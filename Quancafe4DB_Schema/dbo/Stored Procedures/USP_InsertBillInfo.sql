CREATE PROC USP_InsertBillInfo
@IdBILL INT, @IdFood INT, @count INT
AS
BEGIN
	DECLARE @IsExistBillInfo INT
	DECLARE @Foodcount INT = 1
	SELECT @IsExistBillInfo = Id, @Foodcount = b.count 
	FROM dbo.Billinfo AS b WHERE IdBILL = @IdBILL AND IdFood = @IdFood

	IF(@IsExistBillInfo > 0)
	BEGIN
		DECLARE @NewCount INT = @FoodCount + @count
		IF (@NewCount > 0)
			UPDATE dbo.Billinfo SET count = @Foodcount + @count WHERE IdFood = @IdFood
		ELSE
			DELETE dbo.Billinfo WHERE IdBILL = @IdBILL AND IdFood = @IdFood
	END
	ELSE
		INSERT dbo.Billinfo(IdBILL, IdFood, count)
		VALUES (@IdBILL, @IdFood, @count)
END
GO