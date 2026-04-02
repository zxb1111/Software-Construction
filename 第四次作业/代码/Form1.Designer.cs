namespace FileMergerApp
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
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnSelectFile1 = new System.Windows.Forms.Button();
            this.btnSelectFile2 = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.Text = "文件 1：";

            // txtFile1
            this.txtFile1.Location = new System.Drawing.Point(90, 32);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.ReadOnly = true;
            this.txtFile1.Size = new System.Drawing.Size(300, 21);

            // btnSelectFile1
            this.btnSelectFile1.Location = new System.Drawing.Point(410, 30);
            this.btnSelectFile1.Name = "btnSelectFile1";
            this.btnSelectFile1.Size = new System.Drawing.Size(90, 25);
            this.btnSelectFile1.Text = "选择文件 1";
            this.btnSelectFile1.UseVisualStyleBackColor = true;
            this.btnSelectFile1.Click += new System.EventHandler(this.btnSelectFile1_Click);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.Text = "文件 2：";

            // txtFile2
            this.txtFile2.Location = new System.Drawing.Point(90, 82);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.ReadOnly = true;
            this.txtFile2.Size = new System.Drawing.Size(300, 21);

            // btnSelectFile2
            this.btnSelectFile2.Location = new System.Drawing.Point(410, 80);
            this.btnSelectFile2.Name = "btnSelectFile2";
            this.btnSelectFile2.Size = new System.Drawing.Size(90, 25);
            this.btnSelectFile2.Text = "选择文件 2";
            this.btnSelectFile2.UseVisualStyleBackColor = true;
            this.btnSelectFile2.Click += new System.EventHandler(this.btnSelectFile2_Click);

            // btnMerge
            this.btnMerge.Location = new System.Drawing.Point(90, 140);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(150, 40);
            this.btnMerge.Text = "合并并保存";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 220);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnSelectFile2);
            this.Controls.Add(this.txtFile2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectFile1);
            this.Controls.Add(this.txtFile1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文本文件合并工具";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Button btnSelectFile1;
        private System.Windows.Forms.Button btnSelectFile2;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}