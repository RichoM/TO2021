using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingRoutesSimulation
{
    public class Merchant
    {
        public readonly Point Town;
        public readonly Point CapitalCity;

        public Point Position;

        public bool GoingToCapital = true;

        IEnumerable<Point> path;

        public Merchant(Point position, Point capital)
        {
            Town = Position = position;
            CapitalCity = capital;
        }

        public void UpdateOn(TerrainType[,] map, TravelMap travelMap)
        {
            Point target = GoingToCapital ? CapitalCity : Town;
            if (path == null)
            {
                if (GoingToCapital)
                {
                    path = travelMap.GetPath(Position).Reverse();
                }
                else
                {
                    path = travelMap.GetPath(Town);
                }
            }
            var actualPath = path.SkipWhile(p => p != Position).Skip(1);
            if (actualPath.Any())
            {
                Position = actualPath.First();
            }
            else
            {
                GoingToCapital = !GoingToCapital;
                path = path.Reverse();
            }
        }
    }
}
