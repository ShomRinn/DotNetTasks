using PasswordVerification.Solution.Interfaces;
using PasswordVerification.Solution.Repositories;
using System;
using System.Linq;

namespace PasswordVerification.Solution.Services
{
    public class PasswordCheckerService
    {
        private readonly IRepository repository;
        private readonly List<IPasswordRule> passwordRules;

        public PasswordCheckerService(IRepository repository, List<IPasswordRule> passwordRules)
        {
            this.repository = repository;
            this.passwordRules = passwordRules;
        }

        public (bool, string) VerifyPassword(string password)
        {
            foreach (var rule in passwordRules)
            {
                (bool isValid, string errorMessage) = rule.Validate(password);

                if (!isValid)
                {
                    return (isValid, errorMessage);
                }
            }

            this.repository.Create(password);

            return (true, "Password is Ok. User was created");
        }
    }
}
