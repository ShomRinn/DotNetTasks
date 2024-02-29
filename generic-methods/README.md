# Generics Methods
 
## Task Description

* Implement generic methods of the class [ArrayExtension](/GenericMethodsTask/ArrayExtension.cs). The task definitions are given in the  XML-comments for each method.
* Put implementation into the [DoubleExtension](/Ieee754FormatTask/DoubleExtension.cs) class of the `IEEE754FormatTask` project: take a solution of the task 
    <details><summary>IEEE 754 format.</summary>        
    Implement the [GetIeee754Format](/Ieee754FormatTask/DoubleExtension.cs#L13) method that obtains a binary representation of a real double-precision number in IEEE754 format as the extension method. Don't use Framework's converter classes. The task definition is given in the  XML-comments for this method.        
    Hint:  Use C# structs to create a union type (similar to C unions).
    </details>      
* Put implementation into the [ContainsDigitValidator](/ContainsDigitPredicate/ContainsDigitValidator.cs#L3) of the [ContainsDigitPredicate](/ContainsDigitPredicate) project: take a solution of the task 
    <details><summary>Contains digit number.</summary>        
    Given a natural number. Implement a method [Verify](/ContainsDigitPredicate/ContainsDigitValidator.cs#L11) that determines whether a given number contains a given digit or not. Don't use string and array classes.
    </details>
* Put into the [Adapters](/Adapters/) project the [GetIEEE754FormatAdapter](/Adapters/GetIEEE754FormatAdapter.cs#L5) adapter class for [DoubleExtension](IEEE754FormatTask/DoubleExtension.cs#L13) that implement the required interfaces.
* Put into the [Adapters](/Adapters/) project the [ContainsDigitPredicateAdapter](/Adapters/ContainsDigitPredicateAdapter.cs#L6) adapter class for [ContainsDigitValidator](/ContainsDigitPredicate/ContainsDigitValidator.cs#L3) that implement the required interfaces. 
* Explore [unit](/GenericMethodsTask.Tests/NUnitTests) and [mock](/GenericMethodsTask.Tests/MoqTests) tests.

## Additional Materials

Feel welcome to check out a set of supplementary articles from C# Programming Guide: 

- [C# extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) 
- [Math.Abs method](https://docs.microsoft.com/en-us/dotnet/api/system.math.abs?view=net-5.0) 

### C# reference  

* [ArgumentNullException class](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-5.0#:~:text=An%20ArgumentNullException%20exception%20is%20thrown,but%20should%20never%20be%20null%20.&text=An%20object%20returned%20from%20a,original%20returned%20object%20is%20null%20.) 
* [ArgumentException class ](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-5.0)
