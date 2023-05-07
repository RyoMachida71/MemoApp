using System;

namespace MemoApp.Search {
    public partial class SearchForm : BasicSearchForm {
        public SearchForm(ISearcher vSeacher) : base(vSeacher) {
            this.Text = "検索";
            this.btnForward.Text = "前方検索";
            this.btnBackward.Text = "後方検索";
            this.btnAll.Text = "全検索";
            this.lblReplace.Enabled = false;
            this.lblReplace.Visible = false;
            this.tbxReplace.Enabled = false;
            this.tbxReplace.Visible = false;
        }

        protected override void btnForward_Click(object sender, EventArgs e) {
            this.FSearcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbIgnoreCase.Checked));
            this.FSearcher.SearchForward();
            this.Close();
        }

        protected override void btnBackward_Click(object sender, EventArgs e) {
            this.FSearcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbIgnoreCase.Checked));
            this.FSearcher.SearchBackward();
            this.Close();
        }

        protected override void btnAll_Click(object sender, EventArgs e) {
            this.FSearcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbIgnoreCase.Checked));
            this.FSearcher.SearchAll();
            this.Close();
        }
    }
}
