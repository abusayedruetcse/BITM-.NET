CREATE DATABASE StudentDB
---Working into StudentDB
USE StudentDB
USE master
---Create Table
CREATE TABLE Students
(
ID int IDENTITY(1,1),
Name VARCHAR(100),
Age int
)
---Remove Table
DROP TABLE Students
DROP DATABASE StudentDB
---Insert into Table
INSERT INTO Students(Name,Age)
VALUES ('KHALID',25)

->maintain the proper sequence
INSERT INTO Students
VALUES('JAMIL',20)

---Erase a Record from table
DELETE FROM Students
DELETE FROM Students
WHERE Name='JAMIL'
---Update a column into Table
UPDATE Students
SET Name='KHAIRUL',Age=10

UPDATE Students
SET Name='KHAIRUL',Age=10
WHERE Name='JAMIL'

---Display the table records
SELECT * FROM Students
SELECT Name FROM Students
SELECT DISTINCT Name,Age FROM Students
SELECT * FROM Students ORDER BY Name ASC, Age DESC

<OPERATOR,NOT, BETWEEN, LIKE, IN, AND,OR>
SELECT * FROM Students WHERE Name='JAMIL'
SELECT * FROM Students WHERE Age BETWEEN 10 AND 20
SELECT * FROM Students WHERE Age NOT BETWEEN 10 AND 20
SELECT * FROM Students WHERE Name LIKE 'K%'
SELECT * FROM Students WHERE Name NOT LIKE 'K%'
SELECT * FROM Students WHERE Name IN ('JAMIL','KHAIRUL')
SELECT * FROM Students WHERE Name NOT IN ('JAMIL','KHAIRUL')
SELECT * FROM Students WHERE Age < 20 AND Name IN ('JAMIL','KHAIRUL')

---JOIN table
SELECT s.Name,d.Age
FROM Students As s INNER JOIN Districts As d
ON s.ID=d.ID



