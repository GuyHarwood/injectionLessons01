using System;
using Core.Validation;

namespace ContactManager.Contacts.Validation
{
    public class ContactValidator
    {
        public void Validate(CreateContactCommand contact)
        {
            const int minimumDescriptionLength = 10;

			if (Guid.Empty.Equals(contact.ContactId))
				throw new ValidationException("ContactId has not been set by the client");

			if (string.IsNullOrWhiteSpace(contact.Name))
				throw new ValidationException("name is required");

            if (contact.Name.Length < minimumDescriptionLength)
            {
                throw new ValidationException(string.Format("Description must be at least {0} characters long", minimumDescriptionLength));
            }
        }
    }
}
