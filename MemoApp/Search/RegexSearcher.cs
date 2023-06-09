using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MemoApp.Search {
    /// <summary>
    /// In the middle of implementation
    /// </summary>
    public class RegexSearcher : ISearcher {
        private ISearchTarget FSearchTarget;
        private SearchArg FArg;
        private List<Match> FMatches = new List<Match>();

        public RegexSearcher(ISearchTarget vSearchTarget) {
            FSearchTarget = vSearchTarget;
        }

        public void PrepareSearch(SearchArg vArg) {
            FArg = vArg;
        }

        public int SearchForward() {
            foreach (Match wMatch in FMatches) {
                if (wMatch.Index <= FSearchTarget.SelectionStart) continue;
                FSearchTarget.Select(wMatch.Index, wMatch.Length);
                return wMatch.Index;
            }
            return -1;
        }

        public int SearchBackward() {
            for (int i = FMatches.Count - 1; i >= 0; --i) {
                var wMatch = FMatches[i];
                if (wMatch.Index >= FSearchTarget.SelectionStart) continue;
                FSearchTarget.Select(wMatch.Index, wMatch.Length);
                return wMatch.Index;
            }
            return -1;
        }

        public int SearchAll() {
            var wOriginalPosition = FSearchTarget.SelectionStart;
            var wMatches = Regex.Matches(FSearchTarget.Text, FArg.SearchText, RegexOptions.Compiled | RegexOptions.Multiline);
            foreach (Match wMatch in wMatches) {
                FSearchTarget.SelectionStart = wMatch.Index;
                FSearchTarget.SelectionLength = wMatch.Length;
                FSearchTarget.HighlightSelectedText();
                FMatches.Add(wMatch);
            }
            FSearchTarget.SelectionStart = wOriginalPosition;
            return -1;
        }

        public int ReplaceForward() {
            var wIndex = this.SearchForward();
            if (wIndex >= 0) {
                FSearchTarget.SelectedText = Regex.Unescape(FArg.ReplaceText);
                FMatches.Remove(FMatches.Find(x => x.Index == wIndex));
            }
            return wIndex;
        }

        public int ReplaceBackward() {
            var wIndex = this.SearchBackward();
            int wOriginalPosition = FSearchTarget.SelectionStart;
            if (wIndex >= 0) {
                FSearchTarget.SelectedText = Regex.Unescape(FArg.ReplaceText);
                FMatches.Remove(FMatches.Find(x => x.Index == wIndex));
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
