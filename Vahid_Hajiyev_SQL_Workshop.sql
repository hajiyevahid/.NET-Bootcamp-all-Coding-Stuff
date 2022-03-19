--1. 
SELECT  SalesOrderID, OrderDate, TotalDue, SalesPersonID, TerritoryID
  FROM AdventureWorks2019.Sales.SalesOrderHeader
  WHERE TerritoryID IN (2,4,6) AND TotalDue > 50000  ORDER BY TotalDue DESC;

--2. 
SELECT BusinessEntityID, FirstName, ModifiedDate 
  FROM AdventureWorks2019.Person.Person
  WHERE MONTH(ModifiedDate)<>12 AND YEAR(ModifiedDate)<>2013;

--3. 
SELECT BusinessEntityID, FirstName, LastName 
  FROM AdventureWorks2019.Person.Person
  WHERE PersonType='EM' AND FirstName LIKE 'A%S' AND SUBSTRING(FirstName,3,1)='D';

--4. 
SELECT ProductID, Name, Color
  FROM AdventureWorks2019.Production.Product
  WHERE Color<>'blue';

--5.
SELECT SalesOrderID, OrderQty, 
     CASE WHEN OrderQty<10 THEN 'under 10'
      WHEN OrderQty<20 THEN '10-19'
      WHEN OrderQty<30 THEN '20-29'
      WHEN OrderQty<40 THEN '30-39'
      ELSE '40 and over'
    END AS 'range'
  FROM AdventureWorks2019.Sales.SalesOrderDetail 
  ORDER BY OrderQty DESC;

--6. 
SELECT PersonType, FirstName, MiddleName, LastName
  FROM AdventureWorks2019.Person.Person 
  ORDER BY 
  CASE WHEN PersonType IN ('IN','SP','SC') THEN LastName
       ELSE FirstName 
  END;

--7.
SELECT NationalIDNumber, 
  CASE WHEN OrganizationLevel=1 THEN 'Junior'
     WHEN OrganizationLevel=2 THEN 'Medior'
     WHEN OrganizationLevel=3 THEN 'Senior'
     WHEN OrganizationLevel=4 THEN 'Expert'
     ELSE 'Unknown'
  END 
  AS EmployeeLevel
  FROM AdventureWorks2019.HumanResources.Employee
	WHERE Employee.BusinessEntityID<15
  ORDER BY 
  CASE WHEN OrganizationLevel IN (1,2,3,4) THEN OrganizationLevel
  ELSE 5
  END DESC;

--8. 
SELECT AddressID,CONCAT(AddressLine1, ' (', City, PostalCode,')') 
  FROM AdventureWorks2019.Person.Address
  WHERE CITY='Ottawa';

--9. 
SELECT CONCAT( COALESCE(Title + ' ', ''), FirstName + ' ', 
            COALESCE(MiddleName + ' ',''), LastName + ', ', 
            COALESCE(Suffix + ' ','')) AS Full_name
  FROM AdventureWorks2019.Person.Person WHERE BusinessEntityID>384;

--10.
SELECT SalesOrderNumber,convert(varchar, OrderDate, 23) AS OrderDate, ROUND(TotalDue, 2) AS TotalDue, SalesPersonID, TerritoryID
  FROM AdventureWorks2019.Sales.SalesOrderHeader 
  WHERE TotalDue>60000 AND (SalesPersonID = 289 OR TerritoryID = 8) AND CurrencyRateID IS NOT NULL
  ORDER BY TotalDue DESC;

--11.
  Age is calculated on current date (13/02/2022).
SELECT  NationalIDNumber, BirthDate, FLOOR(DATEDIFF(hour,BirthDate,GETDATE())/8766.0) AS Age
  FROM AdventureWorks2019.HumanResources.Employee WHERE BusinessEntityID>108;

--12.
SELECT  ProductID, SUM(OrderQty) AS TotalOrdered, FLOOR(SUM(StockedQty)) AS TotalStock 
  FROM AdventureWorks2019.Purchasing.PurchaseOrderDetail GROUP BY ProductID ORDER BY TotalOrdered DESC;

