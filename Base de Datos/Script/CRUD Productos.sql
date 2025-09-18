USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_ListarTodosProductos
AS
BEGIN
	BEGIN TRY
		SELECT p.idProducto AS ID,
			   p.codigo AS CODIGO,
			   p.nombreProducto AS PRODUCTO,
			   p.formatoCompra AS FORMATO,
			   c.nombreCategoria AS CATEGORIA,
			   l.nombreLaboratorio AS LABORATORIO,
			   p.precioCompra AS P_COMPRA,
			   p.precioVenta AS P_VENTA,
			   p.stock AS STOCK,
			   p.stockMinimo AS MINIMO,
			   p.ventaReceta AS RECETA,
			   p.impuesto AS IMPUESTO,
			   P.tieneVencimiento,
			   P.fechaVencimiento AS VENCIMIENTO
			   			   		   
		FROM productos p
		INNER JOIN categorias c ON p.idCategoria = c.idCategoria
		INNER JOIN laboratorios l ON p.idLaboratorio = l.idLaboratorio
		WHERE P.estado = 1 AND p.fechaVencimiento > GETDATE()
		ORDER BY p.idProducto ASC
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


CREATE OR ALTER PROC sp_ListarProductos
AS
BEGIN
	BEGIN TRY
		SELECT p.idProducto AS ID,
			   p.codigo AS CODIGO,
			   p.nombreProducto AS PRODUCTO,
			   l.nombreLaboratorio AS LABORATORIO,
			   p.precioCompra AS P_COMPRA,
			   p.precioVenta AS P_VENTA,
			   p.stock AS STOCK,
			   p.impuesto AS IMPUESTO,
			   p.ventaReceta AS RECETA			   		   
		FROM productos p
		INNER JOIN laboratorios l ON p.idLaboratorio = l.idLaboratorio
		WHERE p.estado = 1 AND p.stock > 0 AND p.fechaVencimiento > GETDATE()
		ORDER BY p.idProducto ASC
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


CREATE OR ALTER PROC sp_BuscarTodosProductos
@Filtro INT,
@Valor VARCHAR(100)
AS
BEGIN
    BEGIN TRY
        IF @Filtro NOT IN (0, 1)
            THROW 50001, 'El filtro proporcionado no es válido. Debe ser 0 o 1.', 1;

        SELECT p.idProducto AS ID,
               p.codigo AS CODIGO,
               p.nombreProducto AS PRODUCTO,
               l.nombreLaboratorio AS LABORATORIO,
               p.precioCompra AS P_COMPRA,
			   p.precioVenta AS P_VENTA,
               p.stock AS STOCK,
               p.impuesto AS IMPUESTO,
               p.ventaReceta AS RECETA
        FROM productos p
        INNER JOIN laboratorios l ON p.idLaboratorio = l.idLaboratorio
        WHERE p.estado = 1
          AND p.fechaVencimiento > GETDATE()
          AND (
               (@Filtro = 0 AND p.codigo = @Valor)
            OR (@Filtro = 1 AND p.nombreProducto LIKE '%' + @Valor + '%')
          )
        ORDER BY p.idProducto ASC
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


CREATE OR ALTER PROC sp_BuscarProductos
@Filtro INT,
@Valor VARCHAR(100)
AS
BEGIN
    BEGIN TRY
        IF @Filtro NOT IN (0, 1)
            THROW 50001, 'El filtro proporcionado no es válido. Debe ser 0 o 1.', 1;

        SELECT p.idProducto AS ID,
               p.codigo AS CODIGO,
               p.nombreProducto AS PRODUCTO,
               l.nombreLaboratorio AS LABORATORIO,
			   p.precioCompra AS P_COMPRA,
               p.precioVenta AS P_VENTA,
               p.stock AS STOCK,
               p.impuesto AS IMPUESTO,
               p.ventaReceta AS RECETA
        FROM productos p
        INNER JOIN laboratorios l ON p.idLaboratorio = l.idLaboratorio
        WHERE p.estado = 1
          AND p.stock > 0
          AND p.fechaVencimiento > GETDATE()
          AND (
               (@Filtro = 0 AND p.codigo = @Valor)
            OR (@Filtro = 1 AND p.nombreProducto LIKE '%' + @Valor + '%')
          )
        ORDER BY p.idProducto ASC

    END TRY
    BEGIN CATCH
        DECLARE @Error_Mensaje VARCHAR(5000),
                @Error_Severidad INT,
                @Error_Estado INT, 
                @Error_sp VARCHAR(255),
                @Mensaje_Devuelto VARCHAR(5000)

        SELECT @Error_Mensaje = ERROR_MESSAGE(),
               @Error_Severidad = ERROR_SEVERITY(),
               @Error_Estado = ERROR_STATE(),
               @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido')

        INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
        VALUES(@Error_Mensaje, @Error_Severidad, @Error_Estado, @Error_sp)

        SET @Mensaje_Devuelto = 'Error al buscar el registro. Detalles: ' + @Error_Mensaje;
        THROW 50002, @Mensaje_Devuelto, @Error_Estado;
    END CATCH
END
GO


