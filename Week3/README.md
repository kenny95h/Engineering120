# Week 3: 11/07 - 15/07

**1.** [Monday](##1. Monday) - C# Core Test & OOP

**2.** [Tuesday](##2. Tuesday) - 

**3.** [Wednesday](##3. Wednesday) - 

**4.** [Thursday](##4. Thursday) - 

**5.** [Friday](##5. Friday) - 



## 1. Monday

### Object-Oriented Programming

* **Procedural programming** - data and functions in different places

* **Object-Oriented Programming** - data and functions are combined, re-use is easier and it closely models the real world

* Four principals of OOP:

  * Abstraction
  * Encapsulation
  * Inheritance
  * Polymorphism

* **Abstraction** - The implementation is hidden within the class. The details of the class can be called on from other classes

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

* **Encapsulation** - The data is hidden within the class. Provides a simple and consistent interface to use the object

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

  * **Superclass** and **subclass** - The inheritance hierarchy, the subclass inherits the characteristics from the superclass

  * To specify a subclass:

    * ```c#
      public class SubClassName : ClassName;
      ```

  * The constructor of the subclass needs to have the same properties as the superclass, but can also take further specialised parameters:

    * ```c#
      public SubClassName (string Var1, string Var2, string Var3)
      {
      
      }
      ```

  * We can also specify we want the superclass constructor to be called by using the `base` keyword:

    * ```c#
      public SubClassName (string Var1, string Var2, string Var3) : base (Var1, Var2)
      {
      
      }
      ```

  * The implementation of the subclass is inherited through the superclass methods, however we can also create more specialised methods in the subclass

* **Polymorphism** - different objects can interact with the same operation, and the object knows how to complete the task. The same method, but with different outputs

  * The keyword `virtual` needs to be added to the method definition in the superclass, and the keyword `override` needs to be added to the same method definition in the subclass.



## 2. Tuesday





## 3. Wednesday





## 4. Thursday





## 5. Friday