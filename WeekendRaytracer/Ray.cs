
using System;
using System.Numerics;

namespace WeekendRaytracer
{
    public class Ray
    {
		public Vector3 A;
		public Vector3 B;

        public Ray()
        {			
        }

        public Ray(Vector3 a, Vector3 b)
		{
			A = a;
			B = b;
		}

        public Vector3 origin()
		{
			return A;
		}

        public Vector3 direction()
		{
			return B;
		}

        public Vector3 point_at_parameter(float t)
		{
			return A + t * B;
		}
    }
}
