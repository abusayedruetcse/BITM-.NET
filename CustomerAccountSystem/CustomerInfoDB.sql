CREATE DATABASE SMSDB
DESKTOP-AAHS936\SQLEXPRESS

USE CustomerInfoDB

CREATE TABLE Customers
(
AccountNo VARCHAR(20),
Name VARCHAR(35),
Email VARCHAR(40),
OpeningDate VARCHAR(20)
)
-- DROP TABLE Customers
DELETE Customers

CREATE TABLE Accounts
(
AccountNo VARCHAR(20),
Amount NUMERIC(15,2)
)
-- DROP TABLE Accounts
SELECT * FROM Customers WHERE AccountNo= '1223'
INSERT INTO Customers VALUES ('1223','Jahid','adfa@gmail.com','12/2/19')
SELECT * FROM Accounts WHERE AccountNo= ''
UPDATE Accounts SET Amount=  WHERE AccountNo=''
SELECT Name,c.AccountNo,OpeningDate,Amount AS Balance FROM Customers AS c LEFT JOIN Accounts AS a ON c.AccountNo=a.AccountNo WHERE c.AccountNo= '12345678'