--��������������� � �������� ������� ������ ������� � ����������� �����������

SELECT d.Name, COUNT(e.Id) AS [Employee Count]
FROM Departments d
JOIN Employees e ON d.Id = e.DepartmentId
GROUP BY d.Name
ORDER BY d.Name DESC 


--������� ������ �����������, ���������� ���������� ����� ������� ��� � ����������������� ������������

SELECT e.Name AS EmployeeName, e.Salary AS [Employee Salary], c.Name AS ChiefName, c.Salary AS [Chief Salary]
FROM Employees e
JOIN Employees c on e.Id = c.ChiefID
WHERE e.Salary > c.Salary


--������� ������ �������, ���������� ����������� � ������� �� ��������� 3x �������

SELECT d.Name AS [Department Name], COUNT(e.Id) AS [Employees Count]
FROM Departments d
LEFT JOIN Employees e ON d.Id = e.DepartmentId
GROUP BY d.Name
HAVING COUNT(e.Id) <= 3


--������� ������ �����������, ���������� ������������ ���������� ����� � ����� ������

SELECT empl.Name AS [Employee Name], dep.MaxSalary AS [Max Salary], d.Name AS [Department Name]
FROM Employees empl
JOIN (
	SELECT e.DepartmentId, MAX(Salary) AS MaxSalary
	FROM Employees e 
	GROUP BY DepartmentId
	) dep 
ON empl.DepartmentId = dep.DepartmentId
JOIN Departments d
ON empl.DepartmentId = d.Id
WHERE empl.Salary = dep.MaxSalary


--����� ������ ������� � ������������ ��������� ��������� �����������

SELECT d.Name AS [Department Name], depSal.SumSalary AS [Total Salary]
FROM Departments d
JOIN (
	SELECT e.DepartmentId, SUM(e.Salary) AS SumSalary
	FROM Employees e
	GROUP BY DepartmentId
	) depSal
ON d.Id = depSal.DepartmentId
ORDER BY depSal.SumSalary DESC


--������� ������ �����������, �� ������� ������������ ������������, ����������� � ���-�� ������

SELECT empl.Name
FROM Employees empl
WHERE empl.ChiefId IS NULL OR empl.ChiefId NOT IN (
	SELECT chief.Id 
	FROM Employees chief
	WHERE chief.DepartmentId = empl.DepartmentId
);


--SQL-������, ����� ����� ������ ����� ������� �������� ���������

SELECT TOP(1)e.Salary, e.Name
FROM(
	SELECT TOP 2 Salary, Name
	FROM Employees ORDER BY Salary DESC
	) AS e 
ORDER BY e.Salary ASC


SELECT e.Name, e.Salary  
FROM Employees e 
GROUP BY e.Name, e.Salary  
ORDER BY  e.Salary  DESC 
OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY; 