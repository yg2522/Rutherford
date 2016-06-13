USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetTotalPurchasedEventTickets')
  DROP PROCEDURE GetTotalPurchasedEventTickets
  GO

CREATE PROCEDURE dbo.GetTotalPurchasedEventTickets
	@eventId int
AS
BEGIN
	DECLARE @innerEventId as int = @eventId
	
	SELECT ISNULL(SUM(t.Qty), 0) as Total
	  FROM [dbo].[Transaction] t
	 WHERE t.EventId = @innerEventId
END;
GO