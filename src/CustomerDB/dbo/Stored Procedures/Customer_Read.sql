
CREATE PROC Customer_Read
    @CustomerId int
AS 
BEGIN 
    SELECT * FROM Customers WHERE (CustomerId = @CustomerId) 
END