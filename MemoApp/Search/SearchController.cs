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
            var wForm = new SearchForm(FSearcher);
            wForm.FormClosed += (s, e) => {
                FCurrentMode = Mode.Search;
                // create a new status bar and disable existing status
            };
            wForm.Show();
        }
        public void ShowReplaceForm() {
            var wForm = new ReplaceForm(FSearcher);
            wForm.FormClosed += (s, e) => {
                FCurrentMode = Mode.Replace;
                // create a new status bar and disable existing status
            };
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
