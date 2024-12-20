CREATE DATABASE sistema_de_mantenimiento;
USE sistema_de_mantenimiento;

-- Tabla Usuarios
CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY, 
    nombre NVARCHAR(50) NOT NULL, 
    correo NVARCHAR(50) UNIQUE NOT NULL,
    contraseña NVARCHAR(255) NOT NULL, 
    rol NVARCHAR(10) DEFAULT 'usuario', 
    fecha_creacion DATETIME DEFAULT GETDATE() 
);

-- Tabla Equipos
CREATE TABLE Equipos (
    id_equipo INT IDENTITY(1,1) PRIMARY KEY, 
    nombre_equipo NVARCHAR(50) NOT NULL, 
    descripcion NVARCHAR(MAX), 
    estado NVARCHAR(20) DEFAULT 'operativo', 
    fecha_registro DATETIME DEFAULT GETDATE(), 
    id_usuario INT, -- Relación con Usuarios
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario) 
);

-- Tabla Técnicos
CREATE TABLE Tecnicos (
    id_tecnico INT IDENTITY(1,1) PRIMARY KEY, 
    nombre_tecnico NVARCHAR(50) NOT NULL, 
    especialidad NVARCHAR(100),
    id_equipo INT, 
    FOREIGN KEY (id_equipo) REFERENCES Equipos(id_equipo) 
);

-- Procedimiento para Crear Equipo
CREATE PROCEDURE CrearEquipo
    @nombre_equipo NVARCHAR(50),
    @descripcion NVARCHAR(MAX),
    @estado NVARCHAR(20) = 'operativo',
    @id_usuario INT = NULL -- Relación opcional con un usuario
AS
BEGIN
    INSERT INTO Equipos (nombre_equipo, descripcion, estado, id_usuario)
    VALUES (@nombre_equipo, @descripcion, @estado, @id_usuario);
END;

-- Procedimiento para Consultar Equipos
CREATE PROCEDURE ConsultarEquipos
    @id_equipo INT = NULL -- Opcional, si es NULL devuelve todos los equipos
AS
BEGIN
    IF @id_equipo IS NOT NULL
        SELECT * FROM Equipos WHERE id_equipo = @id_equipo;
    ELSE
        SELECT * FROM Equipos;
END;

-- Procedimiento para Actualizar Equipos
CREATE PROCEDURE ActualizarEquipo
    @id_equipo INT, -- Identificador del equipo
    @nombre_equipo NVARCHAR(50), -- Nuevo nombre del equipo
    @descripcion NVARCHAR(MAX), -- Nueva descripción
    @estado NVARCHAR(20), -- Nuevo estado del equipo
    @id_usuario INT -- Nuevo usuario responsable
AS
BEGIN
    UPDATE Equipos
    SET 
        nombre_equipo = @nombre_equipo,
        descripcion = @descripcion,
        estado = @estado,
        id_usuario = @id_usuario
    WHERE id_equipo = @id_equipo;
END;

-- Procedimiento para Eliminar Equipos
CREATE PROCEDURE EliminarEquipo
    @id_equipo INT
AS
BEGIN
    DELETE FROM Equipos WHERE id_equipo = @id_equipo;
END;


-- Procedimiento para Crear Técnico
CREATE PROCEDURE CrearTecnico
    @nombre_tecnico NVARCHAR(50),
    @especialidad NVARCHAR(100),
    @id_equipo INT = NULL -- Relación opcional con un equipo
AS
BEGIN
    INSERT INTO Tecnicos (nombre_tecnico, especialidad, id_equipo)
    VALUES (@nombre_tecnico, @especialidad, @id_equipo);
END;

-- Procedimiento para Consultar Técnicos
CREATE PROCEDURE ConsultarTecnicos
    @id_tecnico INT = NULL -- Opcional, si es NULL devuelve todos los técnicos
AS
BEGIN
    IF @id_tecnico IS NOT NULL
        SELECT * FROM Tecnicos WHERE id_tecnico = @id_tecnico;
    ELSE
        SELECT * FROM Tecnicos;
END;

-- Procedimiento para Actualizar Técnico
CREATE PROCEDURE ActualizarTecnico
    @id_tecnico INT, -- Identificador del técnico
    @nombre_tecnico NVARCHAR(50), -- Nuevo nombre
    @especialidad NVARCHAR(100), -- Nueva especialidad
    @id_equipo INT = NULL -- Nuevo equipo asignado (opcional)
AS
BEGIN
    UPDATE Tecnicos
    SET 
        nombre_tecnico = @nombre_tecnico,
        especialidad = @especialidad,
        id_equipo = @id_equipo
    WHERE id_tecnico = @id_tecnico;
END;

-- Procedimiento para Eliminar Técnico
CREATE PROCEDURE EliminarTecnico
    @id_tecnico INT
AS
BEGIN
    DELETE FROM Tecnicos WHERE id_tecnico = @id_tecnico;
END;