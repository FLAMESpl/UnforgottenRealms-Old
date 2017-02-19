using System.Collections.Generic;

namespace UnforgottenRealms.Game.World.Geometry
{
    public class PathfindingResult
    {
        public IEnumerable<Field> Path { get; }
        public bool Success { get; }

        public PathfindingResult(IEnumerable<Field> path, bool success)
        {
            Path = path;
            Success = success;
        }
    }
}
