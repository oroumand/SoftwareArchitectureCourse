using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Framework.Domain;

public class DomainValidationException : Exception
{
    public DomainValidationException()
    {
    }

    public DomainValidationException(string? message) : base(message)
    {
    }

    public DomainValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DomainValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
