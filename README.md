# Phonebook Application

## Project Overview
This is a simple Phonebook Application developed to demonstrate problem-solving skills and an understanding of web technologies. The app allows users to perform basic CRUD operations (Create, Read, Update, Delete) on contacts in a phonebook, with an options to search for contacts by name or phone number,filter  from A-Z, Restore Deleted Contatcs.

## Functional Requirements

### 1. Add Contact
- Users can add new contacts with the following fields:
  - **Name** (required)
  - **Phone Number** (required, unique)
  - **Email Address** (optional)

### 2. Update Contact
- Users can update existing contact details.

### 3. Delete Contact
- Users can delete a contact from the phonebook.

### 4. Search Contact
- Users can search for contacts by name or phone number.

## Non-Functional Requirements

### 1. Frontend Framework
- The frontend is implemented using **HTML**, **CSS**, and **Bootstrap** for a responsive, dynamic user interface.

### 2. Backend Framework
- The backend is implemented using **ASP.NET Core** (C#) for building the web application that communicates with the database.

### 3. Database
- The data is stored in **SQL Server**.

### 4. UI/UX
- The application includes a simple yet functional UI that allows users to interact with the phonebook. It is designed to be responsive for both desktop and mobile users.

## Technologies Used

### Frontend
- **HTML/CSS/Bootstrap**: For styling and responsiveness.

### Backend
- **ASP.NET Core**: For building the backend API.
- **Entity Framework Core**: For interacting with the SQL database.

### Database
- **SQL Server**: For data storage.

### Development Tools
- **Visual Studio** for development.

## Setting Up the Project

### Prerequisites

- **.NET SDK**: Ensure you have the **.NET SDK** installed. You can download it from [here](https://dotnet.microsoft.com/download).
- **Node.js and NPM**: Install **Node.js** and **NPM** from [here](https://nodejs.org/).

### Setting Up the Backend (ASP.NET Core)

1. Clone or download the repository to your local machine.
2. Open the backend folder in **Visual Studio** or **Visual Studio Code**.
3. Restore the NuGet packages by running the following command:
   ```bash
   dotnet restore
4.Update the database connection string in appsettings.json to point to your local database.
5.Run the migrations to create the database schema:
5.Run the migrations to create the database schema:

    dotnet ef database update
6. Start the backend server:
```bash
    dotnet run
