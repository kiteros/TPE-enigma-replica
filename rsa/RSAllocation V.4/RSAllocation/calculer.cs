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
    public partial class calculer : Form
    {
        List<int> listep = new List<int>();
        List<int> newlistep = new List<int>();
        int n_a_tester = 5;
        int a = 3;
        int limite;

        public calculer()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limite = Int32.Parse(textBox1.Text);
            listep.Add(2);
            listep.Add(3);


            while (a < limite)
            {
                test(n_a_tester);
                n_a_tester++;
                a++;
            }
            for(int i = 0; i < 5; i++)
            {
                newlistep.Add(listep[listep.Count() - i - 1]);
            }

            newlistep.Reverse();

            listBox1.Visible = true;
            label2.Visible = true;


            for (int i = 0; i < 5; i++)
            {
                listBox1.Items.Add(newlistep[i]);
            }

            
        }

        private int test(int n_a)
        {
            int n_list = listep.Count();

            for(int i = 0; i < n_a; i++)
            {
                if (n_a % listep[i] == 0)
                {
                    break;
                }
                else if (((i + 1) == n_list) || (n_a < (listep[i] * listep[i])))
                {
                    listep.Add(n_a_tester);
                    return n_a;
                    break;
                }
            }
            return 0;
        }

    }
}
