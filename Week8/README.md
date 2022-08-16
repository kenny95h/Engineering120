# Week 8: 15/08 - 19/08

**1.** [Monday](##1. Monday) - 

**2.** [Tuesday](##2. Tuesday) - Exploratory Testing, Performance Testing & JMeter

**3.** [Wednesday](##3. Wednesday) - 

**4.** [Thursday](##4. Thursday) - 

**5.** [Friday](##5. Friday) - 

## 1. Monday

## 2. Tuesday

### Exploratory Testing

* Experienced testers simultaneously learn, test design, test execution and test result interpretation - Overcomes Pesticide Paradox

* Not random. Emphasis on adaptability and learning

* Use and capture information which guides us and can help find patterns and subtle cues

* Essential elements:
  
  * Purpose - clear mission of what we are testing
  
  * Designing - preconditions, verification, and post-conditions
  
  * Executing - execute as soon as we have thought of test
  
  * Learning - look for subtle cues
  
  * Steering - fuel curiosity and steer towards more bugs
  
  * Timeboxing - set a time to spend on testing

* Breakdown the sytem under test based on its high-level functionality, based on your knowledge of the application

* Then breakdown into smaller functions

* Focus on high-risk areas based on experience

* Where can we get ideas:
  
  * Stakeholder questions and comments
  
  * Source code
  
  * Developer comments
  
  * Own findings
  
  * Existing defects and reports
  
  * Particular areas where defects are clustered

* **Heuristics** - rule of thumb - a mental shortcut
  
  * When experienced testers put checklists together when exploratory testing
  
  * Three well know heuristics:
    
    * **Goldilocks** - Too big, Too small, just right - input fields
    
    * **RCRCRC** - Recent, Core, Risky, Configuration, Repaired & Chronic - regression
    
    * **FEW HICCUPS** - Familiar, Explainability, World, History, Image, Comparable product, Claims, User expectations, Product, Purpose, and Statistics

* **Test Charter** - how we document our exploration. Must include:
  
  * Target area (explore)
  
  * Resources/techniques/tools used (with)
  
  * Information we are looking for (to discover)

### Performance Testing

* Testing to determine the performance efficiency of a component or system

* Performance testing is very important in web application development

* Factors:
  
  * Hardware
  
  * Database - efficient queries
  
  * Location of servers
  
  * Connection
  
  * Page Weight - MB of page
  
  * HTTP Requests
  
  * Caching

* **Caching** - do not have to call the server for the same information. Stored locally

* **HTTP Requests** - how many are being made - multiple scripts, stylesheets, web address calls
  
  * Add into the document - longer load times as they are not cached
  
  * Concatenate request into one script/stylesheet

* **Page Weight** - the more information, the longer it takes to download
  
  * Only include what is necessary
  
  * Compress or use smaller images
  
  * GZip assets - use pointers instead of repeated strings - through requests
  
  * Minify Code - Removing comments, whitespace, and non-required semi-colons

* Web performance tools:
  
  * pagespeed.web.dev - insight on page speed (Google) - opportunities for improvement

* **Volume testing** - handling large amounts of data - capability to process data

* **Reliability & Recovery testing** - whether software operates normally after a disaster or integrity loss

* **Spike testing** - determines the behaviour of the system under sudden increase of load

* **Soak testing** - running at high load for a prolonged time to identify performance problems

* **Load testing** - the expected time a page takes to load, given number of users over a period of time (expected peak number of users)

* **Stress testing** - determines the stability of a system by stressing it beyond normal capacity

* What do we need:
  
  * Software KPIs - targets for performance
  
  * Expected normal load
  
  * Expected peak load
  
  * A tool to run the tests

### JMeter

* Open with JMeter Batch file in JMeter folder

* Create testplan:
  
  * New button

* Create a thread group (users):
  
  * Right-click testplan - add - threads - thread group
  
  * Provide number of users - ramp-up period (time for all users) - actions to be taken after sampler error

* Add a sampler (http):
  
  * Right-click thread group - add - sampler - HTTP request
  
  * Copy http protocol - copy address into server name - Add HTTP requests

* Add listeners (store/view results) - can use multiple types:
  
  * Right-click thread group - add - listener - choose type
  
  * Table listener - each iteration of user in new row - sample time (response) - status (pass/fail) - latency (time to first bite) - connect time (to connect to server)
  
  * Tree listener - do not use for large data performance tests - provides in depth data
  
  * Aggregate listener - average of all samples
  
  * Graph listener - visual representation
  
  * Summary listener - shortened version of aggregate
  
  * Data writer listener - save to csv file

* Assertions - checks on request/response - can be added at different levels (testplan/thread) - right-click level - add - assertions:
  
  * Response assertion - select field to test - matching rule - input expected result (pattern)
  
  * Duration assertion - specify maximum expected duration time
  
  * Size assertion - select response size field to test - specify size bytes - specify comparison rule
  
  * HTML assertion - checking HTML of response against standard syntax - can be logged in text file
  
  * JSON assertion - specify path to check if exists - specify expected values
  
  * XPath assertion - check value of XPath location

* HTTP Test Script Recorder - Right-click testplan - add non-test elements - recorder. An element in JMeter that helps record HTTP request
  
  * Do not have to manually add every request

* Right-click thread group - add - logic controller - recording controller:
  
  * Store events into separate recording controllers (rename accordingly)

* In test script recorder, specify the target controller

* Set up proxy and certificate:
  
  * Settings in chrome - search proxy - open - manual proxy setup - localhost - port number from JMeter
  
  * search certificates - manage certificates - import from JMeter bin - ApacheJMeter.crt

* Start from JMeter - Give transaction name (test name) - go to browser to site to test - complete actions - stop in JMeter to finish recording

## 3. Wednesday

## 4. Thursday

## 5. Friday
