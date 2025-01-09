USE master
go

IF exists(SELECT * FROM SysDataBases WHERE name='MutualistWebsite')
BEGIN
	DROP DATABASE MutualistWebsite
END
go

CREATE DATABASE MutualistWebsite
go

USE MutualistWebsite
go

CREATE TABLE Policlinica(
	CodigoID VARCHAR(6) PRIMARY KEY CHECK (CodigoID LIKE '[A-Za-z][A-Za-z][A-Za-z][A-Za-z][A-Za-z][A-Za-z]'), 
	Nombre VARCHAR(50) NOT NULL, 
	Direccion VARCHAR(50) NOT NULL
)
go

CREATE TABLE Consultorio(
	CodigoID VARCHAR(6) NOT NULL FOREIGN KEY REFERENCES Policlinica(CodigoID),
	NumConsultorio INT NOT NULL CHECK (NumConsultorio >= 0),
	Descripcion VARCHAR(100) NOT NULL,
	PRIMARY KEY(NumConsultorio, CodigoID),
	Activo BIT NOT NULL DEFAULT 1
)
go


CREATE TABLE Consulta(
	CodigoC INT IDENTITY(1,1) PRIMARY KEY,
	Fecha DATETIME NOT NULL CHECK (Fecha >= CAST(GETDATE() AS DATE)),
	Medico VARCHAR(50) NOT NULL,
	Especialidad VARCHAR(50) NOT NULL,
	CantNumConsulta INT NOT NULL CHECK (CantNumConsulta > 0), 
	CodigoID VARCHAR(6) NOT NULL,
	NumConsultorio INT NOT NULL,
	FOREIGN KEY (NumConsultorio, CodigoID) REFERENCES Consultorio(NumConsultorio, CodigoID)
)
go


CREATE TABLE Empleado(
	NomUsuario VARCHAR(8) PRIMARY KEY CHECK (LEN(NomUsuario) = 8), 
	PassUsuario VARCHAR(6) NOT NULL 
	 CHECK (LEN(PassUsuario) = 6 AND PassUsuario LIKE '%[A-Za-z]%[A-Za-z]%[A-Za-z]%' AND PassUsuario LIKE '%[0-9]%[0-9]%[0-9]%')
)
go


CREATE TABLE Paciente(
	Cedula INT PRIMARY KEY, 
	Nombre VARCHAR(50) NOT NULL, 
	FechaNac DATETIME NOT NULL CHECK (FechaNac < getdate()), 
	Activo BIT NOT NULL DEFAULT 1
)
go


CREATE TABLE Solicitud(
	NumeroInterno INT IDENTITY(1,1) PRIMARY KEY,
	FechaHora DATETIME NOT NULL DEFAULT GETDATE(), 
	NumSeleccionado INT NOT NULL, 
	AsistioONo BIT NOT NULL DEFAULT 0, 
	CodigoC INT NOT NULL FOREIGN KEY REFERENCES Consulta(CodigoC),
	Cedula INT NOT NULL FOREIGN KEY REFERENCES Paciente(Cedula),
	NomUsuario VARCHAR(8) NOT NULL FOREIGN KEY REFERENCES Empleado(NomUsuario)
)
go

CREATE TABLE Patologias(
	Patologias VARCHAR(50) NOT NULL,
	Cedula INT NOT NULL FOREIGN KEY REFERENCES Paciente(Cedula)
	Primary Key (Cedula, Patologias)
)
go







---------------------------------- DATOS DE PRUEBA ------------------------------------------

