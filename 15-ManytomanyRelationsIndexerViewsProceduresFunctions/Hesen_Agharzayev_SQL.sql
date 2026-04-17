create database CompanyMM
use CompanyMM

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BirthDate DATE,
    Email VARCHAR(100) UNIQUE NOT NULL,
    CONSTRAINT CHK_BirthDate CHECK (BirthDate > '1950-01-01')
)


CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE,
    CONSTRAINT CHK_Dates CHECK (EndDate IS NULL OR EndDate >= StartDate)
)

CREATE TABLE EmployeeProjects (
    EmployeeID INT,
    ProjectID INT,
    AssignedDate DATE DEFAULT GETDATE(),
    PRIMARY KEY (EmployeeID, ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE,
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE
)

INSERT INTO Employees (FirstName, LastName, BirthDate, Email) VALUES
('Əli', 'Əliyev', '1990-05-15', 'ali@company.com'),
('Leyla', 'Məmmədova', '1995-08-20', 'leyla@company.com'),
('Anar', 'Həsənov', '1988-12-10', 'anar@company.com'),
('Nigar', 'Rzayeva', '1992-03-25', 'nigar@company.com'),
('Vüsal', 'Qasımov', '1994-11-02', 'vusal@company.com')


INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES
('E-Commerce Site', '2024-01-01', '2024-06-30'),
('Mobile App', '2024-02-15', '2024-12-01'),
('Cloud Migration', '2024-03-01', NULL)

INSERT INTO EmployeeProjects (EmployeeID, ProjectID) VALUES
(1, 1), (1, 2), (1, 3), 
(2, 1), 
(3, 2), 
(4, 3), 
(5, 3)

SELECT e.FirstName, e.LastName, p.ProjectName
FROM Employees AS e
JOIN EmployeeProjects AS ep 
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID

SELECT e.FirstName, e.LastName, COUNT(ep.ProjectID) AS ProjectCount
FROM Employees AS e
JOIN EmployeeProjects AS ep ON e.EmployeeID = ep.EmployeeID
GROUP BY e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) > 2

CREATE VIEW EmployeeProjectView AS
SELECT 
    e.EmployeeID, 
    (e.FirstName + ' ' + e.LastName) AS FullName, 
    p.ProjectID, 
    p.ProjectName, 
    ep.AssignedDate
FROM Employees AS e
JOIN EmployeeProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID


    
SELECT * FROM EmployeeProjectView  WHERE EmployeeID = 1;

CREATE PROCEDURE sp_AssignEmployeeToProject 
    @empId INT, 
    @projId INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM EmployeeProjects WHERE EmployeeID = @empId AND ProjectID = @projId)
    BEGIN
        INSERT INTO EmployeeProjects (EmployeeID, ProjectID)
        VALUES (@empId, @projId);
    END
END

CREATE FUNCTION fn_GetProjectCount(@empId INT) 
RETURNS INT
AS
BEGIN
    DECLARE @p_count INT;
    SELECT @p_count = COUNT(*) FROM EmployeeProjects WHERE EmployeeID = @empId;
    RETURN @p_count;
END

SELECT FirstName, LastName, dbo.fn_GetProjectCount(EmployeeID) AS TotalProjects 
FROM Employees

EXEC sp_AssignEmployeeToProject @empId = 2, @projId = 2

DELETE FROM EmployeeProjects WHERE EmployeeID = 5

SELECT * FROM EmployeeProjectView

