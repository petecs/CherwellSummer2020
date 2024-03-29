using System.Collections.Generic;
using TriangleApi.Models;

namespace TriangleBoardApi.Interfaces
{
    public interface ITriangleBoard
    {
        Dictionary<string, Triangle> Triangles {get;}
        Triangle CalculateCoordinates(string key);
        string CalculatePosition(int[] v1, int[] v2, int[] v3);
    }
}