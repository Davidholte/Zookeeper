using System;
using System.Linq;
using Digital.Habitat.Api.Common.Domain;

namespace Digital.Habitat.Api.Common.Exceptions
{
    [Serializable]
    public class InvalidEnumerationTypeException<T> : Exception where T : Enumeration
    {
        public InvalidEnumerationTypeException(string received) : base(
            $"Invalid Enumeration Type: {received}, Expected: {Enumeration.GetAll<T>().Select(e => e.DisplayName).ToList()}")
        {
        }

        public InvalidEnumerationTypeException(int received) : base(
            $"Invalid Enumeration Type: {received}, Expected: {Enumeration.GetAll<T>().Select(e => e.Value).ToList()}")
        {
        }
    }
}