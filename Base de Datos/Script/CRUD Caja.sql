USE GestionFarmaciaDB
GO

CREATE OR ALTER PROC sp_ListarCaja
AS
BEGIN
	BEGIN TRY
		SELECT idCaja AS ID,
			   numeroCaja AS CAJA,
			   u.nombreUsuario AS USUARIO,
			   fechaApertura AS APERTURA,
			   fechaCierre AS CIERRE,
			   montoApertura AS INICIA,
			   totalEfectivo AS EFECTIVO,
			   totalTarjeta AS TARJETA,
			   totalCambio AS CAMBIO,
			   totalEntregado AS ENTREGADO,
			   c.estado AS ESTADO,
			   supervisor AS SUPERVISOR,
			   observaciones AS OBSERVACION
		FROM caja c
		INNER JOIN usuarios u ON c.idUsuario = u.idUsuario
		WHERE c.estado = 'Cerrada'
		ORDER BY c.idCaja ASC
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


CREATE OR ALTER PROC sp_BuscarCaja
@IdUsuario INT
AS
BEGIN
	BEGIN TRY
		SELECT idCaja AS ID,
			   montoApertura AS INICIA,
			   numeroCaja AS CAJA
		FROM caja
		WHERE idUsuario = @IdUsuario AND estado = 'Abierta'
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


CREATE OR ALTER PROC sp_BuscarCajaporFecha
@FechaInicio DATETIME,
@FechaFinal DATETIME
AS
BEGIN
	BEGIN TRY
		SELECT idCaja AS ID,
			   numeroCaja AS CAJA,
			   u.nombreUsuario AS USUARIO,
			   fechaApertura AS APERTURA,
			   fechaCierre AS CIERRE,
			   montoApertura AS INICIA,
			   totalEfectivo AS EFECTIVO,
			   totalTarjeta AS TARJETA,
			   totalCambio AS CAMBIO,
			   totalEntregado AS ENTREGADO,
			   c.estado AS ESTADO,
			   supervisor AS SUPERVISOR,
			   observaciones AS OBSERVACION
		FROM caja c
		INNER JOIN usuarios u ON c.idUsuario = u.idUsuario
		WHERE (CAST(fechaApertura AS DATE) BETWEEN @FechaInicio AND @FechaFinal) AND c.estado = 'Cerrada'
		ORDER BY c.idCaja ASC
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


CREATE OR ALTER PROC sp_AbrirCaja
@IdUsuario INT,
@NumeroCaja INT,
@MontoApertura DECIMAL(11,2),
@IdCaja INT OUTPUT,
@Respuesta INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Validar que no exista ya una caja abierta para este usuario
        IF EXISTS (
            SELECT 1
            FROM caja
            WHERE idUsuario = @IdUsuario AND estado = 'Abierta'
        )
        BEGIN
            SET @Respuesta = 0;
            THROW 50001, 'Ya existe una caja abierta para este usuario.', 1;
        END

		IF EXISTS (
            SELECT 1
            FROM caja
            WHERE numeroCaja = @NumeroCaja AND estado = 'Abierta'
        )
        BEGIN
            SET @Respuesta = 0;
            THROW 50001, 'Esta caja se ecnuentra abierta.', 1;
        END

        -- Insertar la nueva caja
        INSERT INTO caja(numeroCaja, montoApertura, estado, idUsuario)
        VALUES(@NumeroCaja, @MontoApertura, 'Abierta', @IdUsuario);

        SET @IdCaja = SCOPE_IDENTITY();

        SET @Respuesta = 1;
        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        SET @Respuesta = 0;

        DECLARE @Error_Menssaje VARCHAR(5000),
                @Error_Severidad INT,
                @Error_Estado INT,
                @Error_sp VARCHAR(255),
                @Mensaje_Devuelto VARCHAR(5000);

        SELECT @Error_Menssaje = ERROR_MESSAGE(),
               @Error_Severidad = ERROR_SEVERITY(),
               @Error_Estado = ERROR_STATE(),
               @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido');

        INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
        VALUES(@Error_Menssaje,
               @Error_Severidad,
               @Error_Estado,
               @Error_sp);

        SET @Mensaje_Devuelto = 'Error al abrir caja. Detalles:' 
                      + CHAR(13) + CHAR(10) 
                      + @Error_Menssaje;

        THROW 50002, @Mensaje_Devuelto, @Error_Estado;
    END CATCH
