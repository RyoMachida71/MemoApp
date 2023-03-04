using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.Files {
    public interface IFile {
        string Path { get; }
        string Name { get; }
        string Text { get; set; }
        Encoding Encoding { get; set; }
        bool IsReadOnly { get; }
        Task SaveAsync();
        Task LoadAsync();
    }
}
