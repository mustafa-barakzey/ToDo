# 📝 Todo API – Clean Architecture with CQRS

A modern **Todo API** built using **.NET**, following **Onion Architecture**, **CQRS**, and **Minimal APIs**.  
The project supports **Entity Framework Core**, **SQL Server**, **In-Memory database**, and includes **Unit Tests** and **Integration Tests**.

---

## 🚀 Features

✅ Minimal APIs  
✅ CQRS (Command Query Responsibility Segregation)  
✅ Onion Architecture  
✅ Entity Framework Core  
✅ SQL Server / In-Memory Database  
✅ JWT Authentication  
✅ Validation  
✅ Unit Tests  
✅ Integration Tests  

---

## 🧱 Architecture Overview
- |src/
- ├── Domain/ → Core business logic
- ├── Application/ → CQRS (Commands & Queries)
- ├── Infrastructure/ → Database & external services
- ├── WebApi/ → Minimal API (Presentation)
- |tests/
- ├── UnitTests/
- ├── ApplicationTests/
- ├── IntegrationTests/

---

## ⚙️ Tech Stack

- **.NET 9**
- **Minimal APIs**
- **Entity Framework Core**
- **SQL Server / InMemory**
- **CQRS**
- **JWT Authentication**
- **xUnit**
- **FluentAssertions**

---

## 📦 Prerequisites

- [.NET SDK 9](https://dotnet.microsoft.com/download)
- SQL Server (optional)

---

## 🔧 Setup & Run

### 1️⃣ Clone repository

```bash
git clone https://github.com/mustafa-barakzey/ToDo.git
cd todo-api
dotnet run --project src/WebApi
