USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetTransactions')
  DROP PROCEDURE GetTransactions
  GO

CREATE PROCEDURE dbo.GetTransactions
AS
	SELECT t.CustomerId, t.EventId, t.Qty, t.Paid, t.Date, t.CreditCardNumber
	  FROM [dbo].[Transaction] t
GO