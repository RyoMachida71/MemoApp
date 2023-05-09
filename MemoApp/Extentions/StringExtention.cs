using System;

namespace MemoApp.Extentions {
    public static class StringExtention {
        public static bool ContainsWithIgnoreCase(this string vString, string vTargetString) {
            var wIndex = vString.IndexOf(vTargetString, StringComparison.OrdinalIgnoreCase);
            return wIndex >= 0;
        }
    }
}
