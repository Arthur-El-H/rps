using System;
using System.Runtime.Serialization;

[Serializable]
internal class ActionNotFinishedException : Exception
{
    public ActionNotFinishedException()
    {
    }

    public ActionNotFinishedException(string message) : base(message)
    {
    }

    public ActionNotFinishedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ActionNotFinishedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}