# Week 4: 18/07 - 22/07

**1.** [Monday](##1. Monday) - Attributes & TDD

**2.** [Tuesday](##2. Tuesday) - C# Core Test & GitHib Collaboration

**3.** [Wednesday](##3. Wednesday) - Big-O Notation & Recursion

**4.** [Thursday](##4. Thursday) - Refactoring, Code Smells & Design Patterns

**5.** [Friday](##5. Friday) - XML & JSON, & Logging, Streaming & Encoding

## 1. Monday

### Attributes

* Attributes are used to identify tests

* `[TestFixture]` - An attribute that marks a class that contains tests

* `[OneTimeSetup]` - It will run this method once before the tests are ran

* `[Setup]` - It will run this method once before every test

* `[OneTimeTearDown]` - A method that runs after all the tests have ran

* `[TearDown]` - A method that runs after each test has ran

* Unit tests must be isolated as it is not known the exact order they will run, and this can change each time

* `[Ignore("Reason to ignore")]` - stops the test explorer from running these indicated tests

* Characteristics of a good unit test
  
  * **F**ast - each tests should run fast
  * **I**solated - shouldn't affect other tests
  * **R**epeatable - should always produce the same result
  * **S**elf-checking - tests automatically inform if passed or failed
  * **T**imely - shouldn't take long to write the test

* `[Category("Name")]` - groups types of tests together as specified

* `[TestCaseSource] - used on parameterised tests to pass in different data types:
  
  * ```csharp
    [TestCaseSource("AddCases")]
    public void aNewTest(int a, int b, int c)
    {
        ...
    }
    private static object[] AddCases =
    {
        new int[] {1, 2, 3}
        new int[] {4, 5, 6}
    };
    
    ```

* The test case source name must match the new method name

* Can add multiple different types of objects this way, that will all be tested

### Test Driven Development

* Unit testing can act as living documentation of the code by looking at what expected results are meant to be

* More efficient and cheaper to find bugs at the unit testing phase

* Confirms the program works as expected

* Provides a suite of regression tests to confirm that the code continues to work at multiple stages

* Assists in refactoring code

* When you test often and fully it assists in writing good code

* Test Automation Pyramid:
  
  * 70% Unit Tests
  
  * 20% API/Integration/Component Tests
  
  * 10% GUI Tests

## 2. Tuesday

### GitHub Collaboration

* Only commit to the main branch at the end of each sprint

* Make all changes to the dev branch

* The feature branch is taken off the dev branch to work on individual features, multiple feature branches can be taken at the same time

* A pull request is used to merge a feature branch into the dev branch

* Any other users will then merge this into their feature branch and continue on

* `git branch` - is the main branch that needs to be commited at the end of the sprint

* `git checkout -b nameOfNewBranch` - creates a new branch and takes you to it

* `git checkout nameOfBranch` - takes to that branch

* `dotnet new console` - creates a new console app in the branch

* `git push -set-upstream origin dev` - pushes the commit to the dev branch

* `git pull origin` - to pull a branch made in github

* In github - settings - branches - add protection rule (require pull request before merging)

* Update default branch in settings to dev - when cloned after this, it will automatically refer to this branch

* Pull requests in github will show all requests from users
  
  * Files changed window to confirm the changes - review changes - happy - approve
  
  * Merge pull requests - confirm merge
  
  * `git pull` - in command prompt to pull the most recent version of the branch
  
  * `git merge dev` - from within feature branch to merge the updates into the dev branch 

## 3. Wednesday

### Big-O Notation

* The efficiency of an algorithm

* Two types of complexity, time and space

* Typically refers to the worst case scenario

* An algorithm is a set of instructions

* A good algorithm:
  
  * Correct - produces expected answers
  
  * Efficient - Doesn't take more time than necessary and doesn't require more memory space than necessary
  
  * Time efficiency - Use big-O notation:
    
    * $O(1)$ - Constant running time
    
    * $O(n)$ - Linear - traversing a list
    
    * $O(n^2)$ - Quadratic - two nested loops
    
    * $O(n^3)$ - Cubic - three nested loops
    
    * $O(log_2n)$ - Logarithmic - number of layers in a binary tree
    
    * $O(nlog _2n)$ - Optimal sorts

* The scalability is more important than the number of times the loop runs

* We ignore constants

* The number of operations $(n)$ is irrelevant, it is the number of loops which is important
  
  * $2^3 = 8$
  
  * $log_2(8) = 3$ 
    
    * 1. $O(n^2)$
    
    * 2. $log_2(n)$
    
    * $array = 2;$
    
    * 1. $4$
    
    * 2. $1$
    
    * $array = 4;$
    
    * 1. $16$
    
    * 2. $2$
    
    * $array = 8;$
    
    * 1. $256$
    
    * 2. $3$

* $log_2(n)$ scales better than $O(n^2)$. The number of operations increases exponentially when the size of the array increases

* $log$ is how many operations we need to do to get from the log to the number:
  
  * $log_2 (8) = 3$
  
  * $2 * 2 * 2 = 8 : 3 times$ 

* Algorithms whose running times are $O(n!)$ are considered unreasonable

* Types of measurements:
  
  * Worst case - The most number of operations possible
  
  * Best case - The least number of operations possible
  
  * Average case

* A **recursive method** is a method that calls itself until some statement is true:
  
  * Each method call is pushed onto the stack and then popped back of the stack then returns to the appropriate method in which it was called
  
  * This takes up a lot of stack memory
  
  * If we do not provide a base case (statement until true) it will lead to a stack overflow

## 4. Thursday

### Refactoring

* **Refactoring** - improving the structure of existing code without modifying behaviour
  
  * Improves design
  
  * Eliminates duplicate/redundant code
  
  * Easier to extend and maintain

* Without refatoring the design of the program will decay

* As people modify code, the code loses structure

* Before refactoring:
  
  * Cover code with unit tests
  
  * Make sure they pass
  
  * Commit code
  
  * Then refactor code knowing you can revert back to previous commit

* Extract method - creates method from existing code fragment and rewrites method - ctrl+r then ctrl+m

### Code Smells

* **Dead code** - code that can never be reached, or is never used

* **Inappropriate names** - methods, classes and fields should all be DAMP (Descriptive And Meaningful Phrases) - names should be changed to more appropriate ones: double-click name to change-rename-press enter

* **Long methods** - part of single responsibility - should be split into separate functional methods: highlight code-refactor-generate method-create name for method

* **Large classes** - split into multiple classes

* **Data clumps** - same group of members keeps appearing together - This should then be encapsulated into one place

* **Feature envy** - when one class is calling another class frequently, it should likely be part of the other class

* **Long parameter lists** - call using an object or interface instead

* **Repeated switch/if-else statements** - think of polymorphism - move into the right class

### Design Patterns

* **Design patterns** describe solutions to commonly encountered problems

* Patterns capture good design principles and communicate them to others

* A common language for talking about problems and their solutions

* The three patterns are **creational**(when creating objects), **behavioural**(the behaviour of an object) and **structural**(the structure of a group of objects), these include:
  
  * **Singleton** - something that can only exist once and is globally available
    
    * ```csharp
      private Singleton(){};private readonly static Singleton? instance;
      ```
    * The constructor is private and an instance is made within the class
    * Guarantees only a single instance of this class
  
  * **Strategy** - allows an algorithm to vary independently from the clients that use it. Family of algorithms, each encapsulated in a class
    
    * Define a family of algorithms, one for each behaviour in a separate class
      
      * The context class has reference to an object implementing that interface
      
      * The concrete instance can be injected
    
    * An alternative to subclassing
    
    * Follows open/closed principle
  
  * **Decorator** - attach additional responsibilities to an object dynamically, by placing them inside wrapper objects that contain the behaviours. A flexible alternative to inheritance
    
    * Avoids classes with excessive numbers of features high up in the class hierarchy
    
    * Often results in lots of little objects that look alike#

## 5. Friday

### XML & JSON

* **XML** (e**X**tensible **M**arkup **L**anguage)

* **JSON** (**J**ava**S**cript **O**bject **N**otation)

* Both are used to store and transfer data:
  
  * Human readable
  
  * Parsable
  
  * Hierarchical

* XML:
  
  * Extensible - add or remove data
  
  * Markup - provides definition to text and symbols
  
  * Language - present information based upon certain rules

* All tags have closing tags `<tag> </tag>`

* In XML tags are definable by the user, contain content, and can have attributes

* Must have a root element that wraps all content

* XML tags are case sensitive

* XML comments `<!- comment -->`

* An element is everything within a tag:
  
  * Text
  
  * Attributes
  
  * Other elements
  
  * Empty

* XML attributes are assigned within the tag:
  
  * Must always be quotes
  
  * `<tag attribute="name"> </tag>`

* XML declaration is a processing instruction that identifies the document as XML:
  
  * `<?xml version="1.0" encoding="UTF-8" standalone="no" ?>`
  
  * No closing tag
  
  * Must be lower case
  
  * XML parsers are required for UTF-8 and UTF-16
  
  * Encoding - names of the most common character sets. Defines the properties and methods for accessing and editing the XML
  
  * Standalone - yes if has internal document type definition, no if linked to external DTD

* JSON:
  
  * Lightweight
  
  * Easily parsable
  
  * Language independent
  
  * Human readable

* Data is declared as objects with key/value pairs

* JSON is focused on content rather than formatting as in XML

* JSON is strictly a data format

* Key-value pairs are between curly brackets:
  
  * ```json
    {
        "string":12,
        "string2":13
    }
    ```

* Types of values:
  
  * String `"String"`
  
  * Number `12`
  
  * Boolean `"key" : true`
  
  * Null `Null`
  
  * Array `["element", "element"]`
  
  * Object `{"element" : true }`

* JSON vs XML:
  
  * Doesn't use tags
  
  * Less verbose
  
  * Quicker to read and write
  
  * Can use arrays
  
  * Less difficult to parse
  
  * Parsed into ready-to-use JavaScript object
  
  * Poor extensibility
  
  * Supported by most backend systems

### Logging, Streaming & Encoding

* `System.IO` - includes all methods for reading and writing

* **Asynchronous** - Happens at the same time

* **Synchronous** - Happens one after another

* Get directory and path:
  
  * ```csharp
    //Get directory of program
    string currentDirectory = Directory.GetCurrentDirectory();
    //Combine each ../ is a deeper folder
    var path = Path.Combine(currentDirectory, @"../../../");
    ```

* Write text to file:
  
  * ```csharp
    //line to write
    File.WriteLine(path + "nameOfFile.txt", textToWrite);
    //array of lines to write
    File.WriteAllLines(path + "nameOfFile.txt", array);
    ```

* Read text from file:
  
  * ```csharp
    //read to string
    File.ReadAllText(path + "nameOfFile.txt");
    //read to array
    string[] readLines = File.ReadAllLines(path + "nameOfFile.txt");
    ```

* `using System.Diagnostics` - used for logging and includes writeline methods. Used to log different activities completed by the specified code
  
  * ```csharp
    //Useful to find defect
    Debug.WriteLine($"Debug - The value of i is {i}");
    //Similar to debug - runs on separate thread - monitors performance
    Trace.WriteLine($"Trace - The value of i is {i}");
    ```

* Can use `TraceListener` to track all the debugging and trace output and writes to file:
  
  * ```csharp
    TextWriterTraceListener twtl = new TextWriterTraceListener(File.Create(_path + "TraceOutput.txt"));
    //Assigns to be a listener
    Trace.Listeners.Add(twtl);
    ... code to debug/trace
    //Flush output to the text file
    Trace.Flush();
    ```

* **Conditionally compiling code** - when we don't want a piece of code to be ran, or only want ran in debug mode:
  
  * ```csharp
    #if DEBUG
        code not to compile unless in debug
    #endif
    ```
  
  * Avoid this as it will be difficult to maintain and creates unreadable code

* **Encoding** - taking readable data and converting to unreadable data. It will then need to be interpreted to understand
  
  * ASCII - represents certain computer characters as binary (0-127) - 7 bit
  
  * UTF-8 - Most character enconding can be done with 1 byte - 8 bit
  
  * UTF-16 - 2 bytes

* **Streaming** - has a start point and an end point - gradually sending data from one location to another

* When streaming we utilise the decorator pattern

* `using System.IO` - provides a generic abstract view of a sequence of bytes

* `StreamReader` (starts the stream to read from) and `StreamWriter` (starts the stream to write to) are derived from the `TextReader` class.

* The `using` keyword only uses the resource within the scope, then it is discarded, using the discard method once it exits the scope:
  
  * ```csharp
    //Creating the stream and streaming the text from the program to the directory
    using (StreamWriter sw = File.AppendText(_path + "File.txt"))
    {
        ...statment to write sw
    }
    //Creating a stream from the directory and back into the application
    using (StreamReader sr = File.OpenText(_path + "File.txt"))
    {
        ... while statement to read back to the program until null
    }
    ```


