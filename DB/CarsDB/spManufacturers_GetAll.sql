
CREATE PROCEDURE [dbo].[spManufacturers_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM dbo.Manufacturers;
END