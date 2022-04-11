select * from OrderLine ol INNER JOIN Orders o on ol.Order_ID = o.Id WHERE o.Id = 6
Orderdate = @orderdate,Customer_ID=@CustomerId,TotalAmount=@Amount, OrderStatus = @OrderStatus