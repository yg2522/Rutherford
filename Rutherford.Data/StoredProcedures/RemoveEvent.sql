USE Rutherford
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