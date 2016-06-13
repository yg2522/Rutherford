USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetCustomer')
  DROP PROCEDURE GetCustomer
  GO

CREATE PROCEDURE dbo.GetCustomer
	@customerId int
AS
	DECLARE @innerId as int = @customerId
	
	SELECT c.CustomerId, c.Name
	  FROM dbo.Customer c
	 WHERE c.CustomerId = @innerId
GO