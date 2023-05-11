using System.Drawing;
using System.Windows.Forms;

namespace MemoApp.Search {
    public interface ISearchTarget {
        string Text { get; }
        string SelectedText { get; set; }
        int SelectionStart { get; set; }
        int SelectionLength { get; set; }
        Color SelectionBackColor { get; set; }
        void Select(int vStart, int vLength);
        void RefreshSelection();
        event KeyEventHandler KeyDown;
    }
}
