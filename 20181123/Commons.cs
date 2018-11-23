using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181123
{
    class Commons
    {
        public Panel getPanel(Hashtable hashtable)
        {
            Panel panel = new Panel();
            panel.Size = (Size) hashtable["size"];
            panel.Location = (Point) hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            return panel;
        }
    }
}
