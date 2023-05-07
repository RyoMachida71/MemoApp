using System;

namespace MemoApp.Search {
    public partial class ReplaceForm : BasicSearchForm {
        public ReplaceForm(ISearcher vSearcher) : base(vSearcher) {
            this.Text = "置換";
            this.btnForward.Text = "前方置換";
            this.btnBackward.Text = "後方置換";
            this.btnAll.Text = "全置換";
        }

        protected override void btnForward_Click(object sender, EventArgs e) {
            this.FSearcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked));
            this.FSearcher.ReplaceForward();
        }

        protected override void btnBackward_Click(object sender, EventArgs e) {
            this.FSearcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked));
            this.FSearcher.ReplaceBackward();
        }

        protected override void btnAll_Click(object sender, EventArgs e) {
            this.FSearcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked));
            this.FSearcher.ReplaceAll();
        }
    }
}
