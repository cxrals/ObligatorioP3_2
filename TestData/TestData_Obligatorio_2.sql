use Obligatorio_P3Obligatorio_P3;
SET DATEFORMAT DMY;

select * from Usuarios
select * from Parametros
select * from Articulos
select * from TiposDeMovimientos
select * from MovimientosDeStock

insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('admin@admin.com', 'Sys', 'Admin','Passw0rd!','Administrador');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('std@std.com', 'Estandar', 'User','Passw0rd!','Estandar');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('enc@enc.com', 'Encargado', 'User','Passw0rd!','Encargado');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('rp@obligatorio.com', 'Roberto', 'Planta','Passw0rd!','Encargado');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('jb@obligatorio.com', 'Jacobo', 'Blanco','Passw0rd!','Encargado');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('fo@obligatorio.com', 'Franco', 'Océano','Passw0rd!','Encargado');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('fm@obligatorio.com', 'Fiona ', 'Manzana','Passw0rd!','Encargado');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('ra@obligatorio.com', 'Rogelio ', 'Aguas','Passw0rd!','Encargado');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('ja@obligatorio.com', 'Joana ', 'Avión','Passw0rd!','Encargado');

insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Calculadora Casio', 'Calculadora de bolsillo Casio', '1234567890123', 300, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Resma A4', '500 hojas para imprimir en formato A4', '1234567890124', 250, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Auriculares con Micrófono', 'Bluetooth o conexión USB, cable desmontable', '1234567890125', 3200, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Silla De Escritorio', 'Soporte lumbar, altura ajustable y base giratoria n ruedas', '1234567890126', 3200, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Notas Adhesivas', 'Block de notas autoadhesivas', '1234597890124', 50, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bandas Elásticas', '100 unidades', '1274597890124', 150, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Engrampadora', 'Hasta 100 hojas', '1834597890124', 800, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cable HDMI', 'HD, FullHD y 4K,', '1236597890124', 200, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Lápices HB', 'Caja de 12 lápices', '1234567890127', 100, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cuaderno A5', 'Cuaderno de 100 hojas', '1234567890128', 150, 30);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bolígrafos Azules', 'Paquete de 10 bolígrafos', '1234567890129', 50, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Tijeras', 'Tijeras de acero inoxidable', '1234567890130', 80, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Pegamento en Barra', 'Pegamento de 20g', '1234567890131', 40, 60);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Carpeta A4', 'Carpeta con anillos', '1234567890132', 90, 30);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Rotuladores', 'Set de 6 colores', '1234567890133', 120, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Libreta de Notas', 'Libreta de 50 hojas', '1234567890134', 70, 80);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Gomas de Borrar', 'Paquete de 4 gomas', '1234567890135', 30, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Sacapuntas', 'Sacapuntas de metal', '1234567890136', 25, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Corrector Líquido', 'Corrector blanco de 20ml', '1234567890137', 45, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Marcadores Permanentes', 'Set de 4 colores', '1234567890138', 100, 60);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Papel Fotocopia', 'Paquete de 500 hojas', '1234567890139', 250, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Carpetas Colgantes', 'Paquete de 10 carpetas', '1234567890140', 150, 30);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Calculadora Científica', 'Calculadora con funciones científicas', '1234567890141', 400, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Tacos de Notas', 'Paquete de 12 tacos', '1234567890142', 100, 60);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cinta Adhesiva', 'Cinta transparente 50m', '1234567890143', 70, 80);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Clips', 'Caja de 100 clips', '1234567890144', 20, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Grapas', 'Caja de 1000 grapas', '1234567890145', 15, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Archivador', 'Archivador tamaño A4', '1234567890146', 200, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Portaminas', 'Portaminas con 10 minas', '1234567890147', 80, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cuaderno Espiral', 'Cuaderno de 80 hojas', '1234567890148', 90, 60);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bloc de Dibujo', 'Bloc de 30 hojas A3', '1234567890149', 150, 30);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Lápices de Colores', 'Set de 24 colores', '1234567890150', 200, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Estuche', 'Estuche para lápices', '1234567890151', 100, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Calculadora Gráfica', 'Calculadora para gráficos', '1234567890152', 500, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Perforadora', 'Perforadora de 2 agujeros', '1234567890153', 120, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cinta Correctora', 'Cinta correctora de 10m', '1234567890154', 50, 80);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Tijeras para Niños', 'Tijeras con punta redonda', '1234567890155', 30, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Notas de Colores', 'Paquete de 6 bloques', '1234567890156', 90, 60);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Agenda', 'Agenda 2024', '1234567890157', 250, 30);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cuaderno de Música', 'Cuaderno de 50 hojas pautadas', '1234567890158', 80, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Compás', 'Compás metálico', '1234567890159', 70, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Transportador', 'Transportador de plástico', '1234567890160', 20, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Set de Regla', 'Set de 3 reglas', '1234567890161', 40, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Pinzas para Papel', 'Paquete de 20 pinzas', '1234567890162', 50, 80);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Post-it de Colores', 'Set de 5 colores', '1234567890163', 100, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bolígrafos Negros', 'Paquete de 10 bolígrafos', '1234567890164', 50, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Notas Adhesivas Pequeñas', 'Notas de 5x5cm', '1234567890165', 30, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Clip de Papel Grande', 'Caja de 50 clips', '1234567890166', 40, 80);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Grapadora Grande', 'Grapadora para 150 hojas', '1234567890167', 200, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Lápices Mecánicos', 'Set de 2 lápices', '1234567890168', 100, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cuaderno de Dibujo', 'Cuaderno de 40 hojas A4', '1234567890169', 120, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Goma de Borrar', 'Goma de borrar grande', '1234567890170', 30, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Rotuladores Finos', 'Set de 12 colores', '1234567890171', 150, 30);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Carpetas Transparentes', 'Paquete de 10 carpetas', '1234567890172', 80, 60);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Regla de Metal', 'Regla de 30cm', '1234567890173', 40, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bolígrafos Rojos', 'Paquete de 10 bolígrafos', '1234567890174', 50, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Subrayadores', 'Set de 6 colores', '1234567890175', 120, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cuaderno con Cubierta Dura', 'Cuaderno de 100 hojas', '1234567890176', 150, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Grapas Grandes', 'Caja de 500 grapas', '1234567890177', 25, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Separadores de Carpetas', 'Set de 5 separadores', '1234567890178', 60, 80);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cinta Adhesiva de Papel', 'Cinta de 20m', '1234567890179', 50, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Tijeras de Cocina', 'Tijeras multiusos', '1234567890180', 100, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Archivador con Llave', 'Archivador de metal', '1234567890181', 300, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Pizarra Blanca', 'Pizarra de 90x60cm', '1234567890182', 250, 15);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Rotuladores para Pizarra', 'Set de 4 colores', '1234567890183', 100, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Calculadora de Escritorio', 'Calculadora con pantalla grande', '1234567890184', 150, 30);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bloc de Notas Adhesivas', 'Bloc de 100 hojas', '1234567890185', 50, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Archivador de Palanca', 'Archivador con mecanismo de palanca', '1234567890186', 200, 40);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Notas Adhesivas Grandes', 'Notas de 10x10cm', '1234567890187', 60, 80);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Sobres A4', 'Paquete de 25 sobres', '1234567890188', 50, 70);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Clip para Papel', 'Caja de 100 clips', '1234567890189', 20, 90);

