using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }

        public override bool IsCollide()
        {
            foreach (GameObject gameObject in Engine.Instance.world.gameObjects)
            {
                if (gameObject.X == X && gameObject.Y == Y)
                {
                    if (gameObject is Monster)
                    {
                        Engine.Instance.GameOver();
                    }
                    else if (gameObject is Goal)
                    {
                        Engine.Instance.level++;
                        if (Engine.Instance.level == Engine.Instance.maxLevel)
                        {
                            Engine.Instance.GameClear();
                        }
                        else
                        {
                            Engine.Instance.LevelUp();
                        }
                    }
                    else if (gameObject is Wall)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Update()
        {
            if (Engine.Instance.GetKeyDown(ConsoleKey.W) || Engine.Instance.GetKeyDown(ConsoleKey.UpArrow))
            {
                Y--;
                if (IsCollide())
                {
                    Y++;
                }
            }
            else if (Engine.Instance.GetKeyDown(ConsoleKey.S) || Engine.Instance.GetKeyDown(ConsoleKey.DownArrow))
            {
                Y++;
                if (IsCollide())
                {
                    Y--;
                }
            }
            else if (Engine.Instance.GetKeyDown(ConsoleKey.A) || Engine.Instance.GetKeyDown(ConsoleKey.LeftArrow))
            {
                X--;
                if (IsCollide())
                {
                    X++;
                }
            }
            else if (Engine.Instance.GetKeyDown(ConsoleKey.D) || Engine.Instance.GetKeyDown(ConsoleKey.RightArrow))
            {
                X++;
                if (IsCollide())
                {
                    X--;
                }
            }
        }
    }
}
