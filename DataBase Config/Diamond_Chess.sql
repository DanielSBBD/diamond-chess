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
																	   ('btrevillion1', '64-3B-60-05-F8-6E-81-85-55-0D-70-C6-23-53-51-CB-CB-CA-1C-9A-65-EC-00-4B-CA-F2-0C-48-4F-A9-A5-1D-17-04-A6-CD-A3-B4-80-68-9B-9A-B2-0C-1F-CD-C5-9E-88-8B-5C-BA-CA-37-99-EB-C4-1C-E5-C4-F0-1D-6E-10'),
																	   --hzdzzgn
																	   ('etofanelli2', '0A-BD-E6-57-B0-83-FE-1F-E7-B5-8A-7B-AA-E8-0B-8D-48-2E-41-75-0E-6F-9C-AE-BC-92-3D-D0-1C-75-42-66-15-9B-E1-0D-D5-3F-AE-FF-E1-46-EE-81-9F-0C-D7-D3-45-4A-2E-3D-D3-7D-CF-61-88-6E-94-DC-58-3B-EF-3B'),
																	   --7AsY1kgH
																	   ('dmackintosh3', 'E6-21-B4-71-3A-1F-6D-76-0E-01-B3-D9-81-FD-99-81-D6-13-78-C9-AF-26-EE-23-CA-02-D0-B8-AD-70-1E-6B-59-BB-BD-C0-58-1A-B2-5E-95-70-95-F3-FB-13-B2-47-49-92-BB-10-2E-30-BD-04-A6-F4-50-1B-9E-80-F6-5C'),
																	   --Y2XytpE6nc
																	   ('ndounbare4', '61-85-40-E7-7A-7A-A2-48-FB-4D-5C-F1-FA-9C-F1-70-2E-BA-24-D6-77-8A-F6-D9-16-F1-D9-E9-A5-B8-03-17-A8-11-A0-19-01-30-68-8E-4E-13-BE-5F-3C-C7-B6-41-E0-08-CB-E9-14-7B-AE-86-2B-FC-12-8D-E6-ED-6F-06'),
																	   --onhQPW
																	   ('hcaulcutt5', '58-7A-36-14-BA-9A-3B-B4-70-08-51-7A-8E-3F-E6-4C-D1-97-08-0C-06-28-FF-62-DF-73-28-C3-E2-50-D2-04-F6-81-3F-58-82-27-1E-C4-65-20-68-0A-3C-10-99-F5-F7-33-1B-AC-44-A4-89-9C-CF-72-FA-36-50-83-E8-F0'),
																	   --7oZbYG
																	   ('cpalser6', '00-24-06-B1-D5-15-1A-C3-4D-C2-5C-3E-24-14-9E-D3-6F-0E-8D-A7-80-CD-B4-DA-F5-F8-1A-63-A5-88-9E-8A-D4-FB-BF-DB-82-6E-45-A8-5E-9A-3A-60-34-B4-8D-8E-91-2E-36-55-9E-EC-C4-12-CD-6F-0B-84-F7-3D-4D-68'),
																	   --7BBgGko9r
																	   ('ajanzen7', '56-38-6E-D1-7E-51-EE-15-FA-D4-63-3A-CB-56-92-93-7B-CB-94-EB-6E-0B-1E-F4-4F-9D-D6-09-50-6F-92-61-54-4F-9C-6F-33-7E-32-C4-59-24-36-AE-A5-65-D1-13-3F-2B-4C-C1-67-06-0E-B7-C8-B1-D5-91-D2-67-02-7A'),
																	   --aOkSHn
																	   ('cstileman8', '39-7B-30-6E-29-C2-C4-A2-DF-F6-57-09-96-40-25-41-61-D2-24-D7-7F-1C-D4-C9-4F-CA-B5-99-B3-27-D2-C0-FB-B1-8F-6D-D4-FC-38-A9-33-3A-EF-DB-58-EE-5A-14-60-06-8F-99-54-A1-C5-35-CB-BF-CE-DF-36-16-74-01'),
																	   --CmwDyKiQMv
																	   ('iswidenbank9', '0C-54-E4-08-72-C5-D1-53-2D-34-83-A8-01-8F-58-71-34-47-37-8B-60-7D-7C-06-A1-E8-A7-7D-83-F0-96-C0-32-E3-34-30-48-68-FD-E4-60-7B-AA-82-4A-90-22-B3-04-37-30-82-A9-C2-7B-3C-34-2D-E8-26-18-FC-67-57'),
																	   --8o0FhTyN
																	   ('prumkea', '27-BE-AB-90-22-09-67-62-1A-76-45-86-ED-D7-66-96-48-59-F5-E3-C8-93-0D-7C-FB-3D-C0-24-06-CE-53-98-71-F0-DF-0A-9A-D9-F2-63-78-28-1C-86-E3-9F-68-50-E8-1C-30-6F-D8-64-1F-2E-14-C6-A1-66-AC-13-2C-D5'),
																	   --iilNsdo
																	   ('bocorriganeb', 'D1-A9-82-15-18-7A-D4-1A-56-46-C6-5A-29-FD-05-B4-A0-E3-9D-41-A0-95-50-37-0E-0A-88-EB-DC-35-6C-5E-7F-E2-C4-12-69-01-8F-25-81-15-98-9E-E5-6D-1D-83-FD-36-3F-73-CC-09-E4-45-4B-F6-E9-39-33-51-2D-12'),
																	   --fkoVTgVSQX
																	   ('ibierc', 'BC-27-8C-1E-AD-0D-71-21-EE-4F-88-0C-63-4A-5F-0A-68-7E-0B-81-66-51-80-03-CE-E8-CC-AF-3E-9D-C6-DB-D0-79-15-1F-71-52-44-75-1F-84-91-CF-1D-67-04-35-59-83-1B-35-1E-21-0E-79-77-66-5C-F4-0F-BB-A7-6E'),
																	   --oVofpVDb7Ao2
																	   ('ehamiltond', '53-FE-68-D7-FD-8A-F9-D9-C0-B9-11-B6-8A-FE-D5-4E-01-53-44-7A-73-E4-9B-55-FE-47-52-54-C5-3C-D2-2E-14-1D-FA-C9-A1-57-01-52-34-D3-16-C4-B8-E6-00-40-D3-95-DD-8E-62-8F-A0-FE-E0-FC-26-38-6B-EA-A0-F6'),
																	   --XMUw4jiZ6
																	   ('uveschie', '56-C8-17-0B-55-45-2C-1C-B3-DE-20-F4-95-02-07-E3-E7-F9-23-BA-C3-F8-2B-3E-DF-6F-24-01-B6-4F-41-D8-3B-EF-27-4F-E5-DD-8C-C7-2D-5A-DC-CD-D9-2D-13-97-8C-74-4C-1B-0F-43-C3-6F-0A-FD-78-08-57-D4-29-7D'),
																	   --swO1N15
																	   ('acockingf', '89-4A-81-9C-3A-2B-72-CE-78-ED-A0-3D-3C-88-9F-E1-26-66-DA-46-1F-18-06-88-CA-8E-F5-85-02-1E-DE-84-9C-B6-95-31-8A-3F-56-33-C6-3A-5E-5E-8B-62-6A-A4-1B-A5-3F-91-E9-96-26-2A-AB-BD-AE-2B-0B-94-69-84'),
																	   --VVwnTW
																	   ('kcalderong', '82-51-74-87-2E-96-E7-B6-37-E7-5E-6A-43-18-B9-9E-DD-C5-81-A9-E9-B5-E5-4F-45-83-57-97-94-C1-B3-F3-2D-AD-FC-74-AA-C6-1A-88-95-71-F6-65-1D-B3-05-52-48-D6-9A-A7-46-81-9A-DB-0A-FA-09-3D-C9-20-42-F8'),
																	   --OyKXIlmBnN
																	   ('jheatlieh', '64-8E-7D-D6-EB-DE-0B-AB-E7-19-D6-4F-F2-86-AE-16-8F-A7-A7-27-DC-F0-84-F8-55-36-61-E2-71-23-41-89-B0-61-EB-9B-B1-E3-4F-9D-3E-3E-E6-C3-CB-95-C0-0F-A7-BF-30-A9-1F-6E-AD-B1-E8-28-22-2F-15-3F-D0-B5'),
																	   --vasWmN
																	   ('dsolwayi', '01-AB-44-52-9C-14-01-85-64-2F-AD-15-92-FB-E2-75-E1-D6-FA-D8-2C-56-DB-90-0A-13-6A-BA-65-20-F5-12-EE-14-F3-57-BA-60-09-BF-03-BF-C0-3C-75-14-05-78-88-C3-AF-72-69-87-93-AA-D5-1A-59-F0-4F-15-A3-0A'),
																	   --ypi4L3R2OX0
																	   ('tbyartj', 'CB-8A-50-B0-C9-59-BE-33-05-FE-B3-FA-2B-2A-82-AD-39-75-E4-76-45-68-85-10-2E-C1-77-D5-8D-03-BC-BA-27-D7-41-78-7E-5C-37-DA-AF-A6-71-CB-BF-C6-E8-76-78-3C-5F-CD-90-E7-3A-5E-15-90-A8-08-AD-3A-ED-88')
																	   --d7sYbE4
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
