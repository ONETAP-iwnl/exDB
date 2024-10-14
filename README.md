CREATE DATABASE Magazin

USE Magazin;

CREATE TABLE Users(
ID_User INT PRIMARY KEY IDENTITY(1,1),
Login NVARCHAR(50) NOT NULL,
Password NVARCHAR(50) NOT NULL,
Role NVARCHAR(50) NOT NULL
);

CREATE TABLE Sklad(
ID_Sklad INT PRIMARY KEY IDENTITY(1,1),
NameSklad NVARCHAR(50) NOT NULL,
Adress NVARCHAR(50) NOT NULL
);

CREATE TABLE Tovar(
ID_Tovar INT PRIMARY KEY IDENTITY(1,1),
NameTovar NVARCHAR(50) NOT NULL,
[Description] NVARCHAR(50) NOT NULL,
ID_Sklad INT,
FOREIGN KEY (ID_Sklad) REFERENCES Sklad(ID_Sklad)
);

INSERT INTO Users (Login, Password, Role)
VALUES 
('admin', 'admin', 'администратор'),
('user', 'user', 'менеджер');

INSERT INTO Sklad (NameSklad, Adress)
VALUES 
('Центральный склад', 'ул. Ленина, д. 10'),
('Восточный склад', 'пр. Мира, д. 25'),
('Западный склад', 'ул. Победы, д. 5');

INSERT INTO Tovar (NameTovar, [Description], ID_Sklad)
VALUES 
('Ноутбук', '15-дюймовый экран, Intel i5', 1),
('Принтер', 'Лазерный, монохромный', 2),
('Стул', 'Эргономичный, с поворотным механизмом', 3);
