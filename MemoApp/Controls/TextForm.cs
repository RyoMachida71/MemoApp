using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoApp.Controls {
    public partial class TextForm : UserControl {
        public Panel LineNumberPanel => panel1;
        public CustomTextBox TextBox => this.customTextBox1;
        public TextForm() {
            InitializeComponent();
            AdjustSize();
            this.Dock = DockStyle.Fill;
            TextBox.TextChanged += (s, e) => TextBox_TextChanged(s, e);
            TextBox.VScroll += (s, e) => TextBox_VSchroll(s, e);
        }
        private void AdjustSize() {
            this.Size = new Size(50, 50);
            LineNumberPanel.Size = new Size(40, 50);
            TextBox.Size = new Size(10, 50);
        }
        private void TextBox_TextChanged(object sender, EventArgs e) => UpdateLineNumber();
        private void TextBox_VSchroll(object sender, EventArgs e) => UpdateLineNumber();
        private void UpdateLineNumber() {
            using (Graphics g = LineNumberPanel.CreateGraphics()) {
                g.Clear(LineNumberPanel.BackColor);
                int wLineCount = TextBox.Lines.Length;
                for (int wLineNumber = 0; wLineNumber < wLineCount; ++wLineNumber) {
                    int wCharIndex = TextBox.GetFirstCharIndexFromLine(wLineNumber);
                    if (wCharIndex == -1) break;
                    var wPoint = TextBox.GetPositionFromCharIndex(wCharIndex);
                    g.DrawString((wLineNumber + 1).ToString(), TextBox.Font, Brushes.Yellow, new PointF(0, wPoint.Y));
                    if (TextBox.Height < wPoint.Y) break;
                }
            }
        }
    }
}
