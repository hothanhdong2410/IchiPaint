USE [IchiPaint]
GO

/****** Object:  StoredProcedure [dbo].[PROC_PROJECT_INSERT]    Script Date: 12/06/2018 9:32:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[PROC_COLOR_INSERT]  
	-- Add the parameters for the stored procedure here
	@P_Name nvarchar(1000) = null,
	@P_Lstord int = 0,
	@P_Description nvarchar(max) = null,
	@P_Avatar nvarchar(max) = null,
	@P_CreateDate varchar(20) = null,
	@P_Return INT OUTPUT
AS
BEGIN
	  
	select  @P_Return  = ISnull(max(Id), 0)
	from Color;

	 
	insert into Color(Name, Lstord, Description, Avatar, CreateDate)
	values(@P_Name, @P_Lstord, @P_Description, @P_Avatar, @P_CreateDate);

	set @P_Return = @P_Return + 1;

END






GO


