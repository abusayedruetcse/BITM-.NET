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
Description VARCHAR(60),
AvailableQuantity int,
CurrentMRP int,
UnitPrice int
)
CREATE TABLE Customers
(
Code VARCHAR(15),
Name VARCHAR(45),
Address VARCHAR(60),
Email VARCHAR(25),
Contact VARCHAR(15),
ImageCustomer VARCHAR(MAX),
LoyaltyPoint int
)
CREATE TABLE Suppliers
(
Code VARCHAR(15),
Name VARCHAR(45),
Address VARCHAR(60),
Email VARCHAR(25),
Contact VARCHAR(15),
ImageCustomer VARCHAR(MAX),
ContactPerson VARCHAR(15)
)
CREATE TABLE Purchases 
(
SupplierCode VARCHAR(15),
BillNo VARCHAR(15),
Date VARCHAR(20),
ProductCode VARCHAR(15),
ManufacturedDate VARCHAR(20),
ExpireDate VARCHAR(20),
Quantity int,
UnitPrice int,
MRP int,
Remarks VARCHAR(45)
)

-- DROP TABLE Products
-- DROP TABLE Customers
SELECT * FROM Categories
INSERT INTO Categories VALUES('','');
UPDATE Categories SET Name='Machinaries' WHERE Code='000'
DELETE Categories WHERE Code='004'
SELECT * FROM Products
SELECT p.Code AS Code,p.Name AS Name, c.Name AS Category, ReorderLevel,ImageProduct, Description FROM Products AS p LEFT JOIN Categories AS c ON p.CategoryCode=c.Code
UPDATE Products 
SET Name='',CategoryCode='',ReorderLevel='',ImageProduct='',Description=''
WHERE Code=''
SELECT * FROM Customers WHERE Code='001'
SELECT * FROM Suppliers