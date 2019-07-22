CREATE PROCEDURE [dbo].[Procedure]
	@customerId int 

AS
	SELECT * from CustomerPhone where customerId= @customerId
RETURN 0