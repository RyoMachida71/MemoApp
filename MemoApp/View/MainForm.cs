using MemoApp.Files;
using MemoApp.Grep;
using MemoApp.Search;
using MemoApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MemoApp {
    public partial class Memo : Form, ISearcher {
        private const string C_TitleForNew = "新規";
        private TabPage CurrentTab => this.tbcMemo.SelectedTab;
        private CustomTextBox CurrentTextBox => CurrentTab.Tag as CustomTextBox;
        private IFile CurrentFile {
            get {
                var wTextFile = CurrentTextBox.Tag as IFile;
                if (wTextFile != null) wTextFile.Text = CurrentTextBox.Text;
                return wTextFile;
            }
            set { this.CurrentTextBox.Tag = value; }
        }
        public Memo() {
            InitializeComponent();
        }
        private void AddTab(string vTitle = C_TitleForNew) {
            var wTab = new TabPage();
            var wTextBox = new CustomTextBox();
            wTextBox.Parent = wTab;
            wTextBox.DragDrop += (s, e) => this.File_DragDrop(s, e);
            wTextBox.DragEnter += (s, e) => this.File_DragEnter(s, e);
            wTab.Text = vTitle;
            wTab.Tag = wTextBox;
            this.tbcMemo.TabPages.Add(wTab);
            this.tbcMemo.SelectedTab = wTab;
            wTextBox.Focus();
        }

        private void AddTab(IFile vFile) {
            var wTab = new TabPage();
            var wTextBox = new CustomTextBox();
            wTextBox.Parent = wTab;
            wTextBox.Text = vFile.Text;
            wTextBox.ReadOnly = vFile.IsReadOnly;
            wTextBox.Tag = vFile;
            wTab.Text = vFile.Name;
            wTab.Tag = wTextBox;
            this.tbcMemo.TabPages.Add(wTab);
            this.tbcMemo.SelectedTab = wTab;
            // Avoid selecting all texts when setting the file text to TextBox.Text
            wTextBox.Select(0, 0);
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
            var wDialog = new OpenFileDialog() { Title = "開く"};
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
                var wDialog = new SaveFileDialog() { Title = "名前を付けて保存" };
                if (wDialog.ShowDialog() != DialogResult.OK) return;
                IFile wFile = new TextFile(wDialog.FileName);
                wFile.Text = CurrentTextBox.Text;
                this.CurrentFile = wFile;
                this.CurrentTab.Text = wFile.Name;
            }
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
            var wSearchForm = new SearchForm(SearchMode.Search, this);
            wSearchForm.Show();
        }
        private void Replace_Click(object sender, EventArgs e) {
            var wReplaceForm = new SearchForm(SearchMode.Replace, this);
            wReplaceForm.Show();
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
            var wSelectedEncoding = ((ToolStripMenuItem)sender).Tag as Encoding;
            // ↓の流れは(https://learn.microsoft.com/ja-jp/dotnet/api/system.text.encoding.convert?view=net-7.0)を参照

            // 現在のテキストボックスの文字列を現在のエンコードのバイト配列に変換

            // 選択されたエンコードに変換

            //↑で取得したバイト配列→char配列に変換→stringに変換してテキストボックスの文字列に代入


        }

        private void Copy_Click(object sender, EventArgs e) => this.CurrentTextBox.Copy();
        private void Cut_Click(object sender, EventArgs e) => this.CurrentTextBox.Cut();
        private void Patste_Click(object sender, EventArgs e) => this.CurrentTextBox.Paste();
        private void SelectAll_Click(object sender, EventArgs e) => this.CurrentTextBox.SelectAll();
        private void Redo_Click(object sender, EventArgs e) => this.CurrentTextBox.Redo();
        private void Undo_Click(object sender, EventArgs e) => this.CurrentTextBox.Undo();

        public void SearchForward(string vSearchText, bool vIsIgnoreCase) => this.CurrentTextBox.SearchForward(vSearchText, vIsIgnoreCase);
        public void SearchBackward(string vSearchText, bool vIsIgnoreCase) => this.CurrentTextBox.SearchBackward(vSearchText, vIsIgnoreCase);
        public void ReplaceForward(string vSearchText, string vReplaceText, bool vIsIgnoreCase) => this.CurrentTextBox.ReplaceForward(vSearchText, vReplaceText, vIsIgnoreCase);
        public void ReplaceBackward(string vSearchText, string vReplaceText, bool vIsIgnoreCase) => this.CurrentTextBox.ReplaceBackward(vSearchText, vReplaceText, vIsIgnoreCase);
        public void ReplaceAll(string vSearchText, string vReplaceText, bool vIsIgnoreCase) => this.CurrentTextBox.ReplaceAll(vSearchText, vReplaceText, vIsIgnoreCase);

    }
}
