using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class GameObject
    {
        private int x;
        private int y;

        public int X;
        public int Y;
        public char Shape;

        public virtual void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Shape);
        }

        public virtual void Update()
        {
            
        }

        public virtual bool IsCollide()
        {
            return false;
        }
    }
}
