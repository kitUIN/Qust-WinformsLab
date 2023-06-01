using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace GraphicsDecoding
{
    public partial class TestForm : Form
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime startTime;
        /// <summary>
        /// 图片方阵边长
        /// </summary>
        private readonly int m;
        /// <summary>
        /// 初始化的n
        /// </summary>
        private readonly int n;
        /// <summary>
        /// 图片序列
        /// </summary>
        private readonly List<int> picArray = new List<int>();
        public TestForm(int n, int m)
        {
            this.m = m;
            this.n = n;
            InitializeComponent();
        }
        /// <summary>
        /// 初始化,用来生成方格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForm_Load(object sender, EventArgs e)
        { 
            ResourceManager rm = new ResourceManager(typeof(GraphicsDecoding.Properties.Resources));
            Random rnd = new Random();
            picArray.Clear();
            for (int i = 0; i < 20; ++i)  // Knuth 算法
            {
                picArray.Add(i + 1);
                int idx = rnd.Next(0, i);
                int temp = picArray[i];
                picArray[i] = picArray[idx];
                picArray[idx] = temp;
            }
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != 0 && i % m == 0) j++;
                this.Controls.Add(new PictureBox()
                {
                    Image = (Image)rm.GetObject($"_{picArray[i]}"),
                    Width = 50,
                    Height = 50,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point((i % m) * 50 + 10, j * 80 + 35),
                });
                this.Controls.Add(new Label()
                {
                    Width = 50,
                    Height = 30,
                    Text = $"{i + 1}",// (i+1).ToString()
                    BackColor = Color.Gold,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("宋体", 14),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point((i % m) * 50 + 10, j * 80 + 50 + 35),
                });
            }
            imgPanel.Location = new Point(5, j * 80 + 50 + 30 + 35 + 15);
            
            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    int r = rnd.Next(0, n);
                    imgPanel.Controls.Add(new PictureBox()
                    {
                        Image = (Image)rm.GetObject($"_{picArray[r]}"),
                        Width = 50,
                        Height = 50,
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(i * 50 + 5, k * 50 + k * 25 + 5),
                    });
                    imgPanel.Controls.Add(new TextBox()
                    {
                        Width = 50,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(i * 50 + 5, k * 75 + 55),
                        Tag = r + 1,
                    });
                }
            }
            imgPanel.Size = new Size(m * 50 + 30, this.Width - (j * 80 + 50 + 30 + 35 + 15) - 60);
            this.Width = m * 50 + 65;
            // 开始记录时间
            startTime = DateTime.Now;
        }
         
        /// <summary>
        /// 用时计时器
        /// </summary>
        private void TimeUsedTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan s1 = DateTime.Now - startTime;
            timeUsed.Text = $"用时：{s1.TotalSeconds.ToString("0.00")} 秒";
        }
        /// <summary>
        /// 清空所有的输入框
        /// </summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (object item in this.Controls)
            {
                if (item is TextBox box)
                {
                    box.Text = "";
                }
            }
        }
        /// <summary>
        /// 完成按钮
        /// </summary>
        private void finishButton_Click(object sender, EventArgs e)
        {
            double total = m * m;
            double right = 0;
            foreach (object item in this.Controls)
            {
                if (item is TextBox box && box.Tag.ToString() == box.Text.Trim()) 
                {
                    right++;
                }
            }
            TimeSpan s1 = DateTime.Now - startTime;
            double res = Math.Round(right / total * 100, 2);
            MessageBox.Show($"所使用时间: {s1.TotalSeconds.ToString("0.00")} 秒,正确率: {res} %", "完成");
            DBHelper.Add(new History(n, m, startTime, Math.Round(s1.TotalSeconds, 2), res));
            this.Close();
        }
    }
}
