# Test Scenarios

## Login and Logout

- TS-LOGIN-001 — Verify successful login using `standard_user`
- TS-LOGIN-002 — Verify login is rejected for `locked_out_user` with an appropriate error message
- TS-LOGIN-003 — Verify application behavior after logging in with `problem_user`
- TS-LOGIN-004 — Verify application response time after logging in with `performance_glitch_user`
- TS-LOGIN-005 — Verify application behavior after logging in with `error_user`
- TS-LOGIN-006 — Verify page presentation after logging in with `visual_user`
- TS-LOGIN-007 — Verify login is rejected when invalid credentials are entered
- TS-LOGIN-008 — Verify validation when either the username or password is missing
- TS-LOGIN-009 — Verify validation when both username and password are empty
- TS-LOGIN-010 — Verify an authenticated user can log out and cannot access protected pages afterward

## Product Listing and Sorting

- TS-PRODUCT-001 — Verify the product listing page is displayed after successful login
- TS-PRODUCT-002 — Verify all expected products are displayed
- TS-PRODUCT-003 — Verify each product displays a name, description, price, image, and action button
- TS-PRODUCT-004 — Verify a user can open a product details page from the product listing
- TS-PRODUCT-005 — Verify product information is consistent between the product listing and product details pages
- TS-PRODUCT-006 — Verify a user can return from the product details page to the product listing
- TS-PRODUCT-007 — Verify the default product order is Name (A to Z)
- TS-PRODUCT-008 — Verify products can be sorted by name from Z to A
- TS-PRODUCT-009 — Verify products can be sorted by price from low to high and high to low

## Add to Cart / Remove from Cart

- TS-CART-001 — Verify a user can add one product to the cart from the product listing page
- TS-CART-002 — Verify a user can add one product to the cart from the product details page
- TS-CART-003 — Verify a user can add multiple different products to the cart
- TS-CART-004 — Verify the cart badge count matches the number of products added
- TS-CART-005 — Verify selected products display the correct quantity, name, description, and price in the cart
- TS-CART-006 — Verify the Add to cart button changes to Remove after a product is added
- TS-CART-007 — Verify a user can remove a product from the product listing page
- TS-CART-008 — Verify a user can remove a product from the cart page
- TS-CART-009 — Verify removing one product does not affect other products in the cart
- TS-CART-010 — Verify the cart badge updates after removal and disappears when the cart becomes empty
- TS-CART-011 — Verify cart contents persist while navigating between the product listing, product details, and cart pages

## Checkout

- TS-CHECKOUT-001 — Verify the checkout information page is displayed after selecting Checkout
- TS-CHECKOUT-002 — Verify valid customer information navigates the user to the checkout overview page
- TS-CHECKOUT-003 — Verify an error message is displayed when the first name is missing
- TS-CHECKOUT-004 — Verify an error message is displayed when the last name is missing
- TS-CHECKOUT-005 — Verify an error message is displayed when the zip/postal code is missing
- TS-CHECKOUT-006 — Verify the Cancel button on the information page returns the user to the cart
- TS-CHECKOUT-007 — Verify the checkout overview displays all products selected from the cart
- TS-CHECKOUT-008 — Verify the checkout overview displays payment and shipping information
- TS-CHECKOUT-009 — Verify the item subtotal equals the sum of all cart item prices
- TS-CHECKOUT-010 — Verify tax is displayed and the total equals the subtotal plus tax
- TS-CHECKOUT-011 — Verify the Cancel button on the overview page returns the user to the product listing
- TS-CHECKOUT-012 — Verify selecting Finish displays the order confirmation page
- TS-CHECKOUT-013 — Verify the confirmation page displays the thank-you and order dispatch messages
- TS-CHECKOUT-014 — Verify the cart badge is cleared after a successful order
- TS-CHECKOUT-015 — Verify the Back Home button returns the user to the product listing
- TS-CHECKOUT-016 — Verify the Generate PDF Order button generates the order document successfully