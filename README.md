# AppointmentBookingAPI

A RESTful Appointment Booking API built with **ASP.NET Core Web API, C#, Entity Framework Core, and SQL Server**.

## Overview

AppointmentBookingAPI is a backend project designed to manage service providers and customer appointments. It provides RESTful endpoints for creating, retrieving, and deleting appointments while validating booking times and preventing scheduling conflicts.

## Features

- Retrieve all service providers.
- Create new appointments.
- Retrieve all appointments.
- Retrieve an appointment by ID.
- Delete an appointment.
- Validate appointment start and end times.
- Prevent appointments from being scheduled in the past.
- Prevent overlapping appointments for the same provider.
- Validate provider existence before booking.
- Explore and test endpoints using Swagger UI.

## Technologies Used

- C#
- ASP.NET Core Web API (.NET 9)
- Entity Framework Core
- Microsoft SQL Server
- Swagger / OpenAPI
- RESTful API architecture

## API Endpoints

| HTTP Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Providers` | Retrieve all providers |
| GET | `/api/Appointments` | Retrieve all appointments |
| GET | `/api/Appointments/{id}` | Retrieve an appointment by ID |
| POST | `/api/Appointments` | Create an appointment |
| DELETE | `/api/Appointments/{id}` | Delete an appointment |

## Sample Request

Example JSON body for `POST /api/Appointments`:

```json
{
  "customerName": "Moataz",
  "startTime": "2026-11-01T10:00:00",
  "endTime": "2026-11-01T10:30:00",
  "notes": "First appointment",
  "providerId": 1
}
```

The selected provider must exist, the appointment must be scheduled in the future, and its time slot must not overlap with another appointment for the same provider.

## Database

The application uses SQL Server and Entity Framework Core.

- **Database:** `AppointmentBookingDB`
- **Providers:** Stores service provider information.
- **Appointments:** Stores customer bookings and appointment details.
- The application creates the database and tables using `EnsureCreated()`.
- Sample providers are inserted automatically when the providers table is empty.

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server Express
- Visual Studio Code or another compatible editor

### Installation and Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/moataz-madyan/AppointmentBookingAPI.git
   ```

2. Navigate to the project directory:

   ```bash
   cd AppointmentBookingAPI
   ```

3. Configure the SQL Server connection string in `appsettings.json`.

4. Restore dependencies:

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

7. Open the Swagger URL displayed in the terminal to explore and test the API.

## Project Structure

```text
AppointmentBookingAPI/
├── Controllers/
│   ├── AppointmentsController.cs
│   └── ProvidersController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── Appointment.cs
│   └── Provider.cs
├── appsettings.json
├── Program.cs
├── .gitignore
└── README.md
```

## Future Improvements

- Add appointment update functionality.
- Implement user authentication and authorization.
- Add appointment cancellation status.
- Introduce automated unit and integration tests.
- Improve validation and error handling.

## Author

**Moataz Madyan**

- GitHub Profile: [moataz-madyan](https://github.com/moataz-madyan)
- Project Repository: [AppointmentBookingAPI](https://github.com/moataz-madyan/AppointmentBookingAPI)
