# Week 10: 29/08 - 02/08

**1.** [Monday](##1. Monday) - 

**2.** [Tuesday](##2. Tuesday) - Unit Testing & TDD, Virtual Environments, PyCharm & PyTest, and Test Doubles

**3.** [Wednesday](3. Wednesday) - 

**4.** [Thursday](##4. Thursday) - 

**5.** [Friday](##5. Friday) -  

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

## 4. Thursday

## 5. Friday

### 
