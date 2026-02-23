# HotelBookingAPI_Project2
# Hotel Booking REST API

A secure and fully functional REST API for hotel room booking, built with ASP.NET Core as part of the second programming project.

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com)
[![Swagger](https://img.shields.io/badge/Swagger-UI-green.svg)](https://swagger.io)
[![JWT](https://img.shields.io/badge/Auth-JWT-orange.svg)](https://jwt.io)
[![SQLite](https://img.shields.io/badge/DB-SQLite-lightgrey.svg)](https://www.sqlite.org)

## Project Overview

This backend API allows users to:
- Register and log in (JWT authentication)
- View hotels and available room types
- Create, view, and cancel bookings
- Access protected endpoints only after authorization

### Key Features Implemented
- Full REST principles (GET, POST, proper status codes)
- Manual JWT authentication (no Microsoft Identity)
- Password hashing with BCrypt
- Automatic database seeding with test data
- Interactive API documentation & testing via Swagger
- Date overlap check for bookings (no double-booking)
- Role-based claims in JWT (Guest / Admin)

### Meets Assignment Requirements
- ASP.NET Core Web API
- Entity Framework Core (Code First + migrations)
- Minimum 4 related tables (actually 5)
- GET & POST endpoints
- Swagger integration
- JWT authentication & authorization

## Technologies & Tools

- **ASP.NET Core 8.0** – Web API framework
- **Entity Framework Core** – ORM, Code First migrations
- **JWT Bearer Authentication** – manual implementation
- **BCrypt.Net-Next** – secure password hashing
- **Swashbuckle.AspNetCore** – Swagger UI & OpenAPI
- **SQLite** – lightweight database for development
- **C# 12** – modern language features

## Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation & Run

1. Clone the repository
   ```bash
   cd hotel-booking-api
