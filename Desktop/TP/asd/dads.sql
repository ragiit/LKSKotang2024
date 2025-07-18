USE [master]
GO
/****** Object:  Database [EsemkaHRMaster]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
CREATE DATABASE [EsemkaHRMaster]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EsemkaHRMaster', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ITSSB\MSSQL\DATA\EsemkaHRMaster.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EsemkaHRMaster_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ITSSB\MSSQL\DATA\EsemkaHRMaster_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EsemkaHRMaster] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EsemkaHRMaster].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EsemkaHRMaster] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET ARITHABORT OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EsemkaHRMaster] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EsemkaHRMaster] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EsemkaHRMaster] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EsemkaHRMaster] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET RECOVERY FULL 
GO
ALTER DATABASE [EsemkaHRMaster] SET  MULTI_USER 
GO
ALTER DATABASE [EsemkaHRMaster] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EsemkaHRMaster] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EsemkaHRMaster] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EsemkaHRMaster] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EsemkaHRMaster] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EsemkaHRMaster] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EsemkaHRMaster', N'ON'
GO
ALTER DATABASE [EsemkaHRMaster] SET QUERY_STORE = ON
GO
ALTER DATABASE [EsemkaHRMaster] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EsemkaHRMaster]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Code] [char](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeStatuses]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeStatuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPositions]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPositions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTitles]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTitles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PositionID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Level] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[WorkLocationID] [int] NOT NULL,
	[WorkDayID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleDetail]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[StartTimeId] [int] NOT NULL,
	[EndTimeId] [int] NOT NULL,
	[BreakTimeId] [int] NOT NULL,
	[BreakDuration] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Times]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Times](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TimeValue] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[JobTitleID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[DepartmentID] [int] NULL,
	[CityID] [int] NOT NULL,
	[EmployeeStatusID] [int] NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[IDCardNumber] [varchar](100) NOT NULL,
	[CivilStatus] [varchar](20) NOT NULL,
	[Religion] [varchar](20) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[JoinDate] [date] NOT NULL,
	[StatusStartDate] [date] NULL,
	[StatusEndDate] [date] NULL,
	[Active] [bit] NOT NULL,
	[SALARY] [money] NULL,
	[Photo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkDays]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkDays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkLocations]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkLocations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (1, 9, N'Tokyo')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (2, 9, N'Kyoto')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (3, 9, N'Sapporo')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (4, 9, N'Nagoya')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (5, 9, N'Yokohama')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (6, 3, N'New York City')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (7, 17, N'London')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (8, 16, N'Paris')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (9, 3, N'Los Angeles')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (10, 8, N'Sydney')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (11, 6, N'Moscow')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (12, 21, N'Rome')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (13, 3, N'Beijing')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (14, 4, N'Cairo')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (15, 19, N'Dubai')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (16, 7, N'Mumbai')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (17, 3, N'Hong Kong')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (18, 5, N'Singapore')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (19, 4, N'Istanbul')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (20, 21, N'Jakarta')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (21, 21, N'Surabaya')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (22, 21, N'Bandung')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (23, 21, N'Medan')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (24, 21, N'Semarang')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (25, 21, N'Bekasi')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (26, 21, N'Depok')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (27, 21, N'Tangerang')
INSERT [dbo].[Cities] ([ID], [CountryID], [Name]) VALUES (28, 21, N'Bogor')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (1, N'Afghanistan', N'AF')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (2, N'Albania', N'AL')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (3, N'Algeria', N'DZ')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (4, N'Andorra', N'AD')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (5, N'Angola', N'AO')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (6, N'Antigua and Barbuda', N'AG')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (7, N'Argentina', N'AR')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (8, N'Armenia', N'AM')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (9, N'Japan', N'JP')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (10, N'Austria', N'AT')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (11, N'Azerbaijan', N'AZ')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (12, N'Bahamas', N'BS')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (13, N'Bahrain', N'BH')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (14, N'Bangladesh', N'BD')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (15, N'Barbados', N'BB')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (16, N'Belarus', N'BY')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (17, N'Belgium', N'BE')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (18, N'Belize', N'BZ')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (19, N'Benin', N'BJ')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (20, N'Bhutan', N'BT')
INSERT [dbo].[Countries] ([ID], [Name], [Code]) VALUES (21, N'Indonesia', N'ID')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [Name]) VALUES (9, N'Administration')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (6, N'Customer Service')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (19, N'Education')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (13, N'Engineering')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (3, N'Finance')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (18, N'Healthcare')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (20, N'Hospitality')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (1, N'Human Resources')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (5, N'Information Technology')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (10, N'Legal')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (16, N'Logistics')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (2, N'Marketing')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (8, N'Operations')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (11, N'Product Management')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (17, N'Public Relations')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (14, N'Purchasing')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (12, N'Quality Assurance')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (7, N'Research and Development')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (4, N'Sales')
INSERT [dbo].[Departments] ([ID], [Name]) VALUES (15, N'Supply Chain')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeStatuses] ON 

INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (10, N'Consultant')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (2, N'Contractual')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (8, N'Freelance')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (5, N'Full-time')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (7, N'Internship')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (4, N'Part-time')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (3, N'Permanent')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (1, N'Probationary')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (6, N'Temporary')
INSERT [dbo].[EmployeeStatuses] ([ID], [Name]) VALUES (9, N'Trainee')
SET IDENTITY_INSERT [dbo].[EmployeeStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[JobPositions] ON 

INSERT [dbo].[JobPositions] ([ID], [Name]) VALUES (3, N'Entry Level')
INSERT [dbo].[JobPositions] ([ID], [Name]) VALUES (1, N'Management')
INSERT [dbo].[JobPositions] ([ID], [Name]) VALUES (2, N'Professional')
SET IDENTITY_INSERT [dbo].[JobPositions] OFF
GO
SET IDENTITY_INSERT [dbo].[JobTitles] ON 

INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (1, 1, N'CEO', 10)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (2, 1, N'CFO', 9)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (3, 1, N'COO', 9)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (4, 1, N'Vice President', 8)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (5, 1, N'Director', 7)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (6, 1, N'Manager', 6)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (7, 1, N'HR', 6)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (8, 2, N'Senior Consultant', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (9, 2, N'Senior Analyst', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (10, 2, N'Senior Engineer', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (11, 2, N'Software Developer', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (12, 2, N'Architect', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (13, 2, N'Attorney', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (14, 2, N'Doctor', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (15, 2, N'Accountant', 5)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (16, 2, N'Engineer', 4)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (17, 2, N'Consultant', 4)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (18, 2, N'Analyst', 4)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (19, 2, N'Designer', 4)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (20, 2, N'Nurse', 4)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (21, 3, N'Intern', 3)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (22, 3, N'Assistant', 3)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (23, 3, N'Associate', 3)
INSERT [dbo].[JobTitles] ([ID], [PositionID], [Name], [Level]) VALUES (24, 3, N'Trainee', 3)
SET IDENTITY_INSERT [dbo].[JobTitles] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [Name]) VALUES (1, N'Administrator')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Times] ON 

INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (1, CAST(N'08:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (2, CAST(N'09:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (3, CAST(N'10:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (4, CAST(N'11:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (5, CAST(N'12:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (6, CAST(N'13:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (7, CAST(N'14:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (8, CAST(N'15:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (9, CAST(N'16:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (10, CAST(N'17:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (11, CAST(N'18:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (12, CAST(N'19:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (13, CAST(N'20:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (14, CAST(N'21:00:00' AS Time))
INSERT [dbo].[Times] ([ID], [TimeValue]) VALUES (15, CAST(N'22:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Times] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [RoleID], [JobTitleID], [CountryID], [DepartmentID], [CityID], [EmployeeStatusID], [Username], [Password], [Email], [FullName], [IDCardNumber], [CivilStatus], [Religion], [DateOfBirth], [Gender], [Address], [Phone], [RegistrationDate], [JoinDate], [StatusStartDate], [StatusEndDate], [Active], [SALARY], [Photo]) VALUES (1, 1, 8, 21, NULL, 26, NULL, N'admin', N'123', N'admin@mail.com', N'Admin', N'32643532523', N'Single', N'Islam', CAST(N'2024-02-20' AS Date), N'Male', N'Jakarta', N'0856179863412', CAST(N'2024-02-20T22:03:13.5254799' AS DateTime2), CAST(N'2024-02-20' AS Date), NULL, NULL, 1, NULL, N'9649095_6909.jpg')
INSERT [dbo].[Users] ([ID], [RoleID], [JobTitleID], [CountryID], [DepartmentID], [CityID], [EmployeeStatusID], [Username], [Password], [Email], [FullName], [IDCardNumber], [CivilStatus], [Religion], [DateOfBirth], [Gender], [Address], [Phone], [RegistrationDate], [JoinDate], [StatusStartDate], [StatusEndDate], [Active], [SALARY], [Photo]) VALUES (2, 2, 19, 21, 9, 25, 10, N'user', N'123', N'user@mail.com', N'User', N'234985721893', N'Single', N'Islam', CAST(N'2024-02-20' AS Date), N'Male', N'Jakarta', N'0817625361253', CAST(N'2024-02-20T22:03:39.5933262' AS DateTime2), CAST(N'2024-02-20' AS Date), CAST(N'2024-02-20' AS Date), CAST(N'2024-05-08' AS Date), 1, 5000000.0000, N'wallpaperflare.com_wallpaper.jpg')
INSERT [dbo].[Users] ([ID], [RoleID], [JobTitleID], [CountryID], [DepartmentID], [CityID], [EmployeeStatusID], [Username], [Password], [Email], [FullName], [IDCardNumber], [CivilStatus], [Religion], [DateOfBirth], [Gender], [Address], [Phone], [RegistrationDate], [JoinDate], [StatusStartDate], [StatusEndDate], [Active], [SALARY], [Photo]) VALUES (3, 2, 8, 21, 19, 27, 5, N'ragiit', N'123', N'ragit@mail.com', N'Ragit', N'287364782', N'Single', N'Islam', CAST(N'2024-02-20' AS Date), N'Male', N'Poris', N'08187246781', CAST(N'2024-02-20T22:04:13.5774810' AS DateTime2), CAST(N'2024-02-20' AS Date), CAST(N'2024-02-20' AS Date), CAST(N'2024-02-20' AS Date), 1, 100000.0000, N'wallpaperflare.com_wallpaper.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkDays] ON 

INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (8, N'Friday')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (3, N'Fullday (Mon-Sun)')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (4, N'Monday')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (9, N'Saturday')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (10, N'Sunday')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (7, N'Thursday')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (5, N'Tuesday')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (6, N'Wednesday')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (2, N'Weekend (Sat-Sun)')
INSERT [dbo].[WorkDays] ([ID], [Name]) VALUES (1, N'Workday (Mon-Fri)')
SET IDENTITY_INSERT [dbo].[WorkDays] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkLocations] ON 

INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (2, N'Branch Office 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (3, N'Branch Office 2')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (4, N'Branch Office 3')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (5, N'Branch Office 4')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (14, N'Call Center 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (15, N'Call Center 2')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (16, N'Data Center 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (17, N'Data Center 2')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (10, N'Distribution Center 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (11, N'Distribution Center 2')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (6, N'Factory 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (7, N'Factory 2')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (1, N'Headquarters')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (20, N'Remote Office')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (18, N'Research Lab 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (19, N'Research Lab 2')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (12, N'Retail Store 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (13, N'Retail Store 2')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (8, N'Warehouse 1')
INSERT [dbo].[WorkLocations] ([ID], [Name]) VALUES (9, N'Warehouse 2')
SET IDENTITY_INSERT [dbo].[WorkLocations] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cities__737584F60A084264]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Cities] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Countrie__737584F6D5EEEF9D]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Countries] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Countrie__A25C5AA7114B476F]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Countries] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__737584F6E6A09807]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Departments] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__737584F67A246F8A]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[EmployeeStatuses] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__JobPosit__737584F6002FB172]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[JobPositions] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__JobTitle__737584F69ACCA410]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[JobTitles] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Roles__737584F645D5204F]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Times__660DA88D39B8938E]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Times] ADD UNIQUE NONCLUSTERED 
(
	[TimeValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E44BAA02F1]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D105345B08EC46]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__WorkDays__737584F647A00B91]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[WorkDays] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__WorkLoca__737584F62E2643BE]    Script Date: Tue, 20 Feb 2024 22:12:31 ******/
