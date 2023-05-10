using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoApp.Search {
    internal class Searcher : ISearcher {
        private ISearchTarget FSearchTarget;
        private SearchArg FArg;

        public Searcher(ISearchTarget vSearchTarget) { 
            FSearchTarget = vSearchTarget;
        }

        public void PrepareSearch(SearchArg vArg) {
            FArg = vArg;
        }
        public int SearchForward() {
            var wOffset = FSearchTarget.SelectedText.Equals(FArg.SearchText, GetStringComparison(FArg.IsDistinguishCase)) ? 1 : 0;
            var wSearchStartIndex = FSearchTarget.Text.IndexOf(FArg.SearchText, FSearchTarget.SelectionStart + wOffset, GetStringComparison(FArg.IsDistinguishCase));
            if (wSearchStartIndex >= 0) FSearchTarget.Select(wSearchStartIndex, FArg.SearchText.Length);
            return wSearchStartIndex;
        }

        public int SearchBackward() {
            var wSearchStartIndex = (FSearchTarget.SelectionStart + FArg.SearchText.Length - 1) - 1;
            if (wSearchStartIndex < 0) return -1;
            if (wSearchStartIndex > FSearchTarget.Text.Length) wSearchStartIndex = FSearchTarget.Text.Length;
            var wIndex = FSearchTarget.Text.LastIndexOf(FArg.SearchText, wSearchStartIndex, GetStringComparison(FArg.IsDistinguishCase));
            if (wIndex >= 0) FSearchTarget.Select(wIndex, FArg.SearchText.Length);
            return wIndex;
        }

        public int SearchAll() {
            var wIndexList = new List<int>();
            var wSearchStartIndex = 0;
            while (wSearchStartIndex < FSearchTarget.TextLength) {
                var wHitIndex = FSearchTarget.Text.IndexOf(FArg.SearchText, wSearchStartIndex, GetStringComparison(FArg.IsDistinguishCase));
                if (wHitIndex == -1) break;
                wIndexList.Add(wHitIndex);
                wSearchStartIndex = ++wHitIndex;
            }
            if (wIndexList.Count == 0) {
                MessageBox.Show("検索文字列にヒットしませんでした。");
                return -1;
            }
            foreach (var wIndex in wIndexList) {
                FSearchTarget.SelectionStart = wIndex;
                FSearchTarget.SelectionLength = FArg.SearchText.Length;
                FSearchTarget.SelectionBackColor = Color.Red;
            }
            return wSearchStartIndex;
        }

        public int ReplaceForward() {
            var wIndex = this.SearchForward();
            if (FSearchTarget.SelectedText == FArg.SearchText) FSearchTarget.SelectedText = FArg.ReplaceText;
            return wIndex;
        }

        public int ReplaceBackward() {
            var wIndex = this.SearchBackward();
            if (FSearchTarget.SelectedText == FArg.SearchText) {
                int wOldPosition = FSearchTarget.SelectionStart;
                FSearchTarget.SelectedText = FArg.ReplaceText;
                FSearchTarget.SelectionStart = wOldPosition;
            }
            return wIndex;
        }

        public int ReplaceAll() {
            int wIndex = FSearchTarget.SelectionStart = 0;
            while (wIndex >= 0) {
                wIndex = this.ReplaceForward();
            }
            return wIndex;
        }
        public void EndSearch() {
            var wCaret = FSearchTarget.SelectionStart;
            FSearchTarget.SelectAll();
            FSearchTarget.SelectionBackColor = FSearchTarget.BackColor;
            FSearchTarget.Select(wCaret, 0);
        }

        private StringComparison GetStringComparison(bool vIsDistinguishCase) => vIsDistinguishCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
    }
}
