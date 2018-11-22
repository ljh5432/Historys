using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181122
{
    public partial class Main : Form
    {
        Panel headPanel, contentsPanel;
        Button btn1, btn2;
        MSsql msSql;
        Board boardForm;

        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.Size = new Size(500, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "MS-SQL";

            headPanel = new Panel();
            headPanel.Size = new Size(500, 100);
            headPanel.Location = new Point(0, 0);
            headPanel.BackColor = Color.Silver;
            Controls.Add(headPanel);

            contentsPanel = new Panel();
            contentsPanel.Size = new Size(500, 500);
            contentsPanel.Location = new Point(0, 100);
            contentsPanel.BackColor = Color.White;
            Controls.Add(contentsPanel);

            btn1 = new Button();
            btn1.Size = new Size(100, 60);
            btn1.Location = new Point(75, 20);
            btn1.BackColor = Color.White;
            btn1.Cursor = Cursors.Hand;
            btn1.Text = "연결";
            btn1.Name = "btnOn";
            btn1.Click += Btn_Click;
            headPanel.Controls.Add(btn1);

            btn2 = new Button();
            btn2.Size = new Size(100, 60);
            btn2.Location = new Point((250 + 75), 20);
            btn2.BackColor = Color.White;
            btn2.Cursor = Cursors.Hand;
            btn2.Text = "연결끊기";
            btn2.Name = "btnOff";
            btn2.Enabled = false;
            btn2.Click += Btn_Click;
            headPanel.Controls.Add(btn2);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            // 상태값 설정
            btn1.Enabled = !btn1.Enabled;
            btn2.Enabled = !btn2.Enabled;
            // 버튼 클릭 이벤트 실행
            Button btn = (Button) sender;
            switch (btn.Name)
            {
                case "btnOn": // 데이터베이스 연결 요청 이벤트
                    msSql = new MSsql();
                    boardForm = new Board();
                    boardForm.MdiParent = this;
                    boardForm.WindowState = FormWindowState.Maximized;
                    boardForm.FormBorderStyle = FormBorderStyle.None;
                    contentsPanel.Controls.Add(boardForm);
                    boardForm.Show();
                    break;
                case "btnOff": // 데이터베이스 연결끊기 요청 이벤트
                    msSql.Close();
                    boardForm.Dispose();
                    break;
                default:
                    break;
            }
        }

    }
}
