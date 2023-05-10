
namespace MemoApp.Search {
    public class SearchArg {
        public string SearchText { get; private set; }
        public string ReplaceText { get; private set; }
        public bool IsDistinguishCase { get; private set; }
        private SearchArg(string vSearchText, string vReplaceText, bool vIsDistinguishCase) {
            this.SearchText = vSearchText;
            this.ReplaceText = vReplaceText;
            this.IsDistinguishCase = vIsDistinguishCase;
        }
        public static SearchArg CreateSearch(string vSearchText, bool vIsDistinguishCase) {
            return new SearchArg(vSearchText, "", vIsDistinguishCase);
        }
        public static SearchArg CreateReplace(string vSearchText, string vReplaceText, bool vIsDistinguishCase) {
            return new SearchArg(vSearchText, vReplaceText, vIsDistinguishCase);
        }
    }
}
