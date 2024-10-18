# Practice - JWT Authentication

This project demonstrates a simple JWT (JSON Web Token) authentication system.

## Steps

### 1. User Model

Created a `User` class with the following properties:

- **Id**: (int) Unique identifier (primary key).
- **Email**: (string) Unique email address.
- **Password**: (string) User's password.

### 2. Database Setup

Utilized Entity Framework to create a `DbContext` class that includes the `User` model.

### 3. JWT Creation

Implemented an `AuthController` with a `Login` method that:

- Accepts `Email` and `Password`.
- Generates and returns a JWT for valid credentials.

### 4. JWT Validation

Configured JWT validation for secured endpoints using the `Authorize` attribute.
