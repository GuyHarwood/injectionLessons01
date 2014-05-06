using System;

namespace MyComponents.Validation
{
    public abstract class ValidationBase<T> : IValidation where T : class
    {
        protected T Context { get; private set; }

        protected ValidationBase(T context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.Context = context;
        }

        public void Validate()
        {
            if (!this.IsValid)
            {
                throw new ValidationException(this.Message);
            }
        }

        public abstract bool IsValid { get; }
        public abstract string Message { get; }
    }
}