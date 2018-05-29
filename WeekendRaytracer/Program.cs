using System;
using System.IO;
using System.Numerics;
using WeekendRaytracer;

namespace WeekendRayTracer
{
    public class Program
    {
		public static float hitSphere(Vector3 center, float radius, Ray r)
        {         
			Vector3 oc = r.origin() - center;
            float a = Vector3.Dot(r.direction(), r.direction());
            float b = 2.0f * Vector3.Dot(r.direction(),oc);
            float c = Vector3.Dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            
			if (discriminant < 0)
				return -1.0f;
			else
				return (-b - (float)Math.Sqrt(discriminant)) / (2.0f * a);
        }
        
		public static Vector3 color(Ray r)
		{
			float t = hitSphere(new Vector3(0.0f, 0.0f, -1.0f), 0.5f, r);
			if(t > 0.0f)
			{
				Vector3 N = r.point_at_parameter(t) / r.point_at_parameter(t).Length()
				             - new Vector3(0,0,-1);
				return 0.5f * new Vector3(N.X + 1, N.Y + 1, N.Z + 1);
			}
            
			Vector3 unitDirection = r.direction() / r.direction().Length();
			t = 0.5f * (unitDirection.Y + 1.0f);
			return Vector3.Lerp(new Vector3(1.0f), new Vector3(0.5f, 0.7f, 1.0f), t);
		}

        public static void Main()
        {
            int nx = 200;
            int ny = 100;
            StreamWriter ppmFile = new StreamWriter("trace.ppm");
            
            ppmFile.Write("P3\n {0} {1}\n255\n", nx, ny);

			Vector3 lower_left_corner = new Vector3(-2.0f, -1.0f, -1.0f);
			Vector3 horizontal = new Vector3(4.0f, 0.0f, 0.0f);
			Vector3 vertical = new Vector3(0.0f, 2.0f, 0.0f);
			Vector3 origin = new Vector3(0.0f);

            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    float u = (float)i / (float)nx;
                    float v = (float)j / (float)ny;
					Ray r = new Ray(origin, lower_left_corner + u*horizontal + v*vertical);
					Vector3 col = color(r);
                    int ir = (int)(255.99 * col.X);
                    int ig = (int)(255.99 * col.Y);
                    int ib = (int)(255.99 * col.Z);

                    ppmFile.Write("{0} {1} {2}\n", ir, ig, ib);
                }
            }
            ppmFile.Close();
        }
    }
}
