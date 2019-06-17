CREATE DATABASE StockManagementDB
--DROP DATABASE StockManagementDB
USE StockManagementDB
CREATE TABLE Categories
(
SL int IDENTITY(1,1),
Name VARCHAR(25)
)
-- DROP TABLE Categories
INSERT INTO Categories (Name)
VALUES ('Stationary')

SELECT * FROM Categories

UPDATE Categories
SET Name= 'Jamil'
WHERE SL= 3

CREATE TABLE Companies
(
SL int IDENTITY(1,1),
Name VARCHAR(25)
)
-- DROP TABLE Companies

CREATE TABLE Items
(
ID int IDENTITY(1,1),
Name VARCHAR(25),
CategoryID int,
CompanyID int,
ReorderLevel int,
)
-- DROP TABLE Items
SELECT ID FROM Items WHERE Name='' AND CategoryID = AND CompanyID=
SELECT * FROM Items