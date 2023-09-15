Task Management System API
Overview
The Task Management System API provides endpoints for managing tasks, projects, users, and notifications. It allows users to create, manage, and track tasks and projects, and receive notifications. This README provides instructions on how to set up, run, and test the API.

Table of Contents
Prerequisites
Getting Started
Clone the Repository
Configuration
Database Setup
Run the Application
API Endpoints
Testing
Design Decisions
Assumptions
Prerequisites
Before you begin, ensure you have met the following requirements:

.NET SDK installed.
Visual Studio or another code editor.
SQL Server for database storage.
Postman or another API testing tool.
Getting Started
Clone the Repository
Clone the Task Management System repository to your local machine:

bash
Copy code
git clone https://github.com/yourusername/task-management-system.git
Configuration
Open the appsettings.json file and configure your database connection string, API keys, and other settings as needed.

json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "YourConnectionStringHere"
  },
  "AppSettings": {
    "SecretKey": "YourSecretKeyHere"
  }
  // Other settings...
}
Database Setup
Create the database by running migrations:

bash
Copy code
dotnet ef database update
Run the Application
Run the API:

bash
Copy code
dotnet run
The API should now be running at http://localhost:{port}.

API Endpoints
CRUD operations for Tasks, Projects, Users, and Notifications.
GET /api/tasks/status/{status}: Fetch tasks by status.
GET /api/tasks/priority/{priority}: Fetch tasks by priority.
GET /api/tasks/due-in-timeframe?startTime={startTime}&endTime={endTime}: Fetch tasks due within a time frame.
POST /api/tasks/assign-to-project: Assign a task to a project.
POST /api/tasks/remove-from-project: Remove a task from a project.
For detailed API documentation, refer to Swagger.

Testing
Use Postman or another API testing tool to test the API endpoints. You can import the provided Postman collection to get started.

Design Decisions
Clean Architecture: The application follows a clean architecture pattern to ensure separation of concerns.
Dependency Injection: Dependency injection is used for managing service and repository dependencies.
Domain-Driven Design (DDD): Aggregates, entities, and value objects are identified and designed based on DDD principles.
SOLID Principles: The application adheres to SOLID principles for better object-oriented design.

Assumptions
Users have authentication and authorization implemented separately.
The database connection string and other sensitive information are stored securely.
Error handling is implemented for API endpoints, returning appropriate HTTP status codes and error messages.
