# 📂 Employee Management System

Welcome to the **Employee Management System** repository! This project is designed to help organizations efficiently manage employee information. Whether you're a small business or a large enterprise, this system provides a user-friendly interface to handle employee data, roles, departments, and more.

Note: This project is listed under the master branch.

## 🚀 Features

### Employee Management 👥
- Add, update, delete, and view employee details (name, email, phone number, job title).

### Department Management 🏢
- Organize employees into departments and manage department-specific information.

### Role Management 📋
- Assign roles to employees and define their responsibilities.

### Search & Filter 🔍
- Easily search and filter employees by name, department, or role using AJAX for a seamless user experience.

### Responsive Design 📱
- Built with Bootstrap for a clean, modern, and mobile-friendly interface.

### Database Integration 🗃️
- Uses SQL Server for reliable and secure data storage.

### User Authentication 🔒
- Secure login and registration system to protect sensitive data.

### Payslips 📄
- Create payslips, and employees can view them.

### Export Data 📊
- Export employee data to CSV or PDF for reporting purposes.

## 🛠️ Technologies Used

- **Framework:** Microsoft .NET Framework
- **Architecture:** MVC (Model-View-Controller)
- **Programming Language:** C#
- **Database:** SQL Server
- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **AJAX:** For asynchronous data loading and seamless user interactions
- **Authentication:** Forms Authentication (or custom authentication logic)
- **Icons:** Font Awesome, Bootstrap Icons

## 📦 Installation

Follow these steps to set up the Employee Management System locally:

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/Philani56/Management-System
```

### 2️⃣ Open the Project in Visual Studio
- Launch **Visual Studio**.
- Open the project by navigating to the cloned repository folder.

### 3️⃣ Set Up the Database
- Open **SQL Server Management Studio (SSMS)**.
- Create a new database (e.g., `EmployeeManagementDB`).
- Update the connection string in the `web.config` file:

```xml
<connectionStrings>
  <add name="EmployeeDBContext" connectionString="Server=your-server-name;Database=EmployeeManagementDB;Integrated Security=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4️⃣ Run Database Migrations (if applicable)
If using **Entity Framework Code First**, run the following command in the **Package Manager Console**:

```powershell
Update-Database
```

### 5️⃣ Build and Run the Project
- **Build the solution** in Visual Studio (`Ctrl + Shift + B`).
- **Run the project** (`F5` or click the "Start" button).

### 6️⃣ Access the Application
- Open your browser and navigate to `http://localhost:port` (check the port number in Visual Studio).

## 🖥️ Usage

### 🔑 Login
- Use the login page to access the system.
- If you don't have an account, register first.

### 👥 Add Employees
- Navigate to the **Employees** section.
- Click "Add Employee" to enter new employee details.

### 🏢 Manage Departments
- Go to the **Departments** section to add, update, or delete departments.

### 📋 Assign Roles
- In the **Roles** section, assign roles to employees and define their responsibilities.

### 🔍 Search Employees
- Use the search bar to filter employees by name, department, or role.
- Results load dynamically using AJAX.

### 📄 Export Data
- Export employee data to **CSV** or **PDF** for reporting purposes.

### 💰 Payslips
- Create payslips for employees to view.

## 📄 Code Structure

This project follows the **MVC (Model-View-Controller)** architecture:

- **Models/** – Contains database entities (e.g., `Employee.cs`, `Department.cs`).
- **Views/** – Contains Razor views (e.g., `Index.cshtml`, `Create.cshtml`).
- **Controllers/** – Contains business logic (e.g., `EmployeeController.cs`, `DepartmentController.cs`).
- **Scripts/** – Contains JavaScript and AJAX scripts for dynamic functionality.
- **App_Data/** – Contains the SQL Server database file (if using LocalDB).

## 🤝 Contributing

We welcome contributions from the community! Follow these steps to contribute:

1. **Fork** the repository.
2. **Create a new branch** for your feature or bugfix.
3. **Commit your changes**.
4. **Push your branch** and open a **pull request**.

## 📜 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for more details.

## 📧 Contact

If you have any questions or suggestions, feel free to reach out:

📩 **Email:** khumalophilani580@gmail.comn  
🐞 **GitHub Issues:** [Open an Issue](https://github.com/Philani56/Management-System/issues)

Thank you for using the **Employee Management System**! We hope it simplifies your employee management tasks. 😊

