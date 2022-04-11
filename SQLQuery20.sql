declare @OrderId int = 1;

select * from OrderLine ol INNER JOIN Orders o on ol.Product_ID = o.Id WHERE o.Id = @OrderId

