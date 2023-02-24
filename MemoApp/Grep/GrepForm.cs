using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoApp.Grep {
    public partial class GrepForm : Form {
        private Action<GrepSearch> RunGrep;
        public GrepForm(Action<GrepSearch> vRunGrep) {
            InitializeComponent();
            this.RunGrep = vRunGrep;
        }
        private void btnFolderDialog_Click(object sender, EventArgs e) {
            var wDialog = new FolderBrowserDialog();
            if (wDialog.ShowDialog() != DialogResult.OK) return;
            this.tbxFolderPath.Text = wDialog.SelectedPath;
        }
        private void btnRun_Click(object sender, EventArgs e) {
            this.ValidateSearchPropertyValue();
            RunGrep(new GrepSearch(this.tbxSearch.Text, this.tbxFolderPath.Text, this.tbxSearchFile.Text, this.chbIgnoreCase.Checked, this.chbRegularExpression.Checked));
            this.Close();
        }
        private bool ValidateSearchPropertyValue() {
            if (string.IsNullOrEmpty(this.tbxSearch.Text)) {
                this.ShowPromptMessage("You need to specify the search text.");
                return false;
            }
            if (string.IsNullOrEmpty(this.tbxFolderPath.Text)) {
                this.ShowPromptMessage("You need to specify the path for your folder.");
                return false;
            }
            if (string.IsNullOrEmpty(this.tbxSearchFile.Text)) {
                this.ShowPromptMessage("You need to specify the search file.");
                return false;
            }
            return true;
        }
        private void ShowPromptMessage(string vMessage) => MessageBox.Show(vMessage);
    }
}
