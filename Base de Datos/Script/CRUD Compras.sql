USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_ListarCompras
AS
BEGIN
	BEGIN TRY
		SELECT c.idCompra as ID,
			   u.nombreUsuario AS USUARIO,
			   c.numeroFactura AS FACTURA,
			   CAST(c.fechaCompra AS DATE) AS FECHA,
			   c.subTotal AS SUBTOTAL,
			   c.impuesto AS IMPUESTO,
			   c.totalGeneral AS TOTAL,
			   c.observacion AS OBSERVACION
		FROM compras c
		INNER JOIN usuarios u ON C.idUsuario = u.idUsuario
		ORDER BY C.idCompra ASC
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


CREATE OR ALTER PROC sp_BuscarCompras
@FechaInicio DATETIME = NULL,
@FechaFinal DATETIME = NULL
AS
BEGIN
	BEGIN TRY
		SELECT c.idCompra as ID,
			   u.nombreUsuario AS USUARIO,
			   c.numeroFactura AS FACTURA,
			   CAST(c.fechaCompra AS DATE) AS FECHA,
			   c.subTotal AS SUBTOTAL,
			   c.impuesto AS IMPUESTO,
			   c.totalGeneral AS TOTAL,
			   c.observacion AS OBSERVACION
		FROM compras c
		INNER JOIN usuarios u ON C.idUsuario = u.idUsuario
		WHERE (CAST(c.fechaCompra AS DATE) BETWEEN @FechaInicio AND @FechaFinal)
		ORDER BY c.idCompra ASC
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


CREATE OR ALTER PROC sp_BuscarDetalleCompras
@IdCompra INT
AS
BEGIN
	BEGIN TRY
		SELECT idCompra AS ID,
			   idProducto,
			   nombreProducto AS PRODUCTO,
			   cantidad AS CANTIDAD,
			   precioCompra AS P_COMPRA,
			   precioVenta AS P_VENTA
		FROM detalleCompras
		WHERE idCompra = @IdCompra
		ORDER BY idDetalles ASC
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


CREATE TYPE detalleCompra AS TABLE(
idProducto INT,
nombreProducto VARCHAR(100),
cantidad INT,
precioCompra DECIMAL(11,2),
precioVenta DECIMAL(11,2),
impuesto CHAR(1)
);
GO


CREATE OR ALTER PROC sp_RegistrarCompra
@NumeroFactura CHAR(20),
@FechaCompra DATETIME,
@Observacion VARCHAR(250),
@SubTotal DECIMAL(11,2),
@Impuesto DECIMAL(11,2),
@TotalGeneral DECIMAL(11,2),
@IdUsuario INT,
@Detalles detalleCompra READONLY,
@Respuesta INT OUTPUT
AS
BEGIN
	
	DECLARE @IdCompra INT;

	BEGIN TRANSACTION
	BEGIN TRY

		INSERT INTO compras(numeroFactura, fechaCompra, observacion, subTotal, impuesto, totalGeneral, idUsuario)
		VALUES(@NumeroFactura,
			   @FechaCompra,
			   @Observacion,
			   @SubTotal,
			   @Impuesto,
			   @TotalGeneral,
			   @IdUsuario);

		SET @IdCompra = SCOPE_IDENTITY();

		-- Insertar en la tabla detalle de pedidos
		INSERT INTO detalleCompras(idCompra, idProducto, nombreProducto, cantidad, precioCompra, precioVenta)
		SELECT @IdCompra, idProducto, nombreProducto, cantidad, precioCompra, precioVenta
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
CREATE OR ALTER TRIGGER trg_ActualizarStockCompra
ON dbo.detalleCompras
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Actualizar stock del producto (sumar la cantidad comprada)
    UPDATE p
    SET p.stocK = p.stocK + i.cantidad,
		p.precioCompra = i.precioCompra,
		p.precioVenta = i.precioVenta
    FROM productos p
    INNER JOIN inserted i ON p.idProducto = i.idProducto;

    -- 2. Insertar movimiento de entrada en detalleKardex
    INSERT INTO detalleKardex(
        idKardex, fecha, referencia, tipoOperacion, entrada, costoEntrada,
        totalEntrada, existencia, promedio, costoExistencia, idUsuario)
    SELECT
        k.idKardex,
        GETDATE(),
        c.numeroFactura,                
        'Entrada por compra',          
        i.cantidad,
        i.precioCompra,
        i.cantidad * i.precioCompra,
        p.stocK,          
        i.precioCompra,
        p.stocK * i.precioCompra,
        c.idUsuario
    FROM inserted i
    INNER JOIN productos p ON p.idProducto = i.idProducto
    INNER JOIN kardex k ON k.idProducto = i.idProducto AND k.estado = 1
    INNER JOIN compras c ON i.idCompra = c.idCompra;
END;
GO
