using MemoApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.Search {
    public interface ISearcher {
        void PrepareSearch(SearchArg vArg);
        int SearchForward();
        int SearchBackward();
        void SearchAll();
        int ReplaceForward();
        int ReplaceBackward();
        int ReplaceAll();
    }
}
