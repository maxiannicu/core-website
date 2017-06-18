using System;
using System.Collections.Generic;

namespace BlogApp.Exceptions
{
    public class CreateUserException : Exception
    {
        public CreateUserException()
        {
        }

        public IList<string> Errors { get; set; }
    }
}