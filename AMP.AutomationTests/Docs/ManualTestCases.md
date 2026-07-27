# Manual Test Cases

## Overview

This document contains detailed manual test cases for the SauceDemo application.

The selected test cases provide representative coverage of:

- Login and logout
- Product listing and sorting
- Add to cart and remove from cart
- Checkout

The manual test cases are written in Gherkin format. In each Gherkin scenario, the Given statements define the initial context,
the When statements define the test actions, and the Then statements define the expected results.

## Priority Definitions

- P0 — Critical: Failure blocks a core user or business flow, such as login, cart management, checkout, or financial calculations.
- P1 — High: Failure significantly affects usability, navigation, session security, or data consistency but may not completely block the purchasing flow.


# Login and Logout

## TC-LOGIN-001 — Verify successful login using standard_user

**Related Scenario:** TS-LOGIN-001  
**Priority:** P0  
**Test Type:** Positive 

### Preconditions

- The SauceDemo application is available.
- The user is on the login page.

### Test Data

- Username: `standard_user`
- Password: `secret_sauce`

### Test Steps and Expected Results

```gherkin

Feature: Login Functionality
  Scenario: Successful login using standard_user    
    When the user enters "standard_user" in the Username field
      And the user enters "secret_sauce" in the Password field
      And the user clicks the Login button
    Then the user should be redirected to the product listing page
      And the page heading should display "Products"
      And the application header should display "Swag Labs"
      And no login error message should be displayed
```      

### Pass Criteria

The test passes if the user is authenticated successfully and the product listing page is displayed without an error.

### Fail Criteria

The test fails if login is rejected, an unexpected error is displayed, or the product listing page does not open.


## TC-LOGIN-002 — Verify login is rejected for locked_out_user

**Related Scenario:** TS-LOGIN-002  
**Priority:** P0  
**Test Type:** Negative

### Preconditions

- The SauceDemo application is available.
- The user is on the login page.

### Test Data

- Username: `locked_out_user`
- Password: `secret_sauce`

### Test Steps and Expected Results

```gherkin
Feature: Login Functionality
  Scenario: Login is rejected for locked_out_user    
    When the user enters "locked_out_user" in the Username field
      And the user enters "secret_sauce" in the Password field
      And the user clicks the Login button
    Then the user should remain on the login page
      And the error message should display "Epic sadface: Sorry, this user has been locked out."
      And the product listing page should not be displayed
```

### Pass Criteria

The test passes if login is rejected and the correct locked-out account error message is displayed.

### Fail Criteria

The test fails if the locked-out user is authenticated or the expected error message is missing or incorrect.


## TC-LOGOUT-001 — Verify logout ends the authenticated session

**Related Scenario:** TS-LOGIN-010  
**Priority:** P1  
**Test Type:** Positive and Security

### Preconditions

- The user is logged in as `standard_user`.
- The product listing page is displayed.

### Test Steps and Expected Results

```gherkin
Feature: Logout Functionality
  Scenario: Logout ends the authenticated session    
    When the user clicks the application hamburger menu at the top left of the page
      And the user clicks Logout
    Then the user should be redirected to the login page
    When the user clicks the browser Back button
    Then the product listing page should not be accessible
      And the user should remain on the login page
      And an authorization error message should be displayed "Epic sadface: You can only access '/inventory.html' when you are logged in."
    When the user navigates directly to "https://www.saucedemo.com/inventory.html"
    Then the product listing page should not be accessible    
      And the user should remain on or be redirected to the login page
```

### Pass Criteria

The test passes if logout returns the user to the login page and protected application pages cannot be accessed afterward.

### Fail Criteria

The test fails if the authenticated session remains active or protected pages remain accessible after logout.


# Product Listing and Sorting

## TC-PRODUCT-001 — Verify each product displays complete information

**Related Scenarios:** TS-PRODUCT-002 and TS-PRODUCT-003  
**Priority:** P1  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- The product listing page is displayed.

### Test Steps and Expected Results

```gherkin
Feature: Product Listing
  Scenario: All products display complete information    
    When the user reviews all products displayed on the page
    Then every product should display an image
      And every product should display a name
      And every product should display a description
      And every product should display a price
      And every product should display an Add to cart enabled button
      And no product should be duplicated
      And no required product information should be missing
```

### Pass Criteria

The test passes if every product displays complete and correctly associated information.

### Fail Criteria

The test fails if any product information is missing, duplicated, or associated with the wrong product.


## TC-PRODUCT-002 — Verify products are sorted by price from low to high

**Related Scenario:** TS-PRODUCT-009  
**Priority:** P1  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- The product listing page is displayed.

