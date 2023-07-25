using System;
using System.Runtime.Serialization;

[Serializable]
public class NotFoundException : Exception
{
    private int id;

    public NotFoundException()
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException(string v, int id) : base($"The {v} with Id: {id} is not found")
    {
        this.id = id;
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