--------------------------------POLICLINICA--------------------------------------------------------
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('AAAAAA', 'Policlinica Prado', '8 de octubre')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('BBBBBB', 'Policlinica Cordon', '18 de Julio')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('CCCCCC', 'Policlinica Punta Carretas', 'Mercedes')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('DDDDDD', 'Policlinica Pocitos', 'Tristan narvajas')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('EEEEEE', 'Policlinica Union', 'Avenida Italia')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('FFFFFF', 'Policlinica Malvin', 'Aconcagua')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('GGGGGG', 'Policlinica Ciudad Vieja', 'Amazonas')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('HHHHHH', 'Policlinica Carrasco', 'El cerrito')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('IIIIII', 'Policlinica Aguada', 'Rivera')
INSERT Policlinica (CodigoID, Nombre, Direccion) VALUES ('JJJJJJ', 'Policlinica Goes', 'Luis Alberto Herrera')
--------------------------------POLICLINICA--------------------------------------------------------

--------------------------------CONSULTORIO--------------------------------------------------------
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (1, 'Grande', 'AAAAAA')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (2, 'Chico', 'BBBBBB')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (3, 'Mediano', 'CCCCCC')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (4, 'Grande', 'DDDDDD')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (5, 'Chico', 'FFFFFF')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (6, 'Mediano', 'FFFFFF')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (7, 'Chico', 'JJJJJJ')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (8, 'Grande', 'AAAAAA')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (9, 'Chico', 'HHHHHH')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (10, 'Mediano', 'GGGGGG')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (11, 'Chico', 'HHHHHH')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (12, 'Grande', 'AAAAAA')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (13, 'Chico', 'IIIIII')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (14, 'Mediano', 'AAAAAA')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (15, 'Chico', 'IIIIII')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (16, 'Grande', 'AAAAAA')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (17, 'Chico', 'AAAAAA')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (18, 'Mediano', 'IIIIII')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (19, 'Chico', 'AAAAAA')
INSERT Consultorio (NumConsultorio, Descripcion, CodigoID) VALUES (20, 'Grande', 'GGGGGG')
--------------------------------CONSULTORIO--------------------------------------------------------

--------------------------------PACIENTE--------------------------------------------------------
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012915, 'Camila', '2003-07-18')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012916, 'Martin', '2001-06-12')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012917, 'Luciana', '2000-05-30')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012918, 'Federico', '1999-04-25')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012919, 'Sofia', '1998-03-14')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012920, 'Matias', '1997-02-02')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012921, 'Valeria', '1996-01-20')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012922, 'Joaquin', '1995-12-11')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012923, 'Carla', '1994-11-08')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012924, 'Nicolas', '1993-10-23')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012925, 'Milagros', '1992-09-17')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012926, 'Agustin', '1991-08-05')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012927, 'Florencia', '1990-07-21')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012928, 'Lautaro', '1989-06-09')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012929, 'Juliana', '1988-05-04')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012930, 'Bruno', '1987-04-19')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012931, 'Martina', '1986-03-07')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012932, 'Ignacio', '1985-02-25')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012933, 'Paula', '1984-01-13')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012934, 'Tomas', '1983-12-31')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012935, 'Valentina', '1982-11-20')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012936, 'Renato', '1981-10-15')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012937, 'Lola', '1980-09-03')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012938, 'Sebastian', '1979-08-27')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012939, 'Carolina', '1978-07-16')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012940, 'Ramiro', '1977-06-05')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012941, 'Nerea', '1976-05-25')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012942, 'Julian', '1975-04-14')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012943, 'Emilia', '1974-03-02')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012944, 'Rodrigo', '1973-02-20')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012945, 'Micaela', '1972-01-08')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012946, 'Gabriel', '1971-12-29')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012947, 'Elena', '1970-11-18')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012948, 'Hernan', '1969-10-07')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012949, 'Daniela', '1968-09-25')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012950, 'Gonzalo', '1967-08-14')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012951, 'Marina', '1966-07-02')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012952, 'Felipe', '1965-06-21')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012953, 'Natalia', '1964-05-10')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012954, 'Dario', '1963-04-29')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012955, 'Lucia', '1962-03-17')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012956, 'Juan', '1961-02-06')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012957, 'Isabel', '1960-01-25')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012958, 'Gustavo', '1959-12-15')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012959, 'Patricia', '1958-11-04')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012960, 'Victor', '1957-10-23')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012961, 'Lorena', '1956-09-11')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012962, 'Esteban', '1955-08-01')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012963, 'Marta', '1954-07-21')
INSERT Paciente(Cedula, Nombre, FechaNac) VALUES (54012964, 'Leonardo', '1953-06-10')

