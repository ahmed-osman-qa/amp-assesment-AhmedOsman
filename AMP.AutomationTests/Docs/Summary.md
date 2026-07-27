# Assessment Summary

## Overall Approach

I started by reviewing the main SauceDemo workflows and creating high-level test scenarios for login and logout, product listing and sorting, cart management, and checkout.

From those scenarios, I selected a smaller set of detailed manual test cases that covered the most important positive, negative, and business-critical paths. I then automated a few representative tests, including successful login, locked-out user validation, invalid credentials, and a complete checkout flow.

My goal was to keep the solution clear, practical, and easy to maintain without overengineering it for a small assessment.

## Framework Choice

I used C# with Playwright, NUnit, and the Page Object Model.

This is the framework and technology stack I currently use in my work, so I already have hands-on experience with it. It allowed me to complete the assessment efficiently while following patterns I am familiar with, such as reusable page objects, external JSON test data, helper methods, and Playwright assertions.

I also chose Playwright because it provides reliable browser automation, built-in waiting, and clear assertion support.

## Bugs and Issues Discovered

During exploratory testing, I found a cart-related issue when using the `error_user` account.

Only some products could be added to the cart, while the Add to cart buttons for the remaining products did not work. Products that were added also could not be removed.

The full details, reproduction steps, expected and actual results, and screenshot evidence are documented in:

`Docs/BugReport.md`

## Improvements Given More Time

Given more time, I would:

- Add more automated coverage for sorting, cart removal, validation messages, and checkout calculations.
- Add cross-browser execution for Chromium, Firefox, and WebKit.
- Add screenshots, traces, and videos automatically when a test fails.
- Add CI execution using GitHub Actions.
- Improve reporting with an HTML test report.
- Add more reusable methods for common actions and test setup.

The current solution focuses on the most important workflows while keeping the framework simple and easy to understand.