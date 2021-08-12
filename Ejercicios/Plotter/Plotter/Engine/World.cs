using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotter
{
    class World
    {
        private Random rnd = new Random();

        private const int width = 500;
        private const int height = 500;
        private Size size = new Size(width, height);
        private List<GameObject> objects = new List<GameObject>();

        public IEnumerable<GameObject> GameObjects { get { return objects.ToArray(); } }

        public GameObject[] OrderedGameObjects
        {
            get { return GameObjects.OrderBy(each => each.Position.X).ToArray(); }
        }

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        
        public void Add(GameObject obj)
        {
            objects.Add(obj);
        }

        public void Remove(GameObject obj)
        {
            objects.Remove(obj);
        }

        public void Update()
        {
            foreach (GameObject obj in GameObjects)
            {
                obj.UpdateOn(this);
            }
        }

        public void DrawOn(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.White, 0, 0, width, height);
            if (OrderedGameObjects.Length > 2)
            {
                for (int i = 1; i < OrderedGameObjects.Length; i++)
                {
                    GameObject last = OrderedGameObjects[i - 1];
                    GameObject next = OrderedGameObjects[i];
                    if (last != null)
                    {
                        Pen pen = new Pen(Color.Blue);
                        pen.Width = 2;
                        graphics.DrawLine(pen, last.Position, next.Position);
                    }
                    last = next;
                }
            }
            foreach (GameObject obj in GameObjects)
            {
                Pen pen = new Pen(Color.Red);
                pen.Width = 2;
                graphics.FillRectangle(pen.Brush, obj.Bounds);
            }
        }
    }
}
