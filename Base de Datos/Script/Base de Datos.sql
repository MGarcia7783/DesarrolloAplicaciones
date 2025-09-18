USE [master]
GO


IF DB_ID('GestionFarmaciaDB') IS NOT NULL
BEGIN
	--SE DESCONECTAN LOS USUARIOS Y ELIMINAR BASE DE DATOS
	ALTER DATABASE GestionFarmaciaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE GestionFarmaciaDB
END
GO


CREATE DATABASE GestionFarmaciaDB
GO


USE GestionFarmaciaDB
GO


CREATE TABLE empresa(
	idEmpresa INT IDENTITY(1,1),
	numeroRuc VARCHAR(20) NOT NULL,
	nombreEmpresa VARCHAR(250) NOT NULL,
	telefonoEmpresa VARCHAR(15),
	direccion VARCHAR(500) NOT NULL

	CONSTRAINT[PK_empresa_IdEmpresa] PRIMARY KEY(idEmpresa)
);
GO


CREATE TABLE roles(
	idRol INT IDENTITY(1,1),
	nombreRol VARCHAR(50) NOT NULL,
	fechaRegistro DATETIME DEFAULT GETDATE()

	CONSTRAINT[PK_roles_idRol] PRIMARY KEY(idROl),
	CONSTRAINT[UN_roles_nombreRol] UNIQUE(nombreRol)
);
GO


CREATE TABLE usuarios(
	idUsuario INT IDENTITY(1,1),
	dniUsuario VARCHAR(17) NOT NULL,
	nombreUsuario VARCHAR(8) NOT NULL,
	codigoUsuario CHAR(10) NOT NULL,
	email VARCHAR(200) NOT NULL,
	idRol INT NOT NULL,
	clave VARBINARY(MAX) NOT NULL,	
	fechaRegistro DATETIME DEFAULT GETDATE(),
	estado BIT DEFAULT 1

	CONSTRAINT[PK_usuarios_idUsuario] PRIMARY KEY(idUsuario),
	CONSTRAINT[UN_usuarios_dniUsuario] UNIQUE(dniUsuario),
	CONSTRAINT[UN_usuarios_nombreUsuario] UNIQUE(nombreUsuario),
	CONSTRAINT[UN_usuarios_codigoUsuario] UNIQUE(codigoUsuario),
	CONSTRAINT[UN_usuarios_email] UNIQUE(email),
	CONSTRAINT[FK_usuarios_idRol] FOREIGN KEY(idRol) REFERENCES roles(idRol),
	CONSTRAINT[CK_usuarios_estado] CHECK(estado IN(0, 1))
);
GO


CREATE TABLE menu(
	idMenu INT IDENTITY(1,1),
	nombreMenu VARCHAR(50) NOT NULL,
	idUsuario INT NOT NULL,
	fechaRegistro DATETIME DEFAULT GETDATE()

	CONSTRAINT[PK_menu_idMenu] PRIMARY KEY(idMenu),
	CONSTRAINT[UN_menu_nombreMenu] UNIQUE(nombreMenu),
	CONSTRAINT[FK_menu_idUsuario] FOREIGN KEY(idUsuario) REFERENCES usuarios(idUsuario)
);
GO


CREATE TABLE clientes(
	idCliente INT IDENTITY(1,1),
	dniCliente VARCHAR(16) NOT NULL,
	razonSocial VARCHAR(100) NOT NULL,
	telefono VARCHAR(15) NOT NULL,
	estado BIT DEFAULT 1,
	fechaRegistro DATETIME DEFAULT GETDATE()

	CONSTRAINT[PK_clientes_idCliente] PRIMARY KEY(idCliente),
	CONSTRAINT[UN_clientes_dniCliente] UNIQUE(dniCliente),
	CONSTRAINT[UN_clientes_telefono] UNIQUE(telefono),
	CONSTRAINT[CK_clientes_estado] CHECK(estado IN(0, 1))
);
GO

CREATE NONCLUSTERED INDEX IX_clientes_dniCliente ON clientes(dniCliente) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_clientes_razonSocial ON clientes(razonSocial) WITH(FILLFACTOR = 80);