--------------------------------PACIENTE--------------------------------------------------------

--------------------------------PATOLOGIAS--------------------------------------------------------
INSERT Patologias  (Patologias, Cedula) VALUES ('Cancer', 54012915)
INSERT Patologias  (Patologias, Cedula) VALUES ('Asma', 54012916)
INSERT Patologias  (Patologias, Cedula) VALUES ('Diabetes', 54012917)
INSERT Patologias  (Patologias, Cedula) VALUES ('Artritis', 54012918)
INSERT Patologias  (Patologias, Cedula) VALUES ('Anemia', 54012919)
INSERT Patologias  (Patologias, Cedula) VALUES ('Gripe', 54012920)
INSERT Patologias  (Patologias, Cedula) VALUES ('SIDA', 54012921)
INSERT Patologias  (Patologias, Cedula) VALUES ('Hepatitis', 54012922)
INSERT Patologias  (Patologias, Cedula) VALUES ('Ebola', 54012923)
INSERT Patologias  (Patologias, Cedula) VALUES ('Gastritis', 54012924)
--------------------------------PATOLOGIAS--------------------------------------------------------
--------------------------------EMPLEADO--------------------------------------------------------
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Juancito', 'ac1b23');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Pedritoo', 'xyz456');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Luisitoo', 'd8ef79');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Rominaaa', 'gi012h');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Luisinaa', 'jkl345');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Juanitaa', '8mno67');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Ezequiel', 'pqr901');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Tomasito', 'su23t4');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Lucianaa', 'v6wx57');
INSERT Empleado (NomUsuario, PassUsuario) VALUES ('Solcitoo', 'yza890');
--------------------------------EMPLEADO--------------------------------------------------------



---------------------------------------CONSULTA----------------------------------------------------
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-08-04', 'Juan Lopez', 'Medicina general', 4, 'AAAAAA', 1)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-18', 'Juan Lopez', 'Medicina general', 4, 'BBBBBB', 2)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-19', 'Maria Garcia', 'Cardiologia', 20, 'CCCCCC', 3)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-20', 'Carlos Perez', 'Pediatria', 32, 'DDDDDD', 4)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-21', 'Ana Martinez', 'Dermatologia', 17, 'FFFFFF', 5)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-22', 'Luis Fernandez', 'Medicina general', 5, 'FFFFFF', 6)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-23', 'Laura Rodriguez', 'Oftalmologia', 14, 'JJJJJJ', 7)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-24', 'Jorge Ramirez', 'Ginecologia', 22, 'AAAAAA', 8)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-25', 'Sofia Gomez', 'Traumatologia', 13, 'HHHHHH', 9)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-26', 'David Torres', 'Urologia', 18, 'GGGGGG', 10)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-27', 'Elena Diaz', 'Psiquiatria', 5, 'HHHHHH', 11)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-28', 'Miguel Ruiz', 'Medicina general', 4, 'AAAAAA', 12)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-29', 'Sandra Jimenez', 'Medicina general', 32, 'IIIIII', 13)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-09-30', 'Raul Alvarez', 'Cardiologia', 23, 'AAAAAA', 14)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-01', 'Natalia Molina', 'Cardiologia', 15, 'IIIIII', 15)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-02', 'Esteban Vargas', 'Reumatologia', 15, 'AAAAAA', 16)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-03', 'Claudia Herrera', 'Nefrologia', 4, 'AAAAAA', 17)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-04', 'Pablo Castillo', 'Hematologia', 12, 'IIIIII', 18)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-05', 'Lucia Romero', 'Dermatologia', 3, 'AAAAAA', 19)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-06', 'Alberto Medina', 'Dermatologia', 11, 'GGGGGG', 20)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-07', 'Paula Cruz', 'Ginecologia', 25, 'AAAAAA', 1)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-08', 'Ricardo Ortiz', 'Ginecologia', 24, 'BBBBBB', 2)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-09', 'Alejandra Chavez', 'Geriatria', 21, 'CCCCCC', 3)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-10', 'Daniela Soto', 'Oftalmologia', 13, 'DDDDDD', 4)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-11', 'Fernando Paredes', 'Psiquiatria infantil', 12, 'FFFFFF', 5)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-12', 'Gabriela Vega', 'Cirugia', 5, 'FFFFFF', 6)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-13', 'Juan Ortega', 'Oftalmologia', 4, 'JJJJJJ', 7)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-14', 'Patricia Vega', 'Medicina general', 22, 'AAAAAA', 8)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-15', 'Andres Herrera', 'Medicina general', 13, 'HHHHHH', 9)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-16', 'Monica Reyes', 'Pediatria', 10, 'GGGGGG', 10)
INSERT Consulta (Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) VALUES ('2024-10-17', 'Hector Fuentes', 'Pediatria', 5, 'HHHHHH', 11)

