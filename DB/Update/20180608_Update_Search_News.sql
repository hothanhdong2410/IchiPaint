USE [IchiPaint]
GO
/****** Object:  StoredProcedure [dbo].[PROC_NEWS_SEARCH]    Script Date: 08/06/2018 12:05:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE  [dbo].[PROC_NEWS_SEARCH]  
 @P_ORDER_BY VARCHAR(50),
 @P_ORDER_TYPE VARCHAR(50),
 @P_START VARCHAR(50),
 @P_END VARCHAR(50),
 @P_CREATE_DATE VARCHAR(50),
 @P_TITLE NVARCHAR(100),
 @P_TOTAL INT OUTPUT
  AS 
  BEGIN
 
   SET @P_CREATE_DATE  = '%'+ @P_CREATE_DATE  + '%';  
   SET @P_TITLE =  '%'+ @P_TITLE  + '%';  
  DECLARE @V_SQL NVARCHAR(4000) = '';
  DECLARE @V_SQL_TOTAL NVARCHAR(4000) = '';
  DECLARE @V_CONDITION NVARCHAR(4000) = '';
 set  @P_ORDER_BY =  @P_ORDER_BY + ' '  +  @P_ORDER_TYPE;
 
 if LEN(@P_TITLE) > 0 
	   SET @V_CONDITION = @V_CONDITION + N' AND UPPER(A.Title) like UPPER(@P_TITLE)';
 
  SET  @V_SQL =  N' SELECT A.* FROM (
			 SELECT  ROW_NUMBER() OVER(ORDER BY ' +  @P_ORDER_BY + ') AS STT, A.*, B.CdContent as CategoryName 			 
			 FROM News A 
			 left join AllCode b on a.CategoryType =b.CdValue and b.CdName= ''Category'' and b.CdType = ''Type''
			 WHERE 1 = 1 '   + @V_CONDITION + '
	 ) A WHERE 1 = 1 '  ;
 
	IF  @P_END <> 0
	 SET  @V_SQL =   @V_SQL + ' AND A.STT <= ' + @P_END + '   AND A.STT >=  ' + @P_START  ;
   IF LEN(@P_ORDER_BY) > 0  
	  SET @V_SQL  = @V_SQL + ' ORDER BY ' + @P_ORDER_BY;
	   EXECUTE sp_executesql 
	   @query = @V_SQL,
	   @params = N' @P_TITLE NVARCHAR(100)',
		 @P_TITLE = @P_TITLE;

	SET @V_SQL_TOTAL = N'SELECT @TOTAL=COUNT(*) FROM News A WHERE 1 = 1 '  + @V_CONDITION; 
	--insert into  WLOG (MES) values( @V_SQL);
    EXEC sp_executesql 
        @query = @V_SQL_TOTAL,
        @params = N'@TOTAL INT OUTPUT, @P_TITLE NVARCHAR(100)',
 
		@P_TITLE = @P_TITLE,
        @TOTAL = @P_TOTAL OUTPUT  
		
		

    
  END
