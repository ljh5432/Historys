using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    class MSsql
    {
        SqlConnection conn;
        public MSsql()
        {
            conn = Connection();
        }

        private SqlConnection Connection()
        {
            string host = "(localdb)\\ProjectsV13";
            string user = "root";
            string password = "1234";
            string db = "gdc";

            string connStr = string.Format("server={0};uid={1};password={2};database={3}", host, user, password, db);
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                MessageBox.Show("MS-SQL 연결 성공!");
            }
            catch
            {
                conn.Close();
                MessageBox.Show("MS-SQL 연결 실패!");
            }

            return conn;
        }

        public bool Close()
        {
            try
            {
                conn.Close();
                MessageBox.Show("MS-SQL 연결끊기 성공!");
            }
            catch
            {
                MessageBox.Show("MS-SQL 연결끊기 실패!");
                return false;
            }
            
            return true;
        }

        public SqlDataReader Select(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            return reader;
        }
    }
}