insert into Parametros(Nombre, Valor) values ('TopeDeMovimientos',20);
insert into Parametros(Nombre, Valor) values ('LimitePorPagina',5);

insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Venta','Reduccion');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Compra','Aumento');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Devolucion','Aumento');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Tipo De Movimiento 1','Reduccion');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Tipo De Movimiento 2','Aumento');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Tipo De Movimiento 3','Reduccion');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Tipo De Movimiento 4','Aumento');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Tipo De Movimiento 5','Reduccion');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Tipo De Movimiento 6','Aumento');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Tipo De Movimiento 7','Reduccion');

insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-05-2024', 1, 3, 1, 5);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('18-05-2024', 2, 4, 1, 2);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('01-06-2024', 3, 5, 2, 10);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('02-06-2024', 4, 6, 3, 15);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('03-06-2024', 5, 7, 4, 8);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('04-06-2024', 6, 8, 5, 20);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('05-06-2024', 7, 3, 6, 12);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('06-06-2024', 8, 4, 7, 6);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('07-06-2024', 9, 5, 8, 18);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('08-06-2024', 10, 6, 9, 14);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('09-06-2024', 11, 7, 10, 11);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('10-06-2024', 12, 8, 1, 3);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('11-06-2024', 13, 3, 2, 7);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('12-06-2024', 14, 4, 3, 9);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('13-06-2024', 15, 5, 4, 13);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('14-06-2024', 1, 6, 5, 4);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('15-06-2024', 2, 7, 6, 16);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-06-2024', 3, 8, 7, 19);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('17-06-2024', 4, 3, 8, 5);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('18-06-2024', 5, 4, 9, 17);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('19-06-2024', 6, 5, 10, 12);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('20-06-2024', 7, 6, 1, 10);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('21-06-2024', 8, 7, 2, 14);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('22-06-2024', 9, 8, 3, 11);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('23-06-2024', 10, 3, 4, 6);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('24-06-2024', 11, 4, 5, 8);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('25-06-2024', 12, 5, 6, 13);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('26-06-2024', 13, 6, 7, 7);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('27-06-2024', 14, 7, 8, 9);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('27-06-2024', 15, 8, 9, 5);


select * from  __EFMigrationsHistory
DELETE FROM __EFMigrationsHistory WHERE MigrationId='20240516201117_init'

-- test paginacion
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-05-2024', 1, 3, 1, 5);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-05-2024', 1, 3, 1, 10);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-05-2024', 1, 3, 1, 25);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('17-05-2024', 1, 3, 1, 5);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-05-2024', 1, 3, 1, 2);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-05-2024', 1, 3, 1, 15);
insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('16-05-2024', 1, 3, 1, 30);

-- test resumen
SELECT 
    YEAR(Fecha) AS Anio,
    TipoMovimientoId,
    SUM(Cantidad) AS CantidadTotalPorTipo,
    (SELECT SUM(Cantidad) 
     FROM MovimientosDeStock 
     WHERE YEAR(Fecha) = YEAR(MS.Fecha)) AS CantidadTotalPorAnio
FROM MovimientosDeStock MS
GROUP BY YEAR(Fecha), TipoMovimientoId
ORDER BY Anio, TipoMovimientoId;