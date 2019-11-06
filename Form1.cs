using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kulki
{
    public partial class Form1 : Form
    {
        bool czy_gra_aktywna = false;
        Random r = new Random();
        Kulka[] k = new Kulka[100];
        Gracz g;
        int ile_kulek;
        int punkty;
        public Form1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (czy_gra_aktywna)
            {
                panel1.CreateGraphics().Clear(Color.LightBlue);
                g.rysuj(panel1.CreateGraphics(), Color.Red);
                for (int i = 0; i < ile_kulek; i++)
                {
                    k[i].rysuj(panel1.CreateGraphics());
                    k[i].przesun(panel1.Width, panel1.Height);
                    if (k[i].czy_kolizja(g.x, g.y, g.szerokosc, g.wysokosc))
                    {
                        czy_gra_aktywna = false;
                        textBox1.Enabled = true;
                        button1.Enabled = true;
                        MessageBox.Show("Twój wynik to: " + Convert.ToString(punkty));
                    }
                }
                punkty = punkty + 1;
            }
            else
            {
                FontFamily fFamily = new FontFamily("Arial");
                Font f = new Font(fFamily, 15);
                Brush b = new SolidBrush(Color.Black);
                panel1.CreateGraphics().DrawString("Podaj liczbę kulek,", f, b, 120, 135);
                panel1.CreateGraphics().DrawString("następnie naciśnij Start", f, b, 100, 165);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ile_kulek = int.Parse(textBox1.Text);
            if (ile_kulek > 100) { ile_kulek = 100; }
            czy_gra_aktywna = true;
            g = new Gracz(panel1.Width, panel1.Height, 20, 20);
            for (int i = 0; i < ile_kulek; i++)
            {
                k[i] = new Kulka(panel1.Width, panel1.Height, r);
            }
            textBox1.Enabled = false;
            button1.Enabled = false;
            punkty = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { g.przesun("gora"); }
            if (e.KeyCode == Keys.Down) { g.przesun("dol"); }
            if (e.KeyCode == Keys.Right) { g.przesun("prawa"); }
            if (e.KeyCode == Keys.Left) { g.przesun("lewa"); }
        }
    }
}
