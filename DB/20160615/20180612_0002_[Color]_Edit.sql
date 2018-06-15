USE [IchiPaint]
GO

/****** Object:  StoredProcedure [dbo].[PROC_PROJECT_EDIT]    Script Date: 12/06/2018 9:41:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE  [dbo].[PROC_COLOR_EDIT]  
	@P_Id int,
	@P_Name nvarchar(1000) = null,
	@P_Avatar nvarchar(max),
	@P_Description nvarchar(max),
	@P_Lstord int,
	@P_Return INT OUTPUT
AS
BEGIN
	
	update Color set 
	Name =@P_Name, Avatar = @P_Avatar,
	Description = @P_Description, Lstord = @P_Lstord 
	where Id = @P_Id;

	SET @P_Return = 1;
END






GO


