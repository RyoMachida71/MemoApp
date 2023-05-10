

using System.Windows.Forms;

namespace MemoApp.Search {
    public class SearchController {
        ISearchTarget FSearchTaget;
        ISearcher FSearcher;
        Mode FCurrentMode;
        public SearchController(ISearchTarget vSearchTarget) {
            FSearcher = new Searcher(vSearchTarget);
            FSearchTaget = vSearchTarget;
            FSearchTaget.KeyDown += Key_Down;
        }
        public void ShowSearchForm() {
            FCurrentMode = Mode.Search;
            var wForm = new SearchForm(FSearcher);
            wForm.Show();
        }
        public void ShowReplaceForm() {
            FCurrentMode = Mode.Replace;
            var wForm = new ReplaceForm(FSearcher);
            wForm.Show();
        }
        private void Key_Down(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    ToNormalMode();
                    break;
                case Keys.F3:
                    if (FCurrentMode == Mode.Search) FSearcher.SearchForward();
                    else if (FCurrentMode == Mode.Replace) FSearcher.ReplaceForward();
                    break;
                case Keys.F4:
                    if (FCurrentMode == Mode.Search) FSearcher.SearchBackward();
                    else if (FCurrentMode == Mode.Replace) FSearcher.ReplaceBackward();
                    break;
            }
        }
        private void ToNormalMode() {
            FCurrentMode = Mode.Normal;
            FSearchTaget.KeyDown -= Key_Down;
            FSearcher.EndSearch();
        }
    }
}
