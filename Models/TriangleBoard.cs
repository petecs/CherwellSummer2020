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

            for (int ix = 0; ix < row.Length; ix++)
            {
                for (int yx = 0; yx < column.Length; yx++)
                {
                    if (column[yx] % 2 != 0)
                    {
                        Triangles["" + row[ix] + column[yx]] = new Triangle(new int[] {x,y}, new int[] {x, y + 10}, new int[] {x + 10, y});
                        continue;
                    }
                    else
                    {
                        Triangles["" + row[ix] + column[yx]] = new Triangle(new int[] {x + 10,y + 10}, new int[] {x + 10, y}, new int[] {x, y + 10});
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
    }
}