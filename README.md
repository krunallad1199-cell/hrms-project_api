# HRMS Pro - Backend API

The backend for HRMS Pro is built using .NET 8.0, providing a robust and scalable foundation for human resource management. It utilizes a Repository Pattern with Dapper for efficient data access and stored procedures for business logic.

## 🚀 Technologies
- **Framework:** .NET 8.0 (ASP.NET Core Web API)
- **Database Access:** Dapper (Micro-ORM)
- **Database Provider:** SQL Server (Microsoft.Data.SqlClient)
- **Documentation:** Swagger / OpenAPI
- **Architecture:** Repository Pattern

## 🛠️ Key Features
- **Authentication:** Secure login and registration.
- **Employee Management:** CRUD operations for employee data.
- **Attendance:** Tracking and managing employee attendance.
- **Payroll:** Managing salaries and payslips.
- **Document Management:** Handling employee documents and uploads.
- **Onboarding:** Managing new hire onboarding processes.
- **Dashboard:** Aggregated statistics and analytics.

## ⚙️ Setup & Installation

### Prerequisites
- .NET 8.0 SDK
- SQL Server

### Configuration
1. Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=HRMS_Pro;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```
2. Ensure the SQL stored procedures are executed against your database (check the `SQL` folder).

### Running the API
```bash
dotnet restore
dotnet run
```
The API will be available at `http://localhost:5000` (or the port specified in `launchSettings.json`). You can access Swagger UI at `/swagger`.

## 📁 Project Structure
- `Controllers/`: API endpoints handling requests.
- `Repositories/`: Data access logic using Dapper.
- `Data/`: Database connection and context.
- `Models/`: Data transfer objects and entities.
- `SQL/`: SQL scripts and stored procedures.
