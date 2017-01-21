using System.Collections.Generic;
using System.Linq;

namespace MazeNavigate
{
    public class MazePathFinder : IMazePathFinder
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
        public List<Index> FindPath(uint[,] maze, Index entrance, Index exit)
        {
            if (maze == null || 
                MazeHasNoDimensions(maze) || 
                !IsValidPathNode((int) entrance.Row, (int) entrance.Col, maze) ||
                !IsValidPathNode((int) exit.Row, (int) exit.Col, maze)
               )
            {
                return new List<Index>(0);
            }

            var visitedNodes = new HashSet<Index>();
            int mazeSize = maze.GetLength(0) * maze.GetLength(1);
            var track = new Queue<Node>(mazeSize);
            track.Enqueue(new Node(entrance));

            while (track.Count != 0)
            {
                Node currentNode = track.Dequeue();
                if (currentNode.MazeIndex == exit)
                {
                    return ConstructPath(currentNode);
                }
                visitedNodes.Add(currentNode.MazeIndex);
                IEnumerable<Node> neighboringNodes = GetNeighboringPathNodesOf(currentNode, maze);
                foreach (var neighbor in neighboringNodes)
                {
                    if (visitedNodes.Contains(neighbor.MazeIndex))
                    {
                        continue;
                    }
                    neighbor.Path = currentNode;
                    track.Enqueue(neighbor);
                }
            }

            return new List<Index>(0);
        }

        private static bool MazeHasNoDimensions(uint[,] maze)
        {
            return maze.GetLength(0) == 0 && maze.GetLength(1) == 0;
        }

        private static List<Index> ConstructPath(Node node)
        {
            var result = new Stack<Index>();
            var currentNode = node;

            do
            {
                result.Push(currentNode.MazeIndex);
                currentNode = currentNode.Path;
            } while (currentNode != null);

            return result.ToList();
        }

        private IEnumerable<Node> GetNeighboringPathNodesOf(Node currentNode, uint[,] maze)
        {
            var indexOffsets = new[]
                               {
                                   new {Row = -1, Col = 0},     // North
                                   new {Row = 0, Col = 1},      // East
                                   new {Row = 1, Col = 0},      // South
                                   new {Row = 0, Col = -1}      // West
                               };
            var result = new List<Node>(4);
            foreach (var indexOffset in indexOffsets)
            {
                var row = (int) (currentNode.MazeIndex.Row + indexOffset.Row);
                var col = (int) (currentNode.MazeIndex.Col + indexOffset.Col);

                if (IsValidPathNode(row, col, maze))
                {
                    var neighboringPathNode = new Node(new Index((uint) row, (uint) col));
                    result.Add(neighboringPathNode);
                }
            }
            return result;
        }

        private bool IsValidPathNode(int row, int col, uint[,] maze)
        {
            return row >= 0 && row < maze.GetLength(0) &&
                   col >= 0 && col < maze.GetLength(1) &&
                   IsIndexOfPath((uint) row, (uint) col, maze);
        }

        private static bool IsIndexOfPath(uint row, uint col, uint[,] maze)
        {
            return maze[row, col] == 0;
        }
    }
}
