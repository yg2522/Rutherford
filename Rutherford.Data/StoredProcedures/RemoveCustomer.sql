USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RemoveCustomer')
  DROP PROCEDURE RemoveCustomer
  GO

CREATE PROCEDURE dbo.RemoveCustomer
	@customerId int
AS
	DECLARE @innerId as int = @customerId
	
	DELETE FROM dbo.Customer
	     OUTPUT deleted.CustomerId, deleted.Name
	      WHERE CustomerId = @innerId
GO