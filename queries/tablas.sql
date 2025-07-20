USE MASTER

-- CLOSE ALL CONNECTIONS TO DATABASE
GO
	IF EXISTS(SELECT * FROM sys.databases WHERE name='gctelecomdb')
BEGIN
	ALTER DATABASE gctelecomdb SET SINGLE_USER
WITH ROLLBACK IMMEDIATE
END
GO

-- SEARCH IF THE DATABASE EXISTS, ELSE WE DELETE IT
IF EXISTS(SELECT * FROM sys.databases WHERE name='gctelecomdb')
BEGIN
	USE MASTER
 	DROP DATABASE gctelecomdb
END
GO

-- CREATE THE DATABASE
CREATE DATABASE gctelecomdb
GO

-- WE SELECT THE DATABASE
USE gctelecomdb
GO

-- BEGIN FUENTE TABLE
CREATE TABLE fuente(
	fuente_id INTEGER PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(100) NOT NULL,
	es_visible BIT NOT NULL DEFAULT 1,
);
GO

INSERT INTO fuente (nombre)
VALUES
	('Google Ads'),
 	('Facebook Ads'),
 	('Instagram'),
 	('LinkedIn'),
	('Página Web'),
	('Redes Sociales'),
	('Referido');
GO

INSERT INTO fuente VALUES ('Email Marketing', 0)
GO

SELECT * FROM fuente
-- END FUENTE TABLE

-- BEGIN CREATE CLIENTE TABLE
CREATE TABLE cliente(
	cliente_id INTEGER PRIMARY KEY IDENTITY(1,1),
	fuente_id INTEGER NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	correo VARCHAR(100) NOT NULL,
	celular VARCHAR(9) NOT NULL,
	direccion TEXT NOT NULL,
	fecha_registro DATETIME DEFAULT CURRENT_TIMESTAMP,
	es_visible BIT NOT NULL DEFAULT 1,

	FOREIGN KEY (fuente_id) REFERENCES fuente(fuente_id),
)
GO

INSERT INTO cliente (fuente_id, nombre, correo, celular, direccion)
VALUES (2, 'Francisco Huapaya', 'franciscojho@hotmail.com', '940361504', 'Av. Chavito 123, El Olivar, Lima')
GO

INSERT INTO cliente (fuente_id, nombre, correo, celular, direccion, es_visible)
VALUES (4, 'Alberto Arana', 'aaranal@hotmail.com', '977888333', 'Av. Concinos 222, San Blas, Cusco', 0)
GO

SELECT * FROM cliente
-- END CREATE CLIENTE TABLE

-- BEGIN CREATE VENDEDOR TABLE
CREATE TABLE vendedor(
	vendedor_id INTEGER PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(100) NOT NULL,
	correo VARCHAR(100) NOT NULL,
	celular VARCHAR(9) NOT NULL,
	direccion TEXT NOT NULL,
	es_visible BIT NOT NULL DEFAULT 1,
)
GO

INSERT INTO vendedor (nombre, correo, celular, direccion, es_visible)
VALUES ('Alberto Amaru', 'aamaru93@hotmail.com', '977000999', 'Av. Cordoba 333, San Isidro, Lima', 1)
GO

SELECT * FROM vendedor
-- END CREATE VENDEDOR TABLE


-- BEGIN CREATE PRODUCTO TABLE
CREATE TABLE producto(
	producto_id INTEGER PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(100) NOT NULL,
	descripcion TEXT NOT NULL,
	precio DECIMAL NOT NULL,
	moneda VARCHAR(10) DEFAULT 'PEN',
	es_visible BIT NOT NULL DEFAULT 1,
)
GO

INSERT INTO producto (nombre, descripcion, precio, es_visible)
VALUES ('Amplificador XT10', 'Super amplificador de celular, tendrá red en cualquies parte de tu casa.', 1500.00, 1)
GO

INSERT INTO producto (nombre, descripcion, precio, es_visible)
VALUES ('Antena M1000', 'Antena gigante para internet satelital.', 700.00, 1)
GO

