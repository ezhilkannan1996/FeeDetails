//Create database Institute

//use Institute
//go 


//CREATE TABLE Courses (
//  course_id INT IDENTITY(1,1) PRIMARY KEY,
//  course_name VARCHAR(50) not null,
//  Duration int not null,
// fees int
//);

//CREATE TABLE Faculty (
//  FacultyId INT IDENTITY(1,1) PRIMARY KEY,
//  Faculty_Name VARCHAR(50) not null ,
//  City VARCHAR(50) not null ,
//  Phone Varchar(10) not null ,
// Specialization_in INT FOREIGN KEY  REFERENCES Courses(course_id)
  
//);


//CREATE TABLE StudentRegistration (
// Student_id INT IDENTITY(1,1) PRIMARY KEY,
//  StudentName VARCHAR(50) not null,
//  City VARCHAR(100) not null ,
//  Phone VARCHAR(10) not null,
//  CourseJoiningDate date not null,
//  FacultyId int FOREIGN KEY  REFERENCES Faculty(FacultyId),
//  course_id INT FOREIGN KEY  REFERENCES Courses(course_id)

//);




//CREATE TABLE FeesDetails (
//  Receipt_id INT IDENTITY(1,1) PRIMARY KEY,
//  StudentId int FOREIGN KEY  REFERENCES StudentRegistration(Student_id),
// course_id INT FOREIGN KEY  REFERENCES Courses(course_id),
// DateOfPayment DATETIME DEFAULT GETDATE(),
//  Amount int not null,

   
// )
