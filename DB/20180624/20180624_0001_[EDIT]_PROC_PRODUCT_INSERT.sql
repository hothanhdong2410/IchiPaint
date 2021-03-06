USE [IchiPaint]
GO
/****** Object:  StoredProcedure [dbo].[PROC_PRODUCT_INSERT]    Script Date: 24/06/2018 10:21:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE  [dbo].[PROC_PRODUCT_INSERT]  
	-- Add the parameters for the stored procedure here
	@P_FullName nvarchar(max) = null,
	@P_ShortName nvarchar(max) = null,
	@P_GroupId int,
	@P_Description nvarchar(max) = null,
	@P_Detail nvarchar(max) = null,
	@P_Avatar nvarchar(max) = null,
	@P_CoatingThickness int,
	@P_Features1  nvarchar(1000) = null,
	@P_Features2  nvarchar(1000) = null,
	@P_Features3  nvarchar(1000) = null,
	@P_Features4  nvarchar(1000) = null,
	@P_Return INT OUTPUT
AS
BEGIN
	  
	select  @P_Return  = ISnull(max(Id), 0)
	from Product;

	 
	insert into Product(FullName, ShortName, GroupId, Description, 
		Detail, Avatar, CoatingThickness, Features1, Features2, Features3, Features4)
	values(@P_FullName, @P_ShortName, @P_GroupId, @P_Description, 
		@P_Detail, @P_Avatar, @P_CoatingThickness, @P_Features1, @P_Features2, @P_Features3, @P_Features4);

	set @P_Return = @P_Return + 1;

END




