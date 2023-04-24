using MemoApp.Search;
using System;
using System.Windows.Forms;

namespace MemoApp.View {
    public partial class SearchForm : Form {
        private ISearcher FSearcher;
        public SearchForm(Mode vMode, ISearcher vSearcher) {
            InitializeComponent();
            FSearcher = vSearcher;
            if (vMode == Mode.Search) this.InitializeSearchForm();
            else this.InitializeReplaceForm();
        }
        private void InitializeSearchForm() {
            this.Text = "検索";
            lblReplace.Visible = false;
            tbxReplace.Visible = false;
            btnReplaceForward.Visible = false;
            btnReplaceBackward.Visible = false;
            btnReplaceAll.Visible = false;
        }
        private void InitializeReplaceForm() {
            this.Text = "置換";
            btnForwardSearch.Enabled = false;
            btnForwardSearch.Visible = false;
            btnBackSearch.Enabled = false;
            btnBackSearch.Visible = false;
            btnAllSearch.Enabled = false;
            btnAllSearch.Visible = false;
            btnReplaceForward.Location = btnForwardSearch.Location;
            btnReplaceBackward.Location = btnBackSearch.Location;
            btnReplaceAll.Location = btnAllSearch.Location;
        }

        private void SearchForward_Click(object sender, EventArgs e) {
            FSearcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbIgnoreCase.Checked));
            FSearcher.SearchForward();
        }
        private void SearchBackward_Click(object sender, EventArgs e) {
            FSearcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbIgnoreCase.Checked));
            FSearcher.SearchBackward();
        }
        private void SearchAll_Click(object sender, EventArgs e) {
            FSearcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbIgnoreCase.Checked));
            FSearcher.SearchAll();
            this.Close();
        }
        private void ReplaceForward_Click(object sender, EventArgs e) {
            FSearcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked));
            FSearcher.ReplaceForward();
        }
        private void ReplaceBackward_Click(object sender, EventArgs e) {
            FSearcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked));
            FSearcher.ReplaceBackward();
        }
        private void ReplaceAll_Click(object sender, EventArgs e) {
            FSearcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked));
            FSearcher.ReplaceAll();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
