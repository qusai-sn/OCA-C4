CREATE TABLE teachers (  
    teacher_id INT PRIMARY KEY, 
    teacher_name VARCHAR(30)
);

CREATE TABLE teacher_details (  
    id INT UNIQUE, 
    email VARCHAR(30), 
     phone VARCHAR(15),
    teacher_address VARCHAR(50),   
    FOREIGN KEY (id) REFERENCES teachers(teacher_id)
);


CREATE TABLE courses ( 
    course_id INT PRIMARY KEY,
    course_name VARCHAR(30),
    number_of_students INT,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES teachers(teacher_id)
);

CREATE TABLE students (
    student_id INT PRIMARY KEY, 
    student_name VARCHAR(50)
);

CREATE TABLE students_courses (
    student_id INT, 
    course_id INT, 
    FOREIGN KEY (student_id) REFERENCES students(student_id), 
    FOREIGN KEY (course_id) REFERENCES courses(course_id),
    PRIMARY KEY (student_id, course_id)   
);

CREATE TABLE students_teachers (
    student_id INT, 
    teacher_id INT, 
    FOREIGN KEY (student_id) REFERENCES students(student_id), 
    FOREIGN KEY (teacher_id) REFERENCES teachers(teacher_id),
    PRIMARY KEY (student_id, teacher_id)   
);

 INSERT INTO teachers (teacher_id, teacher_name) VALUES 
(1, 'Ali Ahmed'),
(2, 'Mohammed Saleh'),
(3, 'Khaled Abdullah'),
(4, 'Malik Hussein'),
(5, 'Mustafa Mahmoud');

 INSERT INTO teacher_details (id, email, phone, teacher_address) VALUES 
(1, 'ali.ahmed@example.com', 1234567890, '123 '),
(2, 'mohammed.saleh@example.com', 9876543210, '456  Street'),
(3, 'khaled.abdullah@example.com', 1122334455, '789  Street'),
(4, 'malik.hussein@example.com', 6677889900, '101  Street'),
(5, 'mustafa.mahmoud@example.com', 3344556677, '202  Street');

 INSERT INTO courses (course_id, course_name, number_of_students, teacher_id) VALUES 
(1, 'Mathematics', 30, 1),
(2, 'Physics', 25, 2),
(3, 'Chemistry', 20, 3),
(4, 'Biology', 15, 4),
(5, 'Computer Science', 35, 5);

 INSERT INTO students (student_id, student_name) VALUES 
(1, 'Ali Hassan'),
(2, 'Mohammed Ali'),
(3, 'Khaled Youssef'),
(4, 'Malik Ibrahim'),
(5, 'Mustafa Omar');

 INSERT INTO students_courses (student_id, course_id) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 1);

 INSERT INTO students_teachers (student_id, teacher_id) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 1);


-- task 1 : 

 CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    BirthYear INT
);

 CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(100),
    AuthorID INT,
    PublishedYear INT,
    CopiesAvailable INT,
    BookCategory VARCHAR(50),
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

 INSERT INTO Authors (AuthorID, FirstName, LastName, BirthYear) VALUES 
(1, 'George', 'Orwell', 1903),
(2, 'Jane', 'Austen', 1775),
(3, 'Mark', 'Twain', 1835),
(4, 'J.K.', 'Rowling', 1965),
(5, 'F. Scott', 'Fitzgerald', 1896);

 INSERT INTO Books (BookID, Title, AuthorID, PublishedYear, CopiesAvailable, BookCategory) VALUES 
(1, '1984', 1, 1949, 12, 'Dystopian'),
(2, 'Pride and Prejudice', 2, 1813, 5, 'Romance'),
(3, 'Adventures of Huckleberry Finn', 3, 1884, 8, 'Adventure'),
(4, 'Harry Potter and the Sorcerers Stone', 4, 1997, 15, 'Fantasy'),
(5, 'The Great Gatsby', 5, 1925, 7, 'Classic');


--1 : 

SELECT * FROM Books;
SELECT * FROM Authors;



--2 : 

 SELECT 
    Title, 
    CopiesAvailable 
FROM 
    Books 
ORDER BY 
    CopiesAvailable DESC;

 SELECT 
    Title, 
    CopiesAvailable 
FROM 
    Books 
ORDER BY 
    CopiesAvailable ASC ;


--3 : 
SELECT 
    AVG(PublishedYear) AS AveragePublicationYear 
FROM 
    Books;

--4 : 

SELECT 
    COUNT(*) AS TotalBooksCount 
FROM 
    Books;

--5 : 

TRUNCATE TABLE Books;


--6: 

DROP TABLE Authors;
