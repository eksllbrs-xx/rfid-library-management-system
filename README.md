# rfid-library-management-system
RFID-based Library Management System for managing library users, books, and transactions using C# and MySQL.


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
                    RFID / Login
                         │
              ┌──────────┴──────────┐
              ↓                     ↓
       ADMIN / STAFF            STUDENT / FACULTY
              │                     │
              ↓                     ↓
        ┌───────────┐        ┌──────────────┐
        │   Books   │        │ Book Search  │
        └─────┬─────┘        └──────────────┘
              │
       ┌──────┴──────┐
       ↓             ↓
   Issue Book    Return Book
       │             │
       └──────┬──────┘
              ↓
          ┌─────────┐
          │ Records │
          └────┬────┘
               │
     ┌─────────┼──────────┐
     ↓         ↓          ↓
 Attendance  Borrowed   Returned
             Books       Books
               │
               ↓
          Inventory
               │
               ↓
        Book Requests
               │
               ↓
       Print Preview / PDF
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

## 📸 System Screenshots

### 🔐 Admin / Library Staff Login

The system provides a login interface for authorized administrators and library staff.

<img width="1175" height="942" alt="image" src="https://github.com/user-attachments/assets/5834ea8a-c054-4f23-893d-8633d316abf8" />


---

### 📡 RFID Student / Faculty Login

Students and faculty members can access the system using RFID-based identification.

The RFID interface displays the library management system, current date, and time while waiting for an RFID ID scan.

<img width="1530" height="966" alt="image" src="https://github.com/user-attachments/assets/73cc6bf6-f52d-4f6c-bcc3-fa3c8a8e4736" />


---

### 🏠 Admin Menu

The administrator interface provides access to the main library management functions.

Available modules include:

- Book Management
- Issue Book
- Return Book
- Records
- Logout

<img width="1735" height="974" alt="image" src="https://github.com/user-attachments/assets/5b74454e-39af-4186-a039-29183b76d87e" />


---

### 📚 Book Management

The Book Management module allows library staff to add, update, search, and delete book records.

Book information includes:

- Book Title
- Author(s)
- Edition
- Copies
- Call Number
- Accession Number
- ISBN
- Nature of Content
- Location
- Category
- Shelf Number
- Date of Registration
- Price
- Abstract

<img width="1706" height="971" alt="image" src="https://github.com/user-attachments/assets/c09edd64-279d-4587-800b-7524d2165748" />


---

### 📖 Issue Book

The Issue Book module records book borrowing transactions.

The system captures borrower information and book information before recording the transaction.

Borrower information includes:

- Full Name
- Department
- Course
- ID Number

Book information includes:

- Accession Number
- Call Number
- Book Title
- Author
- Copies

The system also records the issue date and due date.

<img width="1644" height="964" alt="image" src="https://github.com/user-attachments/assets/73f34919-8f70-4281-8a8c-1a378e650c65" />


---

### 🔄 Return Book

The Return Book module allows library staff to process returned books.

The system displays borrower information and borrowed book information before processing the return.

It also supports:

- Return Date
- Days Overdue
- Fine Calculation
- Remarks
- Return Transaction
- Delete Transaction

<img width="1716" height="963" alt="image" src="https://github.com/user-attachments/assets/65d7f366-fa28-42b0-bf3c-9d2d702dcfe7" />


---

### 📋 Records Section

The Records Section provides centralized access to different library records.

Available record categories include:

- Attendance
- Borrowed Books
- Returned Books
- Inventory
- Book Request

The module also provides:

- Load Data
- Print Preview

<img width="1680" height="957" alt="image" src="https://github.com/user-attachments/assets/24cf0c69-c76c-4c69-9feb-b06ee7835b60" />


---

### 👤 Student / Faculty User Menu

The user interface provides library users with access to:

- Search
- Borrowed Books
- Returned Books
- Book Request
- Logout

<img width="1728" height="962" alt="image" src="https://github.com/user-attachments/assets/ac290108-e873-4377-ae28-87f40323edcf" />


---

### 🔎 Book Search

The Book Search module allows students and faculty to search the library collection.

Search results display available book titles.

<img width="1704" height="966" alt="image" src="https://github.com/user-attachments/assets/e1ee44a7-eea4-4311-a393-1d5c17e2537c" />


---

### 📚 Borrowed Books

Users can view their currently borrowed books.

The system displays:

- Accession Number
- Call Number
- Book Title
- Student Name
- Issued Date
- Due Date

<img width="1705" height="972" alt="image" src="https://github.com/user-attachments/assets/a03a9ff1-59c3-4670-bb80-b2b1c26c949a" />


---

### 🔄 Returned Books

Users can view their returned book transactions.

The system displays:

- Accession Number
- Call Number
- Book Title
- Borrower's Name
- Issued Date
- Due Date
- Returned Date

<img width="1633" height="962" alt="image" src="https://github.com/user-attachments/assets/fa7af60c-8067-4a1a-8f47-3a3f909d873f" />


---

### 📖 Book Requisition

The Book Requisition module allows users to request books or other library materials.

Request information includes:

- Book Title
- Author(s)
- Copyright
- Quantity
- Text for the Subject / Course Code
- Type of Material
- Available At
- Requested By
- Departmen

<img width="1559" height="955" alt="image" src="https://github.com/user-attachments/assets/1b4191b5-ca85-4a52-b419-2c0aff91636e" />



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