CREATE TABLE categorias(
	idCategoria INT IDENTITY(1,1),
	nombreCategoria VARCHAR(50) NOT NULL,
	descripcionCategoria VARCHAR(200) NOT NULL,
	estado BIT DEFAULT 1,
	fechaRegistro DATETIME DEFAULT GETDATE()

	CONSTRAINT[PK_categorias_idCategoria] PRIMARY KEY(idCategoria),
	CONSTRAINT[UN_categorias_nombreCategoria] UNIQUE(nombreCategoria),
	CONSTRAINT[CK_categorias_estado] CHECK(estado IN(0, 1))
);
GO


CREATE TABLE laboratorios(
	idLaboratorio INT IDENTITY(1,1),
	nombreLaboratorio VARCHAR(20) NOT NULL,
	email VARCHAR(200) NOT NULL,
	telefono VARCHAR(15) NOT NULL,
	contacto VARCHAR(50) NOT NULL,
	estado BIT DEFAULT 1,
	fechaRegistro DATETIME DEFAULT GETDATE()

	CONSTRAINT[PK_laboratorios_idLaboratorio] PRIMARY KEY(idLaboratorio),
	CONSTRAINT[UN_loboratorios_nombreLaboratorio] UNIQUE(nombreLaboratorio),
	CONSTRAINT[UN_loboratorios_email] UNIQUE(email),
	CONSTRAINT[UN_loboratorios_telefono] UNIQUE(telefono),
	CONSTRAINT[UN_loboratorios_contacto] UNIQUE(contacto),
	CONSTRAINT[CK_laboratorios_estado] CHECK(estado IN(0, 1))
);
GO

CREATE NONCLUSTERED INDEX IX_labarotorios_nombreLaboratorio ON laboratorios(nombreLaboratorio) WITH(FILLFACTOR = 80);


CREATE TABLE productos(
	idProducto INT IDENTITY(1,1),
	codigo VARCHAR(20) NOT NULL,
	nombreProducto VARCHAR(100) NOT NULL,
	stock INT NOT NULL,
	stockMinimo INT NULL,
	precioCompra DECIMAL(11,2) NOT NULL,
	precioVenta DECIMAL(11,2) NOT NULL,
	formatoCompra VARCHAR(10) NULL,	
	ventaReceta CHAR(2) NOT NULL,
	fechaIngreso DATETIME DEFAULT GETDATE() NOT NULL,
	tieneVencimiento BIT DEFAULT 0 NOT NULL,
	fechaVencimiento DATETIME NULL,
	idCategoria INT NOT NULL,
	idLaboratorio INT NOT NULL,
	impuesto CHAR(1) DEFAULT 'E' NOT NULL,
	estado BIT NOT NULL DEFAULT 1

	CONSTRAINT[PK_productos_idProducto] PRIMARY KEY(idProducto),
	CONSTRAINT[UN_productos_codigo] UNIQUE(codigo),
	CONSTRAINT[CK_productos_precioCompra] CHECK(precioCompra > 0),
	CONSTRAINT[CK_productos_precioVenta] CHECK(precioVenta > precioCompra),
	CONSTRAINT[CK_productos_tieneVencimiento] CHECK(tieneVencimiento IN(0, 1)),
	CONSTRAINT[CK_productos_fechaVencimiento] CHECK(fechaVencimiento > fechaIngreso),
	CONSTRAINT[FK_productos_idCategoria] FOREIGN KEY(idCategoria) REFERENCES categorias(idCategoria),
	CONSTRAINT[FK_productos_idLaboratorio] FOREIGN KEY(idLaboratorio) REFERENCES laboratorios(idLaboratorio),
	CONSTRAINT[CK_productos_estado] CHECK(estado IN(0, 1)),
	CONSTRAINT[CK_productos_impuesto] CHECK(impuesto IN('E','G'))
);
GO

CREATE NONCLUSTERED INDEX IX_productos_codigo ON productos(codigo) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_productos_nombreProducto ON productos(nombreProducto) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_productos_idCategoria ON productos(idCategoria) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_productos_idLaboratorio ON productos(idLaboratorio) WITH(FILLFACTOR = 80);


