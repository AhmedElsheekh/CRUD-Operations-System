# ASP.NET MVC CRUD Operations System

## Overview

This ASP.NET MVC CRUD operations system is designed to facilitate Create, Read, Update, and Delete operations on a database. It utilizes the Model-View-Controller (MVC) architectural pattern to separate concerns and provide a structured approach to handling data.

## Features

* **Create**: Add new records to the database.
* **Read**: Retrieve and display data from the database.
* **Update**: Modify existing records in the database.
* **Delete**: Remove records from the database.

## Technologies Used

* **ASP.NET MVC**: Framework for building web applications.
* **Entity Framework (EF)**: ORM tool for database interactions.
* **C#**: Programming language for backend logic.
* **HTML/CSS/JavaScript**: Frontend development tools for user interfaces.
* **SQL Server**: Database management system for storing data.

## Setup Instructions

1. **Clone Repository**: Clone this repository to your local machine.
   ```
   git clone https://github.com/your-username/aspnet-mvc-crud.git
   ```

2. **Open Solution**: Open the solution file (`Demo.DAL.sln`) in Visual Studio.

3. **Database Configuration**:
   - Modify the connection string in `Web.config` to point to your SQL Server instance.
   - Run the migrations to create the database schema:
     ```
     Update-Database
     ```

4. **Build and Run**:
   - Build the solution and resolve any dependencies.
   - Run the application in your preferred browser.

## Usage

1. **Homepage**:
   - The homepage displays a list of existing records from the database.
   - Use the navigation menu to access different CRUD operations.

2. **Create**:
   - Click on the "Add New" button to create a new record.
   - Fill in the required information and submit the form.

3. **Read**:
   - Click on Details button beside a record to view its details.
   - Use the search or filter options to find specific records.

4. **Update**:
   - Navigate to the record you want to update.
   - Click on the "Edit" button, make changes, and save the updated record.

5. **Delete**:
   - Navigate to the record you want to delete.
   - Click on the "Delete" button to remove the record from the database.

## Contributing
Contributions are welcome! Feel free to fork the repository and submit pull requests for any enhancements or bug fixes.