### Test Steps and Expected Results

```gherkin
Feature: Product Sorting
  Scenario: Sort products by price from low to high    
    Given the current number of displayed products is recorded
      And the sort dropdown is by default set to "Name (A to Z)" 
    When the user selects "Price (low to high)" from the sort dropdown
    Then the selected sort option should remain displayed
      And the products should be ordered from the lowest price to the highest price
      And each product price should be less than or equal to the following product price
      And the number of displayed products should remain unchanged
      And no product should be duplicated
      And product names and prices should remain correctly associated
```

### Pass Criteria

The test passes if all products are displayed in ascending price order without missing, duplicated, or mismatched information.

### Fail Criteria

The test fails if the products are not sorted correctly or the product information becomes inconsistent after sorting.


# Add to Cart and Remove from Cart

## TC-CART-001 — Verify a user can add multiple products to the cart

**Related Scenarios:** TS-CART-003, TS-CART-004, and TS-CART-005  
**Priority:** P0  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- The cart is empty.
- The product listing page is displayed.

### Test Steps and Expected Results

```gherkin
Feature: Shopping Cart
  Scenario: Add multiple products to the cart    
    When the user records the names and prices of two different products
      And the user adds the first product to the cart
    Then the cart badge should display "1"
    When the user adds the second product to the cart
    Then the cart badge should display "2"
    When the user opens the cart
    Then both selected products should be displayed
      And each product name should match the product listing page
      And each product price should match the product listing page
      And no unselected product should be displayed
```

### Pass Criteria

The test passes if both selected products are added successfully and the cart badge and cart contents are accurate.

### Fail Criteria

The test fails if a selected product is missing, an unselected product appears, or the cart badge count is incorrect.


## TC-CART-002 — Verify removing one product does not affect other products

**Related Scenarios:** TS-CART-008, TS-CART-009, and TS-CART-010  
**Priority:** P0  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- Two different products are in the cart.
- The cart page is displayed.
- The cart badge displays `2`.

### Test Steps and Expected Results

```gherkin
Feature: Shopping Cart
  Scenario: Remove one product without affecting other cart items    
    When the user removes one selected product
    Then the removed product should no longer be displayed
      And the other product should remain in the cart
      And the remaining product information should remain unchanged
      And the cart badge should update to "1"
```

### Pass Criteria

The test passes if only the selected product is removed and the remaining product and cart count remain correct.

### Fail Criteria

The test fails if the wrong product is removed, both products are removed, or the cart badge does not update correctly.


## TC-CART-003 — Verify cart contents persist during navigation

**Related Scenario:** TS-CART-011  
**Priority:** P1  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- At least one product has been added to the cart.

### Test Steps and Expected Results

```gherkin
Feature: Shopping Cart
  Scenario: Cart contents persist during navigation    
    Given the product name and price have been recorded
    When the user opens the cart
    Then the selected product should be displayed
    When the user returns to the product listing page
      And the user opens a product details page
      And the user returns to the product listing page
      And the user opens the cart again
    Then the original product should still be displayed
      And the product name and price should remain unchanged
      And the cart badge should display the correct count
```

### Pass Criteria

The test passes if the selected product and cart count remain unchanged while navigating through the application.

### Fail Criteria

The test fails if the cart contents are lost, changed, or duplicated during navigation.


# Checkout

## TC-CHECKOUT-001 — Verify a user can complete checkout successfully

**Related Scenarios:** TS-CHECKOUT-001, TS-CHECKOUT-002, TS-CHECKOUT-012, TS-CHECKOUT-013, and TS-CHECKOUT-014  
**Priority:** P0  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- At least one product has been added to the cart.
- The cart page is displayed.

### Test Data

- First Name: `Ahmed`
- Last Name: `Osman`
- Zip/Postal Code: `30303`

### Test Steps and Expected Results

```gherkin
Feature: Checkout
  Scenario: Complete checkout successfully               
    When the user clicks Checkout
    Then the checkout information page should be displayed with the title "Checkout: Your Information"
    When the user enters "Ahmed" in the First Name field
      And the user enters "Osman" in the Last Name field
      And the user enters "30303" in the Zip/Postal Code field
      And the user clicks the Continue button
    Then the checkout overview page should be displayed with the title "Checkout: Overview"
      And all selected products should be displayed
      And the Payment Information section should be displayed
      And the Shipping Information section should be displayed
      And the item subtotal should be displayed
      And the tax should be displayed
      And the total should be displayed
    When the user clicks Finish
    Then the checkout completion page should be displayed with the title "Checkout: Complete!"
      And the thank-you message should be displayed as "Thank you for your order!"
      And the green checkmark image should be displayed
      And the order dispatch message should be displayed
      And the cart badge should no longer be displayed
```

