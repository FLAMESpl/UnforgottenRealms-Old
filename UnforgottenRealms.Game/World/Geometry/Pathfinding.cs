using C5;
using SFML.Audio;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Common.Geometry.Coordinates;
using UnforgottenRealms.Game.Objects.Units;

namespace UnforgottenRealms.Game.World.Geometry
{
    public static class Pathfinding
    {
        public static readonly int Unreachable = -1;

        public static PathfindingResult FindPath(this Unit unit, Field destination)
        {
            if (unit.Location == destination || unit.MovementCost(unit.Location, destination) == Unreachable)
                return new PathfindingResult(null, false);

            var counter = 0;
            bool success = false;
            var start = unit.Location;
            var frontier = new IntervalHeap<FrontierElement>(new FrontierElement.Comparer());
            var cameFrom = new Dictionary<Field, Field>();
            var costSoFar = new Dictionary<Field, int>();

            frontier.Add(new FrontierElement(0, start));
            cameFrom.Add(start, null);
            costSoFar.Add(start, 0);

            while (!frontier.IsEmpty && counter < 150)
            {
                counter++;
                var current = frontier.DeleteMin();
                if (current.Field == destination)
                {
                    success = true;
                    break;
                }

                foreach(var neighbour in current.Field.Neighbours)
                {
                    var newCost = unit.MovementCost(current.Field, neighbour);
                    if (newCost == Unreachable)
                        continue;
                    newCost += costSoFar[current.Field];

                    if (!costSoFar.ContainsKey(neighbour) || newCost < costSoFar[neighbour])
                    {
                        costSoFar[neighbour] = newCost;
                        var priority = neighbour.DistanceTo(destination) + newCost;
                        frontier.Add(new FrontierElement(priority, neighbour));
                        cameFrom[neighbour] = current.Field;
                    }
                }
            }

            return new PathfindingResult(
                path: success ? GetPath(cameFrom, destination) : null,
                success: success
            );
        }

        public static int DistanceTo(this Field field1, Field field2) => field1.Position.DistanceTo(field2.Position);

        private static IEnumerable<Field> GetPath(this Dictionary<Field, Field> pathMap, Field destination)
        {
            var path = new List<Field>();
            var current = destination;

            do
            {
                path.Add(current);
                current = pathMap[current];
            } while (current != null);

            path.Reverse();
            return path.Skip(1);
        }
    }
}
