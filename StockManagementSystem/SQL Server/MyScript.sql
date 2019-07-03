CREATE DATABASE StockManagementDB
--DROP DATABASE StockManagementDB
USE StockManagementDB
CREATE TABLE Categories
(
ID int IDENTITY(1,1),
Name VARCHAR(25)
)
-- DROP TABLE Categories
INSERT INTO Categories (Name)
VALUES ('Stationary')

SELECT DISTINCT cat.Name, i.CategoryID FROM Categories AS cat LEFT JOIN Items AS i ON cat.ID=i.CategoryID WHERE i.CompanyID= 2
SELECT DISTINCT com.Name, i.CompanyID FROM Companies AS com LEFT JOIN Items AS i ON com.ID=i.CompanyID WHERE i.CategoryID=3
SELECT * FROM Items WHERE CategoryID =3 AND CompanyID=3

UPDATE Categories
SET Name= 'Jamil'
WHERE SL= 3

CREATE TABLE Companies
(
ID int IDENTITY(1,1),
Name VARCHAR(25)
)
-- DROP TABLE Companies
DELETE Companies
WHERE ID=5

SELECT * FROM Companies

CREATE TABLE Items
(
ID int IDENTITY(1,1),
Name VARCHAR(25),
CategoryID int,
CompanyID int,
ReorderLevel int,
AvailableQuantity int
)
-- DROP TABLE Items
SELECT ID FROM Items WHERE Name='' AND CategoryID = AND CompanyID=
SELECT * FROM Items
SELECT DISTINCT cat.ID, cat.Name FROM Items AS i LEFT JOIN Categories AS cat ON i.CategoryID=cat.ID WHERE i.CompanyID=2

SELECT i.Name AS Name,com.Name AS Company,cat.Name AS Category,AvailableQuantity,ReorderLevel FROM Items AS i, Categories AS cat, Companies AS com WHERE CategoryID=cat.ID AND CompanyID=com.ID AND CategoryID=3 AND CompanyID=3

UPDATE Items SET AvailableQuantity=  WHERE ID=

CREATE TABLE StockIns
(
ID int IDENTITY(1,1),
Date VARCHAR(10),
Quantity int,
ItemID int
)
-- DROP TABLE StockIns
SELECT * FROM StockIns
SELECT Name,Date,Quantity FROM StockIns AS s LEFT OUTER JOIN Items AS i ON s.ItemID=i.ID ORDER BY s.Date DESC 

CREATE TABLE StockOuts
(
ID int IDENTITY(1,1),
Date VARCHAR(20),
Quantity int,
ItemID int,
Action VARCHAR(7)
)

-- DROP TABLE StockOuts
SELECT * FROM StockOuts

SELECT SUM(Quantity)
FROM StockOuts
WHERE Action='Sell' AND Date BETWEEN '2018-00-10' AND '2020-10-10'

SELECT i.Name AS ItemName, com.Name AS CompanyName, SUM(Quantity) AS TotalQuantity FROM StockOuts, Companies AS com,Items AS i WHERE ItemID=i.ID AND i.CompanyID=com.ID AND Action='Sell' AND Date BETWEEN '2018-00-10' AND '2020-10-10' GROUP BY ItemID,i.Name,com.Name

SELECT DISTINCT cat.Name
FROM  Categories AS cat LEFT JOIN Items As i
ON i.CategoryID=cat.ID
WHERE i.CompanyID= 3

SELECT DISTINCT cat.Name FROM  Categories AS cat LEFT JOIN Items As i ON i.CategoryID=cat.ID WHERE i.CompanyID= 3