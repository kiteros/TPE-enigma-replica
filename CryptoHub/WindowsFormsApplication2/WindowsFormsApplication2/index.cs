using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;


namespace WindowsFormsApplication2
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 p = new Form1();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://richpad.com/tpe/tpe/start.php");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            rsa r = new rsa();
            r.Show();
        }
    }
}
