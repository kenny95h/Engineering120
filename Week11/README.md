# Week 11: 05/09 - 09/09

**1.** [Monday](##1. Monday) - Postman and Acceptance Testing

**2.** [Tuesday](##2. Tuesday) - APIs

**3.** [Wednesday](3. Wednesday) - SQLite & SQLAlchemy with APIs

**4.** [Thursday](##4. Thursday) - Deploying Flask Apps

**5.** [Friday](##5. Friday) - Flask JWT Extended

## 1. Monday

### Postman

* An environment that can be used to access and test API functionality

* We can set up requests for all of the CRUD functionality of the API by selecting the CRUD method (GET/POST/DELETE etc.), and then inputting the URL, followed by the endpoint to run the API call

* For testing our API environment we can input `{{url}}` in the API call, and then set the environment by selecting a new environment, choosing URL and the value is the URL created by the API when the program runs

* We can write some tests in the tests tab in postman. The name of the test is assigned in `[]`, and this will then equal the test call (boolean check):
  
  * ```javascript
    tests["Response time is less than 200ms"] = responseTime < 200;
    ```

* We can also parse the JSON response into a JavaScript response body to run further tests on:
  
  * ```javascript
    var jsonData = JSON.parse(responseBody);
    tests["User created successfully"] = jsonData.message === 'User created successfully';
    ```

* We can also test the header of the response:
  
  * ```javascript
    tests["Content-Type is application/json"] = postman.getResponseHeader('Content-Type') === 'application/json'
    ```

* When using authentication we will receive an `access_token` that confirms he authorisation of any created users

* These tokens can then be added into the API calls headers as an authorisation key. This will be needed to access any API calls that require user access

* We can set an access token to automatically authenticate and re-use in the authorisation header through the postman test in the authorisation API call:
  
  * ```javascript
    var jsonData = JSON.parse(responseBody);
    postman.setEnvironmentVariable("access_token", jsonData.access_token);
    ```

* We can then add this `access_token` variable into any other API calls, by adding into the authorisation header `{{access_token}}`

* We can add a folder of requests to run sequentially in postman as a user journey. Once we have added the requests, in order, to a new folder, we can then open the postman runner along the bottom and drag in the folder to run

* We can include a number of iterations to run the tests, and a delay between each test if needed

* This will return the results of all API calls and test results

### Acceptance Testing

* This is system testing, but with a user journey. They are generally simplified as this is written from the point of view of the customer of the system

* They should be readable, easy to follow, and reusable

* We can use **BDD**(Behaviour Driven Development) in PyCharm by creating feature files. We need to install the Gherkin plugin first. Then we can add a `.feature` file to our test folder to create our Gherkin tests:
  
  * ```gherkin
    # title for the feature
    Feature: Test navigation between pages
    
    # a user journey to test
    Scenario: Homepage can go to blog
        Given I am on the homepage
        # anything in "" is passed in to the test step as a parameter
        When I click on the link id "blog-link"
        Then I am on the blog page
    ```

* The `Given... When... Then...` are the steps we need to take as part of the test. We can then use this scenario to create our test. We first need to create a new Python package called steps, and we create a `.py` file within steps that matches the feature file name

* To create the tests, we need to install the Selenium and Behave packages through the terminal, and then import them to our test:
  
  * ```python
    from behave import *
    from selenium import webdriver
    ```

* We can then create our test steps:
  
  * ```python
    use_step_matcher('re') # uses regex to match the Gherkin statements
    @given('I am on the homepage') # calls this test step each time this name is used in a scenario
    def step_impl(context):
        context.browser = webdriver.Chrome() # launches a Chrome window, and gives access through the variable
        context.browser.get('url') # navigate to webpage
    ```

* The `context` variable is passed to every step implementation. This allows us to pass variables between the steps where needed. This is done by chaining`context.` before the variable assignment

* For the Chrome Webdriver to work, we need to install a chromedriver matching the current Chrome version on they system, and put into PATH (C:\Windows\System32)

* There are multiple different methods available for finding html/css elements, but the most commonly used is for id tags. This is because they are unique. We can also use the step matcher regex to allow any text to be passed into the method:
  
  * ```python
    @when('I click on the link with id "(.*)"') # "(.*)" passes in any text as the parameter
    def step_impl(context, link_id):
        link = context.browser.find_element("id", link_id) # looks for and assigns element to variable
        link.click() # mimics clicking the element 
    ```

* To check we have accessed the relevant page, we would need to check the expected url matches the `context.browser` url, by calling the `current_url` method:
  
  * ```python
    @then('I am on the blog page')
    def step_impl(context):
        assert context.browser.current_url == expected_url
    ```

* We can use the **multirun** configuration by pressing edit configurations after running the app. Then creating a multirun configuration, we  and adding the app configuration and acceptance test configuration to the multirun. This will then run the app, followed by each of the tests so we do not have to manually load up each time

* We can re-use a step in any stage (Given/When/Then) by using @step in the step, instead of the stage

* We can also fing elements using the `By` keyword to specify the type of element we are searching for. To do this we first have to import the `By` method:
  
  * ```python
    from selenium.webdriver.common.by import By
    @then('There is a title shown on the page')
    def step_impl(context):
        title_tag = context.browser.find_element(By.TAG_NAME, 'h1')
        assert title_tag.is_displayed()
    ```

* Other elements types include:
  
  * **ID**
  
  * **NAME**
  
  * **XPATH**
  
  * **LINK_TEXT**
  
  * **PARTIAL_LINK_TEXT**
  
  * **CLASS_NAME**
  
  * **CSS_SELECTOR**

* For any method in a class that does not take any arguments, we can use the `@property` decorator to assign the method as a property. This way it can be called on like a variable

* We can refactor the program to use **POM**(Page Object Model) by including a locators package and a page_model package. This will make the project more reusable and extensible. The locators package is used to assign each element on a page to a variable:
  
  * ```python
    from selenium.webdriver.common.by import By
    class HomePageLocators:
        TITLE = By.TAG_NAME, 'h1'
        NAVIGATION_LINK = By.ID, 'blog-link'
    ```

* The element locator type and the element name are assigned to a variable as a tuple to be unpacked in the browser call

* We then use the page_model package to create property methods to find each element in the page using the driver:
  
  * ```python
    from tests.acceptance.locators.home_page import HomePageLocators
    class HomePage:
        def __init__(self, driver):
            self.driver = driver # assigns the webdriver that is provided at initialisation
    
        @property
        def url(self):
            return 'url'
        
        @property
        def title(self):
            return self.driver.find_element(*HomePageLocators.TITLE) # uses * to unpack locator tuple
    
        @property
        def blog_link(self):
            return self.driver.find_element(*HomePageLocators.NAVIGATION_LINK)
    ```

* We can then refactor tthe test to use the page model:
  
  * ```python
    from tests.acceptance.page_model.home_page import HomePage
    @then('There is a title shown on the page')
    def step_impl(context):
        page = HomePage(context.browser) # initialises the HomePage POM with the webdriver
        assert page.title.is_displayed()
    ```

* We can further refactor this by creating a base_page POM and locator package which is for those features that are identical for every page:
  
  * ```python
    from selenium.webdriver.common.by import By
    class BasePageLocators:
        TITLE = By.TAG_NAME, 'h1'
    ```

* We can then remove this variable from the `HomePageLocators` class, and then use this locator in the BasePage:
  
  * ```python
    from tests.acceptance.locators.base_page import BasePageLocators
    class BasePage:
        def __init__(self):
            self.driver = driver
        
        @property
        def url(self):
            return 'http://127.0.0.1:5000'
    
        @property
        def title(self):
            return self.driver.find_element(*BasePageLocators.TITLE)
    ```

* We can then remove the `init` method and the `title` method from the home page POM, and then simply make the HomePage inherit from the BasePage. Plus, we can then use the `super()` method in the `url` method to add on the endpoint required:
  
  * ```python
    @property
    def url(self):
        return super(HomePage, self).url + '/'
    ```

* This means we can then instantiate a base page in any relevant tests

* There are several reasons why it may take a while for parts of a webpage to load. As selenium relies on the page being loaded before it can find elements, it may be essential to wait for the page to load fully before the test continues, and looks for the specified elements:
  
  * ```python
    from selenium.webdriver.support.wait import WebDriverWait
    from selenium.webdriver.support import expected_conditions
    @given('I wait for the posts to load')
    def step_impl(context):
        WebDriverWait(context.driver, 5).until(
            expected_conditions.visibility_of_element_located(BlogPageLocators.POSTS_SECTION)
    )
    ```

* The `WebDriverWait()` method takes in the current window to wait on and maximum wait time. And the `until()` method checks for the condition to wait until, using the expected_conditions class

* We can use a **debugger** in PyCharm by selecting the space next to the line number, this will place a debug flag. We then press the debug button, and the program will run up until it reaches the line of code with the debug flag

* Once it has paused on this line, we can then inspect variables and step through the following lines of code, or continue the program as normal

* We can also chain locators and method calls with selenium. This can be useful when completing details in forms:
  
  * ```python
    @when('I enter "(.*)" in the "(.*)" field')
    def step_impl(context):
        page = NewPostPage(context.driver)
        page.form_field(field_name).send_keys(content)
    ```

* The `send_keys()` method is used to type into a field the specified text



## 2. Tuesday

### APIs

* A program that takes in some data and returns data as requested, after processing it

* A web server is a piece of software designed to accept incoming web requests

* Going to a set does a GET request:
  
  * GET        /        HTTP/1.1
  
  * verb   path      protocol

* The only difference is what the server on the other end responds with

* There are multiple different requests that can be sent to a server (POST/DELETE/PUT/HEAD, etc.), and each server will respond differently to each. But the meaning of the verb is the same:
  
  * **GET** - retrieve something
  
  * **POST** - receive data, and use it (such as, creating)
  
  * **PUT** - make sure something is there (such as, updating)
  
  * **DELETE** - remove something

* A **REST API** is a way of thinking about how a web server responds to requests. It responds with data and resources

* The server has these resources, and each is able to interact with the request

* The resource is the verb, path, and possible data being sent:
  
  * POST /item/chair extra data to send

* REST APIs are **stateless** - this means it does not rely on any previous requests

* We can use flask in Python to create an API:
  
  * ```python
    from flask import Flask
    app = Flask(__name__) # sets up new app
    ```

* We use the `@app.route` decorator to set the endpoint of the API request. By default, this is a GET request:
  
  * ```python
    @app.route('/') # the / is the default endpoint for homepage
    def home():
        # code to execute to display page
    ```

* We also have to run the app. We do this using the `run()` method, which takes in the port number for locally ran apps:
  
  * ```python
    app.run(port=5000)
    ```

* To change the request type:
  
  * ```python
    @app.route('/store', methods=['POST'])
    ```

* We can also pass in variables to endpoints to be used in the method with `<datatype:variable>`:
  
  * ```python
    @app.route('/store/<string:name>')
    def get_store(name):
        # code to executre with name variable
    ```

* When we want to get data from the API, it is returned in JSON and therefore we need a way of converting from a python dictionary to a string that can be read as JSON. We can do this using the `jsonify()` method:
  
  * ```python
    from flask import Flask, jsonify
    @app.route('/store')
    def get_store():
        return jsonify({'stores': stores}) # converting stores list, to a dictionary as this is the same syntax as JSON. 
    ```

* When we want to send JSON data as part of the request we can use the request package in flask to get this JSON data and append to our request:
  
  * ```python
    @app.route('/store/<string:name>/item', methods=['POST'])
    def create_item_in_store(name):
        request_data = request.get_json() # the request that was made to the endpoint, with the JSON body
        for store in stores:
            if store['name'] == name: # finding if the store exists
                new_item = { # adding the data from the JSON body
                    'name': request_data['name'],
                    'price': request_data['price']
                }
                store['items'].append(new_item)
                return jsonify(store) # returns the store detail with added item
        return jsonify({'message':'store not found'}) # return error if not found
    ```

* `Flask-RESTful` is an extension of `flask` to adhere to the REST API framework.

* We use the `Resource` and `Api` classes from the `flask_restful` library:
  
  * ```python
    from flask_restful import Resource, Api
    ```

* The `Api` allows us to easily add resources to it:
  
  * ```python
    app = Flask(__name__)
    api = Api(app)
    ```

* A resource respresents something our API will return, they are usually mapped into database tables. Every resource has to be a class, so the class needs to inherit from `Resource` to access and update the CRUD functionality:
  
  * ```python
    class Student(Resource):
        def get(self, name):
            return {'student': name}
    ```

* We then make the resource accessible via the API, and include the endpoint for that resource:
  
  * ```python
    api.add_resource(Student, '/student/<string:name>')
    ```

* When creating the API it is good practice to update the status code to correctly display. The default is 200:
  
  * ```python
    items = []
    class Item(Resource):
        def get(self, name):
            for item in items:
                if item['name'] == name:
                    return item
            return {'message': 'Item not found'}, 404 # updates status code
    ```

* With `flask_restful` the `jsonify()` method is no longer needed

* We can simplify this code further by using the `next()` and `filter()` methods, as well as a turnery operator for the status code:
  
  * ```python
    def get(self, name):
        item = next(filter(lambda x: x['name'] == name, items), None)
        return {'item': item}, 200 if item else 404
    ```

* The `filter()` method takes in a lambda statement to iterate through items. If the item exists, it adds it to the filter object. As we know it will only return 1 or none, then we use the `next()` method to return the first item in the filter object, or None if it doesn't to avoid an error

* We use a turnery operator for the status code to say if the item exists return 200, otherwise return 404



## 3. Wednesday

### SQLite with API

* We need to `import sqlite3` to allow us to connect to a database and run queries

* Then we need to initialise a connection:
  
  * ```python
    connection = sqlite3.connect('data.db') # name of db file
    ```

* We use the `cursor()` method to allow us to interact with the database:
  
  * ```python
    cursor = connection.cursor()
    ```

* We then need to write an SQL query to create a database table:
  
  * ```python
    create_table = "CREATE TABLE users (id int, username text, password text)" # creates the columns in the table
    cursor.execute(create_table) # runs the query
    ```

* When we run the query, it will create a new SQL database file with this table of specified column names

* We then need to insert data into the database:
  
  * ```python
    user = (1, 'bob', 'abcxyz')
    insert_query = "INSERT INTO users VALUES (?, ?, ?)" # each ? is for each value to insert
    cursor.execute(insert_query, users) # the cursor then assigns the values to the query
    ```

* We then need to tell the system to save the new data into the database:
  
  * ```python
    connection.commit()
    connection.close() # and close the database to prevent any loss of data integrity
    ```

* SQL allows us to create auto-incrementing columns, so each time we insert a row, it auto-assigns a value of the next increment:
  
  * ```python
    create_table = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, username text, password text)"
    ```

* To return an item, as this returns a table, we need to specify to only return the first row with the `fetchone()` method:
  
  * ```python
    @classmethod
    def find_by_id(cls, _id):
        connection = sqlite3.connect('data.db')
        cursor = connection.cursor()
        query - "SELECT * FROM users WHERE id=?" # the * returns all. Use the WHERE statement to return rows where a column value matches a specified parameter
        result = cursor.execute(query, (_id,)) # runs query with specified value. Must be a tuple
        row = result.fetchone() # only return the first row, as a tuple
        if row: # if a result is found
            user = cls(*row) # iterates through returned tuple, and assigns to new user
        else:
            user = None
        connection.close()
        return user
    ```

### SQLAlchemy with API

* We need to install flask alchemy first:
  
  * `pip install Flask_SQLAlchemy`

* We should create a new file to host the SQLAlchemy database, and import the SQLAlchemy object:
  
  * ```python
    from flask_sqlalchemy import SQLAlchemy
    db = SQLAlchemy()
    ```

* To allow the SQLAlchemy object to create the mapping between the database and the app objects, we need to make the classes extend `db.Model`:
  
  * ```python
    from db import db
    class UserModel(db.Model)
    ```

* We then need to tell SQLAlchemy the table names where te objects of the classes are going to be stores. This is done by assigning the name of the table to a `__tablename__` variable, and providing the column names:
  
  * ```python
    class UserModel(db.Model):
        __tablename__ = "users"
        id = db.Column(db.Integer, primary_key=True) # providing the datatype, and setting a primary key
        username = db.Column(db.String(80)) # limits the string length
    ```

* SQLAlchemy includes methods that can make connecting to the database and creating queries much simpler. To search for values in a database:
  
  * ```python
    def find_by_name(cls, name):
        return ItemModel.query.filter_by(name=name) # returns all matches
    ```

* This can be further filtered by chaining calls:
  
  * ```python
    return ItemModel.query.filter_by(name=name).first() # returns first match
    ```

* To save items into table:
  
  * ```python
    def save_to_db(self):
        db.session.add(self) # the session is just the current objects to add
        db.session.commit() # saving the current session 
    ```

* We can also use `.delete()` method to delete an item.

* We need to tell SQLAlchemy where to find the database by adding to the app:
  
  * ```python
    app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///data.db'
    ```

* If we  want to return a list of items through SQLAlchemy, we use the `.all()` method. This returns a list, so we need to iterate through each item to return in JSON:
  
  * ```python
    def get(self):
        return {'items': [item.json() for item in ItemModel.query.all()]}
    ```

* Alternatively we can use a lambda statement instead of list comprehension:
  
  * ```python
    return {'items': list(map(lambda item: item.json(), ItemModel.query.all()))}
    ```

* We can use SQLAlchemy to create our table for us. We can remove our create_tables file, and simply add in a flask decorator method in the app to create the database and tables for us:
  
  * ```python
    @app.before_first_request
    def create_table():
        db.create_all() # links to SQLALCHEMY_DATABASE_URI call to create file, and imports to find tables
    ```

* If we want to extend the API and add models that are linked to each other, we need to use **foreign keys**. We do this by linking a column in the base table (generally a primary key) to a column in the sub table with a foreign key:
  
  * ```python
    store_id = db.Column(db.Integer, db.ForeignKey('stores.id')) # creates foreign key
    store = db.relationship('StoreModel') # creates relationship to other model
    ```

* We also need to make the relationship back traceable by adding the relationship to the base table model:
  
  * ```python
    item = db.relationship('ItemModel')
    ```

* You cannot delete an item in the base table, if they have linked items in the sub table



## 4. Thursday

### Deploying Flask Apps

* **Heroku** is a web service that runs your code and allows others to access it

* Allowing others to interact with your code is known as **hosting**

* **Dyno** is Heroku's version of a server, known as a **virtual machine**. We can have multiple Dynos available at one time, to handle larger workloads. They can all access the same database

* **uWSGI** is a way of serving our application. It interacts with our flask app to make it available to use

* Heroku automatically enables **SSL**(Secure Socket Layer), so the transfer of data will be encrypted

* Before we can deploy the flask app into heroku, we need to upload our code to GitHub

* Once we have done thos, we can login to Heroku, create a new app, connect to GitHub, and link to the relevant repository. Before we deploy the app, we need to add the required files:
  
  * runtime.txt - tells Heroku which code version we are running:
    
    * ```python
      python-3.9.13
      ```
  
  * requirements.txt - what libraries to install to run the app:
    
    * ```python
      Flask
      Flask-RESTful
      Flask-JWT
      Flask-SQLAlchemy
      uwsgi
      ```
  
  * uwsgi.ini - the uwsgi process for running the app:
    
    * ```python
      [uwsgi]
      http-socket = :$(PORT) # the socket we want to run, specified for Heroku
      master = true # master process
      die-on-term = true # kill app when process terminates
      memory-report = true
      ```
  
  * Procfile - what dyno (server) we want to use in Heroku:
    
    * ```python
      web: uwsgi uwsgi.ini # runs the uwsgi process with the file we created
      ```

* Then we need to go into Heroku - Settings - Buildpack, to tell Heroku we are using Python

* Finally, we need to add a run.py file into the project to provide a main call to run the app:
  
  * ```python
    from app import app
    from db import db
    db.init_app(app)
    @app.before_first_request
    def create_table():
        db.create_all()
    ```

* Once we have the app running, it is important to add in a database feature to store our changes to the database, so we don't lose them when Heroku closes/sleeps the app. This is done using **PostgreSQL**:
  
  * In Heroku - Resources - More add ons - Install Heroku Postgres with selected app

* We then need to update our app code to ensure we are using this database, insteas of SQLite:
  
  * ```python
    import os
    app.config['SQLALCHEMY_DATABASE_URI'] = os.environ.get('DATABASE_URL', 'sqlite:///data.db') #link to Heroku Postgres database, otherwise use local SQLite database
    ```

* To enable this to work, we also need to add **psycopg2** to our requirements file



## 5. Friday

### Flask JWT Extended

* Flask-JWT has been depreciated and has been changed to Flask-JWT-Extended. This includes similar functionality, with some extra improvements and features
  
  * `pip install Flask-JWT-Extended`

* To use Flask-JWT-Extended for logging in users, we first need to update the app to link JWT to the app:
  
  * ```python
    from flask_jwt_extended import JWTManager
    jwt = JWTManager(app)
    ```

* We then need to create a user login class to generate the access token for the user:
  
  * ```python
    from hmac import compare_digest
    from flask_jwt_extended import create_access_token, create_refresh_token
    class UserLogin(Resource):
        parser = reqparse.RequestParser()
        parser.add_argument('username',
                            type=str,
                            required=True,
                            help='This field cannot be left blank'
                            )
        parser.add_argument('password',
                            type=str,
                            required=True,
                            help='This field cannot be left blank'
                            )
        @classmethod
        def post(cls):
            # get data from parser
            data = cls.parser.parse_args()
            # find user in database
            user = UserModel.find_by_username(data['username'])
            # check password
            if user and compare_digest(user.password, data['password']):
                # create access token
                access_token = create_access_token(identity=user.id, fresh=True)
                # create refresh token
                refresh_token = create_refresh_token(user.id)
                return {
                    'access_token': access_token,
                    'refresh_token': refresh_token
                }, 200
            # user does not exist
            return {'message': 'Invalid credentials'}, 401
    ```

* We then need to add the endpoint to the app:
  
  * ```python
    from resources.user import UserRegister, User, UserLogin
    app.api_resource(UserLogin, '/login')
    ```

* **JWT claims** allow us to add extra data for when JWT comes back to us. Whenever we create a JWT it will run the function linked to the JWT decorator to see if we need to add extra data, such as admin access:
  
  * ```python
    @jwt.additional_claims_loader
    def add_claims_to_jwt(identity):
        if identity == 1: # instead of hard-coding, should read from config or database
            return {'is_admin': True}
        return {'is_admin': False}
    ```

* We can then link this claim to any method to only allow specified users access:
  
  * ```python
    from flask_jwt_extended import jwt_required, get_jwt
    @jwt_required()
    def delete(self, name):
        claims = get_jwt()
        if not claims['is_admin']:
            return {'message': 'Admin privilege required'}
        # code continues to execute for admin
    ```

* We can add optional log in features through JWT, to provide more information to logged in users, than non-logged in users:
  
  * ```python
    from flask_jwt_extended import jwt_required, get_jwt, get_jwt_identity
    @jwt_required(optional=True)
    def get(self):
        user_id = get_jwt_identity()
        items = [item.json() for item in ItemModel.find_all()]
        if user_id:
            return {'items': items}, 200 # return full detail if logged in
       return { # otherwise, only return name of items
            'items': [item['name'] for item in items],
            'message': 'More data available if you log in'
    }, 200
    ```

* **Fresh tokens** are generally used when users want to perform a critical change on their account, but they have already been logged in for a prolonged period. This is an extra layer of security

* A **refresh token** is an automatically renewed access token that is generated to continue access for the user after the original access token has expired. When a user attempts to perform a critical action, we can check if they are using a refresh token, and request them to sign in again to generate a fresh token before continuing:
  
  * ```python
    from flask_jwt_extended import jwt_required
    class TokenRefresh(Resource):
        @jwt_required(refresh=True)
        def post(self):
            current_user = get_jwt_identity()
            new_token = create_access_token(identity=current_user, fresh=False)
            return {'access_token': new_token}, 200
    ```

* We then need to add the new endpoint for the refresh token:
  
  * ```python
    from user import TokenRefresh
    api.add_resource(TokenRefresh, '/refresh')
    ```

* To require a method to need a fresh token by adding the decorator:
  
  * ```python
    @jwt_required(fresh=True)
    ```

* We can create JWT loaders to notify users of issues with tokens:
  
  * ```python
    @jwt.expired_token_loader # token has expired and needs refreshing
    def expired_token_callback():
        return jsonify({
            'description': 'The token has expired',
            'error': 'token_expired'
    }), 401
    
    @jwt.invalid_token_loader # an invalid token has been entered
    # method to return message
    
    @jwt.unauthorized_loader # no token received
    # method to return message
    
    @jwt.needs_fresh_token_loader # not a fresh token, needs one for request
    # method to return message
    
    @jwt.revoked_token_loader # user logs out, token is added to revoked token list so cannot be used again
    # method to return message
    ```


