using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameSnake
{
    class Point
    {
        private int _x;
        private int _y;
        private char _ch;
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public char CH { get { return _ch; } set { _ch = value; } }
        public Point(int x,int y,char ch) { _x = x;_y = y;_ch = ch; }

        public void Draw()
        {
            DrawSymbol(_ch);
        }

        public void Clear()
        {
            DrawSymbol(' ');
        }
        public void DrawSymbol(char ch)
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(ch);
        }
        public bool Compare(Point b)
        {
            if (_x == b.X && _y == b.Y) return true;
            else return false;
        }
    }
}
