CREATE DATABASE EsemkaHRSystem
GO
USE EsemkaHRSystem
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

CREATE TABLE Cities (
    ID INT PRIMARY KEY IDENTITY,
    CountryID INT NOT NULL,
    Name VARCHAR(100) UNIQUE NOT NULL,

    FOREIGN KEY (CountryID) REFERENCES Countries(ID)
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

CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY,
	RoleID INT NOT NULL, -- DEFAULT Set to User when register new employee
	JobTitleID INT NOT NULL,
    CountryID INT NOT NULL, -- for Citizenship (Kewarganegaraan)
	DepartmentID INT,
    CityID INT NOT NULL, 
	EmployeeStatusID INT,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(MAX) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    FullName VARCHAR(100) NOT NULL,
	IDCardNumber VARCHAR(100) NOT NULL,
	CivilStatus VARCHAR(20) NOT NULL,
	Religion VARCHAR(20) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender VARCHAR(50) NOT NULL,
    Address VARCHAR(255) NOT NULL,  
    Phone VARCHAR(20) NOT NULL,
    RegistrationDate DATETIME2 DEFAULT CURRENT_TIMESTAMP NOT NULL, 
	JoinDate DATE NOT NULL,
	StatusStartDate DATE,
	StatusEndDate DATE,
    Active BIT DEFAULT 0 NOT NULL,
	SALARY MONEY,
	Photo VARCHAR(100)

    FOREIGN KEY (JobTitleID) REFERENCES JobTitles(ID),
	FOREIGN KEY (RoleID) REFERENCES Roles(ID),
	FOREIGN KEY (DepartmentID) REFERENCES Departments(ID),
	FOREIGN KEY (CityID) REFERENCES Cities(ID),
	FOREIGN KEY (CountryID) REFERENCES Countries(ID),
	FOREIGN KEY (EmployeeStatusID) REFERENCES EmployeeStatuses(ID) 
); 

CREATE TABLE Schedule (
    ID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    WorkLocationID INT NOT NULL,
    WorkDayID INT NOT NULL,
    
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (WorkLocationID) REFERENCES WorkLocations(ID),
	FOREIGN KEY (WorkDayID) REFERENCES WorkDays(ID),
); 

