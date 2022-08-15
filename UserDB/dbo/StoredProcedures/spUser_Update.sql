CREATE PROCEDURE [dbo].[spUser_Update]
    @Id int,
	@Firstname nvarchar(50),
	@Lastname nvarchar(50)
AS
begin
	update dbo.[User] set LastName = @Lastname , FirstName = @Firstname where Id =@Id
	end