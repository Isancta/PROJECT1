USE [DEPOT]
GO

INSERT INTO [dbo].[ORDERLINE]([Order_ID],[Product_ID],[Quantity])VALUES(@Order_ID,@Product_ID,@Quantity)
GO

insert into OrdeLine values(@Order_ID,@Product_ID,@Quantity
