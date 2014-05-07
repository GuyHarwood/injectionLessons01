using System.Collections.Generic;

namespace Core.Validation
{
    public interface IValidationList
    {
        bool IsValid { get; }
        void Validate();
        IEnumerable<string> Messages { get; }
    }
}