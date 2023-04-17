USE master

IF EXISTS(select * from sys.databases where name='Diamond_Chess')
DROP DATABASE Diamond_Chess;

CREATE DATABASE Diamond_Chess;
GO

USE Diamond_Chess;

CREATE TABLE [Players] (
  [player_id] int PRIMARY KEY IDENTITY(1, 1),
  [player_name] varchar(50),
  [player_surname] varchar(50),
  [login_id] int
)
GO

CREATE TABLE [Login_Details] (
  [login_id] int PRIMARY KEY IDENTITY(50001, 1),
  [login_username] varchar(30) UNIQUE NOT NULL,
  [login_password_hash] varchar(max) NOT NULL
)
GO

CREATE TABLE [Match_Histories] (
  [match_id] int PRIMARY KEY IDENTITY(1, 1),
  [white] int,
  [black] int,
  [match_outcome] int NOT NULL,
  [match_duration] time NOT NULL,
  CONSTRAINT CHK_UNIQUE CHECK(white != black)
)
GO

CREATE TABLE [Match_Outcomes] (
  [outcome_id] int PRIMARY KEY IDENTITY(0, 1),
  [outcome_name] varchar(15) NOT NULL
)
GO


CREATE TABLE [DBO].[Piece_Type] (
		[id] [INT] IDENTITY(1,1) PRIMARY KEY,
		[type] VARCHAR(8)
	);
GO

CREATE TABLE [DBO].[Piece_Status] (
		[id] [INT] IDENTITY(1,1) PRIMARY KEY,
		[status] VARCHAR(8)
	);
GO

CREATE TABLE [DBO].[Piece] (
		[id] [INT] IDENTITY(1,1) PRIMARY KEY,
		[type] [INT] FOREIGN KEY REFERENCES Piece_Type(id),
		[coordinate_x] [INT],
		[coordinate_y] [INT],
		[status] [INT] FOREIGN KEY REFERENCES Piece_Status(id)
	);
GO

ALTER TABLE [Players] ADD FOREIGN KEY ([login_id]) REFERENCES [Login_Details] ([login_id])
GO

ALTER TABLE [Match_Histories] ADD FOREIGN KEY ([white]) REFERENCES [Players] ([player_id])
GO

ALTER TABLE [Match_Histories] ADD FOREIGN KEY ([black]) REFERENCES [Players] ([player_id])
GO

ALTER TABLE [Match_Histories] ADD FOREIGN KEY ([match_outcome]) REFERENCES [Match_Outcomes] ([outcome_id])
GO

INSERT INTO Match_Outcomes (outcome_name) VALUES ('White Victory'),
												 ('Black Victory'),
												 ('Draw')
GO
INSERT INTO Login_Details (login_username, login_password_hash) VALUES ('cbarrack0', '59-00-47-00-4C-00-37-00-35-00-32-00-6F-00-75-00-4D-00-35-00-57-00-4C-00'),
																	   ('btrevillion1', HASHBYTES('MD5','hzdzzgn')),
																	   ('etofanelli2', HASHBYTES('MD5','7AsY1kgH')),
																	   ('dmackintosh3', HASHBYTES('MD5','Y2XytpE6nc')),
																	   ('ndounbare4', HASHBYTES('MD5','onhQPW')),
																	   ('hcaulcutt5', HASHBYTES('MD5','7oZbYG')),
																	   ('cpalser6', HASHBYTES('MD5','7BBgGko9r')),
																	   ('ajanzen7', HASHBYTES('MD5','aOkSHn')),
																	   ('cstileman8', HASHBYTES('MD5','CmwDyKiQMv')),
																	   ('iswidenbank9', HASHBYTES('MD5','8o0FhTyN')),
																	   ('prumkea', HASHBYTES('MD5','iilNsdo')),
																	   ('bocorriganeb', HASHBYTES('MD5','fkoVTgVSQX')),
																	   ('ibierc', HASHBYTES('MD5','oVofpVDb7Ao2')),
																	   ('ehamiltond', HASHBYTES('MD5','XMUw4jiZ6')),
																	   ('uveschie', HASHBYTES('MD5','swO1N15')),
																	   ('acockingf', HASHBYTES('MD5','VVwnTW')),
																	   ('kcalderong', HASHBYTES('MD5','OyKXIlmBnN')),
																	   ('jheatlieh', HASHBYTES('MD5','vasWmN')),
																	   ('dsolwayi', HASHBYTES('MD5','ypi4L3R2OX0')),
																	   ('tbyartj', HASHBYTES('MD5','d7sYbE4'))
GO
INSERT INTO Players (player_name, player_surname, login_id) VALUES ('Damiano', 'Dutson', 50001),
																   ('Reider', 'Sobey', 50002),
																   ('Pavia', 'Girod', 50003),
																   ('Vanya', 'Maudson', 50004),
																   ('Kerrin', 'Sheddan', 50005),
																   ('Jonis', 'Bartalin', 50006),
																   ('Consuelo', 'Treverton', 50007),
																   ('Ralina', 'Verlinde', 50008),
																   ('Janelle', 'Paler', 50009),
																   ('Codi', 'Loudian', 50010),
																   ('Marguerite', 'Pryor', 50011),
																   ('Zebulon', 'Welton', 50012),
																   ('Suzette', 'Pellitt', 50013),
																   ('Sterling', 'Norrington', 50014),
																   ('Aretha', 'Porkiss', 50015),
																   ('Huey', 'Barendtsen', 50016),
																   ('Kale', 'Nano', 50017),
																   ('Drona', 'Izod', 50018),
																   ('Cathlene', 'Vida', 50019),
																   ('Geralda', 'Manhood', 50020)
