# AssetManagement

# Fleet Management System

## Overview
The Fleet Management System is a web application built using .NET with Clean Architecture principles. It helps organizations efficiently manage their fleet of vehicles, drivers, safety compliance, and maintenance records.

## Technologies Used
- **Backend**: .NET Core, ASP.NET Web API, Entity Framework Core
- **Frontend**: Razor Pages / Blazor / React (based on implementation)
- **Database**: SQL Server
- **Architecture**: Clean Architecture
- **Authentication**: Identity Framework / JWT Authentication
- **Logging**: Serilog

## Features
- **Vehicle Management**: Track and manage vehicles, including details such as model, make, year, and assigned drivers.
- **Driver Management**: Store driver information, including licenses, safety compliance, and assignments.
- **Safety Compliance**: Ensure drivers meet safety standards with certification tracking.
- **Maintenance Records**: Schedule and log vehicle maintenance activities.
- **Reports & Analytics**: Generate reports on fleet status, compliance, and maintenance.

## Project Structure
The project follows Clean Architecture principles:

 
FleetManagementSystem/
│── src/
│   ├── Application/        # Application layer (Use Cases, Services, DTOs)
│   ├── Domain/             # Core business logic, Entities, Aggregates
│   ├── Infrastructure/     # Data access, repositories, external integrations
│   ├── WebAPI/            # API layer, Controllers
│   ├── UI/                # Frontend (if applicable)
│── tests/                  # Unit and integration tests
│── README.md               # Project documentation
 

## Getting Started
### Prerequisites
- .NET SDK
- SQL Server
- Visual Studio / VS Code

### Setup & Run
1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/fleet-management-system.git
   cd fleet-management-system
   ```
2. Configure database connection in `appsettings.json`.
3. Apply migrations:
   ```sh
   dotnet ef database update
   ```
4. Run the application:
   ```sh
   dotnet run --project WebAPI
   ```

## API Endpoints
### Vehicles
- `GET /api/vehicles` - Get all vehicles
- `POST /api/vehicles` - Add a new vehicle
- `PUT /api/vehicles/{id}` - Update vehicle details
- `DELETE /api/vehicles/{id}` - Remove a vehicle

### Drivers
- `GET /api/drivers` - Get all drivers
- `POST /api/drivers` - Add a new driver
- `GET /api/drivers/{id}/safety-compliance` - Get driver safety records

## Contributing
1. Fork the repository.
2. Create a new branch (`feature/your-feature`).
3. Commit your changes.
4. Push to your branch and create a pull request.

## License
This project is licensed under the MIT License.

## Contact
For any inquiries, contact [your email].

