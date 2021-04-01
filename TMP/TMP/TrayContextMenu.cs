using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMP
{
    public partial class TrayContextMenu: UserControl
    {
        private readonly Form parent;


        public TrayContextMenu(Form form)
        {
            parent = form;
            this.Visible = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TrayContextMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
