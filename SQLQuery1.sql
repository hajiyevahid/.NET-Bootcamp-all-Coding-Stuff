
------------------------------------Vahid__Hajiyev_SQL_TASK------------------------------------

--**1**--
SELECT BusinessEntityId, LastName, FirstName 
FROM Person.Person;
------------------------------------------------------

--**2**--
SELECT Name, ProductNumber, Color
FROM Production.Product;
-------------------------------------------------------

--**3**--
SELECT BusinessEntityID, JobTitle, LoginID
FROM HumanResources.Employee
WHERE JobTitle = 'Research and Development Engineer'; 
--------------------------------------------------------

--**4**--
SELECT [ProductID]
 ,[Name]
 ,[Color]
 ,[Size]
 ,[StandardCost]
 ,[Weight]
 ,[ListPrice]
 FROM [AdventureWorks2019].[Production].[Product]
WHERE Color = 'White';
--------------------------------------------------------

--**5**--
SELECT FirstName, MiddleName, LastName, BusinessEntityID
FROM Person.Person
WHERE MiddleName = 'J'; 
--------------------------------------------------------

--**6**--
SELECT BusinessEntityID, FirstName, ModifiedDate
FROM  [AdventureWorks2019].[Person].[Person]
WHERE ModifiedDate > '2013-12-29';
---------------------------------------------------------

--**7**--
SELECT BusinessEntityID, JobTitle, BirthDate, Gender, HireDate
FROM [AdventureWorks2019].[HumanResources].[Employee]
WHERE HireDate < '2008';
----------------------------------------------------------

--**8**--SELECT BusinessEntityID, JobTitle, HireDate, VacationHours
FROM [AdventureWorks2019].[HumanResources].[Employee]
WHERE JobTitle ='Sales Representative' AND VacationHours>35;
------------------------------------------------------------

--**9**--
SELECT DISTINCT ProductId
From Purchasing.PurchaseOrderDetail;
------------------------------------------------------------

--**10**--
SELECT SalesOrderID, OrderDate, TotalDue
FROM Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '2013-09-01' AND '2013-09-30'
 AND TotalDue > 1000; 
 -----------------------------------------------------------

--**11**--
SELECT TOP (10) [AddressID]
      ,[AddressLine1]
      ,[AddressLine2]
      ,[City]
      ,[StateProvinceID]
      ,[PostalCode]
      ,[SpatialLocation]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2019].[Person].[Address]
  -----------------------------------------------------------

--**12**--
SELECT LoginID, OrganizationLevel, JobTitle,VacationHours
FROM HumanResources.Employee
Where JobTitle LIKE '%WC20%'
--------------------------------------------------------------

--**13---
SELECT ProductID, Comments
FROM Production.ProductReview
WHERE Comments LIKE '%SOCKS%'
--------------------------------------------------------------

--**14**--
SELECT DISTINCT
TITLE
FROM Person.Person
WHERE Title IS NOT NULL
--------------------------------------------------------------

--**15**--
SELECT PRODUCTID, Name, Style, Size, Color
FROM Production.Product
WHERE Style IS NOT NULL OR SIZE IS NOT NULL OR COLOR IS NOT NULL;
---------------------------------------------------------------

