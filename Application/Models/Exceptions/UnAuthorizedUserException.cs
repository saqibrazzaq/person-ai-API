﻿namespace Application.Models.Exceptions
{
  public class UnAuthorizedUserException : Exception
  {
    public UnAuthorizedUserException(string message) : base(message)
    {

    }
  }
}
