USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateCustomer')
  DROP PROCEDURE UpdateCustomer
  GO

CREATE PROCEDURE dbo.UpdateCustomer
	@customerId int,
	@name nvarchar(255)
AS
	DECLARE @innerId as int = @customerId
	DECLARE @innername as nvarchar(255) = @name
	
	UPDATE dbo.Customer 
	   SET Name = @innername
	OUTPUT inserted.CustomerId, inserted.Name
	 WHERE CustomerId = @innerId
GO