using System;

namespace PasswordVerification.Solution.Interfaces
{
    public interface IPasswordRule
    {
        (bool, string) Validate(string password);
    }

}
