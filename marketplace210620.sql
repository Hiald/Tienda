/*
hola@muomarket.com 2@1Mu0market
contacto@muomarket.com 2@0Mu0market

mail.muomarket.com
25
contacto@muomarket.com
no segura

protitpo 4 tablas, 4 procedimientos pass: Muo2020@.
1: categoria del producto
2: tipo de pago
3: tipo de envio
4: marca del producto
5: estado del envio
6: tipo de configuracion (si es talla, porcion, etc) FALTA AGREGAR

INSERT INTO t_maestro(nombre_data,maestro_desc,fechareg_date, activo_type)
VALUES('Categoria del producto', 'Categoria de los productos', NOW(), 1);
INSERT INTO t_maestro(nombre_data,maestro_desc,fechareg_date, activo_type)
VALUES('Tipo de pago', 'Tipo de pago', NOW(), 1);
INSERT INTO t_maestro(nombre_data,maestro_desc,fechareg_date, activo_type)
VALUES('Tipo de envio', 'Tipo de envio', NOW(), 1);
INSERT INTO t_maestro(nombre_data,maestro_desc,fechareg_date, activo_type)
VALUES('Tipo del producto', 'Tipo del producto', NOW(), 1);
INSERT INTO t_maestro(nombre_data,maestro_desc,fechareg_date, activo_type)
VALUES('Estado del envio', 'Estado del envio', NOW(), 1);
INSERT INTO t_maestro(nombre_data,maestro_desc,fechareg_date, activo_type)
VALUES('Tipo de configuracion', 'Tipo de configuracion', NOW(), 1);

INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(1, 2, 'Pago con Yape', 'Pago Yape', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(2, 2, 'Pago contra entrega', 'Pago Contra entrega', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(3, 2, 'Pago tarjeta credito', 'Pago tarjeta credito', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(4, 2, 'Pago tarjeta debito', 'Pago tarjeta debito', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(5, 2, 'Pago deposito agente / otro', 'Pago deposito agente / otro', NOW(), 1);

INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(1, 3, 'Entrega a domicilio', 'Venta Entrega a domimilio', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(2, 3, 'Recoger en tienda', 'Venta Recoger en tienda', NOW(), 1);

INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(1,5, 'Esperando tiempo de envío', 'Esperando tiempo de envío', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(2,5, 'Procesando orden en camino', 'Esperando tiempo de envío', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(3,5, 'Entregando en domicilio', 'Esperando tiempo de envío', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(4,5, 'Orden finalizada', 'Orden finalizada', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(5,5, 'Reprogramando el tiempo de llegada', 'Reprogramando el tiempo de llegada', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(6,5, 'Enviando el reembolso', 'Enviando el reembolso', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(7,5, 'Reembolsado', 'Reembolsado', NOW(), 1);

INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(1,6, 'Porción de plato', 'Porción de plato, se suele especificar si es 1 cuarto, media porción, entre otros', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(2,6, 'Complemento', 'Complemento si se desea cambiar papas por tequeños, o cambiar la entrada de algun plato', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(3,6, 'Bebida a elegir', 'Bebida a elegir, este campo suele ser variable, si es gaseosa, cerveza, etc', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(4,6, 'Talla de ropa', 'Talla de ropa ya sea camisa, pantalon, etc. Puede venir desde la XS, L, XL entre otros.', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(5,6, 'Color', 'Color de alguna prenda de vestir, o elemento electrónico', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(6,6, 'Talla de calzado', 'Tamaño en medida para el pie, ya sea para zapatillas, zapatos, etc', NOW(), 1);
INSERT INTO t_submaestro(submaestro_id,maestro_id,submaestro_data,submaestro_desc,fechareg_date, activo_type)
VALUES(7,6, 'Otra especificación', 'Alguna otra especificacion que no es muy usada', NOW(), 1);


ecommercedb2020.
-- LAS IMAGENES DEBEN SER 780x780 o 1024x1024 px
STR_TO_DATE('2020-05-24 13:16:02','%Y-%m-%d %H:%i:%s');
AAAA/MM/DD HH/MM/SS

maestro: tabla maestra
submaestro: sub tabla maestra
usuario: datos del usuario
acceso: login del usuario
historial acceso: historial del acceso del usuario
usuario tipo pago: info con datos de tarjetas o tipos de pagos
vendedor: datos del vendedor (bodega o tienda)
producto: datos del producto del vendedor
sub producto: pedidos adicionales del producto
venta: pago final del usuario
sub venta: detalle de la venta
envio: informacion final para el delivery (si es que hay)
vendedor valoracion: valoracion del vendedor
*/

-- (contiene opciones generales sea como categorias, tipo de incidencia, etc)
CREATE TABLE IF NOT EXISTS t_maestro( 
  `maestro_id` INT NOT NULL AUTO_INCREMENT,
  `nombre_data` VARCHAR(50) NULL,
  `maestro_desc` VARCHAR(250) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
PRIMARY KEY (`maestro_id`));

-- (contiene los valores de maestro sea como categoria 1,categoria 2, etc)
CREATE TABLE IF NOT EXISTS t_submaestro(
  `submaestro_id` INT,
  `maestro_id` INT,
  `submaestro_data` VARCHAR(50) NULL,
  `submaestro_desc` VARCHAR(250) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (maestro_id) REFERENCES t_maestro(maestro_id));

-- (contiene la informacion del usuario consumidor que compra los productos)
CREATE TABLE IF NOT EXISTS t_usuario(
  `usuario_id` INT NOT NULL AUTO_INCREMENT,
  `nombre_data` VARCHAR(150) NULL,
  `apellido_data` VARCHAR(150) NULL,
  `celular_data` VARCHAR(15) NULL,
  `telefono_data` VARCHAR(15) NULL,
  `pais_num` INT NULL,
  `direccion_desc` VARCHAR(250) NULL,
  `numero_data` VARCHAR(25) NULL,
  `estado_provincia_region_num` INT NULL,
  `ciudad_num` INT NULL,
  `zip_codigopostal_data` VARCHAR(150) NULL,
  `dni_data` VARCHAR(25) NULL,
  `ruc_data` VARCHAR(25) NULL,
  `imagen_data` VARCHAR(500) NULL,
  `fecha_nacimiento_date` DATETIME NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
PRIMARY KEY (`usuario_id`));

-- (credenciales de inicio de sesion de usuario)
CREATE TABLE IF NOT EXISTS t_acceso(
  `acceso_id` INT NOT NULL AUTO_INCREMENT,
  `usuario_id` INT,
  `correo_data` VARCHAR(150) NULL,
  `clave_data` VARCHAR(50) NULL,
  `token_data` VARCHAR(500) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (usuario_id) REFERENCES t_usuario(usuario_id),
PRIMARY KEY (`acceso_id`));

/* datos usuario logeo cuenta */
CREATE TABLE IF NOT EXISTS t_acceso_historial(
  `accesohistorial_id`  INT NOT NULL AUTO_INCREMENT,
  `usuario_id`  INT,
  `direccionip_data` VARCHAR(50) NULL,
  `direccionmac_data` VARCHAR(50) NULL,
  `conexion_type` TINYINT(1) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (usuario_id) REFERENCES t_usuario(usuario_id),
PRIMARY KEY (`accesohistorial_id`));

-- (informacion de pago de usuario, tarjeta)
CREATE TABLE IF NOT EXISTS t_usuario_tipo_pago(
  `tipopago_id` INT NOT NULL AUTO_INCREMENT,
  `usuario_id` INT,
  `tarjeta_type` TINYINT(1) NULL,
  `ppan_data` VARCHAR(150) NULL,
  `ccv_data` VARCHAR(500) NULL,
  `token_data` VARCHAR(500) NULL,
  `anio_data` VARCHAR(500) NULL,
  `mes_data` VARCHAR(500) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (usuario_id) REFERENCES t_usuario(usuario_id),
PRIMARY KEY (`tipopago_id`));

-- (contiene la informacion del vendedor que ofrece productos)
CREATE TABLE IF NOT EXISTS t_vendedor(
  `vendedor_id` INT NOT NULL AUTO_INCREMENT,
  `nombre_data`  VARCHAR(150) NULL,
  `apellido_data` VARCHAR(150) NULL,
  `empresa_data` VARCHAR(150) NULL,
  `ruc_data` VARCHAR(25) NULL,
  `dni_data` VARCHAR(25) NULL,
  `celular1_data` VARCHAR(15) NULL,
  `celular2_data` VARCHAR(15) NULL,
  `correo_data` VARCHAR(150) NULL,
  `pais_num` INT NULL,
  `direccion_desc` VARCHAR(250) NULL,
  `numero_data` VARCHAR(25) NULL,
  `estado_provincia_region_num` INT NULL,
  `ciudad_num` INT NULL,
  `zip_codigopostal_data` VARCHAR(150) NULL,
  `imagen_data` VARCHAR(500) NULL,
  `fecha_empresa_creacion_date` DATETIME NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
PRIMARY KEY (`vendedor_id`));

-- (credenciales de inicio de sesion de usuario)
CREATE TABLE IF NOT EXISTS t_acceso_vendedor(
  `accesovendedor_id` INT NOT NULL AUTO_INCREMENT,
  `vendedor_id` INT,
  `correo_data` VARCHAR(150) NULL,
  `clave_data` VARCHAR(50) NULL,
  `token_data` VARCHAR(500) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
PRIMARY KEY (`accesovendedor_id`));

/* datos usuario logeo cuenta */
CREATE TABLE IF NOT EXISTS t_acceso_historial_vendedor(
  `historialvendedor_id`  INT NOT NULL AUTO_INCREMENT,
  `vendedor_id` INT,
  `direccionip_data` VARCHAR(50) NULL,
  `direccionmac_data` VARCHAR(50) NULL,
  `conexion_type` TINYINT(1) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
PRIMARY KEY (`historialvendedor_id`));

