USE gctelecomdb
GO


PRINT '--- Verificando y añadiendo columnas a tablas (solo si no existen) ---';
GO

-- Mantener estas adiciones para detalle_venta si no están en tu CREATE TABLE
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('detalle_venta') AND name = 'precio_unitario')
BEGIN
    ALTER TABLE detalle_venta ADD precio_unitario DECIMAL(18, 2) NOT NULL DEFAULT 0;
    PRINT 'Columna precio_unitario añadida a tabla detalle_venta.';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('detalle_venta') AND name = 'subtotal')
BEGIN
    ALTER TABLE detalle_venta ADD subtotal DECIMAL(18, 2) NOT NULL DEFAULT 0;
    PRINT 'Columna subtotal añadida a tabla detalle_venta.';
END
GO

PRINT '--- Verificación y adición de columnas completada ---';
GO


PRINT '--- Eliminando procedimientos almacenados existentes ---';
GO

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_FUENTES') DROP PROCEDURE SP_OBTENER_FUENTES;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_FUENTE') DROP PROCEDURE SP_CREAR_FUENTE;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_FUENTE') DROP PROCEDURE SP_ACTUALIZAR_FUENTE;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_FUENTE') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_FUENTE;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_FUENTE_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_FUENTE_ID;
GO

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_CLIENTES') DROP PROCEDURE SP_OBTENER_CLIENTES;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_CLIENTE') DROP PROCEDURE SP_CREAR_CLIENTE;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_CLIENTE') DROP PROCEDURE SP_ACTUALIZAR_CLIENTE;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_CLIENTE') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_CLIENTE;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_CLIENTE_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_CLIENTE_ID;
GO

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_VENDEDORES') DROP PROCEDURE SP_OBTENER_VENDEDORES;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_VENDEDOR') DROP PROCEDURE SP_CREAR_VENDEDOR;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_VENDEDOR') DROP PROCEDURE SP_ACTUALIZAR_VENDEDOR;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_VENDEDOR') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_VENDEDOR;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_VENDEDOR_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_VENDEDOR_ID;
GO

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_PRODUCTOS') DROP PROCEDURE SP_OBTENER_PRODUCTOS;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_PRODUCTO') DROP PROCEDURE SP_CREAR_PRODUCTO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_PRODUCTO') DROP PROCEDURE SP_ACTUALIZAR_PRODUCTO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_PRODUCTO') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_PRODUCTO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_PRODUCTO_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_PRODUCTO_ID;
GO

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_VENTAS') DROP PROCEDURE SP_OBTENER_VENTAS;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_VENTA') DROP PROCEDURE SP_CREAR_VENTA;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_VENTA') DROP PROCEDURE SP_ACTUALIZAR_VENTA;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_VENTA') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_VENTA;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_VENTA_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_VENTA_ID;
GO

-- Nombres antiguos para detalle_venta
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_DETALLE_VENTAS') DROP PROCEDURE SP_OBTENER_DETALLE_VENTAS;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_DETALLEVNTS') DROP PROCEDURE SP_OBTENER_DETALLEVNTS;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_DETALLE_VENTA') DROP PROCEDURE SP_CREAR_DETALLE_VENTA;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_DETALLEVNT') DROP PROCEDURE SP_CREAR_DETALLEVNT;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_DETALLE_VENTA') DROP PROCEDURE SP_ACTUALIZAR_DETALLE_VENTA;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_DETALLEVNT') DROP PROCEDURE SP_ACTUALIZAR_DETALLEVNT;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_DETALLE_VENTA') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_DETALLE_VENTA;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_DETALLEVNT') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_DETALLEVNT;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACT_DES_DET_VENTA') DROP PROCEDURE SP_ACT_DES_DET_VENTA; -- Nuevo nombre acortado
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_DETALLE_VENTA_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_DETALLE_VENTA_ID;
GO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_OBTENER_SIGUIENTE_DETALLEVNT_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_DETALLEVNT_ID;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_DETALLES_VENTA_POR_ID') DROP PROCEDURE SP_OBTENER_DETALLES_VENTA_POR_ID;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ELIMINAR_DET_VENTA') DROP PROCEDURE SP_ELIMINAR_DET_VENTA;
GO

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_RECLAMOS') DROP PROCEDURE SP_OBTENER_RECLAMOS;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_RECLAMO') DROP PROCEDURE SP_CREAR_RECLAMO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_RECLAMO') DROP PROCEDURE SP_ACTUALIZAR_RECLAMO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_RECLAMO') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_RECLAMO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_RECLAMO_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_RECLAMO_ID;
GO

IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_EVENTOS') DROP PROCEDURE SP_OBTENER_EVENTOS;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CREAR_EVENTO') DROP PROCEDURE SP_CREAR_EVENTO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTUALIZAR_EVENTO') DROP PROCEDURE SP_ACTUALIZAR_EVENTO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ACTIVAR_DESACTIVAR_EVENTO') DROP PROCEDURE SP_ACTIVAR_DESACTIVAR_EVENTO;
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_OBTENER_SIGUIENTE_EVENTO_ID') DROP PROCEDURE SP_OBTENER_SIGUIENTE_EVENTO_ID;
GO

PRINT '--- Eliminación de procedimientos almacenados completada ---';
GO


PRINT '--- Creando procedimientos almacenados ---';
GO

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA FUENTE
CREATE PROC	SP_OBTENER_FUENTES
	@es_visible BIT = NULL
AS
BEGIN
	SELECT fuente_id, nombre, es_visible FROM fuente WHERE (@es_visible IS NULL OR es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_FUENTE
	@nombre VARCHAR(100)
AS
BEGIN
	BEGIN TRAN SP_CREAR_FUENTE
	BEGIN TRY
		INSERT INTO fuente(nombre, es_visible)
		VALUES(@nombre, 1)
		COMMIT TRAN SP_CREAR_FUENTE
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_FUENTE
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_FUENTE
	@fuente_id INTEGER,
	@nombre VARCHAR(100)
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_FUENTE
	BEGIN TRY
		UPDATE fuente SET nombre=@nombre
		WHERE fuente_id=@fuente_id
		COMMIT TRAN SP_ACTUALIZAR_FUENTE
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_FUENTE
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTIVAR_DESACTIVAR_FUENTE
	@fuente_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTIVAR_DESACTIVAR_FUENTE
	BEGIN TRY
		UPDATE fuente SET es_visible=@es_visible WHERE fuente_id=@fuente_id
		COMMIT TRAN SP_ACTIVAR_DESACTIVAR_FUENTE
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTIVAR_DESACTIVAR_FUENTE
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_FUENTE_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(fuente_id), 0) + 1 FROM fuente;
 	SELECT @siguiente_id AS siguiente_fuente_id;
END;
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA FUENTE

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA CLIENTE
CREATE PROC	SP_OBTENER_CLIENTES
	@es_visible BIT = NULL
AS
BEGIN
	SELECT cliente_id, fuente_id, nombre, correo, celular, direccion, fecha_registro, es_visible
	FROM cliente
	WHERE (@es_visible IS NULL OR es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_CLIENTE
	@fuente_id INTEGER,
	@nombre VARCHAR(100),
	@correo VARCHAR(100),
	@celular VARCHAR(9),
	@direccion TEXT
AS
BEGIN
	BEGIN TRAN SP_CREAR_CLIENTE
	BEGIN TRY
		INSERT INTO cliente(fuente_id, nombre, correo, celular, direccion, fecha_registro, es_visible)
		VALUES(@fuente_id, @nombre, @correo, @celular, @direccion, GETDATE(), 1)
		COMMIT TRAN SP_CREAR_CLIENTE
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_CLIENTE
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_CLIENTE
	@cliente_id INTEGER,
	@fuente_id INTEGER,
	@nombre VARCHAR(100),
	@correo VARCHAR(100),
	@celular VARCHAR(9),
	@direccion TEXT
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_CLIENTE
	BEGIN TRY
		UPDATE cliente SET
			fuente_id=@fuente_id,
			nombre=@nombre,
			correo=@correo,
			celular=@celular,
			direccion=@direccion
		WHERE cliente_id=@cliente_id
		COMMIT TRAN SP_ACTUALIZAR_CLIENTE
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_CLIENTE
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTIVAR_DESACTIVAR_CLIENTE
	@cliente_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTIVAR_DESACTIVAR_CLIENTE
	BEGIN TRY
		UPDATE cliente SET es_visible=@es_visible WHERE cliente_id=@cliente_id
		COMMIT TRAN SP_ACTIVAR_DESACTIVAR_CLIENTE
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTIVAR_DESACTIVAR_CLIENTE
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_CLIENTE_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(cliente_id), 0) + 1 FROM cliente;
 	SELECT @siguiente_id AS siguiente_cliente_id;
