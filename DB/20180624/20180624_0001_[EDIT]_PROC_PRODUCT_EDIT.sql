USE [IchiPaint]
GO
/****** Object:  StoredProcedure [dbo].[PROC_PRODUCT_EDIT]    Script Date: 24/06/2018 10:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE  [dbo].[PROC_PRODUCT_EDIT]  
	@P_Id int,
	@P_FullName nvarchar(1000) = null,
	@P_ShortName nvarchar(1000) = null, 
	@P_GroupId int,
	@P_Description nvarchar(max),
	@P_Detail nvarchar(max),
	@P_Avatar nvarchar(max),
	@P_CoatingThickness int,
	@P_Features1  nvarchar(1000) = null,
	@P_Features2  nvarchar(1000) = null,
	@P_Features3  nvarchar(1000) = null,
	@P_Features4  nvarchar(1000) = null,
	@P_Return INT OUTPUT
AS
BEGIN
	
	update Product set 
	FullName =@P_FullName, ShortName = @P_ShortName,
	GroupId = @P_GroupId, Description = @P_Description,
	Detail = @P_Detail, Avatar = @P_Avatar, CoatingThickness = @P_CoatingThickness,
	Features1 = @P_Features1, Features2 = @P_Features2, Features3 = @P_Features3, Features4 = @P_Features4
	where Id = @P_Id;

	SET @P_Return = 1;
END




