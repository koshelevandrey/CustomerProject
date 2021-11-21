
CREATE PROCEDURE Customer_Create
	   @FirstName NVARCHAR(50),
	   @LastName NVARCHAR(50),
	   @PhoneNumber NVARCHAR(16),
	   @Email NVARCHAR(100),
	   @Notes NVARCHAR(MAX),
	   @TotalPurchasesAmount MONEY
AS
BEGIN
INSERT INTO Customers(FirstName, LastName, PhoneNumber, Email, Notes, TotalPurchasesAmount)
VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Notes, @TotalPurchasesAmount)
END