END;
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA CLIENTE

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA VENDEDOR
CREATE PROC	SP_OBTENER_VENDEDORES
	@es_visible BIT = NULL
AS
BEGIN
	SELECT vendedor_id, nombre, correo, celular, direccion, es_visible FROM vendedor WHERE (@es_visible IS NULL OR es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_VENDEDOR
	@nombre VARCHAR(100),
	@correo VARCHAR(100),
	@celular VARCHAR(9),
	@direccion TEXT
AS
BEGIN
	BEGIN TRAN SP_CREAR_VENDEDOR
	BEGIN TRY
		INSERT INTO vendedor(nombre, correo, celular, direccion, es_visible)
		VALUES(@nombre, @correo, @celular, @direccion, 1)
		COMMIT TRAN SP_CREAR_VENDEDOR
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_VENDEDOR
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_VENDEDOR
	@vendedor_id INTEGER,
	@nombre VARCHAR(100),
	@correo VARCHAR(100),
	@celular VARCHAR(9),
	@direccion TEXT
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_VENDEDOR
	BEGIN TRY
		UPDATE vendedor SET
			nombre=@nombre,
			correo=@correo,
			celular=@celular,
			direccion=@direccion
		WHERE vendedor_id=@vendedor_id
		COMMIT TRAN SP_ACTUALIZAR_VENDEDOR
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_VENDEDOR
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTIVAR_DESACTIVAR_VENDEDOR
	@vendedor_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTIVAR_DESACTIVAR_VENDEDOR
	BEGIN TRY
		UPDATE vendedor SET es_visible=@es_visible WHERE vendedor_id=@vendedor_id
		COMMIT TRAN SP_ACTIVAR_DESACTIVAR_VENDEDOR
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTIVAR_DESACTIVAR_VENDEDOR
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_VENDEDOR_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(vendedor_id), 0) + 1 FROM vendedor;
 	SELECT @siguiente_id AS siguiente_vendedor_id;
END;
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA VENDEDOR

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA PRODUCTO
CREATE PROC	SP_OBTENER_PRODUCTOS
	@es_visible BIT = NULL
AS
BEGIN
	SELECT producto_id, nombre, descripcion, precio, moneda, es_visible FROM producto WHERE (@es_visible IS NULL OR es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_PRODUCTO
	@nombre VARCHAR(100),
	@descripcion TEXT,
	@precio DECIMAL(18, 2),
	@moneda VARCHAR(10)
AS
BEGIN
	BEGIN TRAN SP_CREAR_PRODUCTO
	BEGIN TRY
		INSERT INTO producto(nombre, descripcion, precio, moneda, es_visible)
		VALUES(@nombre, @descripcion, @precio, @moneda, 1)
		COMMIT TRAN SP_CREAR_PRODUCTO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_PRODUCTO
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_PRODUCTO
	@producto_id INTEGER,
	@nombre VARCHAR(100),
	@descripcion TEXT,
	@precio DECIMAL(18, 2),
	@moneda VARCHAR(10)
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_PRODUCTO
	BEGIN TRY
		UPDATE producto SET
			nombre=@nombre,
			descripcion=@descripcion,
			precio=@precio,
			moneda=@moneda
		WHERE producto_id=@producto_id
		COMMIT TRAN SP_ACTUALIZAR_PRODUCTO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_PRODUCTO
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTIVAR_DESACTIVAR_PRODUCTO
	@producto_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTIVAR_DESACTIVAR_PRODUCTO
	BEGIN TRY
		UPDATE producto SET es_visible=@es_visible WHERE producto_id=@producto_id
		COMMIT TRAN SP_ACTIVAR_DESACTIVAR_PRODUCTO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTIVAR_DESACTIVAR_PRODUCTO
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_PRODUCTO_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(producto_id), 0) + 1 FROM producto;
 	SELECT @siguiente_id AS siguiente_producto_id;
