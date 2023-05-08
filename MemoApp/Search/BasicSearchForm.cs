using System;
using System.Windows.Forms;

namespace MemoApp.Search {
    public partial class BasicSearchForm : Form {
        protected ISearcher FSearcher;
        /// <summary>
        /// Default constructor to make designer work properly
        /// </summary>
        public BasicSearchForm() {
            InitializeComponent();
        }
        public BasicSearchForm(ISearcher vSearcher) {
            InitializeComponent();
            FSearcher = vSearcher;
        }
        protected void RunSearch(Func<int> vSearch) {
            this.FSearcher.PrepareSearch(SearchArg.CreateSearch(this.tbxSearch.Text, this.chbDistinguishCase.Checked));
            vSearch();
            this.Close();
        }
        protected void RunReplace(Func<int> vReplace) {
            this.FSearcher.PrepareSearch(SearchArg.CreateReplace(this.tbxSearch.Text, this.tbxReplace.Text, this.chbDistinguishCase.Checked));
            vReplace();
            this.Close();
        }
        protected void btnClose_Click(object sender, EventArgs e) => this.Close();

        protected virtual void btnForward_Click(object sender, EventArgs e) {}

        protected virtual void btnBackward_Click(object sender, EventArgs e) {}

        protected virtual void btnAll_Click(object sender, EventArgs e) {}
    }
}
