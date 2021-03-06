USE [master]
GO
/****** Object:  Database [dbAcmeTuChance]    Script Date: 1/04/2022 20:23:46 ******/
CREATE DATABASE [dbAcmeTuChance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbAcmeTuChance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbAcmeTuChance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbAcmeTuChance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbAcmeTuChance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbAcmeTuChance] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbAcmeTuChance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbAcmeTuChance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbAcmeTuChance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbAcmeTuChance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbAcmeTuChance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbAcmeTuChance] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbAcmeTuChance] SET  MULTI_USER 
GO
ALTER DATABASE [dbAcmeTuChance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbAcmeTuChance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbAcmeTuChance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbAcmeTuChance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbAcmeTuChance] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbAcmeTuChance] SET QUERY_STORE = OFF
GO
USE [dbAcmeTuChance]
GO
/****** Object:  Table [dbo].[question_type]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[question_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_question_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_role2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[survey]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[survey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](500) NULL,
	[description] [text] NULL,
	[token] [varchar](500) NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
	[isActive] [char](1) NULL,
	[question] [text] NULL,
 CONSTRAINT [PK_survey2_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idRole] [int] NULL,
	[name] [varchar](2000) NULL,
	[lastName] [varchar](200) NULL,
	[email] [varchar](200) NULL,
	[password] [varchar](500) NULL,
	[token] [varchar](500) NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
	[isActive] [char](1) NULL,
 CONSTRAINT [PK_user2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_survey]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_survey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[idSurvey] [int] NULL,
	[createdAt] [datetime] NULL,
	[isActive] [char](1) NULL,
	[answerQuestion] [text] NULL,
 CONSTRAINT [PK_user_survey2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[question_type] ON 

INSERT [dbo].[question_type] ([id], [name]) VALUES (1, N'text')
INSERT [dbo].[question_type] ([id], [name]) VALUES (2, N'number')
INSERT [dbo].[question_type] ([id], [name]) VALUES (3, N'date')
SET IDENTITY_INSERT [dbo].[question_type] OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([id], [name]) VALUES (1, N'administrator')
INSERT [dbo].[role] ([id], [name]) VALUES (2, N'cliente')
SET IDENTITY_INSERT [dbo].[role] OFF
GO
SET IDENTITY_INSERT [dbo].[survey] ON 

INSERT [dbo].[survey] ([id], [name], [description], [token], [createdAt], [updatedAt], [isActive], [question]) VALUES (2, N'string2', N'string', N'UEOJU7YN', CAST(N'2022-04-01T23:15:00.000' AS DateTime), CAST(N'2022-04-01T23:15:00.000' AS DateTime), N'1', N'[{"Name":"string","Title":"string","IsRequired":true,"IdQuestionType":1}]')
INSERT [dbo].[survey] ([id], [name], [description], [token], [createdAt], [updatedAt], [isActive], [question]) VALUES (3, N'string4', N'string', N'0IT3ZZY3', CAST(N'2022-04-01T23:19:00.000' AS DateTime), CAST(N'2022-04-01T23:19:00.000' AS DateTime), N'1', N'[{"Name":"string","Title":"string","IsRequired":true,"IdQuestionType":3}]')
INSERT [dbo].[survey] ([id], [name], [description], [token], [createdAt], [updatedAt], [isActive], [question]) VALUES (4, N'update4', N'string', N'OWG05CXK8HV22SMZ1P3FBIC361P0NFGXTH7CUB920E0CJRXQCD', CAST(N'2022-04-02T00:01:00.000' AS DateTime), CAST(N'2022-04-02T00:02:00.000' AS DateTime), N'0', N'[{"Name":"string","Title":"string","IsRequired":true,"IdQuestionType":1}]')
SET IDENTITY_INSERT [dbo].[survey] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [idRole], [name], [lastName], [email], [password], [token], [createdAt], [updatedAt], [isActive]) VALUES (1, 1, N'Gustavo', N'Rivero', N'jgriverogarcia@gmail.com', N'O1j1V/QgLu0t2OW8/OttZSXPEn6EkRReM6YunN3JwKk=', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJuYmYiOjE2NDg4NDcxMzIsImV4cCI6MTY1NjYyMzEzMiwiaWF0IjoxNjQ4ODQ3MTMyfQ.HtvCJ-dp4xJL-4zCcWKfVkMn0Z-Iy4_6EfRzaDm2JSE', CAST(N'2022-04-01T21:02:00.000' AS DateTime), CAST(N'2022-04-01T16:05:32.713' AS DateTime), N'1')
INSERT [dbo].[user] ([id], [idRole], [name], [lastName], [email], [password], [token], [createdAt], [updatedAt], [isActive]) VALUES (2, 2, N'user1', NULL, NULL, NULL, NULL, CAST(N'2022-04-01T20:01:00.637' AS DateTime), CAST(N'2022-04-01T20:01:00.637' AS DateTime), N'1')
INSERT [dbo].[user] ([id], [idRole], [name], [lastName], [email], [password], [token], [createdAt], [updatedAt], [isActive]) VALUES (3, 2, N'user2', NULL, NULL, NULL, NULL, CAST(N'2022-04-01T20:02:29.493' AS DateTime), CAST(N'2022-04-01T20:02:29.493' AS DateTime), N'1')
SET IDENTITY_INSERT [dbo].[user] OFF
GO
SET IDENTITY_INSERT [dbo].[user_survey] ON 

INSERT [dbo].[user_survey] ([id], [idUser], [idSurvey], [createdAt], [isActive], [answerQuestion]) VALUES (1, 3, 2, CAST(N'2022-04-01T20:02:29.543' AS DateTime), N'1', N'[{"Name":"string","Answer":"XASDDASDAS"}]')
SET IDENTITY_INSERT [dbo].[user_survey] OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_question_s_types]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[usp_question_s_types]
AS
BEGIN
	SELECT id,name FROM question_type
END
GO
/****** Object:  StoredProcedure [dbo].[usp_survey_d_survey]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_survey_d_survey]
	@pid INT,
	@result int output
AS
BEGIN
	
	IF (SELECT COUNT(*) FROM survey WHERE id = @pid) = 1
		BEGIN
			UPDATE [dbo].[survey]
			SET isActive = 0
			WHERE id = @pid;

			SET @result = 1;
		END;
	ELSE
		BEGIN
			SET @result = 0;
		END;

END
GO
/****** Object:  StoredProcedure [dbo].[usp_survey_i_survey]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_survey_i_survey]
	@pname VARCHAR(500),
	@pdescription TEXT,
	@ptoken VARCHAR(500),
	@pdate VARCHAR(45),
	@pquestion TEXT,
	@result int output
AS
BEGIN
	
	IF (SELECT COUNT(*) FROM survey WHERE name = @pname AND isActive = 1) = 0 
		BEGIN
			INSERT INTO [dbo].[survey]
				   ([name]
				   ,[description]
				   ,[token]
				   ,[question]
				   ,[createdAt]
				   ,[updatedAt]
				   ,[isActive])
			 VALUES
				   (@pname
				   ,@pdescription
				   ,@ptoken
				   ,@pquestion
				   ,@pdate
				   ,@pdate
				   ,1)

			SET @result = (SELECT @@IDENTITY);
		END;
	ELSE
		BEGIN
			SET @result = 0;
		END;

END
GO
/****** Object:  StoredProcedure [dbo].[usp_survey_s_survey]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[usp_survey_s_survey]
@pid INT
AS
BEGIN
	IF (SELECT COUNT(*) FROM survey WHERE id = @pid AND isActive = 1) > 0 
		BEGIN
			SELECT
				id,
				name,
				description,
				question
			FROM
				survey
			WHERE
				id = @pid;
		END;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_survey_s_surveys]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[usp_survey_s_surveys]
AS
BEGIN
			SELECT
				id,
				name,
				token,
				description,
				question,
				createdAt,
				updatedAt
			FROM
				survey
			WHERE
				isActive = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_survey_s_token]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[usp_survey_s_token]
@ptoken VARCHAR(500)
AS
BEGIN
	IF (SELECT COUNT(*) FROM survey WHERE token = @ptoken AND isActive = 1) > 0 
		BEGIN
			SELECT
				id,
				name,
				description,
				question
			FROM
				survey
			WHERE
				token = @ptoken;
		END;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_survey_s_user]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[usp_survey_s_user]
@pid INT
AS
BEGIN
	IF (SELECT COUNT(*) FROM user_survey WHERE idSurvey = @pid) > 0 
		BEGIN
			SELECT
				id,
				idUser,
				answerQuestion
			FROM
				user_survey
			WHERE
				idSurvey = @pid;
		END;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_survey_u_survey]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_survey_u_survey]
	@pid INT,
	@pname VARCHAR(500),
	@pdescription TEXT,
	@pquestion TEXT,
	@pdate VARCHAR(45),
	@result int output
AS
BEGIN
	
	IF (SELECT COUNT(*) FROM survey WHERE id = @pid) = 1
		BEGIN
			UPDATE [dbo].[survey]
			SET name = @pname,
				description = @pdescription,
				question = @pquestion,
				updatedAt = @pdate
			WHERE id = @pid;

			SET @result = 1;
		END;
	ELSE
		BEGIN
			SET @result = 0;
		END;

END
GO
/****** Object:  StoredProcedure [dbo].[usp_user_i_client]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_user_i_client]
    @result int output
AS
BEGIN
	DECLARE @countUsers INT;
	SELECT @countUsers = COUNT(*) FROM dbo.[user] WHERE idRole = 2;

	 INSERT INTO [dbo].[user]
           ([idRole]
           ,[name]
           ,[createdAt]
           ,[updatedAt]
           ,[isActive])
     VALUES
           (2,
		    CONCAT('user',@countUsers+1),
			GETDATE(),
			GETDATE(),
			1)

	SET @result = (SELECT @@IDENTITY);

END
GO
/****** Object:  StoredProcedure [dbo].[usp_user_i_survey]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_user_i_survey]
	@pidsurvey INT,
	@piduser INT,
	@answerquestion TEXT,
	@result int output
AS
BEGIN

	IF (SELECT COUNT(*) FROM survey WHERE id = @pidsurvey AND isActive = 1) = 1 
		BEGIN
			INSERT INTO [dbo].[user_survey]
				   ([idUser]
				   ,[idSurvey]
				   ,[createdAt]
				   ,[isActive]
				   ,[answerQuestion])
			 VALUES
				   (@piduser
				   ,@pidsurvey
				   ,GETDATE()
				   ,1
				   ,@answerquestion)

			SET @result = (SELECT @@IDENTITY);
		END;
	ELSE
		BEGIN
			SET @result = 0;
		END;

END
GO
/****** Object:  StoredProcedure [dbo].[usp_user_i_user]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_user_i_user]
    @pemail varchar(200),
	@pname varchar(200),
    @plastname varchar(200),
	@pidrole int,
	@ppassword varchar(500),
	@pdate varchar(50),
    @result int output
AS
BEGIN

	IF (SELECT COUNT(*) FROM [dbo].[user] WHERE email = @pemail) = 0 
		BEGIN 
			 INSERT INTO [dbo].[user]
				   ([idRole]
				   ,[name]
				   ,[lastName]
				   ,[email]
				   ,[password]
				   ,[createdAt]
				   ,[updatedAt]
				   ,[isActive])
			 VALUES
				   (@pidrole,
					@pname,
					@plastname,
					@pemail,
					@ppassword,
					@pdate,
					@pdate,
					1)

			SET @result = (SELECT @@IDENTITY);
		END;
	ELSE
		BEGIN
			SET @result = 0;
		END;

END
GO
/****** Object:  StoredProcedure [dbo].[usp_user_s_email]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_user_s_email]
	@pemail VARCHAR(200)
AS
BEGIN
	SELECT 
		u.id,
		u.password,
		r.name as role
	FROM
		[dbo].[user] u
	INNER JOIN role r ON r.id = u.idRole
	WHERE
		email = @pemail
END
GO
/****** Object:  StoredProcedure [dbo].[usp_user_s_token]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_user_s_token]
	@piduser INT,
	@ptoken VARCHAR(500)
AS
BEGIN
	
	IF @piduser = 0
		BEGIN
			SELECT 
				id,
				name,
				lastName,
				idRole,
				email
			FROM
				[dbo].[user]
			WHERE
				token = @ptoken
		END;
	ELSE
		BEGIN
			SELECT 
				id,
				name,
				lastName,
				idRole,
				email
			FROM
				[dbo].[user]
			WHERE
				id = @piduser
		END;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_user_u_token]    Script Date: 1/04/2022 20:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_user_u_token]
    @pid INT,
	@ptoken VARCHAR(500),
	@result INT OUTPUT
AS
BEGIN
	
	IF ((SELECT COUNT(*) FROM [dbo].[user] WHERE id = @pid) > 0)  -- exist user
		BEGIN
			UPDATE [dbo].[user]
			   SET 
					[token] = @ptoken,
					[updatedAt] = GETDATE()
			 WHERE id = @pid;

			 SET @result = 1;
		END;
	ELSE
		BEGIN
			SET @result = 0;

		END;

END
GO
USE [master]
GO
ALTER DATABASE [dbAcmeTuChance] SET  READ_WRITE 
GO