---------------------------------------CONSULTA----------------------------------------------------











--------------------------------SOLICITUD--------------------------------------------------------
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012915', 'Juancito', 1);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012916', 'Juancito', 2);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012917', 'Pedritoo', 3);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012918', 'Juancito', 4);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012919', 'Juancito', 5);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012920', 'Juancito', 6);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012921', 'Luisinaa', 7);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012922', 'Pedritoo', 8);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012923', 'Juancito', 9);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012924', 'Juancito', 10);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012925', 'Juancito', 11);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012926', 'Pedritoo', 12);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012927', 'Juancito', 13);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012928', 'Juancito', 14);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012929', 'Juancito', 15);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012930', 'Juancito', 16);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012931', 'Juancito', 17);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012932', 'Pedritoo', 18);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012933', 'Juancito', 19);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012934', 'Juancito', 20);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012935', 'Juancito', 21);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012936', 'Pedritoo', 22);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012937', 'Juancito', 23);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012938', 'Luisinaa', 24);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012939', 'Juancito', 25);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012940', 'Juancito', 26);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012941', 'Luisinaa', 27);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 0, '54012942', 'Juancito', 28);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012943', 'Juancito', 29);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (1, 1, '54012944', 'Juancito', 30);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012945', 'Juancito', 1);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012946', 'Juancito', 2);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012947', 'Juancito', 3);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012948', 'Pedritoo', 4);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012949', 'Juancito', 5);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012950', 'Juancito', 6);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012951', 'Juancito', 7);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012952', 'Juancito', 8);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012953', 'Juancito', 9);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012954', 'Juancito', 10);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012955', 'Pedritoo', 11);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012956', 'Pedritoo', 12);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012957', 'Juancito', 13);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012958', 'Juancito', 14);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012959', 'Luisinaa', 15);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012960', 'Juancito', 16);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012961', 'Luisinaa', 17);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012962', 'Juancito', 18);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012963', 'Pedritoo', 19);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012964', 'Juancito', 20);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012915', 'Juancito', 21);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012916', 'Juancito', 22);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012917', 'Pedritoo', 23);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012918', 'Juancito', 24);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012919', 'Juancito', 25);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012920', 'Juancito', 26);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012921', 'Juancito', 27);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012922', 'Juancito', 28);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 1, '54012923', 'Pedritoo', 29);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (2, 0, '54012924', 'Juancito', 30);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012925', 'Luisinaa', 1);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012926', 'Juancito', 2);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012927', 'Juancito', 3);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012928', 'Juancito', 4);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012929', 'Pedritoo', 5);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012930', 'Juancito', 6);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012931', 'Juancito', 7);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012932', 'Juancito', 8);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012933', 'Pedritoo', 9);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012934', 'Juancito', 10);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012935', 'Juancito', 11);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012936', 'Luisinaa', 12);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012937', 'Juancito', 13);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012938', 'Juancito', 14);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012939', 'Pedritoo', 15);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012940', 'Juancito', 16);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012941', 'Luisinaa', 17);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 1, '54012942', 'Juancito', 18);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012943', 'Juancito', 19);
INSERT Solicitud(NumSeleccionado, AsistioONo, Cedula, NomUsuario, CodigoC) VALUES (3, 0, '54012944', 'Juancito', 20);

