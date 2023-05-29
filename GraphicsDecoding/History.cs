using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace GraphicsDecoding
{
    public class History
    { 
        public int N { get;  }
        public int M { get;  }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; }
        
        /// <summary>
        /// 用时
        /// </summary>
        public double TimeUsed { get;  }
        /// <summary>
        /// 正确率
        /// </summary>
        public double CorrectRate { get;  }

        public History(int n,int m,DateTime time,double timeUsed,double correctRate)
        {
            N = n;
            M = m;
            StartTime = time;
            TimeUsed = timeUsed;
            CorrectRate = correctRate;
        }
        public static History CreateFromDB(SqliteDataReader reader)
        {
            return new History(reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetDateTime(2),
                reader.GetDouble(3),
                reader.GetDouble(4));
        }
        public ListViewItem ToListViewItem()
        {
            ListViewItem lvi = new ListViewItem()
            {
                Text = N.ToString()
            }; 
            lvi.SubItems.Add(M.ToString());
            lvi.SubItems.Add(StartTime.ToString("G"));
            lvi.SubItems.Add(TimeUsed.ToString());
            lvi.SubItems.Add(CorrectRate.ToString());
            return lvi;
        }
    }
}
