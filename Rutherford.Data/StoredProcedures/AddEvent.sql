USE Rutherford
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