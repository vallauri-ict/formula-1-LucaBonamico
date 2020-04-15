CREATE TABLE [dbo].[Teams] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [name]            VARCHAR (128) NOT NULL,
    [fullTeamName]    VARCHAR (128) NOT NULL,
    [extCountry]      CHAR (2)      NOT NULL,
    [powerUnit]       VARCHAR (128) NOT NULL,
    [technicalChief]  VARCHAR (128) NOT NULL,
    [chassis]         VARCHAR (128) NOT NULL,
    [extFirstDriver]  INT           NOT NULL,
    [extSecondDriver] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[Teams] ON;
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (1, N'Alfa Romeo', N'Alfa Romeo Racing', N'CH', N'Ferrari', N'Jan Monchaux', N'C38', 14, 16);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (2, N'Ferrari', N'Scuderia Ferrari Mission Winnow', N'IT', N'Ferrari', N'Mattia Binotto', N'SF90', 3, 5);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (3, N'Red Bull', N'Aston Martin Red Bull Racing', N'GB', N'Honda', N'Pierre Waché', N'RB15', 7, 8);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (4, N'Haas', N'Haas F1 Team', N'US', N'Ferrari', N'Rob Taylor', N'VF-19', 18, 17);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (5, N'McLaren', N'McLaren F1 Team', N'GB', N'Renault', N'James Key', N'MCL34', 9, 10);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (6, N'Mercedes', N'Mercedes AMG Petronas Motorsport', N'GB', N'Mercedes', N'James Allison', N'W10', 1, 2);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (7, N'Toro Rosso', N'Red Bull Toro Rosso Honda', N'IT', N'Honda', N'Jody Eggington', N'STR14', 4, 20);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (8, N'Racing Point', N'SportPesa Racing Point F1 Team', N'GB', N'BWT Mercedes', N'Andrew Green', N'RP19', 12, 15);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (9, N'Williams', N'ROKiT Williams Racing', N'GB', N'Mercedes', N'TBC', N'FW42', 13, 19);
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver]) VALUES (10, N'Renault', N'Renault F1 Team', N'GB', N'Renault', N'Nick Chester', N'R.S.19', 6, 11);
SET IDENTITY_INSERT [dbo].[Teams] OFF;