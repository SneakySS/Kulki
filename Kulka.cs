using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kulki
{
    class Kulka
    {
        public int x;
        public int y;
        public int srednica;
        public int dx;
        public int dy;
        public Color kolor;
        public Kulka(int szer, int wys, Random r)
        {
            srednica = r.Next(4, 15);
            x = r.Next(0, szer - srednica);
            y = r.Next(0, wys - srednica);
            dx = r.Next(-2, 2);
            dy = r.Next(-2, 2);
            kolor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }
        public void rysuj(Graphics g)
        {
            g.FillEllipse(new SolidBrush(kolor), x, y, srednica, srednica);
        }
        public void przesun(int szer, int wys)
        {
            if (x < 0 || x + srednica > szer)
            {
                dx = dx * -1;
            }
            if (y < 0 || y + srednica > wys)
            {
                dy = dy * -1;
            }
            x = x + dx;
            y = y + dy;
        }
        public bool czy_kolizja(int x_gracz, int y_gracz, int szer_gracz, int wys_gracz)
        {
            if (x + srednica > x_gracz && x < x_gracz + szer_gracz)
            {
                if (y + srednica > y_gracz && y < y_gracz + wys_gracz)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
