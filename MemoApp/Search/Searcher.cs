using System;

namespace MemoApp.Search {
    public class Searcher : ISearcher {
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
            var wIndex = FSearchTarget.Text.LastIndexOf(FArg.SearchText, FSearchTarget.SelectionStart, GetStringComparison(FArg.IsDistinguishCase));
            if (wIndex >= 0) FSearchTarget.Select(wIndex, FArg.SearchText.Length);
            return wIndex;
        }

        public int SearchAll() {
            var wOriginalPosition = FSearchTarget.SelectionStart;
            int wIndex = FSearchTarget.SelectionStart = 0;
            while (true) {
                wIndex = this.SearchForward();
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
                int wOldPosition = FSearchTarget.SelectionStart;
                FSearchTarget.SelectedText = FArg.ReplaceText;
                FSearchTarget.SelectionStart = wOldPosition;
            }
            return wIndex;
        }

        public int ReplaceAll() {
            var wOriginalPosition = FSearchTarget.SelectionStart;
            int wIndex = FSearchTarget.SelectionStart = 0;
            while (wIndex >= 0) {
                wIndex = this.ReplaceForward();
            }
            FSearchTarget.Select(wOriginalPosition, 0);
            return wIndex;
        }

        private StringComparison GetStringComparison(bool vIsDistinguishCase) => vIsDistinguishCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
    }
}
