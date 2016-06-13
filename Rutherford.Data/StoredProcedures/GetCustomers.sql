USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetCustomers')
  DROP PROCEDURE GetCustomers
  GO

CREATE PROCEDURE dbo.GetCustomers
AS
	SELECT c.CustomerId, c.Name
	  FROM dbo.Customer c
GO