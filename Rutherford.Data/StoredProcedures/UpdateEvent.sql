USE Rutherford
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