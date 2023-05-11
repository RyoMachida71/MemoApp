using System.Windows.Forms;

namespace MemoApp.Search {
    public class SearchController {
        ISearchTarget FSearchTarget;
        ISearcher FSearcher;
        Mode FCurrentMode;
        public SearchController(ISearchTarget vSearchTarget) {
            FSearcher = new Searcher(vSearchTarget);
            FSearchTarget = vSearchTarget;
        }
        public void ShowSearchForm() {
            var wForm = new SearchForm(FSearcher);
            FSearchTarget.KeyDown += Key_Down;
            wForm.FormClosed += (s, e) => {
                FCurrentMode = Mode.Search;
            };
            wForm.Show();
        }
        public void ShowReplaceForm() {
            var wForm = new ReplaceForm(FSearcher);
            FSearchTarget.KeyDown += Key_Down;
            wForm.FormClosed += (s, e) => {
                FCurrentMode = Mode.Replace;
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
            FSearchTarget.KeyDown -= Key_Down;
            FSearchTarget.RefreshSelection();
        }
    }
}
