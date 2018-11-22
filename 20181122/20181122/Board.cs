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
    public partial class Board : Form
    {
        Panel panel1, panel2;
        ListView lv;

        public Board()
        {
            InitializeComponent();
            Load += Board_Load;
        }

        private void Board_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 500);

            panel1 = new Panel();
            panel1.Size = new Size(500, 400);
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.White;
            Controls.Add(panel1);

            panel2 = new Panel();
            panel2.Size = new Size(500, 100);
            panel2.Location = new Point(0, 400);
            panel2.BackColor = Color.Blue;
            Controls.Add(panel2);

            lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.View = View.Details;
            lv.GridLines = true;
            panel1.Controls.Add(lv);

        }
    }
}
