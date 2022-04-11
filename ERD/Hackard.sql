Drop table if exists Employees;
Drop table if exists Titles;
Drop table if exists Salary;
Drop table if exists Departement;
Drop table if exists Dept_period;
Drop Table if exists Dept_Manager;


Create table Employees(
	Emplo_no Int Not null,
	Birt_date date not null,
	First_name Varchar NOt Null,
	Last_Name VArchar Not null,
	Gender Char not null,
	Hired_date Date not null),
	Primary Key (Emplo_no ),
	Foreign Key (Hired_date) References Titles(Hired_date);
Select * from Employees;
	
Create table Titles(
	Emplo_no Int Not null,
	Title Varchar not null,
	Hired_date Date not null,
	Depart_date Date not null);
select * from Titles;

create table Salary(
	Emplo_no Int not null,
	Salary Int not null,
	Hired_date Date not null,
	Depart_date Date not null);
Select * from Salary;

create table Departement(
	Dept_no Varchar not null,
	Dept_name Varchar not null);
Select * from Departement;

create table Dept_period(
	Emplo_no Int not null,
	Dept_no Varchar not null,
	Hired_date Date not null,
	Depart_date Date not null);
select * from Dept_period;

create table Dept_Manager(
	Dept_no Varchar not null,
	Emplo_no Int not null,
	Hired_date Date not null,
	Depart_date Date not null);
select * from Dept_Manager;

--list of all employees Salary
Select Employees.Emplo_no,Employees.Last_name,Employees.First_name, Employees.gender, Salary.Salary
From Employees
INNER JOIN Salary
ON Employees.Emplo_no = Salary.Emplo_no;

-- Employees hired in 1986
select Emplo_no,Last_name, First_name, Hired_date
From Employees
WHERE Hired_date >= CAST('1986-01-01' AS DATE)
AND Hired_date <= CAST('1986-12-30' AS DATE);

--List of Departement Manager

Select DP.Dept_no,DP.Dept_name, 
		DM.Emplo_no, DM.Hired_date,DM.Depart_date,
		Em.Last_name,Em.First_name  
From Dept_Manager as DM
JOIN Departement as DP 
on DM.Dept_no = DP.Dept_no
JOIN Employees as EM
ON DM.Emplo_no = EM.Emplo_no;
		
-- List of Employees departement

Select Em.Emplo_no, Em.Last_name, Em.First_name, DP.Dept_name
From Employees as EM
JOIN Dept_Manager as DM on EM.Emplo_no = DM.Emplo_no
JOIN Departement as DP ON DM.Dept_no = DP.Dept_no;
	
-- Employees with "Hercule as First name" and "Last name begin with B"
Select First_name,Last_name 
From Employees
Where First_name = 'Hercules'
And Last_name like 'B%';

-- Employees from Sale Dapartement
Select Em.Emplo_no, Em.Last_name, Em.First_name, DP.Dept_name
from Employees as EM 
JOIN Dept_Manager as DM ON Em.Emplo_no = DM.Emplo_no 
JOIN Departement as DP ON DM.Dept_no = DP.Dept_no 
Where DP.Dept_name in ('Sales','Development'); 
 
-- descending order of employees  grouped by Last names

SELECT Last_name, COUNT(Last_name) AS "Employees frequency"
FROM Employees
GROUP BY Last_name
ORDER BY "Employees frequency" DESC;


	