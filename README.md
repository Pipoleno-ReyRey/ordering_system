# ordering_system
# Microservices Project in C# - Shopping System
Description
This project simulates an online shopping system with three microservices:

Users: Manages authentication and registration.
Products: Manages the product catalog.
Shopping Cart: Allows adding and removing products from the cart.
It includes a console app that consumes these services.

# Instructions

Clone the repository.

Open each microservice in Visual Studio or VS Code.

Run the microservices.

Run the console app to interact with them.

# API
User Microservice

* GET /users/getUser?email&password
* POST /users/postUser
* PUT /users/updateUser

Product Microservice

* GET /products/getProducts
* GET /products/getProduct?name
* POST /products/postProduct
* PUT /products/updateProduct?seriesNum

Shopping Cart Microservice

* GET /cart/getCart?userId
* POST /cart/postCart?userId
* PUT /cart/updateCartAdd?userId&product&amount
* PUT /cart/updateCartRemove?userId&product&amount
