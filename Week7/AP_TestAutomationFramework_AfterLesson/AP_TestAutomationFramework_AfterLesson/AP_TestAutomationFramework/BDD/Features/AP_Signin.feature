Feature: AP_Signin

In order to be able to buy items
As a registered user of the automation practice website 
I want to be able to sign in to my account

@Login
Scenario: Invalid password – too short
Given I am on the signin page 
And I have entered the email "testing@snailmail.ccm"
And I have entered the password "<passwords>"
When I click the sign in button 
Then I should see an alert containing the error message "Invalid password."
Examples:
|passwords|
|four     |
|1234     |
|Nish     |

@Login
Scenario:  Invalid email
Given I am on the signin page 
And I have entered the email "testingsnailmail.ccm"
And I have entered the password "four"
When I click the sign in button 
Then I should see an alert containing the error message "Invalid email address."


@Login
@SadPath
Scenario: Forgot password
    Given I am on the signin page 
    When I click the forgot your password? link
    Then I will go to a form to reset my password

@Login
Scenario: Invalid email - using SpecFlow assist 
Given I am on the signin page 
And I have the following credentials:
| Email    | Password |
| test.com | nish     |
When enter these credentials
And I click the sign in button
Then I should see an alert containing the error message "Invalid email address."