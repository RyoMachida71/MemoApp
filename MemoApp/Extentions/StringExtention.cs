using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.Extentions {
    public static class StringExtention {
        public static bool ContainsWithIgnoreCase(this string vString, string vTargetString) {
            var wIndex = vString.IndexOf(vTargetString, StringComparison.OrdinalIgnoreCase);
            return wIndex >= 0;
        }
    }
}
