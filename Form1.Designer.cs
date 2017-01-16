namespace ICSharpCodeTextEditor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pContainer = new System.Windows.Forms.Panel();
            this.btnFormatCSharp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pContainer
            // 
            this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainer.Location = new System.Drawing.Point(15, 54);
            this.pContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(807, 633);
            this.pContainer.TabIndex = 0;
            // 
            // btnFormatCSharp
            // 
            this.btnFormatCSharp.Location = new System.Drawing.Point(15, 13);
            this.btnFormatCSharp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFormatCSharp.Name = "btnFormatCSharp";
            this.btnFormatCSharp.Size = new System.Drawing.Size(87, 33);
            this.btnFormatCSharp.TabIndex = 1;
            this.btnFormatCSharp.Text = "格式化C#";
            this.btnFormatCSharp.UseVisualStyleBackColor = true;
            this.btnFormatCSharp.Click += new System.EventHandler(this.btnFormatCSharp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 704);
            this.Controls.Add(this.btnFormatCSharp);
            this.Controls.Add(this.pContainer);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.Button btnFormatCSharp;
    }
}

