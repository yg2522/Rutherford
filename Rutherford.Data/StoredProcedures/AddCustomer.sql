USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddCustomer')
  DROP PROCEDURE AddCustomer
  GO

CREATE PROCEDURE dbo.AddCustomer
	@name nvarchar(255)
AS
	DECLARE @innername as nvarchar(255) = @name
	DECLARE @customerId as int
	
	INSERT INTO dbo.Customer (Name)
	OUTPUT inserted.CustomerId, inserted.Name
		 VALUES (@innername)
GO