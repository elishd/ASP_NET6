USE MASTER
GO

--====================================================================================
--						ESTRUCTURA DE BASE DE DATOS - TEST
--====================================================================================

CREATE DATABASE MiBanco
GO


USE MiBanco
GO


CREATE TABLE Cliente(
	Codigo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	NombreCompleto VARCHAR(100)  NULL,
	TipoPersona CHAR(1) NOT NULL,
	Correo VARCHAR(100) NOT NULL,
	Telefono VARCHAR(9) NOT NULL,
	Direccion VARCHAR(200) NOT NULL,
	CONSTRAINT Chk_Cliente_TipoPersona CHECK (TipoPersona='N' OR TipoPersona='J')
);

CREATE TABLE TipoCuenta(
	Codigo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(15) NOT NULL
);


CREATE TABLE Cuenta(
	Codigo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CodigoCliente INT NOT NULL FOREIGN KEY REFERENCES Cliente(Codigo),
	CodigoTipoCuenta INT NOT NULL FOREIGN KEY REFERENCES TipoCuenta(Codigo),
	NumeroCuenta VARCHAR(20) NOT NULL,
	Saldo DECIMAL(8,4) DEFAULT(0) NOT NULL,
	FechaCreacion DATETIME DEFAULT(GETDATE()),
);


CREATE TABLE TipoTransaccion(
	Codigo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE TransaccionEncabezado(
	Codigo BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CodigoTipoTransaccion INT NOT NULL DEFAULT(1) FOREIGN KEY REFERENCES TipoTransaccion(Codigo),
	MontoTotal DECIMAL(10,4) NOT NULL,
	Descripcion VARCHAR(100) NULL,
	Estado CHAR(1) NULL,
	FechaCreacion DATETIME DEFAULT(GETDATE()) NOT NULL,
	CONSTRAINT Chk_Estado CHECK (Estado='A' OR Estado='I')
);

CREATE TABLE TransaccionDetalle(
	Codigo BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CodigoTransaccion BIGINT NOT NULL  FOREIGN KEY REFERENCES TransaccionEncabezado(Codigo),
	Cuenta INT NOT NULL FOREIGN KEY REFERENCES Cuenta(Codigo),
	Cargo DECIMAL(10,4) NOT NULL,
	Abono DECIMAL(10,4) NOT NULL
);

--====================================================================================
--						DATOS INICIALES - TEST
--====================================================================================

INSERT	INTO	Cliente (NombreCompleto,TipoPersona,Correo,Telefono,Direccion)
		VALUES	('Carlos Alfredo Durán Ramírez','N','carlos-dr@hotmail.com','7323-2323','Final Av.Mansferer, Colonia Helen1,Ilobasco,Cabañas')
INSERT	INTO	Cliente (NombreCompleto,TipoPersona,Correo,Telefono,Direccion)
		VALUES	('Emiliana Hinojosa Ahmed Echeverria','N','ehae@hotmail.com','6332-6765','Final Av.Mansferer, Colonia Helen2,Ilobasco,Cabañas')
INSERT	INTO	Cliente (NombreCompleto,TipoPersona,Correo,Telefono,Direccion)
		VALUES	('Empresa S.A. de C.V.','N','empresa@hotmail.com','2633-9888','Final Av.Mansferer, Colonia Helen3,Ilobasco,Cabañas')
GO


INSERT INTO TipoCuenta(Nombre) VALUES('Ahorro');
INSERT INTO TipoCuenta(Nombre) VALUES('Corriente');
INSERT INTO TipoCuenta(Nombre) VALUES('Préstamo');
INSERT INTO TipoCuenta(Nombre) VALUES('Tarjeta');
GO

INSERT	INTO Cuenta(CodigoCliente,CodigoTipoCuenta,NumeroCuenta,Saldo)
		VALUES (1,1,'0123456555',900.3389)
INSERT	INTO Cuenta(CodigoCliente,CodigoTipoCuenta,NumeroCuenta,Saldo)
		VALUES (1,1,'0123456666',500.9075)
INSERT	INTO Cuenta(CodigoCliente,CodigoTipoCuenta,NumeroCuenta,Saldo)
		VALUES (2,1,'0123456666',1.0000)
INSERT	INTO Cuenta(CodigoCliente,CodigoTipoCuenta,NumeroCuenta,Saldo)
		VALUES (3,1,'0123456666',10.7599)
GO

INSERT INTO TipoTransaccion(Nombre) VALUES('Transacción Cajeros Automáticos (AT)');
INSERT INTO TipoTransaccion(Nombre) VALUES('Transferencia de Fondos	(TF)');
INSERT INTO TipoTransaccion(Nombre) VALUES('Compras en Comercios (CP)');
INSERT INTO TipoTransaccion(Nombre) VALUES('Intereses (IN)');
INSERT INTO TipoTransaccion(Nombre) VALUES('Nota de Crédito (CR)');
GO