END
GO


CREATE OR ALTER PROC sp_CerrarCaja
@IdCaja INT,
@Efectivo DECIMAL(11,2),
@Tarjeta DECIMAL(11,2),
@Cambio DECIMAL(11,2),
@Entregado DECIMAL(11,2),
@Codigo CHAR(10),
@Observacion VARCHAR(250),
@Respuesta INT OUTPUT,
@Supervisor VARCHAR(100) OUTPUT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

		-- Validar existencia del supervisor por código
		IF NOT EXISTS (
			SELECT 1
			FROM usuarios u
			INNER JOIN roles r ON u.idRol = r.idRol
			WHERE u.codigoUsuario = @Codigo AND r.nombreRol = 'Supervisor'
		)
			THROW 50000, 'El código del supervisor no es válido.', 1;
		ELSE
		BEGIN
			SELECT @Supervisor = nombreUsuario
			FROM usuarios u
			INNER JOIN roles r ON u.idRol = r.idRol
			WHERE u.codigoUsuario = @Codigo AND r.nombreRol = 'Supervisor';
		END


        -- Verificar que exista la caja y que esté abierta
        IF NOT EXISTS (
            SELECT 1 FROM caja
            WHERE idCaja = @IdCaja AND estado = 'Abierta'
        )
        BEGIN
            SET @Respuesta = 0;
            THROW 50005, 'La caja no existe o ya está cerrada.', 1;
        END

        -- Actualizar la caja con cierre
        UPDATE caja
        SET fechaCierre = GETDATE(),
            totalEfectivo = @Efectivo,
			totalTarjeta = @Tarjeta,
			totalCambio = @Cambio,
			totalEntregado = @Entregado,
			supervisor = @Supervisor,
            estado = 'Cerrada',
			observaciones = @Observacion
        WHERE idCaja = @IdCaja;

        SET @Respuesta = 1;
        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        SET @Respuesta = 0;

        DECLARE @Error_Mensaje VARCHAR(5000),
                @Error_Severidad INT,
                @Error_Estado INT,
                @Error_SP VARCHAR(255),
                @Mensaje_Devuelto VARCHAR(5000);

        SELECT @Error_Mensaje = ERROR_MESSAGE(),
               @Error_Severidad = ERROR_SEVERITY(),
               @Error_Estado = ERROR_STATE(),
               @Error_SP = ISNULL(ERROR_PROCEDURE(), 'Desconocido');

        INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
        VALUES(@Error_Mensaje, @Error_Severidad, @Error_Estado, @Error_SP);

        SET @Mensaje_Devuelto = 'Error al cerrar la caja. Detalles: ' + @Error_Mensaje;
        THROW 50006, @Mensaje_Devuelto, @Error_Estado;
    END CATCH
END
GO


CREATE OR ALTER PROC sp_SumarTotales
@IdUsuario INT
AS
BEGIN
	BEGIN TRY
		DECLARE @IdCaja INT;

		-- Buscar la caja abierta del usuario
		SELECT @IdCaja = idCaja
		FROM caja
		WHERE idUsuario = @IdUsuario AND estado = 'Abierta';

		IF @IdCaja IS NULL
			THROW 50001, 'No hay caja abierta para este usuario.', 1;

		SELECT
			ISNULL(SUM(montoEfectivo), 0) AS TOTAL_EFECTIVO,
			ISNULL(SUM(montoTarjeta), 0) AS TOTAL_TARJETA,
			ISNULL(SUM(cambio), 0) AS TOTAL_CAMBIO
		FROM pedidos
		WHERE idCaja = @IdCaja
		  AND idUsuario = @IdUsuario
		  AND estado = 1;
	END TRY

	BEGIN CATCH
		DECLARE @Error_Menssaje VARCHAR(5000),
				@Error_Severidad INT,
				@Error_Estado INT, 
				@Error_sp VARCHAR(255),
				@Mensaje_Devuelto VARCHAR(5000);

		SELECT @Error_Menssaje = ERROR_MESSAGE(),
			   @Error_Severidad = ERROR_SEVERITY(),
			   @Error_Estado = ERROR_STATE(),
			   @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido');

		INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
		VALUES(@Error_Menssaje, @Error_Severidad, @Error_Estado, @Error_sp);

		SET @Mensaje_Devuelto = 'Error al sumar los totales. Detalles: ' + @Error_Menssaje;
		THROW 50003, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END
GO