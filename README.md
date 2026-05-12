# HRMS Pro - Backend API

HRMS Pro Backend API is built using .NET 8.0 and ASP.NET Core Web API.  
It provides a scalable and secure backend solution for managing employees, attendance, payroll, onboarding, and HR operations.

---

## 🚀 Technologies Used

- .NET 8.0 (ASP.NET Core Web API)
- Dapper (Micro ORM)
- SQL Server
- Microsoft.Data.SqlClient
- Swagger / OpenAPI
- Repository Pattern

---

## ✨ Features

- Secure Authentication & Authorization
- Employee Management
- Attendance Management
- Payroll Management
- Document Upload & Management
- Employee Onboarding
- Dashboard & Analytics
- RESTful API Architecture

---

## 📦 Project Structure

```text
Controllers/    → API endpoints
Repositories/   → Data access layer using Dapper
Data/           → Database configuration & context
Models/         → DTOs & entities
SQL/             → Stored procedures & SQL scripts
```

---

## ⚙️ Setup & Installation

### Prerequisites

- .NET 8 SDK
- SQL Server

---

## 🔧 Configuration

Update the connection string in:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=HRMS_Pro;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

> Do not store real database credentials in public repositories.

---

## ▶️ Run the Application

```bash
dotnet restore
dotnet run
```

API URL:

```text
http://localhost:5000
```

Swagger URL:

```text
http://localhost:5000/swagger
```

---

## 📄 API Documentation

Swagger/OpenAPI documentation is enabled for testing and API exploration.

---

## 👨‍💻 Author

Krunal Lad
