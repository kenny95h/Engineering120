# Week 7: 08/08 - 12/08

**1.** [Monday](##1. Monday) - Moq

**2.** [Tuesday](##2. Tuesday) - HTTP/CSS

**3.** [Wednesday](##3. Wednesday) - Testing Web Apps & Automation Testing

**4.** [Thursday](##4. Thursday) - BDD & SpecFlow

**5.** [Friday](##5. Friday) - Continuous Intergration

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

### HTML & CSS

* **H**yper**T**ext **M**arkup **L**anguage

* **C**ascading **S**tyle **S**heets - describes the presentation of a document

* **Document Object Model** - a tree structure of what the html will look like - allows us to treat it as an object

* `<!DOCTYPE html>` - information to the browser about what document type to expect

* The `<head>` contains meta declarations, as attributes, about technical data about the html doc:
  
  * ```html
    <meta charset=”utf-8” />
    <meta name=”author” content=”A. Trainee” />
    ```

* The `<body>` contains the content of the web page:
  
  * ```html
    <h1>header</h1> <-- up to h6, descending in size -->
        <p>paragraph</p> <-- paragraph for text -->
        <strong>bold text</strong>
        <em>italics</em>
        <ol> <-- ordered list, includes list elements. ul for unordered list -->
            <li>list element</li>
        </ol>
        <a href=”link”>A hyperlink</a>
    ```

* `<div>` is a non-semantic element that doesn't render anything but provides meaning to the webpage

* `<nav>` is used to contain the navigation elements

* `<header>` contains the title information to display

* **CSS** is a style code that is interpreted by the browser
  
  * Browser document first
  
  * The header style tags
  
  * The in-line tags

* Selectors declare which part of the markup is being targeted for that style

* To select a particular element we declare the name (body/h1/etc.) and then the style in {...}

* To select an element with a particular class name we use `.` followed by the class name.

* The **box model**:
  
  * Inner layer has the content
  
  * Padding is the space within the content
  
  * Border surrounds the padding layer
  
  * Margin the outer most layer - effect of increasing the size of our parent element

## 3. Wednesday

### Testing Web Apps

* **Web and device fragmentation** - different browsers, different operating systems, and different devices all being used to display the same content

* Exhaustive testing is impossible

* **Responsive testing** - emulates screen sizes and how the web page adjusts to fit the size

* Mobile responsiveness is an important ranking factor for Google

* **Functional testing**:
  
  * Form fields - allow entry, show what to enter, placeholders and validation
  
  * Character limits and checks - length
  
  * Broken links - all links to the right place
  
  * Broken buttons - form buttons work as expected
  
  * Error messages and notices - sensible error messages
  
  * Data integrity - do forms work on the back end

* **Black hat hacking** - malicious intent

* **White hat hacking** - hack an organisation with their consent,to help the organisation find security vulnerabilities

* **Grey hat hacking** - think they are helping, but without users' consent. Usually to show off

### Web Automation Testing

* Why automate:
  
  * Avoid repeating the same tests over and over manually
  
  * Free up time for manual testers for exploratory testing
  
  * Can run health checks after deploys
  
  * Set to run without supervision, so can be run out of hours

* Drawbacks of automation:
  
  * Time consuming
  
  * Expensive to maintain
  
  * Can be complex
  
  * Tests can be flakey (timeouts, slow response times, design changes)

* Concentrate on the most important paths. Tests which give the business the most value

* **Selenium IDE** - used to record interactions with the webpage to be played back and edited:
  
  * Take the link to test - open Selenium IDE in extensions, give test name and add link - start recording
  
  * All following clicks are captured
  
  * Can grab an element by id, name, class, css selector
  
  * We can specify the end result
  
  * The test can be exported from Selenium to NUnit

* **Selenium WebDriver** - an API that allows our C# code to interact with the drivers (takes control of the browser)

* In Visual studio, install NuGet packages (selenium.webdriver and selenium.webdriver.chromedriver) - global using OpenQA.Selenium.Chrome;

* We use a `using` statement to open the stream for running the selenium webdriver test.

* We grab the elements by inspecting the elements in the browser

* Ids and names are important to use on the webpage, as if any structure of the webpage changes they are still easy to find
  
  * ```csharp
    using(IWebDriver driver = new ChromeDriver())
    {
        //Maximise the browser so it is full screen
        driver.Manage().Window.Maximize();
        //Navigate to the site
        driver.Navigate().GoToUrl("url");
        //Get Elements
        IWebElement signinLink = driver.FindElement(By.LinkText("Sign in"));
        signinLink.Click();
        //wait to ensure the response
        Thread.Sleep(5000);
        //Assert - that we have arrived on the sign in page
        Assert.That(driver.Title, Is.EqualTo("Login"));
    }
    ```

* **Headless browser** - driving the application without the UI doing anything - simulates the browser so takes up less resources and runs faster, however no visualisation of results:
  
  * ```csharp
    var options = new ChromeOptions();
    options.AddArguments("headless");
    using(IWebDriver driver = new ChromeDriver(options))
    ```

* **Page Object Model** (**POM**) - wraps a HTML page with an application-specific API allowing you to manipulate page elements without digging around in HTML
  
  * The page object should encapsulate the mechanics required to find and manipulate the data in the GUI control itself
  
  * Their responsibility is to provide access to the state of the underlying page
  
  * Test methods should not have any knowledge of our web elements
  
  * Create a class for each webpage, have properties for the elements and include methods to access them



## 4. Thursday

### BDD

* **Behaviour Driven Development** - a software development process that puts feature behaviours first

* A behaviour is how a feature operates within a well-defined scenario of inputs, actions, and outcomes

* **BDD process**:
  
  * BA talks to users about what they need (requirements)
  
  * BA presents requirements to development and test teams
  
  * Requirements formalised and acceptance criteria are written as Gherkin
  
  * Product developed based on these requirements. Clear understanding
  
  * Gherkin features used as basis for tests created

* Each **feature** is a user story

* Each **Scenario** is a test case written as a Gherkin script

* .Net uses **SpecFlow** as the BDD automation tool

* **Imperative syntax** - detailed, intuiative to testers and maps to technical implementation

* **Declarative syntax** - describe what you want, but not how. Understood by stakeholders

* **Good gherkin scripts** - a continuum between imperative and declarative styles. Understandable but not overwhelming

* Using SpecFlow with Visual Studio:
  
  * Download SpecFlow extension
  
  * Create NUnit project
  
  * Add SpecFlow feature file
  
  * Add NuGet packages (SpecFlow and SpecFlow.NUnit)

* The user story is written at the top of the feature

* The `@` symbol specifies the user story category

* The `Scenario:` is the name of the Gherkin Script

* We then specify the Given... When... Then... Statements

* The lines turn purple, this can then be adapted to a class by right-clicking - define steps - create a class

* We can then change the tests from this created class to follow the scenario

* Use the `Examples:` keyword to list examples with the top being variables separated by bars, and underneath we specify the example inputs

* When dealing with **tables**, use helper methods

* Hooks are binding to perform additional automation logic at specific times. This is specified using `[Bindings]`:
  
  * `[AfterScenario]` or `[BeforeScenario]`
  
  * `[AfterFeature]` or `[BeforeFeature]`

* **Tag scoping** restricts hooks to only those features or scenarios that have at least one of the tags in the tag filter:
  
  * `[Scope(Feature = "featurename")]`

* **LivingDoc** - used to get a visualisation of test coverage

## 5. Friday

### Continuous Integration

* Integrate and test several times

* How frequently we integrate what we are working on with everything else

* Automation for every time we commit any updates, the tests will be ran

* Always allow enough time to merge, rebuild, run tests and fix defects

* Github actions:
  
  * Actions
  
  * Configure .Net (auto-generates .yml file) - The file includes the dotnet CLI commands that will run (May need to add file paths for run statements)
  
  * Start commit - include comment for automation and select the branch
