using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.Search {
    public class SearchArg {
        public Mode Mode { get; private set; }
        public string SearchText { get; private set; }
        public string ReplaceText { get; private set; }
        public bool IsIgnoreCase { get; private set; }
        private SearchArg(Mode vMode, string vSearchText, string vReplaceText, bool vIsIgnoreCase) {
            this.Mode = vMode;
            this.SearchText = vSearchText;
            this.ReplaceText = vReplaceText;
            this.IsIgnoreCase = vIsIgnoreCase;
        }
        public static SearchArg CreateSearch(string vSearchText, bool vIsIgnoreCase) {
            return new SearchArg(Mode.Search, vSearchText, "", vIsIgnoreCase);
        }
        public static SearchArg CreateReplace(string vSearchText, string vReplaceText, bool vIsIgnoreCase) {
            return new SearchArg(Mode.Replace, vSearchText, vReplaceText, vIsIgnoreCase);
        }
    }
}
