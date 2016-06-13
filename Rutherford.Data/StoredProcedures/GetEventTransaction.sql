USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetEventTransaction')
  DROP PROCEDURE GetEventTransaction
  GO

CREATE PROCEDURE dbo.GetEventTransaction
	@eventId int
AS
	DECLARE @innerEventId as int = @eventId
	
	SELECT t.CustomerId, t.EventId, t.Qty, t.Paid, t.Date, t.CreditCardNumber
	  FROM [dbo].[Transaction] t
	 WHERE t.EventId = @innerEventId
GO