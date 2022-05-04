using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoGoalsException : Exception
{
    public NoGoalsException()
    {
    }

    public NoGoalsException(string message) : base(message)
    {
    }

    public NoGoalsException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoGoalsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}