
CREATE PROCEDURE [dbo].[spManufacturers_GetById]
@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM dbo.Manufacturers
	WHERE id = @id
END