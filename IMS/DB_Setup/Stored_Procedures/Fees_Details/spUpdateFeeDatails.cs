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
//-- Author:		Ezhil Kannan
//-- Create date: 11 / 07 / 2023
//-- Description: Update a record
//-- =============================================
//CREATE PROCEDURE[dbo].[spUpdateFeeDatails]
//	-- Add the parameters for the stored procedure here
//	@Receipt_id INT,
//	@StudentId INT,
//	@course_id INT,
//	@DateOfPayment DATETIME,
//	@Amount INT
//AS
//BEGIN
//	UPDATE FeesDetails SET StudentId=@StudentId, course_id = @course_id, DateOfPayment = @DateOfPayment, Amount = @Amount WHERE Receipt_id=@Receipt_id;
//END