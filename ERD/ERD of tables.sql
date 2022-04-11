CREATE TABLE Employees (
   Emplo_no Int   NOT NULL Primary key,
   Birt_date date   NOT NULL,
   First_name Varchar,   NOT NULL,
   Last_Name VArchar   NOT NULL,
   Gender Char   NOT NULL,
   Hired_date Date   NOT NULL
);

CREATE TABLE Titles (
    Emplo_no Int   NOT NULL Foreign Key ,
    Title Varchar   NOT NULL,
    Hired_date Date   NOT NULL,
    Depart_date Date   NOT NULL
);

CREATE TABLE Salary (
    Emplo_no Int   NOT NULL Foreign Key,
    Salary Int   NOT NULL,
    Hired_date Date   NOT NULL,
    Depart_date Date   NOT NULL
);

CREATE TABLE Departement(
    Dept_no Varchar   NOT NULL Foreign Key,
    Dept_name Varchar   NOT NULL
);

CREATE TABLE Dept_period (
    Emplo_no Int   NOT NULL Foreign key,
    Dept_no Varchar   NOT NULL,
    Hired_date Date   NOT NULL
);

CREATE TABLE Dept_Manager (
    Dept_no Varchar   NOT NULL Primary key,
    Emplo_no Int   NOT NULL Foreign key,
    Hired_date Date   NOT NULL,
    Depart_date Date   NOT NULL
);

ALTER TABLE Titles ADD CONSTRAINT fk_Titles_Emplo_no FOREIGN KEY(Emplo_no)
REFERENCES Employees (Emplo_no);

ALTER TABLE Salary ADD CONSTRAINT fk_Salary_Emplo_no FOREIGN KEY(Emplo_no)
REFERENCES Employees (Emplo_no);

ALTER TABLE Departement ADD CONSTRAINT fk_Departement_Dept_no FOREIGN KEY(Dept_no)
REFERENCES Dept_Manager (Dept_no);

ALTER TABLE Dept_period ADD CONSTRAINT fk_Dept_period_Emplo_no FOREIGN KEY(Emplo_no)
REFERENCES Employees (Emplo_no);

ALTER TABLE Dept_Manager ADD CONSTRAINT fk_Dept_Manager_Dept_no FOREIGN KEY(Dept_no)
REFERENCES Employees (Emplo_no);
