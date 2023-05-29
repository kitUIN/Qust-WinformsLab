using System;
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
        /// 返回函数
        /// </summary>
        private Action returnAction;
        /// <summary>
        /// 图片映射
        /// </summary>
        private readonly List<int> pics;
        /// <summary>
        /// 图片方阵边长
        /// </summary>
        private readonly int m;
        /// <summary>
        /// 初始化的n
        /// </summary>
        private readonly int n;
        public TestForm(List<int> picArray,int n, int m, Action action)
        {
            this.pics = picArray;
            this.returnAction = action;
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
            this.AutoScroll = true;
            Assembly asm = Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("GraphicsDecoding.Properties.Resources", asm);
            Random rnd = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int r = rnd.Next(0, n);
                    this.Controls.Add(new PictureBox()
                    {
                        Image = (Image)rm.GetObject($"_{pics[r]}"),
                        Width = 50,
                        Height = 50,
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(i * 50 + 5, j * 50 + j * 25 + 35),
                    });
                    this.Controls.Add(new TextBox()
                    {
                        Width = 50,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(i * 50 + 5, j * 75 + 85),
                        Tag = r + 1,
                    });

                }
            }
            this.Width = m * 50 + 45;
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
