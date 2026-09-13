using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBalance.Domain.Exceptions;

public class ForbiddenException : Exception
{
    public ForbiddenException() { }
    public ForbiddenException(string message) : base(message) { }
    public ForbiddenException(string message, Exception innerException) : base(message, innerException) { }
}
