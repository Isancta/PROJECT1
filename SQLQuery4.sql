USE [DEPOT]
GO

INSERT INTO [dbo].[CUSTOMER]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Phone]
           ,[Address1]
           ,[Address2])
     VALUES
           ('Elisya',
           'Isimbi',
           'isimbi.sancta@example.com',
           '999-999-9999',
           'Test Address 1',
           'Test Address 2')
GO


