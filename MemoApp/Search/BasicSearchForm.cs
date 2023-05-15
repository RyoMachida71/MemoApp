using System;
using System.Windows.Forms;

namespace MemoApp.Search {
    public partial class BasicSearchForm : Form {
        private ISearcher FSearcher;
        protected ISearchTarget FSearchTarget;
        private Action<ISearcher> FDone;
        protected ISearcher Searcher {
            get {
                if (FSearcher == null) {
                    if (this.chbRegularExpression.Checked) FSearcher = new RegexSearcher(FSearchTarget);
                    else FSearcher = new Searcher(FSearchTarget);
                }
                return FSearcher;
            }
        }

        /// <summary>
        /// Default constructor to make designer work properly
        /// </summary>
        public BasicSearchForm() {
            InitializeComponent();
        }

        public BasicSearchForm(ISearchTarget vSearchTarget, Action<ISearcher> vDone) {
            InitializeComponent();
            FSearchTarget = vSearchTarget;
            FDone = vDone;
        }

        protected void RunSearch(Func<int> vSearch) {
            Searcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbDistinguishCase.Checked));
            Searcher.SearchAll();
            vSearch();
            FDone(Searcher);
            this.Close();
        }

        protected void RunReplace(Func<int> vReplace) {
            Searcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbDistinguishCase.Checked));
            Searcher.SearchAll();
            vReplace();
            FDone(Searcher);
            this.Close();
        }

        protected void btnClose_Click(object sender, EventArgs e) => this.Close();

        protected virtual void btnForward_Click(object sender, EventArgs e) {}

        protected virtual void btnBackward_Click(object sender, EventArgs e) {}

        protected virtual void btnAll_Click(object sender, EventArgs e) {}
    }
}
