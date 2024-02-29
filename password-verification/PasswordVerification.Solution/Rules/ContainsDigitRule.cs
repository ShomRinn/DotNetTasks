using PasswordVerification.Solution.Interfaces;
using System;

namespace PasswordVerification.Solution.Rules
{
    public class ContainsDigitRule : IPasswordRule
    {
        public (bool, string) Validate(string password)
        {
            if (password.Any(char.IsDigit))
            {
                return (true, string.Empty);
            }

            return (false, "Password doesn't contain any digits");
        }
    }
}
