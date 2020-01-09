using System;

namespace Digital.Habitat.Api.Domain.Common
{
    public interface IIdentity<out T>
    {
        T Id { get; }
    }
    
    [Serializable]
    public abstract class Identity<TKeyType, T> : Value<T>, IIdentity<TKeyType>
        where T : Identity<TKeyType, T>
        where TKeyType : IComparable
    {
        public abstract TKeyType Id { get; }

        public override string ToString()
        {
            return $"{GetType().FullName.Replace("Id", "")}-{Id}";
        }

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

        public override T Clone()
        {
            return (T)MemberwiseClone();
        }
    }

}
