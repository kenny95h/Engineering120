using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;
using System.Collections.Generic;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;
        //Fakes - In memory database (not covered)

        #region Moq as Dummy
        [Ignore("Failed due to null value")]
        [Test]
        public void BeAbleToBeConstructed()
        {
            //Act
            _sut = new CustomerManager(null);
            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        [Test]
        public void BeAbleToBeConstructed_WithMoq()
        {
            //Use Moq to create a dummy object which implements ICustomerService
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            //Act - retrieve ICustomerService object associated with that Mock
            //Mock.Object - No functionality
            _sut = new CustomerManager(mockCustomerService.Object);
            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        #endregion

        #region Stubs
        // Need to create a test double for implementing ICustomerService interface
        // THEN configure to return desired values
        [Test]
        public void ReturnTrue_WhenUpdateIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA"
            };

            // Set up service to return what we want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Update("MANDA", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.That(result);
        }
        [Test]
        public void NotChangeTheSelectedCustomer_WhenUpdateIsCalled_WithInvalidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };

            // Set up service to return what we want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns((Customer)null);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = customer;
            var result = _sut.Update("MANDA", "Nishant Mandal", "UK", "London", null);

            //Assert
            Assert.That(!result);
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
        }



        [Test]
        public void ReturnTrue_WhenDeleteIsCalledWithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA"
            };

            // Set up service to return what we want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Delete("MANDA");

            //Assert
            Assert.That(result);
        }

        [Test]
        public void SetSelectedCustomerToNull_WhenDeleteIsCalledWithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA"
            };

            // Set up service to return what we want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Delete("MANDA");

            //Assert
            Assert.That(_sut.SelectedCustomer, Is.Null);
        }

        [Test]
        public void ReturnFalse_WhenDeleteIsCalled_WithInvalidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA"
            };

            // Set up service to return what we want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns((Customer)null);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Delete("MANDA");

            //Assert
            Assert.That(!result);
        }

        [Test]
        public void NotChangeTheSelectedCustomer_WhenDeleteIsCalled_WithInvalidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };

            // Set up service to return what we want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns((Customer)null);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = customer;
            var result = _sut.Delete("MANDA");

            //Assert
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
        }
        #endregion

        #region Testing Exceptions

        [Test]
        public void ReturnsFalse_WhenUpdateIsCalled_AndADatabaseExceptionIsThrown()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();
            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Update("Wolst", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That(!result);

        }

        [Test]
        public void NotChangeTheSelectedCustomer_WhenUpdateIsCalled_AndADatabaseExceptionIsThrown()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            //mocks the exception during savecustomerchanges
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();

            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = customer;

            //Act
            _sut.Update("MANDA", "Nishant Mandal", null, "Birmingham", null);

            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));

        }
        #endregion

        #region Behaviour-based testing
        [Test]
        public void CallSaveCustomerChanges_WhenUpdateIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Update("WOLST", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // Calling the update method in the CustomerManager class, called the SavesCustomer method once
            //Assert - verify a method has been called once
            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Once);
        }

        [Test]
        public void Behaviours_LooseVsStrict()
        {
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            //Strict means we need to mock all methods under test
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges());
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Update("WOLST", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That(result);
        }

        #endregion



        #region Homework
        [Test]
        public void WhenRetrieveAllIsCalled_ReturnsAllCustomers()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA"
            };

            var customer1 = new Customer
            {
                CustomerId = "WITTE"
            };
            var custList = new List<Customer> { customer, customer1 };

            // Set up service to return what we want
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(custList);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.RetrieveAll();

            //Assert
            Assert.That(result, Contains.Item(customer));
            Assert.That(result, Contains.Item(customer1));

        }

        [Test]
        public void WhenSetSelectedCustomerIsCalled_ReturnCustomer()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            object obj = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };


            //mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA"));

            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SetSelectedCustomer(obj);

            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));

        }

        [Test]
        public void CallRemoveCustomer_WhenDeleteIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer
            {
                CustomerId = "MANDA"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Delete("MANDA");

            //Assert - verify a method has been called once
            mockCustomerService.Verify(cs => cs.RemoveCustomer(customer), Times.Once);

            
        }

        [Test]
        public void CallCreateCustomer_WhenCreateIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
            };
            //mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            //_sut.Create("MANDA", "Nish Mandal", "Sparta Global");
            _sut.Create(customer.CustomerId, customer.ContactName, customer.CompanyName);

            //Assert - verify a method has been called once
            mockCustomerService.Verify(cs => cs.CreateCustomer(It.IsAny<Customer>()), Times.Once);

        }

        #endregion
    }
}

