-- All contacts who's name begins with s

--SELECT ContactName,
--	CompanyName,
--	ContactTitle
--From Customers
--WHERE ContactName LIKE 's%';

-- Category ID
--SELECT SUM(UnitsInStock) AS "Total Units In Stock", CategoryID, SupplierID
--FROM Products
--GROUP BY CategoryID, SupplierID

-- Which customer made which order
-- JOIN with Aggregate
--SELECT COUNT(*) AS "Total Orders", c.ContactName AS "Customer"
--FROM Customers c
--INNER JOIN Orders o
--	ON c.CustomerID = o.CustomerID
--GROUP BY c.ContactName

SELECT o.OrderID, o.OrderDate, o.Freight
, c.ContactName AS "Customer Name"
, e.FirstName + ' ' + e.LastName AS "Employee Name"
FROM Orders o
INNER JOIN Customers c
	ON o.CustomerID = c.CustomerID
INNER JOIN Employees e
	ON o.EmployeeID = e.EmployeeID