-- (se guarda la informacion de los articulos a vender por los vendedores)
CREATE TABLE IF NOT EXISTS t_producto(
  `producto_id` INT NOT NULL AUTO_INCREMENT,
  `vendedor_id`  INT,
  `producto_data` VARCHAR(150) NULL, -- nombre
  `producto_desc` VARCHAR(250) NULL, -- descripcion
  `categoria_type` TINYINT(1) NULL,
  `material_desc` VARCHAR(250) NULL,
  `marca_desc` VARCHAR(50) NULL,
  `peso_dec` DECIMAL(10, 2) NULL,
  `modelo_desc` VARCHAR(150) NULL,
  `medida_desc` VARCHAR(150) NULL,
  `promocion_type` TINYINT(1) NULL,
  `precio_dec` DECIMAL(10, 2) NULL,
  `preciopromocion_dec` DECIMAL(10, 2) NULL,
  `fecha_ini_promocion_date` DATETIME NULL,
  `fecha_fin_promocion_date` DATETIME NULL,
  `imagen1_data` VARCHAR(250) NULL,
  `imagen2_data` VARCHAR(250) NULL,
  `imagen3_data` VARCHAR(250) NULL,
  `imagen4_data` VARCHAR(250) NULL,
  `imagen5_data` VARCHAR(250) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
PRIMARY KEY (`producto_id`));

-- el adicional para los productos, ejemplo:
-- puede ser los productos adicionales (gaseosa, o mayonesa adicional )
CREATE TABLE IF NOT EXISTS t_adicional(
  `adicional_id` INT NOT NULL AUTO_INCREMENT,
  `vendedor_id` INT,
  `adicional_data` VARCHAR(50) NULL,
  `adicional_desc` VARCHAR(50) NULL,
  `precio_dec` DECIMAL(10,2) NULL,
  `adicional_type` TINYINT(1) NULL, -- SI ES GRATUITO O NO (mayonesa extra, una gaseosa extra 3L, etc)
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
PRIMARY KEY (`adicional_id`));

-- configura el producto si cuenta con talla, medida, campos obligatorios a seleccionar antes de agregar al carrito
-- OJO: no cuestan estos campos, solo tienen un valor por ejemplo (seleccionar gaseosa: Inka kola, coca cola,etc | Seleccionar talla: S, M ,XL, etc)
-- esto saldra debajo del precio y seran campos a seleccionar
CREATE TABLE IF NOT EXISTS t_configuracion(
  `configuracion_id` INT NOT NULL AUTO_INCREMENT,
  `vendedor_id` INT,
  `configuracion_data` VARCHAR(50) NULL,
  `configuracion_desc` VARCHAR(50) NULL,
  `valor_data` VARCHAR(100) NULL, -- el valor, si es XL, color rosado, etc
  `configuracion_type` INT NULL, -- si es talla, adicional ropa ,etc 
  -- (configuracion_type: por este campo se va a dividir al seleccionar al carrito) unidad de medida (estara registrado en submaestro)
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
PRIMARY KEY (`configuracion_id`));

-- se guarda la informacion los articulos adicionales al producto general 
-- existen gratuitos (mayonesa, aji, pasador, etc)
-- existen de paga (una gaseosa 3L extra, calcentines adicionales, pan al ajo extra, etc )
CREATE TABLE IF NOT EXISTS t_subProducto(
  `subProducto_id` INT NOT NULL AUTO_INCREMENT,
  `producto_id` INT,
  `adicional_id` INT,
  `fechareg_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  FOREIGN KEY (producto_id) REFERENCES t_producto(producto_id),
  FOREIGN KEY (adicional_id) REFERENCES t_adicional(adicional_id),
PRIMARY KEY (`subProducto_id`));

-- enlaza la configuracion con el producto
-- OJO: el producto puede tener varias configuraciones por ejemplo (seleccionar gaseosa: inca kola, y la porcion)
-- esto saldra debajo del precio y seran campos a seleccionar
CREATE TABLE IF NOT EXISTS t_especificacion(
  `especificacion_id` INT NOT NULL AUTO_INCREMENT,
  `configuracion_id` INT,
  `producto_id` INT,
  `fechareg_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  FOREIGN KEY (configuracion_id) REFERENCES t_configuracion(configuracion_id),
  FOREIGN KEY (producto_id) REFERENCES t_producto(producto_id),
PRIMARY KEY (`especificacion_id`));

-- (registro de ventas)
CREATE TABLE IF NOT EXISTS t_venta(
  `venta_id` INT NOT NULL AUTO_INCREMENT,
  `vendedor_id` INT,
  `usuario_id` INT,
  `monto_dec` DECIMAL(10,2) NULL,
  `igv_dec` DECIMAL(10, 2) NULL,
  `total_dec` DECIMAL(10, 2) NULL,
  `venta_type` TINYINT(1) NULL, -- tipo de envio, si es a domicilio o contra entrega
  `pago_type` TINYINT(1) NULL, /* en que estado esta, si ha pagado, reembolsado, etc */
  `pago_desc` VARCHAR(250) NULL, /* descripcion del tipo de pago */
  `comision_dec` DECIMAL(10, 2) NULL, /* PAGOS DEL DELIVERY, en caso sea contra entrega el monto es 0 | comision si se le paga al motorizado */
  `envio_dec` DECIMAL(10, 2) NULL, /* PAGOS DEL DELIVERY VERDADERO, en caso sea contra entrega el monto es 0 */
  `observacion_desc` VARCHAR(500) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  `fecharegNotificacion_date` DATETIME NULL,
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
  FOREIGN KEY (usuario_id) REFERENCES t_usuario(usuario_id),
PRIMARY KEY (`venta_id`));

-- (lista de articulos del carro de compra)
CREATE TABLE IF NOT EXISTS t_subventa(
  `subventa_id` INT NOT NULL AUTO_INCREMENT,
  `venta_id` INT,
  `producto_id` INT,
  `cantidad_num` INT NULL,
  `subtotal_dec` DECIMAL(10, 2) NULL,
  `descripcionAdicional_desc` VARCHAR(250) NULL, -- agregar para detallar por cada producto
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (producto_id) REFERENCES t_producto(producto_id),
  FOREIGN KEY (venta_id) REFERENCES t_venta(venta_id),
PRIMARY KEY (`subventa_id`));

