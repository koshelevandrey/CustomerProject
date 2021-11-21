
CREATE PROC Address_Update
    @AddressId int,
    @Line NVARCHAR(100),
	@Line2 NVARCHAR(100),
	@AddressType NVARCHAR(8),
	@City NVARCHAR(50),
	@PostalCode NVARCHAR(6),
	@AddressState NVARCHAR(20),
	@Country NVARCHAR(14)
AS 
BEGIN 
UPDATE Addresses
SET  Line = @Line,
     Line2 = @Line2,
	 AddressType = @AddressType,
     City = @City,
     PostalCode = @PostalCode,
	 AddressState = @AddressState,
	 Country = @Country
WHERE  AddressId = @AddressId
END