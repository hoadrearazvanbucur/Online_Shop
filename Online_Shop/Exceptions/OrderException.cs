using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }

    }
}
