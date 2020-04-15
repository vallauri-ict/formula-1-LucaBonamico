CREATE TABLE [dbo].[Drivers] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [firstname]    VARCHAR (128) NOT NULL,
    [lastname]     VARCHAR (128) NOT NULL,
    [dob]          DATE          NOT NULL,
    [placeOfBirth] VARCHAR (64)  NOT NULL,
    [extCountry]   CHAR (2)      NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[Drivers] ON;
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (1, N'Lewis', N'Hamilton', N'1985-01-07', N'Stevenage', N'GB');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (2, N'Valtteri', N'Bottas', N'1989-08-28', N'Nastola', N'FI');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (3, N'Sebastian', N'Vettel', N'1987-07-03', N'Heppenheim', N'DE');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (4, N'Pierre', N'Gasly', N'1996-02-07', N'Rouen', N'FR');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (5, N'Charles', N'Leclerc', N'1997-10-16', N'Monte Carlo', N'MC');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (6, N'Daniel', N'Ricciardo', N'1989-07-01', N'Perth', N'AU');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (7, N'Max', N'Verstappen', N'1997-09-30', N'Hasselt', N'NL');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (8, N'Alexander', N'Albon', N'1996-03-23', N'London', N'TH');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (9, N'Carlos', N'Sainz', N'1994-09-01', N'Madrid', N'ES');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (10, N'Lando', N'Norris', N'1999-11-13', N'Bristol', N'GB');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (11, N'Nico', N'Hulkenberg', N'1987-08-19', N'Emmerich am Rhein', N'DE');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (12, N'Sergio', N'Perez', N'1990-01-26', N'Guadalajara', N'MX');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (13, N'Robert', N'Kubica', N'1984-12-07', N'Krakow', N'PL');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (14, N'Kimi', N'Räikkönen', N'1979-10-17', N'Espoo', N'FI');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (15, N'Lance', N'Stroll', N'1998-10-29', N'Montreal', N'CA');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (16, N'Antonio', N'Giovinazzi', N'1993-12-14', N'Martina Franca', N'IT');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (17, N'Kevin', N'Magnussen', N'1992-10-05', N'Roskilde', N'DK');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (18, N'Romain', N'Grosjean', N'1986-04-17', N'Geneva', N'CH');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (19, N'George', N'Russell', N'1998-02-15', N'Kings Lynn', N'GB');
INSERT INTO [dbo].[Drivers] ([id], [firstname], [lastname], [dob], [placeOfBirth], [extCountry]) VALUES (20, N'Daniil', N'Kvyat', N'1994-04-26', N'Ufa', N'RU');
SET IDENTITY_INSERT [dbo].[Drivers] OFF;