USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_ListarUsuarios
AS
BEGIN
	BEGIN TRY
		SELECT u.idUsuario AS ID,
			   u.dniUsuario AS IDENTIFICACION,
			   u.nombreUsuario AS USUARIO,
			   u.codigoUsuario AS CODIGO,
			   u.email AS EMAIL,
			   r.nombreRol AS ROL
		FROM usuarios u
		INNER JOIN roles r ON u.idRol = r.idRol
		WHERE u.estado = 1
		ORDER BY u.idUsuario ASC 
	END TRY

	BEGIN CATCH
		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al listar los registros. Detalles: ' + @Error_Menssaje;
		THROW 50001, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_BuscarUsuarios
@nombre VARCHAR(75)
AS
BEGIN
	BEGIN TRY
		SELECT u.idUsuario AS ID,
			   u.dniUsuario AS IDENTIFICACION,
			   u.nombreUsuario AS USUARIO,
			   u.codigoUsuario AS CODIGO,
			   u.email AS EMAIL,
			   r.nombreRol AS ROL
		FROM usuarios u
		INNER JOIN roles r ON u.idRol = r.idRol
		WHERE ((u.nombreUsuario LIKE + '%' + @nombre + '%') AND u.estado = 1)
		ORDER BY u.idUsuario ASC 
	END TRY

	BEGIN CATCH
		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al listar los registros. Detalles: ' + @Error_Menssaje;
		THROW 50001, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_BuscarSupervisor
@Codigo CHAR(10)
AS
BEGIN
	BEGIN TRY
		SELECT u.idUsuario AS ID,
			   u.nombreUsuario AS USUARIO,
			   u.codigoUsuario AS CODIGO
		FROM usuarios u
		INNER JOIN roles r on u.idRol = r.idRol
		WHERE u.estado = 1 AND r.nombreRol = 'Supervisor' AND codigoUsuario = @Codigo
		ORDER BY u.idUsuario ASC
	END TRY

	BEGIN CATCH
		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al listar los usuarios. Detalles: ' + @Error_Menssaje;
		THROW 50001, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_ListarRoles
AS
BEGIN
	BEGIN TRY
		SELECT idRol AS ID,
			   nombreRol AS ROL
		FROM roles 
		ORDER BY idRol ASC 
	END TRY

	BEGIN CATCH
		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al listar los registros. Detalles: ' + @Error_Menssaje;
		THROW 50001, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_RegistrarUsuarios
@DniUsuario VARCHAR(17),
@Usuario VARCHAR(75),
@Email VARCHAR(200),
@IdRol INT,
@Codigo VARCHAR(10),
@Clave VARCHAR(MAX),
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO usuarios(dniUsuario, nombreUsuario, email, idRol, codigoUsuario, clave)
		VALUES(@DniUsuario,
			   @Usuario,
			   @Email,
			   @IdRol,
			   @Codigo,
			   ENCRYPTBYPASSPHRASE('desarrollo_aplicaciones_III', @Clave))

		SET @Respuesta = 1;
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		IF XACT_STATE() <> 0
			ROLLBACK TRANSACTION
		
		SET @Respuesta = 0;

		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al agregar el registro. Detalles: ' + @Error_Menssaje;
		THROW 50003, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_ActualizarUsuarios
@IdUsuario INT,
@DniUsuario VARCHAR(17),
@Usuario VARCHAR(75),
@Email VARCHAR(200),
@IdRol INT,
@Codigo VARCHAR(10),
@Clave VARCHAR(MAX),
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
	
		UPDATE usuarios
		SET dniUsuario = @DniUsuario,
			nombreUsuario = @Usuario,
			email = @Email,
			idRol = @IdRol,
			codigoUsuario = @Codigo,
			clave = ENCRYPTBYPASSPHRASE('desarrollo_aplicaciones_III', @Clave)
		WHERE idUsuario = @IdUsuario

		SET @Respuesta = 1;
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		IF XACT_STATE() <> 0
			ROLLBACK TRANSACTION
		
		SET @Respuesta = 0;

		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al editar el registro. Detalles: ' + @Error_Menssaje;
		THROW 50003, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_EliminarUsuarios
@IdUsuario INT,
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
	
		UPDATE usuarios
		SET estado = 0

		SET @Respuesta = 1;
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		IF XACT_STATE() <> 0
			ROLLBACK TRANSACTION
		
		SET @Respuesta = 0;

		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al eliminar el registro. Detalles: ' + @Error_Menssaje;
		THROW 50003, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC spLoginUsuarios
@Email VARCHAR(200),
@Clave VARCHAR(MAX)
AS
BEGIN
	BEGIN TRY
		SELECT u.IdUsuario, u.nombreUsuario, r.nombreRol
		FROM usuarios u
		INNER JOIN roles r ON r.idRol = u.idRol
		WHERE email = @Email		
		AND Estado = 1
		AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('desarrollo_aplicaciones_III', Clave)) = @Clave;
	END TRY

		BEGIN CATCH
		DECLARE @Error_Menssaje VARCHAR(5000),
			    @Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000)

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje,
			   @Error_Severidad,
			   @Error_Estado,
			   @Error_sp)

		SET @Mensaje_Devuelto = 'Error al autenticar usuario. Detalles: ' + @Error_Menssaje;
		THROW 50001, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO