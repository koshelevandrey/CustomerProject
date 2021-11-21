
CREATE PROC Customer_Update
    @CustomerId int,
    @FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber NVARCHAR(16),
	@Email NVARCHAR(100),
	@Notes NVARCHAR(MAX),
	@TotalPurchasesAmount MONEY
AS 
BEGIN 
UPDATE Customers
SET  FirstName = @FirstName,
     LastName = @LastName,
	 PhoneNumber = @PhoneNumber,
     Email = @Email,
     Notes = @Notes,
	 TotalPurchasesAmount = @TotalPurchasesAmount
WHERE  CustomerId = @CustomerId
END