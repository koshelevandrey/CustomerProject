
CREATE PROCEDURE Address_Create
	   @CustomerId INT,
	   @Line NVARCHAR(100),
	   @Line2 NVARCHAR(100),
	   @AddressType NVARCHAR(8),
	   @City NVARCHAR(50),
	   @PostalCode NVARCHAR(6),
	   @AddressState NVARCHAR(20),
	   @Country NVARCHAR(14)
AS
BEGIN
INSERT INTO Addresses (CustomerId, Line, Line2, AddressType, City, PostalCode, AddressState, Country)
VALUES
(@CustomerId, @Line, @Line2, @AddressType, @City, @PostalCode, @AddressState, @Country)
END