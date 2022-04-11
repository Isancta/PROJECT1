USE [DEPOT]
GO

INSERT INTO [dbo].[PRODUCT]
           ([ProductName]
           ,[ProductDescpr]
           ,[Category]
           ,[Price]
           ,[QuantityInStock])
     VALUES
           ('curry'
           ,'organic'
           ,'spices'
           ,16.99
           ,175)
GO
select * from product