GO
--------------------------------SOLICITUD--------------------------------------------------------


------------------------ PROCEDIMIENTOS ALMACENADOS ---------------------------------------------

-----------------------------EMPLEADO------------------------------------------------------------
 
CREATE PROCEDURE AltaEmpleado @NomUsuario VARCHAR(8), @PassUsuario VARCHAR(6) AS
BEGIN
		IF EXISTS (SELECT * FROM Empleado WHERE NomUsuario = @NomUsuario)
		BEGIN
			RETURN -1 --EXISTE EL EMPLEADO
		END ELSE
BEGIN
			INSERT Empleado (NomUsuario, PassUsuario) VALUES (@NomUsuario, @PassUsuario)

			IF @@ERROR != 0
			BEGIN 
				RETURN -2 --NO SE DIÓ DE ALTA
			END
			RETURN 1 -- SE DIÓ DE ALTA
		END
END 
GO

CREATE PROCEDURE BuscarEmpleado @NomUsuario VARCHAR(8) AS
BEGIN 
	SELECT * FROM Empleado WHERE NomUsuario = @NomUsuario
END
GO

CREATE PROCEDURE Logueo @NomUsuario VARCHAR(8), @PassUsuario VARCHAR(6) AS
BEGIN
	SELECT * FROM Empleado A
	WHERE A.NomUsuario = @NomUsuario AND A.PassUsuario = @PassUsuario
END
GO

-----------------------------FIN EMPLEADO------------------------------------------------------------ CORRECTO corregido 

-----------------------------CONSULTA------------------------------------------------------------
CREATE PROCEDURE AltaConsulta @Fecha DATETIME, @Medico VARCHAR(50), @Especialidad VARCHAR(50), @CantNumConsulta INT, @CodigoID VARCHAR(6), @NumConsultorio INT AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Consultorio WHERE CodigoID = @CodigoID AND NumConsultorio = @NumConsultorio AND Activo = 1)
	BEGIN
		RETURN -1 --ERROR
	END

    INSERT Consulta(Fecha, Medico, Especialidad, CantNumConsulta, CodigoID, NumConsultorio) 
	VALUES (@Fecha, @Medico, @Especialidad, @CantNumConsulta, @CodigoID, @NumConsultorio)

    RETURN @@IDENTITY;
END
GO

CREATE PROCEDURE BuscarConsulta  @CodigoC INT AS
BEGIN 
	SELECT * FROM Consulta WHERE CodigoC = @CodigoC
END
GO

CREATE PROCEDURE ListarTodasLasConsultas AS
BEGIN
	SELECT * FROM Consulta
END
GO

CREATE PROCEDURE ListarConsultasPendientes AS
BEGIN
	SELECT * FROM Consulta WHERE Fecha >= GETDATE()
	ORDER BY Fecha
END
GO

-----------------------------FIN CONSULTA------------------------------------------------------------  CORRECTO corregido

-----------------------------POLICLINICA------------------------------------------------------------
CREATE PROCEDURE AltaPoliclinica @CodigoID VARCHAR(6), @Nombre VARCHAR(50), @Direccion VARCHAR(50) AS
BEGIN
	IF EXISTS(SELECT * FROM Policlinica WHERE CodigoID = @CodigoID)
		RETURN -1 --EXISTE LA POLICLINCIA

	INSERT Policlinica(CodigoID, Nombre, Direccion) VALUES (@CodigoID, @Nombre, @Direccion)

	IF @@ERROR != 0
	BEGIN
		RETURN -2 --NO SE DIO DE ALTA
	END
	RETURN 1 -- SE DIO DE ALTA
END
GO

