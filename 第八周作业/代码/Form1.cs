using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace VocabularyApp 
{
    public partial class Form1 : Form
    {
        // SQLite 连接字符串（数据库文件会生成在程序的 Debug 目录下）
        private string connectionString = "Data Source=vocabulary.db;Version=3;";

        // 存储单词的列表 (Key: 英文, Value: 中文)
        private List<KeyValuePair<string, string>> wordList = new List<KeyValuePair<string, string>>();
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form1_Load);
            this.btnNext.Click += new EventHandler(btnNext_Click);
            this.txtEnglish.KeyDown += new KeyEventHandler(txtEnglish_KeyDown);
        }

        // 窗体加载时触发
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDatabase(); // 1. 确保数据库和表存在，并插入测试数据
            LoadWordsFromDatabase(); // 2. 从数据库读取数据到内存
            ShowCurrentWord(); // 3. 显示第一个单词
        }

        // 点击“下一个”按钮
        private void btnNext_Click(object sender, EventArgs e)
        {
            NextWord();
        }

        // 处理 TextBox 中的按键事件
        private void txtEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            // 如果按下的是回车键 (Enter)
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // 消除按下回车时系统发出的“咚咚”提示音
                CheckAnswer();
            }
        }

        // --- 核心逻辑方法 ---

        private void CheckAnswer()
        {
            if (wordList.Count == 0) return;

            string userInput = txtEnglish.Text.Trim(); // 获取用户输入并去除首尾空格
            string correctEnglish = wordList[currentIndex].Key;

            // 比较时不区分大小写
            if (string.Equals(userInput, correctEnglish, StringComparison.OrdinalIgnoreCase))
            {
                lblResult.Text = "正确";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = $"错误 (正确答案: {correctEnglish})";
                lblResult.ForeColor = Color.Red;
            }
        }

        private void NextWord()
        {
            if (wordList.Count == 0) return;

            // 索引加1，准备显示下一个
            currentIndex++;

            // 如果到底了就回到0（循环背单词）
            if (currentIndex >= wordList.Count)
            {
                currentIndex = 0;
                MessageBox.Show("已经背完一轮啦！重新开始。");
            }

            ShowCurrentWord();
        }

        private void ShowCurrentWord()
        {
            if (wordList.Count > 0)
            {
                lblChinese.Text = wordList[currentIndex].Value; // 显示中文
                txtEnglish.Text = ""; // 清空输入框
                lblResult.Text = "";  // 清空结果提示
                txtEnglish.Focus();   // 将光标自动放回输入框，方便用户直接打字
            }
            else
            {
                lblChinese.Text = "词库中没有单词";
            }
        }

        // --- 数据库操作方法 ---

        private void LoadWordsFromDatabase()
        {
            wordList.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT EnglishWord, ChineseMeaning FROM Words";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string eng = reader["EnglishWord"].ToString();
                            string chn = reader["ChineseMeaning"].ToString();
                            wordList.Add(new KeyValuePair<string, string>(eng, chn));
                        }
                    }
                }
            }
        }

        private void InitializeDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS Words (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        EnglishWord TEXT NOT NULL,
                        ChineseMeaning TEXT NOT NULL
                    )";
                using (SQLiteCommand cmd = new SQLiteCommand(createTableSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 检查表里是否有数据，没有的话插入几条测试数据
                string checkDataSql = "SELECT COUNT(*) FROM Words";
                using (SQLiteCommand cmd = new SQLiteCommand(checkDataSql, conn))
                {
                    long count = (long)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        string insertSql = @"
                            INSERT INTO Words (EnglishWord, ChineseMeaning) VALUES ('apple', '苹果');
                            INSERT INTO Words (EnglishWord, ChineseMeaning) VALUES ('computer', '电脑');
                            INSERT INTO Words (EnglishWord, ChineseMeaning) VALUES ('developer', '开发者');
                            INSERT INTO Words (EnglishWord, ChineseMeaning) VALUES ('database', '数据库');
                            INSERT INTO Words (EnglishWord, ChineseMeaning) VALUES ('operating system', '操作系统');
                        ";
                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertSql, conn))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
