﻿using MemoApp.Extentions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoApp.Grep {
    public class GrepSearch {
        public string SearchText { get; private set; }
        public string FolderPath { get; private set; }
        public string SearchFile { get; private set; }
        private bool FIsIgnoreCase;
        private bool FIsRegex;
        public GrepSearch(string vSearchText, string vFolderPath, string vSearchFile, bool vIsIgnoreCase, bool vIsRegex) {
            this.SearchText = vSearchText;
            this.FolderPath = vFolderPath;
            this.SearchFile = vSearchFile;
            FIsIgnoreCase= vIsIgnoreCase;
            FIsRegex = vIsRegex;
        }
        public string Run() {
            var wResult = string.Empty;
            foreach (var wPath in Directory.EnumerateFiles(this.FolderPath, this.SearchFile, SearchOption.AllDirectories)) {
                var wTextRows = File.ReadAllLines(wPath, EncodingDetecter.Detect(wPath));
                foreach (var wTextRow in wTextRows) {
                    if (FIsRegex) {
                        var wRegex = new Regex($@"{this.SearchText}");
                        var wMatches = wRegex.Matches(wTextRow);
                        if (wMatches.Count == 0) continue;
                    } else {
                        if (!this.HasSearchText(wTextRow)) continue;
                    }
                    wResult += string.Format("{0}\t{1}\n", wPath, wTextRow);
                }
            }
            if (string.IsNullOrEmpty(wResult)) MessageBox.Show("検索文字列にヒットしませんでした。");
            return wResult;
        }
        private bool HasSearchText(string vCurrentText) => FIsIgnoreCase ? vCurrentText.ContainsWithIgnoreCase(this.SearchText) : vCurrentText.Contains(this.SearchText);
    }
}
