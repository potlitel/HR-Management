﻿/****** Object:  UserDefinedFunction [dbo].[fnSplitString]    Script Date: 2/9/2022 1:43:05 PM ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO


CREATE FUNCTION [dbo].[fnSplitString] 
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) 
) 
RETURNS @output TABLE(splitdata NVARCHAR(MAX) 
) 
BEGIN
    DECLARE @start INT, @end INT
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string)
    WHILE @start < LEN(@string) + 1 BEGIN
        IF @end = 0  
            SET @end = LEN(@string) + 1

        INSERT INTO @output
            (splitdata)
        VALUES(SUBSTRING(@string, @start, @end - @start))
        SET @start = @end + 1
        SET @end = CHARINDEX(@delimiter, @string, @start)

    END
    RETURN
END
GO