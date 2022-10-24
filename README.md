# BookManagement

## Building ASP.NET Web API with Entity 
Framework Core and Web Application

### Introduction
1. Imagine you're an employee of a company named eBookStore. Your manager 
has asked you to develop a Web application for user management, publisher 
management, book management, author management and the book-author 
management. The application has a default account whose email is 
“admin@ebookstore.com” and password is “admin@@” that stored in the 
appsettings.json.
2. The application has to support adding, viewing, modifying, and removing 
information - a standardized usage action verbs better known as Create, Read, 
Update, Delete (CRUD) and Search. This assignment explores creating an 
ASP.NET Core Web API , and ADO.NET or Entity Framework Core, the Web 
Application (ASP.NET Core Web MVC or Razor Pages). An MS SQL Server 
database will be created to persist the data and it will be used for reading and 
managing data.

### Assignment Objectives
In this assignment, you will:
- Use the Visual Studio.NET to create a Web application and ASP.NET Core 
Web API project (with OData support).
- Perform CRUD actions using Entity Framework Core with Code First 
approach.
- Using OData (a data access protocol for the web) to query and manipulate 
data sets.
- Apply 3-layers architecture to develop the application.
- Apply Repository pattern and Singleton pattern in a project.
- Add CRUD and searching actions to the Web application with ASP.NET 
Core Web API.
- Apply to validate data type for all fields. 
- Run the project and test the actions of the Web application.

### Database Design

![image](https://user-images.githubusercontent.com/63900676/197526241-af422467-722d-4a7f-af08-3de537729227.png)

### Main Functions
- Create database with Forward Engineering approach (create model classes 
and DB context class and migration). 
- Create Web API with OData: Book management, Author management, and 
Publisher management: Read, Create, Update and Delete actions.
- Create Client application (with Desktop/Web application) interactive with 
WebAPI to perform these functions: 
- Search BookName and Price
- Member authentication by Email and Password. If the user is “Admin”
then allows to perform all actions, otherwise, the normal user is 
allowed to view/update the profile.