-- registra el adicional realizado por el usuario
CREATE TABLE IF NOT EXISTS t_VentaAdicional(
  `ventaAdicional_id` INT NOT NULL AUTO_INCREMENT,
  `subProducto_id` INT,
  `venta_id` INT,
  `adicional_id` INT,
  `adicional_data` VARCHAR(50) NULL,
  `precio_dec` DECIMAL(10,2) NULL,
  `adicional_type` TINYINT(1) NULL, -- SI ES GRATUITO O NO (mayonesa extra, una gaseosa extra 3L, etc)
  `fechareg_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  FOREIGN KEY (venta_id) REFERENCES t_venta(venta_id),
  FOREIGN KEY (adicional_id) REFERENCES t_adicional(adicional_id),
  FOREIGN KEY (subProducto_id) REFERENCES t_subProducto(subProducto_id),
PRIMARY KEY (`ventaAdicional_id`));

-- registra las configuraciones (tallas, marca de gaseosa) que han sido seleccionadas por cada producto pagado
CREATE TABLE IF NOT EXISTS t_configuracion_venta(
  `configuracionVenta_id` INT NOT NULL AUTO_INCREMENT,
  `especificacion_id` INT,
  `venta_id` INT,
  `configuracion_id` INT,
  `valor_data` VARCHAR(100) NULL, -- el valor, si es XL, color rosado, etc
  `configuracion_type` INT, -- si es talla, adicional ropa ,etc
  -- (configuracion_type: por este campo se va a dividir al seleccionar al carrito) unidad de medida (estara registrado en submaestro)
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (venta_id) REFERENCES t_venta(venta_id),
  FOREIGN KEY (configuracion_id) REFERENCES t_configuracion(configuracion_id),
  FOREIGN KEY (especificacion_id) REFERENCES t_especificacion(especificacion_id),
PRIMARY KEY (`configuracionVenta_id`));

-- (para el usuario pueda ver sus entregas hechas y a realizar) FALTA UN SUB ENVIO PARA HISTORIAL DE ESTADO DE ENVIO 
-- (cada estado por el que pase sera una fila en sub envio ejemplo: id1:envuelto,id2:encamino)
CREATE TABLE IF NOT EXISTS t_envio(
  `envio_id` INT NOT NULL AUTO_INCREMENT,
  `usuario_id` INT,
  `venta_id` INT,
  `vendedor_id` INT,
  `nombre_data` INT, -- nombre de la persona que va a recoger el pedido
  `numero_data` VARCHAR(25) NULL, -- celular o telefono
  `direccion_desc` VARCHAR(250) NULL, -- direccion o calle
  `piso_desc` VARCHAR(250) NULL, -- numero / piso, etc
  `pais_num` INT NULL,
  `distrito_num` INT NULL, -- distrito
  `estado_provincia_region_num` INT NULL,
  `estado_provincia_region_desc` VARCHAR(250) NULL, -- estado provincia region
  `ciudad_num` INT NULL,
  `ciudad_desc` VARCHAR(150) NULL, -- ciudad
  `zip_codigopostal_data` VARCHAR(150) NULL, -- codigo postal
  `entregado_type` BIT(1) NULL,
  `estado_envio_type` TINYINT(1) NULL,
  `enviado_type` TINYINT(1) NULL,
  `fecha_entrega_date` DATETIME NULL,
  `hora_entrega` VARCHAR(25) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  `fecharegNotificacion_date` DATETIME NULL,
  FOREIGN KEY (usuario_id) REFERENCES t_usuario(usuario_id),
  FOREIGN KEY (venta_id) REFERENCES t_venta(venta_id),
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
PRIMARY KEY (`envio_id`));

-- (calificacion que le dan al vendedor de acuerdo a cada venta)
CREATE TABLE IF NOT EXISTS t_vendedor_valoracion(
  `valoracionvendedor_id` INT NOT NULL AUTO_INCREMENT,
  `vendedor_id` INT,
  `usuario_id` INT,
  `venta_id` INT,
  `puntaje_num` INT NULL,
  `valoracion_desc` VARCHAR(250) NULL,
  `fechareg_date` DATETIME NULL,
  `fechamod_date` DATETIME NULL,
  `activo_type` BIT(1) NULL,
  `modificado_type` BIT(1) NULL,
  FOREIGN KEY (vendedor_id) REFERENCES t_vendedor(vendedor_id),
  FOREIGN KEY (usuario_id) REFERENCES t_usuario(usuario_id),
  FOREIGN KEY (venta_id) REFERENCES t_venta(venta_id),
PRIMARY KEY (`valoracionvendedor_id`));

-- (contiene opciones generales sea como categorias, tipo de incidencia, etc)
CREATE TABLE IF NOT EXISTS t_categoria(
  `categoria_id` INT NOT NULL AUTO_INCREMENT,
  `nombre_data` VARCHAR(50) NULL,
  `icono_codigo_data` VARCHAR(50) NULL,
PRIMARY KEY (`categoria_id`));

-- informacion de gente registrandose
CREATE TABLE IF NOT EXISTS dato_lead(
  `idlead` INT NOT NULL AUTO_INCREMENT,
  `nombretienda` VARCHAR(50) NULL,
  `nombre` VARCHAR(50) NULL,
  `celular` VARCHAR(9) NULL,
  `tiponegocio` INT NULL,
  `ruc` VARCHAR(50) NULL,
  `direccion` VARCHAR(150) NULL,
  `departamento` INT NULL,  
  `correo` VARCHAR(50) NULL,
  `activo` INT NULL,
  `modificado` INT NULL,
  `fechareg` DATETIME NULL,  
  `fechamod` DATETIME NULL,
PRIMARY KEY (`idlead`));

-- -----------------------------------------------------------------------------------
-- VERSION 2 = 22 TABLAS









































-- CUENTA INI 

-- valida si existe el correo al registrar la cuenta
/*DROP procedure IF EXISTS `s_usuario_validarcorreo`;*/
DELIMITER $$
CREATE PROCEDURE `s_usuario_validarcorreo` (IN _pCorreoData VARCHAR(150))
BEGIN

IF EXISTS(SELECT usuario_id FROM t_acceso WHERE `correo_data` =  _pCorreoData) THEN
BEGIN
	SELECT 1 as '_result';
END;
ELSE
BEGIN
	SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;

-- -----------------------------------------------------------------------------------
-- valida si existe el correo al registrar la cuenta
/*DROP procedure IF EXISTS `s_vendedor_validarcorreo`;*/
DELIMITER $$
CREATE PROCEDURE `s_vendedor_validarcorreo` (IN _pCorreoData VARCHAR(150))
BEGIN

IF EXISTS(SELECT vendedor_id FROM t_acceso_vendedor WHERE `correo_data` =  _pCorreoData) THEN
BEGIN
  SELECT 1 as '_result';
END;
ELSE
BEGIN
  SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;

-- --------------------------------------------------------

-- logeo a la plataforma (inicio de sesion)
/*DROP procedure IF EXISTS `s_usuario_acceso`;*/

DELIMITER $$
CREATE PROCEDURE `s_usuario_acceso` (IN _pCorreoData VARCHAR(150), IN _pClaveData VARCHAR(50))
BEGIN

IF EXISTS(SELECT usuario_id FROM t_acceso WHERE `correo_data` =  _pCorreoData AND `activo_type` = 1) THEN
BEGIN
	DECLARE _result INT DEFAULT -1;	 
    SET _result = (SELECT IFNULL((SELECT usuario_id FROM t_acceso WHERE `correo_data` =  _pCorreoData AND `clave_data` = _pClaveData),0) as '_result');
    SELECT _result;
END;
ELSE
BEGIN	
	SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;
-- ------------------------------------------------------------------------------------

-- logeo a la plataforma (inicio de sesion)
/*DROP procedure IF EXISTS `s_proveedor_acceso`;*/

DELIMITER $$
CREATE PROCEDURE `s_proveedor_acceso` (IN _pCorreoData VARCHAR(150), IN _pClaveData VARCHAR(50))
BEGIN

IF EXISTS(SELECT vendedor_id FROM t_acceso_vendedor WHERE `correo_data` =  _pCorreoData AND `activo_type` = 1) THEN
BEGIN
  DECLARE _result INT DEFAULT -1;  
    SET _result = (SELECT IFNULL((SELECT vendedor_id FROM t_acceso_vendedor WHERE `correo_data` =  _pCorreoData AND `clave_data` = _pClaveData),0) as '_result');
    SELECT _result;
END;
ELSE
BEGIN 
  SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;

-- ------------------------------------------------------------------------------------

-- lista al usuario para la sesion
/*DROP procedure IF EXISTS `s_usuario_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_usuario_listar` (IN _pUsuarioId INT)
BEGIN

SELECT
  u.usuario_id
  ,u.nombre_data
  ,u.apellido_data
  ,DATE_FORMAT(u.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,u.activo_type
  ,CONCAT_WS(' ',u.nombre_data, u.apellido_data) as 'nombrecompleto_data'
  ,(SELECT t1.correo_data FROM t_acceso t1 where t1.usuario_id = _pUsuarioId) as 'correo_data'
    
FROM t_usuario as u where u.usuario_id = _pUsuarioId AND u.activo_type = 1;

END$$
DELIMITER ;

-- ------------------------------------------------------------------------------------

/*DROP procedure IF EXISTS `s_vendedor_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_vendedor_listar` (IN _pVendedorId INT)
BEGIN

SELECT
  u.vendedor_id
  ,u.nombre_data
  ,u.apellido_data
  ,DATE_FORMAT(u.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,u.activo_type
  ,CONCAT_WS(' ',u.nombre_data, u.apellido_data) as 'nombrecompleto_data'
  ,(SELECT t1.correo_data FROM t_acceso_vendedor t1 where t1.vendedor_id = _pVendedorId) as 'correo_data'
    
FROM t_vendedor as u where u.vendedor_id = _pVendedorId AND u.activo_type = 1;

END$$
DELIMITER ;

-- ------------------------------------------------------------------------------------

-- registro de usuario al crear cuenta
/*DROP procedure IF EXISTS `s_usuario_registrar`;*/
DELIMITER $$
CREATE PROCEDURE `s_usuario_registrar` 
(IN _pNombreData VARCHAR(150)
,IN _pApellidoData VARCHAR(150)
,IN _pCorreoData VARCHAR(150)
,IN _pClaveData VARCHAR(50))
BEGIN

INSERT INTO t_usuario 
	  (nombre_data
    ,apellido_data
    ,fechareg_date
    ,activo_type)
VALUES 
(_pNombreData
	,_pApellidoData
	,NOW()
	,1
);

INSERT INTO t_acceso 
  (usuario_id
  ,correo_data
  ,clave_data
  ,fechareg_date
  ,activo_type
    )
VALUES 
( 
  LAST_INSERT_ID()
  ,_pCorreoData
  ,_pClaveData 
  ,NOW()
  ,1
);

SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- ------------------------------------------------------------------------------------

-- registro de vendedor al crear cuenta
/*DROP procedure IF EXISTS `s_vendedor_registrar`;*/
DELIMITER $$
CREATE PROCEDURE `s_vendedor_registrar` 
(IN _pNombreData VARCHAR(150)
,IN _pApellidoData VARCHAR(150)
,IN _pCelular1Data VARCHAR(15)
,IN _pCorreoData VARCHAR(150)
,IN _pClaveData VARCHAR(50))
BEGIN

INSERT INTO t_vendedor 
    (nombre_data
    ,apellido_data
    ,celular1_data
    ,fechareg_date
    ,activo_type)
VALUES 
(_pNombreData
  ,_pApellidoData
  ,_pCelular1Data
  ,NOW()
  ,1
);

INSERT INTO t_acceso_vendedor 
  (vendedor_id
  ,correo_data
  ,clave_data
  ,fechareg_date
  ,activo_type
    )
VALUES 
( 
  LAST_INSERT_ID()
  ,_pCorreoData
  ,_pClaveData 
  ,NOW()
  ,1
);

SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- CUENTA FIN 8
-- ------------------------------------------------------------------------------------













































-- INI VENDEDOR
-- ------------------------------------------------------------------------------------
-- VENDEDOR 

-- lista los datos de la tabla submaestro basandose del id de maestro
-- PROCEDIMIENTO GENERAL
/*DROP procedure IF EXISTS `s_maestro_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_maestro_listar` (IN _pMaestroId INT)
BEGIN

SELECT
  m.maestro_id
  ,m.nombre_data
  ,sm.submaestro_id
  ,sm.submaestro_data
  ,sm.submaestro_desc
  ,DATE_FORMAT(sm.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,sm.activo_type
FROM t_maestro as m INNER JOIN t_submaestro as sm WHERE m.maestro_id = sm.maestro_id
AND sm.activo_type = 1 AND m.activo_type = 1 AND m.maestro_id = _pMaestroId;

END$$
DELIMITER ;

-- ------------------------------------------------------------------------------------

-- lista la sub venta de cada compra hecha
-- PROCEDIMIENTO GENERAL
/*DROP procedure IF EXISTS `s_subVenta_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_subVenta_listar` (IN _pventaid INT)
BEGIN

SELECT
  v.venta_id
  ,v.subventa_id
  ,p.producto_id
  ,p.producto_data
  ,p.imagen1_data
  ,v.cantidad_num
  ,v.subtotal_dec
  ,v.descripcionAdicional_desc
FROM t_subventa v LEFT JOIN t_producto p ON v.producto_id = p.producto_id
WHERE v.activo_type = 1 AND v.venta_id = _pventaid;

END$$
DELIMITER ;

-- -------------------------------------------------------------------------

-- Registra el historial de logueo de sesion del vendedor
-- VENDEDOR
/*DROP procedure IF EXISTS `s_historial_vendedor_insertar`;*/
DELIMITER $$
CREATE PROCEDURE `s_historial_vendedor_insertar` 
(
  IN _pvendedor_id INT  
  ,IN _pdireccionip_data VARCHAR(250)
  ,IN _pdireccionmac_data VARCHAR(250)
  ,IN _pconexion_type TINYINT(1)
)
BEGIN

INSERT INTO t_acceso_historial_vendedor
(
  vendedor_id  
  ,direccionip_data
  ,direccionmac_data
  ,conexion_type
  ,fechareg_date
  ,activo_type
)
VALUES
(
  _pvendedor_id  
  ,_pdireccionip_data
  ,_pdireccionmac_data
  ,_pconexion_type
  ,NOW()
  ,1
);

END$$
DELIMITER ;

-- -------------------------------------------------------------------------

-- Lista la categoria
-- PROCEDIMIENTO GENERAL
DELIMITER $$
CREATE PROCEDURE s_categoria_listar()
BEGIN
  SELECT * FROM t_categoria;
END$$;
DELIMITER ;

-- -------------------------------------------------------------------------

-- (VER SI SE USA O NO)
-- lista productos por cada vendedor (al entrar a la tienda del vendedor)
-- VENDEDOR
/*DROP procedure IF EXISTS `s_producto_vendedor_listar`;*/
/*DELIMITER $$
CREATE PROCEDURE `s_producto_vendedor_listar` (IN _pVendedorId INT)
BEGIN

SELECT
  p.producto_id
  ,p.vendedor_id
  ,(SELECT sm.nombre_data FROM t_submaestro sm WHERE sm.maestro_id = 1 AND sm.submaestro = p.categoria_type) as 'categoria_type'
  ,p.producto_data  
  ,p.preciopromocion_dec
  ,p.precio_dec
  ,p.producto_desc
  ,p.promocion_type
FROM t_producto as p where p.vendedor_id = _pVendedorId AND p.activo_type = 1;

END$$
DELIMITER ;
*/

-- ------------------------------------------------------------------------------------

-- Lista los productos del vendedor
-- VENDEDOR
/*DROP procedure IF EXISTS `s_productoVendedor_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_productoVendedor_listar` (
IN _pproducto_data varchar(150)
, IN _pNumeroPagina INT
, IN _pTotalPagina INT
, IN _pvendedorid INT)
BEGIN
  DECLARE _offset INT DEFAULT 1;
    SET _offset = (_pNumeroPagina - 1) * _pTotalPagina;
    
SELECT
    p.producto_id
    ,p.producto_data
    ,c.nombre_data
    ,c.categoria_id
    ,p.precio_dec
    ,p.promocion_type
    ,p.preciopromocion_dec
    ,DATE_FORMAT(p.fecha_ini_promocion_date, '%Y-%m-%d') as 'fecha_ini_promocion_date'
    ,DATE_FORMAT(p.fecha_fin_promocion_date, '%Y-%m-%d') as 'fecha_fin_promocion_date'
FROM t_producto p LEFT JOIN t_categoria c 
on c.categoria_id = p.categoria_type
    WHERE p.producto_data like CONCAT_WS('%',_pproducto_data,'%')
    AND p.activo_type = 1
    AND p.vendedor_id = _pvendedorid
  LIMIT _pTotalPagina OFFSET _offset;
  
END$$
DELIMITER ;

-- -----------------------------------------------------------

-- Registra el producto por el vendedor
-- VENDEDOR
/*DROP procedure IF EXISTS `s_producto_registrar`;*/
DELIMITER $$
CREATE PROCEDURE s_producto_registrar(
IN _pvendedor_id INT
,IN _pcategoria_type TINYINT(1)
,IN _pproducto_data VARCHAR(150)
,IN _pproducto_desc VARCHAR(250)
,IN _pprecio_dec decimal(10,2)
,IN _pimagen1_data VARCHAR(250)
,IN _pimagen2_data VARCHAR(250)
,IN _pimagen3_data VARCHAR(250)
,IN _pimagen4_data VARCHAR(250)
,IN _pimagen5_data VARCHAR(250)
,IN _pfechareg_date VARCHAR(25))
BEGIN
  INSERT INTO t_producto(
    vendedor_id    
    ,categoria_type
    ,producto_data
    ,producto_desc    
    ,precio_dec    
    ,imagen1_data
    ,imagen2_data
    ,imagen3_data
    ,imagen4_data
    ,imagen5_data
    ,promocion_type
    ,fechareg_date    
    ,activo_type
    )
values
  (
  _pvendedor_id
  ,_pcategoria_type
  ,_pproducto_data
  ,_pproducto_desc
  ,_pprecio_dec
  ,_pimagen1_data
  ,_pimagen2_data
  ,_pimagen3_data
  ,_pimagen4_data
  ,_pimagen5_data
  ,0
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
  ,1);

SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- -------------------------------------------------------------------------

-- obtiene los datos del producto a editar
-- VENDEDOR
/*DROP procedure IF EXISTS `s_productoVendedor_editar`;*/
DELIMITER $$
CREATE PROCEDURE `s_productoVendedor_editar` (IN _pproductoid INT)
BEGIN

SELECT
p.producto_id
,p.vendedor_id
,p.producto_data
,p.producto_desc
,p.precio_dec
,p.imagen1_data
,p.imagen2_data
,p.imagen3_data
,p.imagen4_data
,p.imagen5_data
,p.peso_dec
,DATE_FORMAT(p.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
,c.nombre_data -- nombre de la categoria
,c.categoria_id -- id de la categoria
FROM t_producto p LEFT JOIN t_categoria c 
on c.categoria_id = p.categoria_type
    WHERE p.producto_id = _pproductoid AND p.activo_type = 1;

END$$
DELIMITER ;

-- ---------------------------------------------------------------------------------------


-- Actualiza la informacion del producto
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE s_producto_actualizar(
IN _pproducto_id INT
,IN _pcategoria_type TINYINT(1)
,IN _pproducto_data VARCHAR(150)
,IN _pproducto_desc VARCHAR(250)
,IN _pmaterial_desc VARCHAR(250)
,IN _pmarca_desc VARCHAR(50)
,IN _ppeso_dec DECIMAL(10,2)
,IN _pmodelo_desc VARCHAR(150)
,IN _pmedida_desc VARCHAR(150)
,IN _pprecio_dec DECIMAL(10,2)
,IN _pimagen1_data VARCHAR(250)
,IN _pimagen2_data VARCHAR(250)
,IN _pimagen3_data VARCHAR(250)
,IN _pimagen4_data VARCHAR(250)
,IN _pimagen5_data VARCHAR(250)
,IN _pfechamod_date VARCHAR(25)
,IN _pmodificado_type TINYINT(1))
BEGIN
UPDATE t_producto
SET
categoria_type = _pcategoria_type,
producto_data = _pproducto_data,
producto_desc = _pproducto_desc,
material_desc = _pmaterial_desc,
marca_desc = _pmarca_desc,
peso_dec = _ppeso_dec,
modelo_desc = _pmodelo_desc,
medida_desc = _pmedida_desc,
precio_dec = _pprecio_dec,
fechamod_date = _pfechamod_date,
modificado_type = _pmodificado_type
WHERE producto_id = _pproducto_id;

END $$;
DELIMITER ;

-- ----------------------------------------------------------------------------

-- desactiva el activo de cada producto
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE s_producto_eliminar(in _pproducto_id int)
begin
UPDATE t_producto
SET
activo_type = 0
WHERE 
producto_id = _pproducto_id;
END$$;
DELIMITER ;

-- ----------------------------------------------------------------------------

-- Actualiza la promocion del producto
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE s_producto_actualizar_promocion(
IN _pproducto_id INT
,IN _pprecio_dec DECIMAL(10,2)
,IN _ppromocion_type TINYINT(1)
,IN _ppreciopromocion_dec DECIMAL(10,2)
,IN _pfecha_ini_promocion_date VARCHAR(25)
,IN _pfecha_fin_promocion_date VARCHAR(25)
)
BEGIN
UPDATE t_producto
SET
promocion_type = _ppromocion_type,
preciopromocion_dec = _ppreciopromocion_dec,
fecha_ini_promocion_date = STR_TO_DATE(_pfecha_ini_promocion_date,'%Y-%m-%d'),
fecha_fin_promocion_date = STR_TO_DATE(_pfecha_fin_promocion_date,'%Y-%m-%d')
WHERE producto_id = _pproducto_id;

END $$;
DELIMITER ;

-- --------------------------------------------------------------------------

-- Registra la categoria
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE s_categoria_registrar(
IN _pnombre_data VARCHAR(150)
,IN _picono_codigo_data VARCHAR(50))
BEGIN
  INSERT INTO t_categoria(
    nombre_data
    ,icono_codigo_data)
    VALUES(
    _pnombre_data
    ,_picono_codigo_data);
END$$;
DELIMITER ;

-- --------------------------------------------------------------------------

-- Desactiva la categoria del producto
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE s_categoria_eliminar(in _pcategoria_id int)
BEGIN
  delete from t_categoria where categoria_id = _pcategoria_id; 
END$$;
DELIMITER ;

-- --------------------------------------------------------------------------

-- actualiza la categoria del producto
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE s_categoria_actualizar(
in _pcategoria_id int
,in _pnombre_data varchar(150)
,in _picono_codigo_data varchar(50))
BEGIN
  UPDATE t_categoria
    SET 
    nombre_data = _pnombre_data
    ,icono_codigo_data = _picono_codigo_data
    WHERE categoria_id = _pcategoria_id; 
END $$;
DELIMITER ;

-- --------------------------------------------------------------

-- Lista los envios pendientes del vendedor
-- VENDEDOR
/*DROP procedure IF EXISTS `s_envio_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_envio_listar` (IN _pvendedorid INT)
BEGIN

SELECT
e.envio_id
,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = e.usuario_id) as 'usuario_data'
,e.usuario_id
,e.vendedor_id
,(SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = e.vendedor_id) as 'vendedor_data'
,e.venta_id
,e.entregado_type -- si es 1 es envio finalizado si es 0 es que todavia falta
,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 5 AND sm.submaestro_id = e.estado_envio_type) as 'estado_envio_type' -- estado en formato caracter
,e.estado_envio_type as 'iestado_envio_type' -- Actualiza la informacion con el estado del envio
,e.nombre_data -- nombre de la persona que recepciona
,e.direccion_desc -- calle avenida etc
,e.numero_data -- celular o telefono
,e.piso_desc -- numero / piso
,e.distrito_num -- FALTA el submaestro
,e.estado_provincia_region_num -- FALTA el submaestro
,e.estado_provincia_region_desc  
,e.ciudad_num -- FALTA el submaestro
,e.ciudad_desc
,e.pais_num -- FALTA el submaestro
,e.zip_codigopostal_data
,DATE_FORMAT(e.fecha_entrega_date, '%d-%m-%Y %H:%i:%s') as 'fecha_entrega_date'
,e.hora_entrega
,e.activo_type
,DATE_FORMAT(e.fechareg_date, '%d-%m-%Y %H:%i:%s') as 'fechareg_date'
FROM t_envio e WHERE e.activo_type = 1 
AND e.vendedor_id = _pvendedorid 
  ORDER BY e.fecharegNotificacion_date DESC;

END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- Actualiza el tiempo de entrega, hora, etc
-- VENDEDOR
/*DROP procedure IF EXISTS `s_envio_actualizar`;*/
DELIMITER $$
CREATE PROCEDURE s_envio_actualizar(
IN _pidenvio INT
,IN _pentregado_type TINYINT(1)
,IN _pestado_envio_type TINYINT(1)
,IN _pfecha_entrega_date VARCHAR(25)
,IN _phora_entrega VARCHAR(25)
,IN _pfechamod_date VARCHAR(25)
)
BEGIN
  UPDATE t_envio
  SET
  entregado_type = _pestado_envio_type
  ,estado_envio_type = _pestado_envio_type
  ,fecha_entrega_date = STR_TO_DATE(_pfecha_entrega_date,'%Y-%m-%d')
  ,hora_entrega = _phora_entrega
  ,fechamod_date = _pfechamod_date
  ,modificado_type = 1
  WHERE envio_id = _pidenvio;

END$$;
DELIMITER ;

-- ----------------------------------------------------------------------

-- Lista las ventas realizadas por el usuario
-- VENDEDOR
/*DROP procedure IF EXISTS `s_venta_listar_vendedor`;*/
DELIMITER $$
CREATE PROCEDURE `s_venta_listar_vendedor` (IN _pvendedor_id INT)
BEGIN

SELECT
  (SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = v.vendedor_id) as 'vendedor_data'
  ,v.venta_id
  ,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = v.usuario_id) as 'usuario_data'
  ,v.monto_dec
  ,v.igv_dec
  ,v.total_dec
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 3 AND sm.submaestro_id = v.venta_type) as 'venta_type'
  ,v.pago_desc -- nombre del que recepciona el pedido
  ,v.comision_dec -- pago del delivery
  ,v.observacion_desc
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 2 AND sm.submaestro_id = v.pago_type) as 'pago_type'
  ,DATE_FORMAT(v.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,v.activo_type
FROM t_venta v WHERE v.activo_type = 1 
AND v.vendedor_id = _pvendedor_id
  ORDER BY v.fecharegNotificacion_date DESC;

END$$
DELIMITER ;

-- ---------------------------------------------------------------------

-- cambia el estado de la venta, para pasar de estado a otro
-- VENDEDOR
/*DROP procedure IF EXISTS `s_venta_actualizar`;*/
DELIMITER $$
CREATE PROCEDURE s_venta_actualizar(
IN _pventa_id INT
,IN _pventa_type TINYINT(1)
,IN _pfechamod_date VARCHAR(25)
)
BEGIN
  UPDATE t_venta
  SET
  venta_type = _pventa_type
  ,modificado_type = 1
    ,fechamod_date = STR_TO_DATE(_pfechamod_date,'%Y-%m-%d %H:%i:%s')
  WHERE venta_id = _pventa_id;

END$$;
DELIMITER ;


-- --------------------------------------------------

-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `spDatoLead_registrar`(
   IN _pnombretienda VARCHAR(150)
  ,IN _pnombre VARCHAR(250)
  ,IN _pcelular VARCHAR(25)
  ,IN _ptiponegocio INT
  ,IN _pruc VARCHAR(250)
  ,IN _pdireccion VARCHAR(250)
  ,IN _pdepartamento INT
  ,IN _pcorreo VARCHAR(150)
)
BEGIN

INSERT INTO dato_lead(
  nombretienda
  ,nombre
  ,celular
  ,tiponegocio
  ,ruc
  ,direccion
  ,departamento
  ,correo
  ,activo  
  ,fechareg)
  VALUES(
  _pnombretienda
  ,_pnombre
  ,_pcelular
  ,_ptiponegocio
  ,_pruc
  ,_pdireccion
  ,_pdepartamento
  ,_pcorreo
  ,1
  ,NOW());


  SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- ---------------------------------------------------

-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `spDatoLead_listar`()
BEGIN

SELECT    
  dv.idlead
  ,dv.nombretienda
  ,dv.nombre
  ,dv.celular
  ,dv.tiponegocio
  ,dv.ruc
  ,dv.direccion
  ,dv.departamento
  ,dv.correo
  ,dv.activo
  ,DATE_FORMAT(dv.fechareg, '%d %m %Y') as fechareg
  
FROM dato_lead as dv where dv.activo = 1;

END$$
DELIMITER ;

-- ----------------------------------------------------

-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_venta_reporte` (IN _pvendedorid INT, IN _pventa_type INT) 
BEGIN

SELECT SUM(v.total_dec) as 'total_dec'
,COUNT(venta_id) as 'venta_number'
,ROUND(SUM(v.total_dec) / COUNT(venta_id), 2) as 'costo_promedio_dec'
FROM t_venta v
WHERE v.activo_type = 1
  AND v.vendedor_id = _pvendedorid
    AND ((v.venta_type = _pventa_type) OR (_pventa_type = 0));

END$$
DELIMITER ;

-- ---------------------------------------------------------------------

-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_envio_reporte` (IN _pvendedorid INT, IN _pestado_envio_type INT)
BEGIN

SELECT e.estado_envio_type
FROM t_envio e 
WHERE e.activo_type = 1
  AND e.vendedor_id = _pvendedorid
    AND ((e.estado_envio_type = _pestado_envio_type) OR (_pestado_envio_type = 0));

END$$
DELIMITER ;

-- ----------------------------------------------------------------------
-- FIN VENDEDOR 21

-- Registra los adicionales por cada vendedor
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_adicional_registrar`(
 IN _pvendedor_id INT
 ,IN _padicional_data VARCHAR(50)
 ,IN _padicional_desc VARCHAR(50)
 ,IN _pprecio_dec DECIMAL(10,2)
 ,IN _padicional_type TINYINT(1)
 ,IN _pfechareg_date VARCHAR(50)
)
BEGIN

INSERT INTO t_adicional(
  vendedor_id
  ,adicional_data
  ,adicional_desc
  ,precio_dec
  ,adicional_type
  ,fechareg_date
  ,activo_type
)VALUES(
  _pvendedor_id
 ,_padicional_data
 ,_padicional_desc
 ,_pprecio_dec
 ,_padicional_type
 ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
 ,1);

  SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- lista los adicionales en general por vendedor
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_adicional_listar` (IN _pvendedorid INT)
BEGIN

SELECT 

 a.adicional_id
 ,a.vendedor_id
 ,a.adicional_data
 ,a.adicional_desc
 ,a.precio_dec
 ,a.adicional_type
 ,DATE_FORMAT(a.fechareg_date, '%d %m %Y') as 'fechareg'
 ,a.activo_type

FROM t_adicional a
WHERE a.activo_type = 1
  AND a.vendedor_id = _pvendedorid;

END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- actualiza los adicionales por cada vendedor
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_adicional_actualizar`(
  IN _padicional_id INT
 ,IN _padicional_data VARCHAR(50)
 ,IN _padicional_desc VARCHAR(50)
 ,IN _pprecio_dec DECIMAL(10,2)
 ,IN _padicional_type TINYINT(1)
 ,IN _pfecha_modificacion VARCHAR(50)
)
BEGIN

UPDATE t_adicional 
  SET
  adicional_data = _padicional_data,
  adicional_desc = _padicional_desc,
  precio_dec = _pprecio_dec,
  adicional_type = _padicional_type,
  fechamod_date = STR_TO_DATE(_pfecha_modificacion,'%Y-%m-%d %H:%i:%s'),
  modificado_type = 1
WHERE adicional_id = _padicional_id;


END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- desactiva el adicional, sin embargo se mantiene como inactivo
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_adicional_eliminar`(
 IN _padicional_id INT
)
BEGIN

UPDATE t_adicional 
  SET activo_type = 0
WHERE adicional_id = _padicional_id;

END$$
DELIMITER ;

-- ----------------------------------------------------------------------
-- UPD VENDEDOR 25

-- registra la configuracion obligatoria antes de agregar al carrito, como la gaseosa a elegir, talla a seleccionar, etc
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_configuracion_registrar`(
  IN _pvendedor_id INT
  ,IN _pconfiguracion_data VARCHAR(50)
  ,IN _pconfiguracion_desc VARCHAR(50)
  ,IN _pvalor_data VARCHAR(100) -- el valor, si es XL, color rosado, etc
  ,IN _pconfiguracion_type INT -- si es talla, adicional ropa ,etc 
  ,IN _pfechareg_date VARCHAR(50)
)
BEGIN

INSERT INTO t_configuracion(
  vendedor_id
  ,configuracion_data
  ,configuracion_desc
  ,valor_data
  ,configuracion_type
  ,fechareg_date
  ,activo_type
)VALUES(
  _pvendedor_id
  ,_pconfiguracion_data
  ,_pconfiguracion_desc
  ,_pvalor_data
  ,_pconfiguracion_type
 ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
 ,1);

  SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- lista la configuracion por cada vendedor
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_configuracion_listar` (IN _pvendedorid INT)
BEGIN

SELECT 

 c.configuracion_id
 ,c.vendedor_id
 ,c.configuracion_data
 ,c.configuracion_desc
 ,c.valor_data
 ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 6 AND sm.submaestro_id = c.configuracion_type) as 'configuracion_type'
 ,c.configuracion_type as 'configuracion_tipo'
 ,DATE_FORMAT(c.fechareg_date, '%d %m %Y') as 'fechareg'
 ,c.activo_type

FROM t_configuracion c
WHERE c.activo_type = 1
  AND c.vendedor_id = _pvendedorid;

END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- actualiza la configuracion del vendedor
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_configuracion_actualizar`(
  IN _pconfiguracion_id INT
  ,IN _pconfiguracion_data VARCHAR(50)
  ,IN _pconfiguracion_desc VARCHAR(50)
  ,IN _pvalor_data VARCHAR(100) -- el valor, si es XL, color rosado, etc
  ,IN _pconfiguracion_type INT -- si es talla, adicional ropa ,etc
  ,IN _pfechamod_date VARCHAR(50)
)
BEGIN

UPDATE t_configuracion
  SET
  configuracion_data = _pconfiguracion_data,
  configuracion_desc = _pconfiguracion_desc,
  valor_data = _pvalor_data,
  configuracion_type = _pconfiguracion_type,
  fechamod_date = STR_TO_DATE(_pfechamod_date,'%Y-%m-%d %H:%i:%s'),
  modificado_type = 1
WHERE configuracion_id = _pconfiguracion_id;

END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- desactiva la configuracion, sin embargo se mantiene como inactivo
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_configuracion_eliminar`(
 IN _pconfiguracion_id INT
)
BEGIN

UPDATE t_configuracion 
  SET activo_type = 0
WHERE configuracion_id = _pconfiguracion_id;

END$$
DELIMITER ;

-- ----------------------------------------------------------------------
-- UPD VENDEDOR 29

-- registra y enlaza los adicionales con los productos
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_subproducto_registrar`(
  IN _pproducto_id INT
  ,IN _padicional_id INT
  ,IN _pfechareg_date VARCHAR(50)
)
BEGIN

INSERT INTO t_subProducto(
  producto_id
  ,adicional_id
  ,fechareg_date
  ,activo_type
)VALUES(
  _pproducto_id
  ,_padicional_id
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
  ,1);

  SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- ----------------------------------------------------------------------

-- desactiva el subproducto, no deja seguimiento porque es un dato no importante
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_subproducto_eliminar`(
 IN _psubProducto_id INT
)
BEGIN

DELETE FROM t_subProducto
WHERE subProducto_id = _psubProducto_id;

END$$
DELIMITER ;

-- -----------------------------------------------------------------------
-- UPD VENDEDOR 31


-- registra y enlaza la configuracion con los productos
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_especificacion_registrar`(
  IN _pconfiguracion_id INT
  ,IN _pproducto_id INT
  ,IN _pfechareg_date VARCHAR(50)
)
BEGIN

INSERT INTO t_especificacion(
  configuracion_id
  ,producto_id
  ,fechareg_date
  ,activo_type
)VALUES(
  _pconfiguracion_id
  ,_pproducto_id
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
  ,1);

  SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- -----------------------------------------------------------------------

-- desactiva el subproducto, no deja seguimiento porque es un dato no importante, o tambien registra
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_especificacion_eliminar`(
 IN _pespecificacion_id INT
 ,IN _pconfiguracion_id INT
 ,IN _pproducto_id INT
 ,IN _pfechareg_date VARCHAR(25)
 ,IN _pFilterType INT
)
BEGIN

IF(_pFilterType = 0) THEN
BEGIN

INSERT INTO t_especificacion(
  configuracion_id
  ,producto_id
  ,fechareg_date
  ,activo_type
)VALUES(
  _pconfiguracion_id
  ,_pproducto_id
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
  ,1);

END;
ELSEIF(_pFilterType = 1) THEN
BEGIN

DELETE FROM t_especificacion
WHERE especificacion_id = _pespecificacion_id;

END;
END IF;

END$$
DELIMITER ;

-- -----------------------------------------------------------------------
-- UPD VENDEDOR 33


-- lista la configuracion por cada vendedor
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_subproducto_listar` (IN _pproducto_id INT, IN _padicional_type TINYINT(1))
BEGIN

SELECT
  sp.subProducto_id
  ,sp.producto_id
  ,sp.adicional_id
  ,a.adicional_data
  ,a.adicional_desc
  ,a.precio_dec

FROM t_subProducto sp INNER JOIN t_adicional a ON sp.adicional_id = a.adicional_id
WHERE a.activo_type = 1
  AND sp.producto_id = _pproducto_id
  AND a.adicional_type = _padicional_type;

END$$
DELIMITER ;

-- -----------------------------------------------------------------------

-- lista la configuracion por cada vendedor
-- VENDEDOR
DELIMITER $$
CREATE PROCEDURE `s_especificacion_listar` (IN _pproducto_id INT)
BEGIN

SELECT 

  e.especificacion_id
  ,e.configuracion_id
  ,e.producto_id
  ,c.configuracion_data
  ,c.configuracion_desc
  ,c.valor_data
  ,c.configuracion_type
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 6 AND sm.submaestro_id = c.configuracion_type) as 'configuracionTipo_data'

