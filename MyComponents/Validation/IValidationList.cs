using System.Collections.Generic;

namespace MyComponents.Validation
{
    public interface IValidationList
    {
        bool IsValid { get; }
        void Validate();
        IEnumerable<string> Messages { get; }
    }
}