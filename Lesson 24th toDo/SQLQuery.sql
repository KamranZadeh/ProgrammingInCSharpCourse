create database lesson24toDo
use lesson24toDo
drop table employees

create table departments(
Id int primary key identity(1,1),
Name nvarchar(50) not null,
CreatedDate datetime not null
)

ALTER TABLE departments
ADD CONSTRAINT dDF_Departments_CreatedDate
default getdate() for CreatedDate

create table Employees(
Id int primary key identity(1,1),
FirstName nvarchar(20) not null,
LastName nvarchar(20) not null,
EmploymentDate datetime,
DepartmentId int not null,
ManagerId int)

alter table Employees
add constraint FK_Employees_DepartmentId_Departments_Id
foreign key(DepartmentId)
references departments(Id)

alter table Employees
add constraint FK_Employees_ManagerId_Employees_Id
foreign key(ManagerId)
references Employees(Id)

select * from departments
select * from Employees

insert into departments(Name) values('IT')
insert into departments(Name) values('Sale')
insert into departments(Name) values('HR')

insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Nurlan', 'Valizade', '20140101', 1, null)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Kamran', 'Zadeh', '20150101', 1, 1)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Vasif', 'Badalov', '20160101', 2, 2)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Ilkin', 'Shahali', '20170101', 3, 3)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Shahali', 'Shahaliyev', '20180101', 1, 1)

select FirstName +' '+lastName, mName + ' ' mSurname, dName
from Employees
join Employees on

