using MemoApp.Search;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MemoApp {
    public enum Mode {
        Normal,
        Search,
        Replace
    }
    [ToolboxItem(true)]
    public class CustomTextBox : RichTextBox, ISearcher {
        private const int C_LeftMargin = 4;
        private Mode FCurrentMode = Mode.Normal;
        private SearchArg FArg;
        public CustomTextBox() {
            Initialize();
        }
        private void Initialize() {
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ContextMenuStrip = CreatePopupMenu();
            this.Dock = DockStyle.Fill;
            this.DetectUrls = true;
            this.Font = new Font("ＭＳ ゴシック", 10);
            this.ForeColor = System.Drawing.Color.White;
            this.LanguageOption = RichTextBoxLanguageOptions.AutoFont;
            this.Multiline = true;
            this.Modified = false;
            this.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            this.SelectionIndent = C_LeftMargin;
            this.WordWrap = true;
            this.KeyDown += this.KeyPressed;
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
        public void PrepareSearch(SearchArg vArg) {
            FCurrentMode = vArg.Mode;
            FArg = vArg;
        }
        public int SearchForward() {
            this.Focus();
            var wOffset = this.SelectedText.Equals(FArg.SearchText, GetStringComparison(FArg.IsIgnoreCase)) ? 1: 0;
            var wSearchStartIndex = this.Text.IndexOf(FArg.SearchText, this.SelectionStart + wOffset, GetStringComparison(FArg.IsIgnoreCase));
            if (wSearchStartIndex >= 0) this.Select(wSearchStartIndex, FArg.SearchText.Length);
            return wSearchStartIndex;
        }
        public int SearchBackward() {
            this.Focus();
            var wSearchStartIndex = (this.SelectionStart + FArg.SearchText.Length - 1) - 1;
            if (wSearchStartIndex < 0) return -1;
            if (wSearchStartIndex > this.Text.Length) wSearchStartIndex = this.Text.Length;
            var wIndex = this.Text.LastIndexOf(FArg.SearchText, wSearchStartIndex, GetStringComparison(FArg.IsIgnoreCase));
            if (wIndex >= 0) this.Select(wIndex, FArg.SearchText.Length);
            return wIndex;
        }
        public int SearchAll() {
            this.FCurrentMode = Mode.Search;
            var wIndexList = new List<int>();
            var wSearchStartIndex = 0;
            while (wSearchStartIndex < this.TextLength) {
                var wHitIndex = this.Text.IndexOf(FArg.SearchText, wSearchStartIndex, GetStringComparison(FArg.IsIgnoreCase));
                if (wHitIndex == -1) break;
                wIndexList.Add(wHitIndex);
                wSearchStartIndex = ++wHitIndex;
            }
            if (wIndexList.Count == 0) {
                MessageBox.Show("検索文字列にヒットしませんでした。");
                return -1;
            }
            foreach (var wIndex in wIndexList) {
                this.SelectionStart = wIndex;
                this.SelectionLength = FArg.SearchText.Length;
                this.SelectionBackColor = Color.Red;
            }
            return wSearchStartIndex;
        }
        public int ReplaceForward() {
            this.Focus();
            if (this.SelectedText == FArg.SearchText) this.SelectedText = FArg.ReplaceText;
            var wIndex = this.SearchForward();
            return wIndex;
        }
        public int ReplaceBackward() {
            this.Focus();
            if (this.SelectedText == FArg.SearchText) {
                int wOldPosition = this.SelectionStart;
                this.SelectedText = FArg.ReplaceText;
                this.SelectionStart = wOldPosition;
            }
            var wIndex = this.SearchBackward();
            return wIndex;
        }
        public int ReplaceAll() {
            int wIndex = this.SelectionStart = 0;
            while (wIndex >= 0) {
                wIndex = this.ReplaceForward();
            }
            return wIndex;
        }

        private StringComparison GetStringComparison(bool vIsIgnoreCase) => vIsIgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

        private void KeyPressed(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    ToNormalMode();
                    break;
                case Keys.F3:
                    if (FCurrentMode == Mode.Search) this.SearchForward();
                    else if (FCurrentMode == Mode.Replace) this.ReplaceForward();
                    break;
                // todo: Shiftを修飾キーとして押されたままでかつF3が押下されているかどうかを判別する
                case Keys.Shift | Keys.F3:
                    if (FCurrentMode == Mode.Search) this.SearchBackward();
                    else if (FCurrentMode == Mode.Replace) this.ReplaceBackward();
                    break;
            }
        }
        private void ToNormalMode() {
            if (this.FCurrentMode != Mode.Normal) {
                var wCaret = this.SelectionStart;
                this.SelectAll();
                this.SelectionBackColor = this.BackColor;
                this.Select(wCaret, 0);
                this.FCurrentMode = Mode.Normal;
            }
        }
        
    }
}
