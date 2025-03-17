# Learning Clean Architecture

## 🏗️ Clean Architecture Project Structure
This project follows the **Clean Architecture** approach to ensure **scalability, maintainability, and testability**.

## 📂 Project Structure
```
StudentManagementSystem/  
│  
├── Core (Domain Layer)  
│   ├── Entities/  
│   │   ├── Student.cs  
│   ├── Interfaces/  
│   │   ├── IStudentRepository.cs  
│  
├── Application (Application Layer)  
│   ├── DTOs/  
│   │   ├── StudentDto.cs  
│   ├── Interfaces/  
│   │   ├── IStudentService.cs  
│   ├── Services/  
│   │   ├── StudentService.cs  
│   ├── Exceptions/  
│   │   ├── NotFoundException.cs  
│   ├── Validators/  
│   │   ├── StudentValidator.cs  
│  
├── Infrastructure (Infrastructure Layer)  
│   ├── Persistence/  
│   │   ├── AppDbContext.cs  
│   │   ├── StudentRepository.cs  
│   ├── Configurations/  
│   │   ├── StudentConfiguration.cs  
│  
├── Presentation (API Layer)  
│   ├── Controllers/  
│   │   ├── StudentController.cs  
│   ├── Middlewares/  
│   ├── Filters/  
│  
├── Tests (Unit and Integration Tests)  
│   ├── Application.Tests/  
│   ├── Infrastructure.Tests/  
│   ├── Presentation.Tests/  
│  
├── StudentManagementSystem.sln  
├── Program.cs  
├── appsettings.json  
```

## 🔗 Dependency Flow
```
+----------------------+
|   Presentation      |  (API Layer)
|----------------------|
| StudentController   | <--- Allowed to access
| Middleware, Filters |     Application Layer
+----------------------+
           |
           ▼
+----------------------+
|   Application       |  (Business Logic Layer)
|----------------------|
| StudentService      | <--- Allowed to access
| DTOs, Validators    |     Domain Layer
+----------------------+
           |
           ▼
+----------------------+
|   Domain (Core)     |  (Entities & Interfaces)
|----------------------|
| Student Entity      | <--- NO direct dependencies
| IStudentRepository  |     (Pure Business Logic)
+----------------------+
           ▲
           |
+----------------------+
|   Infrastructure    |  (Data Access & External)
|----------------------|
| StudentRepository   | <--- Implements Domain Interfaces
| AppDbContext        |     Accesses Database
+----------------------+
```

## 📌 Rules for Dependency Flow
✅ **Allowed Dependencies**  
- `Presentation` ➝ Can access `Application`  
- `Application` ➝ Can access `Domain`  
- `Infrastructure` ➝ Implements `Domain` but does not access `Application`  
- `Domain` (Core) is **independent** (No dependencies)  

🚫 **Not Allowed**  
- `Domain` **must not depend** on `Application`, `Infrastructure`, or `Presentation`.  
- `Application` **must not depend** on `Infrastructure` or `Presentation`.  
- `Presentation` **must not directly access** `Infrastructure`.  
