using System;
using System.Text.RegularExpressions;

namespace MemoApp.Search {
    public class RegexSearcher : ISearcher {
        private ISearchTarget FSearchTarget;
        private SearchArg FArg;
        private Regex FRegex;
        private StringComparison FStrignComparison;
        public RegexSearcher(ISearchTarget vSearchTarget) {
            FSearchTarget = vSearchTarget;
        }
        public void PrepareSearch(SearchArg vArg) {
            FArg = vArg;
            RegexOptions wOptions = FArg.IsDistinguishCase ? RegexOptions.None | RegexOptions.Compiled : RegexOptions.IgnoreCase | RegexOptions.Compiled;
            FRegex = new Regex(vArg.SearchText, wOptions);
            FStrignComparison = vArg.IsDistinguishCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
        }

        public int SearchForward() {
            var wOffset = FSearchTarget.SelectedText.Equals(FArg.SearchText, FStrignComparison) ? 1 : 0;
            var wMatch = FRegex.Match(FSearchTarget.Text, FSearchTarget.SelectionStart + wOffset);
            if (!wMatch.Success) return -1;
            FSearchTarget.Select(wMatch.Index, wMatch.Length);
            return wMatch.Index;
        }
        public int SearchBackward() {
            return -1;
        }
        public int SearchAll() {
            return -1;
        }
        public int ReplaceForward() {
            return -1;
        }
        public int ReplaceBackward() {
            return -1;
        }
        public int ReplaceAll() {
            return -1;
        }
    }
}