--13.
SELECT 
  CASE WHEN TotalDue<100 THEN '0-99'
     WHEN TotalDue<1000 THEN '100-999'
     WHEN TotalDue<10000 THEN '1000-9999'
     ELSE '10000-'
  END
  AS range, COUNT(1) AS 'Number Of Orders', SUM(TotalDue) AS 'TotalValue'
  FROM AdventureWorks2019.Sales.SalesOrderHeader 
  GROUP BY 
  CASE WHEN TotalDue<100 THEN '0-99'
     WHEN TotalDue<1000 THEN '100-999'
     WHEN TotalDue<10000 THEN '1000-9999'
     ELSE  '10000-'
  END
  ORDER BY 3;

--14.
SELECT ProductNumber, Name, Color, ListPrice, [Prod_Rank] = RANK() OVER(PARTITION BY Color ORDER BY ListPrice DESC)
  FROM AdventureWorks2019.Production.Product 
  ORDER BY Prod_Rank,Color;

--15.
SELECT A.ProductID, A.Name, D.Description
  FROM [Production].[Product] as A
  JOIN [Production].[ProductModel] B ON B.ProductModelID=A.ProductModelID
  JOIN [Production].[ProductModelProductDescriptionCulture] C ON C.ProductModelID=B.ProductModelID
  JOIN [Production].[ProductDescription] D ON D.ProductDescriptionID=C.ProductDescriptionID
Where 
  A.ProductID=726 
  AND  C.CultureID='fr';

--16.
SELECT A.BusinessEntityID, A.FirstName, A.LastName, B.PhoneNumber, D.Name AS TerritoryName, C.SalesYTD, C.Bonus
FROM Person.Person as A 
INNER JOIN Person.PersonPhone B ON B.BusinessEntityID=A.BusinessEntityID
INNER JOIN Sales.SalesPerson C ON C.BusinessEntityID=B.BusinessEntityID
LEFT JOIN Sales.SalesTerritory D ON D.TerritoryID=C.TerritoryID
ORDER BY A.FirstName;

--17.
SELECT A.Name, SUM(C.OrderQty) AS OrderQty
FROM Production.Product AS A
JOIN Production.ProductSubcategory B ON B.ProductSubcategoryID=A.ProductSubcategoryID
JOIN Sales.SalesOrderDetail C ON C.ProductID=A.ProductID
JOIN Sales.SalesOrderHeader D ON D.SalesOrderID=C.SalesOrderID
JOIN Person.Address E ON E.AddressID=D.ShipToAddressID
WHERE B.Name='Tires and Tubes' AND E.City='Newcastle'
GROUP BY A.Name

--18.
SELECT B.FirstName, B.LastName, A.HireDate, A.JobTitle,  C.CountOfTitle 
FROM HumanResources.Employee AS A 
JOIN Person.Person B ON A.BusinessEntityID = B.BusinessEntityID 
JOIN (SELECT COUNT(*) AS CountOfTitle, JobTitle FROM HumanResources.Employee  GROUP BY JobTitle) C ON A.JobTitle = C.JobTitle


--19.
SELECT   A.Color, A.ProductNumber,A.Name, A.StandardCost
FROM Production.Product A
JOIN (SELECT Color, MAX(StandardCost)AS Stan_Cost FROM Production.Product GROUP BY Color) B ON B.Stan_Cost=A.StandardCost AND B.Color=A.Color 
ORDER BY Color;

--20.
WITH Derived AS(
SELECT CONCAT(A.FirstName, COALESCE(' '+ A.MiddleName+' ',' '), A.LastName) AS 'Customer Name', G.Name AS 'Product Name', SUM(F.OrderQty) AS Quantity
FROM Person.Person A 
  JOIN Person.BusinessEntityAddress B ON A.BusinessEntityID=B.BusinessEntityID
  JOIN Person.Address C ON C.AddressID=B.AddressID
  JOIN Person.AddressType D ON D.AddressTypeID=B.AddressTypeID
  JOIN Sales.SalesOrderHeader E ON E.ShipToAddressID=B.AddressID
  JOIN Sales.SalesOrderDetail F ON F.SalesOrderID=E.SalesOrderID
  JOIN Production.Product G ON G.ProductID=F.ProductID
  WHERE C.City='Cergy' AND D.Name='Home'
  GROUP BY CONCAT(A.FirstName, COALESCE(' '+ A.MiddleName+' ',' '), A.LastName) , G.Name
)
SELECT Derived.[Customer Name],Derived.[Product Name],Derived.[Quantity] 
FROM Derived 
WHERE [Customer Name] IN (SELECT Derived.[Customer Name] FROM Derived GROUP BY [Customer Name] HAVING MAX(Quantity)>1)

