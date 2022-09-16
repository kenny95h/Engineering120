# Week 10: 29/08 - 02/09

**1.** [Monday](##1. Monday) - 

**2.** [Tuesday](##2. Tuesday) - Unit Testing & TDD, Virtual Environments, PyCharm & PyTest, and Test Doubles

**3.** [Wednesday](3. Wednesday) - ClassMethod & StaticMethod, More Inheritance, Class Composition and Type Hinting

**4.** [Thursday](##4. Thursday) - Testing, Testing Endpoints

**5.** [Friday](##5. Friday) -  REST API Testing

## 1. Monday

### 

## 2. Tuesday

Unit Testing & TDD

* Software testing catches bugs before they get to the field

* There are several layers of testing:
  
  * Unit testing
  
  * Component testing
  
  * System testing
  
  * Performance testing

* **Unit Testing**:
  
  * Tests individual functions
  
  * A test should be written for each test case of a function
  
  * Groups of tests can be combined into test suites for better organisation
  
  * Executes in development environments rather than the production environment
  
  * Should be automated and return clear results

* They perform three steps:
  
  * Setup
  
  * Action
  
  * Assertion

* **TDD** (Test Driven Development) - A process for writing code to ensure quality

* Unit tests are written before production code

* Tests and production are written together in small increments of functionality

* Provides immediate feedback after each change in production code

* Drives good OOP design

* Three phases:
  
  * **RED** - write a failing unit test for the new functionality
  
  * **GREEN** - write just enough code to make the unit test pass
  
  * **REFACTOR** - refactor the unit tests and the production code to make it clean

### Virtual Environments

* By default, all Python packages are installed in a single directory on a system

* **Virtual environments** create isolated Python environments that can be customised per project

* The PATH environment variable is updated to point to the virtual environment when it is activated

* Setup (use Git Bash):
  
  * `python3 -m venv name_of_env`
  
  * `# source the activate script in the virtualenv directory`
  
  * `source name_of_env/Scripts/activate`

* We can then install packages in the new environment, specific to the program

* To deactivate, type `deactivate` in the virtualenv

### PyCharm & PyTest

* We can create a new project within a previously created virtual environment, or have PyCharm setup a new one

* Once we have created the project, we then need to create the .py test file

* We then need to add a pytest configuration, by selecting edit configurations, press add new configuration, python tests, pytest. Then link the configuration to the new .py test file

* **PyTest** is a Python unit testing framework

* Provides the ability to create tests, test modules and test fixtures

* Uses the built in Python `assert` statement

* Allows us to filter which tests are ran

* We define the test function by beginning the name with `test_nameOfTest`

* Classes for tests should be named as `TestClassName`, and not include an `__init__` method

* The filename should start with `test_`

* **XUnit** includes `setup` and `teardown` functions to exeute before and after, modules, functions, classes, and methods:
  
  * ```python
     def setup_function(function):
         # code to run before each function
     def teardown_module(module):
        # code to run after all tests in the module
    ```

* **Test Fixtures** allow for reuse of setup and teardown code across tests

* The `pytest.fixture` decorator is applied to functions that are decorators

* Individual unit tests can specify which fixtures they want to execute
  
  * ```python
     @pytest.fixture() 
     def setup():
         # code to execute
      def test_one(setup):
         # test to run
    ```

* We can also use an `auto-use` feature to run the setup/teardown fixture on all tests:
  
  * ```python
    @pytest.fixture(autouse=True)
    def setup():
        # code to execute before every test
    ```

* We can also specify the `scope` of the fixture, default is function, but we also have module, class, and session:
  
  * ```python
    @pytest.fixture(scope='session', autouse=True)
    def setup():
        # code to execute at the start of the pytest session
    ```

* Test fixtures can return data which can be used in the test using the `params` argument

* When a `params` argument is specified, the test will be called one time with each value:
  
  * ```python
    @pytest.fixture(params=[1,2])
    def setupData(request):
        return request.param
    def test_one(setupData):
        # test to execute with params from setupData
    ```

* The built-in Python `assert` statement performs verification in a unit test

* PyTest expands on the message returned from assert failures to provide more context

* Comparing floating points:
  
  * ```python
    assert val == approx(0.3)
    ```

* To verify a function throws an exception, we use the keywords `with` and `raises`:
  
  * ```python
    def test_execution():
        with raises(ExceptionType):
            # method call that raises exception
    ```

### Test Doubles

* Tests may depend on code in other parts of they system/program

* These parts of the system may not be easy to replicate in a test environment, or would make tests slow if used directly

* **Test doubles** are objects that are used in unit tests as replacements to the real production system collaborators

* Types of test doubles:
  
  * **Dummy** - objects that can be passed around as necessary, but do not have any implementation
  
  * **Fake** - have a simplified functional implementation of a particular interface that is adequate for testing but not production
  
  * **Stub** - provides implementations with canned answers that are suitable for the test
  
  * **Spies** - provide implementations that record the values that were passed in so they can be used by the test
  
  * **Mock** - pre-programmed to expect specific calls and parameters and can throw exceptions when necessary

* **Mock frameworks** provide easy ways to automatically create test doubles at runtime

* `unittest.mock` is a Python mocking framework. It provides the Mock class to be used as different test doubles

* Once it has been called, a Mock object has many built-in functions for verifying how it was used

* Mock provides **initialisation parameters** which can be used to control the behaviour:
  
  * ```python
    def test_UsingMock():
        bar = Mock(spec=SpecClass) # spec specifies the interface the mock object is implementing
        bar2 = Mock(side_effect=barFunc) # side_effect specifies a function that should be called when the         mock is called
        bar3 = Mock(return_value=1) # the return value when the mock is called
    ```

* Mock provides built-in functions for verifying how it was used:
  
  * `assert_called` - mock was called
  
  * `assert_called_once` - mock was called once
  
  * `assert_called_with` - last call to the mock was with specified parameters
  
  * `assert_called_once_with` - called once with specified parameters
  
  * `assert_any_call` - was called at any point with specified parameters
  
  * `assert_not_called` - mock was not called
  
  * `assert_has_calls` - called with the specified list of calls in order
  
  * `called` - boolean value indicating if mock was ever called
  
  * `call_count` - int value representing num of times called
  
  * `call_args` - arguments mock was last called with
  
  * `call_args_list` - list containing the arguments that were used for each call

* The `MagicMock` class provides default implementation of many of the default magic method (such as, `__str__`)

## 3. Wednesday

### ClassMethod & StaticMethod

* A **classmethod** is a method that links directly to the class, but does not need to create an instance of the class. This is created using the `@classmethod` decorator:
  
  * ```python
    class ClassTest:
        @classmethod
        def class_method(cls):
            print(f"Called class method for {cls}")
    ```

* This needs to take in `cls` as a parameter, as this is calling on the class object itself:
  
  * ```python
    ClassTest.class_method() # infers the cls argument as a parameter
    ```

* A **staticmethod** is used to create functions inside classes that do not have anything to do with the class object, but logically makes sense to be held within that class. This is created using the `@staticmethod` decorator:
  
  * ```python
    class ClassTest:
        @staticmethod
        def static_method():
            print("Called static method")
    ```

* When we call on this static method, we simply call the method name on the class name. Unlike other methods, it does not need to take anything in as a parameter:
  
  * ```python
    ClassTest.static_method()
    ```

* Class methods are used as factories. This is when we want to use a class within a class to define different types of objects:
  
  * ```python
    class Book:
        TYPES = ("hardcover", "paperback")
        def __init__(self, name, book_type, weight):
            self.name = name
            self.book_type = book_type
            self.weight = weight
    
        @classmethod
        def hardcover(cls, name, page_weight):
            return Book(name, Book.TYPES[0], page_weight + 100)
    ```

* We can then create an instance of the hardcover object within the book object to automatically update the variables and assign the book type:
  
  * ```python
    book = Book.hardcover("Harry Potter", 1500)
    ```

### More Inheritance

* We can use the `super()` method to call the details from the superclass, within the initialisation or within overridden methods:
  
  * ```python
    class Device:
        def __init__(self, name, connected_by):
            self.name
            self.connected_by = connected_by
            self.connected = True
    
        def __str__(self):
            return f"Device {self.name} ({self.connected_by})"
    
    
    ```

    ```
    
    ```
    
    ```
    
    class Printer(Device):
        def __init__(self, name, connected_by, capacity):
            super().__init__(name, connected_by) # calls the init method of the superclass
            self.capacity = capacity
            self.remaining_pages = capacity
    
        def __str__(self):
            return f"{super.().__str__()} ({self.remaining_pages} pages remaining)"
    ```

* If you call a method that is not in the class, it will then look for the method in the superclass and run the method from there

### Class Composition

* Used when inheritance does not logically make sense. We can instead pass in objects from one class into another classes init method:
  
  * ```python
    class BookShelf:
        def __init__(self, *books):
            self.books = books
    
    class Book:
        def __init__(self, name):
            self.name = name
    ```

### Type Hinting

* Specifying the data type of the parameters and the return type:
  
  * ```python
    from typing import List # recommended for type hinting - all collection types used should be imported
    
    def my_func(sequence: List) -> float:
        # code to execute
    ```

* This will then display a message when calling the method of the parameter type to input, and the return type to expect

* If a method is returning an object of the class you are in, it is written as `"ClassName"`

## 4. Thursday

### Testing

* When creating a test class in Python we need to inherit from the `TestCase` class to give us access to the test methods. We need to import this class, as well as the class that we want to run the tests against
  
  * ```python
    from unittest import TestCase
    from post import Post # class to test
    class PostTest(TestCase):
        # Test methods
    ```

* Each test we write is a method within the class, that mustbe named `test_whatToTest`, to be automatically recognised as a test method. We write the tests using the `assert` method from the `TestCase` class:
  
  * ```python
    def test_create_post(self):
        p = Post("Test", "Test Content") # instantiate object
        self.assertEqual("Test", p.title) # asserts expected result is equal to actual result
        self.assertEqual("Test Content", p.content)
    ```

* If the assert statement is true, the test has passed. If false, the test has failed and we will be displayed with the error and details of the failed test

* We can also use an assert statement to check the key/value pairs of a dictionary are the same:
  
  * ```python
    def test_json(self):
        p = Post("Test", "Test Content")
        expected = {"title": "Test", "content", "Test Content"}
        self.assertDictEqual(expected, p.json())
    ```

* There are multiple different assert statements that can be used to check the equality of data types, such as `assertListEqual`

* When testing the output to a console we need to use the `patch` class. As soon as we patch a function, it replaces this function with a mock

* We can use the patch class, to patch the print method. We use the `with` and `as` keywords to assign the patch to a variable to be tested. This installs helpers on it that allow us to create a test:
  
  * ```python
    from unittest.mock import patch
    class AppTest(TestCase):
        def test_print_blog(self):
            blog = Blog("Test", "Test Author")
            app.blogs = {"Test": blog}
            with patch("builtins.print") as mocked_print: # we patch the module followed by the function
                app.print_blogs()
                mocked_print.assert_called_with("- Test by Test Author (0 posts)")
    ```

* We can use the patch method for many different built-in functions, including the input function, to test it is displaying the correct message to the user:
  
  * ```python
    def test_input(self):
        with patch("builtins.input") as mocked_input:
            app.menu()
            mocked_input.assert_called_with("Message to user")
    ```

* We can also use patch to check our own methods have been called within our program:
  
  * ```python
    def test_menu_calls_print_blogs(self):
        with patch("app.print_blogs") as mocked_print_blogs:
            with patch("builtins.input", return_value="q"):
                app.menu()
                mocked_print_blogs.assert_called() # asserts the mocked method was called
    ```

* As the method we are testing also includes an input method, we need to include a patch for the input method to ignore waiting for user input, otherwise the test would never complete

* We can also assign a `return_value` to a patch. This will provide a pre-assigned value to return everytime that mocked method is called

* In some cases, we may need to provide different results for each time the input method is called, so instead of a single `return_value`, we can assign a `side_effect` to the mock:
  
  * ```python
    with patch("builtins.input") as mocked_input:
        mocked_input.side_effect = ("Test", "Test Author")
        app.ask_create_blog()
        self.assertIsNotNone(app.blogs.get("Test")) # asserts that when we look for the blog with title test, it does not return None
    ```

* When we are reusing code in our tests we can create a setup method to run before each test:
  
  * ```python
    class TestClass(TestCase):
        def setup(self):
            # code to execute before every test
    ```

### Testing Endpoints

* We can use the `Flask` library to test an endpoint in Python:
  
  * `pip install flask`

* Once installed we can setup the class to run the endpoint:
  
  * ```python
    from flask install flask, jsonify
    app = Flask(__name__) # creates new flask object to run server
    @app.route("/") # adds endpoint to the url
    def home():
        return jsonify({"message": "Hello, world!"}) # need to import jsonify as this converts the dictionary input to a JSON body that can be understood by the server
    if __name__ == '__main__':
        app.run() # only runs the server if this program is being ran directly
    ```

* Once we have created the server and access to the endpoint we can run the tests to ensure the endpoint is valid:
  
  * ```python
    class TestHome(TestCase):
        def test_home(self):
            with app.test_client() as c: # launches a test client instead of running the app in full
                resp = c.get("/") # makes get response, and stores in variable
                self.assertEqual(resp.status_code, 200)
    ```

* We can also use an assert method to check the data coming back from the endpoint. We need to `import json` to convert the json response to Python:
  
  * ```python
    self.assertEqual(json.loads(resp.get_data()), {"message": "Hello, world!"})
    ```

* We can refactor these web tests by creating a base test file so we can make the test data reusable

* It is important that we name the base test file differently as it will not include any tests to run. Ending `_test`, instead of starting `test_`

* This allows us to remove the `unittest` and app imports, as well as the `test_client` setup so this can be changed in the base file if needed, instead of in every test/testcase:
  
  * ```python
    from unittest import TestCase
    from app import app
    
    class BaseTest(TestCase):
        def setUp(self):
            app.testing = True # tells flask we are running the app for testing
            self.app = app.test_client # sets up the test_client to be used in every test
    ```

* We can then go back to the test file and have this import the base test, and extend from the base test as well as refactoring the test_client to call this in the base test:
  
  * ```python
    from tests.system.base_test import BaseTest
    class TestHome(BaseTest):
        def test_home(self):
            with self.app() as c:
                # execute test here
    ```

## 5. Friday

### REST API Testing

* For the  testing framework, we may have multiple dependencies we need to install to access the API. These are generally kept in a `requirements.txt` file. This can then be called on in the terminal to install all dependencies in the file:
  
  * `pip install -r requirements.txt`

* We can create some unit tests on a REST API to test the basic functionality of the code, such as, instantiating a new object. However, the majority will be integration or system tests

* It is important to set up a base test to act as a parent class to each non-unit test. This allows for instantiation of the database dynamically and males sure that it is a new, blank database each time

* It is good practice to run tests on the same type of database as is used by the API

* We use the base test to setup a new blank database, with the app specific tables, and then set up the app to run in a test client:
  
  * ```python
    class BaseTest(TestCase):
        def setUp(self):
            app.config["SQLALCHEMY_DATABASE_URI"] = "sqlite:///" # sets up blank sqlite database in a new config file
            with app.app_context(): # loads up all app variables, and acts as if the app is running
                db.init_app(app) # initialised with app
                db.create_all() # creates pre-defined tables in database
            self.app = app.test_client()
            self.app_context = app.app_context # allows us to access app context later in tests
    ```

* We also use the base test to create a teardown method to delete the database after each test:
  
  * ```python
    def tearDown():
        with app.app_context():
            db.session.remove()
            db.drop_all()
    ```

* We can then create the integration tests. This is testing the CRUD functionality of the API:
  
  * ```python
    class ItemTest(BaseTest):
        def test_crud(self):
            with self.app_context(): # call the setup of the app from the base test
                item = ItemModel("test", 19.99)
                self.assertIsNone(ItemModel.find_by_name("test")) # check the item does not exist before creating in database
                item.save_to_db() # add item to database
                self.assertIsNotNone(ItemModel.find_by_name("test")) # check item has been added to database
                item.delete_from_db() # remove item from database
                self.assertIsNone(ItemModel.find_by_name("test")) # check item has been removed from database
    ```
