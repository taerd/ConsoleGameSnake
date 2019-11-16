using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameSnake
{
    class Snake
    {
        private List<Point> _snake;
        private Point _head;
        private Point _tail;
        public enum Direction { UP,RIGHT,DOWN,LEFT }
        public Direction direction;
        public Snake(int x,int y)
        {
            Point p = new Point(x, y,'*');
            _snake = new List<Point>();
            _snake.Add(p);
            _head = p;
            p.Draw();
            direction = Direction.RIGHT;
        }
        public void Move(ConsoleKey pressed)//х-столбцы y- строчки
        {
            switch (pressed)
            {
                case ConsoleKey.UpArrow:
                    if (direction == Direction.DOWN) break;
                    else
                    {
                        direction = Direction.UP;
                        ReDraw(0,-1);
                        break;
                    }
                case ConsoleKey.RightArrow:
                    if (direction == Direction.LEFT) break;
                    else
                    {
                        direction = Direction.RIGHT;
                        ReDraw(1,0);
                        break;
                    }
                case ConsoleKey.DownArrow:
                    if (direction == Direction.UP) break;
                    else
                    {
                        direction = Direction.DOWN;
                        ReDraw(0,1);
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    if (direction == Direction.RIGHT) break;
                    else
                    {
                        direction = Direction.LEFT;
                        ReDraw(-1,0);
                        break;
                    }
            }
        }
        public void ReDraw(int x,int y)
        {
            GetNextPoint(x,y);
            _snake.Add(_head);

            _tail = _snake.First();
            _tail.Clear();
            _snake.Remove(_tail);//tail= null?
            _tail = null;

            _head.Draw();
        }
        public Point GetHead()
        {
            return _snake.Last();
        }
        public Point GetNextPoint(int x,int y)//newhead может быть null если сразу выйти
        {
            _head = new Point(_snake.Last().X, _snake.Last().Y, '*');
            _head.X += x;
            _head.Y += y;
            return _head;
        }
        public bool IsHit(Point p)
        {
            for (int i = _snake.Count - 3; i > 0; i--)
            {
                if (_snake[i].Compare(p)) return true;//столкновение с головой
            }
            return false;
        }
        public bool CheckFood(Point food)
        {
            Point possiblehead = new Point(_head.X, _head.Y, '*');
            switch (direction)
            {
                case Direction.UP:
                    possiblehead.Y += -1;
                    break;
                case Direction.RIGHT:
                    possiblehead.X += 1;
                    break;
                case Direction.DOWN:
                    possiblehead.Y += 1;
                    break;
                case Direction.LEFT:
                    possiblehead.X += -1;
                    break;
            }
            if (possiblehead.Compare(food))
            {
                _snake.Add(possiblehead);
                possiblehead.Draw();
                return true;
            }
            return false;//если не съела
        }
    }
}
