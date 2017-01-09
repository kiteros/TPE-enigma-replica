using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAllocation
{
    public partial class verif : Form
    {
        int p;
        int q;


        public verif()
        {
            InitializeComponent();
        }

        private int pgcd(int a, int b)
        {
            while( a != b)
            {
                if(a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = Int32.Parse(textBox1.Text);
            q = Int32.Parse(textBox2.Text);
            int phiden = (p - 1) * (q - 1);
            int n = p * q;
            int compteur = 0;
            int PGCD1 = 0;
            int ee = 0;
            while (PGCD1 != 1)
            {
                while (compteur == 0)
                {
                    if (( p < ee ) && ( q < ee ) && ( ee < phiden))
                    {
                        compteur = 1;
                    }
                    ee++;
                }
                PGCD1 = pgcd(ee, n);
            }
            compteur = 0;
            int d = 0;

            while(compteur == 0)
            {
                if (( ee * d % phiden == 1 ) && ( p < d ) && ( q < d ) && ( d < phiden))
                {
                    compteur = 1;
                }
                d++;

                if (d > 10000000)
                {
                    label4.Visible = true;
                    label3.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    compteur = 1;
                }
            }

            if(d < 10000000)
            {
                label3.Visible = true;
                label4.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
            }

            d--;
            label5.Text = "( " + ee + " ; " + n + " )";
            label6.Text = "( " + d + " ; " + n + " )";






        }

        private void verif_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Visible = !label5.Visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Visible = !label6.Visible;
        }
    }
}
