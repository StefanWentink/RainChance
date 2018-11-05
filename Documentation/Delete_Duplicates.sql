USE [RainChance]
GO

DELETE FROM [dbo].[HourPrediction]
WHERE [DayPredictionId] in
(
	SELECT TOP 1 [Id] FROM [dbo].[DayPrediction]
	WHERE [Time] in
	(
		SELECT [Time]
		  FROM [dbo].[DayPrediction]
		GROUP BY [Time]
		HAVING Count(*) > 1
	)
)

DELETE FROM [dbo].[DayPrediction]
WHERE [Id] in
(
	SELECT TOP 1 [Id] FROM [dbo].[DayPrediction]
	WHERE [Time] in
	(
		SELECT [Time]
		  FROM [dbo].[DayPrediction]
		GROUP BY [Time]
		HAVING Count(*) > 1
	)
)

