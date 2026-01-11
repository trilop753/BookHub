# PV179_BookHub

## Team members:

- Maroš Pavlík
- Martin Mackovič
- Adam Kala

# BookHub

BookHub is a digital platform for online book sales across various genres. It allows users to easily browse, filter, and purchase books by author, publisher, and genre. Registered users can manage their accounts, write reviews, create wishlists, and view their order history. Administrators have extended privileges — they can manage books, prices, and user accounts.


<img width="1859" height="989" alt="image" src="https://github.com/user-attachments/assets/41dab6d6-ed87-4d29-8ac8-414424671cd6" />

<img width="1859" height="1311" alt="image" src="https://github.com/user-attachments/assets/7b7fa51f-46ea-45be-af60-1fa59ffbef3f" />

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

Relationships include _1:N_ (e.g., User–Order) and _N:M_ (e.g., Book–Genre via Book_Genre table).

---

### Use Case Diagram

![Use Case Diagram](/Docs/Images/use-case-bookhub.png)

**Main user actions:**

- Registered users can purchase, rate, and manage their wishlist.
- Unregistered users can only browse books.
- Administrators have additional permissions to manage books and accounts.

---

## Middleware

### Authentication Middleware

The `AuthenticationMiddleware` verifies all incoming requests for a valid Bearer Token.
Requests without the correct token return a `401 Unauthorized` response.

Token used for testing:

```bash
secrettoken123
```

### Response Format Middleware

The `ResponseFormatMiddleware` automatically converts API responses between `JSON` and `XML`.

- Default format: `JSON`
- XML can be requested using either:
  - The Accept header (e.g., application/xml), or
  - The query parameter ?format=xml

### Logging Middleware

All incoming HTTP requests are logged into a LiteDB database (bookhub-logs-litedb.db).
Logs include timestamp, request path, and status code.

---

## Data Seeding

Data seeding is implemented using the Bogus NuGet package to generate sort of realistic fake data for development.
This makes it easy to populate all models consistently.

---

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

### 2. Configure the database connection

The project uses a SQLite database.
By default, the connection string in `appsettings.json` is a name of a database that will be created in your user directory (.local/share):

```json
  "ConnectionStrings": {
    "DefaultConnection": "bookhub-mvc.db",
    "LogDatabase": "bookhub-logs-litedb.db"
  },
  "CoverImageStorage": "bookhub-cover-image-storage",
```
### 3. Run the project

#### In Visual Studio

1. Open the `BookHub.sln` solution.
2. Set `WebAPI` or `WebMVC` as the startup project.
3. Select the `https` profile in the toolbar.
4. Click Start or F5.

The project will build, apply migrations automatically, and open Swagger UI in your browser:

```bash
https://localhost:7004/swagger
```

Or for the MVC project:

```bash
https://localhost:7260/
```

## From the command line

```bash
cd WebAPI
dotnet restore
dotnet build
dotnet ef database update
dotnet run --launch-profile "https"
```

Or for the MVC project:

```bash
cd WebMVC
dotnet restore
dotnet build
dotnet ef database update
dotnet run --launch-profile "https"
```

The project will build.

```bash
https://localhost:7004/swagger
```

Or for the MVC project:

```bash
https://localhost:7260/
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
