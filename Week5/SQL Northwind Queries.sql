-- Question 1.1
--SELECT CustomerID, CompanyName, Address, Region, City, PostalCode, Country
--FROM Customers
--WHERE City = 'Paris' OR City = 'London';

-- Question 1.2
--SELECT ProductName, QuantityPerUnit
--FROM Products
--WHERE QuantityPerUnit LIKE '%bottle%';

-- Question 1.3
--SELECT ProductName, QuantityPerUnit, s.CompanyName, s.Country 
--FROM Products p
--LEFT JOIN Suppliers s
--	ON p.SupplierID = s.SupplierID
--WHERE QuantityPerUnit LIKE '%bottle%';

-- Question 1.4
--Select CategoryName AS "Category Name", COUNT(*) AS "Number Of Products"
--FROM Categories c
--INNER JOIN Products p
--	ON c.CategoryID = p.CategoryID
--GROUP BY c.CategoryName
--ORDER BY COUNT(*) DESC;

-- Question 1.5
--SELECT TitleOfCourtesy + ' ' + FirstName + ' ' + LastName AS "Name", City AS "City Of Residence"
--FROM Employees
--WHERE Country = 'UK';

-- Question 1.6
--SELECT COUNT(*) AS 'Freight Amount'
--FROM Orders
--WHERE FREIGHT > 100 AND ShipCountry IN ('USA','UK');

-- Question 1.7
--SELECT OrderID,
--	(SELECT MAX(Discount) FROM [Order Details]) AS "Max Discount"
--FROM [Order Details]

-- Question 1.8
SELECT e.FirstName + ' ' + e.LastName AS "Employee", 
	r.FirstName + ' ' + r.LastName AS "Reports To"
FROM Employees e
LEFT JOIN Employees r
	ON e.ReportsTo = r.EmployeeID;

