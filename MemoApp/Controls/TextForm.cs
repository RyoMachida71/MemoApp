using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MemoApp.Controls {
    public partial class TextForm : UserControl {
        private const string C_DefaultLineNumber = "1" + "\n";
        public RichTextBox LineNumberTextBox => this.rtbLineNumber;
        public CustomTextBox TextBox => this.customTextBox1;
        public TextForm() {
            InitializeComponent();
            InitializeLineNumberTextBox();
            AdjustSize();
            this.Dock = DockStyle.Fill;
            TextBox.TextChanged += TextBox_TextChanged;
            TextBox.VScroll += TextBox_VSchroll;
            LineNumberTextBox.MouseDown += LineNumberTextBox_MouseDown;
        }
        private void InitializeLineNumberTextBox() {
            LineNumberTextBox.Font = TextBox.Font;
            LineNumberTextBox.ForeColor = Color.GreenYellow;
            LineNumberTextBox.BackColor = TextBox.BackColor;
            LineNumberTextBox.Text = C_DefaultLineNumber;
        }
        private void AdjustSize() {
            this.Size = new Size(50, 50);
            LineNumberTextBox.Size = new Size(40, 50);
            TextBox.Size = new Size(10, 50);
        }
        private void TextBox_TextChanged(object sender, EventArgs e) => UpdateLineNumber();
        private void TextBox_VSchroll(object sender, EventArgs e) => UpdateLineNumber();
        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e) {
            TextBox.Select();
        }
        public void UpdateLineNumber() {
            LineNumberTextBox.Text = "";
            if (TextBox.Text == "") LineNumberTextBox.Text = C_DefaultLineNumber;
            for (int wLineNumber = GetTopVisibleLineNumber(); wLineNumber < TextBox.Lines.Length; ++wLineNumber) {
                LineNumberTextBox.Text += (wLineNumber + 1).ToString() + "\n";
            }
        }
        private int GetTopVisibleLineNumber() {
            return SendMessage(this.TextBox.Handle, EM_GETFIRSTVISIBLELINE, 0, 0);
        }
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int EM_GETFIRSTVISIBLELINE = 0x00CE;
    }
}
