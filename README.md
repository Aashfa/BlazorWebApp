# Blazor Server Application

## 📌 Project Overview

This is a **Blazor Server** web application showcasing key enterprise-level features including reusable components, ADO.NET with 3-Tier Architecture, SQL Server integration, Web API interaction, form validation, and user-friendly UI design. The project demonstrates CRUD operations for multiple modules using best practices such as clean separation of concerns and data abstraction.

---

## 🛠️ Technologies Used

- **Blazor Server** (.NET 8)
- **ASP.NET Core Web API**
- **Microsoft SQL Server**
- **ADO.NET (SqlConnection, SqlCommand, SqlDataReader)**
- **3-Tier Architecture (Presentation, BLL, DAL)**
- **Entity Framework Core (Identity, planned)**
- **Visual Studio 2022/2024**
- **Git & GitHub**

---

## ✅ Key Features Implemented

### 📁 1. Reusable Blazor Components
- Modular UI built with Razor Components
- Parameterized components for reusability

### 🔗 2. Navigation & Data Binding
- Page-to-page routing via `NavLink`
- Binding with `@bind`
- Event handling using `@onclick`, etc.

### 🎨 3. UI Responsiveness
- Responsive layout using Bootstrap Grid and CSS Flexbox

### 🗃️ 4. SQL Server Database
- Database with tables
- Use of Primary and Foreign Keys
- Proper constraints and indexing

### 🔄 5. CRUD with 3-Tier Architecture
- **Presentation Layer**: Razor pages/components
- **Business Logic Layer (BLL)**: Handles business rules and logic
- **Data Access Layer (DAL)**: Performs raw SQL operations using ADO.NET
- **Web API**: Implemented REST API
  

### 🌐 6. RESTful Web API
- One module implemented as REST API with:
  - GET, POST, PUT, DELETE endpoints
- Consumed in Blazor app using `HttpClient`


---

## 📂 Project Structure

```plaintext
Blazor-web-App/
│
├── DAL/              # Data Access Layer (ADO.NET code)
├── BLL/              # Business Logic Layer
├── Entities/         # Entity Models
├── BlazorApp/        # Blazor Components
├── API/              # ASP.NET Core Web API Project

