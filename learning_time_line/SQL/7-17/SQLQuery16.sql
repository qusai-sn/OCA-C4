
 CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    BirthYear INT
);

 CREATE TABLE Sections (
    SectionID INT PRIMARY KEY IDENTITY(1,1),
    SectionName VARCHAR(30) NOT NULL
);

 CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100)
);

 CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(100),
    AuthorID INT,
    PublishedYear INT,
    CopiesAvailable INT,
    CategoryID INT,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

 CREATE TABLE BookSections (
    BookID INT,
    SectionID INT,
    PRIMARY KEY (BookID, SectionID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (SectionID) REFERENCES Sections(SectionID)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    BirthYear INT,
    Position VARCHAR(50),
	section_id int ,
	foreign key (section_id) references sections(SectionID)
);

 
 CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username VARCHAR(50),
    Name VARCHAR(50),
    BirthDate DATE,
    Email VARCHAR(100)
);

 CREATE TABLE BorrowingRecords (
    RecordID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    BookID INT,
    BorrowDate DATE,
    ReturnDate DATE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

 INSERT INTO Authors (AuthorID, FirstName, LastName, BirthYear)
VALUES
    (1, 'George', 'Orwell', 1903),
    (2, 'Jane', 'Austen', 1775),
    (3, 'Harper', 'Lee', 1926),
    (4, 'J.K.', 'Rowling', 1965),
    (5, 'Ernest', 'Hemingway', 1899);

 INSERT INTO Sections (SectionName)
VALUES
    ('Fiction'),
    ('Non-Fiction'),
    ('Science Fiction'),
    ('History'),
    ('Biography');

 INSERT INTO Categories (CategoryID, CategoryName)
VALUES
    (1, 'Classic Literature'),
    (2, 'Science Fiction'),
    (3, 'History'),
    (4, 'Biography'),
    (5, 'Fantasy');

 INSERT INTO Books (BookID, Title, AuthorID, PublishedYear, CopiesAvailable, CategoryID)
VALUES
    (1, '1984', 1, 1949, 10, 1),
    (2, 'Pride and Prejudice', 2, 1813, 8, 1),
    (3, 'To Kill a Mockingbird', 3, 1960, 12, 1),
    (4, 'Harry Potter and the Philosopher''s Stone', 4, 1997, 15, 5),
    (5, 'The Old Man and the Sea', 5, 1952, 6, 2);

 INSERT INTO BookSections (BookID, SectionID)
VALUES
    (1, 1),
    (2, 1),
    (3, 1),
    (4, 5),
    (5, 1);

 INSERT INTO Employees (EmployeeID, FirstName, LastName, BirthYear, Position, section_id)
VALUES
    (1, 'John', 'Doe', 1985, 'Librarian', 1),
    (2, 'Jane', 'Smith', 1990, 'Assistant Librarian', 2),
    (3, 'Michael', 'Johnson', 1980, 'Manager', 3),
    (4, 'Emily', 'Brown', 1988, 'Clerk', 4),
    (5, 'David', 'Williams', 1995, 'Assistant', 5);

 INSERT INTO Users (UserID, Username, Name, BirthDate, Email)
VALUES
    (1, 'user1', 'Alice Johnson', '1990-05-15', 'alice@example.com'),
    (2, 'user2', 'Bob Smith', '1988-09-20', 'bob@example.com'),
    (3, 'user3', 'Emma Davis', '1995-03-10', 'emma@example.com'),
    (4, 'user4', 'James Wilson', '1985-11-25', 'james@example.com'),
    (5, 'user5', 'Sophia Brown', '1992-07-03', 'sophia@example.com');

 INSERT INTO BorrowingRecords (UserID, BookID, BorrowDate, ReturnDate)
VALUES
    (1, 1, '2023-01-05', '2023-01-15'),
    (2, 3, '2023-02-10', '2023-02-25'),
    (3, 4, '2023-03-15', NULL),
    (4, 2, '2023-04-20', '2023-05-05'),
    (5, 5, '2023-06-01', '2023-06-15');

SELECT b.Title, a.FirstName, a.LastName
FROM Books b
INNER JOIN Authors a ON b.AuthorID = a.AuthorID;

SELECT b.Title, a.FirstName, a.LastName
FROM Books b
LEFT JOIN Authors a ON b.AuthorID = a.AuthorID;

SELECT b.Title, a.FirstName, a.LastName
FROM Books b
RIGHT JOIN Authors a ON b.AuthorID = a.AuthorID;

 SELECT b.Title, a.FirstName, a.LastName
FROM Books b
FULL OUTER JOIN Authors a ON b.AuthorID = a.AuthorID;
