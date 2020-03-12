Feature: Create Order Tests
	Admin can login

	Imperonate a user

	And create orders

@Chrome @Firefox @IE11 @Edge
Scenario: CreateOrder

	Given I go to CVLink page

	When I click Create Order

	Then I will see the Create Order page
