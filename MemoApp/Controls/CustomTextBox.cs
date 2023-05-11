using MemoApp.Search;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MemoApp {
    [ToolboxItem(true)]
    public class CustomTextBox : RichTextBox, ISearchTarget {
        private const int C_LeftMargin = 4;
        public CustomTextBox() {
            Initialize();
        }
        private void Initialize() {
            this.AcceptsTab= true;
            this.AllowDrop = true;
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.BackColor = System.Drawing.Color.Black;
            this.ContextMenuStrip = CreatePopupMenu();
            this.DetectUrls = true;
            this.Font = new Font("ＭＳ ゴシック", 10f);
            this.ForeColor = System.Drawing.Color.White;
            this.LanguageOption = RichTextBoxLanguageOptions.AutoFont;
            this.Multiline = true;
            this.Modified = false;
            this.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            this.SelectionIndent = C_LeftMargin;
            this.SelectionBackColor = Color.Red;
            this.WordWrap = false;
        }
        private ContextMenuStrip CreatePopupMenu() {
            var wPopupMenu = new ContextMenuStrip();
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "a → A" };
                wMenuItem.Click += (s, e) => this.SelectedText = this.SelectedText.ToUpper();
                wPopupMenu.Items.Add(wMenuItem);
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "A → a" };
                wMenuItem.Click += (s, e) => this.SelectedText = this.SelectedText.ToLower();
                wPopupMenu.Items.Add(wMenuItem);
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "半角 → 全角" };
                wMenuItem.Click += (s, e) => this.SelectedText = Strings.StrConv(this.SelectedText, VbStrConv.Wide);
                wPopupMenu.Items.Add(wMenuItem);
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "全角 → 半角" };
                wMenuItem.Click += (s, e) => this.SelectedText = Strings.StrConv(this.SelectedText, VbStrConv.Narrow);
                wPopupMenu.Items.Add(wMenuItem);
            }
            return wPopupMenu;
        }
        public void RefreshSelection() {
            var wOriginalPosition = this.SelectionStart;
            this.SelectAll();
            this.SelectionBackColor = this.BackColor;
            this.Select(wOriginalPosition, 0);
            this.SelectionBackColor = Color.Red;
        }
    }
}
