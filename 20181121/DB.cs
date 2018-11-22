using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Db
{
    class MSsql
    {
        SqlConnection conn;
        public MSsql()
        {
            conn = Connection();
        }

        public void Exec()
        {
            SqlConnection conn = Connection();
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
                //MessageBox.Show("MS-SQL 연결 성공!");
            }
            catch
            {
                conn.Close();
                MessageBox.Show("MS-SQL 연결 실패!");
            }

            return conn;
        }

        public SqlDataReader Select(string sql)
        {
            //string sql = "select name as tableName from gdc.sys.tables;";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            return reader;
            /*
            ArrayList list = new ArrayList();
            while (reader.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // ht.Add(i, reader[i]);
                    ht.Add(reader.GetName(i), reader.GetValue(i));
                }
                //string result = string.Format("no={0}, name={1}", reader[0], reader[1]);
                list.Add(ht);
            }
            return list;
            */
        }
    }

    class MYsql
    {
        public void Exec()
        {
            string host = "myDB";
            string user = "root";
            string password = "1234";
            string db = "gdc";

            string connStr = string.Format(@"server={0};user={1};password={2};database={3}", host, user, password, db);
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MessageBox.Show("연결 성공");
            }
            catch
            {
                conn.Close();
                MessageBox.Show("연결 실패");
            }
            conn.Close();
        }
    }
}
