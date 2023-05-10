using System.Drawing;
using System.Windows.Forms;

namespace MemoApp.Search {
    public interface ISearchTarget {
        string Text { get; }
        int TextLength { get; }
        string SelectedText { get; set; }
        int SelectionStart { get; set; }
        int SelectionLength { get; set; }
        Color SelectionBackColor { get; set; }
        Color BackColor { get; }
        void Select(int vStart, int vLength);
        void SelectAll();
        event KeyEventHandler KeyDown;
    }
}
