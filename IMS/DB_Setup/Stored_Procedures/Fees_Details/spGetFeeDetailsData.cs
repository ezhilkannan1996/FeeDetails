//-- ================================================
//--Template generated from Template Explorer using:
//--Create Procedure(New Menu).SQL
//--
//-- Use the Specify Values for Template Parameters 
//-- command (Ctrl-Shift-M) to fill in the parameter 
//-- values below.
//--
//-- This block of comments will not be included in
//-- the definition of the procedure.
//-- ================================================
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//-- =============================================
//-- Author:		EZHIL
//-- Create date: 07 / 07 / 2023
//-- Description: Get amount and receipt id using student id and course id
//-- =============================================
//CREATE PROCEDURE spGetFeeDetailsData
//	-- Add the parameters for the stored procedure here
//	@Student_id INT,
//	@course_id INT
//AS
//BEGIN
//     SELECT Courses.fees, FeesDetails.Amount FROM FeesDetails 
//	 INNER JOIN StudentRegistration ON FeesDetails.StudentId = StudentRegistration.Student_id
//	 INNER JOIN Courses ON FeesDetails.course_id = Courses.course_id
//	 WHERE FeesDetails.StudentId = @Student_id AND FeesDetails.course_id = @course_id
//END
//GO