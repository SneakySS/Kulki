using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kulki
{
    class Gracz
    {
        public int y;
        public int x;
        public int szerokosc;
        public int wysokosc;
        public int szer_okna;
        public int wys_okna;
        public Gracz(int szerokosc_okna, int wysokosc_okna, int wys_gracza, int szer_gracza)
        {
            wysokosc = wys_gracza;
            szerokosc = szer_gracza;
            x = (szerokosc_okna - szer_gracza) / 2;
            y = (wysokosc_okna - wys_gracza) / 2;
            szer_okna = szerokosc_okna;
            wys_okna = wysokosc_okna;
        }
        public void rysuj(Graphics g, Color kol)
        {
            g.FillRectangle(new SolidBrush(kol), x, y, szerokosc, wysokosc);
        }
        public void przesun(string strona)
        {
            if (strona == "prawa" && x + szerokosc < szer_okna)
            {
                x = x + 5;
            }
            else if (strona == "lewa" && x > 0)
            {
                x = x - 5;
            }
            else if (strona == "gora" && y > 0)
            {
                y = y - 5;
            }
            else if (strona == "dol" && y + wysokosc < wys_okna)
            {
                y = y + 5;
            }
        }

    }
}
