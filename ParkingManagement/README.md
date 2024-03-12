# Parking Management Application

This is a parking management application developed using ASP.NET MVC. It allows booking counter agents and parking zone assistants to manage parking spaces and bookings at various parking zones.

## Getting Started

To run the application locally, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution.
4. Update the connection string in the `Web.config` file to point to your database.
5. Update the log file path in the `Web.config` file to specify the location for log files.
6. Ensure that your database schema matches the entity models in your project.
7. Start the application.

## Usage

- **Log In:** Use your email and password to log in to the application.
- **Sign Up:** New users can sign up for an account by providing their email and creating a password.
- **Initialize Data (Booking Counter Agent Only):** If you are a Booking Counter Agent, you can initialize the application data by adding parking zones and spaces. This sets up the initial state of the application.
- **Dashboard:** The dashboard allows you to view and manage parking spaces. You can see a list of parking spaces sorted by parking zone and space title, along with their availability (vacant or occupied) and the vehicle registration number if occupied. The list automatically refreshes to show real-time updates.
- **Generate Reports (Booking Counter Agent Only):** Booking Counter Agents can generate reports that provide insights into parking space occupancy and usage trends. These reports can be exported to PDF for further analysis or sharing.

## Technologies Used

- ASP.NET MVC
- Entity Framework
- HTML/CSS
- JavaScript
- Bootstrap (for UI)
