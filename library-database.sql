-- ============================================================
-- RFID LIBRARY MANAGEMENT SYSTEM
-- Database Schema
-- Portfolio Project
-- ============================================================

CREATE DATABASE IF NOT EXISTS rfid_library;

USE rfid_library;

-- ============================================================
-- 1. ADMIN / LIBRARY STAFF
-- ============================================================

CREATE TABLE IF NOT EXISTS admin_users (
    admin_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    full_name VARCHAR(150) NOT NULL,
    role ENUM('ADMIN', 'LIBRARIAN', 'STAFF') NOT NULL DEFAULT 'STAFF',
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- ============================================================
-- 2. LIBRARY USERS
-- Students and Faculty
-- ============================================================

CREATE TABLE IF NOT EXISTS library_users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    
    student_faculty_id VARCHAR(50) NOT NULL UNIQUE,
    rfid_uid VARCHAR(100) UNIQUE,
    
    first_name VARCHAR(75) NOT NULL,
    middle_name VARCHAR(75),
    last_name VARCHAR(75) NOT NULL,
    
    user_type ENUM('STUDENT', 'FACULTY') NOT NULL,
    
    department VARCHAR(150),
    course VARCHAR(150),
    
    email VARCHAR(150),
    contact_number VARCHAR(30),
    
    status ENUM('ACTIVE', 'INACTIVE', 'SUSPENDED')
        NOT NULL DEFAULT 'ACTIVE',
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
        ON UPDATE CURRENT_TIMESTAMP
);

-- ============================================================
-- 3. BOOKS
-- ============================================================

CREATE TABLE IF NOT EXISTS books (
    book_id INT AUTO_INCREMENT PRIMARY KEY,
    
    accession_number VARCHAR(50) NOT NULL UNIQUE,
    call_number VARCHAR(100),
    
    isbn VARCHAR(30),
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255),
    
    edition VARCHAR(100),
    publication_year YEAR,
    
    category VARCHAR(100),
    nature_of_content VARCHAR(150),
    
    location VARCHAR(150),
    shelf_number VARCHAR(50),
    
    copies INT NOT NULL DEFAULT 1,
    available_copies INT NOT NULL DEFAULT 1,
    
    price DECIMAL(10,2),
    
    abstract TEXT,
    
    date_registered DATE,
    
    status ENUM('AVAILABLE', 'BORROWED', 'LOST', 'DAMAGED')
        NOT NULL DEFAULT 'AVAILABLE',
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
        ON UPDATE CURRENT_TIMESTAMP
);

-- ============================================================
-- 4. BORROW TRANSACTIONS
-- ============================================================

CREATE TABLE IF NOT EXISTS borrow_transactions (
    borrow_id INT AUTO_INCREMENT PRIMARY KEY,
    
    user_id INT NOT NULL,
    book_id INT NOT NULL,
    
    issued_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    due_date DATE NOT NULL,
    
    status ENUM('BORROWED', 'RETURNED', 'OVERDUE')
        NOT NULL DEFAULT 'BORROWED',
    
    issued_by INT,
    
    remarks VARCHAR(255),
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    CONSTRAINT fk_borrow_user
        FOREIGN KEY (user_id)
        REFERENCES library_users(user_id),
        
    CONSTRAINT fk_borrow_book
        FOREIGN KEY (book_id)
        REFERENCES books(book_id),
        
    CONSTRAINT fk_borrow_admin
        FOREIGN KEY (issued_by)
        REFERENCES admin_users(admin_id)
);

-- ============================================================
-- 5. RETURN TRANSACTIONS
-- ============================================================

CREATE TABLE IF NOT EXISTS return_transactions (
    return_id INT AUTO_INCREMENT PRIMARY KEY,
    
    borrow_id INT NOT NULL,
    
    returned_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    
    days_overdue INT NOT NULL DEFAULT 0,
    
    fine_amount DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    
    remarks VARCHAR(255),
    
    processed_by INT,
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    CONSTRAINT fk_return_borrow
        FOREIGN KEY (borrow_id)
        REFERENCES borrow_transactions(borrow_id),
        
    CONSTRAINT fk_return_admin
        FOREIGN KEY (processed_by)
        REFERENCES admin_users(admin_id)
);

-- ============================================================
-- 6. ATTENDANCE
-- ============================================================

CREATE TABLE IF NOT EXISTS attendance (
    attendance_id INT AUTO_INCREMENT PRIMARY KEY,
    
    user_id INT NOT NULL,
    
    attendance_date DATE NOT NULL,
    time_in DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    time_out DATETIME,
    
    purpose VARCHAR(150),
    
    CONSTRAINT fk_attendance_user
        FOREIGN KEY (user_id)
        REFERENCES library_users(user_id)
);

-- ============================================================
-- 7. BOOK REQUEST / REQUISITION
-- ============================================================

