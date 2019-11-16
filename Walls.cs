using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameSnake
{
    class Walls
    {
        private char _ch;
        private List<Point> _wall = new List<Point>();//список точек стены
        public Walls(int x,int y,char ch)
        {
            _ch = ch;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0,y);
            DrawVertical(x, y);
        }
        private void DrawHorizontal(int x,int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = new Point(i, y, _ch);
                p.Draw();
                _wall.Add(p);
            }
        }
        private void DrawVertical(int x,int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = new Point(x, i, _ch);
                p.Draw();
                _wall.Add(p);
            }
        }
        public bool IsHit(Point p)
        {
            foreach(Point w in _wall)
            {
                if (p.Compare(w)) return true;//столкновение со стеной
            }
            return false;
        }
    }
}
