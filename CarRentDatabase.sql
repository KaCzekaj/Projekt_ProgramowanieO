USE master;
GO
IF DB_ID (N'CarRent') IS NOT NULL
DROP DATABASE CarRent;

CREATE DATABASE CarRent

GO

USE [CarRent]


CREATE TABLE [dbo].[Status](
[ID] [int] Primary Key Identity,
[DostepnoscSamochodu] [nvarchar] (100) NOT NULL)

CREATE TABLE [dbo].[ListaSamochodow](
[ID] [int] Primary Key Identity,
[Marka] [nvarchar] (50) NOT NULL,
[Model] [nvarchar] (100) NOT NULL,
[Nadwozie] [nvarchar] (250) NOT NULL,
[MocSilnika] [nvarchar] (50) NOT NULL,
[StatusID] [int] FOREIGN KEY REFERENCES Status(ID))

CREATE TABLE [dbo].[LoginHaslo](
[ID] [int] Primary Key Identity,
[Login] [nvarchar] (100) NOT NULL,
[Haslo] [nvarchar] (100) NOT NULL)

CREATE TABLE [dbo].[Pracownicy](
[ID] [int] Primary Key Identity,
[Imie] [nvarchar] (50) NOT NULL,
[Nazwisko] [nvarchar] (100) NOT NULL,
[Email] [nvarchar] (100) NOT NULL,
[Telefon] [nvarchar] (20) NOT NULL,
[StatusID] [int] FOREIGN KEY REFERENCES Status(ID))

CREATE TABLE [dbo].[ZamowieniaSamochodow](
[ID] [int] Primary Key Identity,
[SamochodID] [int] FOREIGN KEY REFERENCES ListaSamochodow(ID),
[DataZamowienia] [datetime] NOT NULL,
[StatusID] [int] FOREIGN KEY REFERENCES Status(ID))


INSERT INTO Status VALUES
('Dostepny'),
('Niedostepny')


INSERT INTO ListaSamochodow VALUES
('Audi','A6','Combi','200hp',1),
('BMW','E60','Sedan','171hp',1),
('Lamborghini','Huracan','Coupe','500hp',1 ),
('Ferrari','Testarossa','Coupe','390hp', 2),
('Fiat','Tipo','Hatchback','39hp',1),
('Opel','Corsa','Coupe','38hp', 1)


INSERT INTO LoginHaslo VALUES
('admin','admin123')

INSERT INTO Pracownicy VALUES
('Kacper','Borowy','kacperBorowy@gmail.com','888717654',1),
('Dawid','Czekaj','dawidCzekaj@gmail.com','817929001',1),
('Adam','Kowalski','adamKowalski@gmail.com','671928635',1),
('Piotr','Ostrowski','piotrOstrowski@gmail.com','879172777',2),
('Sebastian','Augustyn','sebastianAugustyn@gmail.com','66966219',1)
