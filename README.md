# Mutualista System - Web Application

This project implements a system for managing patient consultation requests at a mutual healthcare provider, allowing employees to handle consultations, clinics, patients, and appointment scheduling. The application is built using .NET Framework 4.5.2 or 4.6 with C# for the backend and SQL Server for data storage.

## Project Overview
The Mutualista System provides functionalities for managing employee access, patient requests, and consultations. Employees can log in to manage the following aspects:

- Employee registration and management
- Polyclinic creation and management
- Consultations and appointments scheduling
- Patient records management
- Consultation number requests
- Attendance tracking for consultations
- Generating statistical reports

The system is built on a three-layer architecture using the Factory and Singleton patterns for managing the logic and data access components. Data is retrieved and stored using ADO.NET.

## Technologies Used

- **Backend**: C# with .NET Framework 4.5.2 or 4.6
- **Frontend**: ASP.NET Web Forms
- **Database**: SQL Server
- **Data Access**: ADO.NET
- **Architecture**: Three-tier architecture (Presentation, Logic, Persistence)
- **Design Patterns**: Factory, Singleton

## Functionalities

### Public Pages
- **Login Page**: Allows employees to log in using their username and password.
- **Consultation List**: Displays upcoming consultations ordered by date and time.

### Employee Management
- **Add Employee**: Allows an admin to register a new employee with a unique username and password.

### Polyclinic Management
- **Add Polyclinic**: Allows the creation of new polyclinics with a unique code, name, and address.

### Consultation Management
- **Manage Consultations**: Allows employees to manage consultations, including creating consultations with unique identifiers, dates, doctors, and specialties.

### Patient Management
- **Manage Patients**: Allows employees to create and update patient records, including ID number, name, birthdate, and diagnosed conditions.

### Request Management
- **Add Request**: Allows a patient to request a number for an upcoming consultation, with the ability to track if the patient attended.

### Attendance Tracking
- **Mark Attendance**: Allows employees to mark whether a patient attended a consultation based on their request number.

### Filtering and Reporting
- **Filter Consultations**: Allows employees to filter consultations by polyclinic or date, with Linq to Objects for filtering.
- **Statistical Reports**: Provides reports on consultation attendance and consultation counts by polyclinic and consultory.

### Master Page
- **Navigation and User Info**: All non-public pages feature a master page with the current logged-in user's name, logout option, and a navigation menu for all available actions.

## Database Schema

The database is built using SQL Server, with manually written scripts for the database schema, including stored procedures, constraints (unique, check, and default), and sample data.

The following tables are included in the database:

- **Employees**
- **Polyclinics**
- **Consultations**
- **Patients**
- **Requests**
- **Attendance Records**

### Prerequisites

- **Microsoft Visual Studio** with .NET Framework 4.5.2 or 4.6
- **SQL Server** (LocalDB or a full installation)
- **Microsoft SQL Server Management Studio** (optional for manual database management)

Database Model: Model Conceptual, ER Diagram, and RNE.
UML Diagrams: Detailed class diagrams showing the architecture and components.
Scripts: SQL scripts for database creation and population.
All diagrams are provided in UML format and as PDFs.

Contribution
Feel free to fork the repository and submit pull requests for improvements or bug fixes. Please ensure to follow the project's structure and naming conventions.
