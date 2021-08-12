using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Plotter.Plotting
{
    class TrailParticle : GameObject
    {
        public TrailParticle(float x, float y) : base()
        {
            Position = new PointF(x, y);
        }

        public override void UpdateOn(World world)
        {
            base.UpdateOn(world);
            LookTo(new PointF(float.NegativeInfinity, Position.Y));
            Forward(2f);
        }
    }
}