--21.
WITH Derived AS 
(SELECT B.Name AS FullName, D.AddressLine1 AS Office_Address, D.AddressID, B.BusinessEntityID, E.AddressTypeID,E.Name AS Office, D.City AS City
FROM Sales.Customer A
JOIN Sales.Store B ON A.StoreID = B.BusinessEntityID
JOIN Person.BusinessEntityAddress C ON C.BusinessEntityID=B.BusinessEntityID
JOIN Person.Address D ON  D.AddressID=C.AddressID 
JOIN Person.AddressType E ON E.AddressTypeID=C.AddressTypeID)
SELECT DISTINCT F.FullName,F.Office_Address, G.Office_Address AS Shipping_Address
FROM Derived F
LEFT JOIN (SELECT * FROM Derived WHERE Derived.AddressTypeID=5) G ON F.BusinessEntityID=G.BusinessEntityID
WHERE F.AddressTypeID=3 AND F.City='Dallas';

--22.
CREATE TABLE [Doc]
(
 [DocId]   int IDENTITY(1,1),
 [Name]    varchar(255) NOT NULL ,
 [DocType] int NOT NULL ,
 CONSTRAINT [PK_5] PRIMARY KEY CLUSTERED ([DocId] ASC)
);
GO

CREATE TABLE [Client]
(
 [ClientId]   int IDENTITY(1,1),
 [FirstName]  varchar(255) NOT NULL ,
 [LastName]   varchar(255) NOT NULL ,

 CONSTRAINT [PK_11] PRIMARY KEY CLUSTERED ([ClientId] ASC)
);
GO

CREATE TABLE [Postman]
(
 [PostmanID]    int IDENTITY(1,1),
 [FirstName]    varchar(255) NOT NULL ,
 [LastName]     varchar(255) NOT NULL ,

 CONSTRAINT [PK_19] PRIMARY KEY CLUSTERED ([PostmanID] ASC)
);
GO

CREATE TABLE [ClientToPostman]
(
 [ClientPostID] int IDENTITY(1,1),
 [ClientId]     int NOT NULL ,
 [PostmanID]    int NOT NULL ,

 CONSTRAINT [PK_24] PRIMARY KEY CLUSTERED ([ClientPostID] ASC),
 CONSTRAINT [FK_30] FOREIGN KEY ([ClientId])  REFERENCES [Client]([ClientId]),
 CONSTRAINT [FK_33] FOREIGN KEY ([PostmanID])  REFERENCES [Postman]([PostmanID])
);
GO

