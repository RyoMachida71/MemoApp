using MemoApp.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoApp.View {
    public partial class SearchForm : Form {
        private ISearcher FSearcher;
        public SearchForm(SearchMode vSearchMode, ISearcher vSearcher) {
            InitializeComponent();
            FSearcher = vSearcher;
            if (vSearchMode == SearchMode.Search) this.InitializeSearchForm();
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
            btnReplaceForward.Location = btnBackSearch.Location;
            btnReplaceBackward.Location = btnForwardSearch.Location;
            btnReplaceAll.Location = btnAllSearch.Location;
        }

        private void SearchForward_Click(object sender, EventArgs e) => FSearcher.SearchForward(this.tbxSearch.Text, this.chbIgnoreCase.Checked);
        private void SearchBackward_Click(object sender, EventArgs e) => FSearcher.SearchBackward(this.tbxSearch.Text, this.chbIgnoreCase.Checked);
        private void ReplaceForward_Click(object sender, EventArgs e) => FSearcher.ReplaceForward(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked);
        private void ReplaceBackward_Click(object sender, EventArgs e) => FSearcher.ReplaceBackward(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked);
        private void ReplaceAll_Click(object sender, EventArgs e) => FSearcher.ReplaceAll(this.tbxSearch.Text, this.tbxReplace.Text, this.chbIgnoreCase.Checked);

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