CREATE TABLE ScheduleDetail (
    ID INT PRIMARY KEY IDENTITY,
    ScheduleID INT NOT NULL,
	Date DATE NOT NULL,
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
	('Part-time'), 
	('Temporary'),
	('Internship'),
	('Freelance'),
	('Trainee'); 

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
	('HR', 1, 6),
	('Senior Consultant', 2, 5),
	('Senior Analyst', 2, 5),
	('Senior Engineer', 2, 5),
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
	('Japan', 'JP'),
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
    ('Kabul', 1),
    ('Kandahar', 1),
    ('Herat', 1),
    ('Mazar-i-Sharif', 1),
    ('Jalalabad', 1),
    ('Kunduz', 1),
    ('Lashkar Gah', 1),
	('Tirana', 2),
    ('Durrës', 2),
    ('Vlorë', 2),
    ('Shkodër', 2),
    ('Fier', 2),
    ('Korçë', 2),
	('Tokyo', 9),
	('Kyoto', 9),
	('Sapporo', 9),
	('Nagoya', 9),
	('Vienna', 10),
    ('Graz', 10),
    ('Linz', 10),
    ('Salzburg', 10),
    ('Innsbruck', 10),
    ('Klagenfurt', 10),
	 ('Baku', 11),
    ('Ganja', 11),
    ('Sumqayit', 11),
    ('Mingachevir', 11),
    ('Lankaran', 11),
    ('Shirvan', 11),
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


SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [RoleID], [JobTitleID], [CountryID], [DepartmentID], [CityID], [EmployeeStatusID], [Username], [Password], [Email], [FullName], [IDCardNumber], [CivilStatus], [Religion], [DateOfBirth], [Gender], [Address], [Phone], [RegistrationDate], [JoinDate], [StatusStartDate], [StatusEndDate], [Active], [SALARY]) VALUES (1, 1, 8, 21, NULL, 26, NULL, N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'admin@mail.com', N'Admin', N'32643532523', N'Single', N'Islam', CAST(N'2024-02-20' AS Date), N'Male', N'Jakarta', N'0856179863412', CAST(N'2024-02-20T22:03:13.5254799' AS DateTime2), CAST(N'2024-02-20' AS Date), NULL, NULL, 1, NULL)
INSERT [dbo].[Users] ([ID], [RoleID], [JobTitleID], [CountryID], [DepartmentID], [CityID], [EmployeeStatusID], [Username], [Password], [Email], [FullName], [IDCardNumber], [CivilStatus], [Religion], [DateOfBirth], [Gender], [Address], [Phone], [RegistrationDate], [JoinDate], [StatusStartDate], [StatusEndDate], [Active], [SALARY]) VALUES (2, 2, 19, 21, 9, 25, 10, N'user', N'04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb', N'user@mail.com', N'User', N'234985721893', N'Single', N'Islam', CAST(N'2024-02-20' AS Date), N'Male', N'Jakarta', N'0817625361253', CAST(N'2024-02-20T22:03:39.5933262' AS DateTime2), CAST(N'2024-02-20' AS Date), CAST(N'2024-02-20' AS Date), CAST(N'2024-05-08' AS Date), 0, 5000000.0000)
INSERT [dbo].[Users] ([ID], [RoleID], [JobTitleID], [CountryID], [DepartmentID], [CityID], [EmployeeStatusID], [Username], [Password], [Email], [FullName], [IDCardNumber], [CivilStatus], [Religion], [DateOfBirth], [Gender], [Address], [Phone], [RegistrationDate], [JoinDate], [StatusStartDate], [StatusEndDate], [Active], [SALARY]) VALUES (3, 2, 8, 21, 19, 27, 5, N'ragiit', N'04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb', N'ragit@mail.com', N'Ragit', N'287364782', N'Single', N'Islam', CAST(N'2024-02-20' AS Date), N'Male', N'Poris', N'08187246781', CAST(N'2024-02-20T22:04:13.5774810' AS DateTime2), CAST(N'2024-02-20' AS Date), CAST(N'2024-02-20' AS Date), CAST(N'2024-02-20' AS Date), 1, 100000.0000)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ID], [UserID], [StartDate], [EndDate], [WorkLocationID], [WorkDayID]) VALUES (6, 2, CAST(N'2024-02-26' AS Date), CAST(N'2024-03-08' AS Date), 2, 1)
INSERT [dbo].[Schedule] ([ID], [UserID], [StartDate], [EndDate], [WorkLocationID], [WorkDayID]) VALUES (7, 3, CAST(N'2024-02-20' AS Date), CAST(N'2024-03-30' AS Date), 1, 2)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[ScheduleDetail] ON 

INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (57, 6, CAST(N'2024-02-26' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (58, 6, CAST(N'2024-02-27' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (59, 6, CAST(N'2024-02-28' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (60, 6, CAST(N'2024-02-29' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (61, 6, CAST(N'2024-03-01' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (62, 6, CAST(N'2024-03-04' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (63, 6, CAST(N'2024-03-05' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (64, 6, CAST(N'2024-03-06' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (65, 6, CAST(N'2024-03-07' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (66, 6, CAST(N'2024-03-08' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (67, 7, CAST(N'2024-02-24' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (68, 7, CAST(N'2024-02-25' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (69, 7, CAST(N'2024-03-02' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (70, 7, CAST(N'2024-03-03' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (71, 7, CAST(N'2024-03-09' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (72, 7, CAST(N'2024-03-10' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (73, 7, CAST(N'2024-03-16' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (74, 7, CAST(N'2024-03-17' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (75, 7, CAST(N'2024-03-23' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (76, 7, CAST(N'2024-03-24' AS Date), 1, 1, 1, 60)
INSERT [dbo].[ScheduleDetail] ([ID], [ScheduleID], [Date], [StartTimeId], [EndTimeId], [BreakTimeId], [BreakDuration]) VALUES (77, 7, CAST(N'2024-03-30' AS Date), 1, 1, 1, 60)
SET IDENTITY_INSERT [dbo].[ScheduleDetail] OFF
GO