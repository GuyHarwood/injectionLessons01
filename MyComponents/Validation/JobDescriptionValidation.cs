using MyComponents.Accounts;

namespace MyComponents.Validation
{
    public class JobDescriptionValidation : ValidationBase<CreateContactCommand>
    {
        private const int MinimumLength = 10;
 
        public JobDescriptionValidation(CreateContactCommand context)
            : base(context)
        {}
 
        public override bool IsValid
        {
            get { return !string.IsNullOrWhiteSpace(Context.JobDescription) && 
                         Context.JobDescription.Length >= MinimumLength; }
        }
 
        public override string Message
        {
            get
            {
                return string.Format(
                    "Contact {0} is not valid for storage because its JobDescription length is null or less than {1} ",
                    Context.Name, MinimumLength);
            }
        }
    }
}