USE [master]
GO
/****** Object:  Database [PersonsDB]    Script Date: 2023/07/19 19:16:45 ******/
CREATE DATABASE [PersonsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PersonsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PersonsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PersonsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PersonsDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonsDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonsDB] SET  MULTI_USER 
GO
ALTER DATABASE [PersonsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PersonsDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PersonsDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonsDB', N'ON'
GO
ALTER DATABASE [PersonsDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [PersonsDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PersonsDB]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 2023/07/19 19:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[person_code] [int] NOT NULL,
	[account_number] [varchar](50) NOT NULL,
	[outstanding_balance] [money] NOT NULL,
	[is_closed] [bit] NOT NULL,
	[status_id] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Accounts_account_number] UNIQUE NONCLUSTERED 
(
	[account_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountStatus]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountStatus](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_AccountStatus] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[id_number] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Persons_id_number] UNIQUE NONCLUSTERED 
(
	[id_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[account_code] [int] NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[capture_date] [datetime] NOT NULL,
	[amount] [money] NOT NULL,
	[description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Account_num]    Script Date: 2023/07/19 19:16:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account_num] ON [dbo].[Accounts]
(
	[account_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Person_id]    Script Date: 2023/07/19 19:16:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Person_id] ON [dbo].[Persons]
(
	[id_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((0)) FOR [is_closed]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((1)) FOR [status_id]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Account_Person] FOREIGN KEY([person_code])
REFERENCES [dbo].[Persons] ([code])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Account_Person]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Account_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[AccountStatus] ([status_id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Account_Status]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account] FOREIGN KEY([account_code])
REFERENCES [dbo].[Accounts] ([code])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transaction_Account]
GO
/****** Object:  StoredProcedure [dbo].[pr_AccGetStatus]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[pr_AccGetStatus]
	AS
	BEGIN
		SELECT [status_name] FROM [dbo].[AccountStatus]
	END
GO
/****** Object:  StoredProcedure [dbo].[pr_CreateAcc]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_CreateAcc](
	@PersonC int,
	@AccNum varchar(50),
	@OutStanding money,
	@status varchar(20)
)
AS
BEGIN
	DECLARE @StatID int;
	SET @StatID=(SELECT [status_id] FROM [dbo].[AccountStatus] WHERE [status_name]=@status);
	INSERT INTO [dbo].[Accounts] ([person_code],
			[account_number],
			[outstanding_balance],
			[is_closed],
			[status_id])
	VALUES (@PersonC,@AccNum,@OutStanding,0,@StatID)
END
GO
/****** Object:  StoredProcedure [dbo].[pr_DeletePerson]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_DeletePerson]
(@IDNum varchar(50))
AS 
BEGIN
 DELETE FROM [dbo].[Persons] WHERE [id_number]=@IDNum;
END
GO
/****** Object:  StoredProcedure [dbo].[pr_EditAcc]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_EditAcc]
(
	@AccNum varchar(50),
	@OutStan money,
	@Closed bit,
	@Status varchar(20)
)
AS
BEGIN
	DECLARE @StatID int;
	SET @StatID=(SELECT [status_id] FROM [dbo].[AccountStatus] WHERE [status_name]=@Status);
	UPDATE [dbo].[Accounts] SET [outstanding_balance]=@OutStan,
			[is_closed]=@Closed,
			[status_id]=@StatID
	WHERE [account_number]=@AccNum
			
END
GO
/****** Object:  StoredProcedure [dbo].[pr_EditPerson]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_EditPerson]
(@IDNum varchar(50),
 @Name varchar(50),
 @Surname varchar(50)
)
AS 
BEGIN
	UPDATE [dbo].[Persons] SET [name]=@name,
			[surname]=@Surname
	WHERE [id_number]=@IDNum;
END
GO
/****** Object:  StoredProcedure [dbo].[pr_EditTrans]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_EditTrans]
(
	@AccCode int,
	@amount money,
	@des varchar(100)
)
AS
BEGIN
	DECLARE @CapD datetime;
	SET @CapD=GETDATE();
	UPDATE [dbo].[Transactions] SET [capture_date]=@CapD,
		[amount]=@amount,
		[description]=@des
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAccounts]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_GetAccounts]
(
	@PersonCode int
)
AS
BEGIN
	SELECT * FROM [dbo].[Accounts] WHERE [person_code]=@PersonCode;
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAllAccounts]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_GetAllAccounts]
AS
BEGIN
 SELECT * FROM [dbo].[Accounts]
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAllPersons]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_GetAllPersons]
AS
BEGIN
 SELECT * FROM [dbo].[Persons]
END
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAllTransactions]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_GetAllTransactions]
(@AccCode int) 
AS
BEGIN
 SELECT * FROM [dbo].[Transactions] WHERE [account_code]=@AccCode
END
GO
/****** Object:  StoredProcedure [dbo].[pr_InsertTrans]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[pr_InsertTrans]
(
	@AccCode int,
	@transd datetime,
	@amount money,
	@des varchar(100)
)
AS
BEGIN
	DECLARE @CapD datetime;
	SET @CapD=GETDATE();
	INSERT INTO [dbo].[Transactions]([account_code],
			[transaction_date],
			[capture_date],
			[amount],
			[description]) 
	VALUES(@AccCode,
		@transd,
		@CapD,
		@amount,
		@des)
END
GO
/****** Object:  StoredProcedure [dbo].[pr_InsertUser]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[pr_InsertUser]
(
 @IDNum varchar(50),
 @Name varchar(50),
 @Surname varchar(50)
)
AS
BEGIN
	INSERT INTO [dbo].[Persons]([name],
		[surname],
		[id_number])
	VALUES(@Name,@Surname,@IDNum)
END
GO
/****** Object:  StoredProcedure [dbo].[pr_Login]    Script Date: 2023/07/19 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pr_Login]
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    DECLARE @Result NVARCHAR(10);

    IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [username] = @Username AND [password] = @Password)
        SET @Result = 'Success';
    ELSE 
        SET @Result = 'Failed';

    SELECT @Result AS Result;
END
GO
USE [master]
GO
ALTER DATABASE [PersonsDB] SET  READ_WRITE 
GO
