﻿using System;
using System.Dynamic;

namespace MathLibrary
{
    public class Vector2
    {
        private float _x;
        private float _y;


        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public Vector2()
        {
            _x = 0;
            _y = 0;
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
        public static float FindAngle(Vector2 lhs, Vector2 rhs)
        {
            lhs = lhs.Normalized;
            rhs = rhs.Normalized;

            float dotProd = Vector2.DotProduct(lhs, rhs);

            if (Math.Abs(dotProd) > 1)
                return 0;

            float angle = (float)Math.Acos(dotProd);

            Vector2 perp = new Vector2(rhs.Y, -rhs.X);

            float perpDot = Vector2.DotProduct(perp, lhs);

            if (perpDot != 0)
                angle *= perpDot / Math.Abs(perpDot);

            return angle;
        }

        public static float Distance(Vector2 lhs, Vector2 rhs)
        {
            float XSqr = (lhs.X - rhs.X) * (lhs.X - rhs.X);
            float YSqr = (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y);
            return (float)Math.Sqrt(XSqr + YSqr);
        }
        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }
        public Vector2 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }
        public float DRange
        {
            get
            {
                return Distance(this, this);
            }
        }


        /// <summary>
        /// returns the normalized version of the vector passed in
        /// </summary>
        /// <param name="vector">The vector that will be normal </param>
        /// <returns></returns>
        public static Vector2 Normalize(Vector2 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector2();

            return vector / vector.Magnitude;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }
        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X * scalar, lhs.Y * scalar);
        }
        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X / scalar, lhs.Y / scalar);
        }
    }
}