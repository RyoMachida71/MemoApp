namespace MemoApp.Grep {
    partial class GrepForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.chbRegularExpression = new System.Windows.Forms.CheckBox();
            this.chbIgnoreCase = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.tbxFolderPath = new System.Windows.Forms.TextBox();
            this.btnFolderDialog = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.tbxSearchFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 38);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "検索文字列";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.tbxSearch.Location = new System.Drawing.Point(79, 34);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(247, 21);
            this.tbxSearch.TabIndex = 1;
            // 
            // chbRegularExpression
            // 
            this.chbRegularExpression.AutoSize = true;
            this.chbRegularExpression.Location = new System.Drawing.Point(14, 162);
            this.chbRegularExpression.Name = "chbRegularExpression";
            this.chbRegularExpression.Size = new System.Drawing.Size(72, 16);
            this.chbRegularExpression.TabIndex = 8;
            this.chbRegularExpression.Text = "正規表現";
            this.chbRegularExpression.UseVisualStyleBackColor = true;
            // 
            // chbIgnoreCase
            // 
            this.chbIgnoreCase.AutoSize = true;
            this.chbIgnoreCase.Location = new System.Drawing.Point(14, 130);
            this.chbIgnoreCase.Name = "chbIgnoreCase";
            this.chbIgnoreCase.Size = new System.Drawing.Size(164, 16);
            this.chbIgnoreCase.TabIndex = 7;
            this.chbIgnoreCase.Text = "大文字/小文字を区別しない";
            this.chbIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(444, 130);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(95, 37);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "実行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.AutoSize = true;
            this.lblFolderPath.Location = new System.Drawing.Point(10, 65);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(59, 12);
            this.lblFolderPath.TabIndex = 2;
            this.lblFolderPath.Text = "フォルダパス";
            // 
            // tbxFolderPath
            // 
            this.tbxFolderPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.tbxFolderPath.Location = new System.Drawing.Point(79, 61);
            this.tbxFolderPath.Name = "tbxFolderPath";
            this.tbxFolderPath.Size = new System.Drawing.Size(247, 21);
            this.tbxFolderPath.TabIndex = 3;
            // 
            // btnFolderDialog
            // 
            this.btnFolderDialog.Location = new System.Drawing.Point(332, 61);
            this.btnFolderDialog.Name = "btnFolderDialog";
            this.btnFolderDialog.Size = new System.Drawing.Size(29, 23);
            this.btnFolderDialog.TabIndex = 4;
            this.btnFolderDialog.Text = "...";
            this.btnFolderDialog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFolderDialog.UseVisualStyleBackColor = true;
            this.btnFolderDialog.Click += new System.EventHandler(this.btnFolderDialog_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 92);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(63, 12);
            this.lblFile.TabIndex = 5;
            this.lblFile.Text = "検索ファイル";
            // 
            // tbxSearchFile
            // 
            this.tbxSearchFile.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.tbxSearchFile.Location = new System.Drawing.Point(79, 88);
            this.tbxSearchFile.Name = "tbxSearchFile";
            this.tbxSearchFile.Size = new System.Drawing.Size(247, 21);
            this.tbxSearchFile.TabIndex = 6;
            // 
            // GrepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 213);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.tbxSearchFile);
            this.Controls.Add(this.btnFolderDialog);
            this.Controls.Add(this.lblFolderPath);
            this.Controls.Add(this.tbxFolderPath);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.chbRegularExpression);
            this.Controls.Add(this.chbIgnoreCase);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.tbxSearch);
            this.Name = "GrepForm";
            this.Text = "Grep";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.CheckBox chbRegularExpression;
        private System.Windows.Forms.CheckBox chbIgnoreCase;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.TextBox tbxFolderPath;
        private System.Windows.Forms.Button btnFolderDialog;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox tbxSearchFile;
    }
}