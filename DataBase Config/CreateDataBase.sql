--DELETE WHEN NEEDED
USE MASTER;
DROP DATABASE DiamondChess;
GO


--CREATE WHEN NEEDED
USE MASTER;
Create DATABASE DiamondChess;
GO

USE DiamondChess;
GO

CREATE TABLE [DBO].[Login_Details] (
		[login_id] [INT] IDENTITY(1,1) PRIMARY KEY,
		[login_username] VARCHAR(30),
		[login_password_hash] BINARY(64)
	);
GO

CREATE TABLE [DBO].[Player] (
		[player_id] [INT] IDENTITY(1,1) PRIMARY KEY,
		[player_name] VARCHAR(50) NOT NULL,
		[player_surname] VARCHAR(50) NOT NULL,
		[login_id] [INT] NOT NULL FOREIGN KEY REFERENCES Login_Details(login_id)
	);
GO

CREATE TABLE [DBO].[Match_Outcome] (
		[outcome_id] [INT] IDENTITY(1,1) PRIMARY KEY,
		[outcome_name] VARCHAR(15)
	);
GO

CREATE TABLE [DBO].[Match_History] (
		[match_id] [INT] IDENTITY(1,1) PRIMARY KEY,
		[black] [INT] FOREIGN KEY REFERENCES Player(player_id) NOT NULL,
		[white] [INT] FOREIGN KEY REFERENCES Player(player_id) NOT NULL,
		[match_outcome] [INT],
		[match_duration] [TIME],
		FOREIGN KEY(match_outcome) REFERENCES Match_Outcome(outcome_id),
		CHECK(white != black)
	);
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