CREATE DATABASE StockManagementDB
--DROP DATABASE StockManagementDB
USE StockManagementDB
CREATE TABLE Categories
(
SL int IDENTITY(1,1),
Name VARCHAR(25)
)

INSERT INTO Categories (Name)
VALUES ('Stationary')

SELECT * FROM Categories