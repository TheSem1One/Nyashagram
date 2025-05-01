using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException() : base("Bad Request try something else ")
        {
        }
    }
}
