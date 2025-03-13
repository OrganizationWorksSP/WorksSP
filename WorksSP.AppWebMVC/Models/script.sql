--Crear base de datos WorksSP
Create database WorksSP
GO

-- Usar  base de datos
use  WorksSP
GO


--crear tabla de Usuarios
CREATE TABLE Usuarios(
Id int primary key IDENTITY(1,1) NOT NULL,
Nombre varchar(30) NOT NULL,
Apellido varchar(30) NOT NULL,
Correo varchar(255) NOT NULL,
Contrasena char(64)NOT NULL,
Usuario TINYINT DEFAULT 1 ,
Telefono char(15)NOT NULL,
Direccion varchar(200)NOT NULL	
);
GO
--DROP TABLE Usuarios

--crear tabla de Trabajador
CREATE TABLE Trabajadores(
Id int primary key IDENTITY(1,1) NOT NULL,
IdUsuario int NOT NULL,
Estado TINYINT DEFAULT 1
CONSTRAINT FK1_Usuario_Trabajador FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id)
);
GO
--DROP TABLE Trabajadores

--crear tabla de Contratista
CREATE TABLE Contratistas(
Id int primary key IDENTITY(1,1) NOT NULL,
IdUsuario int NOT NULL,
Estado TINYINT DEFAULT 1
CONSTRAINT FK1_Usuario_Contratista FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id)
);
GO
--DROP TABLE Contratistas


--crear tabla categorias
CREATE TABLE Categorias(
Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre varchar(30)NOT NULL,
Descripcion varchar(255)NOT NULL
);
GO

--crear la tabla de Publicar perfil de trabajo
CREATE TABLE PerfilTrabajos(
Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
IdCategoria int NOT NULL,
IdTrabajador int NOT NULL,
Nombre varchar(30) NOT NULL,
Direccion varchar(200) NOT NULL,
Descripcion varchar(255)NOT NULL,
Telefono char(15),
Estado TINYINT DEFAULT 1,
FechaPublicacion DateTime NOT NULL,
FechaExpiracion DateTime NOT NULL,
CONSTRAINT FK1_Categoria_PerfilTrabajo FOREIGN KEY (IdCategoria) REFERENCES Categorias (Id),
CONSTRAINT FK2_Trabajador_PerfilTrabajo FOREIGN KEY (IdTrabajador) REFERENCES Trabajadores (Id)
);
GO
--DROP TABLE PerfilTrabajos


--crear tabla de publicar oferta de trabajo 
CREATE TABLE OfertaTrabajos(
Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
IdCategoria int NOT NULL,
IdConstratista int NOT NULL,
Nombre varchar(30) NOT NULL,
Direccion varchar(200) NOT NULL,
Descripcion varchar(255)NOT NULL,
Telefono char(15),
Estado TINYINT DEFAULT 1,
FechaPublicacion DateTime NOT NULL,
FechaExpiracion DateTime NOT NULL,
CONSTRAINT FK1_Categoria_OfertaTrabajo FOREIGN KEY (IdCategoria) REFERENCES Categorias (Id),
CONSTRAINT FK2_Constratista_OfertaTrabajo FOREIGN KEY (IdConstratista) REFERENCES Contratistas (Id)
);
GO
--DROP TABLE OfertaTrabajos


--crear tabla de SolicitarTrabajadores
CREATE TABLE SolicitarTrabajadores(
Id int primary key IDENTITY(1,1) NOT NULL,
IdPerfilTrabajo int NOT NULL,
IdContratista int NOT NULL,
Estado tinyint DEFAULT 1, --devera tener 3 estados
Comentario varchar(200),
CONSTRAINT FK1_PerfilTrabajo_SolicitarTrabajador FOREIGN KEY (IdPerfilTrabajo) REFERENCES PerfilTrabajos (Id),
CONSTRAINT FK2_Contratista_SolicitarTrabajador FOREIGN KEY (IdContratista) REFERENCES Contratistas (Id)
);
GO

--DROP TABLE SolicitarTrabajadores
--DROP TABLE SolicitarOfertas

--crear tabla de SolicitarOfertas
CREATE TABLE SolicitarOfertas(
Id int primary key IDENTITY(1,1) NOT NULL,
IdOfertaTrabajo int NOT NULL,
IdTrabajador int NOT NULL,
Estado tinyint DEFAULT 1, --devera tener 3 estados
Comentario varchar(200),
CONSTRAINT FK1_OfertaTrabajo_SolicitarOferta FOREIGN KEY (IdOfertaTrabajo) REFERENCES OfertaTrabajos (Id),
CONSTRAINT FK2_Trabajador_SolicitarOferta FOREIGN KEY (IdTrabajador) REFERENCES Trabajadores (Id)
);
GO


--crear tabla de Valoraciones 
CREATE TABLE Valoraciones(
Id int primary key IDENTITY(1,1) NOT NULL,
IdPerfilTrabajo int NOT NULL,
IdContratista int NOT NULL,
Calificacion TINYINT DEFAULT 1,
Comentario varchar(200),
CONSTRAINT FK1_PerfilTrabajo_Valoracion FOREIGN KEY (IdPerfilTrabajo) REFERENCES PerfilTrabajos (Id),
CONSTRAINT FK2_Contratista_Valoracion FOREIGN KEY (IdContratista) REFERENCES Contratistas (Id)
);
GO

