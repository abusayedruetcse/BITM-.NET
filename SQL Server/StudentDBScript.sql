CREATE DATABASE StudentDB
--DROP DATABASE StudentDB
USE StudentDB
//FirstTask
CREATE TABLE Product
(
ID VARCHAR(4),
Name VARCHAR(30),
Category_id VARCHAR(5),
Price NUMERIC(3,0)
)

INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('A001','MOUSE','H',500)
INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('B001','KEY BOARD','M',300)
INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('C001','MONITOR','L',999)
INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('D001','FOOD','H',250)
INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('A002','CHAIR','M',600)
INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('B002','CAP','L',200)
INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('C002','CAR','H',950)
INSERT INTO Product (ID,Name,Category_id,Price)
VALUES ('D002','CAMERA','M',990)

CREATE TABLE Category
(
ID VARCHAR(5),
Name VARCHAR(30)
)

INSERT INTO Category (ID,Name)
VALUES ('H','HIGH')
INSERT INTO Category (ID,Name)
VALUES ('L','LOW')
INSERT INTO Category (ID,Name)
VALUES ('M','MEDIUM')

SELECT MAX(Price) FROM Product
SELECT MIN(Price) FROM Product
SELECT AVG(Price) FROM Product
SELECT SUM(Price) FROM Product

//secondTask
CREATE TABLE Students
(
ID int IDENTITY(1,1),
RollNo VARCHAR(10),
Name VARCHAR(100),
Age int,
Address VARCHAR(200),
DistrictID int
)
--DROP TABLE Students

INSERT INTO Students(RollNo,Name,Age,Address,DistrictID)
VALUES ('CSE001','ALI', 21,'Mirpur', 1)
INSERT INTO Students(RollNo,Name,Age,Address,DistrictID)
VALUES ('CSE002','ARIF', 22,'Savar', 2)
INSERT INTO Students(RollNo,Name,Age,Address,DistrictID)
VALUES ('CSE003','KHAIRUL', 20,'Dhanmondi', 2)
INSERT INTO Students(RollNo,Name,Age,Address,DistrictID)
VALUES ('EEE001','KOBIR', 21,'Uttora', 1)
INSERT INTO Students(RollNo,Name,Age,Address,DistrictID)
VALUES ('EEE002','ALI', 21,'Motijhil', 2)
INSERT INTO Students(RollNo,Name,Age,Address,DistrictID)
VALUES ('EEE003','SAGOR', 21,'Uttora', 1)

CREATE TABLE Districts
(
ID int IDENTITY(1,1),
Name VARCHAR(35)
)

-- DROP TABLE Districts
INSERT INTO Districts(Name)
VALUES ('Dhaka')
INSERT INTO Districts(Name)
VALUES ('Rajshahi')
INSERT INTO Districts(Name)
VALUES ('Sylhet')

DELETE FROM Districts
WHERE ID=3

SELECT s.Name, d.Name AS [District Name] , s.DistrictID
FROM Students AS s LEFT OUTER JOIN Districts AS d
ON d.ID=s.DistrictID

SELECT s.Name, d.Name AS [District Name] , s.DistrictID
FROM Students AS s RIGHT OUTER JOIN Districts AS d
ON d.ID=s.DistrictID

SELECT s.Name, d.Name AS [District Name] , s.DistrictID
FROM Students AS s INNER JOIN Districts AS d
ON d.ID=s.DistrictID

SELECT s.Name, d.Name AS [District Name] , s.DistrictID
FROM Students AS s FULL OUTER JOIN Districts AS d
ON d.ID=s.DistrictID

SELECT s.Name, d.Name AS [District Name] , s.DistrictID
FROM Districts AS d,Students AS s 
WHERE d.ID=s.DistrictID

//Teachers Instruction

CREATE TABLE Districts(

ID int IDENTITY (1,1) PRIMARY KEY,

Name VARCHAR(50)

)

INSERT INTO Districts Values ('Dhaka')

INSERT INTO Districts Values ('Chitagong')

CREATE TABLE Students(

ID int IDENTITY (1,1) PRIMARY KEY,

RollNo VARCHAR(10),

Name VARCHAR(100),

Age int,

Address VARCHAR(MAX),

DistrictID int FOREIGN KEY REFERENCES Districts(ID)

)

SELECT RollNo, s.Name, Age, Address, d.Name AS District FROM Students AS s LEFT JOIN Districts AS d ON s.DistrictId=d.ID WHERE RollNo='CSE100' 

CREATE VIEW StudensView
AS
SELECT s.ID, RollNo, s.Name, Age, Address, DistrictID, d.Name AS District FROM Students AS s LEFT JOIN Districts AS d ON s.DistrictID=d.ID

SELECT * FROM StudensView
UPDATE Students SET Name='', Age='', DistrictID= ,Address='' WHERE RollNo=''