END;
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA PRODUCTO

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA VENTA
CREATE PROC	SP_OBTENER_VENTAS
	@es_visible BIT = NULL
AS
BEGIN
	SELECT venta_id, cliente_id, vendedor_id, fecha, total, moneda, es_visible
	FROM venta
	WHERE (@es_visible IS NULL OR es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_VENTA
	@cliente_id INTEGER,
	@vendedor_id INTEGER,
	@fecha DATETIME,
	@total DECIMAL(18, 2),
	@moneda VARCHAR(10),
	@es_visible BIT,
	@venta_id_salida INT OUTPUT
AS
BEGIN
	BEGIN TRAN SP_CREAR_VENTA
	BEGIN TRY
		INSERT INTO venta(cliente_id, vendedor_id, fecha, total, moneda, es_visible)
		VALUES(@cliente_id, @vendedor_id, @fecha, @total, @moneda, @es_visible);
		SET @venta_id_salida = SCOPE_IDENTITY();
		COMMIT TRAN SP_CREAR_VENTA
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_VENTA;
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_VENTA
	@venta_id INTEGER,
	@cliente_id INTEGER,
	@vendedor_id INTEGER,
	@fecha DATETIME,
	@total DECIMAL(18, 2),
	@moneda VARCHAR(10),
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_VENTA
	BEGIN TRY
		UPDATE venta SET
			cliente_id=@cliente_id,
			vendedor_id=@vendedor_id,
			fecha=@fecha,
			total=@total,
			moneda=@moneda,
			es_visible=@es_visible
		WHERE venta_id=@venta_id;
		COMMIT TRAN SP_ACTUALIZAR_VENTA
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_VENTA;
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTIVAR_DESACTIVAR_VENTA
	@venta_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTIVAR_DESACTIVAR_VENTA
	BEGIN TRY
		UPDATE venta SET es_visible=@es_visible WHERE venta_id=@venta_id
		COMMIT TRAN SP_ACTIVAR_DESACTIVAR_VENTA
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTIVAR_DESACTIVAR_VENTA
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_VENTA_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(venta_id), 0) + 1 FROM venta;
 	SELECT @siguiente_id AS siguiente_venta_id;
END;
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA VENTA

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA DETALLE_VENTA
CREATE PROC	SP_OBTENER_DETALLE_VENTAS
	@es_visible BIT = NULL
