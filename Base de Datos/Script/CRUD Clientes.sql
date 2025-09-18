USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_ListarClientes
AS
BEGIN
	BEGIN TRY
		SELECT idCliente AS ID,
			   dniCliente AS IDENTIFICACION,
			   razonSocial AS RAZON_SOCIAL,
			   telefono AS TELEFONO
		FROM clientes
		WHERE estado = 1
		ORDER BY razonSocial ASC
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


CREATE OR ALTER PROC sp_BuscarClientes
@Valor VARCHAR(100)
AS
BEGIN
	BEGIN TRY
		SELECT idCliente AS ID,
			   dniCliente AS IDENTIFICACION,
			   razonSocial AS RAZON_SOCIAL,
			   telefono AS TELEFONO
		FROM clientes
		WHERE ((razonSocial LIKE '%' + @Valor + '%') AND estado = 1)
		ORDER BY razonSocial ASC
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


CREATE OR ALTER PROC sp_RegistrarCliente
@DniCliente VARCHAR(16),
@RazonSocial VARCHAR(100),
@Telefono VARCHAR(15),
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO clientes(dniCliente, razonSocial, telefono)
		VALUES(@DniCliente,
			   @RazonSocial,
			   @Telefono)

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


CREATE OR ALTER PROC sp_EditarCliente
@IdCliente INT,
@DniCliente VARCHAR(16),
@RazonSocial VARCHAR(100),
@Telefono VARCHAR(15),
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE clientes
		SET dniCliente = @DniCliente,
			razonSocial = @RazonSocial,
			telefono = @Telefono
			WHERE idCliente = @IdCliente

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


CREATE OR ALTER PROC sp_EliminarCliente
@IdCliente INT,
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE clientes
		SET estado = 0
			WHERE idCliente = @IdCliente

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