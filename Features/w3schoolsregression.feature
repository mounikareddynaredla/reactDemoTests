Feature: w3schoolsregression

A short summary of the feature

Scenario: Successful User Registration
Given a user is on the registration page
When the user enters valid registration details
Then a new user account should be created successfully

Scenario: Existing User Validation
Given a user is on the registration page
And a user with the same user already exists
When the user tries to register with the existing userid
Then an error message should be displayed, and the registration should not proceed

Scenario: Missing Required Fields
Given a user is on the registration page
When the user submits the registration form with missing required fields
Then appropriate error messages should be displayed, and the registration should not proceed

Scenario: Successful Login
Given a user navigates to the login page
When the user enters valid credentials
Then the user should be successfully logged in

Scenario Outline: Invalid Login Attempt
Given a user navigates to the login page
When the user enters invalid credentials 
Then an error message should be displayed, and the user should not be logged in