AS
BEGIN
	SELECT detalle_venta_id, venta_id, producto_id, cantidad, precio_unitario, subtotal, es_visible
	FROM detalle_venta WHERE (@es_visible IS NULL OR es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_DETALLE_VENTA
	@venta_id INTEGER,
	@producto_id INTEGER,
	@cantidad INTEGER,
	@precio_unitario DECIMAL(18, 2),
	@subtotal DECIMAL(18, 2)
AS
BEGIN
	BEGIN TRAN SP_CREAR_DETALLE_VENTA
	BEGIN TRY
		INSERT INTO detalle_venta(venta_id, producto_id, cantidad, precio_unitario, subtotal, es_visible)
		VALUES(@venta_id, @producto_id, @cantidad, @precio_unitario, @subtotal, 1)
		COMMIT TRAN SP_CREAR_DETALLE_VENTA
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_DETALLE_VENTA
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_DETALLE_VENTA
	@detalle_venta_id INTEGER,
	@venta_id INTEGER,
	@producto_id INTEGER,
	@cantidad INTEGER,
	@precio_unitario DECIMAL(18, 2),
	@subtotal DECIMAL(18, 2)
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_DETALLE_VENTA
	BEGIN TRY
		UPDATE detalle_venta SET
			venta_id=@venta_id,
			producto_id=@producto_id,
			cantidad=@cantidad,
			precio_unitario=@precio_unitario,
			subtotal=@subtotal
		WHERE detalle_venta_id=@detalle_venta_id
		COMMIT TRAN SP_ACTUALIZAR_DETALLE_VENTA
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_DETALLE_VENTA
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACT_DES_DET_VENTA
	@detalle_venta_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACT_DES_DET_VENTA
	BEGIN TRY
		UPDATE detalle_venta SET es_visible=@es_visible WHERE detalle_venta_id=@detalle_venta_id
		COMMIT TRAN SP_ACT_DES_DET_VENTA
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACT_DES_DET_VENTA
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_DETALLE_VENTA_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(detalle_venta_id), 0) + 1 FROM detalle_venta;
 	SELECT @siguiente_id AS siguiente_detalle_venta_id;
END;
GO

CREATE PROC SP_OBTENER_DETALLES_VENTA_POR_ID
	@venta_id INT
AS
BEGIN
	SELECT detalle_venta_id, venta_id, producto_id, cantidad, precio_unitario, subtotal, es_visible
	FROM detalle_venta
	WHERE venta_id = @venta_id;
END
GO

CREATE PROC SP_ELIMINAR_DET_VENTA
	@venta_id INT
AS
BEGIN
	BEGIN TRAN SP_ELIMINAR_DET_VENTA
	BEGIN TRY
		DELETE FROM detalle_venta
		WHERE venta_id = @venta_id;
		COMMIT TRAN SP_ELIMINAR_DET_VENTA
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ELIMINAR_DET_VENTA;
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA DETALLE_VENTA

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA RECLAMO
CREATE PROC	SP_OBTENER_RECLAMOS
	@es_visible BIT = NULL
AS
BEGIN
	SELECT
		r.reclamo_id,
		r.producto_id,
		p.nombre AS nombre_producto,
		r.descripcion,
		r.fecha,
		r.estado,
		r.es_visible
	FROM
		reclamo r
	INNER JOIN
		producto p ON r.producto_id = p.producto_id
	WHERE
		(@es_visible IS NULL OR r.es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_RECLAMO
	@producto_id INTEGER,
	@descripcion TEXT,
	@fecha DATETIME,
	@estado VARCHAR(20),
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_CREAR_RECLAMO
	BEGIN TRY
		INSERT INTO reclamo(producto_id, descripcion, fecha, estado, es_visible)
		VALUES(@producto_id, @descripcion, @fecha, @estado, @es_visible)
		COMMIT TRAN SP_CREAR_RECLAMO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_RECLAMO;
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_RECLAMO
	@reclamo_id INTEGER,
	@producto_id INTEGER,
	@descripcion TEXT,
	@fecha DATETIME,
	@estado VARCHAR(20),
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_RECLAMO
	BEGIN TRY
		UPDATE reclamo SET
			producto_id=@producto_id,
			descripcion=@descripcion,
			fecha=@fecha,
			estado=@estado,
			es_visible=@es_visible
		WHERE reclamo_id=@reclamo_id
		COMMIT TRAN SP_ACTUALIZAR_RECLAMO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_RECLAMO;
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTIVAR_DESACTIVAR_RECLAMO
	@reclamo_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTIVAR_DESACTIVAR_RECLAMO
	BEGIN TRY
		UPDATE reclamo SET es_visible=@es_visible WHERE reclamo_id=@reclamo_id
		COMMIT TRAN SP_ACTIVAR_DESACTIVAR_RECLAMO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTIVAR_DESACTIVAR_RECLAMO
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_RECLAMO_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(reclamo_id), 0) + 1 FROM reclamo;
 	SELECT @siguiente_id AS siguiente_reclamo_id;