CREATE PROCEDURE BuscarPoliclinica @CodigoID VARCHAR(6) AS
BEGIN
	SELECT * FROM Policlinica WHERE @CodigoID = CodigoID
END
GO


-----------------------------FIN POLICLINICA---------------------------------------------------------- CORRECTO corregido



-----------------------------SOLICITUD------------------------------------------------------------
CREATE PROCEDURE AltaSolicitud @NumSeleccionado INT, @CodigoC INT, @Cedula INT, @NomUsuario VARCHAR(8) AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Consulta WHERE @CodigoC = CodigoC)
		RETURN -2 --NO EXISTE LA CONSULTA
	IF NOT EXISTS(SELECT 1 FROM Paciente WHERE @Cedula = Cedula AND Activo = 1)
		RETURN -3 --NO EXISTE EL PACIENTE
	IF NOT EXISTS(SELECT 1 FROM Empleado WHERE @NomUsuario = NomUsuario)
		RETURN -4 -- NO EXISTE EL EMPLEADO

	IF EXISTS(SELECT 1 FROM Solicitud WHERE NumSeleccionado = @NumSeleccionado AND CodigoC = @CodigoC)
		RETURN -6 -- ESE NUMERO SELECCIONADO PARA ESA CONSULTA YA NO ESTÁ
	IF EXISTS(SELECT 1 FROM Solicitud WHERE Cedula = @Cedula AND CodigoC = @CodigoC)
        RETURN -7 -- ESE PACIENTE PARA ESA CONSULTA YA TIENE UN NUMERO

		INSERT Solicitud(NumSeleccionado, CodigoC, Cedula, NomUsuario) VALUES (@NumSeleccionado, @CodigoC, @Cedula, @NomUsuario)

		IF @@ERROR != 0
		BEGIN
			RETURN -5 --NO SE DIO DE ALTA
		END
		RETURN 1 -- ALTA CON EXITO
END
GO

CREATE PROCEDURE ListarTodasSolicitudes AS
BEGIN
		SELECT * from Solicitud
END
GO

CREATE PROCEDURE ListarSolicitudesConsulta(@CodigoC INT) AS
BEGIN
	
		select * from Solicitud where @CodigoC = CodigoC

END
GO

CREATE PROCEDURE ListarConsultasSinAsistirHoy AS
BEGIN
	SELECT s.*
	FROM Solicitud s INNER JOIN Consulta c ON c.CodigoC = s.CodigoC WHERE s.AsistioONo = 0 -- saco que no asistió
	AND CAST(c.Fecha AS DATE) = CAST(GETDATE() AS DATE) --le saco la hora a las fechas y hago que sea igual a la fecha de hoy
END
GO

CREATE PROCEDURE MarcarAsistencia @NumeroInterno INT AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Solicitud WHERE NumeroInterno = @NumeroInterno)
    BEGIN
		RETURN -1 --ERROR
	END


		UPDATE Solicitud
        SET AsistioONo = 1
        WHERE NumeroInterno = @NumeroInterno;

	 IF @@ERROR != 0
        BEGIN
            ROLLBACK TRANSACTION            
            RETURN -2 -- ERROR 
        END
		return 1 -- MARCADO
END
GO
-----------------------------FIN SOLICITUD------------------------------------------------------------ CORRECTO corregido



-----------------------------CONSULTORIO------------------------------------------------------------
CREATE PROCEDURE AltaConsultorio @NumConsultorio INT, @Descripcion VARCHAR(100), @CodigoID VARCHAR(6) AS
BEGIN
	IF EXISTS (SELECT * FROM Consultorio WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID AND Activo = 1)
		RETURN -1 --EXISTE EL CONSULTORIO ACTIVO

	IF EXISTS (SELECT 1 FROM Consultorio WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID AND Activo = 0)
    BEGIN
        UPDATE Consultorio
        SET Descripcion = @Descripcion, Activo = 1
        WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID

        IF @@ERROR != 0
        BEGIN
            RETURN -2 -- NO SE PUDO REACTIVAR
        END

        RETURN 2 -- SE REACTIVÓ EL CONSULTORIO
    END

	IF NOT EXISTS (SELECT 1 FROM Policlinica WHERE CodigoID = @CodigoID)
        RETURN -3 -- NO EXISTE LA POLICLINICA


	INSERT INTO Consultorio (NumConsultorio, Descripcion, CodigoID, Activo)
    VALUES (@NumConsultorio, @Descripcion, @CodigoID, 1)

	IF @@ERROR != 0
	BEGIN
		RETURN -4 --NO SE DA DE ALTA
	END
	RETURN 1 --SE DIO DE ALTA
