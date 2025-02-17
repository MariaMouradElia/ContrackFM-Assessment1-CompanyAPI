# Company API

This project provides a RESTful API designed to manage information related to employees, customers, orders, and salaries using a MySQL database. It offers several endpoints that allow you to fetch data about employees, customers, orders, and the total salary sums by department.

# Setup Instructions

## 1️. Install Necessary Tools
- **.NET SDK** (Comes with Visual Studio OR can be downloaded separately):
  - If you **already installed Visual Studio**, the required .NET SDK is included.
  - If you **need to install .NET manually**, download it here:  
    [Download .NET SDK](https://dotnet.microsoft.com/en-us/download)
- **MySQL Server & MySQL Workbench**: [Download MySQL](https://dev.mysql.com/downloads/installer/)
- **Swagger UI** is included to test API endpoints through the browser.

## 2. Clone the Repository
git clone https://github.com/MariaMouradElia/ContrackFM-Assessment1-CompanyAPI.git
cd ContrackFM-Assessment1-CompanyAPI

## 3. Import the Database
- Open **MySQL Workbench**.
- **Create the database manually (if it doesn’t exist)**:
   ```sql
   CREATE DATABASE company; 
   ```
- Go to Server -> Data Import.
- Click "Import from Self-Contained File".
- Manually browse to the .sql file on your computer: C:\Personal\Courses\MySQL\CompanyAPI\MYSQL_FILES\Company.sql
- Click "Start Import" to import the database.
<!-- - Open MySQL Workbench.
- Go to Server -> Data Import.
- Select MYSQL_FILES/Company.sql and import it into your database. -->

## 4. Configure the Database Connection
- Open the appsettings.json file.
- Update the connection string to match your local MySQL database setup.
{
  "ConnectionStrings": 
  {
    "DefaultConnection": "server=localhost;database=company;user=root;password=yourpassword;"
  }
}
Note:  Replace yourpassword with your MySQL password and Make sure that "company" matches the name of the database you imported.

## 5. Install Dependencies
If using **Visual Studio**, dependencies are restored automatically.  
If using the **command line**, run:
dotnet restore

## 6. Run the API
  **Option 1: Using Visual Studio (Recommended)**
    - Open the project in **Visual Studio**.
    - Run your project to start the API.
  **Option 2: Using Command Line**
    - Run: dotnet run

## 7. Open Swagger UI
- Run the project, then check the terminal or browser for the assigned port. Look for a message like: Now listening on: https://localhost:7167
- By default, you can access Swagger UI at: https://localhost:{your-port}/index.html

Note: Replace `{your-port}` with the actual port displayed when you run the application.

### API Endpoints
Method	      Endpoint	                     Description
GET	       /api/employees	Get all employees and their departments.
GET	       /api/customers	Get all customers with their orders and total cost.
GET	       /api/orders	    Get all orders with product names (sorted by Order ID).
GET        /api/salary-sum	Get the sum of employee salaries by department.

### Technologies Used
.NET Core 6
Entity Framework Core
MySQL
Swagger UI