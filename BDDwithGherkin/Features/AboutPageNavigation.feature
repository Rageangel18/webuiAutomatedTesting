Feature: About Page Navigation
  As a user
  I want to navigate to the About page
  So that I can learn more about the website

  @AboutPage
  Scenario: Successful Navigation to About Page
    Given the user is on the About Page homepage
    When the user clicks on the "About" link
    Then the user should be redirected to the "About" page
    And the page title should be "About"