using System;
using System.Collections.Generic;

namespace MazeNavigate
{
    public struct Index : IEquatable<Index>
    {
        public Index(uint row, uint col)
        {
            Row = row;
            Col = col;
        }

        public uint Row;

        public uint Col;

        public bool Equals(Index other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Index && Equals((Index) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Row * 397) ^ (int) Col;
            }
        }

        public static bool operator ==(Index left, Index right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Index left, Index right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"[{Row},{Col}]";
        }
    }
}