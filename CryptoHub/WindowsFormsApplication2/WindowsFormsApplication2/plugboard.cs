using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class plugboard : Form
    {
        private bool[] clicked = new bool[52];
        private bool[] isBloked = new bool[52];
        private CirclePanel[] panels = new CirclePanel[52];
        private Label[] lettresText = new Label[52];
        
        String alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int nbCLicksAffile = 0;
        private int nbLignesOk = 0;
        private char premLettre;
        private char secLettre;
        private Point dep;
        List<Ligne> touteLignes = new List<Ligne>();
        List<String> touteLiaisons = new List<String>();
        List<Label> toutLabels = new List<Label>();
        public plugboard()
        {
            InitializeComponent();

            for (int x = 0; x < 26; x++)
            {
                panels[x] = new CirclePanel();
                panels[x].Location = new Point(10 + 55 * x, 60);
                panels[x].Size = new Size(50, 50);
                panels[x].Name = x.ToString();
                //panels[x].BackColor = Color.Black;
                panels[x].MouseEnter += new EventHandler(pan_MouseEnter);
                panels[x].MouseLeave += new EventHandler(pan_MouseLeave);
                panels[x].Click += new EventHandler(pan_Click);

                this.Controls.Add(panels[x]);
                lettresText[x] = new Label();
                lettresText[x].Location = new Point(10 + 55 * x, 5);
                lettresText[x].Text = alphabet[x].ToString();
                lettresText[x].AutoSize = true;
                lettresText[x].Font = new Font(lettresText[x].Font.FontFamily, 35);
                this.Controls.Add(lettresText[x]);
                clicked[x] = false;
            }
            for (int x = 26; x < 52; x++)
            {
                panels[x] = new CirclePanel();
                panels[x].Location = new Point(10 + 55 * (x - 26), 300);
                panels[x].Size = new Size(50, 50);
                panels[x].Name = x.ToString();
                //panels[x].BackColor = Color.Black;

                panels[x].MouseEnter += new EventHandler(pan_MouseEnter);
                panels[x].MouseLeave += new EventHandler(pan_MouseLeave);
                panels[x].Click += new EventHandler(pan_Click);

                this.Controls.Add(panels[x]);
                lettresText[x] = new Label();
                lettresText[x].Location = new Point(10 + 55 * (x - 26), 350);
                lettresText[x].Text = alphabet[x - 26].ToString();
                lettresText[x].AutoSize = true;
                lettresText[x].Font = new Font(lettresText[x].Font.FontFamily, 35);
                this.Controls.Add(lettresText[x]);
                clicked[x] = false;
            }
            panel1.Parent.MouseMove += new MouseEventHandler(pan_MouseMove);

        }

        private void pan_MouseEnter(object sender, EventArgs e)
        {
            string PanelName = ((CirclePanel)sender).Name;
            int valueOfPanel = Int32.Parse(PanelName);
            //panels[valueOfPanel].BackColor = Color.Black;
            if (!clicked[valueOfPanel] && !isBloked[valueOfPanel])
            {
                panels[valueOfPanel].hoverEllipse();
            }
        }

        private void pan_MouseLeave(object sender, EventArgs e)
        {
            string PanelName = ((CirclePanel)sender).Name;
            int valueOfPanel = Int32.Parse(PanelName);
            //panels[valueOfPanel].BackColor = Color.Transparent;
            if (!clicked[valueOfPanel] && !isBloked[valueOfPanel])
            {
                panels[valueOfPanel].clearEllipse();
            }

        }

        private void pan_Click(object sender, EventArgs e)
        {
            string PanelName = ((CirclePanel)sender).Name;
            int valueOfPanel = Int32.Parse(PanelName);
            if (!isBloked[valueOfPanel])
            {
                panels[valueOfPanel].fillEllipse();
                clicked[valueOfPanel] = true;
                if (nbCLicksAffile == 0)
                {
                    premLettre = alphabet[valueOfPanel % 26];
                }
                else
                {
                    secLettre = alphabet[valueOfPanel % 26];
                }

                nbCLicksAffile++;
                if (nbCLicksAffile == 2)
                {
                    //Nouvelle liaison
                    nbCLicksAffile = 0;
                    panels[alphabet.IndexOf(premLettre) + 26].WrongEllipse();
                    isBloked[alphabet.IndexOf(premLettre) + 26] = true;
                    panels[alphabet.IndexOf(secLettre)].WrongEllipse();
                    isBloked[alphabet.IndexOf(secLettre)] = true;
                    Point t = this.PointToClient(Cursor.Position);
                    Ligne ligne = new Ligne(dep, t);
                    touteLignes.Add(ligne);

                    Label l = new Label();
                    l.Location = new Point(10, 450 + nbLignesOk * 15);
                    l.AutoSize = true;
                    l.Font = new Font(l.Font.FontFamily, 10);
                    l.Text = premLettre.ToString() + "-" + secLettre.ToString();
                    toutLabels.Add(l);
                    touteLiaisons.Add(l.Text);
                    
                    this.Controls.Add(toutLabels[nbLignesOk]);
                    nbLignesOk++;
                }

                dep = ((CirclePanel)sender).Location;
                dep.X += 25;
                dep.Y += 25;
            }
        }

        private void dessinerLigne(Point depart, Point finish, List<Ligne> l)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.Clear(Color.White);
            Pen blackPen = new Pen(Color.Black, 3);
            graphicsObj.DrawLine(blackPen, depart, finish);
            if (l.Any())
            {
                for(int y = 0; y < l.Count; y++)
                {
                    graphicsObj.DrawLine(blackPen, l[y].getDep(), l[y].getArr());
                }
            }
        }

        private void clearLignes()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.Clear(Color.White);
        }

        private void pan_MouseMove(object sender, EventArgs e)
        {
            if (nbCLicksAffile == 1)
            {
                Point p = this.PointToClient(Cursor.Position);
                dessinerLigne(dep, p, touteLignes);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int x = 0; x < 52; x++)
            {
                clicked[x] = false;
                panels[x].clearEllipse();
                isBloked[x] = false;
                
            }
            nbCLicksAffile = 0;
            touteLignes.Clear();
            touteLiaisons.Clear();
            nbLignesOk = 0;
            for(int x = 0; x < toutLabels.Count; x++)
            {
                this.Controls.Remove(toutLabels[x]);
            }
            toutLabels.Clear();
            clearLignes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            variables.clearList();
            for (int x = 0; x < touteLiaisons.Count; x++)
            {
                variables.AddStringLiaison(touteLiaisons[x]);
            }
            this.Close();
        }
    }
    public class CirclePanel : Panel
    {
        public CirclePanel()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
        }

        protected override void OnResize(EventArgs e)
        {
            this.Width = this.Height;
            base.OnResize(e);
        }

        public void fillEllipse()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            graphicsObj.FillEllipse(myBrush, 0, 0, this.Width - 1, this.Height - 1);
        }

        public void WrongEllipse()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Red);
            graphicsObj.FillEllipse(myBrush, 0, 0, this.Width - 1, this.Height - 1);
        }

        public void clearEllipse()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.White);
            graphicsObj.FillEllipse(myBrush, 0, 0, this.Width - 1, this.Height - 1);
            graphicsObj.DrawEllipse(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
        }

        public void hoverEllipse()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Orange);
            graphicsObj.FillEllipse(myBrush, 0, 0, this.Width - 1, this.Height - 1);
        }
    }

    public class Ligne
    {
        private Point dep_;
        private Point Arr_;
        public Ligne(Point dep, Point Arr)
        {
            this.dep_ = dep;
            this.Arr_ = Arr;
        }

        public Point getDep()
        {
            return dep_;
        }

        public Point getArr()
        {
            return Arr_;
        }
    }
}
