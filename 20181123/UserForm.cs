using DB;
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

namespace _20181123
{
    public partial class UserForm : Form
    {
        private MSsql db;

        public UserForm(Object oDB)
        {
            InitializeComponent();
            this.db = (MSsql) oDB;
            Load += UserForm_Load;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
