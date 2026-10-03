# rfid-library-management-system
RFID-based Library Management System for managing library users, books, and transactions using C# and MySQL.


# RFID-Based Library Management System

A desktop-based **RFID Library Management System** developed to support library operations such as user identification, book management, book issuance and returns, attendance monitoring, inventory management, book requests, and library record management.

The system uses **RFID technology** to assist in identifying registered users and maintaining library transactions and records in a centralized database.

---

##  Project Overview

The RFID-Based Library Management System is designed to improve the efficiency of library operations by reducing manual record handling and providing a centralized system for managing library activities.

The system provides modules for:

- User identification
- Book management
- Book issuance
- Book returns
- Borrowed book monitoring
- Returned book monitoring
- Attendance records
- Inventory records
- Book requests
- Search
- Report and print preview

The system also provides a reporting function that allows library records to be prepared for printing and exported as **PDF documents**.

---

##  Objectives

The system aims to:

- Automate common library transactions
- Use RFID technology for user identification
- Maintain organized library records
- Manage books and inventory efficiently
- Record borrowing and returning transactions
- Monitor library user attendance
- Manage book requests
- Provide searchable library records
- Generate printable reports
- Reduce repetitive manual data entry

---

# Key Features

##  RFID-Based User Identification

The system uses RFID technology to identify registered library users.

A registered RFID card or tag can be scanned to identify the user before performing library transactions.

### RFID Workflow

```text
RFID Card / Tag
       ↓
RFID Reader
       ↓
RFID Identification
       ↓
Registered User
       ↓
Library Transaction
```


###  Book Management

The system provides functionality for managing library book information.

Book records may include:

- Accession Number
- Call Number
- Book Title
- Author
- Category
- Availability
- Other bibliographic information

---

###  Issue Book

The **Issue Book** module is used to record books issued to library users.

The system records information such as:

- Student/User ID
- Accession Number
- Call Number
- Book Title
- Borrower's Name
- Issued Date
- Due Date

#### Issuing Workflow

```text
Identify User
      ↓
Select / Identify Book
      ↓
Check Book Availability
      ↓
Record Transaction
      ↓
Set Due Date
      ↓
Update Library Records
```

---

###  Return Book

The **Return Book** module records books returned by library users.

Returned-book records include:

- Accession Number
- Call Number
- Book Title
- Borrower's Name
- Issued Date
- Due Date
- Returned Date

#### Return Workflow

```text
Identify User
      ↓
Identify Borrowed Book
      ↓
Verify Transaction
      ↓
Record Returned Date
      ↓
Update Book Status
      ↓
Update Library Records
```

---

## Records Section

The system provides a centralized **Records Section** for viewing different categories of library information.

The Records section includes:

###  Attendance

Records library user attendance and related activity.

###  Borrowed Books

Displays books currently recorded as borrowed.

Information may include:

- Accession Number
- Call Number
- Book Title
- Student Name
- Issued Date
- Due Date

###  Returned Books

Displays completed book return transactions.

Information may include:

- Accession Number
- Call Number
- Book Title
- Borrower's Name
- Issued Date
- Due Date
- Returned Date

###  Inventory

Provides records related to the library's book inventory.

###  Book Request

Manages requests for books that users would like the library to acquire or provide.

---

## Search

The system includes a search function to help locate relevant library information.

Search functionality can be used to retrieve book, user, or transaction records more efficiently.

---

##  Reports and Print Preview

The Records section provides **Load Data** and **Print Preview** functionality for library records.

### Reporting Workflow

```text
Select Record Category
        ↓
Load Data
        ↓
Display Records
        ↓
Print Preview
        ↓
Print / Export Report
```

### Supported Report Format

**PDF**

The portfolio implementation focuses on PDF-based report generation and printable records.

> Excel export is not currently included in the portfolio implementation.

---

##  User Information

The system displays the currently identified user or student.

Example:

```text
STUDENT ID: 02311244
```

User identification allows library transactions to be associated with the appropriate library user.

---

##  Library Record Categories

The system manages several categories of library records:

```text
┌──────────────────────────────┐
│       LIBRARY RECORDS        │
├──────────────────────────────┤
│ 📅 Attendance                │
│ 📚 Borrowed Books            │
│ 🔄 Returned Books            │
│ 📦 Inventory                 │
│ 📖 Book Requests             │
└──────────────────────────────┘
```

---
##  Technology Stack

| Technology | Purpose |
|---|---|
| **C#** | Application development |
| **.NET / Windows Forms** | Desktop application |
| **MySQL** | Database management |
| **SQL** | Database operations |
| **RFID** | User identification |
| **Visual Studio** | Development environment |
| **Git** | Version control |
| **GitHub** | Source code management |
| **PDF Reporting** | Report generation and document export |

