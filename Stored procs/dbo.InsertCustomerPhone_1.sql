CREATE PROCEDURE [dbo].InsertCustomerPhone
	@customerName varchar(50),@customerAddress varchar(200),
	@phoneNumer int, @status char(1),@Desc as varchar(100)
AS
	Declare @id as int =  ( select max(customerId) from CustomerPhone)


	Insert into Customer values(@id,@customerName,@customerAddress)

	Insert into CustomerPhone values(@id,@phoneNumer,@status,@Desc)

RETURN 0