using System.Collections.Generic;
using TriangleApi.Models;

namespace TriangleBoardApi.Interfaces
{
    public interface ITriangleBoard
    {
        public Dictionary<string, Triangle> Triangles {get;}
        public Triangle CalculateTriangleCoordinates(char row, int column);
        public string CalculateTrianglePosition(int[] v1, int[] v2, int[] v3);
    }
}