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
- SQLite (for development)
- Swagger for API documentation
- Repository pattern
- Middleware for authentication and logging

**Repository:**
The project is hosted on GitLab with **Internal** visibility.  
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
- Simple authentication middleware using a hard-coded token

---

## Architecture and Data Model

### Data Model
// TODO: add image after refactor

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
// TODO: add image after refactor

**Main user actions:**
- Registered users can purchase, rate, and manage their wishlist.
- Unregistered users can only browse books.
- Administrators have additional permissions to manage books and accounts.

---

## Running the Project

### 1. Clone the repository
```bash
git clone https://gitlab.fi.muni.cz/xmackov1/pv179_bookhub
```
```bash
cd pv179_bookhub
```

Secret token for authorization:
```bash
supersecrettoken123
```
