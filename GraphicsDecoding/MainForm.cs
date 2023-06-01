using GraphicsDecoding.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace GraphicsDecoding
{
    public partial class MainForm : Form
    {
        private TestForm testForm;
        private HistoryForm historyForm;
        private List<int> picArray = new List<int>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Shown += (object s,EventArgs args)=> imgPanel.Controls.Clear();
            this.textBoxN.KeyDown += TextBoxN_KeyDown;
            this.textBoxM.KeyDown += TextBoxM_KeyDown;
        }
        /// <summary>
        /// 点击开始测试按钮
        /// </summary>
        private void StartButton_Click(Object sender, EventArgs e)
        { 
            if(picArray.Count == 0)
            {
                if (Check("N", textBoxN.Text))
                {
                    InitButton_Click(sender, e);
                    MessageBox.Show("已自动初始化,请记忆\n记忆完毕后请再开始测试", "提示");
                    return;
                }
                else
                {
                    textBoxN.Text = "";
                    return;
                }
            }
            if (Check("M", textBoxM.Text))
            {
                testForm?.Close(); // 如果存在,则销毁前一个
                this.Hide(); // 隐藏主窗体
                testForm = new TestForm(picArray,int.Parse(textBoxN.Text), int.Parse(textBoxM.Text));
                testForm.FormClosed += (object s, FormClosedEventArgs args) =>
                {
                    this.Show();
                }; // 专注力测试窗体关闭事件
                testForm.Show(); // 显示专注力测试窗体
            }
        }
        /// <summary>
        /// 点击历史记录按钮
        /// </summary>
        private void HistoryButton_Click(object sender, EventArgs e)
        {
            historyForm?.Close(); // 如果存在,则销毁前一个
            historyForm = new HistoryForm();
            historyForm.Show(); // 显示历史记录窗体
        }
        /// <summary>
        /// 在N输入时回车
        /// </summary> 
        private void TextBoxN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitButton_Click(sender, e);
            }
        }
        /// <summary>
        /// 在M输入时回车
        /// </summary> 
        private void TextBoxM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartButton_Click(sender, e);
            }
        }
        /// <summary>
        /// 判断NM是否合理
        /// </summary>
        /// <returns></returns>
        private bool Check(string name,string text)
        {
            try
            {
                int n = int.Parse(text);
                if (n < 5 || n > 20)
                {
                    MessageBox.Show($"您只能选择5-20的{name}", "选择错误");
                    return false;
                }
                return true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show($"{name}输入错误", "输入错误");
            }
            return false;
        }
        /// <summary>
        /// 初始化按钮
        /// </summary>
        private void InitButton_Click(object sender, EventArgs e)
        {
            int n;
            if (Check("N", textBoxN.Text))
            {
                n = int.Parse(textBoxN.Text);
            }
            else
            {
                textBoxN.Text = "";
                return;
            }
            imgPanel.Controls.Clear();

            picArray.Clear();
            Random random = new Random();
            for (int i = 0; i < 20; ++i)  // Knuth 算法
            {
                picArray.Add(i + 1);
                int idx = random.Next(0, i);
                int temp = picArray[i];
                picArray[i] = picArray[idx];
                picArray[idx] = temp;
            }
            ResourceManager rm = new ResourceManager(typeof(GraphicsDecoding.Properties.Resources));
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != 0 && i % 10 == 0) j++;
                imgPanel.Controls.Add(new PictureBox()
                {
                    Image = (Image)rm.GetObject($"_{picArray[i]}"),
                    Width = 50,
                    Height = 50,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point((i % 10) * 50, j * 80),
                });
                imgPanel.Controls.Add(new Label()
                {
                    Width = 50,
                    Height = 30,
                    Text = $"{i + 1}",// (i+1).ToString()
                    BackColor = Color.Gold,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("宋体", 14),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point((i % 10) * 50 , j * 80 + 50),
                });
            }
        }

    }
}
