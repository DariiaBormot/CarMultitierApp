
CREATE PROCEDURE [dbo].[spManufacturers_Insert]
	@name nvarchar(50)
AS
BEGIN
	INSERT INTO Manufacturers(Name) 
	VALUES ( @name )
END