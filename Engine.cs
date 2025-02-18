using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Engine
    {
        private Engine() {}

        static private Engine instance;
        static public Engine Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

        public bool isRunning = true;

        static ConsoleKeyInfo readKey;

        World world;

        public void Load()
        {
            string[] scene =
            {
                "**********",
                "*P       *",
                "*        *",
                "*        *",
                "*    M   *",
                "*        *",
                "*        *",
                "*        *",
                "*       G*",
                "**********"
            };

            world = new World();

            for(int y=0; y<scene.Length; y++)
            {
                for(int x=0; x < scene[y].Length; x++)
                {
                    if (scene[y][x] == '*')
                    {
                        GameObject wall = new Wall(x, y, scene[y][x]);
                        world.Instantiate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
                        GameObject floor = new Floor(x, y, scene[y][x]);
                        world.Instantiate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        GameObject player = new Player(x, y, scene[y][x]);
                        world.Instantiate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new Monster(x, y, scene[y][x]);
                        world.Instantiate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        GameObject goal = new Goal(x, y, scene[y][x]);
                        world.Instantiate(goal);
                    }
                }
            }

        }

        public void Input()
        {
            readKey = Console.ReadKey();
        }

        public void Update()
        {
            world.Update();
        }

        public void Render()
        {
            Console.Clear();
            world.Render();
        }

        public void Run()
        {
            while (isRunning)
            {
                Input();
                Update();
                Render();
            }
        }

        public bool GetKeyDown(ConsoleKey input)
        {
            if(readKey.Key == input)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
