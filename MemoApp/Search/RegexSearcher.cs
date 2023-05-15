using System;
using System.Text.RegularExpressions;

namespace MemoApp.Search {
    public class RegexSearcher : ISearcher {
        ISearchTarget FSearchTarget;
        private Regex FRegex;
        public RegexSearcher(ISearchTarget vSearchTarget) {
            FSearchTarget = vSearchTarget;
        }
        public void PrepareSearch(SearchArg vArg) {
            FRegex = new Regex(vArg.SearchText);
        }
        public int SearchForward() {
            //var wMatch = FRegex.Match(FSearchTarget.Text, FSearchTarget.SelectionStart + wOffset);
            //if (!wMatch.Success) return -1;
            //FSearchTarget.Select(wMatch.Index, wMatch.Length);
            //return wMatch.Index;
            return -1;
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
