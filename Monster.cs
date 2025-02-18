using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Monster : GameObject
    {
        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }

        public override bool IsCollide()
        {
            if (X < 1 || X > 8 || Y < 1 || Y > 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Update()
        {
            Random random = new Random();
            int direction = random.Next() % 4;

            if (direction == 0)
            {
                X--;
                if (IsCollide())
                {
                    X++;
                }
            }
            else if (direction == 1)
            {
                X++;
                if (IsCollide())
                {
                    X--;
                }
            }
            else if (direction == 2)
            {
                Y--;
                if (IsCollide())
                {
                    Y++;
                }
            }
            else if (direction == 3)
            {
                Y++;
                if (IsCollide())
                {
                    Y--;
                }
            }
        }
    }
}
