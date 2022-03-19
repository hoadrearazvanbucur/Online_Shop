using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Exceptions
{
    public class OrderDetailException : Exception
    {
        public OrderDetailException(string message) : base(message) { }

    }
}
