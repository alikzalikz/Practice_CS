using System.Runtime.Serialization;

namespace Packt.Shared;

public class PersonException : Exception
{
    public PersonException() : base() { }
    public PersonException(string message) : base(message) { }
    public PersonException(string message, Exception innerException) : base(message, innerException) { }
}