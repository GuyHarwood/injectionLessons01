using System;
using MyComponents.Validation;

namespace MyComponents.Contacts.Validation
{
    public class ContactValidator
    {
        public void Validate(CreateContactCommand contact)
        {
            const int minimumDescriptionLength = 10;

            if (contact.Description.Length < minimumDescriptionLength)
            {
                throw new ValidationException(string.Format("Description must be at least {0} characters long", minimumDescriptionLength));
            }

            if(string.IsNullOrWhiteSpace(contact.Name))
                throw new ValidationException("name is required");

            if(Guid.Empty.Equals(contact.ContactId))
                throw new ValidationException("ContactId has not been set by the client");
        }
    }
}
