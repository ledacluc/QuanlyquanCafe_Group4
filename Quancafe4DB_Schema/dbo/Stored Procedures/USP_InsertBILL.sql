CREATE PROC USP_InsertBILL
@IdTable INT
AS
BEGIN
	INSERT dbo.BILL (DateCheckIn, DateCheckOut, IdTable, Status)
	VALUES (GETDATE(), NULL, @IdTable, 0)
END
GO