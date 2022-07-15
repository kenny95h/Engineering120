# Week 1: 27/06 - 01/07

1. [Monday](##1. Monday) - Induction information

2. [Tuesday](##2. Tuesday) - Interview preparation & .Net

3. [Wednesday](##3. Wednesday) - Markdown, Shelves, Scripting & Git

4. [Thursday](##4. Thursday) - Intro to Visual Studio, Agile & Scrum

5. [Friday](##5. Friday) - Agile Project & Sales meeting

## 2. Tuesday

### .Net

* .Net 5/.Net 6 is the next iteration of .Net Core

* .Net Framework is not cross-platform and the libraries are stored on the device, unlike on .Net Core where they are stored in the code

  

## 3. Wednesday

### Markdown

| Symbols                                                      | Purpose                                                  |
| ------------------------------------------------------------ | -------------------------------------------------------- |
| \*word* or \_word_                                           | Italics                                                  |
| \**word**                                                    | Bold                                                     |
| \>                                                           | Indented quote, increase number for larger indent        |
| \* or \-                                                     | followed by space for bullet points                      |
| 1.                                                           | numbered list                                            |
| \[link-name](address to image)                               | link to image                                            |
| \[Intro](#introduction)                                      | link to header                                           |
| \!\[image-name](address to image)                            | show image on page                                       |
| #                                                            | header, increase number for smaller header               |
| \```language                                                  \``` | Code fences, write code and ending \``` on separate line |
| \`code`{.language-csharp}                                    | highlights line of code in sentence to csharp            |
| \- \[] name                                                  | tick box                                                 |
| \- \[x] name                                                 | ticked tick box                                          |



### Shelves & Scripting

| PowerShell commands                                          | Purpose                                           |
| ------------------------------------------------------------ | ------------------------------------------------- |
| ping 8.8.8.8                                                 | runs internet ping check                          |
| ls                                                           | lists all folders in directory                    |
| ls -R                                                        | lists everything within folders                   |
| ctrl-c                                                       | cancel current command                            |
| up and down keys                                             | run through command history                       |
| history                                                      | lists previous used commands                      |
| cd folder-name                                               | goes to folder if in current directory            |
| cd ..                                                        | back to previous directory                        |
| cd ~                                                         | back to home directory                            |
| cd /                                                         | to C drive                                        |
| md folder-name                                               | creates new folder in current directory           |
| new-item filename                                            | creates new file                                  |
| notepad filename.txt                                         | opens text file in current directory              |
| cat filename.txt                                             | reads file into PowerShell                        |
| cp filename.txt foldername                                   | copies file to folder                             |
| mv filename.txt newfilename.txt                              | renames file                                      |
| rm filename or del                                           | removes file                                      |
| rm filename.txt                                              | removes data from in file                         |
| help command                                                 | brings up details of what selected command does   |
| get-alias                                                    | brings up list of all aliases                     |
| get-command                                                  | brings up list of all commands                    |
| echo "words"                                                 | prints out to PowerShell                          |
| echo "words" >> filename.txt                                 | appends text to new line in file                  |
| echo "words" > filename.txt                                  | overwrites or creates new file with text inserted |
| ./filename.ps1                                               | runs script in current directory                  |
| Set-ExecutionPolicy -scope process -executionPolicy unrestricted | updates policy so it can run scripts              |



### Git

* A repository for coding.

* Creates snapshots of the current code known as **commits**.

* Create a **gitignore** to ignore visual studio

* PowerShell commands can be used to create and update the repository


| PowerShell commands                        | Purpose                                                      |
| ------------------------------------------ | ------------------------------------------------------------ |
| git clone httpslink-github                 | copies code from github and creates local repository         |
| git add readme.md                          | adds readme file ready to be commited                        |
| git status                                 | checks status of files ready to commit                       |
| git commit --m "comment"                   | commit files to local repository with comment                |
| git push                                   | pushes to github repository                                  |
| git log                                    | shows list of commits with each commit message               |
| git log pretty=oneline                     | shows each commit in single line                             |
| git diff commit1 commit2                   | shows differences between two commits                        |
| git reset HEAD                             | reverse an add (staging)                                     |
| git reset --hard commit1                   | revert back to commit selected                               |
| git tag -a 1.0.1 -m "main updates comment" | Adds new tag version to project - tags are downloadable versions of the project |
| git push origin --tags                     | pushes tag version to github, which can then be downloaded   |





## 4. Thursday

### C# Visual Studio

* A `namespace` is a container for all the code, and is always the same name of the program
* The signature of the Main method is: `public static void Main(string[] args)`
* `using` statements allow us to use the methods within those stated libraries
* Types of text formatting rules:

| Formatting       | Rule                   |
| ---------------- | ---------------------- |
| camelCase        | variable names         |
| _underscoreFirst | private fields         |
| PascalCase       | class and method names |
| kebab-case       | used for HTML          |
| snake_case       | used with SQL          |

* Use **breakpoints** in code when having errors 
  * select the line number from when you want the execution to stop and then be stepped through
  * view autos and local information updates in debug mode, and the core values as we step through from the breakpoint
  * use conditional breakpoints to stop the code when a specified expression is met
* Running the program in **debug** mode generates debugging information for the program - updated in the bin file
* The **release** mode compiles for faster execution
* We can manually **clean solution** in the VS search bar to remove all bin files - useful for dramatic changes in the program
* We can run the program through PowerShell by calling the program using **.\programname**
* We can include arguments after the name to run the program with the specified parameters **.\programname arguments-to-include**



### Agile & Scrum

* Working as a cross-functional team to complete the activities
* There is no single variant of agile
* All inspired by the agile values:
  * Individual and interactions
  * Working software
  * Customer collaboration
  * Responding to change

* 12 agile principles:

  * Customer satisfactions

  * Changing requirements

  * Frequent delivery

  * Communicate regularly

  * Support team member

  * Face-to-face communication

  * Measure work progress

  * Development process

  * Good design

  * Measure progress

  * Continue seeking result

  * Reflect and adjust regularly

* The scrum framework separates the process into small increments known as sprints
* The daily scrum recaps what was done yesterday, including any blockers
* The requirements are changed from the sprint review into the product backlog
* The sprint retrospective looks at improvements for the next sprint
* Three pillars of scrum:
  * Transparency - collaborate, no hidden agendas
  * Inspection - done by everyone on the scrum team
  * Adaptation - continuous improvement
* **User stories** - As a *<user>*, I want to *<goal>* so that *<reason>*
  * A pointer to the real requirement. Does not include a solution
  * An **epic** is the over arching story that encompasses multiple user stories
* **Three amigos** - Involves three disciplines, tester, developer, and business analyst
  * Discover assumptions and potential misunderstandings

* **Acceptance criteria** - sets the boundaries of a user story. The checkboxes that need to be done to consider the user story is completed
* **Gherkin** is used to structure the acceptance criteria:
  * Given...
  * When...
  * Then...
* Multiple scenarios of the acceptance criteria can be considered - Happy/Sad/Alternative
* Use MSCW technique to decide the importance of stories
* User story table template:

| Epic Table | Type | MSCW | User Story Title | User Story | Acceptance Criteria |
| ---------- | ---- | ---- | ---------------- | ---------- | ------------------- |



* In a project board, the requirements are moved through each process (**Definition of ready:** user stories, a.c, wireframes, priority ordered and definition of done checklist):
  * Product backlog
  * Sprint backlog
  * In progress
  * In review
  * Done
* **Definition of done** is agreed amongst the team as a checklist - completed, tested and confirmed by all
