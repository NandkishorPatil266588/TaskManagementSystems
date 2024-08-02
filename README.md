# TaskManagementSystem

## Problem Statement

As the MD, I needed a task management system to address the following requirements:

- **Employees** should be able to:
  - Track their individual tasks
  - Attach documents
  - Add notes
  - Mark tasks as complete

- **Employee Managers** or **Team Leaders** should be able to:
  - Monitor the tasks of all their team members

- **Company Admin** should be able to:
  - Generate reports to assess team performance, including:
    - Task completion rates over specified periods (e.g., weekly, monthly)

## Project Overview

This project is a task management system designed to meet the above requirements using the CQRS pattern. The technologies used include:

- **Backend/API Layer**: .NET Core, Entity Framework Core (EF Core), and a relational database (SQL Server/MSSQL/Postgres)
- **Authentication**: JWT (JSON Web Token)
- **Asynchronous APIs**: All APIs are implemented asynchronously
- **Data Validation**: Included in the API layer
- **Exception Handling**: Implemented throughout the application

## Setup Instructions

### Database Connection

To set up the project for testing, update the connection string in the `appsettings.json` file with the appropriate URL for your testing environment.

### Migrations

1. **Add a New Migration**

   To create a new migration, run the following command:

   ```bash
   add-migration [MigrationName]
   update-database


