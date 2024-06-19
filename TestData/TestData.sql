use ObligatorioProg3;
select * from Usuarios
select * from Clientes
select * from Articulos
select * from Lineas
select * from Pedidos

insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('admin@admin.com', 'Sys', 'Admin','Passw0rd!','Administrador');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('rplanta@lz.com', 'Roberto', 'Planta','Passw0rd!','Estandar');

insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('Fleetium Macs', '123456789012','Ciudadela','1180', 'Montevideo', 98);
insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('Pink Folks', '987654321098', 'Reconquista', '600', 'Montevideo', 101);
insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('Thurston & Kim Co.', '111222333444', 'Durazno', '902', 'Montevideo', 96);
insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('Nueva Helvecia Dolls', '111222333555', 'San Jose', '1060', 'Montevideo', 94);
insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('Fenix', '1112223336666', 'Maldonado', '2010', 'Montevideo', 82);
insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('AB/CD', '1112223337777', 'Canelones', '1110', 'Montevideo', 91);

insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Calculadora Casio', 'Calculadora de bolsillo Casio', '1234567890123', 300, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Resma A4', '500 hojas para imprimir en formato A4', '1234567890124', 250, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Auriculares con Micrófono', 'Bluetooth o conexión USB, cable desmontable', '1234567890125', 3200, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Silla De Escritorio', 'Soporte lumbar, altura ajustable y base giratoria n ruedas', '1234567890126', 3200, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Notas Adhesivas', 'Block de notas autoadhesivas', '1234597890124', 50, 100);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Bandas Elásticas', '100 unidades', '1274597890124', 150, 90);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Engrampadora', 'Hasta 100 hojas', '1834597890124', 800, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Cable HDMI', 'HD, FullHD y 4K,', '1236597890124', 200, 10);

insert into Parametros(Nombre, Valor) values ('IVA',0.18);
insert into Parametros(Nombre, Valor) values ('RecargoComun_DistanciaMayor100',0.05);
insert into Parametros(Nombre, Valor) values ('RecargoComun_DistanciaMenor100',0);
insert into Parametros(Nombre, Valor) values ('RecargoExpress_Plazo1Dia',0.15);
insert into Parametros(Nombre, Valor) values ('RecargoExpress_PlazoMayor1Dia',0.10);


select * from  __EFMigrationsHistory
DELETE FROM __EFMigrationsHistory WHERE MigrationId='20240516201117_init'

