﻿using System.Text;

namespace MemoApp {
    partial class Memo {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Memo));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前を付けて保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上書き保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.現在のファイルを閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.コピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切り取りToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.貼り付けToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全選択ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検索SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.置換ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcMemo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStripMemo = new System.Windows.Forms.StatusStrip();
            this.toolStripButtonEncodingKind = new System.Windows.Forms.ToolStripSplitButton();
            this.UTF8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UTF16MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UTF32MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShiftJISMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tbcMemo.SuspendLayout();
            this.statusStripMemo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.検索SToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成ToolStripMenuItem,
            this.開くToolStripMenuItem,
            this.名前を付けて保存ToolStripMenuItem,
            this.上書き保存ToolStripMenuItem,
            this.現在のファイルを閉じるToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 新規作成ToolStripMenuItem
            // 
            this.新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
            this.新規作成ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新規作成ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.新規作成ToolStripMenuItem.Text = "新規作成";
            this.新規作成ToolStripMenuItem.Click += new System.EventHandler(this.NewFile_Click);
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.開くToolStripMenuItem.Text = "開く";
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            this.名前を付けて保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.名前を付けて保存ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            this.名前を付けて保存ToolStripMenuItem.Click += new System.EventHandler(this.Save_Clicked);
            // 
            // 上書き保存ToolStripMenuItem
            // 
            this.上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
            this.上書き保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.上書き保存ToolStripMenuItem.ShowShortcutKeys = false;
            this.上書き保存ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.上書き保存ToolStripMenuItem.Text = "上書き保存";
            this.上書き保存ToolStripMenuItem.Click += new System.EventHandler(this.Save_Clicked);
            // 
            // 現在のファイルを閉じるToolStripMenuItem
            // 
            this.現在のファイルを閉じるToolStripMenuItem.Name = "現在のファイルを閉じるToolStripMenuItem";
            this.現在のファイルを閉じるToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.現在のファイルを閉じるToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.現在のファイルを閉じるToolStripMenuItem.Text = "現在のタブを閉じる";
            this.現在のファイルを閉じるToolStripMenuItem.Click += new System.EventHandler(this.CloseCurrentTab_Click);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.終了ToolStripMenuItem.Text = "終了(&X)";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.Close_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.コピーToolStripMenuItem,
            this.切り取りToolStripMenuItem,
            this.貼り付けToolStripMenuItem,
            this.全選択ToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.undoToolStripMenuItem});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.編集EToolStripMenuItem.Text = "編集(&E)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem1.Text = "切り取り";
            // 
            // コピーToolStripMenuItem
            // 
            this.コピーToolStripMenuItem.Name = "コピーToolStripMenuItem";
            this.コピーToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.コピーToolStripMenuItem.Text = " コピー";
            // 
            // 切り取りToolStripMenuItem
            // 
            this.切り取りToolStripMenuItem.Name = "切り取りToolStripMenuItem";
            this.切り取りToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.切り取りToolStripMenuItem.Text = "切り取り";
            // 
            // 貼り付けToolStripMenuItem
            // 
            this.貼り付けToolStripMenuItem.Name = "貼り付けToolStripMenuItem";
            this.貼り付けToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.貼り付けToolStripMenuItem.Text = "貼り付け";
            // 
            // 全選択ToolStripMenuItem
            // 
            this.全選択ToolStripMenuItem.Name = "全選択ToolStripMenuItem";
            this.全選択ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.全選択ToolStripMenuItem.Text = "全選択";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // 検索SToolStripMenuItem
            // 
            this.検索SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.検索ToolStripMenuItem,
            this.置換ToolStripMenuItem,
            this.grepToolStripMenuItem});
            this.検索SToolStripMenuItem.Name = "検索SToolStripMenuItem";
            this.検索SToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.検索SToolStripMenuItem.Text = "検索(&S)";
            // 
            // 検索ToolStripMenuItem
            // 
            this.検索ToolStripMenuItem.Name = "検索ToolStripMenuItem";
            this.検索ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.検索ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.検索ToolStripMenuItem.Text = "検索";
            this.検索ToolStripMenuItem.Click += new System.EventHandler(this.Search_Click);
            // 
            // 置換ToolStripMenuItem
            // 
            this.置換ToolStripMenuItem.Name = "置換ToolStripMenuItem";
            this.置換ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.置換ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.置換ToolStripMenuItem.Text = "置換";
            this.置換ToolStripMenuItem.Click += new System.EventHandler(this.Replace_Click);
            // 
            // grepToolStripMenuItem
            // 
            this.grepToolStripMenuItem.Name = "grepToolStripMenuItem";
            this.grepToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.grepToolStripMenuItem.Text = "grep";
            this.grepToolStripMenuItem.Click += new System.EventHandler(this.Grep_Click);
            // 
            // tbcMemo
            // 
            this.tbcMemo.AllowDrop = true;
            this.tbcMemo.Controls.Add(this.tabPage1);
            this.tbcMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMemo.Location = new System.Drawing.Point(0, 24);
            this.tbcMemo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbcMemo.Name = "tbcMemo";
            this.tbcMemo.SelectedIndex = 0;
            this.tbcMemo.Size = new System.Drawing.Size(933, 440);
            this.tbcMemo.TabIndex = 1;
            this.tbcMemo.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.tbcMemo.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(925, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "新規";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStripMemo
            // 
            this.statusStripMemo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonEncodingKind});
            this.statusStripMemo.Location = new System.Drawing.Point(0, 464);
            this.statusStripMemo.Name = "statusStripMemo";
            this.statusStripMemo.Size = new System.Drawing.Size(933, 24);
            this.statusStripMemo.TabIndex = 2;
            this.statusStripMemo.Text = "statusStrip1";
            // 
            // toolStripButtonEncodingKind
            // 
            this.toolStripButtonEncodingKind.AutoSize = false;
            this.toolStripButtonEncodingKind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEncodingKind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UTF8MenuItem,
            this.UTF16MenuItem,
            this.UTF32MenuItem,
            this.ShiftJISMenuItem});
            this.toolStripButtonEncodingKind.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEncodingKind.Image")));
            this.toolStripButtonEncodingKind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEncodingKind.Name = "toolStripButtonEncodingKind";
            this.toolStripButtonEncodingKind.Size = new System.Drawing.Size(99, 22);
            this.toolStripButtonEncodingKind.Text = "エンコードの種類";
            // 
            // UTF8MenuItem
            // 
            this.UTF8MenuItem.Name = "UTF8MenuItem";
            this.UTF8MenuItem.Size = new System.Drawing.Size(162, 22);
            this.UTF8MenuItem.Tag = ((object)(resources.GetObject("UTF8MenuItem.Tag")));
            this.UTF8MenuItem.Text = "Unicode(UTF-8)";
            this.UTF8MenuItem.Click += new System.EventHandler(this.EncodingKind_Click);
            // 
            // UTF16MenuItem
            // 
            this.UTF16MenuItem.Name = "UTF16MenuItem";
            this.UTF16MenuItem.Size = new System.Drawing.Size(162, 22);
            this.UTF16MenuItem.Tag = ((object)(resources.GetObject("UTF16MenuItem.Tag")));
            this.UTF16MenuItem.Text = "Unicode(UTF-16)";
            this.UTF16MenuItem.Click += new System.EventHandler(this.EncodingKind_Click);
            // 
            // UTF32MenuItem
            // 
            this.UTF32MenuItem.Name = "UTF32MenuItem";
            this.UTF32MenuItem.Size = new System.Drawing.Size(162, 22);
            this.UTF32MenuItem.Tag = ((object)(resources.GetObject("UTF32MenuItem.Tag")));
            this.UTF32MenuItem.Text = "Unicode(UTF-32)";
            this.UTF32MenuItem.Click += new System.EventHandler(this.EncodingKind_Click);
            // 
            // ShiftJISMenuItem
            // 
            this.ShiftJISMenuItem.Name = "ShiftJISMenuItem";
            this.ShiftJISMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ShiftJISMenuItem.Tag = ((object)(resources.GetObject("ShiftJISMenuItem.Tag")));
            this.ShiftJISMenuItem.Text = "日本語(Shift-JIS)";
            this.ShiftJISMenuItem.Click += new System.EventHandler(this.EncodingKind_Click);
            // 
            // Memo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 488);
            this.Controls.Add(this.tbcMemo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStripMemo);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Memo";
            this.Text = "メモ";
            this.Load += new System.EventHandler(this.Memo_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbcMemo.ResumeLayout(false);
            this.statusStripMemo.ResumeLayout(false);
            this.statusStripMemo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新規作成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上書き保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 現在のファイルを閉じるToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 検索SToolStripMenuItem;
        private System.Windows.Forms.TabControl tbcMemo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem コピーToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切り取りToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 貼り付けToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全選択ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 検索ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 置換ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grepToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMemo;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonEncodingKind;
        private System.Windows.Forms.ToolStripMenuItem UTF8MenuItem;
        private System.Windows.Forms.ToolStripMenuItem UTF16MenuItem;
        private System.Windows.Forms.ToolStripMenuItem UTF32MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShiftJISMenuItem;
    }
}

