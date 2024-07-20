 CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Address VARCHAR(255)
);

 CREATE TABLE family_info (
    ID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    FatherName VARCHAR(100) NOT NULL,
    FatherContact VARCHAR(100),
    MotherName NVARCHAR(100),
    MotherContact NVARCHAR(100),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);

 CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL,
    Course_Description NVARCHAR(255)
);

 CREATE TABLE Classes (
    ClassID INT PRIMARY KEY IDENTITY(1,1),
    ClassName NVARCHAR(50) NOT NULL,
    RoomNumber NVARCHAR(50),
    CourseID INT,  
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

 CREATE TABLE Assignments (
    AssignmentID INT PRIMARY KEY IDENTITY(1,1),
    AssignmentName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    DueDate DATE,
    Status NVARCHAR(50),  
    ClassID INT,
    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)
);


 CREATE TABLE Assignment_Student (
    AssignmentID INT,
    StudentID INT,
    FOREIGN KEY (AssignmentID) REFERENCES Assignments(AssignmentID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    PRIMARY KEY (AssignmentID, StudentID)
);

 CREATE TABLE Students_Classes (
    ClassID INT,
    StudentID INT,
    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    PRIMARY KEY (ClassID, StudentID)
);

 CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    ClassID INT,
    AttendanceDate DATE NOT NULL,
    AbsenceType NVARCHAR(50),  
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)
);
CREATE TABLE Students_Courses (
    StudentID INT,
    CourseID INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    PRIMARY KEY (StudentID, CourseID)
);
 INSERT INTO Students (Name, DateOfBirth, Address)
VALUES 
('Qusai Omar', '2000-05-15', '123 Maple St'),
('Mohammed Fawareh', '1998-08-22', '456 Oak St'),
('Mustafa Almomani', '1996-12-30', '789 Pine St'),
('Malek Ibdah', '1994-03-12', '101 Elm St');

 INSERT INTO family_info (StudentID, FatherName, FatherContact, MotherName, MotherContact)
VALUES 
(1, 'Omar Omar', '555-1111', 'Lina Omar', '555-2222'),
(2, 'Ahmed Fawareh', '555-3333', 'Mariam Fawareh', '555-4444'),
(3, 'Ibrahim Almomani', '555-5555', 'Sara Almomani', '555-6666'),
(4, 'Hassan Ibdah', '555-7777', 'Nadia Ibdah', '555-8888');

 INSERT INTO Courses (CourseName, Course_Description)
VALUES 
('Mathematics', 'A introduction to basic mathematics concepts.'),
('Science', 'A comprehensive study of physical and biological sciences.'),
('History', 'Exploring historical events and contexts.'),
('Computer Science', 'Introduction to programming and computer science principles.');

 INSERT INTO Classes (ClassName, RoomNumber, CourseID)
VALUES 
('Math 101', 'Room 101', 1),
('Science 101', 'Room 102', 2),
('History 101', 'Room 103', 3),
('CS 101', 'Room 104', 4);

 INSERT INTO Assignments (AssignmentName, Description, DueDate, Status, ClassID)
VALUES 
('Math Homework 1', 'Complete exercises 1-10', '2024-07-30', 'pass', 1),
('Science Project', 'Group project on ecosystems', '2024-08-15', 'failed', 2),
('History Essay', 'Write an essay on World War II', '2024-07-25', 'pass', 3),
('CS Assignment 1', 'Write a basic program in Python', '2024-08-01', 'pass', 4);

 INSERT INTO Assignment_Student (AssignmentID, StudentID)
VALUES 
(1, 1),
(1, 2),
(3, 1),
(3, 3),
(4, 2);

 INSERT INTO Students_Classes (ClassID, StudentID)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(4, 2);

 INSERT INTO Attendance (StudentID, ClassID, AttendanceDate, AbsenceType)
VALUES 
(1, 1, '2024-07-28', 'leaving'),
(2, 2, '2024-08-12', 'absence'),
(3, 3, '2024-07-24', 'late'),
(4, 4, '2024-08-01', 'absence'),
(1, 1, '2024-07-30', 'absence');

 INSERT INTO Students_Courses (StudentID, CourseID)
VALUES 
(1, 1),
(1, 4),
(2, 2),
(3, 3),
(4, 4);

-- questions : 

--#1:
SELECT DISTINCT s.Name
FROM Students s
JOIN Attendance a ON s.StudentID = a.StudentID
WHERE a.AttendanceDate = '2024-07-30';

--#2:
SELECT *
FROM Courses
WHERE CourseName = 'Mathematics';

--#3:
ALTER TABLE Students
ADD Email VARCHAR(100);

--#4: 

INSERT INTO Students (Name, DateOfBirth, Address, Email)
VALUES ('qusai omar ', '2000-11-29', '202 alramtha', 'qusayomar21@gmail.com');

--#5: 

SELECT s.Name
FROM Students s
JOIN family_info f ON s.StudentID = f.StudentID;


--#6 : 

SELECT s.Name
FROM Students s
JOIN Students_Courses sc ON s.StudentID = sc.StudentID
JOIN Courses c ON sc.CourseID = c.CourseID
WHERE c.CourseName = 'Mathematics';

--#7 : 

SELECT s.Name
FROM Students s
JOIN Assignment_Student asg_s ON s.StudentID = asg_s.StudentID
JOIN Assignments a ON asg_s.AssignmentID = a.AssignmentID
WHERE a.AssignmentName = 'CS Assignment 1' AND a.Status = 'pass';


--#8 : 

SELECT  s.Name
FROM Students s
JOIN Attendance a ON s.StudentID = a.StudentID
WHERE a.AbsenceType = 'leaving'
  AND a.AttendanceDate BETWEEN '2024-01-01' AND '2024-01-05';


--#9 : 
SELECT s.Name
FROM Students s
JOIN Attendance a ON s.StudentID = a.StudentID
WHERE a.AbsenceType = 'absence'
GROUP BY s.StudentID, s.Name
HAVING COUNT(*) > 4;
