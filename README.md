# User Management API
A Robust ASP.NET Core Web API for Enterprise Standards.

### What the project is
This project is a sophisticated backend service built with **ASP.NET Core** to handle core user operations. It focuses on implementing high-level corporate standards, including structured logging, custom security layers, and standardized error management.

### The purpose 
Developed as the **Final Module Project** for the Microsoft Back-End Development course, this API serves as a practical application of clean architecture. The goal was to build a service where business logic is strictly separated from cross-cutting concerns like logging and security through a custom middleware pipeline.

### Key Features
*   **Custom Middleware Stack:** Includes `InfoMiddleware` for request/response logging and `TokenValidationMiddleware` for security.
*   **Global Exception Handling:** A centralized system that catches errors and returns consistent JSON responses, eliminating the need for repetitive `try-catch` blocks.
*   **Decoupled Data Flow:** Uses **C# Records** as DTOs (`UserCreateDto`, `UserResponseDto`) to separate internal database models from the public API.
*   **Strict Input Validation:** Leverages Data Annotations to enforce business rules directly at the API entry point.
*   **Dependency Injection:** Full utilization of the .NET DI container for managing service lifetimes and promoting loose coupling.

### Challenges you faced and how you solved them
*   **Middleware Ordering:** Ensuring that logging occurs even when security or exception middleware triggers a short-circuit.
    *   **Solution:** Carefully structured the `Program.cs` pipeline to place the Global Exception Handler and Logging middleware at the very beginning of the stack to capture the full lifecycle of every request.
*   **Standardizing API Responses:** Providing the frontend with a predictable error format regardless of where the failure occurred.
    *   **Solution:** Implemented a custom middleware that intercepts all unhandled exceptions and maps them to a standardized `ErrorResponse` record.

### Setup or usage instructions

1. **Clone & Navigate:**
```bash
git clone [https://github.com/Szafter12/User-Management-API.git](https://github.com/Szafter12/User-Management-API.git)
cd User-Management-API
```
2. **Run Application:**
```bash
dotnet watch run
```
3. **Access Documentation:**
```bash
Open https://localhost:{port}/swagger to explore the interactive API documentation.
```
4. **Authentication:**
To access protected endpoints, use the following header:

- Key: Authorization
- Value: Bearer TechHive-Super-Secret-2026

### Technical concepts used

- Middleware Pipeline: Designing custom logic for the HTTP request/response flow.

- RESTful API Design: Implementing standard HTTP methods and status codes.

- C# 12 Records: Using immutable types for efficient data transfer.

- Structured Logging: Using ILogger to track API health and request telemetry.

- Data Annotations: Declarative validation for API security and integrity.

### Images