END;
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA RECLAMO

-- INICIO PROCEDIMIENTOS ALMACENADOS PARA TABLA EVENTO
CREATE PROC	SP_OBTENER_EVENTOS
	@es_visible BIT = NULL
AS
BEGIN
	SELECT
		e.evento_id,
		e.cliente_id,
		c.nombre AS nombre_cliente,
		e.vendedor_id,
		v.nombre AS nombre_vendedor,
		e.tipo,
		e.descripcion,
		e.fecha_inicio,
		e.duracion,
		e.es_visible
	FROM
		evento e
	INNER JOIN
		cliente c ON e.cliente_id = c.cliente_id
	INNER JOIN
		vendedor v ON e.vendedor_id = v.vendedor_id
	WHERE
		(@es_visible IS NULL OR e.es_visible = @es_visible)
END
GO

CREATE PROC	SP_CREAR_EVENTO
	@cliente_id INTEGER,
	@vendedor_id INTEGER,
	@tipo VARCHAR(20),
	@descripcion TEXT,
	@fecha_inicio DATETIME,
	@duracion INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_CREAR_EVENTO
	BEGIN TRY
		INSERT INTO evento(cliente_id, vendedor_id, tipo, descripcion, fecha_inicio, duracion, es_visible)
		VALUES(@cliente_id, @vendedor_id, @tipo, @descripcion, @fecha_inicio, @duracion, @es_visible)
		COMMIT TRAN SP_CREAR_EVENTO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_CREAR_EVENTO;
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTUALIZAR_EVENTO
	@evento_id INTEGER,
	@cliente_id INTEGER,
	@vendedor_id INTEGER,
	@tipo VARCHAR(20),
	@descripcion TEXT,
	@fecha_inicio DATETIME,
	@duracion INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTUALIZAR_EVENTO
	BEGIN TRY
		UPDATE evento SET
			cliente_id=@cliente_id,
			vendedor_id=@vendedor_id,
			tipo=@tipo,
			descripcion=@descripcion,
			fecha_inicio=@fecha_inicio,
			duracion=@duracion,
			es_visible=@es_visible
		WHERE evento_id=@evento_id
		COMMIT TRAN SP_ACTUALIZAR_EVENTO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTUALIZAR_EVENTO;
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROC	SP_ACTIVAR_DESACTIVAR_EVENTO
	@evento_id INTEGER,
	@es_visible BIT
AS
BEGIN
	BEGIN TRAN SP_ACTIVAR_DESACTIVAR_EVENTO
	BEGIN TRY
		UPDATE evento SET es_visible=@es_visible WHERE evento_id=@evento_id
		COMMIT TRAN SP_ACTIVAR_DESACTIVAR_EVENTO
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN SP_ACTIVAR_DESACTIVAR_EVENTO
		DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;
		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

CREATE PROCEDURE SP_OBTENER_SIGUIENTE_EVENTO_ID
AS
BEGIN
 	DECLARE @siguiente_id INT;
 	SELECT @siguiente_id = ISNULL(MAX(evento_id), 0) + 1 FROM evento;
 	SELECT @siguiente_id AS siguiente_evento_id;
END;
GO

-- FIN PROCEDIMIENTOS ALMACENADOS PARA TABLA EVENTO

PRINT '--- Creación de procedimientos almacenados completada ---';
GO



PRINT '--- Insertando datos de ejemplo ---';


