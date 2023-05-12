using MemoApp.Controls;
using MemoApp.Files;
using MemoApp.Grep;
using MemoApp.Search;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoApp {
    public partial class Memo : Form {
        private const string C_TitleForNew = "新規";
        private SearchController FSearchController;
        private TabPage CurrentTab => this.tbcMemo.SelectedTab;
        private CustomTextBox CurrentTextBox => ((TextForm)CurrentTab.Tag).TextBox;
        private IFile CurrentFile {
            get { return CurrentTextBox.Tag as IFile; }
            set { this.CurrentTextBox.Tag = value; }
        }
        public Memo() {
            InitializeComponent();
            var wTextForm = new TextForm();
            this.CurrentTab.Controls.Add(wTextForm);
            this.CurrentTab.Tag = wTextForm;
        }
        /// <summary>
        /// Set default focus on textbox when loading
        /// </summary>
        private void Memo_Load(object sender, EventArgs e) {
            this.ActiveControl = this.CurrentTextBox;
        }
        private void AddTab(string vTitle = C_TitleForNew) {
            var wTab = new TabPage();
            this.tbcMemo.TabPages.Add(wTab);
            var wTextForm = new TextForm();
            wTextForm.Parent = wTab;
            wTextForm.DragDrop += (s, e) => this.File_DragDrop(s, e);
            wTextForm.DragEnter += (s, e) => this.File_DragEnter(s, e);
            wTab.Text = vTitle;
            wTab.Tag = wTextForm;
            this.tbcMemo.SelectedTab = wTab;
            wTextForm.TextBox.Focus();
        }

        private void AddTab(IFile vFile) {
            var wTab = new TabPage();
            this.tbcMemo.TabPages.Add(wTab);
            var wTextForm = new TextForm();
            wTextForm.Parent = wTab;
            wTextForm.TextBox.Text = vFile.Text;
            wTextForm.TextBox.ReadOnly = vFile.IsReadOnly;
            wTextForm.TextBox.Tag = vFile;
            wTab.Text = vFile.Name;
            wTab.Tag = wTextForm;
            this.tbcMemo.SelectedTab = wTab;
            // Avoid selecting all texts when setting the file text to TextBox.Text
            wTextForm.TextBox.Select(0, 0);
        }
        private bool ShouldSetFileToCurrentTab() => this.CurrentFile == null && !this.CurrentTextBox.Modified;

        private void SetFileToCurrentTab(IFile vFile) {
            this.CurrentFile = vFile;
            this.CurrentTextBox.Text = vFile.Text;
            this.CurrentTextBox.ReadOnly = vFile.IsReadOnly;
            this.CurrentTab.Text = vFile.Name;
        }

        private void NewFile_Click(object sender, EventArgs e) => this.AddTab();

        private async void Open_Click(object sender, EventArgs e) {
            var wDialog = new OpenFileDialog() { Title = "開く", Filter = "テキストファイル|*.txt|すべてのファイル|*.*" };
            if (wDialog.ShowDialog() != DialogResult.OK) return;
            IFile wFile = new TextFile(wDialog.FileName);
            await wFile.LoadAsync();
            if (this.ShouldSetFileToCurrentTab()) {
                this.SetFileToCurrentTab(wFile);
                return;
            }
            this.AddTab(wFile);
        }

        private async void Save_Clicked(object sender, EventArgs e) {
            if (this.CurrentFile == null) {
                var wDialog = new SaveFileDialog() { Title = "名前を付けて保存", Filter = "テキストファイル|*.txt|すべてのファイル|*.*" };
                if (wDialog.ShowDialog() != DialogResult.OK) return;
                IFile wFile = new TextFile(wDialog.FileName);
                wFile.Text = CurrentTextBox.Text;
                this.CurrentFile = wFile;
                this.CurrentTab.Text = wFile.Name;
            }
            this.CurrentFile.Text = this.CurrentTextBox.Text;
            await this.CurrentFile.SaveAsync();
            this.CurrentTextBox.Modified = false;
        }

        private void CloseCurrentTab_Click(object sender, EventArgs e) {
            if (this.CurrentTextBox.Modified) {
                var wResult = MessageBox.Show(this, $"This content has not saved yet.{Environment.NewLine}Is it Ok to Close?", "Confirmation", MessageBoxButtons.OKCancel);
                if (wResult == DialogResult.Cancel) return;
            }
            this.tbcMemo.TabPages.Remove(this.CurrentTab);
            if (this.tbcMemo.TabPages.Count == 0) this.AddTab();
        }

        private void Search_Click(object sender, EventArgs e) {
            if (FSearchController == null) FSearchController = new SearchController(this.CurrentTextBox);
            FSearchController.ShowSearchForm();
        }
        private void Replace_Click(object sender, EventArgs e) {
            if (FSearchController == null) FSearchController = new SearchController(this.CurrentTextBox);
            FSearchController.ShowReplaceForm();
        }

        private void Grep_Click(object sender, EventArgs e) {
            var wGrepForm = new GrepForm(async (GrepSearch vGrep) => {
                this.AddTab("grep");
                this.CurrentTextBox.Text = await Task.Run(() => vGrep.Run());
            });
            wGrepForm.Show();
        }

        private void Close_Click(object sender, EventArgs e) => this.Close();

        private void File_DragDrop(object sender, DragEventArgs e) {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            var wPaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var wPath in wPaths) {
                IFile wFile = new TextFile(wPath);
                wFile.LoadAsync();
                if (this.ShouldSetFileToCurrentTab()) {
                    this.SetFileToCurrentTab(wFile);
                    continue;
                }
                this.AddTab(wFile);
            }
        }

        private void File_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.All;

        private void EncodingKind_Click(object sender, EventArgs e) {
            if (this.CurrentFile == null) return;
            var wSelectedEncoding = ((ToolStripMenuItem)sender).Tag as Encoding;
            this.CurrentFile.ReloadWith(wSelectedEncoding);
            this.CurrentTextBox.Text = this.CurrentFile.Text;
        }
    }
}
