using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebExtractorApp
{
    public partial class Form1 : Form
    {
        // 使用 static 确保 HttpClient 在程序生命周期内复用，避免套接字耗尽
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            txtUrl.Text = "https://";

            lvResults.View = View.Details;
            lvResults.GridLines = true;
            lvResults.FullRowSelect = true;
            lvResults.Columns.Clear();
            lvResults.Columns.Add("类型", 200);
            lvResults.Columns.Add("提取内容", 700);

        }
        private async void btnStart_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();

            // 1. 基础验证
            if (string.IsNullOrEmpty(url) || !url.StartsWith("http"))
            {
                MessageBox.Show("请输入有效的 URL (以 http:// 或 https:// 开头)", "提示");
                return;
            }

            // 2. 状态初始化
            btnStart.Enabled = false;
            btnStart.Text = "抓取中...";
            lvResults.Items.Clear();

            try
            {
                // 3. 异步获取网页 HTML
                // 设置超时防止死挂
                client.Timeout = TimeSpan.FromSeconds(15);
                string htmlContent = await client.GetStringAsync(url);

                // 4. 使用正则提取
                // 邮箱正则
                var emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
                // 中国手机号正则
                var phonePattern = @"1[3-9]\d{9}";

                var emails = ExtractMatches(htmlContent, emailPattern);
                var phones = ExtractMatches(htmlContent, phonePattern);

                // 5. 填充到 ListView
                FillListView("邮箱", emails);
                FillListView("手机号", phones);

                if (emails.Count == 0 && phones.Count == 0)
                {
                    MessageBox.Show("页面加载成功，但未发现匹配的邮箱或手机号。");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"网络请求错误: {ex.Message}", "错误");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生异常: {ex.Message}", "错误");
            }
            finally
            {
                btnStart.Enabled = true;
                btnStart.Text = "开始提取";
            }
        }

        /// <summary>
        /// 正则提取逻辑
        /// </summary>
        private HashSet<string> ExtractMatches(string input, string pattern)
        {
            var results = new HashSet<string>(); // HashSet 自动去重
            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                results.Add(match.Value);
            }
            return results;
        }

        /// <summary>
        /// 将结果添加到 UI
        /// </summary>
        private void FillListView(string type, HashSet<string> data)
        {
            foreach (var item in data)
            {
                ListViewItem lvi = new ListViewItem(type);
                lvi.SubItems.Add(item);
                lvResults.Items.Add(lvi);
            }
        }

        private void lvResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}