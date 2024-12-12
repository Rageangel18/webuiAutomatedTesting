Feature: Contact Page Information

    Scenario Outline: Verify contact page displays correct information
    Given the user navigates to "<URL>"
    Then the user should see the contact information "<ExpectedText>"

    Examples:
      | URL                              | ExpectedText             |
      | https://en.ehu.lt/contact/       | franciskscarynacr@gmail.com |
      | https://en.ehu.lt/contact/       | +370 68 771365           |
      | https://en.ehu.lt/contact/       | +375 29 5781488          |