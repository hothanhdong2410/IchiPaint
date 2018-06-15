USE [IchiPaint]
GO

/****** Object:  StoredProcedure [dbo].[PROC_PROJECT_GET_BY_ID]    Script Date: 12/06/2018 9:53:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE  [dbo].[PROC_COLOR_GET_BY_ID]  
	@P_Id int
AS
BEGIN

	 SELECT a.* from Color a where Id = @P_Id;
	 
END









GO