SELECT * FROM producto
-- END CREATE PRODUCTO TABLE

-- BEGIN CREATE VENTA TABLE
CREATE TABLE venta(
	venta_id INTEGER PRIMARY KEY IDENTITY(1,1),
	cliente_id INTEGER NOT NULL,
	vendedor_id INTEGER NOT NULL,
	fecha DATETIME NOT NULL,
	total DECIMAL NOT NULL,
	moneda VARCHAR(10) DEFAULT 'PEN',
	es_visible BIT NOT NULL DEFAULT 1,

	FOREIGN KEY (cliente_id) REFERENCES cliente(cliente_id),
	FOREIGN KEY (vendedor_id) REFERENCES vendedor(vendedor_id),
)
GO

INSERT INTO venta (cliente_id, vendedor_id, fecha, total, es_visible)
VALUES (1, 1, CURRENT_TIMESTAMP, 2200.00, 1)
GO

SELECT * FROM venta
-- END CREATE VENTA TABLE

-- BEGIN CREATE DETALLE_VENTA TABLE
CREATE TABLE detalle_venta(
	detalle_venta_id INTEGER PRIMARY KEY IDENTITY(1,1),
	venta_id INTEGER NOT NULL,
	producto_id INTEGER NOT NULL,
	cantidad INTEGER NOT NULL,
	es_visible BIT NOT NULL DEFAULT 1,

	FOREIGN KEY (venta_id) REFERENCES venta(venta_id),
	FOREIGN KEY (producto_id) REFERENCES producto(producto_id),
)
GO

INSERT INTO detalle_venta (venta_id, producto_id, cantidad)
VALUES (1, 1, 1)
GO

INSERT INTO detalle_venta (venta_id, producto_id, cantidad)
VALUES (1, 2, 1)
GO

SELECT * FROM detalle_venta
-- END CREATE DETALLE_VENTA TABLE

-- BEGIN CREATE RECLAMO TABLE
CREATE TABLE reclamo(
	reclamo_id INTEGER PRIMARY KEY IDENTITY(1,1),
	producto_id INTEGER NOT NULL,
	descripcion TEXT NOT NULL,
	fecha DATETIME NOT NULL,
	estado VARCHAR(20) NOT NULL CHECK (estado IN('Pendiente', 'En Progreso', 'Cerrado')) DEFAULT 'Pendiente',
	es_visible BIT NOT NULL DEFAULT 1,

	FOREIGN KEY (producto_id) REFERENCES producto(producto_id),
)
GO

INSERT INTO reclamo (producto_id, descripcion, fecha, es_visible)
VALUES (1, 'El amplificador está fallando, una luz está parpadeando.', '2025-07-13T18:34:23', 1)
GO

SELECT * FROM reclamo
-- END CREATE RECLAMO TABLE

-- BEGIN CREATE EVENTO TABLE
CREATE TABLE evento(
	evento_id INTEGER PRIMARY KEY IDENTITY(1,1),
	cliente_id INTEGER NOT NULL,
	vendedor_id INTEGER NOT NULL,
	tipo VARCHAR(20) NOT NULL CHECK (tipo IN('Reunión', 'Llamada')),
	descripcion TEXT NOT NULL,
	fecha_inicio DATETIME NOT NULL,
	duracion INTEGER NOT NULL,
	es_visible BIT NOT NULL DEFAULT 1,

	FOREIGN KEY (cliente_id) REFERENCES cliente(cliente_id),
	FOREIGN KEY (vendedor_id) REFERENCES vendedor(vendedor_id),
)
GO

INSERT INTO evento (cliente_id, vendedor_id, tipo, descripcion, fecha_inicio, duracion, es_visible)
VALUES (1, 1, 'Llamada', 'llamar al cliente para presentarle nuestros productos.', '2025-07-15T14:30:00', 30, 1)
GO

SELECT * FROM evento
-- END CREATE EVENTO TABLE

