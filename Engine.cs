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

        static Engine instance;
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
        public int level = 0;
        public int maxLevel = 4;
        static ConsoleKeyInfo readKey;

        public World world;

        public Scene[] scenes = new Scene[4];

        public void InitScene()
        {
            string[] map01 = {
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
            scenes[0] = new Scene(map01);

            string[] map02 = {
                "**********",
                "*P       *",
                "*        *",
                "*        *",
                "*    M   *",
                "*        *",
                "*        *",
                "* M      *",
                "*       G*",
                "**********"
            };
            scenes[1] = new Scene(map02);

            string[] map03 = {
                "**********",
                "*P       *",
                "*      M *",
                "*        *",
                "*    M   *",
                "*        *",
                "*        *",
                "* M      *",
                "*       G*",
                "**********"
            };
            scenes[2] = new Scene(map03);

            string[] map04 = {
                "**********",
                "*P       *",
                "*      M *",
                "*        *",
                "*    M   *",
                "*        *",
                "*     M  *",
                "* M      *",
                "*       G*",
                "**********"
            };
            scenes[3] = new Scene(map04);
        }

        public void Load(Scene scene)
        {
            string[] map = scene.map;
            world = new World();

            for(int y=0; y< map.Length; y++)
            {
                for(int x=0; x < map[y].Length; x++)
                {
                    if (map[y][x] == '*')
                    {
                        GameObject wall = new Wall(x, y, map[y][x]);
                        world.Instantiate(wall);
                    }
                    else if (map[y][x] == ' ')
                    {
                        GameObject floor = new Floor(x, y, map[y][x]);
                        world.Instantiate(floor);
                    }
                    else if (map[y][x] == 'P')
                    {
                        GameObject player = new Player(x, y, map[y][x]);
                        world.Instantiate(player);
                    }
                    else if (map[y][x] == 'M')
                    {
                        GameObject monster = new Monster(x, y, map[y][x]);
                        world.Instantiate(monster);
                    }
                    else if (map[y][x] == 'G')
                    {
                        GameObject goal = new Goal(x, y, map[y][x]);
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
                Render();
                Input();
                Update();
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

        public void GameOver()
        {
            isRunning = false;
            Console.Clear();
            Console.WriteLine("GameOver");
        }

        public void GameClear()
        {
            isRunning = false;
            Console.Clear();
            Console.WriteLine("GameClear");
        }

        public void LevelUp()
        {
            Load(scenes[level]);
        }
    }
}
