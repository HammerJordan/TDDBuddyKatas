using System;

namespace HeavyMetalBakeSale.Kata
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException(string message) : base(message)
        {
        }
    }
}