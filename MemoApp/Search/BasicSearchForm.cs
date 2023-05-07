using System;
using System.Windows.Forms;

namespace MemoApp.Search {
    public partial class BasicSearchForm : Form {
        protected ISearcher FSearcher;
        /// <summary>
        /// デザイナ表示用のデフォルトコンストラクタ
        /// </summary>
        public BasicSearchForm() {
            InitializeComponent();
        }
        public BasicSearchForm(ISearcher vSearcher) {
            InitializeComponent();
            FSearcher = vSearcher;
        }
        protected void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        protected virtual void btnForward_Click(object sender, EventArgs e) {}

        protected virtual void btnBackward_Click(object sender, EventArgs e) {}

        protected virtual void btnAll_Click(object sender, EventArgs e) {}
    }
}
