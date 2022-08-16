# Week 8: 15/08 - 19/08

**1.** [Monday](##1. Monday) - 

**2.** [Tuesday](##2. Tuesday) - Exploratory Testing &  Performance Testing

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



## 3. Wednesday

## 4. Thursday

## 5. Friday
