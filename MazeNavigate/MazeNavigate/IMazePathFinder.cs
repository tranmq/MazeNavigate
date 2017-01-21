using System.Collections.Generic;

namespace MazeNavigate
{
    public interface IMazePathFinder
    {
        /// <summary>
        /// Find the shortest path through the defined maze from the entrance to the exit.
        /// </summary>
        /// <param name="maze">The 2D array with 0s as path and 1s as blockage.</param>
        /// <param name="entrance">The index of the 2D maze to start.</param>
        /// <param name="exit">The index of the 2D maze to stop.</param>
        /// <returns>
        /// The list of indices representing the path from the entrance point to the exit point.
        /// If no path can be found, the returned list is an empty list.
        /// </returns>
        List<Index> FindPath(uint[,] maze, Index entrance, Index exit);
    }
}
