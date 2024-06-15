use Obligatorio_P3;
SET DATEFORMAT DMY;

select * from Usuarios
select * from Parametros
select * from Articulos
select * from Lineas
select * from Pedidos

insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('admin@admin.com', 'Sys', 'Admin','Passw0rd!','Administrador');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('rplanta@lz.com', 'Roberto', 'Planta','Passw0rd!','Estandar');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('jblanco@tws.com', 'Jacobo', 'Blanco','Passw0rd!','Encargado');

insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Calculadora Casio', 'Calculadora de bolsillo Casio', '1234567890123', 300, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Resma A4', '500 hojas para imprimir en formato A4', '1234567890124', 250, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Auriculares con Micrófono', 'Bluetooth o conexión USB, cable desmontable', '1234567890125', 3200, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Silla De Escritorio', 'Soporte lumbar, altura ajustable y base giratoria n ruedas', '1234567890126', 3200, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Notas Adhesivas', 'Block de notas autoadhesivas', '1234597890124', 50, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bandas Elásticas', '100 unidades', '1274597890124', 150, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Engrampadora', 'Hasta 100 hojas', '1834597890124', 800, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cable HDMI', 'HD, FullHD y 4K,', '1236597890124', 200, 10);

insert into Parametros(Nombre, Valor) values ('TopeDeMovimientos',20);
insert into Parametros(Nombre, Valor) values ('LimitePorPagina',5);

insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Venta','Reduccion');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Compra','Aumento');
insert into TiposDeMovimientos(Nombre, TipoAccion) values ('Devolucion','Aumento');

insert into MovimientosDeStock(Fecha, ArticuloId, UsuarioId, TipoMovimientoId, Cantidad) values ('01-08-2023',1,3,1,5);

select * from  __EFMigrationsHistory
DELETE FROM __EFMigrationsHistory WHERE MigrationId='20240516201117_init'

