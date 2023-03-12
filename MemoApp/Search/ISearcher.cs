using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.Search {
    public interface ISearcher {
        void SearchForward(string vSearchText, bool vIsIgnoreCase);
        void SearchBackward(string vSearchText, bool vIsIgnoreCase);
        void SearchAll(string vSearchText, bool vIsIgnoreCase);
        void ReplaceForward(string vSearchText, string vReplaceText, bool vIsIgnoreCase);
        void ReplaceBackward(string vSearchText, string vReplaceText, bool vIsIgnoreCase);
        void ReplaceAll(string vSearchText, string vReplaceText, bool vIsIgnoreCase);
    }
}
