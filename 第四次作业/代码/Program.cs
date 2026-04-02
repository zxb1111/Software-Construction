using System;
using System.Windows.Forms;
using FileMergerApp;

namespace FileMergerApp
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 启动 Form1 窗体
            Application.Run(new Form1());
        }
    }
}
