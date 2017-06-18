using System;
using System.Collections.Generic;

namespace BlogApp.Exceptions
{
    public class SignInUserException : Exception
    {
        public SignInUserException()
        {
        }

        public IList<string> Errors { get; set; }
    }
}