using System;
using System.Runtime.Serialization;

[Serializable]
public class NotFoundException : Exception
{
  private int idNote;

  public NotFoundException()
  {
  }

  public NotFoundException(string? message) : base(message)
  {
  }

  public NotFoundException(string v, int idNote) : base($"The {v} with Id: {idNote} is not found")
  {
    this.idNote = idNote;
  }

  public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
  {
  }

  protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }
}
