using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotter.Plotting
{
    class PlottingFunction : GameObject
    {
        public override void UpdateOn(World world)
        {
            base.UpdateOn(world);
            X += 1f;
            Y = GetY(X - world.Width);
            world.Add(new TrailParticle(Position.X, Position.Y));
        }

        private float GetY(double x)
        {
            if (x <= 1) return 1;
            return 5 * (GetY(x - 1) + GetY(x - 2)) / GetY(x - 3);
        }
    }
}
