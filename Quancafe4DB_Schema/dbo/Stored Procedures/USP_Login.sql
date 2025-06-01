create proc USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
as
begin
		select *from dbo.Account where UserName = @userName and Password = @passWord
end
go