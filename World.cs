using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class World
    {
        public GameObject[] gameObjects = new GameObject[100];
        public int countGameObject = 0;

        public void Instantiate(GameObject gameObject)
        {
            gameObjects[countGameObject] = gameObject;
            countGameObject++;
        }

        public void Update()
        {
            for(int i= 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Update();
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Render();
            }
        }
    }
}
