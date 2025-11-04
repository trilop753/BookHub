# PV179_BookHub | Seminar 3 | Team 8

## Team members:
- xmackov1  
- xpavlik9  
- xkala  

# BookHub

BookHub is a digital platform for online book sales across various genres. It allows users to easily browse, filter, and purchase books by author, publisher, and genre. Registered users can manage their accounts, write reviews, create wishlists, and view their order history. Administrators have extended privileges — they can manage books, prices, and user accounts.

---

## Project Information

**Technologies:**
- C# (.NET 8 / ASP.NET Core Web API)
- Entity Framework Core (Code First)
- SQLite (main application database)
- LiteDB (log database)
- Swagger for API documentation
- Repository pattern
- Middleware for authentication and logging
- GitLab CI/CD for merge requests

**Repository:**
The project is hosted on *GitLab* with **Internal** visibility.  
All changes are made through separate branches and merged via Merge Requests after approval from another team member.

---

## Features

### Users
- Registration and login
- Browsing, filtering, and sorting books
- Adding books to the cart and wishlist
- Purchasing books (creating orders)
- Rating and reviewing books
- Viewing order history

### Administrator
- Managing user accounts (including banning users)
- Adding, editing, and deleting books
- Changing book prices
- Managing authors, publishers, and genres

### System Features
- REST API with CRUD operations for all entities
- Cache mechanism (refreshes every 10 minutes)
- Logging middleware (records all incoming requests)
- Unit tests with mocked repositories
- Simple authentication middleware using a hard-coded token
- CD/CD pipeline
- Logging to LiteDB (bookhub-logs-litedb.db)

---

## Architecture and Data Model

### Data Model
![ERD Diagram](/Docs/Images/erd-bookhub.png)

**Main entities:**
- **User** – contains user data and role (User/Admin)
- **Book** – book entity with references to author, publisher, and genres
- **Order / OrderItem** – represents purchase records
- **CartItem / WishlistItem** – manages shopping cart and wishlist
- **Review** – user ratings and comments
- **Genre / Author / Publisher / Role** – supporting entities

Relationships include *1:N* (e.g., User–Order) and *N:M* (e.g., Book–Genre via Book_Genre table).

---

### Use Case Diagram
![Use Case Diagram](/Docs/Images/use-case-bookhub.png)

**Main user actions:**
- Registered users can purchase, rate, and manage their wishlist.
- Unregistered users can only browse books.
- Administrators have additional permissions to manage books and accounts.

## Continuous Integration / Deployment

### GitLab Pipeline
GitLab CI/CD runs for each Merge Request and ensures only successful pipelines can be merged.
This project's pipeline:
- Restores packages
- Builds the solution in Release mode
- Runs all unit tests
- Allows merge only if the pipeline succeeds

## Running the Project

### 1. Clone the repository
```bash
git clone https://gitlab.fi.muni.cz/xmackov1/pv179_bookhub
```
```bash
cd pv179_bookhub
```

### 2. Configure the database connection
The project uses a SQLite database.
By default, the connection string in `appsettings.json` points to a local database stored in your user directory:
```json
"ConnectionStrings": {
    "DefaultConnection": "Data Source=%LocalAppData%\\bookhub.db"
},
```
You can modify the path or file name in the connection string if you want to store the database elsewhere.

### 3. Run the project

#### In Visual Studio
1. Open the `BookHub.sln` solution.
2. Set `WebAPI` as the startup project.
3. Select the `https` profile in the toolbar.
4. Click Start or F5.

The project will build, apply migrations automatically, and open Swagger UI in your browser:
```bash
https://localhost:7004/swagger
```

## From the command line
```bash
cd WebAPI
dotnet restore
dotnet build
dotnet ef database update
dotnet run --launch-profile "https"
```

The project will build.
```bash
https://localhost:7004/swagger
```

### 5. Authorization
Secret token for authorization:
```bash
supersecrettoken123
```
In Swagger, click Authorize, choose Bearer Token, and paste the token there.

## Testing
Run tests:
```bash
dotnet test
```

