create database EmployeeManagementDB;
go

use EmployeeManagementDB;
go

create table Employee_Details (
    EmpNo int primary key identity(1,1),
    EmpName varchar(50) not null,
    EmpSal numeric(10,2) check (EmpSal >= 25000),
    EmpType char(1) check (EmpType in ('F', 'P'))
);
go

create procedure InsertEmployee
    @EmpName varchar(50),
    @EmpSal numeric(10,2),
    @EmpType char(1)
as
begin
    set nocount on;
 
    insert into Employee_Details (EmpName, EmpSal, EmpType)
    output inserted.EmpNo
    values (@EmpName, @EmpSal, @EmpType);
end;
go

