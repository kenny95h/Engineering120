# Week 6: 01/08 - 05/08

**1.** [Monday](##1. Monday) - Lambda Expressions

**2.** [Tuesday](##2. Tuesday) - Serialisation, Asynchronous Programming & APIs

**3.** [Wednesday](##3. Wednesday) - API Testing

**4.** [Thursday](##4. Thursday) - 

**5.** [Friday](##5. Friday) - 

## 1. Monday

### Lambda Expressions

* **LINQ**(Language Integrated Query) is used to query databases and datasets:
  
  * They have no name
  
  * Declared at the place it is used
  
  * Cannot be reused anywhere else
  
  * Type of parameters are inferred from context

* **IEnumerable** is used to iterate over a collection

* Query keywords:
  
  * **.Sum(method that returns a number)**
  
  * **.Where(method that returns a bool)**
  
  * **.OrderBy(method which returns a key)**
  
  * **.Sum(method that returns a bool)**
  
  * **.Count(method that returns a bool)**

* An anonymous method is written with the keyword **delegate**. This cannot be used elsewhere:
  
  * ```csharp
    nums.Count(delegate (int n) {return n % 2 == 0});
    ```

* Do not use anonymous methods. Use **lambdas** instead:
  
  * ```csharp
    nums.Count(x => x % 2 == 0);
    ```

* **.Select** is used to return the query as a certain type

* LINQ queries are always executed once the variable is iterated over, not when the query variable is created.

* Lambdas can also be used to write inline methods as one line:
  
  * ```csharp
    public override string ToString() => $"{variable} string";
    ```



## 2. Tuesday

### Serialisation

* **Serialisation** is the process of converting an object to a stream of bytes to be stored somewhere.

* To make an object serialisable we need to add the serialisable tag above the class:
  
  * ```csharp
    [Serializable]
    public class ClassName
    ```

* Nullable value types represent undefined values of an underlying value type

* If we want the value to retuen as null, when not initialised, we use the **?** symbol after the datatype

* The **<T>** tag is a generic type. When used within the method signature it means you have to specify the type when calling the method and creates a generic method:
  
  * ```csharp
    public void SerialiseToFile<T>(string filePath, T item){}
    ```

* We need to create and open a stream first, then create a serialiser using a formatter type, serialise the object, then close the stream:





## 3. Wednesday

## 4. Thursday

## 5. Friday
