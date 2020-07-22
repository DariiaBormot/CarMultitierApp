
CREATE PROCEDURE [dbo].[spManufacturers_Update]
@name nvarchar(50),
@id int

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Manufacturers 
	SET Name = @name
	WHERE Id = @id
END