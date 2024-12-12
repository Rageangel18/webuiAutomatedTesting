Feature: Language Switcher
  Verify the functionality of switching the language on the homepage.

  Scenario: Successfully change the language to Lithuanian
    Given the user is on the homepage
    When the user clicks on the "LT" language link
    Then the user should be redirected to the Lithuanian version of the site
    And the page header should contain "Kodėl EHU? Kas daro EHU unikaliu?"