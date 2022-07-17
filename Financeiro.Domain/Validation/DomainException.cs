using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.Domain.Validation
{
    public class DomainException : Exception
    {

        public DomainException(string error) : base(error)
        {}

        public static void When(bool hasError, string message)
        {
            if(hasError)
                throw new DomainException(message);
        }
        
    }
}