namespace MazeNavigate
{
    public struct Index
    {
        public Index(uint row, uint col)
        {
            Row = row;
            Col = col;
        }

        public uint Row;

        public uint Col;
    }
}