END
GO

CREATE PROCEDURE BajaLogicaConsultorio @CodigoID VARCHAR(6), @NumConsultorio INT AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Consultorio WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID AND Activo = 1)
    BEGIN       
        RETURN -1 -- NO EXISTE EL CONSULTORIO O TIENE BAJA LOGICA
    END

    IF EXISTS (SELECT 1 FROM Consulta WHERE CodigoID = @CodigoID AND NumConsultorio = @NumConsultorio)
    BEGIN
        UPDATE Consultorio
        SET Activo = 0
        WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID

        IF @@ERROR != 0
        BEGIN
            RETURN -2 -- ERROR AL DAR DE BAJA LÓGICA
        END

        RETURN 1 -- SE DIO DE BAJA LÓGICA
    END
    ELSE
    BEGIN
        DELETE FROM Consultorio 
        WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID

        IF @@ERROR != 0
        BEGIN
            RETURN -3 -- ERROR AL DAR DE BAJA FÍSICA
        END

        RETURN 1 -- SE DIO DE BAJA FÍSICA
    END


END
GO

CREATE PROCEDURE ModificarConsultorio @NumConsultorio INT, @Descripcion VARCHAR(100), @CodigoID VARCHAR(6) AS
BEGIN
        IF NOT EXISTS (SELECT 1 FROM Consultorio WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID AND Activo = 1)
        BEGIN          
            RETURN -1 -- NO EXISTE EL CONSULTORIO O TIENE BAJA LÓGICA
        END

        UPDATE Consultorio
        SET Descripcion = @Descripcion
        WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID AND Activo = 1

        IF @@ERROR != 0
        BEGIN
            ROLLBACK TRANSACTION            
            RETURN -2 -- ERROR AL MODIFICAR
        END
		return 1 -- MODIFICADO
END
GO

CREATE PROCEDURE BuscarConsultorio @NumConsultorio INT, @CodigoID VARCHAR(6) AS
BEGIN
	SELECT * FROM Consultorio WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID 
END
GO

CREATE PROCEDURE BuscarConsultorioActivo @NumConsultorio INT, @CodigoID VARCHAR(6) AS
BEGIN
	SELECT * FROM Consultorio WHERE NumConsultorio = @NumConsultorio AND CodigoID = @CodigoID AND Activo = 1
END
GO
-----------------------------FIN CONSULTORIO------------------------------------------------------------ CORRECTO corregido

-----------------------------PACIENTE------------------------------------------------------------
CREATE PROCEDURE AltaPaciente @Cedula INT, @Nombre VARCHAR(50), @FechaNac DATETIME AS
BEGIN
	IF EXISTS (SELECT 1 FROM Paciente WHERE Cedula = @Cedula AND Activo = 1)
		RETURN -1 --EL PACIENTE EXISTE ACTIVO

	IF EXISTS (SELECT 1 FROM Paciente WHERE Cedula = @Cedula AND Activo = 0)
	BEGIN
		UPDATE Paciente
		SET Nombre = @Nombre, FechaNac = @FechaNac, Activo = 1
		WHERE Cedula = @Cedula 

		IF @@ERROR != 0
		BEGIN
			RETURN -2 --NO SE REACTIVA
		END
		RETURN 2 -- SE REACTIVA
	END


	INSERT Paciente (Cedula, Nombre, FechaNac, Activo) VALUES (@Cedula, @Nombre, @FechaNac, 1)

	IF @@ERROR != 0
		BEGIN
			RETURN -2 --NO SE DIO DE ALTA
		END
		RETURN 1 -- ALTA CON EXITO
