create database SQLCC1

-- 4.Create table Employee with empno, ename, sal, doj columns and perform the following operations in a single transaction 	
create table Employee (
empno int primary key,
ename varchar(100),
sal decimal(10, 2),
doj date
);

--a. First insert 3 rows

insert into Employee (empno,ename,sal,doj) values (1,'Nithin', 5000, '2024-04-12');
insert into Employee (empno,ename,sal,doj) values (2,'Raghav', 6000, '2024-04-13');
insert into Employee (empno,ename,sal,doj) values (3,'Raghu', 7000, '2024-04-14');
insert into Employee (empno,ename,sal,doj) values (4,'gurukiran',5000,'2024-04-15');

select * from Employee

begin transaction 

--b. Update the second row sal with 15% increment 
--c. Delete first row. After completing above all actions how to recall the deleted row without losing increment of second row.

update employee
set sal = sal*1.15
where empno=2;

create table  DeletedEmployees (
empno int,
ename varchar(100),
sal decimal(10, 2),
doj date
);

insert into DeletedEmployees (empno,ename,sal,doj)
select empno,ename,sal,doj
from Employee
where empno=1

delete from employee where empno=1;

commit;

select * from DeletedEmployees
select * from Employee

alter table employee add deptno int
select*from Employee

insert into Employee (empno,ename,sal,doj,deptno) VALUES (1,'Nithin',5000,'2024-04-12',10);
insert into Employee (empno,ename,sal,doj,deptno) VALUES (2,'Raghav',6000,'2024-04-13',11);
insert into Employee (empno,ename,sal,doj,deptno) VALUES (3,'Raghu',7000,'2024-04-14',12);
insert into Employee (empno,ename,sal,doj,deptno) VALUES (4,'Gurukiran',5000,'2024-04-15',13);


update Employee set deptno = 10 where empno = 1;
update Employee set deptno = 20 where empno = 2; 
update Employee set deptno = 30 where empno = 3;  
update Employee set deptno = 10 where empno = 4; 


create function BonusCalculator(@emp_deptno INT, @emp_sal DECIMAL(10, 2))
returns decimal(10, 2)
as
begin

declare @bonus decimal(10, 2);
if @emp_deptno = 10
set @bonus = @emp_sal * 0.15;
else if @emp_deptno = 20
set @bonus = @emp_sal * 0.20;
else
set @bonus = @emp_sal * 0.05;
return @bonus;
end

SELECT empno,ename,sal,deptno, BonusCalculator(deptno, sal) as bonus
FROM Employee; 

select*from Employee

--3.	Write a query to display all employees information those who joined before 5 years in the current month

select * from Employee
where doj < dateadd(year, -5, getdate())
  AND month(doj) = month(getdate())
  AND year(doj) = year(getdate());


alter table employee add Dob date

select*from Employee

update Employee
set dob = '1990-04-12'
where empno = 1; 
update Employee
set dob = '1992-05-15'
where empno = 2;
update Employee
set dob = '1988-08-20'
where empno = 3;  
update Employee
set dob = '1995-03-30'
where empno = 4;  

select * from Employee

--2: Display your age in days

declare @birthday date = '1995-03-30';
select datediff(day, @birthday, getdate()) AS Age_In_Days;