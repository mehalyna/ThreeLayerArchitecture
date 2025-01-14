CREATE PROCEDURE GetOrdersByCustomerId
    @CustomerId INT
AS
BEGIN
    SELECT o.OrderId, o.OrderDate, o.TotalAmount
    FROM Orders o
    WHERE o.CustomerId = @CustomerId;
END;
GO

CREATE PROCEDURE AddNewProduct
    @Name NVARCHAR(100),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products (Name, Price)
    VALUES (@Name, @Price);
END;
GO

CREATE PROCEDURE UpdateProductPrice
    @ProductId INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET Price = @Price
    WHERE ProductId = @ProductId;
END;
GO

CREATE PROCEDURE DeleteOrder
    @OrderId INT
AS
BEGIN
    DELETE FROM Orders
    WHERE OrderId = @OrderId;
END;
GO

CREATE PROCEDURE GetOrderDetails
    @OrderId INT
AS
BEGIN
    SELECT od.OrderDetailId, p.Name AS ProductName, od.Quantity, p.Price
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductId = p.ProductId
    WHERE od.OrderId = @OrderId;
END;
GO