USE Rutherford
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