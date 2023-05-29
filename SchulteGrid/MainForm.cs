using System;
using System.IO;
using System.Windows.Forms;

namespace SchulteGrid
{
    public partial class MainForm : Form
    {
        private TestForm testForm;
        private HistoryForm historyForm;
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击开始测试按钮
        /// </summary>
        private void StartButton_Click(Object sender, EventArgs e)
        {
            testForm?.Close(); // 如果存在,则销毁前一个
            int difficulty;
            // 判断难度
            try
            {
                difficulty = int.Parse(difficultyBox.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("输入错误", "查询错误");
                return;
            }

            if (difficulty < 3 || difficulty > 10)
            {
                MessageBox.Show("您只能选择3-10的难度", "选择错误");
                difficultyBox.Text = "";
                return;
            }
            testForm = new TestForm(difficulty, checkBox1.Checked);
            testForm.Show(); // 显示专注力训练窗体
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
        /// 在难度输入时回车
        /// </summary> 
        private void DifficultyBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartButton_Click(sender, e);
            }
        }
    }
}
