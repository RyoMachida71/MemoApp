using System.Windows.Forms;

namespace MemoApp.Search {
    public interface ISearchTarget {
        string Text { get; }
        string SelectedText { get; set; }
        int SelectionStart { get; set; }
        int SelectionLength { get; set; }
        void Select(int vStart, int vLength);
        void HighlightSelectedText();
        void DeselectAll();
        event KeyEventHandler KeyDown;
    }
}
