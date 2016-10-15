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
        int timerLetterBack = 0;
        int timerLetterBack_limit = 500;
        string textToCode = "";

        public Form1()
        {
            InitializeComponent();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textToCode = textBox1.Text;
            if(textToCode != "")
            {
                drawLetterToCode(textToCode[0]);
            }else
            {

            }
            
        }

        private void drawLetterToCode(char letter)
        {
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
            SerialPort port = new SerialPort(comboBox1.Text, 9600);
            port.Open();
            port.Write(letter.ToString());
            string c = port.ReadLine();
            label4.Text = c;
            drawLetterCoded(c[0]);
            port.Close();
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
    }


}
