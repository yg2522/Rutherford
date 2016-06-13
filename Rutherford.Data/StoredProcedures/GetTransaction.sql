USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetTransaction')
  DROP PROCEDURE GetTransaction
  GO

CREATE PROCEDURE dbo.GetTransaction
	@customerId int,
	@eventId int
AS
	DECLARE @innerCustomerId as int = @customerId
	DECLARE @innerEventId as int = @eventId
	
	SELECT t.CustomerId, t.EventId, t.Qty, t.Paid, t.Date, t.CreditCardNumber
	  FROM [dbo].[Transaction] t
	 WHERE t.CustomerId = @innerCustomerId AND t.EventId = @innerEventId
GO