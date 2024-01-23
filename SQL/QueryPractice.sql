CREATE TABLE Persons (
    Personid int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int
);
INSERT INTO Persons (FirstName,LastName,Age)
VALUES ('Mehak','Gupta','18');
SELECT * FROM Persons;
truncate table Persons;

CREATE PROCEDURE printdata
AS
BEGIN
    PRINT 'Executing printdata stored procedure - Before SELECT';
    SELECT * FROM persons;
    PRINT 'Executing printdata stored procedure - After SELECT';
END;

CREATE PROCEDURE printdata2
AS
begin
SELECT * FROM persons
end;	

exec printdata2;

ALTER TABLE Persons
ADD CONSTRAINT Lname
DEFAULT 'Gupta' FOR LastName;

INSERT INTO Persons (FirstName,Age)
VALUES ('Nishi','22');
select * from persons;

use adventureworks2022;
SELECT table_name = t.name
FROM sys.tables t
INNER JOIN sys.schemas s ON t.schema_id = s.schema_id;

SELECT * FROM HumanResources.Department;
SELECT DISTINCT GroupName FROM HumanResources.Department;
SELECT COUNT(DISTINCT GroupName) FROM HumanResources.Department;
SELECT * FROM HumanResources.Department
WHERE GroupName='Manufacturing';

SELECT DISTINCT DepartmentID FROM HumanResources.Department;

SELECT * FROM HumanResources.Department
WHERE DepartmentID=1;

SELECT * FROM HumanResources.Department
WHERE DepartmentID>10;

SELECT * FROM HumanResources.Employee;

SELECT * FROM HumanResources.JobCandidate;

SELECT * FROM HumanResources.EmployeePayHistory;

SELECT * FROM HumanResources.Employee ORDER BY SickLeaveHours;
SELECT * FROM HumanResources.Employee ORDER BY SickLeaveHours;
SELECT * FROM Production.ProductDescription;
SELECT * FROM Production.Product;

SELECT * FROM Production.Product
WHERE ProductNumber LIKE 'EC%';

SELECT * FROM Person.Person;

SELECT * FROM Person.Person 
WHERE EmailPromotion=1 AND (PersonType='EM' OR PersonType='SC');

SELECT * FROM Person.Person 
WHERE  NOT EmailPromotion=1 AND (PersonType='EM' OR PersonType='SC');

SELECT * FROM Person.Person 
WHERE  ( EmailPromotion NOT BETWEEN 1 AND 2) AND (PersonType='EM' OR PersonType='SC');

SELECT * FROM Person.Person 
WHERE Suffix IS NOT NULL;

SELECT * FROM Person.Person 
WHERE Suffix IS NOT NULL AND Title IS NULL;

UPDATE Person.Person 
SET Title='Mr.'
WHERE Suffix IS NOT NULL AND Title IS NULL;

SELECT TOP 3 * FROM Person.Person
ORDER BY FirstName DESC;

SELECT * FROM Sales.SalesOrderDetail;

SELECT MAX(UnitPrice) as maxprice FROM Sales.SalesOrderDetail;

SELECT COUNT(DISTINCT UnitPrice) FROM Sales.SalesOrderDetail;

SELECT AVG(DISTINCT UnitPrice) FROM Sales.SalesOrderDetail;

SELECT AVG(OrderQty) FROM Sales.SalesOrderDetail 
WHERE ProductID=777;

--USING FUNCTION
GO
CREATE FUNCTION getAverage(@id INT)
RETURNS FLOAT
AS 
BEGIN
 DECLARE @average FLOAT;
 SELECT @average=AVG(OrderQty)
 FROM Sales.SalesOrderDetail
 WHERE ProductID=@id;

 RETURN @average;
END;
GO
DECLARE @ID INT;
SET @ID = 777;
SELECT DBO.getAverage(@ID) AS AVERAGE_ORDER_QTY;

--SQL CASE
SELECT DISTINCT UnitPrice FROM Sales.SalesOrderDetail;
SELECT SalesOrderDetailID,
CASE WHEN UnitPrice <500 THEN 'PRICE LESS THAN 500'
WHEN UnitPrice BETWEEN 500 AND 1000 THEN 'PRICE MORE THAN 500 AND LESS THAN 1000'
WHEN UnitPrice BETWEEN 1000 AND 2000 THEN 'PRICE MORE THAN 1000 AND LESS THAN 2000'
ELSE 'MORE THAN 2000'
END AS UnitInfo 
FROM Sales.SalesOrderDetail;

--using procedure
GO;
CREATE PROCEDURE selectAll
AS 
SELECT * FROM Sales.SalesOrderDetail
GO;
 EXEC selectAll;

