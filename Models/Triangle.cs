namespace TriangleApi.Models
{
    public class Triangle
    {
        private int[] Vertex1 {get;}
        private int[] Vertex2 {get;}
        private int[] Vertex3 {get;}

        public Triangle(int[] v1, int[] v2, int[] v3)
        {
            Vertex1 = v1;
            Vertex2 = v2;
            Vertex3 = v3;
        }

        public bool FitCoordinates(int[] v1, int[] v2, int[] v3)
        {
            if (Vertex1[0] != v1[0] || Vertex1[1] != v1[1])
            {
                return false;
            }

            if (Vertex2[0] != v2[0] || Vertex2[1] != v2[1])
            {
                return false;
            }

            if (Vertex3[0] != v3[0] || Vertex3[1] != v3[1])
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string VERTEX1_STR = $"Vertex 1: ({Vertex1[0]}, {Vertex1[1]})\n";
            string VERTEX2_STR = $"Vertex 2: ({Vertex2[0]}, {Vertex2[1]})\n";
            string VERTEX3_STR = $"Vertex 3: ({Vertex3[0]}, {Vertex3[1]})\n";
            return VERTEX1_STR + VERTEX2_STR + VERTEX3_STR;
        }
    }
}