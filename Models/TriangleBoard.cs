using System.Collections.Generic;
using TriangleApi.Models;

namespace TriangleBoardApi.Models
{
    public class TriangleBoard
    {
        public Dictionary<string, Triangle> Triangles {get;}

        public TriangleBoard()
        {
            Triangles = new Dictionary<string, Triangle>();
            char[] row = new char[] {'F', 'E', 'D', 'C', 'B', 'A'};
            int[] column = new int[] {1,2,3,4,5,6,7,8,9,10,11,12};

            int x = 0;
            int y = 0;

            foreach (char ch in row)
            {
                foreach (int yx in column)
                {
                    if (yx % 2 != 0)
                    {
                        Triangles["" + ch + yx] = new Triangle(new int[] {x,y}, new int[] {x, y + 10}, new int[] {x + 10, y});
                    }
                    else
                    {
                        Triangles["" + ch + yx] = new Triangle(new int[] {x + 10,y + 10}, new int[] {x + 10, y}, new int[] {x, y + 10});
                        x += 10;
                    }
                }
                x = 0;
                y += 10;
            }
        }

        public Triangle CalculateTriangleCoordinates(char row, int column)
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

        public string CalculateTrianglePosition(int[] v1, int[] v2, int[] v3)
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