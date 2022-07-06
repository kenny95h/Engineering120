# Week 2: 04/07 - 08/07

1. [Monday](##1. Monday) - C# Basics & Unit Testing

2. [Tuesday](##2. Tuesday) - Operators & Iterations

3. [Wednesday](##3. Wednesday) - Exceptions

4. [Thursday](##4. Thursday) - 

5. [Friday](##5. Friday) - 



## 1. Monday

### C# Unit Testing

* **Refactoring** changes the structure of the code without changing behaviour - highlight code, right-click and extract into new method

* **DAMP** - Descriptive and Meaningful Phrases

* Type `var` is a general type that infers the type with whatever is assigned to the variable

* To create a new *NUnit test class* - right-click solution-add-new project-search for NUnit test project-create

  * The `[Test]` attribute marks the method as a test so it will be ran by the test explorer

* Method signature for tests:

  * `public void GivenAVariable_NameOfClass_ReturnsSomeOutput()`

* To allow the test class to access the class to test:

  * right-click dependencies-add project reference-tick class name
  * check class method is public
  * add `using` statement for class in test class

* Example of a test (Arrange / Act / Assert):

  * `Assert.That(Program.ClassName(Variable), Is.EqualTo(Variable));`

* What makes a good unit test? **FIRST**:

  * **FAST** - Fast enough that users wont be discouraged from using
  * **INDEPENDENT** - Testing one thing and does not depend on previous tests
  * **REPEATABLE** - In any environment without varying results
  * **SELF VALIDATING** - In test explorer it should show pass/fail
  * **TIMELY** - Before production code

* **Boundary value analysis** - testing the boundaries of an expected result

* **Parameterised tests** - testing the parameters by taking arguments:

  * Change `[Test]` tag to `[TestCase(parameter)]` and provide a parameter in the method signature as required - Can provide multiple per method, and can include multiple parameters.

* **TDD (Test Driven Development)** - Create tests, test fails, refactor methods to pass tests and repeat

* **TFD (Test First Development)** - Create all tests first and adapt the code to pass the tests

* The statement can be returned straight away, so can be made into one-line:

  * ```c#
    if (x >= y)
                {
                    return true;
                }
                return false;
    ```

  * To:

  * ```c#
    return x >= y;
    ```

* We can **throw an exception** for any values we choose as out of range:

  * ```c#
    throw new ArgumentOutOfRangeException("Message to display");
    ```

* This can be checked with a unit test:

  * ```c#
    Assert.That(() => Program.ClassName(variable), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message);
    ```



## 2. Tuesday

### Operators

* C# order of precedence

  * Primary
  * Unary
  * Multiplicative
  * Additive
  * Relational and type-testing
  * Equality
  * Logical
  * Conditional
  * Assignment

* `++i`- pre-fix operator

* `i++` - post-fix operator

  * Only comes in to play when it is being assigned at the same time as the increment

* Using `var` will assign the variable type from the assignment - can only return an int value when assigned

* Use `$` to concatenate a variable in a string:

  * `Console.WriteLine($"{variable} and {variable}")`

* The `const` keyword assigns a variable as a constant that cannot be reassigned to a new value:

  * `const int name = 2;`

* `&&` - short circuit and statement, does not check right-hand condition if left-hand is false

* `&` - checks both sides of the statement

* `^` - exclusive or operator, 1 condition is true but not both

* **Turnery operators** - Short-hand if statement

  * `return variable >= variable ? condition1 : condition2;` 

* These can be chained together to provide multiple outcomes:

  * ```c#
    return variable >= variable ? condition1
        : variable >= variable ? condition2
        : variable < variable ? condition3
        : condition4;
    ```

* **Switch statements** - preferably used with constants

  * ```c#
    switch(variableToSearch)
    {
        case variableToFind:
            outputStatement;
            break;
        default:
            outputWhenNoCaseToFind;
            break;
    }
    return output;
    ```

  * use the break keyword to get out of case statement

  * When a case does not include an output it jumps to the case underneath

### Iterations

* **Foreach loop**

  * ```c#
    foreach (int i in listName)
    {
    	outputForEachElement;
    }
    ```

* **For loop**

  * ```c#
    for (int i = 0; condition; i++)
    {
        outputUntilConditionMet;
    }
    ```

* **While loop**

  * ```c#
    while (condition)
    {
    	outputUntilConditionIsNotTrue;
    }
    ```

* **DoWhile Loop**

  * ```c#
    do
    {
    	outputUntilConditionIsNotTrue;
    }
    while (condition)
        
    ```

## 3. Wednesday

### Exceptions

* **Exceptions** are when the program creates an error at runtime

* They are part of a hierarchy of exception types

* **Arrays** - are immutable so the length cannot be changed

  * `new type [] {elementsInArray}`
  * Attempting to add more will create an `indexOutOfRangeException`

* We use a **try catch** statement to handle exceptions:

  * ```c#
    try
    {
    	statementToTry;
    }
    catch (ExceptionType exceptionVariable)
    {
    	resultIfExceptionOccurs;
    }
    ```

* We can add multiple catch blocks to catch different types of exceptions. Ordered from more specific, to less specific exceptions.

* We can integrate the exception in the catch block by running commands on the exception variable

  * ```c#
    Console.WriteLine(exceptionVariable.ToString()); // calls toString method
    Console.WriteLine(exceptionVariable.Message); // return the message in the exception message field
    ```

* A `finally {      }` block can be added at the end of the try catch statement, this will always run no matter if the exception occurs or not 

* We can force an exception:

  * `throw new ExceptionType("Reason for exception");`

* These can be tested using:

  * `Assert.That(() => Program.MethodName(variable), Throws.TypeOf<ExceptionType>());`
  * `() =>` - A lambda expression that catches the exception
  * `TypeOf` can be changed to `InstanceOf<Expression>` if we want to test if it catches any exception, instead of a specific one
  * Add `.With.Message.Contain("message returned by exception");` 





## 4. Thursday





## 5. Friday