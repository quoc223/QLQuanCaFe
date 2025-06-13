DOCUMENT: https://deepwiki.com/quoc223/QLQuanCaFe
---

## ⚙️ Core System Components

### 🔹 Application Entry Point
- `Program.cs`: Initializes the WinForms environment and starts `Loginfrm`.

### 🔹 User Interface Layer
- `Loginfrm`: User authentication screen
- `AdminFrm`: Main dashboard for management tasks
- `ProfileFrm`: Account and profile settings

### 🔹 Data Access Layer (DAO Pattern with Singleton)
- `AccountDAO`: Handles login and user management
- `BillDAO`: Manages billing operations
- `CategoryDAO`: Manages food categories
- `FoodDAO`: Handles CRUD for food items
- `TableDAO`: Tracks restaurant table status
- `MenuDAO`: Displays menus for selection
- `BillInforDAO`: Tracks individual items in bills

### 🔹 Core Infrastructure
- `DataProvide`: Singleton pattern for managing DB connections
- `DTOs`: Used for data transfer between layers

---

## 🧰 Technology Stack

| Component        | Technology          | Notes                           |
|------------------|---------------------|----------------------------------|
| Framework        | .NET Framework 4.7.2| Desktop development              |
| UI               | Windows Forms       | Traditional Windows UI          |
| Database         | SQL Server          | QL_QUANCAFE schema               |
| Configuration    | App.config          | Connection strings, settings    |
| Assembly Info    | AssemblyInfo.cs     | App metadata & versioning       |
| App Version      | QLBANCAFE 1.0.0.0   |                                 |

---

## 🧩 Functional Areas

| Area                        | Description                                                                 |
|-----------------------------|-----------------------------------------------------------------------------|
| 🛡️ Authentication & Security | Login system with role-based access control                                |
| 🍽️ Menu Management           | CRUD operations for food items and categories                              |
| 🪑 Table Management          | Allocation and real-time status tracking of restaurant tables               |
| 💰 Billing & Finance         | Billing flow, invoice creation, and revenue reporting                       |
| 👤 Account Management        | Manage user accounts and permissions                                        |

All operations interact through the `DataProvide` singleton, using DAO classes and DTOs to ensure consistency and clean separation of concerns.

---

## 📝 Configuration & Setup

- Configure your database connection string in `App.config`
- Build and run the project via Visual Studio (targeting .NET Framework 4.7.2)
- Make sure the SQL Server contains the `QL_QUANCAFE` database schema

---

## 📁 Key Files

- `Program.cs`: App entry point
- `App.config`: Configuration settings
- `Properties/AssemblyInfo.cs`: Versioning info
- `DataProvide.cs`: Centralized DB handler
- `DAO/`: Contains all data access classes
- `DTO/`: Contains all data transfer objects
- `Forms/`: UI components for login, dashboard, etc.

---

## 👨‍💻 Author

Nguyễn Anh Quốc  
📧 nguyenanhquoc2123@gmail.com  
🔗 [GitHub: quoc223](https://github.com/quoc223)

---

## 📜 License

This project is intended for educational and non-commercial use only.
