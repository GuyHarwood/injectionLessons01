using ContactManager.Contacts;
using ContactManager.Web.Controllers;
using Core;
using Moq;
using NUnit.Framework;

namespace Web.Tests
{
	[TestFixture]
	public class ContactControllerTests
	{
		[Test]
		public void SomeTest()
		{
			var contactRepositoryMock = new Mock<IContactRepository>();
			var createContactHandlerMock = new Mock<ICommandHandler<CreateContactCommand>>();
			var sut = new ContactsController(contactRepositoryMock.Object, createContactHandlerMock.Object, new UnitOfWork(new Logger()));
			var result = sut.Index();
			Assert.IsNotNull(result);
		}

	    [Test]
	    public void theTest()
	    {
	        var sut = new ClosureController("sfkdsjfksdj");
            Assert.IsNotNull(sut);
	    }
	}
}