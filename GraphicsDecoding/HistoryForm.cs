using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GraphicsDecoding
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
        private void Query_Click(object sender, EventArgs e)
        {
            if (queryNBox.Text == "" || queryMBox.Text == "")
            {
                MessageBox.Show("查询时N,M不能为空", "查询错误");
                return;
            }
            try
            {
                this.historyView.Items.Clear();
                List<int> ns = queryNBox.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToList();
                if (ns.Any(item => item < 5 || item > 20))
                {
                    MessageBox.Show("您只能查询N=[5,20]的历史记录", "查询错误");
                    queryNBox.Text = "";
                    return;
                }
                List<int> ms = queryMBox.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToList();
                if (ms.Any(item => item < 5 || item > 20))
                {
                    MessageBox.Show("您只能查询M=[5,20]的历史记录", "查询错误");
                    queryMBox.Text = "";
                    return;
                }
                // 某一N与某一M
                if (ns.Count == 1 && ms.Count == 1)
                {
                    foreach (History item in DBHelper.Query(ns[0], ms[0]))
                    {
                        this.historyView.Items.Add(item.ToListViewItem());
                    }
                }
                // 不同N与不同M
                else
                {
                    foreach (int n in ns)
                    {
                        foreach (int m in ms)
                        {
                            if (DBHelper.QueryTop(n, m) is History history)
                            {
                                this.historyView.Items.Add(history.ToListViewItem());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("输入错误", "查询错误");
                queryNBox.Text = "";
                queryMBox.Text = "";
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
                Query_Click(sender, e);
            }
        }
        /// <summary>
        /// 点击打开数据库文件夹
        /// </summary>
        private void openDbButton_Click(object sender, EventArgs e)
        {
            DBHelper.OpenDB();
        } 
    }
}
