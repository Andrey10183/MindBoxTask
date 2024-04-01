SELECT 
	p.ProductName,
	c.CategoryName
FROM Products as p
LEFT JOIN Categories AS c ON p.CategoryID = c.CategoryID