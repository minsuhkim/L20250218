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
            foreach (GameObject gameObject in Engine.Instance.world.gameObjects)
            {
                if (gameObject is Wall)
                {
                    if (gameObject.X == X && gameObject.Y == Y)
                    {
                        return true;
                    }
                }
            }
            return false;
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
