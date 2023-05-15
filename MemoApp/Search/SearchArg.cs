using System;

namespace MemoApp.Search {
    public class SearchArg {
        public string SearchText { get; private set; }
        public string ReplaceText { get; private set; }
        public StringComparison StringComparison { get; private set; }
        private SearchArg(string vSearchText, string vReplaceText, bool vIsDistinguishCase) {
            this.SearchText = $@"{vSearchText}";
            this.ReplaceText = $@"{vReplaceText}";
            this.StringComparison = vIsDistinguishCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
        }
        public static SearchArg CreateSearch(string vSearchText, bool vIsDistinguishCase) {
            return new SearchArg(vSearchText, "", vIsDistinguishCase);
        }
        public static SearchArg CreateReplace(string vSearchText, string vReplaceText, bool vIsDistinguishCase) {
            return new SearchArg(vSearchText, vReplaceText, vIsDistinguishCase);
        }
    }
}
