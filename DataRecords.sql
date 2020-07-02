IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DataRecords')
CREATE DATABASE DataRecords;
GO
USE DataRecords
--dropping tables
IF OBJECT_ID('tblEmployees') IS NOT NULL 
DROP TABLE tblEmployees;

IF OBJECT_ID('tblManagers') IS NOT NULL 
DROP TABLE tblManagers;

--creating tables
--employees
CREATE TABLE tblEmployees(
	employeeId INT PRIMARY KEY IDENTITY(1,1),
	firstname VARCHAR(20) NOT NULL,
	lastname VARCHAR(20) NOT NULL,
	jmbg CHAR(13) NOT NULL,
	mail VARCHAR(30) NOT NULL,
	salary NUMERIC,
	dateOfBirth DATE not null,
	position VARCHAR(25),
	accountNumber VARCHAR(20) NOT NULL,
	username VARCHAR(20) UNIQUE NOT NULL,
	password VARCHAR(20) NOT NULL,
	);
CREATE TABLE tblManagers(
	managerId INT FOREIGN KEY REFERENCES  tblEmployees(employeeId) ON DELETE SET NULL,
	sector VARCHAR(30) NOT NULL,
	access VARCHAR(15) NOT NULL
);
