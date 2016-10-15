using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int lettreEnCours = 0;
        int tailleMessage = 0;
        string textToCode = "";
        string textCoded = "";
        List<String> inversions = new List<String>();
        List<char> lFrom = new List<char>();
        List<char> lto = new List<char>();

        public Form1()
        {
            InitializeComponent();
            inversions = variables.getLiaison();
            if (inversions.Any())
            {
                invers.Text = "il y a des inversions : ";
            }
            else
            {
                invers.Text = "Aucune inversion";
            }
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index += 1;
                comboBox1.Items.Add(ArrayComPortsNames[index]);
            } while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));


            Array.Sort(ArrayComPortsNames);
            Array.Reverse(ArrayComPortsNames);
            

            

            //want to get first out
            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                ComPortName = ArrayComPortsNames[0];
            }
            comboBox1.Text = ArrayComPortsNames[0];
            listBox1.Items.Add("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textToCode = textBox1.Text;
            tailleMessage = textToCode.Length;
            if (textToCode != "")
            {
                drawLetterToCode(textToCode[lettreEnCours]);
            }else
            {

            }
            
        }

        private void drawLetterToCode(char letter)
        {
            if (letter == ' ')
            {
                lettreEnCours++;
                letter = textToCode[lettreEnCours];
            }
            
            System.Drawing.Graphics graphicsObj;
            pictureBox1.Visible = true;
            graphicsObj = this.CreateGraphics();
            graphicsObj.Clear(SystemColors.Control);
            Pen myPen = new Pen(System.Drawing.Color.Green, 5);
            Rectangle myRectangle = new Rectangle(560, 425, 65, 65);
            graphicsObj.DrawEllipse(myPen, myRectangle);
            Font myFont = new System.Drawing.Font("Helvetica", 40, FontStyle.Italic);
            Brush myBrush = new SolidBrush(System.Drawing.Color.Black);
            graphicsObj.DrawString(letter.ToString(), myFont, myBrush, 570, 425);
            
            //letterBack.Visible = true;
            label17.Text = Char.ToUpper(letter).ToString();
            if (inversions.Any())
            {
                
                char newLetter = ' ';
                if (lFrom.Contains(Char.ToUpper(letter)))
                {
                    
                    newLetter = lto[lFrom.IndexOf(Char.ToUpper(letter))];
                    label18.Text = newLetter.ToString();
                }
                letter = newLetter;
            }else
            {
                label18.Text = Char.ToUpper(letter).ToString();
            }
            
            SerialPort port = new SerialPort(comboBox1.Text, 9600);
            port.Open();
            port.Write(Char.ToLower(letter).ToString());
            string c = port.ReadLine();
            label4.Text = char.ToUpper(c[0]).ToString();
            listBox1.Items.Clear();
            textCoded += c;
            listBox1.Items.Add(textCoded);
            drawLetterCoded(c[0]);
            port.Close();
            
            double progress = ((double)(lettreEnCours +1)/ (double)tailleMessage) * 100;
            progressBar1.Value = (int)progress;;
        }

        private void drawLetterCoded(char letter)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Green, 5);
            Rectangle myRectangle = new Rectangle(650, 520, 65, 65);
            graphicsObj.DrawEllipse(myPen, myRectangle);
            Font myFont = new System.Drawing.Font("Helvetica", 40, FontStyle.Italic);
            Brush myBrush = new SolidBrush(System.Drawing.Color.Black);
            graphicsObj.DrawString(letter.ToString(), myFont, myBrush, 650, 520);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plugboard p = new plugboard();
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            lFrom.Clear();
            lto.Clear();
            inversions = variables.getLiaison();
            if (inversions.Any())
            {
                invers.Text = "il y a des inversions : ";
                
                for (int x = 0; x < inversions.Count; x++)
                {
                    String[] p = inversions[x].Split('-');
                    char letterFrom = p[0][0];
                    char letterTo = p[1][0];
                    listBox2.Items.Add(letterFrom.ToString() + " devient " + letterTo.ToString());
                    listBox2.Items.Add(" et " + letterTo.ToString() + " devient " + letterFrom.ToString());
                    lFrom.Add(letterFrom);
                    lto.Add(letterTo);
                    lFrom.Add(letterTo);
                    lto.Add(letterFrom);
                }
            }else
            {
                invers.Text = "Aucune inversion";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lettreEnCours++;
            if(textToCode.Length -1 >= lettreEnCours)
            {
                drawLetterToCode(textToCode[lettreEnCours]);
            }else
            {
                error te = new error();
                te.Show();
            }
            
        }

        
    }


}