FROM t_especificacion e INNER JOIN t_configuracion c ON e.configuracion_id = c.configuracion_id
WHERE c.activo_type = 1
  AND e.producto_id = _pproducto_id;

END$$
DELIMITER ;

-- -----------------------------------------------------------------------

-- notifica al vendedor por cada envio nuevo que hay
-- VENDEDOR
/*DROP procedure IF EXISTS `s_envio_vendedor_notificar`;*/
DELIMITER $$
CREATE PROCEDURE `s_envio_vendedor_notificar` (IN _pvendedorid INT)
BEGIN

SELECT
e.envio_id
,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = e.usuario_id) as 'usuario_data'
,e.usuario_id
,e.vendedor_id
,(SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = e.vendedor_id) as 'vendedor_data'
,e.venta_id
,e.entregado_type -- si es 1 es envio finalizado si es 0 es que todavia falta
,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 5 AND sm.submaestro_id = e.estado_envio_type) as 'estado_envio_type' -- estado en formato caracter
,e.estado_envio_type as 'iestado_envio_type' -- Actualiza la informacion con el estado del envio
,e.nombre_data -- nombre de la persona que recepciona
,e.direccion_desc -- calle avenida etc
,e.numero_data -- celular o telefono
,e.piso_desc -- numero / piso
,e.distrito_num -- FALTA el submaestro
,e.estado_provincia_region_num -- FALTA el submaestro
,e.estado_provincia_region_desc  
,e.ciudad_num -- FALTA el submaestro
,e.ciudad_desc
,e.pais_num -- FALTA el submaestro
,e.zip_codigopostal_data
,DATE_FORMAT(e.fecha_entrega_date, '%d-%m-%Y %H:%i:%s') as 'fecha_entrega_date'
,e.hora_entrega
,e.activo_type
,DATE_FORMAT(e.fechareg_date, '%d-%m-%Y %H:%i:%s') as 'fechareg_date'
FROM t_envio e WHERE e.activo_type = 1 
AND e.vendedor_id = _pvendedorid
AND DATE_SUB(NOW(),INTERVAL 8 SECOND) <= e.fecharegNotificacion_date ORDER BY e.fecharegNotificacion_date DESC;