CREATE TABLE caja (
    idCaja INT IDENTITY(1,1),
	numeroCaja INT NOT NULL,
    fechaApertura DATETIME NOT NULL DEFAULT GETDATE(),
    fechaCierre DATETIME NULL,
    montoApertura DECIMAL(11,2) NOT NULL,
    totalEfectivo DECIMAL(11,2) NOT NULL,
	totalTarjeta DECIMAL(11,2) NOT NULL DEFAULT 0,
	totalCambio DECIMAL(11,2) NOT NULL DEFAULT 0,
	totalEntregado DECIMAL(11,2) NOT NULL DEFAULT 0,
    estado VARCHAR(10) NOT NULL DEFAULT 'Abierta', -- 'Abierta' o 'Cerrada'
	supervisor VARCHAR(100) NULL,
	idUsuario INT NOT NULL,
    observaciones NVARCHAR(250) NULL,

    CONSTRAINT PK_caja_idCaja PRIMARY KEY NONCLUSTERED(idCaja),
	CONSTRAINT CK_caja_estado CHECK(estado IN('Abierta','Cerrada')),
	CONSTRAINT FK_Caja_idUsuario FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);
GO

CREATE CLUSTERED INDEX IX_caja_fechaApertura ON caja(fechaApertura) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_caja_idUsuario ON caja(idUsuario) WITH(FILLFACTOR = 80);


CREATE TABLE pedidos(
	idPedido INT IDENTITY(1,1) NOT NULL,
	idUsuario INT NOT NULL,
	idCaja INT NOT NULL,
	fechaPedido DATETIME DEFAULT GETDATE(),
	numeroPedido VARCHAR(20) NOT NULL,
	subTotal DECIMAL(11,2) NOT NULL,
	impuesto DECIMAL(11,2) DEFAULT 0 NOT NULL,
	totalGeneral DECIMAL(11,2) NOT NULL,	
	montoEfectivo DECIMAL(11,2) NOT NULL DEFAULT 0,
	montoTarjeta DECIMAL(11,2) NOT NULL DEFAULT 0,
	cambio DECIMAL(11,2) NOT NULL DEFAULT 0,
	estado BIT DEFAULT 1 NOT NULL

	CONSTRAINT[PK_pedidos_idPedido] PRIMARY KEY NONCLUSTERED(idPedido),
	CONSTRAINT[FK_pedidos_idUsuario] FOREIGN KEY(idUsuario) REFERENCES usuarios(idUsuario),
	CONSTRAINT[CK_pedidos_numeroPedido] UNIQUE(numeroPedido)
);
GO

CREATE CLUSTERED INDEX IX_pedidos_fechaPedido ON pedidos(fechaPedido) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_pedidos_idUsuario ON pedidos(idUsuario) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_pedidos_idCaja ON pedidos(idCaja) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_pedidos_numeroPedido ON pedidos(numeroPedido) WITH(FILLFACTOR = 80);



CREATE TABLE detallePedidos(
	idDetallePedido INT IDENTITY(1,1),
	idPedido INT NOT NULL,
	idProducto INT NOT NULL,
	nombreProducto VARCHAR(100) NOT NULL,
	cantidad INT NOT NULL,
	precio DECIMAL(11,2) NOT NULL	

	CONSTRAINT[PK_detallePedidos_idDetallePedido] PRIMARY KEY(idDetallePedido),
	CONSTRAINT[FK_detallePedidos_idPedido] FOREIGN KEY(idPedido) REFERENCES pedidos(idPedido),
	CONSTRAINT[FK_detallePedidos_idProducto] FOREIGN KEY(idProducto) REFERENCES productos(idProducto),
);
GO

CREATE NONCLUSTERED INDEX IX_detallePedidos_idPedido ON detallePedidos(idPedido) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_detallePedidos_idProducto ON detallePedidos(idProducto) WITH(FILLFACTOR = 80);



CREATE TABLE documentos(
	idDocumento INT IDENTITY(1,1),
	TipoDocumento VARCHAR(50) NOT NULL,
	numeroDocumento INT NOT NULL

	CONSTRAINT[PK_documentos_idDocumento] PRIMARY KEY NONCLUSTERED(idDocumento)
);
GO



