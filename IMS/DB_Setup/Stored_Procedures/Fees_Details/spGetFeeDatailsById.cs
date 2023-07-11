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
//-- Description: Get record by id
//-- =============================================
//CREATE PROCEDURE spGetFeeDatailsById
//	@Receipt_Id INT
//AS
//BEGIN
//	SELECT * FROM FeesDetails WHERE Receipt_id=@Receipt_Id;
//END
//GO
