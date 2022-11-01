using System;
using System.Runtime.Serialization;

[Serializable]
internal class methodCallError : Exception
{
    public methodCallError()
    {
    }

    public methodCallError(string message) : base(message)
    {
    }

    public methodCallError(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected methodCallError(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}