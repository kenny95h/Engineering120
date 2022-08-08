# Week 7: 08/08 - 12/08

**1.** [Monday](##1. Monday) - Moq

**2.** [Tuesday](##2. Tuesday) - BDD & HTTP/CSS

**3.** [Wednesday](##3. Wednesday) - 

**4.** [Thursday](##4. Thursday) - 

**5.** [Friday](##5. Friday) - 

## 1. Monday

### Moq

* **Partial class** - can write a class in 2 separate files. At compile time, they are treated as one class

* Unit testing databases violates four of the FIRST principles of testing:
  
  * **Fast** - database queries are slow
  
  * **Isolated** - they rely on access to information in a database so cannot be independent
  
  * **Repeatable** - live databases are constantly changed so cannot rely on the data to be valid
  
  * **Timely** - Need to wait for the full database, and tests are difficult to write

* **Test doubles** - the production object is replaced by another for testing purposes:
  
  * **Dummy** - Non-functional filler object
  
  * **Fake** - Object with working implementation, but not suitable for production (InMemoryDatabase)
  
  * **Stubs** - provides set responses for calls made in the test
  
  * **Spies** - stubs that record some information based on how they are called - used on behaviour based testing
  
  * **Mocks** - verify method calls and execption handling

* **Moq** is used to construct our test objects.

* Creating a dummy object (No functionality):
  
  * ```csharp
    var mockCustomerService = new Mock<ICustomerService>();
    //Expose mock object associated with the mock
    _sut = new CustomerManager(mockCustomerService.Object);
    ```

* Creating a stub:
  
  * ```csharp
    //Create the mock object first
    var mockCustomerService = new Mock<ICustomerService>();
    var customer = new Customer
    {
    CustomerId = "MANDA"
    };
    // Set up service to return what we want
    mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);
    // Passes through the mock object with stub (specified results)
    _sut = new CustomerManager(mockCustomerService.Object);
    var result = _sut.Update("MANDA", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
    Assert.That(result);
    ```

* Moq has a method `It.IsAny<datatype>` which is used when the variable does not matter. Used as fillers

* **State based testing** - the final state the system is in after a specified action

* Testing exceptions using a mock (normally when a database has been changed since last access):
  
  * ```csharp
    //Arrange
    var mockCustomerService = new Mock<ICustomerService>();
    mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
    //mocks the exception during savecustomerchanges
    mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();
    _sut = new CustomerManager(mockCustomerService.Object);
    //Act
    var result = _sut.Update("Wolst", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
    Assert.That(!result);
    ```

* **Behaviour based testing** - testing that methods have been called - use a mock to `Verify` the method has been called with the `Times` method:
  
  * ```csharp
    //Arrange
    var mockCustomerService = new Mock<ICustomerService>();
    mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
    //Act
    var result = _sut.Update("WOLST", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
    //Assert
    mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Once);
    ```

* The default convention of the **MockBehaviour** with a parameterless constructor is `Loose`.

* `Strict` - all methods within the method under test must have behaviour set up - makes it more thorough, but they are then made more brittle:
  
  * ```csharp
    var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
    ```



## 2. Tuesday

## 3. Wednesday

## 4. Thursday

## 5. Friday
