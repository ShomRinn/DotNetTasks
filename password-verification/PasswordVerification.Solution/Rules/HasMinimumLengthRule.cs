using PasswordVerification.Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerification.Solution.Rules
{
    public class HasMinimumLengthRule : IPasswordRule
    {
        public (bool, string) Validate(string password)
        {
            if (password.Length > 7)
            {
                return (true, string.Empty);
            }

            return (false, "Password length too short");
        }
    }
}
