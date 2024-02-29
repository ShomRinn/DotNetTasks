using PasswordVerification.Solution.Interfaces;
using System;

namespace PasswordVerification.Solution.Rules
{
    public class ContainsLetterRule : IPasswordRule
    {
        public (bool, string) Validate(string password)
        {
            if (password.Any(char.IsLetter))
            {
                return (true, string.Empty);
            }

            return (false, "Password doesn't contain any alphabetical characters");
        }
    }
}
