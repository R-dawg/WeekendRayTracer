using System;
using System.IO;

namespace WeekendRayTracer
{
    public class Program
    {
        public static void Main()
        {
            int nx = 200;
            int ny = 100;
            StreamWriter ppmFile = new StreamWriter("trace.ppm");

            ppmFile.Write("P3\n {0} {1}\n255\n", nx, ny);
            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    float r = (float)i / (float)nx;
                    float g = (float)j / (float)ny;
                    float b = 0.2f;
                    int ir = (int)(255.99 * r);
                    int ig = (int)(255.99 * g);
                    int ib = (int)(255.99 * b);

                    ppmFile.Write("{0} {1} {2}\n", ir, ig, ib);
                }
            }
            ppmFile.Close();
        }
    }
}
