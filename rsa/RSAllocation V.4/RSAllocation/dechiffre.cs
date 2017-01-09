using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAllocation
{
    public partial class dechiffre : Form
    {
        int n;
        int d;
        String textCrypt;
        int lettre_crypt;
        int ascii;
        int i;

        public dechiffre()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            d = Int32.Parse(textBox1.Text);
            n = Int32.Parse(textBox2.Text);
            textCrypt = textBox3.Text.ToString();
            i = textCrypt.Split(' ').Count() + 1;
            String[] list_bloc = textCrypt.Split(' ');
            int taille = list_bloc.Count();

            for (int compteur = 0; compteur < taille; compteur++)
            {
                lettre_crypt = Int32.Parse((string)list_bloc[compteur]);
                BigInteger ascii = BigInteger.Pow(lettre_crypt , d) % n;
                textBox4.AppendText(((char)ascii).ToString());
                

            }

            
        }
    }
}
