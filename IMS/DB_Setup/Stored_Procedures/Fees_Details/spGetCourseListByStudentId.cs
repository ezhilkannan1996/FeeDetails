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
//-- Description: Get the data for fees details page courses dropdown
//-- =============================================
//CREATE PROCEDURE spGetCourseListByStudentId
//	-- Add the parameters for the stored procedure here
//	@Id INT
//AS
//BEGIN
//	-- SET NOCOUNT ON added to prevent extra result sets from
//	-- interfering with SELECT statements.
//	SET NOCOUNT ON;

//--Insert statements for procedure here

//SELECT Courses.course_id, Courses.course_name

//FROM Courses

//INNER JOIN StudentRegistration ON Courses.course_id = StudentRegistration.course_id

//WHERE Student_id = @Id;
//END
//GO
