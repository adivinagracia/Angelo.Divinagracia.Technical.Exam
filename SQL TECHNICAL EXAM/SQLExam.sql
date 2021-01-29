IF OBJECT_ID('ExamTable') IS NULL
BEGIN
	CREATE TABLE ExamTable (
		[Name] VARCHAR(50) NOT NULL,
		[Sales] INT NOT NULL,
		[DateJoined] DATE NOT NULL
	)

END


GO

INSERT INTO ExamTable ([Name], Sales, DateJoined)
SELECT x.[Name], x.Sales, x.DateJoined
FROM (
	SELECT 'A' AS [Name], 14114 AS Sales, '01/22/2019' AS DateJoined UNION ALL 
	SELECT 'B', 41231, '03/02/2019' UNION ALL 
	SELECT 'C', 34674, '11/17/2017' UNION ALL 
	SELECT 'D', 61231, '07/13/2018' UNION ALL 
	SELECT 'E', 52856, '05/26/2019' UNION ALL 
	SELECT 'F', 61231, '06/21/2017' UNION ALL 
	SELECT 'G', 81728, '05/05/2017' UNION ALL 
	SELECT 'H', 34616, '10/18/2019' UNION ALL 
	SELECT 'I', 71926, '02/11/2018' UNION ALL 
	SELECT 'J', 52856, '02/11/2018' UNION ALL 
	SELECT 'K', 52856, '02/11/2018'
) x
WHERE NOT EXISTS (
	SELECT *
	FROM ExamTable a
	WHERE a.[Name] = x.[Name]
)

DECLARE @tmp TABLE (Sales INT, DiffToPrevRank INT)
INSERT INTO @tmp (Sales, DiffToPrevRank)
SELECT 
	Sales,
	ISNULL(LAG(Sales, 1) OVER (ORDER BY Sales DESC) - Sales, 0)
FROM ExamTable
GROUP BY Sales
ORDER BY Sales DESC

SELECT a.[Name], a.Sales, a.DateJoined, RANK () OVER ( ORDER BY a.Sales DESC) AS [Rank], t.DiffToPrevRank
FROM ExamTable a
	INNER JOIN @tmp t ON t.Sales = a.Sales
