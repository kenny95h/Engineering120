Feature: AP_CreateAccount
In order to be able to buy items
As non-user of the automation practice website 
I want to be able to create an account
So that I can start buying fake goods


@Login
@Happy
Scenario: Forgot password
    Given I am on the signin page 
    When I enter the valid e-mail "Nish@sparta.com"
    And click create account
    Then I should appear on the create account page