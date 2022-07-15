# Week 2: 04/07 - 08/07

1. [Monday](##1. Monday) - C# Basics & Unit Testing

2. [Tuesday](##2. Tuesday) - Operators & Iterations

3. [Wednesday](##3. Wednesday) - Exceptions & Data Types

4. [Thursday](##4. Thursday) - String, Arrays, Date Type 

5. [Friday](##5. Friday) - Enums, Methods & the Memory Model



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

### Data Types

* C# is a strongly typed language - Have to explicitly state the data type of the variable, and the type checks happen before runtime:

  * Statically typed - Once you define the type you can't change it
  * Type Safe - Prevented from assigning a different type to a variable that has already been assigned before runtime
  * Memory Safe - Restricted in the memory we can access
  * Class based - All methods must be written within a specific type

* Implicitly typed variables - using the `var` keyword creates a variable and is assigned a type after the assignment. Only used at a method level

* Explicitly typed variables - type is assigned at the time the variable is created

* Different integral types take up different sizes (in bits)

  * `sbyte & byte` - 8-bit
  * `short & ushort` - 16-bit
  * `int & uint` - 32-bit
  * `long & ulong` - 64-bit

* Use underscores instead of commas when representing large numbers

* **Floating point** numbers are anything with a decimal

  * Three types (**float, double, decimal**) and the level of precision is different in each
  * `float` - 4-byte
  * `double` - 8-byte
  * `decimal` - 16-byte
  * The decimal is the most precise point and is inferred with 1.0m

* **Safe (implicit) casting** - can store smaller data types into bigger data types without losing anything

* We need to **explicitly cast** the data type for the other way, however this may lose some data

  * ```c#
    double d = (int)b;
    ```

* **Stack overflow/underflow** - when the maximum/minimum storage size is met it will loop back around

  * Need to be aware of where these edge cases are so we can test for it

  * We can wrap the code in a checked block to throw an exception of it occurs

  * ```c#
    checked
    {
    	codeToRun;
    }
    ```

* The convert class converts one .net base type to another:

  * ```c#
    Convert.double(variable);
    ```

* **Narrowing conversion** - When we lose data after converting from a larger data type to a smaller data type.

  

## 4. Thursday

### Strings

* A **string** is an array of characters and is defined with the `string` keyword, and the assignment in double quotes:

  * ``` c#
    string message = "A string";
    ```

* `string` is an alias of the `String` class so can use the String methods

* Strings are *immutable* so cannot be changed; it would need to be assigned a new variable instead.

* The `StringBuilder` class can be used instead as this represents a mutable string:

  * ```c#
    StringBuilder sb = new StringBuilder("text");
    ```

  * This will take up less memory as it will not need to create a new storage location for every change. However, less methods are available for this

* **String interpolation** - a cleaner way of concatenating strings and variables by using the `$` special character:

  * ```c#
    $"Your {variable} is {variable}";
    ```

  * For formatting a string value we use `\key`. Multiple different format keys are available

  * For formatting a value we follow the function with `{statement:key}`.

* **Parse statement** - try to convert a string variable to a numeric value at runtime

  * ```c#
    dataType variable = dataType.Parse(variableToParse);
    ```

  * ```c#
    var success = dataType.TryParse(variableToParse, out dataType returnValueVariable);
    ```

### Arrays

* **Arrays** are fixed length lists

* An empty array can be initialised by specifying the length:

  * ```c#
    int[] array = new int[10];
    ```

* An array can be initialised with elements, and the number of elements will determine the length:

  * ```c#
    int[] array = {1, 2, 3};
    ```

* We can initialise **2D arrays** which set the number of rows and columns:

  * ```c#
    int[,] grid = new int[2,4];
    ```

  * Extra dimensions can be specified by adding further `,`.

* A **jagged array** is an array of other arrays. Only need to specify the length of the outer array (the array that holds other arrays) when initialising:

  * ```c#
    int[][] jaggedArray = new int[2][];
    ```

* The inner arrays are set after:

  * ```c#
    jaggedArray[0] = new int[6];
    jaggedArray[1] = new int[3];
    ```

### Date/Time Type

* The **DateTime Class** can be used to check the current time

  * `DateTime.Now;`

* Computers track the time in ticks, which is very millisecond:

  * `DateTime.Now.Ticks;`

* The `AddDays(numberOfDays)` method adds days on to the current time.

* Date only can also be used

  * ```c#
    new DateOnly(YYYY, MM, DD);
    ```

* Dates can be formatted using the `.ToString()` method

  

## 5. Friday

### Enums

* **Enums** are a way to represent some values that you do not want to change, but need to access

* The enum is declared in the namespace, but outside of the class:

  * ```c#
    public enum enumName
    {
    	VARIABLE1, VARIABLE2, VARIABLE3
    }
    ```

* These are constants so cannot be changed. They can then be called in the class using dot notation `enumName.VARIABLE1;`

### Methods

* Methods are made of a signature, and the body:

  * ```c#
    public static int DoThis(int x, int y)
    {
    	codeToRun;
    }
    ```

* The signature is made up of the visibility, return type, name, and parameters to take in brackets

* Visibility types:

  * public - accessed from anywhere
  * private - only accessed in the class
  * internal - accessed in that namespace
  * protected - accessed in that class and any subclass

* Static methods belong to that class

* Anything in the body can only be accessed within that scope

* The `new` keyword is what calls a constructor. These are methods without a return type

* `sealed` methods cannot be overridden by other classes

* `async` methods are used when it awaits to return

* We can provide optional parameters in the method at the end of the parameter list:

  * ```c#
    public int DoThis(int x, string y = "default")
    ```

  * In this case, only one parameter is required when the method is called

* Methods should not take too many arguments

* We can use the named parameters within a method call so we do not have to call in order:

  * ```c#
    DoThis(y: "hello", x: 3)
    ```

* **Overloaded method** - multiple methods with the same signature, but with a different parameters list

* **Tuples** - hold multiple data types within one statement:

  * ```c#
    var myTuple = ("string", "string2", 3);
    ```

* Can call an individual item in the tuple by calling the item number (starting at 1):

  * ```c#
    myTuple.item2;
    ```

* We can declare items specifically, then we can call them by a specified name:

  * ```c#
    (string firstTup, string secondTup, int age) myTuple = ("string", "string2", 3);
    myTuple.firstTup;
    ```

* We can also use a tuple as a return type for a method:

  * ```c#
    public static (int variableName, int variableName2) DoThis()
    {
        return (int, int);
    }
    ```

  

### Memory Model

* `int` is a **primitive type** so is passed a value - stored on stack

* `string` is an object so is passed a reference - stored on the heap

* When we use the `out` keyword, we are editing the variable in memory, not passing a copy. Used for returning multiple variables

* We can use the `ref` keyword to pass the memory location of a primitive type:

  * ```c#
    int number = 10;
    DoThis(number);
    public static void DoThis(ref int num)
    {
    	changeNumber;
    }
    ```

  * This would change the number value to 9 in `int number = 10`

* **Primitive Data Types** - numeric types, booleans, chars - value types are stored on the stack which is fast access memory - The value is stored directly in that variable

* **Reference Types** - arrays, lists, strings - stored on the heap - not stored in the variable (only the variable is stored on the stack), it stores a memory address of the element that has just been created - element is stored on the heap

* **Scope** - where the variable is visible form - class, method or block

* **Stack** - variables are stored as they are declared

* **Heap** - organised storage

* **Garbage collector** - Identifies dead (non-referenced) elements, compacts heap, removes dead elements