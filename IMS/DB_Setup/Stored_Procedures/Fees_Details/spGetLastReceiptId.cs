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
//-- Description: Get Last Receipt Id
//-- =============================================
//CREATE PROCEDURE spGetLastReceiptId 

//AS
//BEGIN
//	SELECT TOP 1 Receipt_id FROM FeesDetails ORDER BY Receipt_id DESC
//END
//GO