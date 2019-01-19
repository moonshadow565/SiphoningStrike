using System;
namespace SiphoningStrike
{
    static class Utility
    {
        public static T[] Array<T>(int count)
            where T : new()
        {
            var result = new T[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = new T();
            }
            return result;
        }
    }
}
