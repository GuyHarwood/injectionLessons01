using System;
using Core.Validation;

namespace ContactManager.Contacts.Validation
{
	public class ContactIdValidation : ValidationBase<CreateContactCommand>
	{
		public ContactIdValidation(CreateContactCommand context) : base(context)
		{}

		public override bool IsValid
		{
			get { return !Guid.Empty.Equals(Context.ContactId); }
		}

		public override string Message
		{
			get { return "ContactId has not been initialised"; }
		}
	}
}