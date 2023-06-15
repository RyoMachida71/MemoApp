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
            {
                wPopupMenu.Items.Add(new ToolStripSeparator());
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "通常", ShortcutKeys = (Keys.Control | Keys.U) };
                wMenuItem.Click += (s, e) => this.ChangeFontStyle(FontStyle.Regular);
                wPopupMenu.Items.Add(wMenuItem);
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "太字", ShortcutKeys = (Keys.Control | Keys.B) };
                wMenuItem.Click += (s, e) => this.ChangeFontStyle(FontStyle.Bold);
                wPopupMenu.Items.Add(wMenuItem);
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "下線", ShortcutKeys = (Keys.Control | Keys.L) };
                wMenuItem.Click += (s, e) => this.ChangeFontStyle(FontStyle.Underline);
                wPopupMenu.Items.Add(wMenuItem);
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "イタリック", ShortcutKeys = (Keys.Control | Keys.I) };
                wMenuItem.Click += (s, e) => this.ChangeFontStyle(FontStyle.Italic);
                wPopupMenu.Items.Add(wMenuItem);
            }
            {
                var wMenuItem = new ToolStripMenuItem() { Text = "取り消し線", ShortcutKeys = (Keys.Control | Keys.E) };
                wMenuItem.Click += (s, e) => this.ChangeFontStyle(FontStyle.Strikeout);
                wPopupMenu.Items.Add(wMenuItem);
            }
            return wPopupMenu;
        }

        private void ChangeFontStyle(FontStyle vStyle) {
            if (this.SelectionFont.Style == vStyle || vStyle == FontStyle.Regular) {
                this.SelectionFont = this.Font;
                return;
            }
            this.SelectionFont = new Font(this.Font.FontFamily, this.Font.Size, SetFontStyle(vStyle));
            this.SelectionStart = SelectionStart + SelectionLength;
            this.SelectionLength = 0;
            this.SelectionFont = this.Font;
        }

        private FontStyle SetFontStyle(FontStyle vStyle) => this.SelectionFont.Style == FontStyle.Regular ? vStyle : this.SelectionFont.Style | vStyle;

        public void HighlightSelectedText() {
            this.SelectionBackColor = Color.Red;
            this.SelectionFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
        }

        void ISearchTarget.DeselectAll() {
            var wOriginalPosition = this.SelectionStart;
            this.SelectAll();
            this.SelectionBackColor = this.BackColor;
            this.SelectionFont = this.Font;
            this.Select(wOriginalPosition, 0);
        }

        public void JumpTo(int vLineNumber) {
            if (vLineNumber <= 0 || vLineNumber > this.Lines.Length) return;
            var wIndex = this.GetFirstCharIndexFromLine(vLineNumber - 1);
            this.SelectionStart = wIndex;
        }
    }
}
