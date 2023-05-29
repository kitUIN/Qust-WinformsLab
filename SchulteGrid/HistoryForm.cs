using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SchulteGrid
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        private void HistoryForm_Load(object sender, EventArgs e)
        {
            List<History> histories = DBHelper.Query();
            foreach (History item in histories)
            {
                this.historyView.Items.Add(item.ToListViewItem());
            }
        }
        /// <summary>
        /// 点击查询按钮
        /// </summary>
        private void QueryButton_Click(object sender, EventArgs e)
        {
            if(queryBox.Text == "")
            {
                MessageBox.Show("查询难度不能为空", "查询错误");
                return;
            }
            try
            {
                IEnumerable<int> dis = queryBox.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim()));
                this.historyView.Items.Clear();
                if (dis.Any(item => item < 3 || item > 10))
                {
                    MessageBox.Show("您只能查询3-10难度的历史记录", "查询错误");
                    queryBox.Text = "";
                    return;
                }
                if (dis.Count() == 1)
                {
                    foreach (int item in dis)
                    {
                        List<History> histories = DBHelper.Query(item);
                        if (histories is null) return;
                        foreach (History history in histories.OrderBy(x => x.TimeUsed))
                        {
                            this.historyView.Items.Add(history.ToListViewItem());
                        }
                    }
                }
                else
                {
                    foreach (int item in dis)
                    {
                        if (DBHelper.QueryTop(item) is History history)
                        {
                            this.historyView.Items.Add(history.ToListViewItem());
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("输入错误", "查询错误");
                queryBox.Text = "";
                return;
            }
        }
        /// <summary>
        /// 在查询输入框回车
        /// </summary>
        private void QueryBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QueryButton_Click(sender, e);
            }
        }
        /// <summary>
        /// 点击打开数据库文件夹
        /// </summary>
        private void OpenDbButton_Click(object sender, EventArgs e)
        {
            DBHelper.OpenDB();
        } 
    }
}
