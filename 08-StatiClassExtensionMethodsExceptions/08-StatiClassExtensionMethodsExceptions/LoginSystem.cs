using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions
{
    class LoginSystem
    {
        private User[] users;
        private const int MaxAttempts = 3;

        public LoginSystem()
        {
            users = new User[]
            {
            new User("Huseyn", "huseyn2006"),
            new User("Rauf", "rauf1234"),
            new User("Fuad", "fuad1234")
            };
        }

        public void ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 3)
                throw new InvalidUsernameException();
        }

        public void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                throw new InvalidPasswordException();
        }

        private User FindUser(string username)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Username.ToLower() == username.ToLower())
                    return users[i];
            }
            return null;
        }

        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);

            User user = FindUser(username);

            if (user == null)
                throw new UserNotFoundException(username);

            if (user.IsLocked)
                throw new AccountLockedException();

            if (user.Password == password)
            {
                user.FailedAttempts = 0;
                Console.WriteLine($"Login successful! Welcome, {username}!");
                return true;
            }
            else
            {
                user.FailedAttempts++;

                int attemptsLeft = MaxAttempts - user.FailedAttempts;

                if (attemptsLeft > 0)
                    throw new IncorrectPasswordException(attemptsLeft);
                else
                {
                    user.IsLocked = true;
                    throw new AccountLockedException();
                }
            }
        }

        // Mövcud userləri göstərmək üçün
        public void ShowUsers()
        {
            Console.WriteLine("Available users:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}
