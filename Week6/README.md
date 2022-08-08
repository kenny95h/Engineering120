# Week 6: 01/08 - 05/08

**1.** [Monday](##1. Monday) - Lambda Expressions

**2.** [Tuesday](##2. Tuesday) - Serialisation, Asynchronous Programming & APIs

**3.** [Wednesday](##3. Wednesday) - API Testing

**4.** [Thursday](##4. Thursday) - API Test Strategy 

**5.** [Friday](##5. Friday) - Defect Management

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
  
  * ```csharp
    // Stream or FileStream created and opened
    FileStream filestream = File.Create(filePath);
    //Create a BinaryFormatter object and use it to serialise the item to file
    BinaryFormatter writer = new BinaryFormatter();
    //Serialise
    writer.Serialize(filestream, item);
    filestream.Close();
    ```

* We can then call this method to serialise an object. The type is inferred by the parameter so it does not need to be specified:
  
  * ```csharp
    var serialiser = new SerialiserBinary();
    serialiser.SerialiseToFile($"{_path}/BinaryTrainee.bin", trainee);
    ```

* We use a deserialiser to convert the serialised object back to the original object state:
  
  * ```csharp
    public T DeserialiseFromFile<T>(string filePath)
    {
        //Create a stream object for reading
        Stream fileStream = File.OpenRead(filePath);
        BinaryFormatter reader = new BinaryFormatter();
        //Cast deserialised object to T
        var deserialisedItem = (T)reader.Deserialize(fileStream);
        fileStream.Close();
        return deserialisedItem;
    }
    ```

* The deserialiser method can then be called to return the object. We need to specify the type as it is not inferred:
  
  * ```csharp
    Trainee deserialisedObject = serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryTrainee.bin");
    ```

* We can use this technique for different types of serialiser including:
  
  * `XmlSerializer` - `using System.Xml.Serialization;`
  
  * `JsonConvert` - `using Newtonsoft.Json;` - Need to download in Nuget Packages

* The `JsonConvert` method is serialised using the methods:
  
  * ```csharp
    public T DeserialiseFromFile<T>(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
    
    public void SerialiseToFile<T>(string filePath, T item)
    {
        string jsonString = JsonConvert.SerializeObject(item);
        File.WriteAllText(filePath, jsonString);
    }
    ```

* We can specify a field that we do not want to serialise:
  
  * ```csharp
    [field:NonSearialized]
    private readonly DateTime _lastRead;
    ```

* We can use the JSON package to ignore properties where needed by adding a `JsonIgnore` tag above the property:
  
  * ```csharp
    [JsonIgnore]
    public string FullName => $"{FirstName} {LastName}";
    ```

### Asynchronous Programming

* **Threading** is different execution paths. More than one thread (multiple people)

* **Asynchronous programming** - when one process calls another process, they can both run at the same time. On one thread (multitasking)

* Allows multiple processes to run at the same time so can speed up operations and creates more efficient programs.

* We need to add the `async` keyword in the method signature to declare a method as asynchronous

* It is a convention to name the method ending with the word async

* The method will also need to have a return type `Task` for void, or `Task<DataType>` for returning methods:
  
  * ```csharp
    private static async Task<DataType> methodNameAsync(){}
    ```

* We use the `await` keyword to return back to the original method where this method was called from, while we are waiting for the task to complete. We can then use the `Task.Delay` method (`using System.Threading.Tasks;`) to put a delay on thr next call in the current method:
  
  * ```csharp
    await Task.Delay(TimeSpan.FromSeconds(5));
    ```

### APIs

* **APIs** (Application Programming Interface) allow programs to communicate with each other

* Web API:
  
  * Defined interface available over the web
  
  * Request-response message system
  
  * Most commonly on a HTTP-based server

* A server holds the information

* A client requests information (or asks for it to be creates, updated or deleted)

* Client sends a request to the server and receives a response

* Database -- Server -- API Gateway -- Internet -- Client

* HTTP protocol is used by APIs

* **CRUD** (**C**reate, **R**ead, **U**pdate, **D**elete) - operations typically performed on databases

* HTTP has a version of these operations:
  
  * GET - read
  
  * POST - create
  
  * PUT - update
  
  * PATCH - update
  
  * DELETE - delete

* HTTP status codes:
  
  * **1XX** - Informational
  
  * **2XX** - Success
  
  * **3XX** - Redirection
  
  * **4XX** - Client error
  
  * **5XX** - Server error

* **RESTful** Services (Representational State Transfer) - An architecture style for an API. If an API follows the architectural constraints, it is considered RESTful:
  
  * **Uniform interface** - identification of resources, manipulation through representation and self-descriptive messages. Hypermedia as the Engine of Application State (**HATEOAS**) - responses can contain links to other related resources
  
  * **Client-server**
  
  * **Stateless**
  
  * **Cacheable**
  
  * **Layered system**

* **Representation and Data Flow** - a representation of a resource that can be passed between client and server that is understandable by both (JSON/XML)

* HTTP response and request:
  
  * **HTTP Headers** - an extra set of instructions that are included with the request to the API, and about the information received from the API - Written as Key/Value pairs

* **Caching** - the concept of storing the generated results so they do not need to be generated repeatedly
  
  * Can be stored on the client, the server, or on a component between them
  
  * Header elements can be used to control caching by an expiration time, age, etc.



## 3. Wednesday

### API Testing

* **Restsharp** - REST API client library (`using RestSharp`) - download program

* The **rest client** object is created to make the authenticated HTTP request:
  
  * ```csharp
    var restClient = new RestClient("http://api.postcodes.io/");
    ```

* We then create a **RestRequest** object to set up the request to be executed:
  
  * ```csharp
    var restRequest = new RestRequest();
    ```

* The method request is defaulted as a GET request, and the header content-type is inferred:
  
  * ```csharp
    restRequest.AddHeader("Content-Type","application/Json");
    ```

* The resource is then appended to the uri for the request:
  
  * ```csharp
    var postcode = "EC2Y 5AS";
    restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";
    ```

* We then need to execute the request. We can run this asynchronously:
  
  * ```csharp
    var singlePostcodeResponse = await restClient.ExecuteAsync(restRequest;)
    ```
  
  * The client executes the request and it is stored within the variable

* The first thing to test when testing an API request is the response code

* **Status codes** are stored as enums with integer references. We can cast to an int to get the response code from the enum:
  
  * ```csharp
    (int)singlePostcodeResponse.StatusCode;
    ```

* Using the **NewtonSoft** library we can convert the response into a JSON object so it is easier to query:
  
  * ```csharp
    var singlePostcodeJsonResponse = JObject.Parse(singlePostcodeResponse.Content);
    // Query in [...] can be paired by using multiple [...]
    var adminDistrict = singlePostcodeJsonResponse["status"];
    ```

* When we have an array of different results in the JObject we need to specify the array index:
  
  * ```csharp
    var bulkAdminDistrict = bulkPostcodeJsonResponse["result"][0]["result"]["admin_district"];
    ```

* We can copy a full JSON file as a new class in Visual Studio by copying into new class document. Copy JSON text -- Edit -- Paste Special -- Paste JSON as classes.

* We can then deserialise this to a **C# Object**:
  
  * ```csharp
    var singlePostcodeObjectResponse = JsonConvert.DeserializeObject<singlePostcodeResponse>(singlePostcodeResponse.Content);
    ```

* **Config files** should never be added to a repo. Need to add into ignore file.

* **DLL** (Dynamic Link Libraries)
  
  * Testhost.dll.config files are stored by the system at runtime. What is being referenced when the tests are executed
  
  * Always ensure the file is copied to the output directory when modified. Right click on file -- properties -- copy to output directory -- change to copy always



## 4. Thursday

### API Test Strategy

* The API code should be covered by unit tests

* Test framework will be used for regression testing as well as pre-release

* What to test:
  
  * Correct response header
  
  * Correct response body
  
  * JSON has valid structure, correct field names, correct value types, correct values

* Non-functional tests:
  
  * Security and authorisation
  
  * Performance - Load/Stress tests
  
  * Usability - API documentation



## 5. Friday

### Defect Management

* Insufficient requirements could introduce errors in code

* Inexperienced teams

* Poor version control

* Level of software testing skill

* When we find a defect it enters the **defect lifecycle**:
  
  * New -- Assign -- Open (Rejected/Deferred/Duplicate/Can't Reproduce) -- Fix -- Test (Reopened) -- Verified -- Closed

* **Defect severity** - each user story has a rating - the degree of impact the defect has on the system if not fixed
  
  * Critical -- High -- Medium -- Low

* **Defect Priority** - more to do with business impact - how urgently it needs fixed

* Need consensus to decide on what makes a defect a certain level of severity/priority

* **Severity-Priority Matrix**:
  
  * Low Low - Cosmetic
  
  * High Low - impact on minor things, but user can still do work
  
  * Low High - Doesnt have high impact, but may be user unfriendly
  
  * High High - Data loss, Missing features, Security violation

* **Traceability** enables effective impact analysis. When a defect has been found, we can trace it back to the requirement it relates to and report this back to the stakeholder

* There are 3 types of **traceability matrix**:
  
  * Forward - maps requirements to test cases - ensures requirements are tested thoroughly
  
  * Backward - maps test cases to requirements - ensures no unnecessary features are developed
  
  * Bidirectional - maps both ways

* A **defect management commitee** is a cross-functional team of stakeholders who manage reported defects from detection to resolution:
  
  * Determine validity, actions to take, and priority/severity
  
  * Every action takes into account benefits, costs and risks


