namespace MemoApp.Search {
    partial class BasicSearchForm {
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
            this.lblReplace = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.tbxReplace = new System.Windows.Forms.TextBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chbRegularExpression = new System.Windows.Forms.CheckBox();
            this.chbDistinguishCase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(16, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(33, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = " 検索";
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(20, 53);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(29, 12);
            this.lblReplace.TabIndex = 1;
            this.lblReplace.Text = "置換";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(68, 24);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(189, 19);
            this.tbxSearch.TabIndex = 2;
            // 
            // tbxReplace
            // 
            this.tbxReplace.Location = new System.Drawing.Point(68, 50);
            this.tbxReplace.Name = "tbxReplace";
            this.tbxReplace.Size = new System.Drawing.Size(189, 19);
            this.tbxReplace.TabIndex = 3;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(306, 84);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 9;
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(306, 22);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 8;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.Location = new System.Drawing.Point(306, 55);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(75, 23);
            this.btnBackward.TabIndex = 7;
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(306, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chbRegularExpression
            // 
            this.chbRegularExpression.AutoSize = true;
            this.chbRegularExpression.Location = new System.Drawing.Point(18, 163);
            this.chbRegularExpression.Name = "chbRegularExpression";
            this.chbRegularExpression.Size = new System.Drawing.Size(72, 16);
            this.chbRegularExpression.TabIndex = 15;
            this.chbRegularExpression.Text = "正規表現";
            this.chbRegularExpression.UseVisualStyleBackColor = true;
            // 
            // chbIgnoreCase
            // 
            this.chbDistinguishCase.AutoSize = true;
            this.chbDistinguishCase.Location = new System.Drawing.Point(18, 131);
            this.chbDistinguishCase.Name = "chbDistinguishCase";
            this.chbDistinguishCase.Size = new System.Drawing.Size(154, 16);
            this.chbDistinguishCase.TabIndex = 14;
            this.chbDistinguishCase.Text = "大文字/小文字を区別する";
            this.chbDistinguishCase.UseVisualStyleBackColor = true;
            // 
            // BasicSearchForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(407, 197);
            this.Controls.Add(this.chbRegularExpression);
            this.Controls.Add(this.chbDistinguishCase);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBackward);
            this.Controls.Add(this.tbxReplace);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.lblSearch);
            this.Name = "BasicSearchForm";
            this.Text = "BasicSearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblSearch;
        protected System.Windows.Forms.Label lblReplace;
        protected System.Windows.Forms.TextBox tbxSearch;
        protected System.Windows.Forms.TextBox tbxReplace;
        protected System.Windows.Forms.Button btnAll;
        protected System.Windows.Forms.Button btnForward;
        protected System.Windows.Forms.Button btnBackward;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.CheckBox chbRegularExpression;
        protected System.Windows.Forms.CheckBox chbDistinguishCase;
    }
}