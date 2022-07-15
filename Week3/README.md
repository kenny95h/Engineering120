# Week 3: 11/07 - 15/07

**1.** [Monday](##1. Monday) - C# Core Test & OOP

**2.** [Tuesday](##2. Tuesday) - Abstraction & Encapsulation

**3.** [Wednesday](##3. Wednesday) - Inheritance & Polymorphism

**4.** [Thursday](##4. Thursday) - SOLID principles & Comparing Objects 

**5.** [Friday](##5. Friday) - Collections



## 1. Monday

### Object-Oriented Programming

* **Procedural programming** - data and functions in different places

* **Object-Oriented Programming** - data and functions are combined, re-use is easier and it closely models the real world

* Four principals of OOP:

  * Abstraction
  * Encapsulation
  * Inheritance
  * Polymorphism

* **Abstraction** - The details of the class mimic the real world and act as a blueprint for objects

  * Class - The properties, the methods, and the name of the class

  * Constructor - has the same name as the class, used to initialise an instance of the class

    * ```c#
      public string Variable1; //variables of class
      public string Variable2;
      
      public ClassName
      {
      	
      }
      ```

    * The constructor can then be called to create a new instance of that class:

      * ```c#
        ClassName con = new ClassName();
        con.Variable1 = "name";
        con.Variable2 = "name2";
        ```

    * Can also create a constructor which intitalises the values at the same time as creating the object by adding parameters into the constructor:

      * ```c#
        public string Variable1; //variables of class
        public string Variable2;
        
        public ClassName(string Var1, string Var2)
        {
        	Variable1 = Var1;
            Variable2 = Var2;
        }
        
        ClassName con = new ClassName("name", "name2");
        ```

    * Can also add methods into the class which can then be called on the new instance of the class that has been created

* **Encapsulation** - The data and implementation is hidden within the class. Provides a simple and consistent interface to use the object

  * We use the keyword `private` to control access to the instance variables, the convention is to change the name to an underscore and lowercase:

    * ```c#
      private string _variable1; //variables of class
      private string _variable2;
      
      public ClassName(string Var1, string Var2)
      {
      	_variable1 = Var1;
          _variable2 = Var2;
      }
      ```

    * This then hides these variables from access within other classes

  * We can then create methods so these variables can be accessed from outside the class if needed (Get or Set methods). A shorthand way of doing so is provided in C#, by right-clicking the variable-quick access and refactoring-Encapsulate field:

    * ```c#
      public string Variable1 { get => _variable1; set => _variable1 = value; }
      ```

    * This allows us to assign a value to this variable in another class `con.Variable1 = "name";`

    * These are known as **properties** 

* **Inheritance** - different types of classes can inherit from others which have characteristics in common. 

  * **Base (Superclass)** and **derived (subclass)** - The inheritance hierarchy, the derived inherits the characteristics from the base

  * To specify a base:

    * ```c#
      public class SubClassName : ClassName;
      ```

  * The constructor of the derived needs to have the same properties as the base, but can also take further specialised parameters:

    * ```c#
      public SubClassName (string Var1, string Var2, string Var3)
      {
      
      }
      ```

  * We can also specify we want the base constructor to be called by using the `base` keyword:

    * ```c#
      public SubClassName (string Var1, string Var2, string Var3) : base (Var1, Var2)
      {
      
      }
      ```

  * The implementation of the derived is inherited through the base methods, however we can also create more specialised methods in the subclass

* **Polymorphism** - different objects can interact with the same operation, and the object knows how to complete the task. The same method, but with different outputs

  * The keyword `virtual` needs to be added to the method definition in the superclass, and the keyword `override` needs to be added to the same method definition in the subclass.



## 2. Tuesday

### Abstraction & Encapsulation

* **Unified Modeling Language** (**UML**) - used in software development to make diagrams to represent the relationships between items

* **Class Diagram** - In VS, right-click on project name-add item-create class diagram.

  * Drag over the class into the class diagram window to see its properties
  * Add in additional properties through the class details bar in the class diagram

* **Properties** - The get and set methods of a private field. Type in prop-tab tab:

  * ```c#
    public int age {get; set;}
    ```

* Always put the fields and properties above the constructor

* Quickly create a constructor and select parameters from the fields and properties. Right-click class name-refactoring-generate constructor.

* If we don't declare a constructor, a default one is declared with no parameters. However, if we do declare one, this default constructor will not be created

* The `new` keyword is used to call the constructor of a specified class and creates an instance of that class object:

  * ```c#
    ClassName variable = new ClassName("parameter1", "parameter2");
    ```

* We can edit the property methods by creating the full property. Type propfull-tab tab:

  * ```c#
    private int _age;
    public int Age
    {
    	get {return _age;}
    	set {_age = value;}
    }
    ```

* Can change any standalone get method into a property:

  * ```c#
    public string FullName => $"{_firstName} {_lastName}";
    ```

  * In a property we can `get` multiple values, but can only `set` one value at a time.

* `readonly` variables can only be set when declared or within the constructor:

  * ```c#
    private readonly string variable;
    ```

* `const` variables can only be set when declared:

  * ```c#
    private const int variable = 12;
    ```

* **Object initialisation** - used to set a variable outside of the constructor by using {}:

  * ```c#
    ClassName name = new ClassName {FirstName = "name", LastName = "name2"};
    ```

* **Immutable properties** - cannot be changed after they have been declared

  * remove the set method in the property and declare the value in a constructor
  * The better way is to use the `init` keyword in place of `set`, then we can still declare the variable through object initialisation

* **Naming conventions:**

  * Classes - noun - PascalCase (e.g. Person)
  * Fields - nouns - underscore using _camelCase (e.g. _firstName)
  * Properties - nouns - PascalCase (e.g. FirstName)
  * Methods - verbs - PascalCase (e.g. GetFullName())
  * Variables and method parameters - camelCase (e.g. firstName)
  * Constants - const - PascalCase

* **Structs** - similar to a class, typically with only public fields and methods, to represent one value which can then be represented in different manners:

  * ```c#
    public struct StructName
    {
    
    }
    ```

  * They are value types so are stored on the stack

  * Cannot inherit from other structs

  * Structs do not need to use the `new` keyword when initialising:

    * ```c#
      StructName variable;
      variable.parameter = 2;
      ```



## 3. Wednesday

### Inheritance & Polymorphism

* An **Is A** relationship

* Avoid writing the same code to describe similar features

* Use the `base` keyword to call the constructor from the base class, and pass the parameters from the derived class to the base constructor

* The body of the derived class constructor runs after the base

* To have a no argument constructor in the derived class, we must also have a no argument constructor in the base class

* All classes are derived from the `Object` class

* The `ToString()` method returns information about that object, default is namespace and class name

* The `virtual` keyword means that method can be overridden in derived classes

* Must use the `override` keyword in the derived class for the methods we want to override:

  * ```c#
    public override string ToString()
    {
    	return base.ToString();
    }
    ```

  * `base.ToString()` calls the base method

* Use the `sealed` keyword to ensure a method cannot be overridden by derived classes:

  * ```c#
    public override sealed string ToString()
    {
    	return "";
    }
    ```

* **Abstract** classes can have concrete and abstract methods, however concrete classes cannot have abstract methods

  * In abstract methods we do not provide implementation of the method, this is left for the derived classes
  * Any derived classes must override all methods of the abstract class

* To define an `interface` we call them **ISomethingable** 

  * Any class implementing an interface must use all their methods
  * Classes can implement multiple interfaces
  * All methods and properties are public by default
  * Only need the method signature, no body

* An interface is added to the derived class in the same way as a base class

  * ```c#
    public class ClassName: ISomethingable
    ```

  * All derived classes then become a type of that interface



## 4. Thursday

### SOLID principles

* **S**ingle responsibility
* **O**pen for extension / Closed for modification
* **L**iskov substitution
* **I**nterface segregation
* **D**ependency Inversion
* We follow SOLID principles to abide by the rules of OOP
* **Single Responsibility Principle**:
  * A class should represent one thing that it is responsible for
  * Class members should be cohesive - fields should hold information, methods should manipulate or return this information
* **Open / Closed Principle**:
  * Methods and classes should be open for extension but closed for modification
  * Abstract classes once defined should not be changed
  * New functionality can be added by creating derived classes
  * Existing methods can be modified by overriding them in derived classes
* **Liskov Substitution Principle**:
  * Derived types must be substitutable for their base types without breaking the application
  * The essence of polymorphism
* **Interface Segregation Principle**:
  * Many small, specific interfaces (all classes) are better than one large, general purpose one
  * Classes should not be forced to depend on interfaces they do not use
* **Dependency Inversion**:
  * Depend on abstractions rather than concrete instances
  * High level modules should not depend on low-level modules
  * The dependency is apparent in the constructor
  * *Dependency Injection* - inject in the dependency in the constructor

### Comparing Objects

* The Object `Equals` method only checks whether the memory reference address is the same, if not they are not considered equal.

  * This memory location is also what the `GetHashCode` is calculated from

* Override the `Equals` and `GetHashCode` methods to specify which fields should be the same for the object to be considered equal

  * Right-click ClassName-Refactoring-Generate Equals and GetHashCode-Select fields-Tick implement IEquatable and generate operators

* When sorting a list of objects we need to override the `CompareTo` method, otherwise it will throw an exception, as there is nothing to compare against. To do this we need to implement the `IComparable` interface:

  * ```c#
    public class ClassName : IComparable<ClassName?>
    ```

* In the `CompareTo` method:

  * Less than 0 - before
  * More than 0 - after
  * 0 - same

* ```c#
  public int CompareTo(ClassName? other)
  {
  	if(other == null) return 1;
  	if(this.variable != other.variable)
  	{
  		return this.variable.CompareTo(other.variable);
  	}
  }
  ```



## 5. Friday

### Collections