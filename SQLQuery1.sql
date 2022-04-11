Create database
select* from Logs

DROP TABLE Authentification
DROP TABLE Product
DROP TABLE ShopLocation
DROP TABLE Customer
DROP TABLE OrderLine
DROP TABLE Orders
DROP TABLE OrderStatus

Create table Authentification(
  username varchar(20),
  password Varchar(20),
  Role int 

)

CREATE TABLE CUSTOMER(
    Id int not null primary key IDENTITY(1,1),
	FirstName varchar (20) not null,
	LastName varchar (20) not null,
	Email varchar (50) not null,
	Phone varchar (20),
	Address1 varchar (200),
	Address2 varchar (20),
	
)
 
 
CREATE TABLE PRODUCT(
     
	 Id int not null primary key IDENTITY(1,1),
	 ProductName varchar(200) not null,
	 ProductDescpr varchar(200) not null,
	 Category varchar(200),
	 Price float not null,
	 QuantityInStock int not null,
	   	  
)
 

CREATE TABLE ShopLocation(
  Id int not null primary key IDENTITY(1,1),
  Name varchar(20) not null,
  Address1 varchar (200)not null,
  Adrress2 varchar (20),
  ZipCode varchar (20),
  City varchar (20) not null,
  Country varchar (20) not null

)


CREATE TABLE ORDERLINE(

Id int not null primary key IDENTITY(1,1),
Order_ID int not null,
Product_ID int not null,
Quantity int not null,
Foreign key(Order_ID) references Orders(Id),
Foreign key(Product_ID) references Product(Id)
)


CREATE TABLE ORDERS(
 
 Id int not null primary key IDENTITY(1,1),
 Orderdate datetimeoffset not null,
 Customer_ID int not null,
 TotalAmount float not null,
 OrderStatus varchar(20) not null,
 Foreign key(Customer_ID) references Customer(Id)

)

GO 

Create function GetTheDate


Go

Create procedure Totalamout
as
begin
     @totalamount = 
end
go 






