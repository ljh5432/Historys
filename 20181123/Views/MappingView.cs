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
        private Panel member, rule, mapping, list, controll;
        private Label label1, label2, label3, label4;
        private ListView listView;
        private ComboBox comboBox1, comboBox2;
        private TextBox textBox1, textBox2;
        private Button btn1, btn2, btn3;
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
            hashtable.Add("click", (EventHandler)Member_click);
            comboBox1 = comm.getComboBox(hashtable, member);

            hashtable = new Hashtable();
            hashtable.Add("width", 485);
            hashtable.Add("point", new Point(0, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "comboBox2");
            hashtable.Add("click", (EventHandler)Rule_click);
            comboBox2 = comm.getComboBox(hashtable, rule);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 555));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Red);
            hashtable.Add("name", "list");
            list = comm.getPanel(hashtable, mapping);

            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            listView = comm.getListView(hashtable, list);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 100));
            hashtable.Add("point", new Point(0, 555));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "controll");
            controll = comm.getPanel(hashtable, mapping);

            hashtable = new Hashtable();
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "textBox1");
            hashtable.Add("enabled", false);
            textBox1 = comm.getTextBox(hashtable, controll);

            hashtable = new Hashtable();
            hashtable.Add("width", 100);
            hashtable.Add("point", new Point(100, 0));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "textBox2");
            hashtable.Add("enabled", false);
            textBox2 = comm.getTextBox(hashtable, controll);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(200, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "추가");
            hashtable.Add("click", (EventHandler)btn1_click);
            btn1 = comm.getButton(hashtable, controll);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(300, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "삭제");
            hashtable.Add("click", (EventHandler)btn2_click);
            btn2 = comm.getButton(hashtable, controll);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(400, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "초기화");
            hashtable.Add("click", (EventHandler)btn3_click);
            btn3 = comm.getButton(hashtable, controll);

            GetSelect();
        }

        private void GetSelect()
        {
            SelectMember();
            SelectRule();
            SelectMapping();
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

        private void SelectMapping()
        {
            string sql = "SELECT [Mapping].mNo, [Member].mName, [Mapping].rNo, [Rule].rName FROM [Mapping] left outer join [Member] on ([Mapping].mNo = [Member].mNo and [Member].delYn = 'N') left outer join [Rule] on ([Mapping].rNo = [Rule].rNo and [Rule].delYn = 'N');";
            SqlDataReader sdr = db.Reader(sql);

            textBox1.Text = "";
            textBox2.Text = "";
            listView.Clear();

            listView.Columns.Add("사용자번호", 100, HorizontalAlignment.Center);
            listView.Columns.Add("사용자명", 200, HorizontalAlignment.Center);
            listView.Columns.Add("권한번호", 100, HorizontalAlignment.Center);
            listView.Columns.Add("권한명", 200, HorizontalAlignment.Center);

            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                listView.Items.Add(new ListViewItem(arr));
            }
            db.ReaderClose(sdr);
        }

        private void Member_click(object o, EventArgs a)
        {
            switch (comboBox1.SelectedValue.ToString())
            {
                case "0":
                    textBox1.Text = "";
                    return;
                default:
                    textBox1.Text = comboBox1.SelectedValue.ToString();
                    //MessageBox.Show(comboBox1.Text);
                    break;
            }
        }

        private void Rule_click(object o, EventArgs a)
        {
            switch (comboBox2.SelectedValue.ToString())
            {
                case "0":
                    textBox2.Text = "";
                    return;
                default:
                    textBox2.Text = comboBox2.SelectedValue.ToString();
                    //MessageBox.Show(comboBox2.Text);
                    break;
            }
        }

        private void btn1_click(object o, EventArgs a)
        {
            // 콤보박스 선택 여부 확인.
            if (textBox1.Text == "")
            {
                MessageBox.Show("사용자를 선택해주세요.");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("권한를 선택해주세요.");
                return;
            }

            // Mapping 테이블에 이미 연결 데이터가 있는지 확인.
            string sql = string.Format("select rNo, mNo from [Mapping] where rNo = {0} and mNo = {1};", textBox2.Text, textBox1.Text);
            SqlDataReader sdr = db.Reader(sql);
            bool check = true;
            while (sdr.Read())
            {
                check = false;
            }
            db.ReaderClose(sdr);

            // Mapping 테이블에 추가 여부 확인 후 데이터 처리하기.
            if(check)
            {
                sql = string.Format("insert into [Mapping] values ({0},{1});", textBox2.Text, textBox1.Text);
                if (db.NonQuery(sql))
                {
                    MessageBox.Show("맵핑 추가 되었습니다.");
                }
                else
                {
                    MessageBox.Show("맵핑 추가 중 오류가 발생하였습니다.");
                }
            }
            else
            {
                MessageBox.Show("중복 맵핑은 할 수 없습니다.");
            }

            GetSelect();
        }

        private void btn2_click(object o, EventArgs a)
        {
            // 콤보박스 선택 여부 확인.
            if (textBox1.Text == "")
            {
                MessageBox.Show("사용자를 선택해주세요.");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("권한를 선택해주세요.");
                return;
            }

            // Mapping 테이블에 이미 연결 데이터가 있는지 확인.
            string sql = string.Format("select rNo, mNo from [Mapping] where rNo = {0} and mNo = {1};", textBox2.Text, textBox1.Text);
            SqlDataReader sdr = db.Reader(sql);
            bool check = false;
            while (sdr.Read())
            {
                check = true;
            }
            db.ReaderClose(sdr);

            // Mapping 테이블에 삭제 여부 확인 후 데이터 처리하기.
            if (check)
            {
                sql = string.Format("delete from [Mapping] where rNo = {0} and mNo = {1};", textBox2.Text, textBox1.Text);
                if (db.NonQuery(sql))
                {
                    MessageBox.Show("맵핑 삭제가 되었습니다.");
                }
                else
                {
                    MessageBox.Show("맵핑 삭제 중 오류가 발생하였습니다.");
                }
            }
            else
            {
                MessageBox.Show("맵핑이 추가 되어 있지 않습니다.");
                return;
            }

            GetSelect();
        }

        private void btn3_click(object o, EventArgs a)
        {
            GetSelect();
        }

        private void listView_click(object o, EventArgs a)
        {
            ListView lv = (ListView)o;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
            textBox1.Text = item.SubItems[0].Text;
            textBox2.Text = item.SubItems[2].Text;
        }

    }
}
