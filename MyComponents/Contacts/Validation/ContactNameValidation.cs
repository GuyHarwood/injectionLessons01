using Core.Validation;

namespace ContactManager.Contacts.Validation
{
	public class ContactNameValidation : ValidationBase<CreateContactCommand>
	{
		private const int MinimumLength = 3;

		public ContactNameValidation(CreateContactCommand context)
			: base(context)
		{ }

		public override bool IsValid
		{
			get
			{
				return !string.IsNullOrWhiteSpace(Context.Name) &&
					   Context.Name.Length >= MinimumLength;
			}
		}

		public override string Message
		{
			get
			{
				return string.Format("Name must be at least {0} characters in length", MinimumLength);
			}
		}
	}
}