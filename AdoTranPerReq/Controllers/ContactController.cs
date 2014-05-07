using System;
using System.Web.Mvc;
using ContactManager.Contacts;
using ContactManager.Web.Models;
using Core;

namespace ContactManager.Web.Controllers
{
	public class ContactsController : Controller
	{
		private readonly IContactRepository contactRepository;
		private readonly ICommandHandler<CreateContactCommand> createContactHandler;
		private readonly UnitOfWork unitOfWork;

		public ContactsController(IContactRepository contactRepository, ICommandHandler<CreateContactCommand> createContactHandler, UnitOfWork unitOfWork)
		{
			this.contactRepository = contactRepository;
			this.createContactHandler = createContactHandler;
			this.unitOfWork = unitOfWork;
		}

		public ActionResult Index()
		{
			var contacts = contactRepository.GetContacts();
			var model = new ContactIndexModel()
			{
				Contacts = contacts
			};
			return View(model);
		}

		public ActionResult Create()
		{
			return View(new ContactCreateModel());
		}

		[HttpPost]
		public ActionResult Create(ContactCreateModel model)
		{
			var command = new CreateContactCommand()
			{
				ContactId = Guid.NewGuid(),
				Name = model.Name
			};
			createContactHandler.Handle(command);

			return RedirectToAction("Index");
		}
	}
}