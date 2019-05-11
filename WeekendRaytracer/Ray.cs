
using System;
using System.Numerics;

namespace WeekendRaytracer
{
	/// <summary>
	/// Ray of light
	/// </summary>
    public class Ray
    {
		public Vector3 A;
		public Vector3 B;

        public Ray()
        {			
        }

		/// <summary>
		/// Ray of light
		/// </summary>
		/// <param name="a">origin of the light</param>
		/// <param name="b">direction the light is traveling</param>
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
