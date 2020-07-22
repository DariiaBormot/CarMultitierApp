--Create Department table  

CREATE TABLE Departments (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL UNIQUE
);


--Create Employee table 

CREATE TABLE Employees(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id),
	ChiefId INT NULL FOREIGN KEY REFERENCES Employees(Id),
	[Name] NVARCHAR(100) NOT NULL,
	Salary INT NOT NULL
);

--Insert values

INSERT INTO Departments( Name )
VALUES  ('Witcher Department'),
		('GOT Department'),
		('Marvel Department'),
		('DC Department'),
		('Rick and Morty');

--Insert chief

INSERT INTO Employees (ChiefId, DepartmentID, Name, Salary)
VALUES  
		(NULL, (SELECT d.Id FROM Departments d WHERE Name = 'Witcher Department'), 'Yennefer of Vengerberg', 700),
		(NULL, (SELECT d.Id FROM Departments d WHERE Name = 'GOT Department'), 'Daenerys Targaryen', 800),
		(NULL, (SELECT d.Id FROM Departments d WHERE Name = 'Marvel Department'), 'Doctor Strange', 1500),
		(NULL, (SELECT d.Id FROM Departments d WHERE Name = 'Marvel Department'), 'Thor', 600),
		(NULL, (SELECT d.Id FROM Departments d WHERE Name = 'DC Department'), 'Aquaman', 800),
		(NULL, (SELECT d.Id FROM Departments d WHERE Name = 'Rick and Morty'), 'Rick Sanchez', 600)

--Insert employee

INSERT INTO Employees (ChiefId, DepartmentID, Name, Salary)
VALUES  
		(2, (SELECT d.Id FROM Departments d WHERE Name = 'GOT Department'), 'John Snow', 200),
		(1, (SELECT d.Id FROM Departments d WHERE Name = 'Witcher Department'), 'Geralt of Rivia', 100),
		(2, (SELECT d.Id FROM Departments d WHERE Name = 'GOT Department'), 'Thanos', 400),
		(5, (SELECT d.Id FROM Departments d WHERE Name = 'DC Department'), 'Flash', 700),
		(3, (SELECT d.Id FROM Departments d WHERE Name = 'Marvel Department'), 'Star Lord', 300),
		(2, (SELECT d.Id FROM Departments d WHERE Name = 'GOT Department'), 'Tyrion Lannister', 900),
		(4, (SELECT d.Id FROM Departments d WHERE Name = 'Marvel Department'), 'Black Widow', 300),
		(1, (SELECT d.Id FROM Departments d WHERE Name = 'Witcher Department'), 'Cirilla of Cintra', 500),
		(6, (SELECT d.Id FROM Departments d WHERE Name = 'Rick and Morty'), 'Summer Smith', 700),
		(6, (SELECT d.Id FROM Departments d WHERE Name = 'Rick and Morty'), 'Morty Smith', 1200),
		(3, (SELECT d.Id FROM Departments d WHERE Name = 'Marvel Department'), 'Tonny Stark', 2000),
		(4, (SELECT d.Id FROM Departments d WHERE Name = 'Marvel Department'), 'Peter Parker', 300),
		(5, (SELECT d.Id FROM Departments d WHERE Name = 'DC Department'), 'Super Man', 100),
		(5, (SELECT d.Id FROM Departments d WHERE Name = 'DC Department'), 'Batman', 1000),
		(5, (SELECT d.Id FROM Departments d WHERE Name = 'DC Department'), 'Wonder Woman', 900);






