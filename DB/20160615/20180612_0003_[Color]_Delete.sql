USE [IchiPaint]
GO

/****** Object:  StoredProcedure [dbo].[PROC_PROJECT_DELETE]    Script Date: 12/06/2018 9:45:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE  [dbo].[PROC_COLOR_DELETE]  
	@P_Id int
AS
BEGIN
	DELETE Color WHERE Id = @P_Id;
END







GO


