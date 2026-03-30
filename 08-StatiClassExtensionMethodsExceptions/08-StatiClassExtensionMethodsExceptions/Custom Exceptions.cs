using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions
{
    using System;

    // Username Exception
    class InvalidUsernameException : Exception
    {
        public InvalidUsernameException() : base("Username is invalid!") { }

        public InvalidUsernameException(string message) : base(message) { }
    }

    // Password Exception
    class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("Password is invalid!") { }

        public InvalidPasswordException(string message) : base(message) { }
    }

    // User Not Found
    class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found!") { }

        public UserNotFoundException(string username)
            : base($"User '{username}' not found!") { }
    }


    class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; set; }

        public IncorrectPasswordException(int attemptsLeft)
            : base($"Incorrect password! Attempts left: {attemptsLeft}")
        {
            AttemptsLeft = attemptsLeft;
        }
    }


    class AccountLockedException : Exception
    {
        public AccountLockedException() : base("Account is locked!") { }
    }
}
