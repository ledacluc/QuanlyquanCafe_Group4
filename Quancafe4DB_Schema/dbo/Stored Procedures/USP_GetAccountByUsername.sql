CREATE PROC USP_GetAccountByUsername
@userName NVARCHAR(100)
AS
BEGIN 
    SELECT * FROM dbo.Account WHERE UserName = @userName
END