END
GO

CREATE PROCEDURE BajaLogicaPaciente @Cedula INT AS
BEGIN

        IF NOT EXISTS (SELECT 1 FROM Paciente WHERE Cedula = @Cedula AND Activo = 1)
        BEGIN
            RETURN -1 -- NO EXISTE EL PACIENTE O YA TIENE BAJA LÓGICA
        END
	BEGIN TRY
        BEGIN TRANSACTION



        IF EXISTS (SELECT 1 FROM Solicitud WHERE Cedula = @Cedula)
        BEGIN
            UPDATE Paciente
            SET Activo = 0
            WHERE Cedula = @Cedula

            COMMIT TRANSACTION
            RETURN 1 -- SE DIO DE BAJA LÓGICA
        END
        ELSE
        BEGIN
			DELETE FROM Patologias
			WHERE Cedula = @Cedula

            DELETE FROM Paciente
            WHERE Cedula = @Cedula 

            COMMIT TRANSACTION
            RETURN 1 -- SE DIO DE BAJA FÍSICA
        END
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        RETURN -4 -- ERROR
    END CATCH
END
GO

CREATE PROCEDURE ModificarPaciente @Cedula INT, @Nombre VARCHAR(50), @FechaNac DATETIME AS
BEGIN 
	IF NOT EXISTS (SELECT 1 FROM Paciente WHERE Cedula = @Cedula AND Activo = 1)
		RETURN -1 --NO EXISTE O TIENE BAJA LOGICA

	UPDATE Paciente
	SET Nombre = @Nombre,
	FechaNac = @FechaNac
	WHERE Cedula = @Cedula AND Activo = 1

	IF @@ERROR != 0
		BEGIN
			RETURN -2 --NO SE MODIFICO
		END
		RETURN 1 -- MODIFICADO
END
GO

CREATE PROCEDURE BuscarPaciente @Cedula INT AS
BEGIN
	SELECT * FROM Paciente WHERE Cedula = @Cedula 
END
GO

CREATE PROCEDURE BuscarPacienteActivo @Cedula INT AS
BEGIN
	SELECT * FROM Paciente WHERE Cedula = @Cedula AND Activo = 1
END
GO
-----------------------------FIN PACIENTE------------------------------------------------------------ CORRECTO corregido

-----------------------------PATOLOGIAS-----------------------------------------------------------
CREATE PROCEDURE AltaPatologia @Cedula int, @Patologias VARCHAR(50) AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Paciente WHERE Cedula = @Cedula AND Activo = 1)
    BEGIN
        RETURN -1 -- NO EXISTE EL PACIENTE O TIENE BAJA LOGICA
    END

    IF NOT EXISTS (SELECT 1 FROM Patologias WHERE Cedula = @Cedula AND Patologias = @Patologias)
    BEGIN
        INSERT  Patologias (Patologias, Cedula) VALUES (@Patologias, @Cedula)
    END

    IF @@ERROR != 0
    BEGIN
        RETURN -2 -- ERROR
    END

    RETURN 1 -- SE DIO DE ALTA
END
GO

CREATE PROCEDURE PatologiasDeUnPaciente  @Cedula INT AS
BEGIN 
	SELECT * FROM Patologias WHERE Cedula = @Cedula
END
GO

CREATE PROCEDURE EliminarPatologiasDePaciente @Cedula INT AS
BEGIN
	DELETE FROM Patologias WHERE Cedula = @Cedula
END
go
-----------------------------FIN PATOLOGIAS-----------------------------------------------------------

USE master
go
 
CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS 
go
 
USE MutualistWebsite
go
 
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
go
 
-- agregar permiso 
GRANT EXECUTE TO [IIS APPPOOL\DefaultAppPool]
go
