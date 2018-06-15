USE [IchiPaint]
GO

/****** Object:  StoredProcedure [dbo].[PROC_PROJECT_SEARCH]    Script Date: 12/06/2018 9:47:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE  PROCEDURE  [dbo].[PROC_COLOR_SEARCH]
 @P_START VARCHAR(50),
 @P_END VARCHAR(50),
 @P_TOTAL INT OUTPUT
  AS 
  BEGIN
 
  DECLARE @V_SQL NVARCHAR(4000) = '';
  DECLARE @V_SQL_TOTAL NVARCHAR(4000) = '';
  DECLARE @V_CONDITION NVARCHAR(4000) = '';
 
 
  SET  @V_SQL =  N' SELECT A.* FROM (
			 SELECT  ROW_NUMBER() OVER(ORDER BY CreateDate DESC) AS STT, A.* 
			 FROM Color A  
			  
			 WHERE 1 = 1 '   + @V_CONDITION + '
	 ) A WHERE 1 = 1 '  ;
 
	IF  @P_END <> 0
	 SET  @V_SQL =   @V_SQL + ' AND A.STT <= ' + @P_END + '   AND A.STT >=  ' + @P_START  ;
 
	   EXECUTE sp_executesql 
	   @query = @V_SQL;
 
	 

	SET @V_SQL_TOTAL = N'SELECT @TOTAL=COUNT(*) FROM Color A WHERE 1 = 1 '  + @V_CONDITION; 
 
    EXEC sp_executesql 
        @query = @V_SQL_TOTAL,
        @params = N'@TOTAL INT OUTPUT',	
        @TOTAL = @P_TOTAL OUTPUT  
		
	
  END
 









GO


