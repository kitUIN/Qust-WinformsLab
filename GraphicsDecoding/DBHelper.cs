using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace GraphicsDecoding
{
    public class DBHelper
    {
        private static string dbPath;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            dbPath = Path.Combine(Application.CommonAppDataPath, "GraphicsDecodingHistory.db");
            if (!File.Exists(dbPath))
            {
                File.Create(dbPath).Dispose();
            }
            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                string tableCommand =
@"CREATE TABLE IF NOT EXISTS HistoryTable (
N INTEGER  NULL, 
M INTEGER  NULL, 
StartTime TEXT NULL,
TimeUsed real NULL,
CorrectRate real NULL
);";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        /// <summary>
        /// 添加一个记录到数据库
        /// </summary>
        /// <param name="history"></param>
        public static void Add(History history)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand insertCommand = db.CreateCommand();
                insertCommand.CommandText = "INSERT INTO HistoryTable VALUES (@N, @M, @StartTime, @TimeUsed, @CorrectRate);";
                insertCommand.Parameters.AddWithValue("@N", history.N);
                insertCommand.Parameters.AddWithValue("@M", history.M);
                insertCommand.Parameters.AddWithValue("@StartTime", history.StartTime);
                insertCommand.Parameters.AddWithValue("@TimeUsed", history.TimeUsed);
                insertCommand.Parameters.AddWithValue("@CorrectRate", history.CorrectRate);
                insertCommand.ExecuteReader();
            }
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns></returns>
        public static List<History> Query()
        {
            List<History> entries = new List<History>();
            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand insertCommand = db.CreateCommand();
                insertCommand.CommandText = "SELECT * FROM HistoryTable";
                SqliteDataReader query = insertCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(History.CreateFromDB(query));
                }
            }
            return entries;
        }
        /// <summary>
        /// 查询N=n的记录
        /// </summary>
        public static List<History> QueryN(int n)
        {
            List<History> entries = new List<History>();
            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand insertCommand = db.CreateCommand();
                insertCommand.CommandText = "SELECT * FROM HistoryTable WHERE N = @Entry;";
                insertCommand.Parameters.AddWithValue("@Entry", n);
                SqliteDataReader query = insertCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(History.CreateFromDB(query));
                }
            }
            return entries;
        }
        /// <summary>
        /// 查询N=n,M=m的记录
        /// </summary>
        public static List<History> Query(int n, int m)
        {
            List<History> entries = new List<History>();
            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand insertCommand = db.CreateCommand();
                insertCommand.CommandText = "SELECT * FROM HistoryTable WHERE N = @NEntry And M = @MEntry;";
                insertCommand.Parameters.AddWithValue("@NEntry", n);
                insertCommand.Parameters.AddWithValue("@MEntry", m);
                SqliteDataReader query = insertCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(History.CreateFromDB(query));
                }
            }
            return entries;
        }
        /// <summary>
        /// 查询难度=n的记录
        /// </summary>
        public static List<History> QueryTop(int m)
        {
            List<History> entries = new List<History>();
            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand insertCommand = db.CreateCommand();
                insertCommand.CommandText = "SELECT * FROM HistoryTable WHERE M = @Entry;";
                insertCommand.Parameters.AddWithValue("@Entry", m);
                SqliteDataReader query = insertCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(History.CreateFromDB(query));
                }
            }
            return entries;
        }
        /// <summary>
        /// 查询N=n的用时最短的记录
        /// </summary>
        public static History QueryTop(int n,int m)
        {

            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand insertCommand = db.CreateCommand();
                insertCommand.CommandText = "SELECT * FROM HistoryTable  WHERE N = @NEntry And M = @MEntry ORDER BY TimeUsed ASC LIMIT 1;";
                insertCommand.Parameters.AddWithValue("@NEntry", n);
                insertCommand.Parameters.AddWithValue("@MEntry", m);
                SqliteDataReader query = insertCommand.ExecuteReader();
                while (query.Read())
                {
                    return History.CreateFromDB(query);
                }
                return null;
            }
        }
        /// <summary>
        /// 查询M=m的用时最短的记录
        /// </summary>
        public static History QueryMTop(int m)
        {

            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand insertCommand = db.CreateCommand();
                insertCommand.CommandText = "SELECT * FROM HistoryTable WHERE M=@Entry ORDER BY TimeUsed ASC LIMIT 1;";
                insertCommand.Parameters.AddWithValue("@Entry", m);
                SqliteDataReader query = insertCommand.ExecuteReader();
                while (query.Read())
                {
                    return History.CreateFromDB(query);
                }
                return null;
            }
        }
        /// <summary>
        /// 打开数据库所在的文件夹
        /// </summary>
        public static void OpenDB()
        {
            if (dbPath != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select," + dbPath);
            }
        }
    }
}
