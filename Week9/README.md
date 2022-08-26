# Week 8: 22/08 - 26/08

**1.** [Monday](##1. Monday) - Python Intro, Data Types, and File Input/Output

**2.** [Tuesday](##2. Tuesday) - Comparison Operators, Control Flow, Methods, Lambda Expressions, and Scope

**3.** [Wednesday](3. Wednesday) - Validating User Input, Object Oriented Programming, Special Methods, and Modules/Packages

**4.** [Thursday](##4. Thursday) - Exception Handling, Unit Testing, Decorators, Generators, and Advanced Python Modules

**5.** [Friday](##5. Friday) -  Web Scraping, Images, PDFs & CSV files, and Emails

## 1. Monday

### Python Intro

* **Dynamically Typed** - do not need to specify the data type when assigning. Variables can be reassigned to different data types

* Once we understand base Python, we can use externa; libraried for further functionality:
  
  * Automate simple tasks
  
  * Data science and Machine learning
  
  * Create websites

#### Anaconda

* Anaconda is a package of multiple programming environments, including Python

* Run with Anaconda Navigator app - GUI for software that is included

* Environments tab can be used to set-up new environments to run programs in

* Jupyter notebook - a localhost of all folders and files on your computer

* Notebook files can be created using new

* Notebooks are used to write Pyhton code - an environment for individual cells of Python code

* We can use the cell button to run individual cells (Shortcut: Shift + Enter)

* Better for organising and writing Python code

* The green icon next to the notebook means the code is running. We can tick and press shutdown to stop the code running

#### Running Python

* 3 Types of environments (To write Python code):
  
  * Text editors - general text files
  
  * Full IDEs - Development environments designed for Python - lots of extra functionality
  
  * Notebook environments - designed for learning. Input/Output side-by-side

* To run a Python file (.py) on the command line, go to file location and type python filename.py

### Data Types

* Main Python data types:
  
  * **Integers** (**int**) - whole numbers
  
  * **Floating point** (**float**) - numbers with decimal point
  
  * **Strings** (**str**) - ordered sequence of characters, in double or single quotes
  
  * **Lists** (**list**) - ordered sequence of objects
  
  * **Dictionaries** (**dict**) - unordered key/value pairs
  
  * **Tuples** (**tup**) - ordered immutable sequence of objects
  
  * **Sets** (**set**) - unordered collection of unique objects
  
  * **Booleans** (**bool**) - Logical value indicating True/False

#### Numbers

* **%** (**Modulo**) - finds the remainder of division of two numbers

* ****** (**Power**) - the left to the power of the right

* Python 3 performs true division by default - integers divided can return decimals

#### Variable assignments

* Rules:
  
  * Cannot start with a number
  
  * No spaces (**__** used instead)
  
  * No symbols

* Variable names are written in lower case

* Variables can be reassigned as different data types

* `type(variablename)` - used to check the type of a variable

#### Strings

* Sequences of characters (single quotes or double quotes can be used)

* **Ordered sequences** - indexing notation (uses **[]** after the variable) - indexing starts at 0

* Reverse indexing can be used by starting at -1 (being the last element) and counting backwards

* **Slicing** - grab a subsection of multiple characters `[start:stop:step]` - start: index for start, stop: index to end(not inclusive), step: size of jump to take
  
  * `[::-1]` will reverse the string

* The `print()` function is used to return the element to the output window

* `\n` - an escape sequence for new line

* `\t` - tab

* `len(variable)` function returns the length of the string

* **Immutability** - cannot be changed

* We an concatenate to strings by using `+`

* We can follow a variable name with `.` then press tab to see all available methods that can be ran on the variable

* `.lower()` or `.upper()` - change case

* `.split()` - split the string to a list by whitespace - or by the character passed in

* We use **string interpolation** to print variables and strings together

* `.format()` - Used to insert variables into `{}` where specified in a string statement:
  
  * ```python
    print("This is a string {}".format("INSERTED"))
    # Result: 'This is a string INSERTED'
    ```

* This can also be used with formatting. Float formatting - `{value:width.precision f}`:
  
  * ```python
    result = 1.2345
    print("result = {r:1.2f}".format(r = result))
    # Result: 1.23
    ```

* **f.literals** - can place the variable directly in `{}`:
  
  * ```python
    name = "Jose"
    print(f"Hello, {name}")
    # Result: 'Hello, Jose'
    ```

#### Lists

* Can hold a variety of object types

* Use `[,]` with objects separated by commas

* Use the method`.append(element)` to add item to the end of a list

* Use the method`.pop()` to return and remove an element from the end of the list, or pass in the index position to remove

* Use the method `.sort()` to sort the list in place. Does not return anything, so cannot be assigned to a new variable

* Can use the method `sorted(list)` to return the sorted list, so it can be assigned to a new variable

* Use the method `.reverse` to reverse the elements in the list. Also, does not return anything.

#### Dictionaries

* Unordered list of key/value pairs

* Uses `{key : value}` with key/value pairs separated by commas

* Objects retrieved by key names, instead of indexes

* Cannot be sorted

* Search for values by calling the key name:
  
  * ```python
    dict['keyname']
    ```

* We append elements to a dictionary by assigning a value to a new key:
  
  * ```python
    dict['newkey'] = 1
    ```

* Use the method `.key()` to return all keys

* `.values()` returns all values

* `.items()` returns tuples of all key/value pairs

##### Tuples

* Tuples are immutable lists. Once assigned, they cannot be changed

* Use `(,)` with objects separated by commas

* The method `.count(item)` counts how many times the specified item occurs

* `index(item)` returns the index of the first occurence of the item

* A convenient source of data integrity, as they cannot be changed accidentally

#### Sets

* Unordered collection of unique elements. Elements cannot be repeated

* Created using `variable = set()`

* Use the method `.add(element)` to add a new element to the set

* If a repeated element is specified it will not be added

* Useful when casting from a list to set to remove duplicates `set(mylist)`

#### Booleans

* Convey `True` or `False` statements

* Important for dealing with control flow and logic

* Must start with a capital

* Comparison operator statements will return bools

* Use the `None` placeholder to assign to a variable before waiting for a True/False result

### File Input/Output

* Create a .txt file to write to

* We use the `open('filename.txt')` function to open the file, and assign to a variable

* You can also specify the entire filepath of the file to read

* Multiple methods are then available to call on this variable

* Use the method `.read()` to return a string of what is in the file

* After reading we need to reset the cursor back to the start of the file, using the method `seek(0)`. Or move anywhere in the file by specifying the index

* `.readlines()` returns each line as an element in a list

* We should also close the file once finished with it by using the `.close()` method

* Alternatively, we can use the `with` keyword to open the file:
  
  * ```python
    with open('filename.txt') as variable_name:
        contents = variable_name.read()
    ```

* Use (shift + tab) when cursor is next to any method name to open the documentation for it

* There is a parameter in the `open()` method known as **mode** which assigns the permission of the opened file. `'r'` for read, `'w'` for write (overwrites or creates new file), `'a'` to append, `'r+'` to read and write, or `'w+'` for writing and reading (overwrites)
  
  * ```python
    open('filename.txt', mode='w')
    ```

* The `.write('Write this')` method is used to write to a file

## 2. Tuesday

### Comparison Operators

* `==` equality

* `!=` inequality

* `>` greater than

* `<` less than

* `>=` greater than or equal to

* These can be chained together:
  
  * `x > y < z`

* Alternatively, we can use logical operators:
  
  * `and`
  
  * `or`
  
  * `not` 

### Control Flow

* Use logic to execute code if a particular condition has been met

* The indentation is crucial to Python to read the statements

* We need a colon at the end of each statement:
  
  * ```python
    if some_condition:
        # execute this code
    elif other_condition:
        # execute this code - only checked if last statement is false
    else: # when all other statements are false
        # execute this code
    ```

* **Iterable** - can iterate over an object, such as items in a list, characters in a string, keys in dictionaries, etc.

* **For loops** are used to iterate over objects:
  
  * ```python
    mylist = [1,2,3]
    for item in mylist:
        # execute this code
    ```

* The variable name (item) can be any chosen name

* We use for loops for tuple unpacking by duplicating the structure of the tuple:
  
  * ```python
    mylist = [(1,2),(3,4)]
    for a,b in mylist:
        print(b)
    # result: 2 4
    dict = {'k1': 1, 'k2' : 2}
    for key,value in dict.items():
        print(key)
    # result: 'k1' 'k2'
    ```

* By default, when iterating through a dictionary it will only print out the key. So we use the `.items()` method and tuple unpacking to return values as well

* **While loops** continue to execute a block of code while a statement is true:
  
  * ```python
    while condition:
        # execute code until condition is false
    #execute code once condition is false
    ```

* `x += 1` - shorthand for `x = x + 1`

* We can use break, continue and pass keywords in loops:
  
  * **break** - breaks out of current enclosing loop
  
  * **continue** - goes to top of current enclosing loop
  
  * **pass** - do nothing - use as a placeholder for indentation to avoid syntax error

* We can use the `range(start:stop:step)` method to specify a range 

* This can be used with a for loop to print out numbers:
  
  * ```python
    for num in range(0,11,2):
        print(num)
    # result: 0 2 4 6 8 10
    ```

* We can use the `enumerate(method)` method to count while iterating over an object:
  
  * ```python
    word = 'abc'
    for item in enumerate(word):
        print(item)
    # result: (0,'a') (1,'b') (2,'c')
    ```

* This returns a tuple, which can then be unpacked

* We can use the `zip()` method to merge lists together as tuples:
  
  * ```python
    mylist1 = [1,2,3]
    mylist2 = ['a','b','c']
    for item in zip(mylist1,mylist2):
        print(item)
    # result: (1,'a') (2,'b') (3,'c')
    ```

* Zip can only merge together up to the equal length of all lists

* We can use the `in` keyword to check if an item is in a list, a char is in a string, a key is in a dictionary, etc.
  
  * ```python
    'x' in [1,2,3]
    # result: False
    ```

* We also have a `min(mylist)` and `max(mylist)` method to check the minimum/maximum value in a list

* We can import functions from the**random** library by using:
  
  * ```python
    from random import library
    ```

* There are multiple functions in random that can be used, such as **randint** to specify a random integer:
  
  * ```python
    from random import randint
    x = randint(startint, endint)
    ```

* For user input we use the keyword `input('Phrase for user')`. Accepts everything that is passed in as a string. This can then be cast to the type we want:
  
  * ```python
    x = int(input('input a number'))
    ```

* **List comprehensions** are a unique way of quickly creating a list. Instead of a for loop and the append method:
  
  * ```python
    mystring = 'hello'
    mylist = [letter for letter in mystring]
    #result: ['h','e','l','l','o']
    ```

* This is essentially a flattened out for loop

* We can also perform operations on the first variable in the loop if needed:
  
  * ```python
    mylist = [num*2 for num in range(3)]
    # result: [0,2,4,6]
    ```

* We can also add if statements:
  
  * ```python
    mylist = [num for num in range(0,5) if num % 2 == 0]
    # result: [0,2,4]
    ```

### Methods

* Functions that are built into objects (methods)

* Press `.` then tab after defining a variable to see the available functions for that variable type

* Then press shift + tab to check the documentation for that function

* Functions allow us to execute a block of code without having to write it out several times

* The `def` keyword allows us to create a function. We also need correct indentation. Snake casing is common practice for naming functions:
  
  * ```python
    def name_of_function():
        '''
        Multi-line comment code - explains function
        '''
        # code to execute everytime the function is called
    ```

* We can also pass in a parameter to the function within the parentheses `(parameter_name)`

* Typically, we use the return keyword to send back the result of the function. This can then be saved to a variable to be used later
  
  * ```python
    def name_of_function():
        return 'hello'
    x = name_of_function()
    # result: x = 'hello'
    ```

* We can provide a default value to the functions parameter:
  
  * ```python
    def name_of_function(parameter='Hello'):
    ```

* We can use the `pass` keyword, instead of return, in cases where we don't want to return anything

* Functions can return **tuples**, which can then be unpacked:
  
  * ```python
    def function():
        return (variable_one, variable_two)
    v1, v2 = function()
    ```

* `*args` - arguments - allow us to set an arbitrary number of parameters in a function:
  
  * ```python
    def myfuunc(*args):
        return sum(args)
    ```

* Can pass in as many parameters as they want, and it will be treates as a tuple

* `**kwargs` - key word arguments - builds a dictionary of key/value pairs:
  
  * ```python
    def myfunc(**kwargs):
        if 'fruit' in kwargs:
            print(kwargs['fruit'])
    myfunc(veggie = 'pepper', fruit = 'melon', food = 'donut')
    # result: 'melon'
    ```

### Lambda Expressions

* We can use the `map(function, list)` method to run a method on every item in a list:
  
  * ```python
    for item in map(function,list):
        print(item)
    # returns each result of function
    ```

* The `filter()` function returns items in a list based on the result of the specified funtion. The specified function must either return True or False:
  
  * ```python
    for n in filter(function, list):
        print(n)
    # returns only the items that return true in the function
    ```

* A **lambda expression** is an anonymous function that is only used one time:
  
  * ```python
    variable = lambda parameter: parameter ** 2
    # Same as function:
    def squared(num):
        return num ** 2
    ```

* These lambda expressions can be used directly in map or filter functions:
  
  * ```python
    list(map(lambda num:num ** 2, list))
    # returns a list of the numbers in the previously defined list, squared
    ```

### Scope

* The **Scope** determines the visibility of variables within code

* **LEGB rule** - order to look for variables:
  
  * **Local** - names assigned in a function
  
  * **Enclosing function locals** - names in scope of any enclosing functions
  
  * **Global** - names assigned at the top-level of a module file
  
  * **Built-in** - pre-assigned names from Python

* We can use the `global` keyword within a function to globally re-assign variables:
  
  * ```python
    x = 50
    def func():
        global x
        x = 'New'
    print(x)
    # result: 50
    func()
    print(x)
    # result: 'New'
    ```

## 3. Wednesday

### Validating User Input

* We need to further validate user input to avoid conversion errors:
  
  * ```python
    choice = 'false' # set user input to a non-number to access the while loop
    value = range(0,10) # pre-define user values to accept
    in_value = False # set users choice to not in values to accept to access while loop
    while choice.isdigit() == False or in_value == False:
        choice = input("Enter a number: ") # take user input
        if choice.isdigit(): # if user input is not a digit, ask for input again
            if int(choice) in value: # if user input is a digit that is not in values to accept, ask again
                in_value = True
    return int(choice)
    ```

### Object Oriented Programming

* **OOP** creates code that is repeatable and organised

* The `class` keyword is used to create the class (object):
  
  * ```python
    class ClassName(): # parentheses are not required, unless inheritance is required
    ```

* By convention, classes use CamelCasing

* We then create an instance of the class using an `init` method, and the `self` keyword:
  
  * ```python
    def __init__(self, param1, param2):
        self.param1 = param1
        self.param2 = param2
    ```

* An **instance** is a particular object created from that class

* By convention, the parameter names are the same as the self. variable names

* The `self` keyword lets the system know it is a method defined for that class, and lets it refer to itself

* **Attributes** are characteristics of the object

* These can later be called on when an instance of the object is created

* When we create an instance of that class we then need to define the attributes:
  
  * ```python
    this_class = ClassName(param1 = 1, param2 = 2)
    ```

* **Class object attributes** are defined above the instance method. These attributes will be the same for any instance of the the class created:
  
  * ```python
    class ClassName():
        my_attribute = 'word'
    ```

* These can be called on from within methods of that class using `self.my_attribute`, or more commonly `ClassName.my_attribute`

* **Class methods** are available to run operations on that class object, and use the `self` keyword within the parameter list:
  
  * ```python
    def class_method(self):
        print(self.param1)
    ```

* When we call attributes we do not need the `()` after the attribute as they simply return their value, however when calling a class method we do, as they do something specific to the object

* The methods can reference attributes in the object using `self.attribute_name`

* If a user is providing a parameter in the method call, then this parameter can be used within that method without the `self` keyword

#### Inheritance and Polymorphism

* Newly formed classes can **inherit** from features in other classes
  
  * ```python
    class NewClass(ClassToInheritFrom):
        def __init__(self):
            ClassToInheritFrom.__init__(self)
    ```

* All the methods in the base class with then be available for the subclass

* To overwrite a method, we just define the same method in the new class

* When we add methods to the subclass, they will not be available to the class we are inheriting from (base class)

* **Polymorphism** refers to the way in which different object classes can share the same method name. These can then be called in the same place on different objects, but with unique outcomes, depending on the type of object they are

* We can create a base class, that we never expect to create an instance of, to share methods with other classes. We would raise an error on the methods in the base class to ensure it is defined in the subclass:
  
  * ```python
    def my_method(self):
        raise NotImplementedError("Subclass must implement this abstract method")
    ```

### Special Methods

* Using built-in functions on user-defined objects (**Magic**/**Dunder**)
  
  * ```python
    def __str__(self):
        return 'This string'
    ```

* Calls this method for any functions that require a string representation of the object to be returned
  
  * ```python
    def __len__(self):
        return len(self.variable)
    ```

* Calls this method to calculate the length of the object
  
  * ```python
    def __del__(self):
        print('This object has been deleted')
    ```

* Calls this method to delete the instance of the object

### Modules and Packages

* **PyPI** - A repository for open-source third-party packages

* We can install these packages through the command line:
  
  * `pip install PackageName`

* Colorama is a package that allows you to incorporate colour at the command line:

        `python`

        `from colorama import init`

        `init()`

        `from colorama inport Fore`

        `print(Fore.GREEN + "some green text")` - displays the specified text in green

        `quit()` - quits the current Python session

* **Modules** are .py scripts that can be called in another .py script

* **Packages** are a collection of modules

* To create a module, we create the .py script, and then call it in another one:
  
  * ```python
    from mymodule import mymethod
    ```

* We then need to create a folder for the package, with folders for subpackages inside. We need to let Python know these folders are packages. Within each folder we need to create a file called **_\_init\_\_.py**\.

* To import from a package:
  
  * ```python
    from MainPackageName import somescript
    # or import a script within a folder
    from MainPackageName.SubFolderName import somescript
    # call methods within scripts
    somescript.methodname()
    ```

* Implicitly all code at the first indentation level is ran when the .py script is ran

* `if __name__ == "__main__"` means the .py file is being ran directly (from command line), otherwise it is being imported

## 4. Thursday

### Exception Handling

* **Error handling** is used to plan for potential errors that occur in the future

* Three key words are used to handle the error:
  
  * **try** - block of code to be attempted
  
  * **except** - execute if there is an error in try block
  
  * **finally** - executed regardless of error

* **TypeError** - cannot run statement on two different data types
  
  * ```python
    def add(num1, num2):
        try:
            result = num1 + num2
        except TypeError:
            print('There was a TypeError')
        else: # if no error
            print('Added correctly')
            print(result)
        finally:
            print('This message always prints')
    ```

* If we do not specify the exception type, it will run the except block for any exception

* We can add multiple except blocks to catch different exceptions, as specified

* We can use a while loop to continually try a block of code, until no exception occurs:
  
  * ```python
    while True:
        try:
            result = int(input('input number: '))
        except:
            print('Not a number')
            continue
        else:
            print('That is correct')
            break # breaks out of while block - could also use a variable instead
        finally:
            print('End of try/except/finally attempt')
    ```

### Unit Testing

* There are several testing tools:
  
  * **pylint** - a library that looks at your code and reports back possible issues
  
  * **unittest** - built-in library allows you to test a program and check it provides the desired result

* Pylint first needs to be installed on the command line:
  
  * `pip install pylint`

* After creating a .py script we can then run this script with pylint to check for error, using the command line at the file location:
  
  * `Python -m pylint simple.py -r y`

* This returns statistics based on the code design, as well as any error messages. The final line provides a rating for the code

* **unittest** - allows us to write our own test programs

* First we need to import unittest and then import the file we are testing

* We then need to create a test class that inherits testcase methods from unittest:
  
  * ```python
    class TestCap(unittest.TestCase):
    ```

* We then need to create a method for each test:
  
  * ```python
    def test_one_word(self):
        # set the variable to pass into the method to test
        text = 'python'
        # set the result as running the function from the program to test
        result = cap.cap_text(text)
        # Assert - check the result of running the method matches expected result
        self.assertEqual(result, 'Python')
    ```

* We then need to end the class with the name/main statement to run the unittest main method:
  
  * ```python
    if __name__ == '__main__':
        unittest.main()
    ```

* We can then run the test .py script through the command line `python test_script.py` and this will return the results of the test, and where any failures occurred

### Decorators

* Allows you to decorate a function - add new funtionality to an existing function for certain occassions

* Uses the `@` operator on top of the function to decorate

* Functions are objects that can be passed into other objects/variables

* If functions are written inside other functions, then their scope is limited to the function they are written in

* We can make the function return a function that is defined within it. This can then be assigned to a variable so it can be called on outside of the function:
  
  * ```python
    def my_func():
        def my_func2():
            return('This is my func 2')
        return myfunc2
    internal_func = myfunc()
    print(internal_func())
    # result: 'This is my func 2'
    ```

* We use this method of wrapping functions inside other functions to create the decorator, by using the `@new_func` on-top of the original function that we want to add functionality to:
  
  * ```python
    @new_decorator_func
    def original_func():
        # code to execute
    
    def new_decorator_func(original_func):
        def wrap_func():
            # execute some code
            original_func() # call original function that is passed through
        return wrap_func
    ```

### Generators

* Allows us to write a function that returns a value and then can later resume where it left off

* Uses the `yield` keyword

* **Generator functions** suspend and resume execution and their state around the last point of value generation

* The `range()` method is an example of a generator

* This is beneficial when we do not need previous values to be stored in memory
  
  * ```python
    def create_cubes(n):
        for x in range(n):
            yield x ** 3
    ```

* Calling the method will not return the items, but a generator object, as it is not stored in memory. If we needed it, we would cast the method to a list. Or we simply print them out as ther are returned, one at a time

* If we assign the method to a variable, we can then use the `next(variable)` method to check each subsequent result of calling the method

* We can also use the `iter()` method on iterable items (strings, lists, etc.) to turn them into iterators so we can then iterate through using `next()`:
  
  * ```python
    word = 'hello'
    iter_word = iter(word)
    next(iter_word)
    # result: 'h'
    next(iter_word)
    # result: 'e'
    ```

### Advanced Python Modules

#### Collections Module

* Alternatives to Pythons built-in list containers
  
  * `import collections`

* **Counter** - keeps track of the instances of values in a list:
  
  * ```python
    mylist = ['a','a',10,10,10]
    Counter(mylist)
    # result: Counter({'a' : 2, 10 : 3})
    ```

* They have similar methods to dictionaries, but include further methods such as `.most_common(numberOfMostCommonKeys)` - displays the most common keys up to the number of keys specified, and how many times they occur

* **defaultdict** - assigns a default value, where there is an instance in which a key is not currently available in a list:
  
  * ```python
    d = defaultdict(lambda: 0)
    # call a key that is not available
    d['wrong key']
    # creates key and assigns default value to 0
    ```

* **namedtuple** - expands on a normal tuple by assigning a name to an index:
  
  * ```python
    Dog = namedtuple('Dog',['age','breed','name'])
    ```

* Works similar to creating a new object

* We can then call on each attribute in the tuple, depending on the name assigned to the tuple

#### Opening and Reading Files and Folders

* **Shutil** and **OS** - allow us to navigate files and directories, and perform actions on them
  
  * `import os`

* Can be used to return the current working directory:
  
  * ```python
    os.getcwd()
    # returns the path of the current working directory
    ```

* We can list everything in our current directory:
  
  * ```python
    os.listdir()
    # can also pass in a file path as a parameter to return that directory
    ```
  
  * `import shutil`

* We can use shutil to move files from current working directory:
  
  * ```python
    shutil.move('filename.txt',pathToMoveTo)
    ```

* We have multiple methods to delete (CAN NOT BE REVERSED):
  
  * `os.unlink(path)` - deletes a file at the path
  
  * `os.rmdir(path)` - deletes a folder (must be empty)
  
  * `shutil.rmtree(path)` - removes all files and folders

* There is an alternative external package **send2trash** which does not permanently delete:
  
  * `pip install send2trash`

* We can then use this in Python:
  
  * ```python
    import send2trash
    send2trash.send2trash('filename.txt')
    # sends file in current directory to trash
    ```

* We can also return the tree of a directory using `os.walk()`:
  
  * ```python
    # using tuple unpacking
    for folder, sub_folders, files in os.walk('path'):
        print(folder)
        for sub_fold in sub_folders:
            print(sub_fold)
        for f in files:
            print(f)
    ```

#### Datetime Module

* `import datetime`

* We can return the time as an object using `.time()`. We only need to specify the time parameters we require, starting at hours and down to microseconds:
  
  * ```python
    mytime = datetime(13,20,10)
    ```

* We can then use this to get the information of each time segment, such as `.hour`, to return the hour from the specified time variable

* We can also return the date - we can specify a date, or take the current date:
  
  * ```python
    today = datetime.date.today()
    # format: YYYY-MM-DD
    ```

* We can then call the individual attributes, such as `.month`

* We can also get information that returns both date and time:
  
  * ```python
    mydatetime = datetime.datetime(2022,10,3,14,20,10)
    # result: 2022-10-03 14:20:10
    ```

* Many methods are available, such as `.replace()`, to replace certain elements:
  
  * ```python
    mydatetime.replace(year=2020)
    ```

* Comparing date objects will return the difference in days:
  
  * ```python
    date1 = date(2021,11,3)
    date2 = date(2020,11,3)
    result = date1 - date2
    # result: 365 - type(result) = datetime.timedelta
    ```

* We can do the same with datetime objects, this will return total days and total seconds

* We can also perform multiple methods on the results to drill down further

#### Math and Random Modules

* `import math`

* We can round numbers in multiple ways:
  
  * ```python
    math.floor(value) # round down
    math.ceil(value) # round up
    round(value) # true rounding - can specify the number of decimal places
    ```

* We can also return attributes, such as `math.pi`

* `import random`

* Returns pseudorandom numbers

* If we are testing random numbers we would use a seed - returns the same sequence of pseudorandom numbers:
  
  * ```python
    random.seed(101) # the seed number does not matter - as long as we know the expected results
    random.randint(0,100) # will always return 74 first, then 24 second, and so on
    ```

* We can randomly pick a number x amount of times:
  
  * ```python
    random.choices(population=alist, k=numOfChoices) # with replacement
    random.sample(population=alist, k=numOfChoices) # without replacement
    ```

#### Python Debugger

* A built-in debugger tool to explore code as it runs

* We set trace using `pdb`:
  
  * ```python
    import pdb
    x = 2
    pdb.set_trace() # checking the value of x at this time will return 2
    x = 'a'
    ```

* It allows us to use an interactive environment to explore and call variables. We type in the variable name, and it will return the result at that time

* Type in `q` in the debugger to quit the debugger tool and continue on in the code

#### Regular Expressions

* Used to search for pattern structures in text data

* Python includes a built-in regular expression library:
  
  * `import re`

* The start of the string begins with `r`, followed by the different types of identifiers and exact string elements within the string:
  
  * ```python
    r"(\d{3})-\d{3}-\d{4}"
    # Example: (555)-123-1234
    ```

* We can search for patterns in variables using `re.search(pattern,text)`. This will return the span for the index of the start element and end element, including the matching text that was found

* This will only find the first match. If we want multiple, we would use the `re.findall(pattern,text)` method, which will return a list of the matching text

* We can use the `re.finditer(pattern,text)`, which can be used with a for loop to return multiple properties using the methods from that object:
  
  * ```python
    for matcher in re.finditer(pattern, text):
        print(matcher.group())
    ```

* Identifier syntax:
  
  * **\d** - a digit
  
  * **\w** - alphanumeric
  
  * **\s** - whitespace
  
  * **\D** - non-digit
  
  * **\W** - non-alphanumeric
  
  * **\S** - non-whitespace

* Quantifier syntax:
  
  * **+** - occurs one or more times
  
  * **{n}** - occurs exactly n times
  
  * **{n,x}** - occurs between n and x times
  
  * **{n,}** - occurs n or more times
  
  * **\*** - occurs zero or more times
  
  * **?** - occurs one or none times

* We can compile together different regular expressions using `re.compile()`, and each expression is within parantheses. We can then later call the individual group, starting at index 1:
  
  * ```python
    text = 555-123-4567
    pattern = re.compile(r'(\d{3})-(\d{3})-(\d{4})’)
    result = re.search(pattern,text)
    result.group() # returns: 555-123-4567
    result.group(2) # returns 123
    ```

* We can use operators to search for different results within a regex function:
  
  * **|** - or `(r’c|d’)` - finds any c or d
  * **.** - wildcard `(r'.at)` - counts any one character before
  * **^** - starts with `(r'^\d')` - find if the string starts with a number
  * **\$** - ends with
  * **[^]** - exclude - returns everything that isn't in the braces next to ^#

#### Timing Code

* Use the **timeit** module - allows us to see how efficient the code is - specifically designed for timing code
  
  * ```python
    import timeit
    timeit.timeit(stmt=functionCall, setup=theFunction, number=numberOfTimesToRun)
    ```

* The function call and the setup both need to be passed in as a string, so we need to use multi-line strings to create the variables:
  
  * ```python
    stmt = '''
    myfunc(100)
    '''
    setup = '''
    def my_func(n):
        return[str(num) for num in range(n)]
    '''
    timeit.timeit(stmt,setup,number=100000)
    # return time it took to run in seconds
    ```

#### Zipping and Unzipping Files

* `import zipfile` - creates the zipfiles and writes the file into it:
  
  * ```python
    comp_file = zipfile.ZipFile('newzipfilename.zip','w') # w to write to zipfile
    comp_file.write('filetozip.txt', compress_type=zipfile.ZIP_DEFLATED)
    # multiple writes can be completed to add multiple files to the zip
    comp_file.close() # closes the created zipfile
    ```

* We can also unzip:
  
  * ```python
    zip_obj = zipfile.ZipFile('filetounzipname.zip','r') # r to read from zip
    zip_obj.extractall('newFolderToExtractTo') # extracts files to new folder in cwd
    ```

* To zip an entire folder it is better to use `shutil`:
  
  * ```python
    import shutil
    output_filename = 'newFolderToZipTo'
    shutil.make_archive(output_filename,'zip','filePathOfFolderToZip') # zip is the format
    ```

* To unzip:
  
  * ```python
    shutil.unpack_archive('filePathOfFolderToUnzip','nameOfTheFolderToUnzip','zip')
    ```

## 5. Friday

### Web Scraping

* Techniques involving automating the gathering of data from a website

* Web scraping scripts are static as websites are different from each other, and can change frequently

* To web scrape with Python we can use the external libraried **requests** and **beautifulsoup**:
  
  * `pip install requests` - allows us to make requests to a website
  
  * `pip install lxml` - used with beautifulsoup library to decipher the html response
  
  * `pip install beautifulsoup` - allows us to find html/css elements

* The we need to import the libraries to Python:
  
  * ```python
    import requests
    import bs4
    ```

* To get the webpage we use requests:
  
  * ```python
    result = requests.get('url')
    ```

* This returns the html response as a string. We then need to parse this string with beautifulsoup:
  
  * ```python
    soup = bs4.BeautifulSoup(result.text, 'lxml') # convert response to xml
    ```

* We can then grab elements using the `.select()` method:
  
  * ```python
    soup.select(element)
    # returns a list of all elements of that type
    ```

* This can then be chained together with ither methods to grab the information required:
  
  * ```python
    soup.select(element)[index].getText()
    # returns the text of the first element in the list of that type
    ```

* Syntax to select different types of elements:
  
  * `.select('div')` - all elements with specified tag
  
  * `.select('#some_id')` - all elements containing that id
  
  * `.select('.some_class')` - all elements containing that class
  
  * `.select('div span')` - any (span) tag within any layer inside a (div) tag
  
  * `.select('div > span')` - any (span) tag directly in top layer of a (div) tag

* We can assign the selected tag to a variable, and then every attribute within the tag is treated as a dictionary, so we can search for them individually:
  
  * ```python
    myimage = soup.select('.image')[0] # returns first element with image class name
    class_name = myimage['class'] # returns the class name of the image
    image_link = myimage['src'] # would return the source of the image - link
    ```

* If you are selecting a class call that has a space in it, we need to remove the space and put a dot instead:
  
  * ```python
    class = "star-rating Three"
    soup.select('star-rating.Three')
    ```

### Images

* We can use the **Pillow** library to work with images in Python:
  
  * `pip install pillow`

* We then import this from the built-in Python class PIL:
  
  * ```python
    from PIL import image
    ```

* We can assign the image file to a variable to open the image:
  
  * ```python
    myimage = Image.open(‘imagefile.jpg’)
    ```

* We can get the size of the image by calling:
  
  * ```python
    myimage.size
    # returns image in pixels(xAxisSize, yAxisSize)
    ```

* We can resize the image where needed using the `.resize(xAxisSize, yAxisSize)` method

* We can crop images using the `.crop(startxaxis,startyaxis,width,height)` method:
  
  * ```python
    myimage.crop(0,0,100,100)
    # returns the image cropped from the top left corner, 100x100pixels in size
    ```

* We can change the transparency of images with the `.putalpha()` method:
  
  * ```python
    myimage.putalpha(128)
    # 0 is completely transparent, 256 is completely opaque
    ```

* We can paste images on top of other images using `.paste(im=imageToPaste,box=(whereToPaste), mask=imageToPaste)`:
  
  * ```python
    myimage.paste(im=newimage, box(0,0), mask=newimage)
    # pastes the new image starting in the top left corner of old image
    ```

* We can then save the edited image:
  
  * ```python
    myimage.save(‘path/nameoffiletosaveas.jpg’)
    # overwrites file if name already exists
    ```

#### PDFs and CSV Files

* **CSV** – comma separated variables – an output for spreadsheet programs (only contains raw data)

* Python includes a built-in **csv** module to grab rows, columns and values, and write to .csv files:
  
  * `import csv`

* To open and reformat a csv file to a python object list:
  
  * ```python
    data = open(‘filename.csv’, encoding=’utf-8’) # encoding says what types of characters to read
    csv_data = csv.reader(data) # reads all data in file
    data_lines = list(csv_data) # assigns each line to a list within a list 
    ```

* Each element in the list is a cell within the spreadsheet. If we wanted to return a specific column, we can get the index of that column, and return each row for that column:
  
  * ```python
    all_column = [] # empty list to add all element of that column
    for line in data_lines[1:]: # miss the title row, and go to the end
        all_column.append(line[indexOfColum])
    ```

* We can also write to csv files:
  
  * ```python
    file_to_write = open(‘newFileName.csv’, mode=’w’, newline=’’) # can also use mode = ‘a’ to append to existing file
    csv_writer = csv.writer(file_to_write, delimiter=’,’) # to separate columns use ,
    csv_writer.writerow([‘a’, ‘b’, ‘c’]) # writes a single row
    csv_writer.writerows([‘a’, ‘b’, ‘c’] ,[‘1’, ‘2’, ‘3’]) # write multiple rows. Needs to be the same length of any previous row that has been added
    file_to_write.close() # need to close the file to save
    ```

* **PDF** – Portable Document Format – A lot of PDFs are not readable, and we can generally only read, not write

* An external library **PyPDF2** is a free PDF reader:
  
  * `pip install PyPDF2`

* To open and read a PDF:
  
  * ```python
    import PyPDF2
    file = open(‘filename.pdf’, ‘rb’) # rb – read binary file
    pdf_reader = PyPDF2.PdfFileReader(file)
    pdf_reader.numPages # returns number of pages in pdf
    first_page = pdf_reader.getPage(0) # gets first page of pdf
    first_page_text = first_page.extractText() # extracts text as a string 
    file.close() # close file 
    ```

#### Emails

* We can send and receive emails programmatically with Python

* The built-in **smtplib** library in Python includes all the function calls we need to connect to a server and send emails. SMTP is the server domain name:
  
  * ```python
    import smtplib
    smtp_obj = smtplib.SMTP(‘smtp.gmail.com’, 587) # the server domain for the email provider and a port number to connect on
    smtp_obj.ehlo # greet server and establish connection
    smtp_obj.starttls() # used to decrypt the response
    email = #userinput
    password = #userinput
    smtp_obj.login(email,password)
    # We can then generate an email to send
    from_address = email
    to_address = ‘anemail’
    subject = #userinput
    message = #userinput
    msg = ‘Subject: ‘ + subject + ‘\n’ + message #requires this format to correctly send
    smtp_obj.sendmail(from_address, to_address, msg)
    # if we receive an empty dict back, it was successful
    smtp_obj.quit() # close the access
    ```

* We generate app passwords, instead of using real passwords for security purposes in gmail.

* It is generally better to take user input for the password so it is not stored in the script. We can use the **getpass**library to get a (\*\*\*\*) blank password input, so it cannot be seen on screen:
  
  * ```python
    import getpass
    password = getpass.getpass(‘Input password: ‘)
    ```


