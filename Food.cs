using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameSnake
{
    class Food
    {
        private int _x;
        private int _y;
        private char _ch;
        public Point position;
        Random rand = new Random();
        public Food(int x,int y,char ch)//x и y - размеры игрового поля(границы)
        {
            _x = x;
            _y = y;
            _ch = ch;
        }
        public void CreateFood()
        {
            //position = new Point(42,13, _ch);//для проверки сравнений
            position = new Point(rand.Next(2,_x-2),rand.Next(2,_y-2),_ch);
            position.Draw();
        }

    }
}
