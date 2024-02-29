## Password verification.

The program currently has a type system in place that verifies passwords according to certain rules and saves valid passwords in a storage location. The storage location is fixed and the rules for verifying passwords are predetermined.

The task is to restructure the code so that it is easy to use different types of storage locations and various combinations of new and existing rules for password verification - the result is acceptable if adding a new validator or type for saving doesn't require making any changes in `PasswordVerification.PasswordCheckerService` file. The new code should be in the `PasswordVerification.Solution` project.

Optionally: the code can be tested using unit tests. These tests should be placed in the `PasswordVerification.Solution.Tests` project.
