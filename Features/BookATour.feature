Feature: Calculator

@test_001
Scenario: Book a tour
Given I am in the home page of the MailTravel application
And I search "India" for destination
And I select "Incredible India" tour package

@test_002
Scenario: Validate different destinations
Given I am in the home page of the MailTravel application
And I search for below places
| Destination | PackageName      |
| India       | Incredible India |