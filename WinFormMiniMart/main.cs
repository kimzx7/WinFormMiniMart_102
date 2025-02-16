using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMiniMart
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void จดการToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void พนกงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void สนคToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategories frm = new frmCategories();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void คำนวนสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPos frm = new frmPos();
            //frm.MdiParent = this;
            frm.Show();
        }
    }
}
