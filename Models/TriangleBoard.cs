using System.Collections.Generic;
using TriangleApi.Models;
using TriangleBoardApi.Interfaces;

namespace TriangleBoardApi.Models
{
    public class TriangleBoard : ITriangleBoard
    {
        public Dictionary<string, Triangle> Triangles {get;}

        public TriangleBoard()
        {
            // triangle grid assumptions
            // (0,0) at starting point A1, (60,60) at end point F12
            // no negative numbers for coordinates
            // (0,0) == upper-left point boundary of grid
            // (60, 0) == upper-right point boundary of grid
            // (0, 60) == lower-left point boundary of grid
            // (60, 60) == lower-right point boundary of grid
            Triangles = new Dictionary<string, Triangle>();
            char[] row = new char[] {'A', 'B', 'C', 'D', 'E', 'F'};
            int[] column = new int[] {1,2,3,4,5,6,7,8,9,10,11,12};

            int x = 0;
            int y = 0;

            foreach (char ch in row)
            {
                foreach (int yx in column)
                {
                    if (yx % 2 != 0)
                    {
                        Triangles["" + ch + yx] = new Triangle(new int[] {x,y + 10}, new int[] {x, y}, new int[] {x + 10, y + 10});
                    }
                    else
                    {
                        Triangles["" + ch + yx] = new Triangle(new int[] {x + 10,y}, new int[] {x + 10, y + 10}, new int[] {x, y});
                        x += 10;
                    }
                }
                x = 0;
                y += 10;
            }
        }

        public Triangle CalculateCoordinates(char row, int column)
        {
            string key = "" + row + column;
            
            if (Triangles.ContainsKey(key))
            {
                return Triangles[key];
            }
            else
            {
                return null;
            }
        }

        public string CalculatePosition(int[] v1, int[] v2, int[] v3)
        {
            foreach (KeyValuePair<string, Triangle> kv in Triangles)
            {
                if (kv.Value.FitCoordinates(v1, v2, v3))
                {
                return kv.Key;
                }
            }

            return null;
        }

        override public string ToString()
        {
            string str = "";

            foreach (KeyValuePair<string, Triangle> kv in Triangles)
            {
            str += $"\n{kv.Key}\n({kv.Value.Vertex1[0]}, {kv.Value.Vertex1[1]})\n"
            + $"({kv.Value.Vertex2[0]}, {kv.Value.Vertex2[1]})\n"
            + $"({kv.Value.Vertex3[0]}, {kv.Value.Vertex3[1]})\n\n";
            }

            return str;
        }
    }
}