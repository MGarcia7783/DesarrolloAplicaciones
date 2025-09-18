USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_ListarLaboratorio
AS
BEGIN
	BEGIN TRY
		SELECT idLaboratorio AS ID,
			   nombreLaboratorio AS LABORATORIO,
			   email AS EMAIL,
			   telefono AS TELEFONO,
			   contacto AS CONTACTO
		FROM laboratorios
		WHERE estado = 1
		ORDER BY nombreLaboratorio ASC
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


CREATE OR ALTER PROC sp_BuscarLaboratorio
@Valor VARCHAR(50)
AS
BEGIN
	BEGIN TRY
		SELECT idLaboratorio AS ID,
			   nombreLaboratorio AS LABORATORIO,
			   email AS EMAIL,
			   telefono AS TELEFONO,
			   contacto AS CONTACTO
		FROM laboratorios
		WHERE ((nombreLaboratorio LIKE '%' + @Valor + '%') AND estado = 1)
		ORDER BY nombreLaboratorio ASC
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

		SET @Mensaje_Devuelto = 'Error al buscar el registro. Detalles: ' + @Error_Menssaje;
		THROW 50002, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_RegistrarLaboratorio
@Laboratorio VARCHAR(20),
@Email VARCHAR(200),
@Telefono VARCHAR(15),
@Contacto VARCHAR(50),
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO laboratorios(nombreLaboratorio, email, telefono, contacto)
		VALUES(@Laboratorio,
			   @Email,
			   @Telefono,
			   @Contacto)

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


CREATE OR ALTER PROC sp_EditarLaboratorio
@idLaboratorio INT,
@Laboratorio VARCHAR(20),
@Email VARCHAR(200),
@Telefono VARCHAR(15),
@Contacto VARCHAR(50),
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE laboratorios
		SET nombreLaboratorio = @Laboratorio,
			email = @Email,
			telefono = @Telefono,
			contacto = @Contacto
		WHERE idLaboratorio = @idLaboratorio

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

		SET @Mensaje_Devuelto = 'Error al actualizar el registro. Detalles: ' + @Error_Menssaje;
		THROW 50004, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO


CREATE OR ALTER PROC sp_EliminarLaboratorio
@IdLaboratorio INT,
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE laboratorios
		SET estado = 0
		WHERE idLaboratorio = @IdLaboratorio

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
		THROW 50005, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO