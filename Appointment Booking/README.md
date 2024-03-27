# Book an Appointment

This project enables patients to book appointments with doctors based on their availability. Doctors can manage their appointments and view reports, while patients can book appointments without logging in.

## Features

- **Doctor Sign-in:** Doctors can sign in to manage their appointments.
- **Patient Booking:** Patients can book appointments without signing in.
- **Appointment Management:** Doctors can view upcoming appointments and update appointment statuses.
- **Reports:** Appointment summary and detailed reports are available for viewing and exporting to PDF.

## Getting Started

To run the application locally, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution.
4. Update the connection string in the `appsettings.json` file.
5. Ensure that your database schema matches the entity models.
6. Start the application.

## Usage

- **Doctor Section:**
  - View and manage appointments.
  - Close or cancel appointments.

- **Patient Section:**
  - Book appointments by selecting a doctor and time slot.

- **Reports:**
  - View appointment reports in the browser.
  - Export reports to PDF.

## Technologies Used

- ASP.NET CORE MVC
- ASP.NET CORE API
- Entity Framework
- HTML/CSS
- JavaScript
- Bootstrap

## Scope of Work

- Initialize Data:
  - Add doctor records.
  - Remove all transactional data from the appointment records.

- Sign-in (Doctor):
  - Doctors can sign in using their email and password.

- Sections:
  - Doctor Section:
    - View upcoming appointments and filter by date.
    - Close or cancel appointments.

  - Reports Section:
    - Appointment Summary Report.
    - Appointment Detailed Report.

- Patient Section:
  - Book an Appointment.