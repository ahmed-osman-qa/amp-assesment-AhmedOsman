# Bug Report

## BUG-001 — Add to Cart and Remove buttons do not work consistently for error_user

**Application:** SauceDemo  
**URL:** https://www.saucedemo.com/  
**Browser:** Chromium 
**Operating System:** Windows 11  
**User Account:** `error_user`  
**Severity:** High  
**Priority:** P1  
**Reproducibility:** 100%  
**Status:** Open

## Description

When logged in as `error_user`, only some products can be added to the cart, while the remaining Add to cart buttons do not respond. Products that are successfully added also cannot be removed.

## Preconditions

- The SauceDemo application is available.
- The user is on the login page.
- The cart is empty.

## Test Data

- Username: `error_user`
- Password: `secret_sauce`

## Steps and Expected Results

```gherkin
Feature: Shopping cart functionality for error_user
  Scenario: Add all available products to the cart
    When the user clicks Add to cart for "Sauce Labs Backpack"
      And the user clicks Add to cart for "Sauce Labs Bike Light"
      And the user clicks Add to cart for "Sauce Labs Onesie"
    Then all three products should be added to the cart
      And the cart badge should display "3"
      And each selected button should change from Add to cart to Remove

    When the user clicks Add to cart for "Sauce Labs Bolt T-Shirt"
      And the user clicks Add to cart for "Sauce Labs Fleece Jacket"
      And the user clicks Add to cart for "Test.allTheThings() T-Shirt (Red)"
    Then all three additional products should be added to the cart
      And the cart badge should display "6"
      And each selected button should change from Add to cart to Remove

  Scenario: Remove products from the cart
    Given the user is logged in as "error_user"
      And the following products are already in the cart:
        | Product Name            |
        | Sauce Labs Backpack     |
        | Sauce Labs Bike Light   |
        | Sauce Labs Onesie       |
      And the cart badge displays "3"

    When the user clicks Remove for "Sauce Labs Backpack"
    Then "Sauce Labs Backpack" should be removed from the cart
      And the button should change from Remove to Add to cart
      And the cart badge should update to "2"
      And the remaining products should stay in the cart
```

## Actual Result

- `Sauce Labs Backpack`, `Sauce Labs Bike Light`, and `Sauce Labs Onesie` can be added successfully.
- `Sauce Labs Bolt T-Shirt`, `Sauce Labs Fleece Jacket`, and `Test.allTheThings() T-Shirt (Red)` are not added when their Add to cart buttons are clicked.
- The cart badge remains at `3`.
- The affected buttons remain displayed as Add to cart.
- Clicking Remove for any successfully added product does not remove it.
- The product remains in the cart.
- The button remains displayed as Remove.
- The cart badge does not decrease.

## Impact

The user cannot reliably manage the shopping cart. This affects a core e-commerce workflow and may prevent the user from purchasing the intended products.

## Evidence

`Docs/Evidence/BUG-001-error-user-cart-controls.png`

## Comparison

The same add and remove actions work correctly when performed using `standard_user`.

## Pass Criteria

The defect is resolved when `error_user` can add every displayed product, remove any selected product, and see the cart badge and button states update correctly.

## Fail Criteria

The defect remains if any product cannot be added, any added product cannot be removed, or the cart badge does not accurately reflect the cart contents.