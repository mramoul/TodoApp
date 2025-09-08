# Todo Web App
<img width="1728" height="999" alt="Screenshot 2025-09-08 at 1 55 51 AM" src="https://github.com/user-attachments/assets/44821734-2d81-463b-80d6-c26ff045fea7" />

<img width="1711" height="993" alt="Screenshot 2025-09-08 at 2 08 10 AM" src="https://github.com/user-attachments/assets/d85170d3-64ab-438a-951b-fdfabaf8618f" />

<img width="1728" height="993" alt="Screenshot 2025-09-08 at 2 01 25 AM" src="https://github.com/user-attachments/assets/4c883622-ba3a-47f8-b9bf-a322a7232a80" />

## Overview
Todo API is a microservices-based application following the principles of Clean Architecture. It provides endpoints for managing tasks, and users in a kanban management system. The project is designed for scalability, separation of concerns, and maintainability.

## Architecture
The project adopts Clean Architecture, separating the application into distinct layers:
- **Domain Layer**: Contains business logic and entities.
- **Application Layer**: Implements use cases and application logic using MediatR for CQRS pattern.
- **Infrastructure Layer**: Handles database interaction, repositories, and external services.
- **API Layer**: Minimal API exposing endpoints using ASP.NET Core.

## Tech Stack
- **Angular +20**
- **Tools & IDEs:** VS Code, Docker Desktop, Postgres, Git
- **Libraries:**
  - ASP.NET Core Minimal API
  - Swagger (for API documentation)
  - MediatR (for CQRS)
  - Entity Framework Core (for data access)

## API Endpoints
<img width="1728" height="998" alt="Screenshot 2025-09-08 at 2 09 26 AM" src="https://github.com/user-attachments/assets/0826426c-415b-432d-9372-815b41f4773f" />

- `POST /task` - Creates a new task.
- `PATCH /task` - Updates a task.
- `PATCH /task-update-status` - Updates status of a task.
- `PATCH /task-assign-user` - Assign a user to a task.
- `GET /task-list` - Retrieves all tasks.
- `GET /task/{id}` - Retrieves a task by ID, includes assigned user.
- `DELETE /task/{id}` - Deletes a task.

- `POST /user` - Creates a new user.
- `PATCH /user` - Updates a user.
- `PATCH /user-assign-task` - Assign a task to a user.
- `GET /user/{id}` - Retrieves a user by ID, includes assigned tasks.
- `GET /user-list` - Retrieves all users.
- `DELETE /user/{id}` - Deletes a user.

## Setup Instructions
1. **Clone the Repository**
```bash
git clone https://github.com/mramoul/TodoApp.git
```
## API
```bash
cd api
docker build -t todo-api ./todoapi
docker run -p 5001:5001 todo-api
```
##UI
At the root of the project "TodoApp"
```bash
docker build -t todo-ui ./ui
docker run -p 4200:80 todo-ui
```

- Open Docker Desktop, locate the API container, and restart if needed.
- Access the application:
  - API: [http://localhost:5001/swagger](http://localhost:5001/swagger/index.html)
  - UI: [http://localhost:5001/swagger](http://localhost:4200)

- If docker option do not work, run the command "dotnet run" at the "api/ToDoApi" folder and "npm run install ng serve" at the "ui" one.
- NOTE: you may have to change the api url at the "TodoApp/ui/src/environments/environment.ts" with your api's instance.

## Future Enhancements
- **Fluent Validation:** Implement request validation and data sanitization.
- **Unit and Integration Testing:** Improve test coverage.
- **Authentication & Authorization:** Add access control to API routes.
