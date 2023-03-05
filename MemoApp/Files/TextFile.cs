using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoApp.Files {
    public class TextFile : IFile {
        private const string LineFeedCode = "\r\n";
        private FileInfo FFileInfo;
        public string Path => FFileInfo.FullName;
        public string Name => FFileInfo.Name;
        public string Text { get; set; }
        // デフォルトはshift-jisとする
        public Encoding Encoding { get; set; } = Encoding.GetEncoding(932);
        public bool IsReadOnly => FFileInfo.IsReadOnly;
        public TextFile(string vPath) {
            FFileInfo= new FileInfo(vPath);
            this.Encoding = EncodingDetecter.Detect(this.Path);
        }

        public Task SaveAsync() => Task.Run(() => {
            using (var wWriter = new FileStream(this.Path, FileMode.Create, FileAccess.Write)) {
                var wBomBytes = this.Encoding.GetPreamble();
                if (wBomBytes.Length > 0) wWriter.Write(wBomBytes, 0, wBomBytes.Length);
                var wText = this.Text.Replace("\n", LineFeedCode);
                var wBytes = this.Encoding.GetBytes(wText);
                wWriter.Write(wBytes, 0, wBytes.Length);
            }
        });

        public Task LoadAsync() => Task.Run(() => {
            using (var wReader = new StreamReader(this.Path, this.Encoding)) {
                this.Text = wReader.ReadToEnd();
            }
        });

        public void ReloadWithSpecifiedEncoding(Encoding vEncoding) {
            using (var wReader = new StreamReader(this.Path, vEncoding)) {
                this.Text = wReader.ReadToEnd();
                this.Encoding = vEncoding;
            }
        }
    }
}
