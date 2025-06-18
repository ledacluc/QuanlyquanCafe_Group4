CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.Billinfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBILL INT
	SELECT @idBILL = IdBILL FROM inserted
	DECLARE @IdTable INT
	SELECT @IdTable = IdTable FROM dbo.BILL WHERE Id = @idBILL AND Status = 0

	UPDATE dbo.TableFood SET Status = N'Co nguoi' WHERE Id = @IdTable
END
GO