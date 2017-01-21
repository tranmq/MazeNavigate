namespace MazeNavigate
{
    internal class Node
    {
        public Node() { }

        public Node(Index index)
        {
            MazeIndex = index;
        }

        /// <summary>
        /// For back tracking to construct the path.
        /// </summary>
        public Node Path { get; set; }

        public Index MazeIndex { get; set; }
    }
}