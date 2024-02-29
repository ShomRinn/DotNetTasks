using PasswordVerification.Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerification.Solution.Rules
{
    public class PasswordNotEmptyRule : IPasswordRule
    {
        public (bool, string) Validate(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                return (true, string.Empty);
            }

            return (false, "Password is empty");
        }
    }
}