GO
INSERT INTO Match_Histories (white, black, match_outcome, match_duration) VALUES (20, 19, 1, '22:41:26'),
																				 (18, 20, 1, '02:12:23'),
																				 (17, 12, 0, '03:34:07'),
																				 (10, 16, 1, '09:03:36'),
																				 (15, 16, 1, '06:58:38'),
																				 (18, 17, 2, '23:15:46'),
																				 (8, 2, 0, '14:54:19'),
																				 (17, 15, 2, '13:12:19'),
																				 (14, 17, 0, '20:02:58'),
																				 (2, 13, 0, '03:49:22'),
																				 (12, 10, 2, '14:17:39'),
																				 (2, 15, 0, '20:07:43'),
																				 (6, 13, 1, '00:54:36'),
																				 (2, 7, 2, '16:52:55'),
																				 (14, 8, 1, '14:49:45'),
																				 (8, 20, 1, '06:45:48'),
																				 (15, 1, 1, '20:15:30'),
																				 (1, 5, 1, '14:33:53'),
																				 (19, 5, 0, '00:01:08'),
																				 (3, 14, 2, '00:53:17'),
																				 (10, 17, 0, '07:55:59'),
																				 (12, 4, 2, '22:39:59'),
																				 (17, 6, 0, '06:11:32'),
																				 (17, 20, 0, '19:23:25'),
																				 (1, 5, 2, '12:03:38'),
																				 (6, 1, 0, '07:08:23'),
																				 (11, 2, 0, '14:09:09'),
																				 (6, 12, 2, '08:14:53'),
																				 (18, 5, 1, '20:41:10'),
																				 (14, 10, 2, '15:06:28')
GO

CREATE PROCEDURE dbo.uspRegisterPlayer
    @pUsername VARCHAR(30), 
    @pPassword VARCHAR(MAX), 
    @pName VARCHAR(50), 
    @pSurname VARCHAR(50),
	@responseMessage VARCHAR(250) OUTPUT
    
AS

BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO dbo.[Login_Details] (login_username, login_password_hash)
        VALUES(@pUsername, @pPassword)

        DECLARE @pLogin int 
		
		SELECT TOP 1 @pLogin = login_id FROM dbo.[Login_Details] ORDER BY login_id DESC;

        INSERT INTO dbo.[Players] (player_name,player_surname,login_id)
        VALUES(@pName, @pSurname, @pLogin)


        SET @responseMessage='Successfully registed player.'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END
GO

CREATE PROCEDURE dbo.uspLogin
    @pUsername VARCHAR(30),
    @pPassword VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @playerInfo TABLE(pid int, pName VARCHAR(50), pSurname VARCHAR(50))
    DECLARE @loginID INT

    IF EXISTS (SELECT TOP 1 login_id FROM [dbo].[Login_Details] WHERE login_username=@pUsername)
    BEGIN
        SET @loginID=(SELECT login_id FROM [dbo].[Login_Details] WHERE login_username=@pUsername AND login_password_hash=@pPassword)
		
		IF (@loginID IS NOT NULL )
			SELECT player_id, player_name, player_surname FROM Players WHERE login_id = @loginID
		ELSE
			RETURN NULL
    END
    ELSE
       RETURN NULL
END
GO

CREATE PROCEDURE dbo.uspInsertMatch
    @pWhite int,
    @pBlack int,
	@mOutcome int,
	@mDuration TIME,
	@responseMessage VARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

	   BEGIN TRY
        INSERT INTO [dbo].[Match_Histories] (white, black, match_outcome, match_duration) 
		VALUES ( @pWhite, @pBlack, @mOutcome, @mDuration)


        SET @responseMessage='Successfully inserted match.'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END
GO

CREATE FUNCTION udfgetPlayerWins(
	@pId int
)
RETURNS INT
AS
BEGIN
	DECLARE @pWins as INT = (SELECT COUNT(white) FROM Match_Histories WHERE white = @pId AND match_outcome = 0)
							+ (SELECT COUNT(black) FROM Match_Histories WHERE black = @pId AND match_outcome = 1) ;
	RETURN @pWins 
END
GO

CREATE FUNCTION udfgetPlayerDraws(
	@pId int
)
RETURNS INT
AS
BEGIN
	DECLARE @pDraws as INT = (SELECT COUNT(match_id) FROM Match_Histories WHERE (white = @pId OR black = @pId) AND match_outcome = 2);
	RETURN @pDraws; 
END
GO

CREATE FUNCTION udfgetPlayerLoses(
	@pId int
)
RETURNS INT
AS
BEGIN
	DECLARE @pLosses as INT = (SELECT COUNT(match_id) FROM Match_Histories WHERE (white = @pId AND match_outcome = 1) OR (black = @pId AND match_outcome = 0));
	RETURN @pLosses; 
END
GO

CREATE VIEW vPlayerScores
AS
SELECT p.player_id, p.player_name, p.player_surname, dbo.udfgetPlayerWins(p.player_id) as [Wins], dbo.udfgetPlayerDraws(p.player_id) as [Draws], dbo.udfgetPlayerLoses(p.player_id) as [Losses]
FROM Players p
