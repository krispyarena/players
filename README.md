# Players CRUD Application

This repository contains a CRUD (Create, Read, Update, Delete) application for managing football players, built with ASP.NET MVC and Entity Framework.

## Features

- **Create**: Add new football players with details such as name, position, and team.
- **Read**: View a list of all football players and search for specific players.
- **Update**: Edit the details of existing football players.
- **Delete**: Remove football players from the database.
- **Responsive UI**: User-friendly interface designed with ASP.NET MVC.

## Getting Started

### Prerequisites

- .NET 6 SDK or later
- SQL Server or another compatible database

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/krispyarena/players.git
   cd players
   ```

2. Set up the database:
   - Update the connection string in `appsettings.json` to point to your database.
   - Run the database migrations to set up the schema:
     ```sh
     dotnet ef database update
     ```

3. Run the application:
   ```sh
   dotnet run
   ```

4. Open your browser and navigate to `https://localhost:5001` to see the app in action.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server

## Contributing

Contributions are welcome! Please fork this repository and submit pull requests with your changes.

## License

This project is licensed under the MIT License.
