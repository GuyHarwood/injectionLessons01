
using MyComponents.Validation;

namespace MyComponents.Contacts.Validation
{
    public class ContactDescriptionValidation : ValidationBase<CreateContactCommand>
    {
        private const int MinimumLength = 10;
 
        public ContactDescriptionValidation(CreateContactCommand context)
            : base(context)
        {}
 
        public override bool IsValid
        {
            get { return !string.IsNullOrWhiteSpace(Context.Description) && 
                         Context.Description.Length >= MinimumLength; }
        }
 
        public override string Message
        {
            get
            {
                return string.Format("Description length is null or less than {0} ",MinimumLength);
            }
        }
    }
}