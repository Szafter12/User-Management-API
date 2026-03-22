# User Management API

A robust ASP.NET Core Web API built as the **Final Module Project** for the **Microsoft Back-End Development with .NET** course. This project demonstrates clean architecture principles, standardized error handling, and custom middleware implementation.

---

## Project Overview
The **User Management API** is designed to handle core user operations while enforcing corporate-level standards for logging, security, and error management. It serves as a practical application of the concepts learned throughout the Microsoft .NET Back-End module, focusing on building scalable and maintainable web services.

## 🛠 Features & Architecture

### 1. Custom Middleware Pipeline
The project implements a sophisticated middleware stack to ensure the API is reliable, secure, and easy to audit:
* **Global Exception Handling**: A dedicated middleware that catches unhandled exceptions and returns standardized JSON error responses, keeping the controllers clean from `try-catch` blocks.
* **Request/Response Logging (`InfoMiddleware`)**: Custom middleware that logs every incoming HTTP request (Method & Path) and outgoing response (Status Code) to the console using `ILogger`.
* **Token-Based Security**: A custom `TokenValidationMiddleware` that mimics real-world authentication by validating Bearer tokens before allowing access to protected endpoints.

### 2. Data Transfer Objects (DTOs)
To decouple internal models from the public API, the project utilizes **C# Records**:
* `UserCreateDto`: Includes strict **Data Annotations** for input validation (Required, StringLength, EmailAddress).
* `UserResponseDto`: An immutable record optimized for sending data back to the client.
* `UserUpdateDto`: Specialized for handling partial or full user updates.

### 3. Dependency Injection (DI)
The project heavily relies on the built-in .NET DI container to manage service lifetimes and provide loggers/services to the middleware and controllers, ensuring a loosely coupled architecture.

## Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or newer.
* An IDE (Visual Studio 2022, VS Code, or JetBrains Rider).

### Installation & Running
1.  Clone the repository:
    ```bash
    git clone [https://github.com/Szafter12/User-Management-API.git](https://github.com/Szafter12/User-Management-API.git)
    ```
2.  Navigate to the project directory:
    ```bash
    cd User-Management-API
    ```
3.  Run the application:
    ```bash
    dotnet watch run
    ```

## Testing the API
Once the API is running, you can explore the endpoints via **Swagger UI**:
`https://localhost:{port}/swagger`

### Authentication
To access protected endpoints, you must include a `Bearer` token in your HTTP header:
* **Key**: `Authorization`
* **Value**: `Bearer TechHive-Super-Secret-2026`

## Course Context
This repository represents the culmination of skills acquired during the **Microsoft Back-End Development with .NET** course. Key areas covered include:
* RESTful API design.
* Advanced Middleware Pipeline configuration.
* Structured Logging with `ILogger`.
* Asynchronous programming in C#.
* Global error handling strategies.
