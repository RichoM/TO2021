using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotter
{
    abstract class GameObject
    {
        private PointF position = new PointF(0,0);
        private double rotation = 0;

        public PointF Position
        {
            get { return position; }
            set { position = value; }
        }

        public float X
        {
            get { return Position.X; }
            set { Position = new PointF(value, Y); }
        }

        public float Y
        {
            get { return Position.Y; }
            set { Position = new PointF(X, value); }
        }
        
        public double Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public RectangleF Bounds
        {
            get { return new RectangleF(Position, new Size(1, 1)); }
        }

        public virtual void UpdateOn(World world)
        {
            // Do nothing
        }

        public void Forward(float dist)
        {
            Position = new PointF((int)Math.Round(Math.Cos(rotation) * dist + Position.X),
                                  (int)Math.Round(Math.Sin(rotation) * dist + Position.Y));
        }

        public void LookTo(PointF p)
        {
            Rotation = Math.Atan2(p.Y - Position.Y, p.X - Position.X);
        }
    }
}