ALTER TABLE [dbo].[WorkLocations] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[JobTitles]  WITH CHECK ADD FOREIGN KEY([PositionID])
REFERENCES [dbo].[JobPositions] ([ID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([WorkDayID])
REFERENCES [dbo].[WorkDays] ([ID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([WorkLocationID])
REFERENCES [dbo].[WorkLocations] ([ID])
GO
ALTER TABLE [dbo].[ScheduleDetail]  WITH CHECK ADD FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ID])
GO
ALTER TABLE [dbo].[ScheduleDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleDetail_BreakTime] FOREIGN KEY([BreakTimeId])
REFERENCES [dbo].[Times] ([ID])
GO
ALTER TABLE [dbo].[ScheduleDetail] CHECK CONSTRAINT [FK_ScheduleDetail_BreakTime]
GO
ALTER TABLE [dbo].[ScheduleDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleDetail_EndTime] FOREIGN KEY([EndTimeId])
REFERENCES [dbo].[Times] ([ID])
GO
ALTER TABLE [dbo].[ScheduleDetail] CHECK CONSTRAINT [FK_ScheduleDetail_EndTime]
GO
ALTER TABLE [dbo].[ScheduleDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleDetail_StartTime] FOREIGN KEY([StartTimeId])
REFERENCES [dbo].[Times] ([ID])
GO
ALTER TABLE [dbo].[ScheduleDetail] CHECK CONSTRAINT [FK_ScheduleDetail_StartTime]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([EmployeeStatusID])
REFERENCES [dbo].[EmployeeStatuses] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([JobTitleID])
REFERENCES [dbo].[JobTitles] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
USE [master]
GO
ALTER DATABASE [EsemkaHRMaster] SET  READ_WRITE 
GO
