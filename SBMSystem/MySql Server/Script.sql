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