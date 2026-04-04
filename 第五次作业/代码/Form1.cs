using System;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        // 存储第一个操作数
        double resultValue = 0;
        // 存储当前选中的运算符 (+, -, *, /)
        string operationPerformed = "";
        // 标记是否刚刚点击过运算符
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // --- 1. 数字按钮通用点击事件 (btn0 ~ btn9) ---
        private void button_Click(object sender, EventArgs e)
        {
            // 将 sender 转换为 Button 对象
            Button button = (Button)sender;

            // 如果当前是 0 或者刚刚按过运算符，则清空文本框开始输入新数字
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;
            txtDisplay.Text = txtDisplay.Text + button.Text;
        }

        // --- 2. 运算符按钮通用点击事件 (btnAdd, btnSub, btnMul, btnDiv) ---
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                // 如果已经有第一个数了，点击运算符会自动执行上一步计算 (支持 1+2+3 连加)
                btnEqual.PerformClick();
                operationPerformed = button.Text;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
        }

        // --- 3. 清空按钮点击事件 (btnClear) ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // --- 4. 等号按钮点击事件 (btnEqual) ---
        private void btnEqual_Click(object sender, EventArgs e)
        {
            double secondValue = Double.Parse(txtDisplay.Text);
            double finalResult = 0;

            switch (operationPerformed)
            {
                case "+":
                    finalResult = resultValue + secondValue;
                    break;
                case "-":
                    finalResult = resultValue - secondValue;
                    break;
                case "*":
                    finalResult = resultValue * secondValue;
                    break;
                case "/":
                    if (secondValue != 0)
                        finalResult = resultValue / secondValue;
                    else
                    {
                        MessageBox.Show("错误：除数不能为零！");
                        return;
                    }
                    break;
                default:
                    return; // 如果没有运算符，直接返回
            }

            // 按照你要求的格式显示：18+5=23
            txtDisplay.Text = $"{resultValue}{operationPerformed}{secondValue}={finalResult}";
            
            // 计算结束后，将结果存入 resultValue，方便下一次连算
            resultValue = finalResult;
            operationPerformed = "";
            isOperationPerformed = true; // 设为 true，这样下次按数字会重置文本框
        }
    }
}