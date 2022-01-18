create database lesson24toDo
go
use lesson24toDo

--Create 2 tables
--1.Departments (Id(int), Name(nvarchar(50) not null), CreatedDate(datetime) not null default getdate())
--2.Employees (Id(int), FirstName(nvarchar(20) not null), LastName(nvarchar(20) not null), EmploymentDate (datetime), 
--DepartmentId(int foreign key not null), ManagerId int self foreign key))


create table Departments(
Id int primary key identity(1,1),
Name nvarchar(50) not null,
CreatedDate datetime  not null constraint DF_Departments_CreatedDate  default getdate()
)

create table Employees(
Id int primary key identity(1,1),
FirstName nvarchar(20) not null,
LastName nvarchar(20) not null,
EmploymentDate datetime,
DepartmentId int constraint FK_Employees_DepartmentId_Departments_Id 
foreign key(DepartmentId) 
references Departments(Id)
on delete no action
on update no action
)

alter table Employees
add ManagerId int

alter table Employees
add constraint FK_Employees_ManagerId_Employees_Id
foreign key (ManagerId)
references Employees(Id)
on delete no action
on update no action

insert into departments(Name) values('IT')
insert into departments(Name) values('Sale')
insert into departments(Name) values('HR')

insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Nurlan', 'Valizade', '20140101', 1, null)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Kamran', 'Zadeh', '20150101', 1, 1)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Vasif', 'Badalov', '20160101', 2, 2)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Ilkin', 'Shahali', '20170101', 3, 3)
insert into Employees(FirstName, LastName, EmploymentDate, DepartmentId, ManagerId) values('Shahali', 'Shahaliyev', '20180101', 1, 1)

--Write a query to return EmployeeFirstName, EmployeeLastName, ManagerFirstName, ManagerLastName, DepartmentName result
	 
select e.FirstName, e.LastName,  m.FirstName + ' '+ m.LastName as Superior, d.Name as DepartmentName from Employees e
left join Employees m on m.Id = e.ManagerId
join departments d on e.DepartmentId = d.Id
