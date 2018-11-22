using Db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181121
{
    public partial class Main2 : Form
    {
        public Main2()
        {
            InitializeComponent();
            Load += Main2_Load;
        }

        ListView lv1, lv2;
        string targetDB = "";

        private void Main2_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.Size = new Size(500, 400);

            Panel headPanel = new Panel();
            headPanel.Size = new Size(500, 100);
            headPanel.Location = new Point(0, 0);
            headPanel.BackColor = Color.Silver;
            Controls.Add(headPanel);

            Panel contentsPanel = new Panel();
            contentsPanel.Size = new Size(500, 300);
            contentsPanel.Location = new Point(0, 100);
            contentsPanel.BackColor = Color.White;
            Controls.Add(contentsPanel);

            Button btn1 = new Button();
            btn1.Size = new Size(100, 60);
            btn1.Location = new Point(75, 20);
            btn1.BackColor = Color.White;
            btn1.Cursor = Cursors.Hand;
            btn1.Text = "MySQL";
            btn1.Name = "btn1";
            btn1.MouseHover += Btn_MouseHover;
            btn1.MouseLeave += Btn_MouseLeave;
            btn1.Click += Btn_Click;
            headPanel.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Size = new Size(100, 60);
            btn2.Location = new Point((250 + 75), 20);
            btn2.BackColor = Color.White;
            btn2.Cursor = Cursors.Hand;
            btn2.Text = "MSSQL";
            btn2.Name = "btn2";
            btn2.MouseHover += Btn_MouseHover;
            btn2.MouseLeave += Btn_MouseLeave;
            btn2.Click += Btn_Click;
            headPanel.Controls.Add(btn2);

            lv1 = new ListView();
            lv1.Size = new Size(100, 300);
            lv1.Location = new Point(0, 0);
            lv1.GridLines = true;
            lv1.View = View.Details;
            //lv1.BackColor = Color.Green;
            lv1.MouseClick += Lv1_MouseClick;
            contentsPanel.Controls.Add(lv1);

            lv2 = new ListView();
            lv2.Size = new Size(400, 300);
            lv2.Location = new Point(100, 0);
            lv2.GridLines = true;
            lv2.View = View.Details;
            //lv2.BackColor = Color.Red;
            contentsPanel.Controls.Add(lv2);

        }

        private void Lv1_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
            //MessageBox.Show(item.SubItems[0].Text);

            string sql = string.Format("select * from {0}", item.SubItems[0].Text);

            MySqlDataReader sdr1 = null;
            SqlDataReader sdr2 = null;
            switch (targetDB)
            {
                case "MSsql":
                    MSsql ms = new MSsql();
                    sdr2 = ms.Select(sql);
                    break;
                case "MYsql":
                    MYsql my = new MYsql();
                    sdr1 = my.Select(sql);
                    break;
            }
            ReadList(sdr1, sdr2, lv2);
        }

        private void ReadList(MySqlDataReader sdr1, SqlDataReader sdr2, ListView lv)
        {
            lv.Clear();
            lv2.Clear();
            bool 일회전 = true;

            switch (targetDB)
            {
                case "MSsql":
                    while (sdr2.Read())
                    {
                        ListViewItem item = null;
                        for (int i = 0; i < sdr2.FieldCount; i++)
                        {
                            if (일회전) lv.Columns.Add(sdr2.GetName(i));

                            string value = sdr2.GetValue(i).ToString();
                            if (item == null) item = new ListViewItem(value);
                            else item.SubItems.Add(value);
                        }
                        일회전 = false;
                        lv.Items.Add(item);
                    }
                    break;
                case "MYsql":
                    while (sdr1.Read())
                    {
                        ListViewItem item = null;
                        for (int i = 0; i < sdr1.FieldCount; i++)
                        {
                            if (일회전) lv.Columns.Add(sdr1.GetName(i));

                            string value = sdr1.GetValue(i).ToString();
                            if (item == null) item = new ListViewItem(value);
                            else item.SubItems.Add(value);
                        }
                        일회전 = false;
                        lv.Items.Add(item);
                    }
                    break;
            }

            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            MySqlDataReader sdr1 = null;
            SqlDataReader sdr2 = null;
            Button btn = (Button)sender;
            //MessageBox.Show(string.Format("Click {0}", btn.Name));
            switch (btn.Name)
            {
                case "btn1":
                    targetDB = "MYsql";
                    MYsql my = new MYsql();
                    sdr1 = my.Select("show tables;");
                    break;
                case "btn2":
                    targetDB = "MSsql";
                    MSsql ms = new MSsql();
                    sdr2 = ms.Select("select name as tableName from gdc.sys.tables;");
                    break;
            }

            ReadList(sdr1, sdr2, lv1);
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Yellow;
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }
    }
}
