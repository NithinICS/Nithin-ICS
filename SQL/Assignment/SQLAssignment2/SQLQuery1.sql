CREATE DATABASE SQLAssignment2;

USE SQLAssignment2;


CREATE TABLE EMP (
  EMPNO INT,
  ENAME VARCHAR(255),
  JOB VARCHAR(255),
  MGR_ID INT,
  HIREDATE DATE,
  SAL DECIMAL(10, 2),
  COMM DECIMAL(10, 2),
  DEPTNO INT
);

CREATE TABLE DEPT (
  DEPTNO INT,
  DNAME VARCHAR(255),
  LOC VARCHAR(255)
);

-- Insert data into the EMP and DEPT tables
INSERT INTO EMP (EMPNO, ENAME, JOB, MGR_ID, HIREDATE, SAL, COMM, DEPTNO)
VALUES
  (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800.00, 0.00, 20),
  (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600.00, 300.00, 30),
  (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250.00, 500.00, 30),
  (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975.00, 0.00, 20),
  (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250.00, 1400.00, 30),
  (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850.00, 0.00, 30),
  (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450.00, 0.00, 10),
  (7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000.00, 0.00, 20),
  (7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000.00, 0.00, 10),
  (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500.00, 0.00, 30),
  (7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100.00, 0.00, 20),
  (7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950.00, 0.00, 30),
  (7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000.00, 0.00, 20),
  (7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300.00, 0.00, 10);

INSERT INTO DEPT (DEPTNO, DNAME, LOC)
VALUES
  (10, 'ACCOUNTING', 'NEW YORK'),
  (20, 'RESEARCH', 'DALLAS'),
  (30, 'SALES', 'CHICAGO'),
  (40, 'OPERATIONS', 'BOSTON');

-- Task 1: List all employees whose name begins with 'A'
SELECT * FROM EMP WHERE ENAME LIKE 'A%';

-- Task 2: Select all those employees who don't have a manager
SELECT * FROM EMP WHERE MGR_ID IS NULL;

-- Task 3: List employee name, number, and salary for those employees who earn in the range 1200 to 1400
SELECT ENAME, EMPNO, SAL FROM EMP WHERE SAL BETWEEN 1200.00 AND 1400.00;

-- Task 4: Give all the employees in the RESEARCH department a 10% pay rise
SELECT * FROM EMP WHERE DEPTNO = 20;
UPDATE EMP SET SAL = SAL * 1.1 WHERE DEPTNO = 20;
SELECT * FROM EMP WHERE DEPTNO = 20;

-- Task 5: Find the number of CLERKS employed
SELECT COUNT(*) AS "Number of Clerks" FROM EMP WHERE JOB = 'CLERK';

-- Task 6: Find the average salary for each job type and the number of people employed in each job
SELECT JOB, AVG(SAL) AS "Average Salary", COUNT(*) AS "Number of Employees"
FROM EMP
GROUP BY JOB;

-- Task 7: List the employees with the lowest and highest salary
SELECT * FROM EMP WHERE SAL = (SELECT MIN(SAL) FROM EMP) OR SAL = (SELECT MAX(SAL) FROM EMP);

-- Task 8: Find the total salary paid to employees in each department
SELECT DEPTNO, SUM(SAL) AS "Total Salary"
FROM EMP
GROUP BY DEPTNO;

-- Task 9: Find the average salary for each department
SELECT DEPTNO, AVG(SAL) AS "Average Salary"
FROM EMP
GROUP BY DEPTNO;

-- Task 10: List the employees who earn more than the average salary of their department
SELECT E.*
FROM EMP E
JOIN (
  SELECT DEPTNO, AVG(SAL) AS "Average Salary"
  FROM EMP
  GROUP BY DEPTNO
) AS D ON E.DEPTNO = D.DEPTNO
WHERE E.SAL > D."Average Salary";

-- Task 11: Find the number of employees in each department
SELECT DEPTNO, COUNT(*) AS "Number of Employees"
FROM EMP
GROUP BY DEPTNO;

-- Task 12: List the departments that have more than 3 employees
SELECT DEPTNO, COUNT(*) AS "Number of Employees"
FROM EMP
GROUP BY DEPTNO
HAVING COUNT(*) > 3;