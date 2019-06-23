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

SELECT DISTINCT cat.Name, i.CategoryID FROM Categories AS cat LEFT JOIN Items AS i ON cat.ID=i.CategoryID WHERE i.CompanyID= 
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

CREATE TABLE StockIns
(
ID int IDENTITY(1,1),
Date VARCHAR(10),
Quantity int,
ItemID int
)
-- DROP TABLE StockIns
SELECT * FROM StockIns

CREATE TABLE StockOuts
(
ID int IDENTITY(1,1),
Date VARCHAR(20),
Quantity int,
Action VARCHAR(8),
ItemID int
)

SELECT DISTINCT cat.Name
FROM  Categories AS cat LEFT JOIN Items As i
ON i.CategoryID=cat.ID
WHERE i.CompanyID= 3

SELECT DISTINCT cat.Name FROM  Categories AS cat LEFT JOIN Items As i ON i.CategoryID=cat.ID WHERE i.CompanyID= 3