END$$
DELIMITER ;

-- -----------------------------------------------------------------------

-- notifica las ventas realizadas por el usuario, cada cierto tiempo
-- VENDEDOR
/*DROP procedure IF EXISTS `s_venta_vendedor_notificar`;*/
DELIMITER $$
CREATE PROCEDURE `s_venta_vendedor_notificar` (IN _pvendedor_id INT)
BEGIN

SELECT
  (SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = v.vendedor_id) as 'vendedor_data'
  ,v.venta_id
  ,e.envio_id
  ,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = v.usuario_id) as 'usuario_data'
  ,v.monto_dec
  ,v.igv_dec
  ,v.total_dec
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 3 AND sm.submaestro_id = v.venta_type) as 'venta_type'
  ,v.pago_desc -- nombre del que recepciona el pedido
  ,v.comision_dec -- pago del delivery
  ,v.observacion_desc
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 2 AND sm.submaestro_id = v.pago_type) as 'pago_type'
  ,DATE_FORMAT(v.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,v.activo_type
FROM t_venta v INNER JOIN t_envio e ON v.venta_id = e.venta_id WHERE v.activo_type = 1 
AND v.vendedor_id = _pvendedor_id
AND DATE_SUB(NOW(),INTERVAL 8 SECOND) <= v.fecharegNotificacion_date ORDER BY v.fecharegNotificacion_date DESC;

END$$
DELIMITER ;

-- -----------------------------------------------------------------------

--  entra al detalle de cada compra hecha por el usuario
-- CLIENTE
/*DROP procedure IF EXISTS `s_venta_listar_vendedor`;*/
DELIMITER $$
CREATE PROCEDURE `s_venta_vendedor` (IN _pvendedorid INT, IN _pventaid INT)
BEGIN

SELECT
  (SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = v.vendedor_id) as 'vendedor_data'
  ,v.venta_id
  ,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = v.usuario_id) as 'usuario_data'
  ,v.monto_dec
  ,v.igv_dec
  ,v.total_dec
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 3 AND sm.submaestro_id = v.venta_type) as 'venta_type'
  ,v.pago_desc -- nombre del que recepciona el pedido
  ,v.comision_dec -- pago del delivery
  ,v.observacion_desc
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 2 AND sm.submaestro_id = v.pago_type) as 'pago_type'
  ,DATE_FORMAT(v.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,v.activo_type
FROM t_venta v WHERE v.activo_type = 1 
AND v.vendedor_id = _pvendedorid
AND v.venta_id = _pventaid;

END$$
DELIMITER ;

-- -----------------------------------------------------------------------
-- UPD VENDEDOR 38











































































































-- -------------------------------------------------------------------------------------
-- INI CLIENTE
-- -------------------------------------------------------------------------------------

-- Registra el historial de logueo de sesion del usuario
-- CLIENTE
/*DROP procedure IF EXISTS `s_historial_usuario_insertar`;*/
DELIMITER $$
CREATE PROCEDURE `s_historial_usuario_insertar` 
(
  IN _pusuario_id INT  
  ,IN _pdireccionip_data VARCHAR(250)
  ,IN _pdireccionmac_data VARCHAR(250)
  ,IN _pconexion_type TINYINT(1)
)
BEGIN

INSERT INTO t_acceso_historial
(
  usuario_id
  ,direccionip_data
  ,direccionmac_data
  ,conexion_type
  ,fechareg_date
  ,activo_type
)
VALUES
(
  _pusuario_id
  ,_pdireccionip_data
  ,_pdireccionmac_data  
  ,_pconexion_type
  ,NOW()
  ,1
);

END$$
DELIMITER ;

/* ------------------------------------------------------------------ */

-- lista todas las ventas que se realizaron por usuario
-- CLIENTE
/*DROP procedure IF EXISTS `s_venta_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_venta_listar` (IN _pUsuarioId INT)
BEGIN

SELECT
  v.vendedor_id
  ,v.venta_id
  ,v.usuario_id
  ,v.monto_dec
  ,v.igv_dec
  ,v.total_dec
  ,(SELECT sm.nombre_data FROM t_submaestro sm WHERE sm.maestro_id = 3 AND sm.submaestro_id = v.venta_type) as 'venta_type'
  ,v.pago_desc
  ,v.comision_dec
  ,v.observacion_desc
  ,(SELECT sm.nombre_data FROM t_submaestro sm WHERE sm.maestro_id = 2 AND sm.submaestro_id = v.pago_type) as 'pago_type'
  ,DATE_FORMAT(v.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,v.activo_type
FROM t_venta as v WHERE v.activo_type = 1 AND v.usuario_id = _pUsuarioId;

END$$
DELIMITER ;

-- ------------------------------------------------------------------------------------

-- registra la valoracion con el vendedor
-- CLIENTE
 /*DROP procedure IF EXISTS `s_valoracion_vendedor_registrar`;*/
DELIMITER $$
CREATE PROCEDURE `s_valoracion_vendedor_registrar` (
  IN _pVendedorId INT
  ,IN _pUsuarioId INT
  ,IN _pVentaId INT
  ,IN _pPuntajeNum INT
  ,IN _pValoracionDesc VARCHAR(250)
  )
BEGIN

INSERT INTO t_vendedor_valoracion
  (vendedor_id
  ,usuario_id
  ,venta_id
  ,puntaje_num
  ,valoracion_desc
  ,fecha_registro_date
  ,activo_type)
VALUES 
(_pVendedorId
 ,_pUsuarioId
 ,_pVentaId
 ,_pPuntajeNum 
 ,_pValoracionDesc
 ,NOW()
 ,1);

END$$
DELIMITER ;

-- -----------------------------------------------------

-- lista los sub productos por cada vendedor, (al dar click a cada producto en miniatura)
-- CLIENTE
/*DROP procedure IF EXISTS `s_producto_detalle_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_producto_detalle_listar` (IN _pPromocion_type TINYINT(1), IN _pProductoId INT)
BEGIN

SELECT
  p.producto_id
  ,p.vendedor_id
  ,(SELECT c.nombre_data FROM t_categoria c WHERE c.categoria_id = p.categoria_type) as 'categoria_type'
  ,p.producto_data
  ,p.producto_desc
  ,p.promocion_type
  ,p.material_desc
  ,p.marca_desc
  ,p.peso_dec
  ,p.modelo_desc
  ,p.medida_desc
  ,DATE_FORMAT(p.fecha_fin_promocion_date, '%d-%m-%Y') as 'fecha_fin_promocion_date'
  ,p.precio_dec
  ,p.preciopromocion_dec
  ,p.imagen1_data
  ,p.imagen2_data
  ,p.imagen3_data
  ,p.imagen4_data
  ,p.imagen5_data
  ,DATE_FORMAT(p.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,p.activo_type
FROM t_producto as p WHERE p.activo_type = 1 AND p.promocion_type = _pPromocion_type AND p.producto_id = _pProductoId;

END$$
DELIMITER ;

-- ------------------------------------------------------------------------------------

-- lista las promociones activas como no activas (las que ya acabaron y las que no)
-- CLIENTE
/*DROP procedure IF EXISTS `s_producto_buscar`;*/
DELIMITER $$
CREATE PROCEDURE `s_producto_buscar` (IN _pFilterType INT, IN _pProducto_data VARCHAR(150), IN _pcategoria_type TINYINT(1))
BEGIN

-- 0: productos sin promocion
-- 1: productos con promocion
-- 2: todos los productos
IF(_pFilterType = 0) THEN
BEGIN

SELECT
  p.producto_id
  ,p.vendedor_id
  ,(SELECT c.nombre_data FROM t_categoria c WHERE c.categoria_id = p.categoria_type) as 'categoria_type'
  ,p.producto_data
  ,p.producto_desc
  ,p.precio_dec
  ,p.imagen1_data
  ,p.preciopromocion_dec
  ,p.promocion_type
  ,DATE_FORMAT(p.fecha_ini_promocion_date, '%d-%m-%Y') as 'fecha_ini_promocion_date'
  ,DATE_FORMAT(p.fecha_fin_promocion_date, '%d-%m-%Y') as 'fecha_fin_promocion_date'
FROM t_producto as p WHERE p.activo_type = 1
  AND ((p.promocion_type = 0) OR (p.promocion_type = 1 AND DATE(fecha_fin_promocion_date) < CURDATE()))
  AND ((p.producto_data LIKE CONCAT_WS('%',_pProducto_data,'%')) OR (_pProducto_data = ''))
  AND ((p.categoria_type = _pcategoria_type) OR (_pcategoria_type = 0));

END;
ELSEIF(_pFilterType = 1) THEN
BEGIN

SELECT
  p.producto_id
  ,p.vendedor_id
  ,(SELECT c.nombre_data FROM t_categoria c WHERE c.categoria_id = p.categoria_type) as 'categoria_type'
  ,p.producto_data
  ,p.producto_desc
  ,p.precio_dec
  ,p.imagen1_data
  ,p.preciopromocion_dec
  ,p.promocion_type
  ,DATE_FORMAT(p.fecha_ini_promocion_date, '%d-%m-%Y') as 'fecha_ini_promocion_date'
  ,DATE_FORMAT(p.fecha_fin_promocion_date, '%d-%m-%Y') as 'fecha_fin_promocion_date'
FROM t_producto as p WHERE p.activo_type = 1 AND p.promocion_type = 1
  AND ((p.producto_data LIKE CONCAT_WS('%',_pProducto_data,'%')) OR (_pProducto_data = ''))
  AND ((p.categoria_type = _pcategoria_type) OR (_pcategoria_type = 0))
  AND DATE(fecha_fin_promocion_date) >= CURDATE();

END;
ELSEIF(_pFilterType = 2) THEN
BEGIN

SELECT
  p.producto_id
  ,p.vendedor_id
  ,(SELECT c.nombre_data FROM t_categoria c WHERE c.categoria_id = p.categoria_type) as 'categoria_type'
  ,p.producto_data
  ,p.producto_desc
  ,p.precio_dec
  ,p.imagen1_data
  ,p.preciopromocion_dec
  ,p.promocion_type
  ,DATE_FORMAT(p.fecha_ini_promocion_date, '%d-%m-%Y') as 'fecha_ini_promocion_date'
  ,DATE_FORMAT(p.fecha_fin_promocion_date, '%d-%m-%Y') as 'fecha_fin_promocion_date'
FROM t_producto as p WHERE p.activo_type = 1
  AND ((p.producto_data LIKE CONCAT_WS('%',_pProducto_data,'%')) OR (_pProducto_data = ''))
  AND ((p.categoria_type = _pcategoria_type) OR (_pcategoria_type = 0));

END;
END IF;

END$$
DELIMITER ;

-- -------------------------------------------------------------------------

-- registra el envio el usuario al pagar
-- CLIENTE
/*DROP procedure IF EXISTS `s_envio_registrar`;*/
DELIMITER $$
CREATE PROCEDURE s_envio_registrar(
IN _pusuario_id INT
,IN _pventa_id INT
,IN _pvendedor_id INT
,IN _pnombre_data VARCHAR(150)
,IN _pnumero_data VARCHAR(25) 
-- ubicacion 
,IN _pdireccion_desc VARCHAR(250) -- direccion o calle
,IN _ppiso_desc VARCHAR(250) -- numero / piso, etc
,IN _ppais_num INT
,IN _pdistrito_num INT -- distrito
,IN _pestado_provincia_region_num INT
,IN _pestado_provincia_region_desc VARCHAR(250) -- estado provincia region
,IN _pciudad_num INT
,IN _pciudad_desc VARCHAR(150) -- ciudad
,IN _pzip_codigopostal_data VARCHAR(150) -- codigo postal
-- envio
,IN _pentregado_type TINYINT(1)
,IN _pestado_envio_type TINYINT(1)
,IN _pfecha_entrega_date VARCHAR(25)
,IN _phora_entrega VARCHAR(25)
,IN _pfecha_registro VARCHAR(25)
)
BEGIN
  INSERT INTO t_envio(
  usuario_id
  ,venta_id
  ,vendedor_id
  ,nombre_data
  ,numero_data
  -- ubicacion
  ,direccion_desc
  ,piso_desc
  ,pais_num
  ,distrito_num
  ,estado_provincia_region_num
  ,estado_provincia_region_desc
  ,ciudad_num
  ,ciudad_desc
  ,zip_codigopostal_data
  -- envio
  ,entregado_type
  ,estado_envio_type
  ,enviado_type
  ,fecha_entrega_date
  ,hora_entrega
  ,fechareg_date
  ,activo_type
  ,fecharegNotificacion_date
    )
    VALUES(
  _pusuario_id
  ,_pventa_id
  ,_pvendedor_id
  ,_pnombre_data
  ,_pnumero_data
  ,_pdireccion_desc
  ,_ppiso_desc
  ,_ppais_num
  ,_pdistrito_num
  ,_pestado_provincia_region_num
  ,_pestado_provincia_region_desc
  ,_pciudad_num
  ,_pciudad_desc
  ,_pzip_codigopostal_data

  ,_pentregado_type
  ,_pestado_envio_type
  ,0
  ,STR_TO_DATE(_pfecha_entrega_date,'%Y-%m-%d %H:%i:%s')
  ,_phora_entrega
  ,STR_TO_DATE(_pfecha_registro,'%Y-%m-%d %H:%i:%s')
  ,1
  ,NOW());

END$$;
DELIMITER ;

-- ----------------------------------------------------------------------

-- registra las ventas hechas por el usuario
-- CLIENTE
/*DROP procedure IF EXISTS `s_venta_registrar`;*/
DELIMITER $$
CREATE PROCEDURE s_venta_registrar(
IN _pvendedor_id INT
,IN _pusuario_id INT
,IN _pmonto_dec DECIMAL(10,2)
,IN _pigv_dec DECIMAL(10,2)
,IN _ptotal_dec DECIMAL(10,2)
,IN _pventa_type TINYINT(1)
,IN _ppago_type TINYINT(1)
,IN _ppago_desc VARCHAR(250) -- nombre de la persona
,IN _pcomision_dec DECIMAL(10,2) 
,IN _pobservacion_desc VARCHAR(500) 
,IN _pfechareg_date VARCHAR(25)
)
BEGIN
  INSERT INTO t_venta(
  vendedor_id
  ,usuario_id
  ,monto_dec
  ,igv_dec
  ,total_dec
  ,venta_type
  ,pago_type
  ,pago_desc
  ,comision_dec
  ,observacion_desc
  ,fechareg_date
  ,activo_type
  ,fecharegNotificacion_date)
  VALUES(
   _pvendedor_id
   ,_pusuario_id
   ,_pmonto_dec
   ,_pigv_dec
   ,_ptotal_dec
   ,_pventa_type
   ,_ppago_type
   ,_ppago_desc
   ,_pcomision_dec
   ,_pobservacion_desc
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')   
  ,1
  ,NOW());

SELECT LAST_INSERT_ID() as '_result';

END$$;
DELIMITER ;

-- ----------------------------------------------------------------------

-- registra una sub venta una de cada producto que se añadio al carrito (tarjeta o pago)
-- CLIENTE
/*DROP procedure IF EXISTS `s_subventa_registrar`;*/
DELIMITER $$
CREATE PROCEDURE s_subventa_registrar(
IN _pventa_id INT
,IN _pproducto_id INT
,IN _pcantidad_num INT
,IN _psubtotal_dec DECIMAL(10,2)
,IN _pdescripcionAdicional_desc VARCHAR(250)
,IN _pfechareg_date VARCHAR(25)
)
BEGIN
  INSERT INTO t_subventa(
  venta_id
  ,producto_id
  ,cantidad_num
  ,subtotal_dec
  ,descripcionAdicional_desc
  ,fechareg_date
  ,activo_type
  )
  VALUES(
   _pventa_id
   ,_pproducto_id
   ,_pcantidad_num
   ,_psubtotal_dec
   ,_pdescripcionAdicional_desc   
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')   
  ,1);

END$$;
DELIMITER ;

-- ----------------------------------------------------------------------------------------------

-- lista los pedidos pendientes por el usuario, este con cuenta o no
-- CLIENTE
/*DROP procedure IF EXISTS `s_envio_listar_usuario`;*/
DELIMITER $$
CREATE PROCEDURE `s_envio_listar_usuario` (IN _pusuarioid INT, IN _penvioid INT)
BEGIN

IF (_pusuarioid = 0) THEN
BEGIN
  
SELECT
  e.envio_id
  ,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = e.usuario_id) as 'usuario_data'
  ,e.usuario_id
  ,e.vendedor_id
  ,(SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = e.vendedor_id) as 'vendedor_data'
  ,e.venta_id
  ,e.estado_envio_type as 'entregado_type' -- si es 1 es finalizado si es 0 es que todavia falta
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 5 AND sm.submaestro_id = e.estado_envio_type) as 'estado_envio_type' 
  ,e.nombre_data -- nombre de la persona que recepciona
  ,e.direccion_desc -- calle avenida etc
  ,e.numero_data -- celular o telefono
  ,e.piso_desc -- numero / piso
  ,e.distrito_num -- FALTA el submaestro
  ,e.estado_provincia_region_num -- FALTA el submaestro
  ,e.estado_provincia_region_desc
  ,e.ciudad_num -- FALTA el submaestro
  ,e.ciudad_desc
  ,e.pais_num -- FALTA el submaestro
  ,e.zip_codigopostal_data
  ,DATE_FORMAT(e.fecha_entrega_date, '%d-%m-%Y %H:%i:%s') as 'fecha_entrega_date'
  ,e.hora_entrega
  ,e.activo_type
  ,DATE_FORMAT(e.fechareg_date, '%d-%m-%Y %H:%i:%s') as 'fechareg_date'