---

##  System Workflow

The overall system workflow can be represented as:

```text
                    ┌─────────────────┐
                    │   RFID Reader   │
                    └────────┬────────┘
                             │
                             ↓
                    ┌─────────────────┐
                    │ User Identification │
                    └────────┬────────┘
                             │
                             ↓
              ┌──────────────────────────────┐
              │   Library Management System  │
              └──────────────┬───────────────┘
                             │
        ┌────────────────────┼────────────────────┐
        ↓                    ↓                    ↓
   Book Management      Issue / Return       Book Request
        │                    │                    │
        └────────────────────┼────────────────────┘
                             ↓
                   ┌──────────────────┐
                   │     Database     │
                   └────────┬─────────┘
                            ↓
                   ┌──────────────────┐
                   │     Records      │
                   ├──────────────────┤
                   │ Attendance       │
                   │ Borrowed Books   │
                   │ Returned Books   │
                   │ Inventory        │
                   │ Book Requests    │
                   └────────┬─────────┘
                            ↓
                   ┌──────────────────┐
                   │ Print Preview /  │
                   │ PDF Report       │
                   └──────────────────┘
```

---

##  Data Management

The system manages information related to:

### Users

- Student/User ID
- RFID identifier
- User information

### Books

- Accession Number
- Call Number
- Book Title
- Bibliographic information
- Availability

### Transactions

- Borrowing records
- Returning records
- Issued Date
- Due Date
- Returned Date

### Library Records

- Attendance
- Borrowed Books
- Returned Books
- Inventory
- Book Requests

---

##  Screenshots

### Borrowed Books

The Borrowed Books module displays recorded borrowing transactions.

<img width="1594" height="955" alt="image" src="https://github.com/user-attachments/assets/ed720853-72fe-4e32-8712-5b15998ca466" />

### Returned Books

The Returned Books module displays completed book return transactions.

<img width="1633" height="980" alt="image" src="https://github.com/user-attachments/assets/9512fabf-2e8e-4e29-b7f7-1f41f3ef0040" />

### Records Section

The Records Section provides access to:

- Attendance
- Borrowed Books
- Returned Books
- Inventory
- Book Requests

<img width="1612" height="954" alt="image" src="https://github.com/user-attachments/assets/d7773cf1-bf94-4b33-bd12-1693f2d66abb" />


---

##  Software Engineering Concepts

This project demonstrates practical application of:

- Object-Oriented Programming
- Database-driven application development
- CRUD operations
- SQL
- Relational database design
- RFID integration
- User identification
- Transaction processing
- Data validation
- Record management
- Search functionality
- Report generation
- Print preview
- Error handling
- Software documentation
- Version control using Git

---

##  Data Privacy

This repository should contain **demonstration data only**.

The following should not be uploaded to a public GitHub repository:

- Real student information
- Real student IDs
- Real RFID identifiers
- Real library records
- Passwords
- Database credentials
- Confidential institutional documents

Screenshots should also be anonymized when necessary.

---

##  Current Limitations

The portfolio version may differ from the original institutional implementation.

Current limitations may include:

- Basic user interface
- Limited authentication functionality
- Limited reporting customization
- PDF reporting instead of Excel export
- RFID functionality dependent on compatible hardware
- Some administrative functions requiring further development

---

##  Future Improvements

### Authentication

- Secure password hashing

###  RFID

- RFID registration
- RFID card management
- Improved RFID transaction handling

###  Library Management

- Book reservation
- Book availability notifications

###  Reporting

- PDF reports
- Excel export
- Borrowing reports
- Returning reports
- Statistical dashboards

###  System Modernization

- ASP.NET Core Web API
- REST API
- Web-based interface
- Entity Framework Core
- Mobile-friendly interface
- Cloud database integration

###  Software Quality

- Unit testing
- Integration testing
- Automated testing
- Logging
- Dependency injection
- Improved application architecture

---

##  Project Background

This project originated from an academic/research-oriented **RFID-based Library Management System** project.

The GitHub repository is being developed as a **software development portfolio project** to demonstrate programming, database, RFID integration, transaction processing, reporting, and software engineering skills.

The portfolio version is a recreated implementation and does not contain the original institutional source code or confidential institutional data.

---

##  Developer

### Erika G. Llabres

**Computer Engineer | Master in Information Technology – Software Development**

Currently transitioning into professional **Software Development / Software Engineering**.

### Technical Interests

- C# / .NET
- Software Development
- Backend Development
- Database Development
- REST APIs
- Application Development
- Python
- SQL
- Software Engineering

---

## 📫 Connect With Me

- **LinkedIn:** https://www.linkedin.com/in/erkallbrs/
- **Email:** eksllabres@gmail.com
