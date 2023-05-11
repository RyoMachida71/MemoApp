namespace MemoApp.Controls {
    partial class TextForm {
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.customTextBox1 = new MemoApp.CustomTextBox();
            this.rtbLineNumber = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // customTextBox1
            // 
            this.customTextBox1.AcceptsTab = true;
            this.customTextBox1.AllowDrop = true;
            this.customTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTextBox1.BackColor = System.Drawing.Color.Black;
            this.customTextBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.customTextBox1.ForeColor = System.Drawing.Color.White;
            this.customTextBox1.Location = new System.Drawing.Point(40, 0);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.customTextBox1.Size = new System.Drawing.Size(1106, 523);
            this.customTextBox1.TabIndex = 1;
            this.customTextBox1.Text = "";
            this.customTextBox1.WordWrap = false;
            // 
            // rtbLineNumber
            // 
            this.rtbLineNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbLineNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbLineNumber.DetectUrls = false;
            this.rtbLineNumber.Location = new System.Drawing.Point(0, 0);
            this.rtbLineNumber.Name = "rtbLineNumber";
            this.rtbLineNumber.ReadOnly = true;
            this.rtbLineNumber.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbLineNumber.Size = new System.Drawing.Size(40, 96);
            this.rtbLineNumber.TabIndex = 2;
            this.rtbLineNumber.Text = "";
            // 
            // TextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbLineNumber);
            this.Controls.Add(this.customTextBox1);
            this.Name = "TextForm";
            this.Size = new System.Drawing.Size(1570, 699);
            this.ResumeLayout(false);

        }

        #endregion
        private CustomTextBox customTextBox1;
        private System.Windows.Forms.RichTextBox rtbLineNumber;
    }
}
