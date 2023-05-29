using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace SchulteGrid
{
    public class History
    {
        /// <summary>
        /// 难度
        /// </summary>
        public int N { get;  }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; }

        /// <summary>
        /// 用时
        /// </summary>
        public double TimeUsed { get; }

        public History(int n,DateTime time,double timeUsed)
        {
            N = n;
            StartTime = time;
            TimeUsed = timeUsed;
        }
        public static History CreateFromDB(SqliteDataReader reader)
        {
            return new History(reader.GetInt32(0),
                reader.GetDateTime(1),
                reader.GetDouble(2));
        }
        public ListViewItem ToListViewItem()
        {
            ListViewItem lvi = new ListViewItem()
            {
                Text = N.ToString()
            }; 
            lvi.SubItems.Add(StartTime.ToString("G"));
            lvi.SubItems.Add(TimeUsed.ToString());
            return lvi;
        }
    }
}
