using System.Collections.Generic;
using TriangleApi.Models;

namespace TriangleBoardApi.Interfaces
{
    public interface ITriangleBoard
    {
        Dictionary<string, Triangle> Triangles {get;}
        Triangle CalculateTriangleCoordinates(char row, int column);
        string CalculateTrianglePosition(int[] v1, int[] v2, int[] v3);
    }
}