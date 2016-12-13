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
    public partial class chiffre : Form
    {	
		int e;
		int n;
		
        public chiffre()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			e = Int32.Parse(textBox1.Text);
            n = Int32.Parse(textBox2.Text);
			string mot = textBox3.Text;
			taille_du_mot = mot.length();
			int i = 0;
			List<int> phraseCrypt = new List<int>();
			
			while (i < taille_du_mot)
			{
				int ascii =(int)(mot[i]);
				lettre_crypt = Math.Pow(ascii,e)%n
				
			}
			

        }
    }
}
