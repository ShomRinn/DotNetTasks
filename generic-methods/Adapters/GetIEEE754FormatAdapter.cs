using GenericMethodsTask.Interfaces;
using Ieee754FormatTask;

namespace Adapters
{
    /// <summary>
    /// GetIeee754FormatAdapter.
    /// </summary>
    public class GetIeee754FormatAdapter : ITransformer<double, string>
    {
        /// <summary>
        /// Method converts an object from one type to another type.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <returns>The TResult represents the converted TSource.</returns>
        public string Transform(double obj)
        {
            return obj.GetIEEE754Format();
        }
    }
}
