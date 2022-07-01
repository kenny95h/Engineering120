# Intro to Visual Studio

A solution is the umbrella - its only function is to be a container for the code

The bin and obj files will not be commited when using a gitignore

In .Net 6 the Main method does not need to be specified. Multiple using statements are implicit in this. 

In our programs we will write out the whole method including the `using` statements manually

The `namespace` is always the name of the program

`global using` statements can be placed in a separate file to be used with all files in that program

camelCase - variable names
_underscoreFirst - private fields
PascalCase - Class and method names
kebab-case - used for HTML
snake_case - used with SQL

Always put as break point in code when having issues - Use breakpoint by selecting the line number from when you want the execution to stop and then be stepped through
This allows us to view the autos and local information in debug mode, and the core values as we step through from the breakpoint

right click to insert a conditional breakpoint - an expression can then be added to stop the code when the expression is met

Running the program in debug mode generates debugging information for the program - This is updated in the bin file (debug)

The release mode compiles for faster execution 