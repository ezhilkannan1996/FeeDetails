//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace IMS.Stored_Procedures.StudentRegistraion
//{
//    public class UpdateStudnet
//    {
//    }
//}

//USE[Institute]
//GO
///****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 7/7/2023 5:19:09 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER Procedure [dbo].[UpdateStudent](
//@Student_id int,
//@StudentName varchar(30),
//@City varchar(30),
//@Phone Decimal(10,0),
//@CourseJoiningDate Date,
//@course_id int,
//@FacultyId int
//)

//AS BEGIN

//UPDATE [dbo].[StudentRegistration]
//SET[StudentName] = @StudentName
//      ,[City] = @City
//      ,[Phone] = @Phone
//      ,[CourseJoiningDate] = @CourseJoiningDate
//	  ,[course_id] = @course_id
//      ,[FacultyId] = @FacultyId


// WHERE Student_id = @Student_id
//END