FROM t_envio e WHERE e.activo_type = 1
AND e.envio_id = _penvioid;
  
END;
ELSE
BEGIN
  
SELECT
  e.envio_id
  ,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = e.usuario_id) as 'usuario_data'
  ,e.usuario_id
  ,e.vendedor_id
  ,(SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = e.vendedor_id) as 'vendedor_data'
  ,e.venta_id
  ,e.estado_envio_type as 'entregado_type' -- si es 1 es finalizado si es 0 es que todavia falta
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 5 AND sm.submaestro_id = e.estado_envio_type) as 'estado_envio_type' 
  ,e.nombre_data -- nombre de la persona que recepciona
  ,e.direccion_desc -- calle avenida etc
  ,e.numero_data -- celular o telefono
  ,e.piso_desc -- numero / piso
  ,e.distrito_num -- FALTA el submaestro
  ,e.estado_provincia_region_num -- FALTA el submaestro
  ,e.estado_provincia_region_desc  
  ,e.ciudad_num -- FALTA el submaestro
  ,e.ciudad_desc
  ,e.pais_num -- FALTA el submaestro
  ,e.zip_codigopostal_data
  ,DATE_FORMAT(e.fecha_entrega_date, '%d-%m-%Y %H:%i:%s') as 'fecha_entrega_date'
  ,e.hora_entrega
  ,e.activo_type
  ,DATE_FORMAT(e.fechareg_date, '%d-%m-%Y %H:%i:%s') as 'fechareg_date'
