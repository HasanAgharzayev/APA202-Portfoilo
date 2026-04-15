
create database company

use company




create table employees (
    employeeid int primary key,
    firstname varchar(50),
    lastname varchar(50),
    email varchar(100),
    phonenumber varchar(20),
    hiredate date,
    jobtitle varchar(50),
    salary decimal(10, 2),
    department varchar(50)
)


insert into employees (employeeid, firstname, lastname, email, phonenumber, hiredate, jobtitle, salary, department)
values 
(1, 'anar', 'mammadov', 'anar@company.az', '0501112233', '2019-05-10', 'developer', 2500, 'it'),
(2, 'leyla', 'hasanova', 'leyla@mail.com', '0552223344', '2021-02-15', 'hr', 1800, 'hr'),
(3, 'elvin', 'quliyev', 'elvin@company.az', '0703334455', '2022-10-01', 'analyst', 2200, 'finance'),
(4, 'nigar', 'aliyeva', 'nigar@company.az', '0514445566', '2018-12-20', 'manager', 3500, 'it'),
(5, 'tural', 'valiyev', 'tural@gmail.com', '0505556677', '2023-01-05', 'designer', 1200, 'design'),
(6, 'orxan', 'sadiqov', 'orxan@company.az', '0556667788', '2020-06-12', 'support', 1400, 'it')


select * from employees
select * from employees where salary > 2000
select * from employees where department = 'it'
select * from employees order by salary desc
select firstname, salary from employees
select * from employees where hiredate > '2020-01-01'
select * from employees where email like '%company.az%'


select max(salary) as maxsalary from employees
select min(salary) as minsalary from employees
select avg(salary) as averagesalary from employees
select count(*) as totalemployees from employees
select sum(salary) as totalsalary from employees


select department, count(*) from employees group by department
select department, avg(salary) from employees group by department
select department, max(salary) from employees group by department

-- update query
update employees set salary = 2800 where employeeid = 1
update employees set salary = salary * 1.10 where department = 'it'
update employees set jobtitle = 'hr meneceri' where firstname = 'leyla' and lastname = 'hasanova'

-- delete query
delete from employees where employeeid = 5
delete from employees where salary < 1500

-- əlavə
select * from employees where firstname like '%a%'
select * from employees where salary between 2000 and 2500
select * from employees where department in ('finance', 'it')