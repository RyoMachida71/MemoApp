using System.Drawing;

namespace MemoApp.View {
    partial class SearchForm {
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
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.tbxReplace = new System.Windows.Forms.TextBox();
            this.btnBackSearch = new System.Windows.Forms.Button();
            this.btnForwardSearch = new System.Windows.Forms.Button();
            this.btnAllSearch = new System.Windows.Forms.Button();
            this.chbIgnoreCase = new System.Windows.Forms.CheckBox();
            this.chbRegularExpression = new System.Windows.Forms.CheckBox();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnReplaceBackward = new System.Windows.Forms.Button();
            this.btnReplaceForward = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.tbxSearch.Location = new System.Drawing.Point(47, 28);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(247, 21);
            this.tbxSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 31);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(29, 12);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "検索";
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(12, 72);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(29, 12);
            this.lblReplace.TabIndex = 3;
            this.lblReplace.Text = "置換";
            // 
            // tbxReplace
            // 
            this.tbxReplace.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.tbxReplace.Location = new System.Drawing.Point(47, 69);
            this.tbxReplace.Name = "tbxReplace";
            this.tbxReplace.Size = new System.Drawing.Size(247, 21);
            this.tbxReplace.TabIndex = 2;
            // 
            // btnBackSearch
            // 
            this.btnBackSearch.Location = new System.Drawing.Point(452, 62);
            this.btnBackSearch.Name = "btnBackSearch";
            this.btnBackSearch.Size = new System.Drawing.Size(75, 23);
            this.btnBackSearch.TabIndex = 4;
            this.btnBackSearch.Text = "後方検索";
            this.btnBackSearch.UseVisualStyleBackColor = true;
            this.btnBackSearch.Click += new System.EventHandler(this.SearchBackward_Click);
            // 
            // btnForwardSearch
            // 
            this.btnForwardSearch.Location = new System.Drawing.Point(452, 29);
            this.btnForwardSearch.Name = "btnForwardSearch";
            this.btnForwardSearch.Size = new System.Drawing.Size(75, 23);
            this.btnForwardSearch.TabIndex = 5;
            this.btnForwardSearch.Text = "前方検索";
            this.btnForwardSearch.UseVisualStyleBackColor = true;
            this.btnForwardSearch.Click += new System.EventHandler(this.SearchForward_Click);
            // 
            // btnAllSearch
            // 
            this.btnAllSearch.Location = new System.Drawing.Point(452, 91);
            this.btnAllSearch.Name = "btnAllSearch";
            this.btnAllSearch.Size = new System.Drawing.Size(75, 23);
            this.btnAllSearch.TabIndex = 6;
            this.btnAllSearch.Text = "全検索";
            this.btnAllSearch.UseVisualStyleBackColor = true;
            this.btnAllSearch.Click += new System.EventHandler(this.SearchAll_Click);
            // 
            // chbIgnoreCase
            // 
            this.chbIgnoreCase.AutoSize = true;
            this.chbIgnoreCase.Location = new System.Drawing.Point(23, 118);
            this.chbIgnoreCase.Name = "chbIgnoreCase";
            this.chbIgnoreCase.Size = new System.Drawing.Size(154, 16);
            this.chbIgnoreCase.TabIndex = 7;
            this.chbIgnoreCase.Text = "大文字/小文字を区別する";
            this.chbIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // chbRegularExpression
            // 
            this.chbRegularExpression.AutoSize = true;
            this.chbRegularExpression.Location = new System.Drawing.Point(23, 150);
            this.chbRegularExpression.Name = "chbRegularExpression";
            this.chbRegularExpression.Size = new System.Drawing.Size(72, 16);
            this.chbRegularExpression.TabIndex = 8;
            this.chbRegularExpression.Text = "正規表現";
            this.chbRegularExpression.UseVisualStyleBackColor = true;
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(359, 182);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(75, 23);
            this.btnReplaceAll.TabIndex = 11;
            this.btnReplaceAll.Text = "全置換";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.ReplaceAll_Click);
            // 
            // btnReplaceBackward
            // 
            this.btnReplaceBackward.Location = new System.Drawing.Point(359, 153);
            this.btnReplaceBackward.Name = "btnReplaceBackward";
            this.btnReplaceBackward.Size = new System.Drawing.Size(75, 23);
            this.btnReplaceBackward.TabIndex = 10;
            this.btnReplaceBackward.Text = "後方置換";
            this.btnReplaceBackward.UseVisualStyleBackColor = true;
            this.btnReplaceBackward.Click += new System.EventHandler(this.ReplaceBackward_Click);
            // 
            // btnReplaceForward
            // 
            this.btnReplaceForward.Location = new System.Drawing.Point(359, 120);
            this.btnReplaceForward.Name = "btnReplaceForward";
            this.btnReplaceForward.Size = new System.Drawing.Size(75, 23);
            this.btnReplaceForward.TabIndex = 9;
            this.btnReplaceForward.Text = "前方置換";
            this.btnReplaceForward.UseVisualStyleBackColor = true;
            this.btnReplaceForward.Click += new System.EventHandler(this.ReplaceForward_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(500, 184);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SearchForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(609, 219);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnReplaceBackward);
            this.Controls.Add(this.btnReplaceForward);
            this.Controls.Add(this.chbRegularExpression);
            this.Controls.Add(this.chbIgnoreCase);
            this.Controls.Add(this.btnAllSearch);
            this.Controls.Add(this.btnForwardSearch);
            this.Controls.Add(this.btnBackSearch);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.tbxReplace);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.tbxSearch);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.TextBox tbxReplace;
        private System.Windows.Forms.Button btnBackSearch;
        private System.Windows.Forms.Button btnForwardSearch;
        private System.Windows.Forms.Button btnAllSearch;
        private System.Windows.Forms.CheckBox chbIgnoreCase;
        private System.Windows.Forms.CheckBox chbRegularExpression;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnReplaceBackward;
        private System.Windows.Forms.Button btnReplaceForward;
        private System.Windows.Forms.Button btnClose;
    }
}