﻿namespace Idea.Youla.Exceptions;

public class YoulaHttpApiClientException : Exception
{
    public YoulaHttpApiClientException(string message) : base(message)
    {
    }
}