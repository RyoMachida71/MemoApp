namespace MemoApp.Controls {
    partial class LineNumberTextBox {
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
            this.customTextBox = new MemoApp.CustomTextBox();
            this.SuspendLayout();
            // 
            // customTextBox
            // 
            this.customTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTextBox.BackColor = System.Drawing.Color.Black;
            this.customTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.customTextBox.ForeColor = System.Drawing.Color.White;
            this.customTextBox.Location = new System.Drawing.Point(62, 0);
            this.customTextBox.Name = "customTextBox";
            this.customTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.customTextBox.Size = new System.Drawing.Size(237, 238);
            this.customTextBox.TabIndex = 0;
            this.customTextBox.Text = "";
            // 
            // LineNumberTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.customTextBox);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "LineNumberTextBox";
            this.Size = new System.Drawing.Size(299, 238);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTextBox customTextBox;
    }
}
