
CREATE PROC Address_Read
    @AddressId int
AS 
BEGIN 
    SELECT * FROM Addresses WHERE (AddressId = @AddressId) 
END