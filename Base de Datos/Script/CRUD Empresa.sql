USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_ListarEmpresa
AS
BEGIN
	BEGIN TRY
		SELECT idEmpresa AS ID,
			   numeroRuc AS RUC,
			   nombreEmpresa AS EMPRESA,
			   telefonoEmpresa AS TELEFONO,
			   direccion AS DIRECCION
		FROM empresa
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


CREATE OR ALTER PROC sp_EditarEmpresa
@NumeroRuc VARCHAR(20),
@NombreEmpresa VARCHAR(250),
@Telefono VARCHAR(15),
@Direccion VARCHAR(500),
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY

		IF EXISTS (SELECT 1 FROM empresa WHERE idEmpresa = 1)
		BEGIN

			UPDATE empresa
			SET numeroRuc = @NumeroRuc,
				nombreEmpresa = @NombreEmpresa,
				telefonoEmpresa = @Telefono,
				direccion = @Direccion
			WHERE idEmpresa = 1
		END
		ELSE
		BEGIN

			INSERT INTO empresa(idEmpresa, numeroRuc, nombreEmpresa, telefonoEmpresa, direccion)
			VALUES (1,
				    @NumeroRuc,
				    @NombreEmpresa,
					@Telefono,
					@Direccion);
		END

		SET @Respuesta = 1	
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		IF XACT_STATE() <> 0
			ROLLBACK TRANSACTION;

		SET @Respuesta = 0

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
		THROW 50004, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END;