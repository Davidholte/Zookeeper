using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Digital.Habitat.Api.Common.Exceptions;

namespace Digital.Habitat.Api.Common.Domain
{
    /// <summary>
    /// This is from Jimmy Bogard's blogpost about enumerations classes:
    /// https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/
    /// 
    /// It should be used to get rid of enums whenever logic could be added to the enum itself.
    /// </summary>
    // #warning [Serializable]
    [Serializable]
    public abstract class Enumeration : Value<Enumeration>
    {
        public int Value { get; }
        public string DisplayName { get; }

        protected Enumeration(int value, string displayName)
        {
            Value = value;
            DisplayName = displayName;
        }
        private Enumeration() { }

        public override string ToString()
        {
            return DisplayName;
        }

        #region Statics

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static T FromValue<T>(int value, bool throwExceptionIfInvalid = false) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);
            if (throwExceptionIfInvalid && matchingItem == null)
            {
                throw new InvalidEnumerationTypeException<T>(value);
            }
            return matchingItem;
        }

        public static T FromValueAllowNull<T>(int? value, bool throwExceptionIfInvalid = false) where T : Enumeration
        {
            if (value == null)
            {
                return null;
            }

            return FromValue<T>((int)value);
        }

        public static T FromDisplayName<T>(string displayName, bool throwExceptionIfInvalid = false) where T : Enumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName.Equals(displayName, StringComparison.InvariantCultureIgnoreCase));
            if (throwExceptionIfInvalid && matchingItem == null)
            {
                throw new InvalidEnumerationTypeException<T>(displayName);
            }
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName, T defaultImplementation) where T : Enumeration
        {
            return displayName != null ? FromDisplayName<T>(displayName) ?? defaultImplementation : defaultImplementation;
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        protected static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate, bool throwExceptionIfInvalid = false) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (throwExceptionIfInvalid && matchingItem == null)
            {
                var message = $"'{value}' is not a valid {description} in {typeof(T)}";
                throw new Exception(message);
            }

            return matchingItem;
        }

        #endregion

        #region Value implementation

        public override bool Equals(Enumeration other)
        {
            if (other == null)
            {
                return false;
            }
            return GetType() == other.GetType() && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return GetType().FullName.GetHashCode() + Value.GetHashCode();
        }

        public override int CompareTo(Enumeration other)
        {
            if (ReferenceEquals(other, null))
                return 1; // All instances are greater than null

            return Value.CompareTo(other.Value);
        }

        public override Enumeration Clone()
        {
            return (Enumeration)MemberwiseClone();
        }

        #endregion
    }
}
