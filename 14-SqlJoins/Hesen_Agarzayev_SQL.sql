create database Company
use Company 

create table Countries(
Id int primary key identity,
[Name] nvarchar(50) not null,
)


create table Cities(
Id int primary key identity,
[Name] nvarchar(50) not null,
CountriesId int foreign key references Countries(Id)
)



create table Employees(
Id int primary key identity,
[Name] nvarchar(50) not null,
Surname nvarchar(50) not null,
Age int,
Salary decimal(6,2),
Position nvarchar(50),
IsDeleted bit default 0,
CityId int foreign key references Cities(Id)
)

insert into Countries (Name) 
values
('Azerbaycan'), 
('Turkiye'), 
('Almaniya'), 
('Fransa'), 
('Yaponiya'), 
('Italiya')

insert into Cities (Name, CountriesId) 
values 
('Baki', 1),
('Berlin', 3),
('Ankara', 2),
('Milan', 6),
('Marsilya', 4),
('Tokio', 5),
('Izmir', 2),
('Yokohama', 5),
('Dortmund', 3),
('Venesiya', 6),
('Sicilya', 4),
('Semkir', 1)

insert into Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId) 
values 
('Elon', 'Musk', 27, 7777.77, 'Developer', 0, 1),
('Jeff', 'Bezos', 40, 3500.99, 'Reception', 0, 4),
('Steve', 'Jobs', 35, 2100.67, 'Manager', 0, 2),
('Bill', 'Gates', 31, 4500.54, 'Developer', 0, 9),
('Mark', 'Zuckerberg', 36, 6800.73, 'Reception', 0, 3),
('Albert', 'Einstein', 21, 6000.98, 'Manager', 0, 10),
('Nikola', 'Tesla', 25, 5000.35, 'Developer', 1, 5),
('Isaac', 'Newton', 29, 3200.78, 'Reception', 0, 7),
('Leonardo', 'Da Vinci', 24, 1900.42, 'Designer', 0, 8),
('Pablo', 'Picasso', 38, 3400.55, 'Reception', 1, 11),
('Vincent', 'Van Gogh', 38, 2500.55, 'Reception', 1, 6),
('Salvador', 'Dali', 38, 2800.55, 'Reception', 1, 12);

select e.Name as EmployeesName, e.Surname as Surname, ci.Name as City, co.Name as Country from Employees as e
left join Cities as ci 

on e.CityId = ci.Id
left join Countries as co 
on ci.CountriesId = co.Id

select e.Name, co.Name as Country from Employees as e
inner join Cities as ci
on e.CityId = ci.Id
inner join Countries as co

on ci.CountriesId = co.Id
where e.Salary > 2000


select ci.Name as City, co.Name as Country from Cities as ci
left join Countries as co 
on ci.CountriesId = co.Id



select e.Name, e.Surname, e.Age, e.Salary, e.Position, e.IsDeleted,ci.Name as CityName, co.Name as CountryName 
from Employees as e
left join Cities as ci on e.CityId = ci.Id

left join Countries as co on ci.CountriesId = co.Id
where e.Position = 'Reception'


select  e.Name, e.Surname, ci.Name as City, co.Name as Country from Employees as e
inner join Cities as ci on e.CityId = ci.Id
inner join Countries as co on ci.CountriesId = co.Id
where e.IsDeleted = 1