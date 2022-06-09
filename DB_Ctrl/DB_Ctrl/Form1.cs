using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SqlClient;

namespace DB_Ctrl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                // 接続文字列の構築
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   // 接続先の SQL Server インスタンス
                builder.UserID = "sa";              // 接続ユーザー名
                builder.Password = "your_password"; // 接続パスワード
                builder.InitialCatalog = "master";  // 接続するデータベース(ここは変えないでください)
                // builder.ConnectTimeout = 60000;  // 接続タイムアウトの秒数(ms) デフォルトは 15 秒

                // SQL Server に接続
                Console.Write("SQL Server に接続しています... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功。");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }*/

            // 先ほどコピーした接続文字列を貼り付ける
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\_git\VS\DB_Ctrl\DB_Ctrl\DB_Ctrl\prg_db.mdf;Integrated Security=True";

            // 実行するSELECT文
            var sql = "SELECT * FROM PrgType";

            // 接続のためのオブジェクトを生成
            // 実行後にオブジェクトのCloseが必要なため基本的にusing文で囲う
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続開始
                connection.Open();

                // SqlCommand：DBにSQL文を送信するためのオブジェクトを生成
                // SqlDataReader：読み取ったデータを格納するためのオブジェクトを生成
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    // 1行ごとに読み取る。読み取ったらtrue
                    while (reader.Read())
                    {
                        // 列名を指定して、読み取ったデータをコンソール上に表示
                        Console.WriteLine($"" +
                            $"{reader["PrgType_Name"]}\t\t" +
                            $"{reader["PrgType_Id"]}\t\t");
                    }
                }
            }
        }
    }
}
