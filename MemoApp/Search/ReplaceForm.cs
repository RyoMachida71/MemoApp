using System;

namespace MemoApp.Search {
    public partial class ReplaceForm : BasicSearchForm {
        public ReplaceForm(ISearchTarget vSearchTarget, Action<ISearcher> vDone) : base(vSearchTarget, vDone) {
            this.Text = "置換";
            this.btnForward.Text = "前方置換";
            this.btnBackward.Text = "後方置換";
            this.btnAll.Text = "全置換";
        }

        protected override void btnForward_Click(object sender, EventArgs e) => this.RunReplace(Searcher.ReplaceForward);
        

        protected override void btnBackward_Click(object sender, EventArgs e) => this.RunReplace(Searcher.ReplaceBackward);

        protected override void btnAll_Click(object sender, EventArgs e) => this.RunReplace(Searcher.ReplaceAll);
    }
}
