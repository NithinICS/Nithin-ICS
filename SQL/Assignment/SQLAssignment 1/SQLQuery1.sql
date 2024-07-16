CREATE DATABASE SQLAssignment01;
USE SQLAssignment01;

CREATE TABLE Clients (
  Client_ID INT PRIMARY KEY,
  Cname VARCHAR(40) NOT NULL,
  Address VARCHAR(30),
  Email VARCHAR(30) UNIQUE,
  Phone VARCHAR(10),
  Business VARCHAR(20) NOT NULL
);

CREATE TABLE Departments (
  Deptno INT PRIMARY KEY,
  Dname VARCHAR(15) NOT NULL,
  Loc VARCHAR(20)
);

CREATE TABLE Employeees (
  Empno INT PRIMARY KEY,
  Ename VARCHAR(20) NOT NULL,
  Job VARCHAR(15),
  Salary DECIMAL(10, 2) CHECK (Salary > 0),
  Deptno INT,
  FOREIGN KEY (Deptno) REFERENCES Departments(Deptno)
);

CREATE TABLE Projectss (
  Project_ID INT PRIMARY KEY,
  Descr VARCHAR(30) NOT NULL,
  Start_Date DATE,
  Planned_End_Date DATE,
  Actual_End_date DATE,
  Budget DECIMAL(10, 2) CHECK (Budget > 0),
  Client_ID INT,
  FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID),
  CONSTRAINT CK_Actual_End_date CHECK (Actual_End_date > Planned_End_Date)
);

CREATE TABLE EmpProjectTasks (
  Project_ID INT,
  Empno INT,
  Start_Date DATE,
  End_Date DATE,
  Task VARCHAR(25) NOT NULL,
  Status VARCHAR(15) NOT NULL,
  PRIMARY KEY (Project_ID, Empno),
  FOREIGN KEY (Project_ID) REFERENCES Projectss(Project_ID),
  FOREIGN KEY (Empno) REFERENCES Employeees(Empno)
);

  INSERT INTO Clients (Client_ID, Cname, Address, Email, Phone, Business)
VALUES
  (1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', '9567880032', 'Manufacturing'),
  (1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', '8734210090', 'Consultant'),
  (1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', '7799886655', 'Reseller'),
  (1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', '9210342219', 'Professional');

  INSERT INTO Departments (Deptno, Dname, Loc)
VALUES
  (10, 'Design', 'Pune'),
  (20, 'Development', 'Pune'),
  (30, 'Testing', 'Mumbai'),
  (40, 'Document', 'Mumbai');

  INSERT INTO Employeees (Empno, Ename, Job, Salary, Deptno)
VALUES
  (7001, 'Sandeep', 'Analyst', 25000.00, 10),
  (7002, 'Rajesh', 'Designer', 30000.00, 10),
  (7003, 'Madhav', 'Developer', 40000.00, 20),
  (7004, 'Manoj', 'Developer', 40000.00, 20),
  (7005, 'Abhay', 'Designer', 35000.00, 10),
  (7006, 'Uma', 'Tester', 30000.00, 30),
  (7007, 'Gita', 'Tech. Writer', 30000.00, 40),
  (7008, 'Priya', 'Tester', 35000.00, 30),
  (7009, 'Nutan', 'Developer', 45000.00, 20),
  (7010, 'Smita', 'Analyst', 20000.00, 10),
  (7011, 'Anand', 'Project Mgr', 65000.00, 10);

  INSERT INTO Projectss (Project_ID, Descr, Start_Date, Planned_End_Date, Actual_End_date, Budget, Client_ID)
VALUES
  (401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000.00, 1001),
  (402, 'Accounting', '2011-08-01', '2012-01-01', NULL, 500000.00, 1002),
  (403, 'Payroll', '2011-10-01', '2011-12-31', NULL, 75000.00, 1003),
  (404, 'Contact Mgmt', '2011-11-01', '2011-12-31', NULL, 50000.00, 1004);

  INSERT INTO EmpProjectTasks (Project_ID, Empno, Start_Date, End_Date, Task, Status)
VALUES
  (401, 7001, '2011-04-01', '2011-04-20', 'Task1', 'In Progress');

  SELECT * FROM Clients;
  SELECT * FROM Departments;
  SELECT * FROM Employeees;
  SELECT * FROM Projectss;
  SELECT * FROM EmpProjectTasks;
