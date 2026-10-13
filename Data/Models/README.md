# AppointmentBookingAPI

A RESTful Appointment Booking API built with **ASP.NET Core Web API, C#, Entity Framework Core, and SQL Server**.

## Features

- View all service providers.
- Create new appointments.
- Retrieve all appointments.
- Retrieve a specific appointment by ID.
- Delete appointments.
- Validate appointment start and end times.
- Prevent appointments from being scheduled in the past.
- Prevent overlapping appointments for the same provider.
- Validate provider existence before booking.
- Test API endpoints using Swagger UI.

## Technologies Used

- C#
- ASP.NET Core Web API (.NET 9)
- Entity Framework Core
- Microsoft SQL Server
- Swagger / OpenAPI
- RESTful API principles

## API Endpoints

| HTTP Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Providers` | Get all service providers |
| GET | `/api/Appointments` | Get all appointments |
| GET | `/api/Appointments/{id}` | Get an appointment by ID |
| POST | `/api/Appointments` | Create a new appointment |
| DELETE | `/api/Appointments/{id}` | Delete an appointment |

## Sample Appointment Request

Use this JSON body when testing the `POST /api/Appointments` endpoint:

```json
{
  "customerName": "Moataz",
  "startTime": "2026-11-01T10:00:00",
  "endTime": "2026-11-01T10:30:00",
  "notes": "First appointment",
  "providerId": 1
}
```

**Note:** The appointment time must be in the future, and the selected provider must not have another appointment during the same time period.

## Database

The project uses SQL Server with Entity Framework Core.

- Database name: `AppointmentBookingDB`
- Providers and appointments are stored in the database.
- The application creates the database and tables using `EnsureCreated()`.
- Sample providers are added automatically when the providers table is empty.

## Run Locally

### Prerequisites

- .NET 9 SDK
- SQL Server Express
- Visual Studio Code or another compatible code editor

### Steps

1. Clone or download the repository.
2. Open the project folder in a terminal.
3. Configure the SQL Server connection string in `appsettings.json`.
4. Restore the required packages:

   ```bash
   dotnet restore
   ```

5. Build the project:

   ```bash
   dotnet build
   ```

6. Run the application:

   ```bash
   dotnet run
   ```

7. Open the Swagger URL displayed in the terminal to test the API endpoints.

## Project Repository

GitHub: [AppointmentBookingAPI](https://github.com/moataz-madyan/AppointmentBookingAPI)

## Author

**Moataz Madyan**

GitHub Profile: [https://github.com/moataz-madyan](https://github.com/moataz-madyan)

