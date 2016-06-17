USE Rutherford
GO
--add tables
CREATE TABLE [dbo].[Customer]
(
	[CustomerId] int IDENTITY(1,1),
	[Name] nvarchar(255),
	CONSTRAINT PK_Customer PRIMARY KEY CLUSTERED ([CustomerId])
)
GO
CREATE TABLE [dbo].[Event]
(
	[EventId] int IDENTITY(1,1),
	[Name] nvarchar(500) NOT NULL,
	[Date] datetime,
	[Location] nvarchar(500),
	[Price] decimal(18,2) NOT NULL,
	[TotalTickets] int NOT NULL,
	[Notes] nvarchar(4000),
	CONSTRAINT PK_Event PRIMARY KEY CLUSTERED ([EventId]),
)
GO
ALTER TABLE [dbo].[Event]
	ADD CONSTRAINT DF_Event_Price DEFAULT 0.00 FOR [Price]
GO
ALTER TABLE [dbo].[Event]
	ADD CONSTRAINT DF_Event_TotalTickets DEFAULT 0 FOR [TotalTickets]
GO
CREATE TABLE [dbo].[Transaction]
(
	[CustomerId] int NOT NULL,
	[EventId] int NOT NULL,
	[Qty] int NOT NULL,
	[Paid] decimal(18,2),
	[Date] datetime,
	[CreditCardNumber] numeric(16,0),
	CONSTRAINT PK_TransactionHistory PRIMARY KEY CLUSTERED ([CustomerId], [EventId]),
	CONSTRAINT FK_TransactionHistory_Customer FOREIGN KEY ([CustomerId])
		REFERENCES [dbo].[Customer] ([CustomerId])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT FK_TransactionHistory_Event FOREIGN KEY ([EventId])
		REFERENCES [dbo].[Event] ([EventId])
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
GO
ALTER TABLE [dbo].[Transaction]
	ADD CONSTRAINT DF_Transaction_Qty DEFAULT 0 FOR [Qty]
GO

--add stored procedures
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddEvent')
  DROP PROCEDURE AddEvent
  GO

CREATE PROCEDURE dbo.AddEvent
	@name nvarchar(500),
	@date datetime,
	@location nvarchar(500),
	@price decimal(18,2),
	@totalTickets int,
	@notes nvarchar(4000)
AS
	DECLARE @innername as nvarchar(255) = @name
	DECLARE @innerDate as datetime = @date
	DECLARE @innerLocation as nvarchar(500) = @location
	DECLARE @innerPrice as decimal(18,2) = @price
	DECLARE @innerTotalTickets as int = @totalTickets
	DECLARE @innerNotes as nvarchar(4000) = @notes
	
	INSERT INTO [dbo].[Event] (Name, Date, Location, Price, TotalTickets, Notes)
	     OUTPUT inserted.EventId, inserted.Name, inserted.Date, inserted.Location, inserted.Price, inserted.TotalTickets, inserted.Notes
		 VALUES (@innername, @innerDate, @innerLocation, @innerPrice, @innerTotalTickets, @innerNotes)
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetCustomers')
  DROP PROCEDURE GetCustomers
  GO

CREATE PROCEDURE dbo.GetCustomers
AS
	SELECT c.CustomerId, c.Name
	  FROM dbo.Customer c
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetEvent')
  DROP PROCEDURE GetEvent
  GO

CREATE PROCEDURE dbo.GetEvent
	@eventId int
AS
	DECLARE @innerId as int = @eventId
	
	SELECT e.EventId, e.Name, e.Date, e.Location, e.Price, e.TotalTickets, e.Notes
	  FROM [dbo].[Event] e
	 WHERE e.EventId = @innerId
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetEvents')
  DROP PROCEDURE GetEvents
  GO

CREATE PROCEDURE dbo.GetEvents
AS
	SELECT e.EventId, e.Name, e.Date, e.Location, e.Price, e.TotalTickets, e.Notes
	  FROM [dbo].[Event] e
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetTotalPurchasedEventTickets')
  DROP PROCEDURE GetTotalPurchasedEventTickets
  GO

CREATE PROCEDURE dbo.GetTotalPurchasedEventTickets
	@eventId int
AS
BEGIN
	DECLARE @innerEventId as int = @eventId
	
	SELECT ISNULL(SUM(t.Qty), 0) as Total
	  FROM [dbo].[Transaction] t
	 WHERE t.EventId = @innerEventId
END;
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetTransactions')
  DROP PROCEDURE GetTransactions
  GO

CREATE PROCEDURE dbo.GetTransactions
AS
	SELECT t.CustomerId, t.EventId, t.Qty, t.Paid, t.Date, t.CreditCardNumber
	  FROM [dbo].[Transaction] t
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RemoveEvent')
  DROP PROCEDURE RemoveEvent
  GO

CREATE PROCEDURE dbo.RemoveEvent
	@eventId int
AS
	DECLARE @innerId as int = @eventId
	
	DELETE FROM [dbo].[Event]
	     OUTPUT deleted.EventId, deleted.Name, deleted.Date, deleted.Location, deleted.Price, deleted.TotalTickets, deleted.Notes
	      WHERE EventId = @innerId
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateEvent')
  DROP PROCEDURE UpdateEvent
  GO

CREATE PROCEDURE dbo.UpdateEvent
	@eventId int,
	@name nvarchar(255),
	@date datetime,
	@location nvarchar(500),
	@price decimal(18,2),
	@totalTickets int,
	@notes nvarchar(4000)
AS
	DECLARE @innerId as int = @eventId
	DECLARE @innername as nvarchar(255) = @name
	DECLARE @innerDate as datetime = @date
	DECLARE @innerLocation as nvarchar(500) = @location
	DECLARE @innerPrice as decimal(18,2) = @price
	DECLARE @innerTotalTickets as int = @totalTickets
	DECLARE @innerNotes as nvarchar(4000) = @notes
	
	UPDATE [dbo].[Event] 
	   SET Name = @innername, Date = @innerDate, Location = @innerLocation, Price = @innerPrice, TotalTickets = @innerTotalTickets, Notes = @innerNotes
	OUTPUT inserted.EventId, inserted.Name, inserted.Date, inserted.Location, inserted.Price, inserted.TotalTickets, inserted.Notes
	 WHERE EventId = @innerId
GO