USE GestionFarmaciaDB
GO


CREATE OR ALTER PROC sp_Backup
@Directorio VARCHAR(MAX),
@Respuesta INT OUT
AS
BEGIN
    BEGIN TRY
    
        IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'GestionFarmaciaDB')
            THROW 50001, 'La base de datos GestionFarmaciaDB no existe.', 1;

        DECLARE @Archivo VARCHAR(MAX) = @Directorio + '\GestionFarmaciaDB_' + 
                                         CONVERT(VARCHAR(20), GETDATE(), 112) + '.bak'

        BACKUP DATABASE GestionFarmaciaDB
        TO DISK = @Archivo
        WITH INIT, COMPRESSION

        SET @Respuesta = 1;
    END TRY 

    BEGIN CATCH

        SET @Respuesta = 0;

        DECLARE @Error_Mensaje VARCHAR(5000),
                @Error_Severidad INT,
                @Error_Estado INT,
                @Error_sp VARCHAR(255),
                @Mensaje_Devuelto VARCHAR(5000);

        SELECT @Error_Mensaje = ERROR_MESSAGE(),
               @Error_Severidad = ERROR_SEVERITY(),
               @Error_Estado = ERROR_STATE(),
               @Error_sp = ISNULL(ERROR_PROCEDURE(), 'Desconocido');

        INSERT INTO logError(mensajeError, severidadError, estadoError, spError)
        VALUES(@Error_Mensaje,
               @Error_Severidad,
               @Error_Estado,
               @Error_sp);

        SET @Mensaje_Devuelto = 'Error al generar el respaldo. Detalles:' 
                      + CHAR(13) + CHAR(10) 
                      + @Error_Mensaje;

        THROW 50003, @Mensaje_Devuelto, @Error_Estado;
    END CATCH
END
GO