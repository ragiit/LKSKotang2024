CREATE DATABASE EsemkaHRMaster
GO
USE EsemkaHRMaster
GO

CREATE TABLE EmployeeStatuses (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE JobPositions (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Times (
    ID INT PRIMARY KEY IDENTITY,
    TimeValue TIME UNIQUE NOT NULL
);

CREATE TABLE Countries (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) UNIQUE NOT NULL,
    Code CHAR(2) UNIQUE
);

CREATE TABLE Departments (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Roles (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE WorkDays (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) UNIQUE NOT NULL,
);

CREATE TABLE WorkLocations (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE JobTitles (
    ID INT PRIMARY KEY IDENTITY,
    PositionID INT NOT NULL,
    Name VARCHAR(50) UNIQUE NOT NULL,
    Level INT NOT NULL,

    FOREIGN KEY (PositionID) REFERENCES JobPositions(ID)
);

CREATE TABLE Cities (
    ID INT PRIMARY KEY IDENTITY,
    CountryID INT NOT NULL,
    Name VARCHAR(100) UNIQUE NOT NULL,

    FOREIGN KEY (CountryID) REFERENCES Countries(ID)
);

CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY,
	RoleID INT NOT NULL,
	JobTitleID INT NOT NULL,
    CountryID INT NOT NULL,
	DepartmentID INT NOT NULL,
    CityID INT NOT NULL,
	EmployeeStatusID INT NOT NULL,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    DateOfBirth DATE,
    Gender VARCHAR(50),
    Address VARCHAR(255),  
    Phone VARCHAR(20),
    RegistrationDate DATETIME2 DEFAULT CURRENT_TIMESTAMP NOT NULL, 
	JoinDate DATE,
	StatusStartDate DATE,
	StatusEndDate DATE,
    Active BIT DEFAULT 0 NOT NULL,
	SALARY MONEY NOT NULL,
	Photo VARCHAR(100)

    FOREIGN KEY (JobTitleID) REFERENCES JobTitles(ID),
	FOREIGN KEY (RoleID) REFERENCES Roles(ID),
	FOREIGN KEY (DepartmentID) REFERENCES Departments(ID),
	FOREIGN KEY (CityID) REFERENCES Cities(ID),
	FOREIGN KEY (CountryID) REFERENCES Countries(ID),
	FOREIGN KEY (EmployeeStatusID) REFERENCES EmployeeStatuses(ID) 
);

--CREATE TABLE UserWorkLocations (
--    ID INT PRIMARY KEY IDENTITY,
--    UserID INT UNIQUE,
--	WorkLocationID INT,
--	WorkDayID INT,

--	FOREIGN KEY (UserID) REFERENCES Users(ID),
--	FOREIGN KEY (WorkDayID) REFERENCES WorkDays(ID),
--	FOREIGN KEY (WorkLocationID) REFERENCES WorkLocations(ID),
--);

CREATE TABLE Schedule (
    ID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    WorkLocationID INT NOT NULL,
    WorkDayID INT NOT NULL,
    
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (WorkLocationID) REFERENCES WorkLocations(ID)
); 

CREATE TABLE ScheduleDetail (
    ID INT PRIMARY KEY IDENTITY,
    ScheduleID INT NOT NULL,
    StartTimeId INT NOT NULL,
    EndTimeId INT NOT NULL,
	BreakTimeId INT NOT NULL,
	BreakDuration INT NOT NULL,
    
    FOREIGN KEY (ScheduleID) REFERENCES Schedule(ID), 
	CONSTRAINT FK_ScheduleDetail_StartTime FOREIGN KEY (StartTimeId) REFERENCES Times(ID),
	CONSTRAINT FK_ScheduleDetail_BreakTime FOREIGN KEY (BreakTimeId) REFERENCES Times(ID),
    CONSTRAINT FK_ScheduleDetail_EndTime FOREIGN KEY (EndTimeId) REFERENCES Times(ID)
); 


-- INSERT VALUES --

INSERT INTO WorkLocations (Name) VALUES
	('Headquarters'),
	('Branch Office 1'),
	('Branch Office 2'),
	('Branch Office 3'),
	('Branch Office 4'),
	('Factory 1'),
	('Factory 2'),
	('Warehouse 1'),
	('Warehouse 2'),
	('Distribution Center 1'),
	('Distribution Center 2'),
	('Retail Store 1'),
	('Retail Store 2'),
	('Call Center 1'),
	('Call Center 2'),
	('Data Center 1'),
	('Data Center 2'),
	('Research Lab 1'),
	('Research Lab 2'),
	('Remote Office');

INSERT INTO EmployeeStatuses (Name) VALUES
	('Probationary'),
	('Contractual'),
	('Permanent'),
	('Part-time'),
	('Full-time'),
	('Temporary'),
	('Internship'),
	('Freelance'),
	('Trainee'),
	('Consultant'); 

DECLARE @StartTime TIME = '08:00:00';
DECLARE @EndTime TIME = '22:00:00';
DECLARE @CurrentTime TIME = @StartTime;

WHILE @CurrentTime <= @EndTime
BEGIN
    INSERT INTO Times (TimeValue) VALUES (@CurrentTime);
    SET @CurrentTime = DATEADD(HOUR, 1, @CurrentTime);
END;

INSERT INTO Roles (Name) VALUES
	('Administrator'),
	('User');

INSERT INTO WorkDays (Name) VALUES
	('Workday (Mon-Fri)'),
	('Weekend (Sat-Sun)'),
	('Fullday (Mon-Sun)'),
	('Monday'),
	('Tuesday'),
	('Wednesday'),
	('Thursday'),
	('Friday'),
	('Saturday'),
	('Sunday');

INSERT INTO Departments (Name) VALUES
	('Human Resources'),
	('Marketing'),
	('Finance'),
	('Sales'),
	('Information Technology'),
	('Customer Service'),
	('Research and Development'),
	('Operations'),
	('Administration'),
	('Legal'),
	('Product Management'),
	('Quality Assurance'),
	('Engineering'),
	('Purchasing'),
	('Supply Chain'),
	('Logistics'),
	('Public Relations'),
	('Healthcare'),
	('Education'),
	('Hospitality');

INSERT INTO JobPositions (Name) VALUES
	('Management'),
	('Professional'),
	('Entry Level');

INSERT INTO JobTitles (Name, PositionID, Level) VALUES
	('CEO', 1, 10),
	('CFO', 1, 9),
	('COO', 1, 9),
	('Vice President', 1, 8),
	('Director', 1, 7),
	('Manager', 1, 6),
	('Senior Consultant', 2, 6),
	('Senior Analyst', 2, 6),
	('Senior Engineer', 2, 6),
	('Software Developer', 2, 5),
	('Architect', 2, 5),
	('Attorney', 2, 5),
	('Doctor', 2, 5),
	('Accountant', 2, 5),
	('Engineer', 2, 4),
	('Consultant', 2, 4),
	('Analyst', 2, 4),
	('Designer', 2, 4),
	('Nurse', 2, 4),
	('Intern', 3, 3),
	('Assistant', 3, 3),
	('Associate', 3, 3),
	('Trainee', 3, 3);

INSERT INTO Countries (Name, Code) VALUES
	('Afghanistan', 'AF'),
	('Albania', 'AL'),
	('Algeria', 'DZ'),
	('Andorra', 'AD'),
	('Angola', 'AO'),
	('Antigua and Barbuda', 'AG'),
	('Argentina', 'AR'),
	('Armenia', 'AM'),
	('Australia', 'AU'),
	('Austria', 'AT'),
	('Azerbaijan', 'AZ'),
	('Bahamas', 'BS'),
	('Bahrain', 'BH'),
	('Bangladesh', 'BD'),
	('Barbados', 'BB'),
	('Belarus', 'BY'),
	('Belgium', 'BE'),
	('Belize', 'BZ'),
	('Benin', 'BJ'),
	('Bhutan', 'BT'),
	('Indonesia', 'ID');

INSERT INTO Cities (Name, CountryID) VALUES
	('Tokyo', 9),
	('Kyoto', 9),
	('Sapporo', 9),
	('Nagoya', 9),
	('Yokohama', 9),
	('New York City', 3),
	('London', 17),
	('Paris', 16),
	('Los Angeles', 3),
	('Sydney', 8),
	('Moscow', 6), 
	('Rome', 21),
	('Beijing', 3),
	('Cairo', 4),
	('Dubai', 19),  
	('Mumbai', 7),
	('Hong Kong', 3),
	('Singapore', 5),
	('Istanbul', 4),
	('Jakarta', 21),
	('Surabaya', 21),
	('Bandung', 21),
	('Medan', 21),
	('Semarang', 21),
	('Bekasi', 21),
	('Depok', 21),
	('Tangerang', 21),
	('Bogor', 21);