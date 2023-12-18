using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoApp.Controls {
    public partial class LineNumberTextBox : UserControl {
        private const int LeftMargin = 40;
        private const int DrawingOffset = 2;

        private readonly Point _bottomLeft;
        private readonly Brush _fontBrush;
        private StringFormat _lineFormat;
        private int _lastLineCount;

        public CustomTextBox TextBox => customTextBox;
        public LineNumberTextBox() {
            InitializeComponent();
            customTextBox.Initialize();
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
            this.Location = new Point(0, 0);
            this.customTextBox.Location = new Point(LeftMargin, 0);
            this.customTextBox.TextChanged += (s, e) => this.UpdateLineCount();
            this.customTextBox.VScroll += (s, e) => this.UpdateLineCount();
            this.Paint += LineNumberTextBox_Paint;

            _bottomLeft = new Point(0, this.ClientRectangle.Height);
            _fontBrush = new SolidBrush(customTextBox.ForeColor);
            _lineFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        }

        private void UpdateLineCount() {
            if (customTextBox.Lines.Length != _lastLineCount) {
                _lastLineCount = customTextBox.Lines.Length;
                this.Invalidate();
            }
        }

        private void LineNumberTextBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(customTextBox.BackColor);

            var visibleFirstLine = GetVisibleLine(Point.Empty);
            var visibleLastLine = GetVisibleLine(_bottomLeft);
            for (int i = visibleFirstLine; i <= visibleLastLine + 1; ++i) {
                var yPos = GetYPositionOfLine(i);
                if (yPos == -1) continue;
                e.Graphics.DrawString((i + 1).ToString(), this.Font, Brushes.White, new RectangleF(0, yPos + DrawingOffset, LeftMargin, this.Font.Height), _lineFormat);
            }
        }

        private int GetVisibleLine(Point pos) {
            var index = customTextBox.GetCharIndexFromPosition(pos);
            return customTextBox.GetLineFromCharIndex(index);
        }

        private int GetYPositionOfLine(int line) {
            var index = customTextBox.GetFirstCharIndexFromLine(line);
            if (index == -1) return index;
            return customTextBox.GetPositionFromCharIndex(index).Y;
        }
    }
}
