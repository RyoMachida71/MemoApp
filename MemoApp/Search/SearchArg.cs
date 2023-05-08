
namespace MemoApp.Search {
    public class SearchArg {
        public Mode Mode { get; private set; }
        public string SearchText { get; private set; }
        public string ReplaceText { get; private set; }
        public bool IsDistinguishCase { get; private set; }
        private SearchArg(Mode vMode, string vSearchText, string vReplaceText, bool vIsDistinguishCase) {
            this.Mode = vMode;
            this.SearchText = vSearchText;
            this.ReplaceText = vReplaceText;
            this.IsDistinguishCase = vIsDistinguishCase;
        }
        public static SearchArg CreateSearch(string vSearchText, bool vIsDistinguishCase) {
            return new SearchArg(Mode.Search, vSearchText, "", vIsDistinguishCase);
        }
        public static SearchArg CreateReplace(string vSearchText, string vReplaceText, bool vIsDistinguishCase) {
            return new SearchArg(Mode.Replace, vSearchText, vReplaceText, vIsDistinguishCase);
        }
    }
}
