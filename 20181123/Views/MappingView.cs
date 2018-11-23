using DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181123
{
    class MappingView
    {
        private MSsql db;
        private Commons comm;
        private Panel member, rule, mapping;
        private Label label1, label2, label3, label4;
        private ComboBox comboBox1, comboBox2;
        private Button btn1, btn2;
        private Form parentForm;
        private Hashtable hashtable;
        private BindingSource bs;

        public MappingView(Form parentForm, Object oDB)
        {
            this.parentForm = parentForm;
            this.db = (MSsql)oDB;
            comm = new Commons();
            getView();
        }

        private void getView()
        {
            hashtable = new Hashtable();
            hashtable.Add("type", "");
            hashtable.Add("size", new Size(500, 45));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Red);
            hashtable.Add("name", "member");
            member = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(500, 45));
            hashtable.Add("point", new Point(500, 0));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "rule");
            rule = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 655));
            hashtable.Add("point", new Point(0, 45));
            hashtable.Add("color", Color.Blue);
            hashtable.Add("name", "mapping");
            mapping = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(500, 20));
            hashtable.Add("point", new Point(0, 5));
            hashtable.Add("color", Color.Red);
            hashtable.Add("name", "label1");
            hashtable.Add("text", "Member");
            label1 = comm.getLabel(hashtable, member);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(500, 20));
            hashtable.Add("point", new Point(0, 5));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "label2");
            hashtable.Add("text", "Rule");
            label2 = comm.getLabel(hashtable, rule);

            hashtable = new Hashtable();
            hashtable.Add("width", 500);
            hashtable.Add("point", new Point(0, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "comboBox1");
            hashtable.Add("click", (EventHandler) Member_click);
            comboBox1 = comm.getComboBox(hashtable, member);

            hashtable = new Hashtable();
            hashtable.Add("width", 485);
            hashtable.Add("point", new Point(0, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "comboBox2");
            hashtable.Add("click", (EventHandler) Rule_click);
            comboBox2 = comm.getComboBox(hashtable, rule);

            GetSelect();
        }

        private void GetSelect()
        {
            SelectMember();
            SelectRule();
        }

        private void SelectMember()
        {
            string sql = "select mNo, mName from Member where delYn = 'N';";
            SqlDataReader sdr = db.Reader(sql);
            bs = new BindingSource();
            hashtable = new Hashtable();
            hashtable.Add("0", "선택하세요.");
            while (sdr.Read())
            {
                hashtable.Add(sdr.GetInt32(0), sdr.GetString(1));
            }
            db.ReaderClose(sdr);
            bs.DataSource = hashtable;
            comboBox1.DataSource = bs;
            comboBox1.SelectedIndexChanged += Member_click;
        }

        private void SelectRule()
        {
            string sql = "select rNo, rName from [Rule] where delYn = 'N';";
            SqlDataReader sdr = db.Reader(sql);
            bs = new BindingSource();
            hashtable = new Hashtable();
            hashtable.Add("0", "선택하세요.");
            while (sdr.Read())
            {
                hashtable.Add(sdr.GetInt32(0), sdr.GetString(1));
            }
            db.ReaderClose(sdr);
            bs.DataSource = hashtable;
            comboBox2.DataSource = bs;
            comboBox2.SelectedIndexChanged += Rule_click;
        }

        private void Member_click(object o, EventArgs a)
        {
            switch (comboBox1.SelectedValue.ToString()) {
                case "0":
                    return;
                default:
                    MessageBox.Show(comboBox1.Text);
                    break;
            }
        }

        private void Rule_click(object o, EventArgs a)
        {
            switch (comboBox2.SelectedValue.ToString())
            {
                case "0":
                    return;
                default:
                    MessageBox.Show(comboBox2.Text);
                    break;
            }
        }

    }
}
