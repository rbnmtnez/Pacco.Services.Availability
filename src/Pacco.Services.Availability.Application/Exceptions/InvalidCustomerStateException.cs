using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Application.Exceptions
{
    public class InvalidCustomerStateException : AppException
    {
        public InvalidCustomerStateException(Guid customerId, string state) 
            : base($"Customer with ID '{customerId}' has invalid state: '{state}'")
        {
        }
    }
}
