Create table DEPT
(DeptNo int, DName varchar(20), Location varchar(30), 
constraint DEPT_PK PRIMARY KEY (DeptNo));

CREATE table EMP
(EMPNo int,EName varchar(20),Comm int, DeptNo int, MGR int, Job int, HireDate date, 
constraint EMP_FK FOREIGN KEY (DeptNo) References DEPT (DeptNo));

CReate table SaleGrade
(Grade varchar(10), LoSal int, HiSal int)

Alter table Dept
Alter column DName varchar(30)

Alter table SaleGrade
Add Title varchar(2)

Exec sp_rename 'SaleGrade','SaleGrad';

Insert Into DEPT  
Values (40,'Unknown', 'Chicago')

insert into EMP (EMPNo, EName, Comm, DeptNo, MGR, Job, HireDate)
values (7, 'Ahmad1', null,20, 20, 2, '13-Jan-20')

insert into SaleGrad (Grade, LoSal, HiSal)
values ('C', 20000,30000)

select max(DeptNo) from EMP

select min(DeptNo) from EMP

select count(DeptNo) from EMP

select * from EMP 
where DeptNo > 10

select DeptNo, count(DeptNo) from EMP 
Group by DeptNo
Having max(DeptNo) = 30 --use having when using group function like max. 

--Equi Join
select EmpNo, DName from EMP, Dept 
Where Emp.DeptNo = Dept.DeptNo

--if column name is common, specify the table name
--method 1
select EmpNo, DName, EName, Dept.DeptNo from EMP, Dept 
Where Emp.DeptNo = Dept.DeptNo

--method 2
select e.EmpNo, d.DName, e.EName, d.DeptNo from EMP e, Dept d 
Where e.DeptNo = d.DeptNo

--method 3
select * from Emp join Dept
on Emp.DeptNo = Dept.DeptNo

--outer join syntax didn't work in sql
select EmpNo, DName, EName, Dept.DeptNo from EMP, Dept 
Where Dept.DeptNo = Emp.DeptNo+

-- outer join 
select EmpNo, EName, Dept.DeptNo from EMP
full outer join DEPT
on Emp.DeptNo = DEPT.DeptNo

--table definition
sp_help emp;
sp_help dept;


alter table emp
add Salary int

update EMP 
set salary = 28000
where EMPNo = 3

--non equijoin (no common columns)
select emp.EName, salegrad.Grade from emp, salegrad 
where emp.salary between salegrad.loSal and salegrad.hisal

select * from emp

update emp set salary = 15000 where EMPNo = 7

select comm+salary from emp where empNo = 7

select isnull(comm,0)+ salary from emp where empno = 7

select * from emp where ename like '%d' --3rd character u % means any number of characters _ means 1 character

select * from emp where comm is null

select * from emp where ename not in ('Bilal', 'Yousuf')

select * from emp where DeptNo < all (select DeptNo from emp where deptno in (20,30))

-- = any is the same as in
-- > any will return more than the minimum
-- < any will return less than maximum value
-- > all more than maximum value

select salary from emp where salary in (select avg(salary) from emp group by DeptNo ) 

select avg(salary) from emp group by deptno

select * from emp 

update emp set mgr = 1 where empno = 4

--self join
select worker.empno worker_empno, worker.ename worker_ename, manager.empno manager_empno, manager.ename manager_ename
from emp worker, emp manager
where worker.mgr = manager.EMPNo

