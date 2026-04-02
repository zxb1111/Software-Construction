using System;
using System.IO;
using System.Windows.Forms;

namespace FileMergerApp
{
    public partial class Form1 : Form
    {
        // 定义全局变量，用于临时存储用户选择的文件路径
        private string file1Path = "";
        private string file2Path = "";

        public Form1()
        {
            InitializeComponent();
        }

        // “选择文件 1” 按钮的点击事件
        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "请选择第一个文本文件";
                openFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file1Path = openFileDialog.FileName;
                    txtFile1.Text = file1Path; // 在界面上显示路径
                }
            }
        }

        // “选择文件 2” 按钮的点击事件
        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "请选择第二个文本文件";
                openFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file2Path = openFileDialog.FileName;
                    txtFile2.Text = file2Path; // 在界面上显示路径
                }
            }
        }

        // “合并并保存” 按钮的点击事件
        private void btnMerge_Click(object sender, EventArgs e)
        {
            // 1. 验证是否选择了两个文件
            if (string.IsNullOrEmpty(file1Path) || string.IsNullOrEmpty(file2Path))
            {
                MessageBox.Show("请先选择两个需要合并的文本文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. 读取两个文件的内容
                string content1 = File.ReadAllText(file1Path);
                string content2 = File.ReadAllText(file2Path);

                // 3. 确定程序可执行目录下的 Data 子目录路径
                // Application.StartupPath 指向的是程序 .exe 所在的文件夹
                string dataDirectory = Path.Combine(Application.StartupPath, "Data");

                // 如果 Data 文件夹不存在，则创建一个
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }

                // 4. 生成新文件的路径 (使用当前时间命名防止重名覆盖)
                string newFileName = "MergedResult_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                string targetFilePath = Path.Combine(dataDirectory, newFileName);

                // 5. 将两个内容合并 (中间加一个换行符分隔)
                string mergedContent = content1 + Environment.NewLine + content2;

                // 6. 写入到新创建的文件中
                File.WriteAllText(targetFilePath, mergedContent);

                // 7. 提示成功，并显示文件保存的具体路径
                MessageBox.Show($"文件合并成功！\n\n已保存至：\n{targetFilePath}", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // 捕获并显示可能发生的错误 (如文件被占用、无权限等)
                MessageBox.Show("合并文件时发生错误：\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}