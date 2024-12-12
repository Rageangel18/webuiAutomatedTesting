Feature: Search Results
  Verify the search functionality on the homepage.

  @SearchPage
  Scenario: Successful search result
    Given the user is on the Search Page homepage
    When the user searches for "study programs"
    Then the user should be redirected to "https://en.ehu.lt/?s=study+programs"
    And the results count element with class "search-filter__result-count" should contain "results found."