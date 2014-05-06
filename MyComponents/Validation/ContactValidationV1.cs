using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using MyComponents.Accounts;

namespace MyComponents.Validation
{
    public class ContactValidationV1
    {
        public void Validate(CreateContactCommand contact)
        {
            const int minimumJobDescriptionLength = 10;

            if (contact.JobDescription.Length < minimumJobDescriptionLength)
            {
                throw new ValidationException(string.Format("Job Description must be at least {0} characters long", minimumJobDescriptionLength));
            }

            if(string.IsNullOrWhiteSpace(contact.Name))
                throw new ValidationException("name is required");

            if(Guid.Empty.Equals(contact.ContactId))
                throw new ValidationException("ContactId has not been set by the client");
        }
    }
}
