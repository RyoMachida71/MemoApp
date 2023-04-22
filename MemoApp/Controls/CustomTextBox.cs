using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MemoApp {
    [ToolboxItem(true)]
    public class CustomTextBox : RichTextBox {
        private enum Mode {
            Normal,
            Search
        }
        private const int C_LeftMargin = 4;
        private Mode _Mode { get; set; } = Mode.Normal;
        public CustomTextBox() {
            Initialize();
        }
        private void Initialize() {
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ContextMenuStrip = CreatePopupMenu();
            this.Dock = DockStyle.Fill;
            this.DetectUrls = true;
            // フォント名とサイズは外から渡したほうがよい？(設定ファイルから読み込んだ内容を渡すとか)
            this.Font = new Font("ＭＳ ゴシック", 10);
            this.ForeColor = System.Drawing.Color.White;
            this.LanguageOption = RichTextBoxLanguageOptions.AutoFont;
            this.Multiline = true;
            this.Modified = false;
            this.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.SelectionIndent = C_LeftMargin;
            this.WordWrap = true;
            this.KeyPress += this.KeyPressed;
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
        public int SearchForward(string vSearchString, bool vIsIgnoreCase) {
            this.Focus();
            var wOffset = this.SelectedText.Equals(vSearchString, GetStringComparison(vIsIgnoreCase)) ? 1: 0;
            var wSearchStartIndex = this.Text.IndexOf(vSearchString, this.SelectionStart + wOffset, GetStringComparison(vIsIgnoreCase));
            if (wSearchStartIndex >= 0) this.Select(wSearchStartIndex, vSearchString.Length);
            return wSearchStartIndex;
        }
        public int SearchBackward(string vSearchText, bool vIsIgnoreCase) {
            this.Focus();
            var wSearchStartIndex = (this.SelectionStart + vSearchText.Length - 1) - 1;
            if (wSearchStartIndex < 0) return -1;
            if (wSearchStartIndex > this.Text.Length) wSearchStartIndex = this.Text.Length;
            var wIndex = this.Text.LastIndexOf(vSearchText, wSearchStartIndex, GetStringComparison(vIsIgnoreCase));
            if (wIndex >= 0) this.Select(wIndex, vSearchText.Length);
            return wIndex;
        }
        public void SearchAll(string vSearchText, bool vIsIgnoreCase) {
            this._Mode = Mode.Search;
            var wIndexList = new List<int>();
            var wSearchStartIndex = 0;
            while (true) {
                if (wSearchStartIndex > this.TextLength) break;
                var wHitIndex = this.Text.IndexOf(vSearchText, wSearchStartIndex, GetStringComparison(vIsIgnoreCase));
                if (wHitIndex == -1) break;
                wIndexList.Add(wHitIndex);
                wSearchStartIndex = ++wHitIndex;
            }
            if (wIndexList.Count == 0) {
                MessageBox.Show("検索文字列にヒットしませんでした。");
                return;
            }
            foreach (var wIndex in wIndexList) {
                this.SelectionStart = wIndex;
                this.SelectionLength = wIndex + vSearchText.Length;
                this.SelectionBackColor = Color.Red;
            }
        }
        public int ReplaceForward(string vSearchText, string vReplaceText, bool vIsIgnoreCase) {
            this.Focus();
            if (this.SelectedText == vSearchText) this.SelectedText = vReplaceText;
            var wIndex = this.SearchForward(vSearchText, vIsIgnoreCase);
            return wIndex;
        }
        public int ReplaceBackward(string vSearchText, string vReplaceText, bool vIsIgnoreCase) {
            this.Focus();
            if (this.SelectedText == vSearchText) {
                int wOldPosition = this.SelectionStart;
                this.SelectedText = vReplaceText;
                this.SelectionStart = wOldPosition;
            }
            var wIndex = this.SearchBackward(vSearchText, vIsIgnoreCase);
            return wIndex;
        }
        public int ReplaceAll(string vSearchText, string vReplaceText, bool vIsIgnoreCase) {
            // 全置換
            this.SelectionStart = 0;
            this.SelectionLength = 0;
            int wIndex = 0;
            while (wIndex >= 0) {
                wIndex = this.ReplaceForward(vSearchText, vReplaceText, vIsIgnoreCase);
            }
            return wIndex;
        }
        private StringComparison GetStringComparison(bool vIsIgnoreCase) => vIsIgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

        private void KeyPressed(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case (char)Keys.Escape:
                    ReleaseSearchMode();
                    break;
            }
        }
        private void ReleaseSearchMode() {
            this.SelectAll();
            this.SelectionBackColor = this.BackColor;
            this.Select(0, 0);
            this._Mode = Mode.Normal;
        }
    }
}
