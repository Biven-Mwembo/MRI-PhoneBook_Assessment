Phonebook Application

Project Overview
This is a simple Phonebook Application developed to demonstrate problem-solving skills and an understanding of web technologies. The app allows users to perform basic CRUD operations (Create, Read, Update, Delete) on contacts in a phonebook, with an option to search for contacts by name or phone number.

Functional Requirements
Add Contact

Users can add new contacts with the following fields:
Name (required)
Phone Number (required, unique)
Email Address (optional)
Update Contact

Users can update existing contact details.
Delete Contact

Users can delete a contact from the phonebook.
Search Contact

Users can search for contacts by name or phone number.
Non-Functional Requirements
Frontend Framework:

The frontend is implemented using HTML/CSS/Bootstrap for a responsive, dynamic user interface.
Backend Framework:

The backend is implemented using ASP.NET Core (C#) for building the web Aplication that communicates with the database.
Database:

The data is stored in SQL Server
UI/UX:

The application includes a simple yet functional UI that allows users to interact with the phonebook. It is designed to be responsive for both desktop and mobile users.
Technologies Used
Frontend:

HTML/CSS/Bootstrap: For styling and responsiveness.
Backend:

ASP.NET Core: For building the backend API.
Entity Framework Core: For interacting with the SQL database.
Database:

SQL Server .
Development Tools:

Visual Studio for development.
Setting Up the Project
Prerequisites
.NET SDK: Ensure you have the .NET SDK installed. You can download it from here.
Node.js and NPM: Install Node.js and NPM from here.
Setting Up the Backend (ASP.NET Core)
Clone or download the repository to your local machine.
Open the backend folder in Visual Studio or Visual Studio Code.
Restore the NuGet packages by running the following command:
dotnet restore
Update the database connection string in appsettings.json to point to your local database.
Run the migrations to create the database schema:
dotnet ef database update
Start the backend server:
dotnet run
Testing the Application
Once both the backend and frontend are running, open your browser and navigate to interact with the phonebook application. You can add, update, delete, and search for contacts through the user interface.

Conclusion
This Phonebook Application demonstrates how to handle CRUD operations using ASP.NET Core for the backend and Angular for the frontend, with SQL Server as the database. The application is responsive and provides a simple yet effective UI for managing contacts.
