using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchulteGrid
{
    public partial class TestForm : Form
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime startTime;
        /// <summary>
        /// 难度
        /// </summary>
        private readonly int difficulty;
        /// <summary>
        /// 所有格子数量
        /// </summary>
        private readonly int totalCounts;
        /// <summary>
        /// 当前点击到第几个数字
        /// </summary>
        private int clicked = 0;
        /// <summary>
        /// 是否是消除模式
        /// </summary>
        private readonly bool eliminationMode;
        public TestForm(int difficulty, bool eliminationMode)
        {
            this.difficulty = difficulty;
            this.totalCounts = difficulty * difficulty;
            this.eliminationMode = eliminationMode;
            InitializeComponent();
        }
        /// <summary>
        /// 初始化,用来生成方格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForm_Load(object sender, EventArgs e)
        {  
            this.Width = 61 * difficulty + 25;
            this.Height = 61 * difficulty + 70;
            // 生成方格
            int[] array = new int[totalCounts];
            Random random = new Random();
            //for (int i = 0; i < totalCounts; i++)
            //{
            //    int number;
            //    do
            //    {
            //        number = random.Next(1, totalCounts + 1);
            //    }
            //    while (Array.IndexOf(array, number) != -1);
            //    array[i] = number;
            //}
            for (int i = 0; i < totalCounts; ++i)  // Knuth 算法
            {
                array[i] = i + 1;
                if(i > 0)
                {
                    int idx = random.Next(0, i);
                    int temp = array[i];
                    array[i] = array[idx];
                    array[idx] = temp;
                }
            }
            for (int i = 0; i < difficulty; i++)
            {
                for (int j = 0; j < difficulty; j++)
                {
                    Label label1 = new Label();
                    label1.Width = label1.Height = 60;
                    label1.Text = array[i * difficulty + j].ToString();
                    label1.BackColor = Color.Gold;
                    label1.BorderStyle = BorderStyle.FixedSingle;
                    label1.Click += MathLabel_Click;
                    label1.Font = new Font("宋体", 14);
                    label1.TextAlign = ContentAlignment.MiddleCenter;
                    label1.Location = new Point(i * 61 + 5, (j) * 61 + 25);
                    this.Controls.Add(label1);
                }
            }
            // 开始记录时间
            startTime = DateTime.Now;
        }
        /// <summary>
        /// 点击每一个格子时
        /// </summary>
        private void MathLabel_Click(Object sender, EventArgs e)
        {
            Label label2 = (Label)sender;
            clicked++;
            if (label2.Text == clicked.ToString())
            {
                if (eliminationMode)
                {
                    label2.Visible = false;
                }
                else
                {
                    label2.Font = new Font("宋体", 14, FontStyle.Bold);
                }
            }
            else
            {
                clicked--;
            }

            if (clicked == totalCounts)
            { 
                TimeSpan s1 = DateTime.Now - startTime;
                this.Close();
                
                DBHelper.Add(new History(difficulty, startTime, Math.Round(s1.TotalSeconds,2)));
                MessageBox.Show($"您使用的时间为：{s1.TotalSeconds.ToString("0.00")} 秒");
            }
        }
        /// <summary>
        /// 用时计时器
        /// </summary>
        private void TimeUsedTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan s1 = DateTime.Now - startTime;
            timeUsed.Text = $"用时：{s1.TotalSeconds.ToString("0.00")} 秒";
        }
        

    }
}
