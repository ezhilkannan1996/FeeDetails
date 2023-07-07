//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace IMS.Stored_Procedures.StudentRegistraion
//{
//    public class InsertStudent
//    {
//    }
//}

//USE[Institute]
//GO
///****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 7/7/2023 5:18:48 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER Procedure [dbo].[InsertStudent](
//@StudentName varchar(30),
//@City varchar(30),
//@Phone varchar(10),
//@CourseJoiningDate date,
//@course_id int,
//@FacultyId int
//)

//AS
//BEGIN

//INSERT INTO [dbo].[StudentRegistration]
//(StudentName, City, Phone, CourseJoiningDate, FacultyId, course_id)
//VALUES
//(@StudentName, @City, @Phone, @CourseJoiningDate, @course_id, @FacultyId)
//END