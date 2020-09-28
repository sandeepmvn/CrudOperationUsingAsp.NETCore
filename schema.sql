USE [master]
GO
/****** Object:  Database [SampleCoreDB]    Script Date: 25-09-2020 08:50:34 ******/
CREATE DATABASE [SampleCoreDB]
GO
ALTER DATABASE [SampleCoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SampleCoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SampleCoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SampleCoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SampleCoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SampleCoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SampleCoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SampleCoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SampleCoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SampleCoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SampleCoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SampleCoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SampleCoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SampleCoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SampleCoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SampleCoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SampleCoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SampleCoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SampleCoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SampleCoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SampleCoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SampleCoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SampleCoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SampleCoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [SampleCoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SampleCoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SampleCoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SampleCoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SampleCoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SampleCoreDB] SET QUERY_STORE = OFF
GO
USE [SampleCoreDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 25-09-2020 08:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[PKDepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[PKDepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 25-09-2020 08:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[PKEmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FKDeptId] [int] NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[EmployeeSalary] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[PKEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([FKDeptId])
REFERENCES [dbo].[Department] ([PKDepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
USE [master]
GO
ALTER DATABASE [SampleCoreDB] SET  READ_WRITE 
GO
