CREATE DATABASE ABCDB
CREATE DATABASE StockManagementDB
--DROP DATABASE StockManagementDB
-- //connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB;Integrated Security=True";
            
USE StockManagementDB
CREATE TABLE UserAccount 
(
ID int IDENTITY(1,1),
Email VARCHAR(35),
UserName VARCHAR(35),
Password VARCHAR(35)
)
-- DROP TABLE UserAccount
SELECT * FROM UserAccount WHERE Password='' AND (Email= '' OR UserName='')
INSERT INTO UserAccount VALUES('A','B','C')

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

CREATE TABLE InsertUpdateHistory 
(
UserID int,
TableName VARCHAR(20),
TableRowNo int,
Element VARCHAR(30),
DateAndTime VARCHAR(25)
)
-- DROP TABLE InsertUpdateHistory  
INSERT INTO InsertUpdateHistory VALUES( 1,'sf',4 ,'fs')
SELECT * FROM InsertUpdateHistory
SELECT SUM(Quantity)
FROM StockOuts
WHERE Action='Sell' AND Date BETWEEN '2018-00-10' AND '2020-10-10'

SELECT i.Name AS ItemName, com.Name AS CompanyName, SUM(Quantity) AS TotalQuantity FROM StockOuts, Companies AS com,Items AS i WHERE ItemID=i.ID AND i.CompanyID=com.ID AND Action='Sell' AND Date BETWEEN '2018-00-10' AND '2020-10-10' GROUP BY ItemID,i.Name,com.Name

SELECT DISTINCT cat.Name
FROM  Categories AS cat LEFT JOIN Items As i
ON i.CategoryID=cat.ID
WHERE i.CompanyID= 3

SELECT DISTINCT cat.Name FROM  Categories AS cat LEFT JOIN Items As i ON i.CategoryID=cat.ID WHERE i.CompanyID= 3

SELECT i.TableRowNo,t.Name,u.Email,i.DateAndTime
FROM InsertUpdateHistory AS i, UserAccount AS u, Companies AS t
WHERE i.TableName='Companies' AND t.ID=i.TableRowNo AND i.UserID=u.ID
ORDER BY i.DateAndTime DESC

SELECT i.TableRowNo,t.Name,u.Email,i.DateAndTime
FROM InsertUpdateHistory AS i, UserAccount AS u, Items AS t
WHERE i.TableName='Items' AND t.ID=i.TableRowNo AND i.UserID=u.ID
ORDER BY i.DateAndTime DESC
SELECT i.TableRowNo AS TableRowNo,item.Name AS Element,u.Email AS Email,i.DateAndTime AS DateAndTime FROM InsertUpdateHistory AS i, UserAccount AS u, StockIns AS t,Items AS item WHERE i.TableName='StockIns' AND t.ID=i.TableRowNo AND t.ItemID=item.ID AND i.UserID=u.ID ORDER BY i.DateAndTime DESC
SELECT i.TableRowNo AS TableRowNo,i.Element AS Element,u.Email AS Email,i.DateAndTime AS DateAndTime FROM InsertUpdateHistory AS i, UserAccount AS u, StockIns AS t WHERE i.TableName='StockIns' AND t.ID=i.TableRowNo AND i.UserID=u.ID ORDER BY i.DateAndTime DESC
SELECT s.ID AS ID,ItemID, Name AS ItemName,Date,Quantity FROM StockIns AS s LEFT OUTER JOIN Items AS i ON s.ItemID=i.ID WHERE s.ItemID=2 ORDER BY s.Date DESC

SELECT i.Name AS ItemName, com.Name AS CompanyName, cat.Name AS CategoryName, AvailableQuantity, ReorderLevel FROM Items AS i, Companies AS com, Categories AS cat WHERE i.ID=2 AND i.CompanyID=com.ID AND i.CategoryID=cat.ID
SELECT DISTINCT cat.Name AS Name,cat.ID AS ID FROM Categories AS cat , Items AS i WHERE i.CategoryID=cat.ID AND i.CompanyID=5

CREATE VIEW CompanyView AS SELECT * FROM Companies
SELECT * FROM CompanyView