FROM t_envio e WHERE e.activo_type = 1 
AND e.usuario_id = _pusuarioid
AND((e.envio_id = _penvioid) OR (_penvioid = 0));
  
END;
END IF;


END$$
DELIMITER ;

-- -------------------------------------------------------------------------

--  entra al detalle de cada compra hecha por el usuario
-- CLIENTE
/*DROP procedure IF EXISTS `s_venta_listar_usuario`;*/
DELIMITER $$
CREATE PROCEDURE `s_venta_listar_usuario` (IN _pusuarioid INT, IN _pventaid INT)
BEGIN

SELECT
  (SELECT v2.nombre_data FROM t_vendedor v2 WHERE v2.vendedor_id = v.vendedor_id) as 'vendedor_data'
  ,v.venta_id
  ,(SELECT u.nombre_data FROM t_usuario u WHERE u.usuario_id = v.usuario_id) as 'usuario_data'
  ,v.monto_dec
  ,v.igv_dec
  ,v.total_dec
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 3 AND sm.submaestro_id = v.venta_type) as 'venta_type'
  ,v.pago_desc -- nombre del que recepciona el pedido
  ,v.comision_dec -- pago del delivery
  ,v.observacion_desc
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 2 AND sm.submaestro_id = v.pago_type) as 'pago_type'
  ,DATE_FORMAT(v.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,v.activo_type
FROM t_venta v WHERE v.activo_type = 1 
AND v.usuario_id = _pusuarioid
AND ((v.venta_id = _pventaid) OR (_pventaid = 0));

END$$
DELIMITER ;

-- -------------------------------------------------------------------------
-- FIN CLIENTE 10

-- adjunta los productos adicionales hacia la venta
-- CLIENTE
/*DROP procedure IF EXISTS `s_ventaAdicional_registrar`;*/
DELIMITER $$
CREATE PROCEDURE s_ventaAdicional_registrar(
  IN _pventa_id INT
  ,IN _psubProducto_id INT
  ,IN _padicional_id INT
  ,IN _padicional_data VARCHAR(50)
  ,IN _pprecio_dec DECIMAL(10,2)
  ,IN _padicional_type TINYINT(1)
  ,IN _pfechareg_date VARCHAR(50)
)
BEGIN
  INSERT INTO t_VentaAdicional(
  venta_id
  ,adicional_id
  ,subProducto_id
  ,adicional_data
  ,precio_dec
  ,adicional_type
  ,fechareg_date
  ,activo_type
  )VALUES(
   _pventa_id
  ,_padicional_id
  ,_psubProducto_id
  ,_padicional_data
  ,_pprecio_dec
  ,_padicional_type
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
  ,1);

END$$;
DELIMITER ;

-- -------------------------------------------------------------------------

-- adjunta las especificaciones
-- CLIENTE
/*DROP procedure IF EXISTS `s_configuracionVenta_registrar`;*/
DELIMITER $$
CREATE PROCEDURE s_configuracionVenta_registrar(
  IN _pventa_id INT
  ,IN _pespecificacion_id INT
  ,IN _configuracion_id INT
  ,IN _pvalor_data VARCHAR(100)
  ,IN _pconfiguracion_type INT
  ,IN _pfechareg_date VARCHAR(50)
)
BEGIN

  INSERT INTO t_configuracion_venta(
  venta_id
  ,especificacion_id
  ,configuracion_id
  ,valor_data
  ,configuracion_type
  ,fechareg_date
  ,activo_type
  )VALUES(
   _pventa_id
  ,_pespecificacion_id
  ,_configuracion_id
  ,_pvalor_data
  ,_pconfiguracion_type
  ,STR_TO_DATE(_pfechareg_date,'%Y-%m-%d %H:%i:%s')
  ,1);

END$$;
DELIMITER ;


-- -------------------------------------------------------------------------
-- CLIENTE UPD 12


-- lista el adicional de la venta, por ejemplo si el plato se le agrega un producto mas como gaseosa, un plato adicional
-- (el producto id viene de listar sub venta)
-- CLIENTE
/*DROP procedure IF EXISTS `s_ventaAdicional_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_ventaAdicional_listar` (IN _pventaid INT, IN _pproducto_id INT, IN _padicional_type TINYINT(1))
BEGIN

SELECT
  va.ventaAdicional_id
  ,va.venta_id
  ,va.adicional_id
  ,va.subProducto_id
  ,va.adicional_data
  ,va.precio_dec
  ,va.adicional_type
  ,DATE_FORMAT(va.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,va.activo_type
FROM t_VentaAdicional va INNER JOIN t_subProducto sp ON sp.subProducto_id = va.subProducto_id
WHERE va.activo_type = 1
  AND va.venta_id = _pventaid
  AND sp.producto_id = _pproducto_id
  AND sp.adicional_type = _padicional_type; -- SI ES GRATUITO O NO

END$$
DELIMITER ;

-- -------------------------------------------------------------------------

-- lista la especificacion de cada venta, de cada producto, si por ejemplo el plato tiene un adicional como crema
-- (el producto id viene de listar sub venta)
-- CLIENTE
/*DROP procedure IF EXISTS `s_configuracionVenta_listar`;*/
DELIMITER $$
CREATE PROCEDURE `s_configuracionVenta_listar` (IN _pventaid INT, IN _pproducto_id INT, IN _pconfiguracion_type INT)
BEGIN

SELECT
  cv.configuracionVenta_id
  ,cv.especificacion_id
  ,cv.venta_id
  ,cv.configuracion_id
  ,cv.valor_data
  ,cv.configuracion_type
  ,(SELECT sm.submaestro_data FROM t_submaestro sm WHERE sm.maestro_id = 6 AND sm.submaestro_id = cv.configuracion_type) as 'sconfiguracion_data'
  ,DATE_FORMAT(cv.fechareg_date, '%d-%m-%Y') as 'fechareg_date'
  ,cv.activo_type
FROM t_configuracion_venta cv INNER JOIN t_especificacion e ON e.especificacion_id = cv.especificacion_id
WHERE cv.activo_type = 1
  AND cv.venta_id = _pventaid
  AND e.producto_id = _pproducto_id
  AND cv.configuracion_type = _pconfiguracion_type;

END$$
DELIMITER ;

-- -------------------------------------------------------------------------
-- UPD CLIENTE 14