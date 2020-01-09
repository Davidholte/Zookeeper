using System;

namespace Digital.Habitat.Api.Common.Models
{
    public class CustomContract
    {
        public static void Requires<TException>(bool predicate, string message)
            where TException : Exception, new()
        {
            if (!predicate)
            {
                var ctor = typeof(TException).GetConstructor(new[] { typeof(string) });
                if (ctor != null)
                {
                    throw (TException)ctor.Invoke(new object[] { message });
                }
                throw new TException();
            }
        }
    }
}