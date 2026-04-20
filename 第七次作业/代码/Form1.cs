using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MultiSearchApp
{
    public partial class Form1 : Form
    {
        // 静态 HttpClient 实例，避免频繁创建导致 Socket 耗尽
        private static readonly HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();

            // 初始化设置：模拟浏览器 User-Agent，防止被搜索引擎拦截
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");
            _httpClient.Timeout = TimeSpan.FromSeconds(10); // 设置10秒超时
        }

        /// <summary>
        /// 搜索按钮点击事件 - 异步
        /// </summary>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入搜索关键字");
                return;
            }

            // 1. UI 状态切换
            SetUIState(false);
            txtBaidu.Text = "百度搜索中...";
            txtBing.Text = "必应搜索中...";

            try
            {
                // 2. 构造并行任务
                // Uri.EscapeDataString 确保中文关键字被正确编码
                string baiduUrl = $"https://www.baidu.com/s?wd={Uri.EscapeDataString(keyword)}";
                string bingUrl = $"https://cn.bing.com/search?q={Uri.EscapeDataString(keyword)}";

                // 同时启动两个异步任务
                Task<string> baiduTask = FetchAndProcessAsync(baiduUrl);
                Task<string> bingTask = FetchAndProcessAsync(bingUrl);

                // 3. 等待所有任务完成（并行执行）
                await Task.WhenAll(baiduTask, bingTask);

                // 4. 更新 UI
                txtBaidu.Text = await baiduTask;
                txtBing.Text = await bingTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
            finally
            {
                // 5. 恢复按钮状态
                SetUIState(true);
            }
        }

        /// <summary>
        /// 获取网页并清洗文本的异步方法
        /// </summary>
        private async Task<string> FetchAndProcessAsync(string url)
        {
            try
            {
                // 异步获取网页 HTML 源码
                string html = await _httpClient.GetStringAsync(url);

                // 执行 HTML 清洗
                string plainText = ExtractCleanText(html);

                // 截取前 200 个字
                if (plainText.Length > 200)
                    return plainText.Substring(0, 200) + "...";

                return plainText;
            }
            catch (HttpRequestException)
            {
                return "网络请求失败，请检查连接或是否被屏蔽。";
            }
            catch (Exception ex)
            {
                return $"处理出错: {ex.Message}";
            }
        }

        /// <summary>
        /// 使用正则简单粗暴地去除 HTML 标签和脚本
        /// </summary>
        private string ExtractCleanText(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return "";

            // 移除 <script> 和 <style> 块及其内容
            html = Regex.Replace(html, @"<(script|style)[^>]*?>.*?</\1>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // 移除所有 HTML 标签
            string text = Regex.Replace(html, "<[^>]*>", "");

            // 移除 HTML 转义字符 (如 &nbsp;)
            text = System.Net.WebUtility.HtmlDecode(text);

            // 将多个空格、换行符替换为单个空格，使结果更紧凑
            text = Regex.Replace(text, @"\s+", " ").Trim();

            return text;
        }

        private void SetUIState(bool enabled)
        {
            btnSearch.Enabled = enabled;
            txtKeyword.Enabled = enabled;
        }
    }
}