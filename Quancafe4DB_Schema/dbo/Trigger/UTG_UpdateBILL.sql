CREATE TRIGGER UTG_UpdateBILL
ON dbo.BILL FOR UPDATE
AS
BEGIN
	DECLARE @idBILL INT
	SELECT @idBILL = Id FROM inserted
	DECLARE @IdTable INT
	SELECT @IdTable = IdTable FROM dbo.BILL WHERE Id = @idBILL 
	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.BILL WHERE Id = @IdTable AND Status = 0

	IF(@count = 0)
		UPDATE dbo.TableFood SET Status = N'TRONG' WHERE Id = @IdTable
END
GO