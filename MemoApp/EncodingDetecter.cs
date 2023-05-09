using System.IO;
using System.Text;

namespace MemoApp {
    public class EncodingDetecter {
        private static Encoding Default => Encoding.GetEncoding(932);
        public static Encoding Detect(string vPath) {
            if (!File.Exists(vPath)) return Default;
            byte[] wBytes;
            using (var wFileStream = File.Open(vPath, FileMode.Open, FileAccess.Read)) {
                wBytes = new byte[wFileStream.Length];
                wFileStream.Read(wBytes, 0, (int)wFileStream.Length);
            }
            if (wBytes.Length <= 0) return Encoding.GetEncoding(932);
            // UTF-8
            if (wBytes[0] == 0xEF && wBytes[1] == 0xBB && wBytes[2] == 0xBF) return new UTF8Encoding(true);
            // UTF-16
            if (wBytes[0] == 0xFF && wBytes[1] == 0xFE) return Encoding.GetEncoding(1200); //UTF-16
            if (wBytes[0] == 0xFE && wBytes[1] == 0xFF) return Encoding.GetEncoding(1201); //UTF-16BE
            // UTF-32
            if (wBytes[0] == 0xFF && wBytes[1] == 0xFE && wBytes[2] == 0x00 && wBytes[3] == 0x00) return new UTF32Encoding(false, true); //UTF-32
            if (wBytes[0] == 0x00 && wBytes[1] == 0x00 && wBytes[2] == 0xFE && wBytes[3] == 0xFF) return new UTF32Encoding(true, true); //UTF-32BE

            // デフォルトはshift-jis
            return Default;
        }
    }
}
