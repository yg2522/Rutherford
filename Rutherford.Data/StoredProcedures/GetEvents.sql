USE Rutherford
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetEvents')
  DROP PROCEDURE GetEvents
  GO

CREATE PROCEDURE dbo.GetEvents
AS
	SELECT e.EventId, e.Name, e.Date, e.Location, e.Price, e.TotalTickets, e.Notes
	  FROM [dbo].[Event] e
GO