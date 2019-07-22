CREATE PROCEDURE [dbo].ActivatePhoneNumber

@customerid int, @phoneNumber int
AS
	Update CustomerPhone
	set phoneStatus ='A' where customerId= @customerid and PhoneNumber =@phoneNumber
RETURN 0