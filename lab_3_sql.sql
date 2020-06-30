sp_configure 'show advanced options', 1;    
GO    
RECONFIGURE;    
GO    
sp_configure 'clr strict security', 0;    
GO    
RECONFIGURE;    
GO 

CREATE ASSEMBLY lab_3 from 'D:\Study\Databases-1\lab_3\lab_3\bin\Debug\lab_3.dll' WITH PERMISSION_SET = SAFE

CREATE PROCEDURE OrdersPIVOT    
@begin_date datetime, @end_date datetime     
AS    
EXTERNAL NAME lab_3.[lab_3.StoredProcedure].OrdersPIVOT 

DECLARE @p1 datetime = CONVERT(Datetime, '2020-02-01', 120), @p2 datetime = CONVERT(Datetime, '2020-02-20', 120)
EXEC OrdersPIVOT @begin_date = @p1, @end_date = @p2

CREATE TYPE dbo.Route   
EXTERNAL NAME lab_3.[lab_3.Route];

CREATE TABLE Example
(ID int IDENTITY(1,1) PRIMARY KEY, Route Route)

INSERT INTO Example(Route) VALUES (CONVERT(Route, 'Gomel,Minsk')); 
INSERT INTO Example(Route) VALUES (CONVERT(Route, 'Brest,Minsk')); 
INSERT INTO Example(Route) VALUES (CONVERT(Route, 'Gomel,Vitebsk')); 

SELECT ID, Route.ToString() AS Route FROM Example;
