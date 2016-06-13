USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetCustomerTransaction')
  DROP PROCEDURE GetCustomerTransaction
  GO

CREATE PROCEDURE dbo.GetCustomerTransaction
	@customerId int
AS
	DECLARE @innerCustomerId as int = @customerId
	
	SELECT t.CustomerId, t.EventId, t.Qty, t.Paid, t.Date, t.CreditCardNumber
	  FROM [dbo].[Transaction] t
	 WHERE t.CustomerId = @innerCustomerId
GO