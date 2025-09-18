USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_ListarPedidos
AS
BEGIN
	BEGIN TRY
		SELECT p.idPedido AS ID,
			   c.numeroCaja AS CAJA,
			   u.nombreUsuario AS USUARIO,
			   CAST(p.fechaPedido AS DATE) AS FECHA,
			   p.numeroPedido AS PEDIDO,
			   p.subTotal AS SUBTOTAL,
			   p.impuesto AS IMPUESTO,
			   p.totalGeneral AS TOTAL			   
		FROM pedidos p
		INNER JOIN usuarios u ON p.idUsuario = u.idUsuario
		INNER JOIN caja c ON c.idCaja = p.idCaja
		ORDER BY p.idPedido ASC
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
END;
GO


CREATE OR ALTER PROC sp_BuscarPedidos
@Pedido VARCHAR(20)
AS
BEGIN
	BEGIN TRY
		SELECT p.idPedido AS ID,
			   c.numeroCaja AS CAJA,
			   u.nombreUsuario AS USUARIO,
			   CAST(p.fechaPedido AS DATE) AS FECHA,
			   p.numeroPedido AS PEDIDO,
			   p.subTotal AS SUBTOTAL,
			   p.impuesto AS IMPUESTO,
			   p.totalGeneral AS TOTAL			   
		FROM pedidos p
		INNER JOIN usuarios u ON p.idUsuario = u.idUsuario
		INNER JOIN caja c ON c.idCaja = p.idCaja
		WHERE p.numeroPedido = @Pedido
		ORDER BY p.idPedido ASC
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
END;
GO


CREATE OR ALTER PROC sp_BuscarDetallePedidos
@IdPedido INT
AS
BEGIN
	BEGIN TRY
		SELECT idPedido AS ID,
			   idProducto,
			   nombreProducto AS PRODUCTO,
			   cantidad AS CANTIDAD,
			   precio AS PRECIO
		FROM detallePedidos
		WHERE idPedido = @IdPedido
		ORDER BY idDetallePedido ASC
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
END;
GO


CREATE OR ALTER PROC sp_ImprimirPedido
@IdPedido INT
AS
BEGIN
	BEGIN TRY
		SELECT p.numeroPedido,
			   CAST(p.fechaPedido AS DATE) AS Fecha,
			   d.cantidad,
			   d.nombreProducto,
			   d.precio,
			   p.subTotal,
			   p.impuesto,
			   p.totalGeneral,
			   u.nombreUsuario AS Usuario
		FROM pedidos p
		INNER JOIN detallePedidos d ON d.idPedido = p.idPedido
		INNER JOIN usuarios u ON p.idUsuario = u.idUsuario
		WHERE p.idPedido = @IdPedido
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

		SET @Mensaje_Devuelto = 'Error al imprimir el registro. Detalles: ' + @Error_Menssaje;
		THROW 50003, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END;
GO


CREATE TYPE detallePedido AS TABLE(
idProducto INT,
cantidad INT,
nombreProducto VARCHAR(100),
precio DECIMAL(11,2),
stock INT,
impuesto CHAR(1)
);
GO


CREATE OR ALTER PROC sp_RegistrarPedido
@IdUsuario INT,
@IdCaja INT,
@SubTotal DECIMAL(11,2),
@Impuesto DECIMAL(11,2),
@Total DECIMAL(11,2),
@MontoEfectivo DECIMAL(11,2),
@MontoTarjeta DECIMAL(11,2),
@Cambio DECIMAL(11,2),
@Detalles detallePedido READONLY,
@Respuesta INT OUTPUT,
@Pedido VARCHAR(20) OUTPUT
AS
BEGIN
	DECLARE @IdPedido INT;
	DECLARE @NumeroDocumento INT;	

	BEGIN TRANSACTION
	BEGIN TRY
		-- Bloqueo con ROWLOCK y UPDLOCK para evitar condiciones de carrera
		IF EXISTS (SELECT 1 FROM documentos WITH (ROWLOCK, UPDLOCK) WHERE TipoDocumento = 'Pedido')
		BEGIN
			-- Obtener el valor actual con bloqueo para asegurar atomicidad
			SELECT @NumeroDocumento = numeroDocumento + 1
			FROM documentos WITH (ROWLOCK, UPDLOCK)
			WHERE TipoDocumento = 'Pedido';

			-- Actualizar el nuevo número
			UPDATE documentos
			SET numeroDocumento = @NumeroDocumento
			WHERE TipoDocumento = 'Pedido';
		END
		ELSE
		BEGIN
			-- Insertar el primer valor si no existe
			SET @NumeroDocumento = 1;

			INSERT INTO documentos (TipoDocumento, numeroDocumento)
			VALUES ('Pedido', @NumeroDocumento);
		END

		-- Formatear el número de pedido
		SET @Pedido = RIGHT('0000' + CAST(@NumeroDocumento AS VARCHAR), 4);

		INSERT INTO pedidos(idUsuario, idCaja, numeroPedido, subTotal, impuesto, totalGeneral, montoEfectivo, montoTarjeta, cambio)
		VALUES(@IdUsuario,
			   @IdCaja,
			   @Pedido,
			   @SubTotal,
			   @Impuesto,
			   @Total,
			   @MontoEfectivo,
			   @MontoTarjeta,
			   @Cambio);

		-- Capturar el último idPedido generado
		SET @IdPedido = SCOPE_IDENTITY();

		-- Insertar en la tabla detalle de pedidos
		INSERT INTO detallePedidos(idPedido, idProducto, cantidad, nombreProducto, precio)
		SELECT @IdPedido, idProducto, cantidad, nombreProducto, precio
		FROM @Detalles

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

		SET @Mensaje_Devuelto = 'Error al agregar el registro. Detalles: ' + @Error_Menssaje;
		THROW 50004, @Mensaje_Devuelto, @Error_Estado;
	END CATCH
END;
GO


--> TRIGGER
CREATE OR ALTER TRIGGER trg_ActualizarStock
ON dbo.detallePedidos
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Actualizar stock
    UPDATE p
    SET p.stocK = p.stocK - i.cantidad
    FROM productos p
    INNER JOIN inserted i ON p.idProducto = i.idProducto;

    -- 2. Insertar movimiento en detalleKardex
    INSERT INTO detalleKardex(idKardex, fecha, referencia, tipoOperacion, salida, costoSalida,
		                      totalSalida, existencia, promedio, costoExistencia, idUsuario)
    SELECT
        k.idKardex,
        GETDATE(),
        ped.numeroPedido,                      -- Referencia: número del pedido
        'Salida por venta',
        i.cantidad,
        p.precioCompra,
        i.cantidad * p.precioCompra,
        p.stocK,
        p.precioCompra,
        p.stocK * p.precioCompra,
        ped.idUsuario                          -- Usuario que realizó la venta
    FROM inserted i
    INNER JOIN productos p ON p.idProducto = i.idProducto
    INNER JOIN kardex k ON k.idProducto = i.idProducto AND k.estado = 1
    INNER JOIN pedidos ped ON i.idPedido = ped.idPedido;
END;
GO
