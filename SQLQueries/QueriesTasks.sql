-- Task 1
-- Niedostępne produkty, których dostawa jest przewidywana w bieżącym miesiącu

SELECT
	p.[ProductId]
	,p.[Code]
	,p.[Description]
	,p.[Price]
	,p.[DeliveryDate]
FROM [dbo].[Product] p
WHERE p.[IsAvailable] = 0
	AND MONTH(GETUTCDATE()) = MONTH(p.[DeliveryDate])
	AND YEAR(GETUTCDATE()) = YEAR(p.[DeliveryDate])


-- Task 2
-- Dostępne produkty, które są przypisane do więcej niż jednej kategorii

SELECT 
	p.[ProductId]
	,p.[Code]
	,COUNT(p.[ProductId]) AS CategoriesCount 
FROM [dbo].[Product] p
JOIN [dbo].[ProductCategory] pc on p.[ProductId] = pc.[ProductId]
WHERE [IsAvailable] = 1
GROUP BY p.[ProductId], p.[Code]
HAVING COUNT(p.[ProductId]) > 1


-- Task 3
-- Top 3 kategorie wraz z informacją o liczbie przypisanych, dostępnych produktów oraz średnią ceną produktów w kategorii (top 3 powinno pokazywać kategorie, których średnia cen produktów jest największa)

SELECT TOP 3 
	c.[CategoryId]
	,c.[Code] AS 'Category Code'
	,COUNT(p.[ProductId]) AS 'All products'
	,SUM(CAST(p.[IsAvailable] as INT)) AS 'Available products'
	,AVG(p.[Price]) AS 'Average price'
FROM [dbo].[Category] c
JOIN [dbo].[ProductCategory] cp ON c.[CategoryId] = cp.[CategoryId]
JOIN [dbo].[Product] p ON p.[ProductId] = cp.[ProductId]
GROUP BY c.[CategoryId], c.[Code]
ORDER BY AVG(p.[Price]) DESC