CREATE TABLE IF NOT EXISTS book_requests (
    request_id INT AUTO_INCREMENT PRIMARY KEY,
    
    requested_by INT NOT NULL,
    
    book_title VARCHAR(255) NOT NULL,
    authors VARCHAR(255),
    
    copyright_year YEAR,
    
    quantity INT NOT NULL DEFAULT 1,
    
    subject_course_code VARCHAR(150),
    
    material_type VARCHAR(100),
    
    available_at VARCHAR(255),
    
    reason TEXT,
    
    request_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    
    status ENUM(
        'PENDING',
        'APPROVED',
        'PURCHASED',
        'REJECTED'
    ) NOT NULL DEFAULT 'PENDING',
    
    processed_by INT,
    
    processed_date DATETIME,
    
    remarks VARCHAR(255),
    
    CONSTRAINT fk_request_user
        FOREIGN KEY (requested_by)
        REFERENCES library_users(user_id),
        
    CONSTRAINT fk_request_admin
        FOREIGN KEY (processed_by)
        REFERENCES admin_users(admin_id)
);

-- ============================================================
-- 8. INVENTORY
-- ============================================================

CREATE TABLE IF NOT EXISTS inventory (
    inventory_id INT AUTO_INCREMENT PRIMARY KEY,
    
    book_id INT NOT NULL,
    
    inventory_date DATE NOT NULL,
    
    quantity_checked INT NOT NULL DEFAULT 0,
    
    quantity_missing INT NOT NULL DEFAULT 0,
    
    quantity_damaged INT NOT NULL DEFAULT 0,
    
    remarks VARCHAR(255),
    
    checked_by INT,
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    CONSTRAINT fk_inventory_book
        FOREIGN KEY (book_id)
        REFERENCES books(book_id),
        
    CONSTRAINT fk_inventory_admin
        FOREIGN KEY (checked_by)
        REFERENCES admin_users(admin_id)
);

-- ============================================================
-- 9. INDEXES
-- Improve search performance
-- ============================================================

CREATE INDEX idx_rfid_uid
ON library_users(rfid_uid);

CREATE INDEX idx_user_id
ON library_users(student_faculty_id);

CREATE INDEX idx_book_title
ON books(title);

CREATE INDEX idx_accession_number
ON books(accession_number);

CREATE INDEX idx_borrow_status
ON borrow_transactions(status);

CREATE INDEX idx_borrow_due_date
ON borrow_transactions(due_date);

CREATE INDEX idx_attendance_date
ON attendance(attendance_date);

CREATE INDEX idx_request_status
ON book_requests(status);

-- ============================================================
-- 10. DEMONSTRATION ADMIN ACCOUNT
-- ============================================================
-- NOTE:
-- This is a placeholder password hash for development only.
-- The actual application should use BCrypt/Argon2 or another
-- secure password hashing mechanism.

INSERT INTO admin_users
(
    username,
    password_hash,
    full_name,
    role
)
VALUES
(
    'admin',
    'DEMO_PASSWORD_HASH',
    'System Administrator',
    'ADMIN'
);

-- ============================================================
-- 11. DEMONSTRATION USERS
-- ============================================================

INSERT INTO library_users
(
    student_faculty_id,
    rfid_uid,
    first_name,
    middle_name,
    last_name,
    user_type,
    department,
    course,
    email
)
VALUES
(
    'DEMO-001',
    'RFID-001',
    'Juan',
    'D.',
    'Student',
    'STUDENT',
    'Computer Engineering',
    'Bachelor of Science in Computer Engineering',
    'juan.demo@example.com'
);

INSERT INTO library_users
(
    student_faculty_id,
    rfid_uid,
    first_name,
    middle_name,
    last_name,
    user_type,
    department,
    course,
    email
)
VALUES
(
    'DEMO-002',
    'RFID-002',
    'Maria',
    'A.',
    'Faculty',
    'FACULTY',
    'College of Engineering',
    NULL,
    'maria.demo@example.com'
);

-- ============================================================
-- 12. DEMONSTRATION BOOKS
-- ============================================================

INSERT INTO books
(
    accession_number,
    call_number,
    isbn,
    title,
    author,
    edition,
    publication_year,
    category,
    nature_of_content,
    location,
    shelf_number,
    copies,
    available_copies,
    price,
    abstract,
    date_registered
)
VALUES
(
    'ACC-0001',
    'QA76.73.C154',
    '978000000001',
    'Introduction to C# Programming',
    'Demo Author',
    '1st Edition',
    2025,
    'Programming',
    'Computer Science',
    'Main Library',
    'SHELF-A01',
    5,
    5,
    1500.00,
    'An introductory programming book covering fundamental C# concepts.',
    CURRENT_DATE
);

INSERT INTO books
(
    accession_number,
    call_number,
    isbn,
    title,
    author,
    edition,
    publication_year,
    category,
    nature_of_content,
    location,
    shelf_number,
    copies,
    available_copies,
    price,
    abstract,
    date_registered
)
VALUES
(
    'ACC-0002',
    'QA76.9.D3',
    '978000000002',
    'Database Management Systems',
    'Demo Author',
    '2nd Edition',
    2025,
    'Database',
    'Information Technology',
    'Main Library',
    'SHELF-A02',
    3,
    3,
    1800.00,
    'Fundamentals of relational database design and SQL.',
    CURRENT_DATE
);

-- ============================================================
-- END OF DATABASE SCHEMA
-- ============================================================