-- Datos de ejemplo para FUENTE
PRINT 'Insertando datos en FUENTE...';
-- Se asume que estos IDs se generarán secuencialmente a partir de los datos existentes.
-- Si ya tienes datos, estos se añadirán después de los IDs existentes.
EXEC SP_CREAR_FUENTE 'Redes Sociales';
EXEC SP_CREAR_FUENTE 'Referido';
EXEC SP_CREAR_FUENTE 'Publicidad Online';
EXEC SP_CREAR_FUENTE 'Evento Físico';
EXEC SP_CREAR_FUENTE 'Llamada en Frío';
GO -- Este GO separa la inserción de FUENTE del siguiente bloque.

-- Datos de ejemplo para CLIENTE (asumiendo fuente_id 1 al 5 existen)
PRINT 'Insertando datos en CLIENTE...';
EXEC SP_CREAR_CLIENTE 1, 'Juan Pérez', 'juan.perez@example.com', '987654321', 'Av. Siempre Viva 123';
EXEC SP_CREAR_CLIENTE 2, 'María García', 'maria.garcia@example.com', '912345678', 'Calle Falsa 456';
EXEC SP_CREAR_CLIENTE 3, 'Carlos López', 'carlos.lopez@example.com', '934567890', 'Jr. La Unión 789';
EXEC SP_CREAR_CLIENTE 4, 'Ana Martínez', 'ana.martinez@example.com', '956789012', 'Psje. Los Olivos 101';
EXEC SP_CREAR_CLIENTE 5, 'Pedro Sánchez', 'pedro.sanchez@example.com', '978901234', 'Urb. El Sol 202';
GO

-- Datos de ejemplo para VENDEDOR
PRINT 'Insertando datos en VENDEDOR...';
EXEC SP_CREAR_VENDEDOR 'Vendedor A', 'vendedor.a@gctelecom.com', '900000001', 'Oficina Principal';
EXEC SP_CREAR_VENDEDOR 'Vendedor B', 'vendedor.b@gctelecom.com', '900000002', 'Sucursal Norte';
EXEC SP_CREAR_VENDEDOR 'Vendedor C', 'vendedor.c@gctelecom.com', '900000003', 'Sucursal Sur';
EXEC SP_CREAR_VENDEDOR 'Vendedor D', 'vendedor.d@gctelecom.com', '900000004', 'Teletrabajo';
EXEC SP_CREAR_VENDEDOR 'Vendedor E', 'vendedor.e@gctelecom.com', '900000005', 'Oficina Central';
GO

-- Datos de ejemplo para PRODUCTO
PRINT 'Insertando datos en PRODUCTO...';
-- Ahora se incluye el parámetro @moneda
EXEC SP_CREAR_PRODUCTO 'Internet Fibra Óptica 100Mbps', 'Conexión a internet de alta velocidad', 50.00, 'PEN';
EXEC SP_CREAR_PRODUCTO 'Plan Móvil Ilimitado', 'Plan de celular con datos y llamadas ilimitadas', 30.00, 'PEN';
EXEC SP_CREAR_PRODUCTO 'Router Wi-Fi Premium', 'Router de última generación para mejor cobertura', 100.00, 'USD';
EXEC SP_CREAR_PRODUCTO 'Servicio de Soporte Técnico', 'Soporte técnico 24/7', 25.00, 'PEN';
EXEC SP_CREAR_PRODUCTO 'Paquete de Canales HD', 'Acceso a canales de alta definición', 80.00, 'USD';
GO

-- Datos de ejemplo para VENTA y DETALLE_VENTA (se omiten las inserciones)
PRINT 'Insertando datos en VENTA y DETALLE_VENTA...';
-- Se han omitido las inserciones de datos para VENTA y DETALLE_VENTA según tu solicitud.
GO

-- Datos de ejemplo para RECLAMO (se omiten las inserciones)
PRINT 'Insertando datos en RECLAMO...';
-- Se han omitido las inserciones de datos para RECLAMO según tu solicitud.
GO

-- Datos de ejemplo para EVENTO (se omiten las inserciones)
PRINT 'Insertando datos en EVENTO...';
-- Se han omitido las inserciones de datos para EVENTO según tu solicitud.
GO

PRINT '--- Inserción de datos de ejemplo completada ---';
GO
