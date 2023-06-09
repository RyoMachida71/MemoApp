using System.Windows.Forms;

namespace MemoApp.View {
    public partial class LineNumberJumpForm : Form {
        public int LineNumber { get; private set; }
        public LineNumberJumpForm() {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimizeBox = false;
            this.MinimumSize = this.Size;
            this.mtbLineNumber.Mask = "000000";
        }
        private void btnOK_Click(object sender, System.EventArgs e) {
            if (!int.TryParse(this.mtbLineNumber.Text, out int wLineNumber)) return;
            LineNumber = wLineNumber;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e) {
            this.Close();
        }

    }
}
