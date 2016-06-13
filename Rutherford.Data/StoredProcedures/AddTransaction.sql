USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddTransaction')
  DROP PROCEDURE AddTransaction
  GO

CREATE PROCEDURE dbo.AddTransaction
	@customerId int,
	@eventId int,
	@qty int,
	@paid decimal(18,2),
	@date datetime,
	@ccNumber numeric(16,0)
AS
	DECLARE @innerCustomerId as int = @customerId
	DECLARE @innerEventId as int = @eventId
	DECLARE @innerQty as int = @qty
	DECLARE @innerPaid as decimal(18,2) = @paid
	DECLARE @innerDate as datetime = @date
	DECLARE @innerCcNumber as numeric(16,0) = @ccNumber
	
	INSERT INTO [dbo].[Transaction] (CustomerId, EventId, Qty, Paid, Date, CreditCardNumber)
	     OUTPUT inserted.CustomerId, inserted.EventId, inserted.Qty, inserted.Paid, inserted.Date, inserted.CreditCardNumber
		 VALUES (@innerCustomerId, @innerEventId, @innerQty, @innerPaid, @innerDate, @innerCcNumber)
GO