using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;

namespace _20181123
{
    public partial class Main : Form
    {
        private MSsql db;
        private Commons comm;

        public Main()
        {
            InitializeComponent();
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            db = new MSsql();
            comm = new Commons();

            this.IsMdiContainer = true;
            this.Size = new Size(1000, 800);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "회원정보";

            Hashtable hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 100));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "head");
            Controls.Add(comm.getPanel(hashtable));

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 700));
            hashtable.Add("point", new Point(0, 100));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "contents");
            Controls.Add(comm.getPanel(hashtable));

            // 버튼 이벤트 영역
            UserForm uf = new UserForm(db);
            uf.MdiParent = this;
            uf.WindowState = FormWindowState.Maximized;
            uf.FormBorderStyle = FormBorderStyle.None;
            //uf.Show();

            foreach (Control ctr in Controls)
            {
                if(ctr.Name == "contents")
                {
                    ctr.Controls.Add(uf);
                    uf.Show();
                }
            }

        }
    }
}
