CREATE DATABASE MasterAuto

USE MasterAuto

CREATE TABLE Marca(
	id_Marca UNIQUEIDENTIFIER PRIMARY KEY DEFAULT ((NEWID())),
	Nome_Marca NVARCHAR(100)
)

CREATE TABLE Categoria(
	id_Categoria UNIQUEIDENTIFIER PRIMARY KEY DEFAULT ((NEWID())),
	Nome_Categoria NVARCHAR(100)
)

CREATE TABLE Carro(
	Modelo NVARCHAR(244) NOT NULL,
	Placa NVARCHAR(8) UNIQUE NOT NULL,
	Valor DECIMAL(12) NOT NULL,
	Imagem NVARCHAR(100) NOT NULL,
	Cor NVARCHAR(100) NOT NULL,
	id_Categoria UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Categoria (id_Categoria),
	id_Marca UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Marca (id_Marca)
)

ALTER TABLE Carro
ADD Id UNIQUEIDENTIFIER DEFAULT NEWID();

ALTER TABLE Carro
ALTER COLUMN Id UNIQUEIDENTIFIER NOT NULL;

EXEC sp_rename 'Carro.Id', 'Id_Carro', 'COLUMN';

ALTER TABLE Carro
ADD CONSTRAINT PK_Carro PRIMARY KEY (Id_Carro);



Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=MasterAuto;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir BdContextEvent -Context MasterAutoContext -DataAnnotations -Force 

SELECT * FROM Carro