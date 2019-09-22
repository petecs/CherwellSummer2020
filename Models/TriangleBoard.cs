using System.Collections.Generic;
using TriangleApi.Models;

namespace TriangleBoardApi.Models
{
    public class TriangleBoard
    {
        private Dictionary<string, Triangle> triangles = new Dictionary<string, Triangle>();

        public TriangleBoard()
        {
        }

        public Triangle CalculateTriangleCoordinates(char row, int column)
        {
            string key = "" + row + column;
            return new Triangle(new int[3], new int[3], new int[3]);
        }

        public string CalculateTrianglePosition(int[] v1, int[] v2, int[] v3)
        {
            return "";
        }
    }
}