### Pass Criteria

The test passes if the order is completed successfully, the confirmation page is displayed, and the cart badge is cleared.

### Fail Criteria

The test fails if the user cannot complete checkout, the selected product information is incorrect, or the confirmation page is not displayed.


## TC-CHECKOUT-002 — Verify required customer information validation

**Related Scenarios:** TS-CHECKOUT-003, TS-CHECKOUT-004, and TS-CHECKOUT-005  
**Priority:** P0  
**Test Type:** Negative

### Preconditions

- The user is logged in as `standard_user`.
- At least one product is in the cart.
- The checkout information page is displayed.

### Test Steps and Expected Results

```gherkin
Feature: Checkout Validation
  Scenario Outline: Required customer information is missing    
    When the user enters "<FirstName>" in the First Name field
      And the user enters "<LastName>" in the Last Name field
      And the user enters "<PostalCode>" in the Zip/Postal Code field
      And the user clicks Continue
    Then the user should remain on the checkout information page
      And the error message should display "<ExpectedError>"
      And the checkout overview page should not be displayed

    Examples:
      | FirstName | LastName | PostalCode | ExpectedError                  |
      |           | Osman    | 30303      | Error: First Name is required  |
      | Ahmed     |          | 30303      | Error: Last Name is required   |
      | Ahmed     | Osman    |            | Error: Postal Code is required |

```

### Pass Criteria

The test passes if each missing required field produces the correct validation message and checkout does not continue.

### Fail Criteria

The test fails if checkout proceeds with incomplete information or the incorrect validation message is displayed.


## TC-CHECKOUT-003 — Verify subtotal, tax, and total calculations

**Related Scenarios:** TS-CHECKOUT-009 and TS-CHECKOUT-010  
**Priority:** P0  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- Two or more products are in the cart.
- Valid customer information has been submitted.
- The checkout overview page is displayed.

### Test Steps and Expected Results

```gherkin
Feature: Checkout Calculations
  Scenario: Verify checkout subtotal, tax, and total   
    When the user records the price of each product
      And the user calculates the sum of all product prices
    Then the calculated sum should equal the displayed item subtotal
      And a tax amount should be displayed
    When the user adds the displayed subtotal and tax
    Then the calculated amount should equal the displayed total
      And all monetary values should use consistent dollar formatting
      And all monetary values should display two decimal places
```

### Pass Criteria

The test passes if the subtotal equals the sum of the product prices and the total equals the subtotal plus tax.

### Fail Criteria

The test fails if any calculated amount is incorrect or monetary values are displayed inconsistently.


## TC-CHECKOUT-004 — Verify checkout cancellation preserves cart contents

**Related Scenarios:** TS-CHECKOUT-006 and TS-CHECKOUT-011  
**Priority:** P1  
**Test Type:** Positive

### Preconditions

- The user is logged in as `standard_user`.
- At least one product has been added to the cart.

### Test Steps and Expected Results
```gherkin
Feature: Checkout Cancellation Functionality
  Scenario: Cancel checkout from the information page    
    Given the product name and cart badge count have been recorded
    When the user opens the checkout information page
      And the user clicks the Cancel button
    Then the user should be returned to the cart page
      And the original product should remain in the cart
      And the cart badge count should remain unchanged

  Scenario: Cancel checkout from the overview page    
    Given the user has entered valid checkout information
      And the user clicks Continue to proceed to the checkout overview page
      And the checkout overview page is displayed
    When the user clicks the Cancel button
    Then the user should be returned to the product listing page
    When the user opens the cart
    Then the original product should remain in the cart
      And the cart badge count should remain unchanged
```

### Pass Criteria

The test passes if both cancellation paths navigate to the expected pages and preserve all cart contents.

### Fail Criteria

The test fails if cart contents are removed or changed, the cart badge becomes incorrect, or the user is sent to the wrong page.


# Prioritization Rationale

P0 test cases cover business-critical and access-critical functionality. These cases validate successful authentication, locked-account handling, cart integrity, required checkout information, successful order completion, and pricing accuracy. Failure in these areas could block the user from accessing the application or completing a purchase.

P1 test cases cover important supporting functionality, including logout security, product presentation, sorting, cart persistence, navigation, and checkout cancellation. Failures in these areas would significantly affect usability or reliability but may not completely block the primary purchasing flow.

The selected manual test cases provide representative coverage across every functional area required by the assessment while avoiding unnecessary duplication. Related verification points are grouped within broader test cases when they belong to the same user workflow.