CREATE OR ALTER PROC sp_RegistrarProductos
@Codigo VARCHAR(20),
@Impuesto CHAR(1),
@Producto VARCHAR(100),
@Formato VARCHAR(10),
@IdCategoria INT,
@IdLaboratorio INT,
@Stock INT,
@StockMinimo INT,
@VentaReceta CHAR(2),
@PrecioCompra DECIMAL(11,2),
@PrecioVenta DECIMAL(11,2),
@TieneVencimiento BIT,
@Vencimiento DATETIME,
@Respuesta INT OUTPUT
AS
BEGIN

	DECLARE @FechaVencimiento DATETIME
	SET @FechaVencimiento = CASE WHEN @TieneVencimiento = 1 THEN @Vencimiento ELSE NULL END;

	BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO productos(codigo, impuesto, nombreProducto, formatoCompra, idCategoria, idLaboratorio, stocK, stockMinimo,
							  ventaReceta, tieneVencimiento, fechaVencimiento, precioCompra, precioVenta)
		VALUES(@Codigo,
			   @Impuesto,
			   @Producto,
			   @Formato,
			   @IdCategoria,
			   @IdLaboratorio,
			   @Stock,
			   @StockMinimo,
			   @VentaReceta,
			   @TieneVencimiento, 
			   @FechaVencimiento,
			   @PrecioCompra,
			   @PrecioVenta)

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


CREATE OR ALTER PROC sp_ActualizarProductos
@IdProducto INT,
@Codigo VARCHAR(20),
@Impuesto CHAR(1),
@Producto VARCHAR(100),
@Formato VARCHAR(10),
@IdCategoria INT,
@IdLaboratorio INT,
@Stock INT,
@StockMinimo INT,
@VentaReceta CHAR(2),
@PrecioCompra DECIMAL(11,2),
@PrecioVenta DECIMAL(11,2),
@TieneVencimiento BIT,
@Vencimiento DATETIME,
@Respuesta INT OUTPUT
AS
BEGIN

	DECLARE @FechaVencimiento DATETIME;
	SET @FechaVencimiento = CASE WHEN @TieneVencimiento = 1 THEN @Vencimiento ELSE NULL END;

	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE productos
		SET codigo = @Codigo,
			impuesto = @Impuesto,
		    nombreProducto = @Producto,
			formatoCompra = @Formato,
			idCategoria = @IdCategoria,
			idLaboratorio = @IdLaboratorio,
			stockMinimo = @StockMinimo,
			ventaReceta = @VentaReceta,
			precioCompra = @PrecioCompra,
			precioVenta = @PrecioVenta,
			tieneVencimiento = @TieneVencimiento,   
			fechaVencimiento = @FechaVencimiento
		WHERE idProducto = @IdProducto
		

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


CREATE OR ALTER PROC sp_EliminarProductos
@IdProducto INT,
@Respuesta INT OUTPUT
AS
BEGIN

	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE productos
		SET estado = 0
		WHERE idProducto = @IdProducto

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


CREATE OR ALTER PROC sp_BuscarKardex
@Codigo VARCHAR(20),
@Filtro BIT,
@FechaInicio DATETIME,
@FechaFinal DATETIME,
@Producto VARCHAR(100) OUT
AS
BEGIN
    BEGIN TRY
        DECLARE @IdProducto INT;
        DECLARE @IdKardex INT;

        -- Obtener idProducto
        SELECT @IdProducto = idProducto,
               @Producto = nombreProducto
        FROM productos
        WHERE codigo = @Codigo;

        IF @IdProducto IS NULL
            THROW 50000, 'El código de producto especificado no existe.', 1;

        -- Obtener idKardex
        SELECT TOP 1 @IdKardex = idKardex
        FROM kardex
        WHERE idProducto = @IdProducto;

        IF @IdKardex IS NULL
            THROW 50001, 'No hay un registro en kardex para este producto.', 1;

        -- Obtener detalles del kardex
        SELECT CAST(fecha AS DATE) AS FECHA,
			   referencia AS REFERENCIA,
			   tipoOperacion AS OPERACION,
			   entrada AS ENTRADA,
			   costoEntrada AS C_ENTRADA,
			   totalEntrada AS T_ENTRADA,
			   salida AS SALIDA,
			   costoSalida AS C_SALIDA,
			   totalSalida AS T_SALIDA,
			   existencia AS EXISTENCIA,
			   promedio AS PROMEDIO,
			   costoExistencia AS COSTO
		FROM detalleKardex
		WHERE idKardex = @IdKardex
		  AND (@Filtro = 0 OR 
		      (@Filtro = 1 AND CAST(fecha AS DATE) BETWEEN @FechaInicio AND @FechaFinal)); 
    END TRY

    BEGIN CATCH
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

        SET @Mensaje_Devuelto = 'Error al buscar el producto. Detalles: ' + @Error_Mensaje;
        THROW 50006, @Mensaje_Devuelto, @Error_Estado;
    END CATCH
END
GO


--> TRIGGRER
CREATE OR ALTER TRIGGER trg_KardexNuevoRegistro
ON dbo.productos
AFTER INSERT
AS
BEGIN
	
	DECLARE
		@IdProducto INT,
		@Stock INT,
		@PrecioCompra DECIMAL(11,2),
		@IdKardex INT;
	
	-- Obtener los valores del producto insertado
	SELECT
		@IdProducto = p.idProducto,
		@Stock = p.stocK,
		@PrecioCompra = p.precioCompra
	FROM inserted p;

	-- Insertar en la tabla kardex
	INSERT INTO kardex(idProducto)
	VALUES(@IdProducto);
	
	-- Obtener el último idKardex generado
	SET @IdKardex = SCOPE_IDENTITY();

	-- Insertar el detalle de kardex
	INSERT INTO detalleKardex(idKardex, fecha, referencia, tipoOperacion, entrada, costoEntrada, totalEntrada,
							  salida, costoSalida, totalSalida, existencia, promedio, costoExistencia, idUsuario)
	VALUES(@IdKardex,
		   GETDATE(),
		   NULL,
		   'Inventario inicial',
		   @Stock,
		   @PrecioCompra,
		   @Stock * @PrecioCompra,
		   NULL,
		   NULL,
		   NULL,
		   @Stock,
		   @PrecioCompra,
		   @Stock * @PrecioCompra,
		   1)
END;
GO