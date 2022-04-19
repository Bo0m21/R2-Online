using Microsoft.EntityFrameworkCore;
using Packets.Core.Utilities;
using System;

namespace Packets.Server.Game.Structures
{
    [Owned]
    public class Vector3 : IEquatable<Vector3>
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float Length => Distance(new Vector3());
        public Vector3 Normalized => this / Length;

        public Vector3(Vector3 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3()
        {
        }

        public void Read(FormationPackage formationPackage)
        {
            X = formationPackage.ReadFloat();
            Z = formationPackage.ReadFloat();
            Y = formationPackage.ReadFloat();
        }

        public void Write(FormationPackage formationPackage)
        {
            formationPackage.AddFloat(X);
            formationPackage.AddFloat(Z);
            formationPackage.AddFloat(Y);
        }

        public float Distance(Vector3 position)
        {
            return (float)Math.Sqrt((X - position.X) * (X - position.X) + (Y - position.Y) * (Y - position.Y) + (Z - position.Z) * (Z - position.Z));
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3 operator *(Vector3 a, double c) => a * (float)c;
        public static Vector3 operator *(Vector3 a, float c)
        {
            return new Vector3(a.X * c, a.Y * c, a.Z * c);
        }

        public static Vector3 operator /(Vector3 a, float c)
        {
            return new Vector3(a.X / c, a.Y / c, a.Z / c);
        }

        public bool Equals(Vector3 other)
        {
            if (other == null)
            {
                return false;
            }

            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override string ToString()
        {
            return $"{{ {X}; {Y}; {Z} }}";
        }
    }
}
