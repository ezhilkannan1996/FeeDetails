//using System.Collections.Generic;
//using System.Web.UI.WebControls;
//using System.Web.UI;

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
//-- Add the parameters for the stored procedure here
//	@Student_id INT,
//    @course_id INT,
//    @Result INT OUTPUT
//AS
//BEGIN
//     DECLARE @AmountPaid INT, @Fee INT, @Result INT

//     -- Retrieve the fee amount for the given student and course
//     SELECT @Fee = fees FROM Courses WHERE course_id = @course_id;

//--Calculate the remaining balance by subtracting the amount paid from the fee amount
//     SELECT @AmountPaid = SUM(Amount) FROM FeesDetails WHERE StudentId = @Student_id AND course_id = @course_id;

//SET @Result = @Fee - ISNULL(@AmountPaid, 0);

//SELECT @Result AS RemainingBalance;
//END
