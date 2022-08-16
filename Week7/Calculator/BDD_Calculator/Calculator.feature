Feature: Calculator

As a Spartan who is crap at maths,
I want a calculator that takes two numbers,
So I can do maths on them

@HappyPath
Scenario: Addition
	Given I have a calculator
	And I enter 5 and 2 in the calculator
	When I press add
	Then the result should be 7

@HappyPath
Scenario: Subtraction
	Given I have a calculator
	And I enter <input1> and <input2> in the calculator
	When I press subtract
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 1      | 1      | 0      |
	| 0      | 1      | -1     |
	| 1000   | 1      | 999    |

@HappyPath
Scenario: Multiply
    Given I have a calculator
    And I enter <input1> and <input2> in the calculator
    When I press multiply
    Then the result should be <result>

Examples: 
|input1 |input2  |result  |
| 1     | 1      | 1      |
| 2     | 3      | 6      |
| 9     | 9      | 81     |
| 5     | -17    | -85    |

@SadPath
Scenario: Divide By Zero
    Given I have a calculator
    And I enter <input1> and 0 in the calculator
    When I press divide
    Then a DivideByZero Exception should a DivideByZeroException when I press divide
    And the exception should have the message "Cannot Divide By Zero"
    Examples:
    | input1 | 
    | 1      | 
    | 6      | 

@HappyPath
Scenario: SumOfNumbersDivisibleBy2
    Given I have a calculator
    And I enter the numbers below to a list
    | nums |
    | 1    |
    | 2    |
    | 3    |
    | 4    |
    | 5    |
    When I iterate through the list to add all the even numbers
    Then the result should be 6
