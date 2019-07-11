CREATE DATABASE SBMSDB
USE SBMSDB
CREATE TABLE Categories 
(
Code VARCHAR(15),
Name VARCHAR(45)
)
CREATE TABLE Products 
(
Code VARCHAR(15),
Name VARCHAR(45),
CategoryCode VARCHAR(15),
ReorderLevel int,
ImageProduct VARCHAR(MAX),
Description VARCHAR(60)
)
-- DROP TABLE Products
SELECT * FROM Categories
INSERT INTO Categories VALUES('','');
UPDATE Categories SET Name='Machinaries' WHERE Code='000'
DELETE Categories WHERE Code='004'
SELECT * FROM Products
SELECT p.Code AS Code,p.Name AS Name, c.Name AS Category, ReorderLevel,ImageProduct, Description FROM Products AS p LEFT JOIN Categories AS c ON p.CategoryCode=c.Code
UPDATE Products 
SET Name='',CategoryCode='',ReorderLevel='',ImageProduct='',Description=''
WHERE Code=''