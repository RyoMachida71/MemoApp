using System.IO;
using System.Text;
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
            var wSb = new StringBuilder();
            using (var wReader = new StreamReader(this.Path, this.Encoding)) {
                while (!wReader.EndOfStream) {
                    wSb.AppendLine(wReader.ReadLine());
                }
            }
            this.Text = wSb.ToString();
        });

        public void ReloadWith(Encoding vEncoding) {
            var wSb = new StringBuilder();
            using (var wReader = new StreamReader(this.Path, vEncoding)) {
                this.Encoding = vEncoding;
                while (!wReader.EndOfStream) {
                    wSb.AppendLine(wReader.ReadLine());
                }
            }
            this.Text = wSb.ToString();
        }
    }
}
