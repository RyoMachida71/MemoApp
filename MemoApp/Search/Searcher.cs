using System;

namespace MemoApp.Search {
    public class Searcher : ISearcher {
        private ISearchTarget FSearchTarget;
        private SearchArg FArg;
        private StringComparison FStringComparison;

        public Searcher(ISearchTarget vSearchTarget) {
            FSearchTarget = vSearchTarget;
        }

        public void PrepareSearch(SearchArg vArg) {
            FArg = vArg;
            FStringComparison = vArg.IsDistinguishCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
        }

        public int SearchForward() {
            var wOffset = FSearchTarget.SelectedText.Equals(FArg.SearchText, FStringComparison) ? 1 : 0;
            var wSearchStartIndex = FSearchTarget.Text.IndexOf(FArg.SearchText, FSearchTarget.SelectionStart + wOffset, FStringComparison);
            if (wSearchStartIndex >= 0) FSearchTarget.Select(wSearchStartIndex, FArg.SearchText.Length);
            return wSearchStartIndex;
        }

        public int SearchBackward() {
            var wIndex = FSearchTarget.Text.LastIndexOf(FArg.SearchText, FSearchTarget.SelectionStart, FStringComparison);
            if (wIndex >= 0) FSearchTarget.Select(wIndex, FArg.SearchText.Length);
            return wIndex;
        }

        public int SearchAll() {
            var wOriginalPosition = FSearchTarget.SelectionStart;
            int wIndex = FSearchTarget.SelectionStart = FSearchTarget.Text.Length - 1;
            while (true) {
                wIndex = this.SearchBackward();
                if (wIndex == -1) break;
                FSearchTarget.SelectionStart = wIndex;
                FSearchTarget.SelectionLength = FArg.SearchText.Length;
                FSearchTarget.HighlightSelectedText();
            }
            FSearchTarget.Select(wOriginalPosition, 0);
            return wIndex;
        }

        public int ReplaceForward() {
            var wIndex = this.SearchForward();
            if (FSearchTarget.SelectedText == FArg.SearchText) FSearchTarget.SelectedText = FArg.ReplaceText;
            return wIndex;
        }

        public int ReplaceBackward() {
            var wIndex = this.SearchBackward();
            if (FSearchTarget.SelectedText == FArg.SearchText) {
                int wOriginalPosition = FSearchTarget.SelectionStart;
                FSearchTarget.SelectedText = FArg.ReplaceText;
                FSearchTarget.SelectionStart = wOriginalPosition;
            }
            return wIndex;
        }

        public int ReplaceAll() {
            var wOriginalPosition = FSearchTarget.SelectionStart;
            int wIndex = FSearchTarget.SelectionStart = FSearchTarget.Text.Length - 1;
            while (wIndex >= 0) {
                wIndex = this.ReplaceBackward();
            }
            FSearchTarget.Select(wOriginalPosition, 0);
            return wIndex;
        }
    }
}