CREATE TABLE compras(
	idCompra CHAR(11),
	numeroFactura CHAR(20) NOT NULL,
	fechaCompra DATETIME NOT NULL,
	observacion VARCHAR(250) NULL,
	subTotal DECIMAL(11,2) NOT NULL,
	impuesto DECIMAL(11,2) NOT NULL DEFAULT 0,
	totalGeneral DECIMAL(11,2) NOT NULL DEFAULT 0,
	idUsuario INT NOT NULL,
	fechaRegistro DATETIME DEFAULT GETDATE()

	CONSTRAINT[PK_compras_idCompra] PRIMARY KEY NONCLUSTERED(idCompra),
	CONSTRAINT[FK_compras_idUsuario] FOREIGN KEY(idUsuario) REFERENCES usuarios(idUsuario)
);
GO

CREATE CLUSTERED INDEX IX_compras_fechaCompra ON compras(fechaCompra) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_compras_idUsuario ON compras(idUsuario) WITH(FILLFACTOR = 80);



CREATE TABLE detalleCompras(
	idDetalles INT IDENTITY(1,1),
	idCompra CHAR(11) NOT NULL,
	idProducto INT NOT NULL,
	nombreProducto VARCHAR(100) NOT NULL,
	cantidad int NOT NULL,
	precioCompra DECIMAL(11,2) NOT NULL,
	precioVenta DECIMAL(11,2) NOT NULL,

	CONSTRAINT[PK_detalleCompras_idDetalles] PRIMARY KEY(idDetalles),
	CONSTRAINT[FK_detalleCompras_idCompra] FOREIGN KEY(idCompra) REFERENCES compras(idCompra),
	CONSTRAINT[FK_detalleCompras_idProducto] FOREIGN KEY(idProducto) REFERENCES productos(idProducto)
);
GO

CREATE NONCLUSTERED INDEX IX_detalleCompras_idCompra ON detalleCompras(idCompra) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_detalleCompras_idProducto ON detalleCompras(idProducto) WITH(FILLFACTOR = 80);



CREATE TABLE kardex(
	idKardex INT IDENTITY(1,1),
	idProducto INT NOT NULL,
	estado BIT DEFAULT 1,
	fechaRegistro DATETIME DEFAULT GETDATE()

	CONSTRAINT[PK_kardex_idKardex] PRIMARY KEY NONCLUSTERED(idKardex),
	CONSTRAINT[FK_kardex_idProducto] FOREIGN KEY(idProducto) REFERENCES productos(idProducto),
	CONSTRAINT[CK_kardex_estado] CHECK(estado IN(0, 1)),
);
GO

CREATE CLUSTERED INDEX IX_kardex_fechaRegistro ON kardex(fechaRegistro) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_kardex_idProducto ON kardex(idProducto) WITH(FILLFACTOR = 80);



CREATE TABLE detalleKardex(
	idDetalleKardex INT IDENTITY(1,1),
	idKardex INT NOT NULL,
	fecha DATETIME NOT NULL,
	referencia CHAR(20) NULL,
	tipoOperacion VARCHAR(180) NULL,
	entrada INT NULL,
	costoEntrada DECIMAL(11,2) NULL,
	totalEntrada DECIMAL(11,2) NULL,
	salida INT NULL,
	costoSalida DECIMAL(11,2) NULL,
	totalSalida DECIMAL(11,2) NULL,
	existencia INT NOT NULL,
	promedio DECIMAL(11,2) NULL,
	costoExistencia DECIMAL(11,2) NULL,
	idUsuario INT NOT NULL

	CONSTRAINT[PK_detalleKardex_idDetalleKardex] PRIMARY KEY(idDetalleKardex),
	CONSTRAINT[FK_detalleKardex_idKardex] FOREIGN KEY(idKardex) REFERENCES kardex(idKardex),
	CONSTRAINT[FK_detalleKardex_idUsuario] FOREIGN KEY(idUsuario) REFERENCES usuarios(idUsuario)
);
GO

CREATE NONCLUSTERED INDEX IX_detalleKardex_idKardex ON detalleKardex(idKardex) WITH(FILLFACTOR = 80);
CREATE NONCLUSTERED INDEX IX_detalleKardex_idUsuario ON detalleKardex(idUsuario) WITH(FILLFACTOR = 80);


CREATE TABLE logError(
	id INT IDENTITY(1,1),
	mensajeError VARCHAR(5000),
	severidadError INT,
	estadoError INT,
	spError VARCHAR(255),
	fechaRegistro DATETIME DEFAULT GETDATE()
);
GO



