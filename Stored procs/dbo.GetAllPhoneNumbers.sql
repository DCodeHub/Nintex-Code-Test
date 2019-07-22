CREATE PROCEDURE [dbo].[GetAllPhoneNumbers]
	
AS
	SELECT c.CustomerName,p.PhoneNumber, p.phoneStatus from CustomerPhone p
	inner join Customer c on p.customerId = c.CustomerId
RETURN 0