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
    public partial class chiffre : Form
    {
        int ee;
        int n;
        int taille_du_mot;
        int ascii;
        public chiffre()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ee = Int32.Parse(textBox1.Text);
            n = Int32.Parse(textBox2.Text);
            string mot = textBox3.Text;
            taille_du_mot = mot.Length;
            int i = 0;
            List<int> phraseCrypt = new List<int>();
            while (i < taille_du_mot)
            {
                ascii = (int)(mot[i]);
                BigInteger lettre_crypt = BigInteger.Pow(ascii, ee) % n;

                if (ascii > n)
                {
                    textBox4.Text = "Les nombres p et q sont trop petits veulliez recommencer";
                }

                if (lettre_crypt > n)
                {
                    textBox4.Text = "Erreur de calcul";
                }

 
                phraseCrypt.Add((int)lettre_crypt);
                i++;


            }
            for (int f = 0; f < (phraseCrypt.Count()); f++)
            {
                textBox4.AppendText(phraseCrypt[f].ToString() + " ");


            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}