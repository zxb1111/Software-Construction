namespace MyCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.txtDisplay.Location = new System.Drawing.Point(50, 50);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(430, 71);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // 数字按钮 (统一绑定到 button_Click)
            // 
            this.btn7.Location = new System.Drawing.Point(50, 150);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(80, 80);
            this.btn7.Text = "7";
            this.btn7.Click += new System.EventHandler(this.button_Click);

            this.btn8.Location = new System.Drawing.Point(150, 150);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(80, 80);
            this.btn8.Text = "8";
            this.btn8.Click += new System.EventHandler(this.button_Click);

            this.btn9.Location = new System.Drawing.Point(250, 150);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(80, 80);
            this.btn9.Text = "9";
            this.btn9.Click += new System.EventHandler(this.button_Click);

            this.btn4.Location = new System.Drawing.Point(50, 250);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(80, 80);
            this.btn4.Text = "4";
            this.btn4.Click += new System.EventHandler(this.button_Click);

            this.btn5.Location = new System.Drawing.Point(150, 250);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(80, 80);
            this.btn5.Text = "5";
            this.btn5.Click += new System.EventHandler(this.button_Click);

            this.btn6.Location = new System.Drawing.Point(250, 250);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(80, 80);
            this.btn6.Text = "6";
            this.btn6.Click += new System.EventHandler(this.button_Click);

            this.btn1.Location = new System.Drawing.Point(50, 350);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(80, 80);
            this.btn1.Text = "1";
            this.btn1.Click += new System.EventHandler(this.button_Click);

            this.btn2.Location = new System.Drawing.Point(150, 350);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(80, 80);
            this.btn2.Text = "2";
            this.btn2.Click += new System.EventHandler(this.button_Click);

            this.btn3.Location = new System.Drawing.Point(250, 350);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(80, 80);
            this.btn3.Text = "3";
            this.btn3.Click += new System.EventHandler(this.button_Click);

            this.btn0.Location = new System.Drawing.Point(50, 450);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(80, 80);
            this.btn0.Text = "0";
            this.btn0.Click += new System.EventHandler(this.button_Click);

            // 运算符按钮 (统一绑定到 operator_Click)
            // 
            this.btnDiv.Location = new System.Drawing.Point(350, 150);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(80, 80);
            this.btnDiv.Text = "/";
            this.btnDiv.Click += new System.EventHandler(this.operator_Click);

            this.btnMul.Location = new System.Drawing.Point(350, 250);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(80, 80);
            this.btnMul.Text = "*";
            this.btnMul.Click += new System.EventHandler(this.operator_Click);

            this.btnSub.Location = new System.Drawing.Point(350, 350);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(80, 80);
            this.btnSub.Text = "-";
            this.btnSub.Click += new System.EventHandler(this.operator_Click);

            this.btnAdd.Location = new System.Drawing.Point(350, 450);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 80);
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.operator_Click);

            // 辅助按钮
            // 
            this.btnClear.Location = new System.Drawing.Point(150, 450);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 80);
            this.btnClear.Text = "C";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnEqual.Location = new System.Drawing.Point(250, 450);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(80, 80);
            this.btnEqual.Text = "=";
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);

            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.txtDisplay);
            this.Name = "Form1";
            this.Text = "简单计算器";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnAdd;
    }
}