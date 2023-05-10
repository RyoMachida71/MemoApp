namespace MemoApp.Search {
    public interface ISearcher {
        void PrepareSearch(SearchArg vArg);
        int SearchForward();
        int SearchBackward();
        int SearchAll();
        int ReplaceForward();
        int ReplaceBackward();
        int ReplaceAll();
        void EndSearch();
    }
}
