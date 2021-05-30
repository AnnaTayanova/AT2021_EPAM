Feature: Northwind.Login

@mytag
Scenario: SF_Login
	Given I open url "http://localhost:5000/Account/Login?"
	And I type in field login "user"
	And I type in field password "user"
	When I click button Submit
	Then I taken to the home page

Scenario: SF_Logout
	Given I open  url "http://localhost:5000/Account/Login?"
	And I type in field   login "user"
	And I type in field   password "user"
	And I click button   Submit 
	When I click button  Logout
	Then I taken to the  Login page
