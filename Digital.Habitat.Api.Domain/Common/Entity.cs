using System;

namespace Digital.Habitat.Api.Domain.Common
{
    [Serializable]
    public abstract class Entity<TKeyType, T> : Value<T>
        where T : Entity<TKeyType, T>
        where TKeyType : IComparable
    {

        public abstract TKeyType Id { get; }

        public override bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            return GetType() == other.GetType() && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return GetType().FullName.GetHashCode() + Id.GetHashCode();
        }

        public override int CompareTo(T other)
        {
            return ReferenceEquals(other, null) ? 1 : Id.CompareTo(other.Id);
        }

        public abstract override T Clone();
    }
}