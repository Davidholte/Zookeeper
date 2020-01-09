using System;

namespace Digital.Habitat.Api.Common.Domain
{
    [Serializable]
    public abstract class Value<T> : IComparable, IComparable<T>, IEquatable<T>, ICloneable where T : Value<T>
    {
        public override bool Equals(object obj)
        {
            var otherValue = obj as T;
            return otherValue != null && Equals(otherValue);
        }

        public abstract bool Equals(T other);

        public abstract override int GetHashCode();

        public virtual int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                return 1; // All instances are greater than null

            var otherValue = obj as T;
            if (otherValue == null)
            {
                throw new ArgumentException($"The comparing type must be '{GetType()}'", nameof(obj));
            }
            return CompareTo(otherValue);
        }

        public abstract int CompareTo(T other);

        public abstract T Clone();

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static bool operator ==(Value<T> a, Value<T> b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Value<T> a, Value<T> b)
        {
            return !(a == b);
        }

        public static bool operator >(Value<T> a, Value<T> b)
        {
            if (ReferenceEquals(a, null))
            {
                return false; // All instances are greater than null
            }
            if (ReferenceEquals(b, null))
            {
                return true; // All instances are greater than null
            }
            return a.CompareTo(b) > 0;
        }

        public static bool operator >=(Value<T> a, Value<T> b)
        {
            return a == b || a > b;
        }

        public static bool operator <(Value<T> a, Value<T> b)
        {
            if (ReferenceEquals(a, null))
            {
                return true; // All instances are greater than null
            }
            if (ReferenceEquals(b, null))
            {
                return false; // All instances are greater than null
            }
            return a.CompareTo(b) < 0;
        }

        public static bool operator <=(Value<T> a, Value<T> b)
        {
            return a == b || a < b;
        }
    }
}