CREATE NONCLUSTERED INDEX [FK_32] ON [ClientToPostman] 
 (
  [ClientId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_35] ON [ClientToPostman] 
 (
  [PostmanID] ASC
 )

GO

CREATE TABLE [Subcription]
(
 [SubID]     int IDENTITY(1,1),
 [ClientId]  int NOT NULL ,
 [DocId]     int NOT NULL ,
 [StartDate] date NOT NULL ,
 [EndDate]   date NOT NULL ,

 CONSTRAINT [PK_38] PRIMARY KEY CLUSTERED ([SubID] ASC),
 CONSTRAINT [FK_41] FOREIGN KEY ([DocId])  REFERENCES [Doc]([DocId]),
 CONSTRAINT [FK_44] FOREIGN KEY ([ClientId])  REFERENCES [Client]([ClientId])
);
GO

CREATE NONCLUSTERED INDEX [FK_43] ON [Subcription] 
 (
  [DocId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_46] ON [Subcription] 
 (
  [ClientId] ASC
 )

GO

--23.
-----------------------Populating------------------------------
INSERT INTO dbo.Doc VALUES('Washington Post',0),('La Opinion',0),
('USA Today',0),('La Opinion',0),('LA Times',0),
('Tampa Bay Times',0),('America Oggi',0),
('People`s World',0),('Nordisk Tidende',0),
('Rocky Mountain News',0),('Stars and Stripes',0);

INSERT INTO dbo.Doc VALUES('Ecology',1),
('American Studies',1),('American Journal of Science',1),
('USA Science',1),('Playboy',1),('Project MUSE',1),
('El Portfolio',1),('Sozluk',1),('Operation X',1),
('Tacos and Snacks',1),('Zvezda',1),('La Oscura',1);

INSERT INTO dbo.Client VALUES('Alan',' Snappy'),('Maria','Foster'),
('Michale','Robbin'),('Enric','Dosio'),
('Joseph',' Dosni'),('Zanifer','Emily'),
('Kuleswar','Itaraman'),('Henrey',' Gabriel'),
('Alex',' Manuel'),('George',' Mardy');

INSERT INTO dbo.Postman VALUES('Bryce','Abbott'), ('Daniela','Abella'), 
('Jacob','Abraham'), ('Reily','Acevedo'), 
('Micaela','Acevedo'),('Breonia','Adam'), 
('Miranda','Adam'), ('Madelyn','Adams'), 
('Jase','Adams'), ('Jessica','Adams'), 
('Samuel','Adams');

INSERT INTO dbo.ClientToPostman VALUES(1,3),(1,2),(1,4),(1,8),
(2,1),(2,6),(2,5),
(2,7),(2,9),(3,10),
(3,9),(3,11),(3,3),
(4,2),(4,9),(4,10),
(4,8),(5,7),(5,5),
(6,9),(6,2),(7,3),
(7,6),(7,10), (8,11),
(8,5),(9,6),(9,9),
(9,10),(10,2),(10,3);

INSERT INTO Subcription VALUES(1,1,'2020-12-01','2022-12-01'),
(8,2,'2020-12-01','2022-01-01'),(1,3,'2020-11-01','2023-02-01'),
(3,4,'2020-10-01','2021-03-01'),(1,5,'2020-09-01','2023-04-01'),
(1,6,'2020-08-01','2022-05-01'),(8,7,'2020-07-01','2021-06-01'),
(1,7,'2020-06-01','2023-07-01'),(2,6,'2020-05-01','2022-08-01'),
(2,4,'2020-04-01','2021-09-01'),(1,2,'2020-03-01','2023-10-01'),
(7,3,'2020-02-01','2022-11-01'),(8,1,'2020-01-01','2021-12-01'),
(7,1,'2020-12-01','2022-12-01'),(5,2,'2020-12-01','2022-01-01'),
(2,3,'2020-11-01','2023-02-01'),(6,4,'2020-10-01','2021-03-01'),
(7,5,'2020-09-01','2023-04-01'),(10,6,'2020-08-01','2022-05-01'),
(10,7,'2020-07-01','2021-06-01'),(9,7,'2020-06-01','2023-07-01'),
(5,6,'2020-05-01','2022-08-01'),(3,9,'2020-04-01','2021-09-01'),
(7,2,'2020-03-01','2023-10-01'),(4,3,'2020-02-01','2022-11-01'),
(9,1,'2020-01-01','2021-12-01');

-----------------------Queries----------------------------------
--24.a
SELECT CONCAT(FirstName+' ',LastName) AS FullName, C.Name AS Newspaper_Journal
  FROM dbo.Client A
  JOIN dbo.Subcription B ON B.ClientId=A.ClientId
  JOIN dbo.Doc C ON C.DocId=B.DocId
WHERE A.ClientId=2;

--24.b
SELECT CONCAT(FirstName+' ',LastName) AS FullName, C.Name AS Newspaper_Journal, B.StartDate, B.EndDate
FROM dbo.Client A
JOIN dbo.Subcription B ON B.ClientId=A.ClientId
JOIN dbo.Doc C ON C.DocId=B.DocId WHERE A.ClientId=1

--24.c
SELECT  CONCAT(FirstName+' ',LastName) AS FullName, COUNT(*)
FROM dbo.Client A
JOIN dbo.Subcription B ON B.ClientId=A.ClientId
JOIN dbo.Doc C ON C.DocId=B.DocId 
WHERE A.ClientId=8 AND B.EndDate<(SELECT CAST(GETDATE() AS Date))
GROUP BY CONCAT(FirstName+' ',LastName);

--24.d
SELECT  CONCAT(FirstName+' ',LastName) AS FullName, COUNT(*)
FROM dbo.Client A
JOIN dbo.Subcription B ON B.ClientId=A.ClientId
JOIN dbo.Doc C ON C.DocId=B.DocId 
WHERE A.ClientId=7 AND B.EndDate>(SELECT CAST(GETDATE() AS Date))
GROUP BY CONCAT(FirstName+' ',LastName);

--24.e
SELECT  CONCAT(A.FirstName+' ',A.LastName) AS Customer,  CONCAT(C.FirstName+' ',C.LastName) AS Postman
FROM dbo.Client A
JOIN dbo.ClientToPostman B ON B.ClientId=A.ClientId
JOIN dbo.Postman C ON C.PostmanID=B.PostmanID 
WHERE A.ClientId=7

--24.f
SELECT  CONCAT(C.FirstName+' ',C.LastName) AS Postman,CONCAT(A.FirstName+' ',A.LastName) AS Customer
FROM dbo.Client A
JOIN dbo.ClientToPostman B ON B.ClientId=A.ClientId
JOIN dbo.Postman C ON C.PostmanID=B.PostmanID 
WHERE C.PostmanID=2

--25.1
ALTER TABLE dbo.Client
ADD ActiveSubs INT NULL DEFAULT NULL;

UPDATE dbo.Client SET ActiveSubs=Derived.Qty
FROM (SELECT  COALESCE(COUNT(*),'NULL') AS Qty,B.ClientId
FROM dbo.Client A
JOIN dbo.Subcription B ON B.ClientId=A.ClientId
JOIN dbo.Doc C ON C.DocId=B.DocId 
WHERE B.EndDate>(SELECT CAST(GETDATE() AS Date))
GROUP BY B.ClientId) AS Derived JOIN Client ON Client.ClientId=Derived.ClientId;
SELECT * FROM dbo.Client;

--25.2
ALTER TABLE dbo.Postman
ADD NextMonth INT NULL DEFAULT NULL;

UPDATE dbo.Postman SET NextMonth=Derived.Qty
FROM dbo.Postman 
JOIN (SELECT  COALESCE(COUNT(*),'NULL') AS Qty, A.PostmanID
FROM dbo.Postman A
JOIN dbo.ClientToPostman B ON B.PostmanID=A.PostmanID
JOIN dbo.Subcription C ON C.ClientId=B.ClientId
WHERE C.EndDate>(SELECT CAST(GETDATE() AS DATE)) AND C.EndDate>(SELECT CAST(DATEADD(mm,1,GETDATE())AS DATE))
GROUP BY A.PostmanID)Derived ON Derived.PostmanID=Postman.PostmanID
SELECT * FROM dbo.Postman;

----------------DROP-----------------------------------------------
ALTER TABLE [dbo].[ClientToPostman] DROP CONSTRAINT [FK_30];
ALTER TABLE [dbo].[ClientToPostman] DROP CONSTRAINT [FK_33];
ALTER TABLE [dbo].[Subcription] DROP CONSTRAINT [FK_41];
ALTER TABLE [dbo].[Subcription] DROP CONSTRAINT [FK_44];
ALTER TABLE [dbo].[Subcription] DROP CONSTRAINT [PK_38];
ALTER TABLE [dbo].[Doc] DROP CONSTRAINT [PK_5];
ALTER TABLE [dbo].[Client] DROP CONSTRAINT [PK_11];
ALTER TABLE [dbo].[Postman] DROP CONSTRAINT [PK_19];
ALTER TABLE [dbo].[ClientToPostman] DROP CONSTRAINT [PK_24];

DROP TABLE [dbo].[ClientToPostman]
DROP TABLE [dbo].[Subcription]
DROP TABLE [dbo].[Doc]
DROP TABLE [dbo].[Client]
DROP TABLE [dbo].[Postman]
