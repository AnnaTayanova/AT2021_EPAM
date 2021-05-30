Feature: Northwind.AddProduct

@mytag
Scenario: SF_AddProduct
	Given I open url  "http://localhost:5000/Account/Login?"
	And I type in field login  "user"
	And I type in field password  "user"
	And I click button  Submit
	And I click the link  All products
	And I click button  Create New
	And I fill all  fields
	When I click button  Submit
	Then I taken All products page