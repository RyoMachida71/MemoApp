using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MemoApp.Search {
    /// <summary>
    /// In the middle of implementation
    /// </summary>
    public class RegexSearcher : ISearcher {
        private ISearchTarget FSearchTarget;
        private SearchArg FArg;
        private Regex FForwardSearcher;
        private Regex FBackwardSearcher;

        public RegexSearcher(ISearchTarget vSearchTarget) {
            FSearchTarget = vSearchTarget;
        }

        public void PrepareSearch(SearchArg vArg) {
            FArg = vArg;
            FForwardSearcher = new Regex(vArg.SearchText, RegexOptions.Compiled | RegexOptions.Multiline);
            FBackwardSearcher = new Regex(vArg.SearchText, RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.RightToLeft);
        }

        public int SearchForward() {
            var wOffset = FSearchTarget.SelectionLength == 0 ? 0 : 1;
            var wMatch = FForwardSearcher.Match(FSearchTarget.Text, FSearchTarget.SelectionStart + wOffset);
            if (!wMatch.Success) return -1;
            FSearchTarget.Select(wMatch.Index, wMatch.Length);
            return wMatch.Index;
        }

        public int SearchBackward() {
            var wMatch = InternalSearchBackward();
            if (!wMatch.Success) return -1;
            FSearchTarget.Select(wMatch.Index, wMatch.Length);
            return wMatch.Index;
        }
        private Match InternalSearchBackward() => FBackwardSearcher.Match(FSearchTarget.Text, FSearchTarget.SelectionStart);

        public int SearchAll() {
            var wOriginalPosition = FSearchTarget.SelectionStart;
            FSearchTarget.SelectionStart = FSearchTarget.Text.Length;
            Match wMatch;
            while (true) {
                wMatch = InternalSearchBackward();
                if (!wMatch.Success) break;
                FSearchTarget.SelectionStart = wMatch.Index;
                FSearchTarget.SelectionLength = wMatch.Length;
                FSearchTarget.HighlightSelectedText();
            }
            FSearchTarget.Select(wOriginalPosition, 0);
            return wMatch.Index;
        }

        public int ReplaceForward() {
            var wIndex = this.SearchForward();
            if (wIndex >= 0) {
                FSearchTarget.SelectedText = Regex.Unescape(FArg.ReplaceText);
            }
            return wIndex;
        }

        public int ReplaceBackward() {
            var wIndex = this.SearchBackward();
            int wOriginalPosition = FSearchTarget.SelectionStart;
            if (wIndex >= 0) {
                FSearchTarget.SelectedText = Regex.Unescape(FArg.ReplaceText);
            }
            FSearchTarget.SelectionStart = wOriginalPosition;
            return wIndex;
        }
        
        public int ReplaceAll() {
            var wOriginalPosition = FSearchTarget.SelectionStart;
            int wIndex = FSearchTarget.SelectionStart = FSearchTarget.Text.Length;
            while (wIndex >= 0) {
                wIndex = this.ReplaceBackward();
            }
            FSearchTarget.Select(wOriginalPosition, 0);
            return wIndex;
        }
    }
}
