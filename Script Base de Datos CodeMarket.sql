CREATE DATABASE CodeMarket

Go

USE CodeMarket

GO

CREATE TABLE Rol(
IdRol INT PRIMARY KEY IDENTITY,
Descripcion VARCHAR(50),
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE Permiso(
IdPermiso INT PRIMARY KEY IDENTITY,
IdRol INT REFERENCES Rol(IdRol),
NombreMenu VARCHAR(100),
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE Proveedor(
IdProveedor INT PRIMARY KEY IDENTITY,
Documento VARCHAR(30),
RazonSocial VARCHAR(50),
Correo VARCHAR(50),
Telefono VARCHAR(20),
Estado BIT,
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE Cliente(
IdCliente INT PRIMARY KEY IDENTITY,
Documento VARCHAR(30),
NombreCompleto VARCHAR(50),
Correo VARCHAR(50),
Telefono VARCHAR(20),
Estado BIT,
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE Usuario(
IdUsuario INT PRIMARY KEY IDENTITY,
Documento VARCHAR(30),
NombreCompleto VARCHAR(50),
Correo VARCHAR(50),
Clave VARCHAR(30),
IdRol INT REFERENCES Rol(IdRol),
Telefono VARCHAR(20),
Estado BIT,
FechaRegistro DATETIME DEFAULT getdate()
)

GO


Create TABLE Categoria(
IdCategoria INT PRIMARY KEY IDENTITY,
Descripcion VARCHAR(100),
Estado BIT,
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE Producto(
IdProducto INT PRIMARY KEY IDENTITY,
Codigo VARCHAR(30),
Nombre VARCHAR(40),
Descripcion VARCHAR(50),
IdCategoria INT REFERENCES Categoria(IdCategoria),
Stock INT NOT NULL DEFAULT 0,
PrecioCompra DECIMAL(10,2) DEFAULT 0,
PrecioVenta DECIMAL(10,2) DEFAULT 0,
Estado BIT,
FechaRegistro DATETIME DEFAULT getdate()
)

GO
/*
 * Apartir de este punto no esta contemplado terminar el proyecto, debido al alcance definido y ya que este es solo un prototipo
 */

CREATE TABLE Compra(
IdCompra INT PRIMARY KEY IDENTITY,
IdUsuario INT REFERENCES Usuario(IdUsuario),
IdProveedor INT REFERENCES Proveedor(IdProveedor),
TipoDocumento VARCHAR(30),
NumeroDocumento VARCHAR(50),
MontoTotal DECIMAL(10,2),
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE DetalleCompra(
IdDetalleCompra INT PRIMARY KEY IDENTITY,
IdCompra INT REFERENCES Compra(IdCompra),
IdProducto INT REFERENCES Producto(IdProducto),
PrecioCompra DECIMAL(10,2) DEFAULT 0,
PrecioVenta DECIMAL(10,2) DEFAULT 0,
Cantidad INT,
MontoTotal DECIMAL(10,2),
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE Venta(
IdVenta INT PRIMARY KEY IDENTITY,
IdUsuario INT REFERENCES Usuario(IdUsuario),
TipoDocumento VARCHAR(30),
NumeroDocumento VARCHAR(50),
DocumentoCliente VARCHAR(30),
NombreCliente VARCHAR(50),
MontoPago DECIMAL(10,2),
MontoCambio DECIMAL(10,2),
MontoTotal DECIMAL(10,2),
FechaRegistro DATETIME DEFAULT getdate()
)

GO

CREATE TABLE DetalleVenta(
IdDetalleVenta INT PRIMARY KEY IDENTITY,
IdVenta INT REFERENCES Venta(IdVenta),
IdProducto INT REFERENCES Producto(IdProducto),
PrecioVenta DECIMAL(10,2),
Cantidad INT,
SubTotal DECIMAL(10,2),
FechaRegistro DATETIME DEFAULT getdate()
)

/*
 * Inserts
 */

 /*
 * Insert para la tabla Rol
 */
INSERT INTO [dbo].[Rol]
           ([Descripcion])
     VALUES
           ('Administrador')
GO


INSERT INTO [dbo].[Rol]
           ([Descripcion])
     VALUES
           ('Empleado')
GO

/*
 * Insert para la tabla Permiso
 */

INSERT INTO [dbo].[Permiso]
           ([IdRol]
           ,[NombreMenu])        
     VALUES
           (1
           ,'menuusuario'),
		   (1
           ,'menumantenedor'),
		   (1
           ,'menuventas'),
		   (1
           ,'menucompras'),
		   (1
           ,'menuclientes'),
		   (1
           ,'menuproveedores'),
		   (1
           ,'menureportes'),
		   (1
           ,'menuacercade')
GO

INSERT INTO [dbo].[Permiso]
           ([IdRol]
           ,[NombreMenu])        
     VALUES        
		   (2
           ,'menuventas'),
		   (2
           ,'menucompras'),
		   (2
           ,'menuclientes'),
		   (2
           ,'menuproveedores'),
		   (2
           ,'menuacercade')
GO
/*
 * Insert para la tabla Usuarios con permiso de ADMINISTRADOR
 */
 INSERT INTO [dbo].[Usuario]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Clave]
           ,[IdRol]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1726647066'
           ,'Christopher Pallo'
           ,'cipallo'
           ,'1234'
           ,1
           ,'0995312828'
           ,1)
GO

INSERT INTO [dbo].[Usuario]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Clave]
           ,[IdRol]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1725054512'
           ,'Edgar Garzón'
           ,'epgarzonr'
           ,'1234'
           ,1
           ,'0995488400'
           ,1)
GO

INSERT INTO [dbo].[Usuario]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Clave]
           ,[IdRol]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1723055289'
           ,'Andrea Vargas'
           ,'alvargas'
           ,'1234'
           ,1
           ,'0989925869'
           ,1)
GO

INSERT INTO [dbo].[Usuario]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Clave]
           ,[IdRol]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1727364604'
           ,'Sebastián Tituaña'
           ,'satituana'
           ,'1234'
           ,1
           ,'0983154886'
           ,1)
GO

INSERT INTO [dbo].[Usuario]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Clave]
           ,[IdRol]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1004542329'
           ,'Stalin Yamá'
           ,'bsyama'
           ,'1234'
           ,1
           ,'0986051981'
           ,1)
GO



/*
 * Insert para la tabla Usuarios con permiso de Empleado
 */

 INSERT INTO [dbo].[Usuario]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Clave]
           ,[IdRol]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1726687986'
           ,'Paulo LLaguno'
           ,'pfllaguno'
           ,'4321'
           ,2
           ,'0995648575'
           ,1)
GO

/*
 * Insert para la tabla Categorias
 */

INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Lacteos'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Bebidas'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Snacks'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Licores'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Cereales'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Harinas'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Pastas'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Limpieza'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Dulces'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Granos Secos'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Panadería'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Carnes'
           ,1
            )
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Aceites y Grasas'
           ,1
GO

/*
 * Insert para la tabla Productos
 */
 INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LT001'
           ,'Leche entera VITA'
           ,'1 Litro'
           ,1
           ,1)
GO

 INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LT002'
           ,'Leche entera Parmalat'
           ,'1 Litro'
           ,1
           ,1)
GO

INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('BEB001'
           ,'Coca Cola'
           ,'1 Litro'
           ,2
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('BEB002'
           ,'Agua Mineral'
           ,'1 Litro'
           ,2
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('BEB003'
           ,'Cifrut'
           ,'1 Litro'
           ,2
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('BEB004'
           ,'Gatorade'
           ,'1 Litro'
           ,2
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('BEB005'
           ,'Fuze tea'
           ,'1 Litro'
           ,2
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('SNA001'
           ,'Papas Ruflles'
           ,'84 Gramos'
           ,3
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('SNA002'
           ,'Doritos'
           ,'58 Gramos'
           ,3
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('SNA003'
           ,'Platanitos'
           ,'52 Gramos'
           ,3
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('SNA004'
           ,'Tostitos'
           ,'45 Gramos'
           ,3
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('SNA005'
           ,'Chetos'
           ,'29 Gramos'
           ,3
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIC001'
           ,'Cerveza'
           ,'2 Litros'
           ,4
           ,1)
GO
INSERT INTO [dbo].[Categoria]
           ([Descripcion]
           ,[Estado])
     VALUES
           ('Licores'
           ,1
            )
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIC002'
           ,'Switch'
           ,'1.4 Litros'
           ,4
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIC003'
           ,'Norteño'
           ,'740 ml'
           ,4
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIC004'
           ,'Vodka'
           ,'700 ml'
           ,4
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIC005'
           ,'Whisky'
           ,'750 ml'
           ,4
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CER001'
           ,'Granola'
           ,'250 gramos'
           ,5
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CER002'
           ,'Avena Quaker'
           ,'1000 gramos'
           ,5
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CER003'
           ,'Arroz'
           ,'25 libras'
           ,5
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CER004'
           ,'Quinua'
           ,'500 gramos'
           ,5
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CER005'
           ,'Cereal de maiz'
           ,'300 gramos'
           ,5
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('HAR001'
           ,'Harina de trigo'
           ,'500 gramos'
           ,6
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('HAR002'
           ,'Harina de maiz'
           ,'1000 kilogramos'
           ,6
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('HAR003'
           ,'Harina de avena'
           ,'1000 kilogramos'
           ,6
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('HAR004'
           ,'Harina de centeno'
           ,'1000 kilogramos'
           ,6
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('HAR005'
           ,'Harina de cebada'
           ,'1000 kilogramos'
           ,6
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAS001'
           ,'Espaguetis'
           ,'500 gramos'
           ,7
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAS002'
           ,'Fideos'
           ,'400 gramos'
           ,7
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAS003'
           ,'Rapidito'
           ,'100 gramos'
           ,7
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAS004'
           ,'Macarrones'
           ,'400 gramos'
           ,7
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAS005'
           ,'Tallarines'
           ,'300 gramos'
           ,7
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIM001'
           ,'Desinfectante Fabuloso'
           ,'1 Litro'
           ,8
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIM002'
           ,'Deja'
           ,'1200 Kilogramos'
           ,8
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIM003'
           ,'Cloro'
           ,'1 litro'
           ,8
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIM004'
           ,'Colgate'
           ,'125 mililitros'
           ,8
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('LIM005'
           ,'Jabón de baño'
           ,'110 gramos'
           ,8
           ,1)
GO
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('DUL001'
           ,'Chocolate JET'
           ,'30 gramos'
           ,9
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('DUL002'
           ,'Gomitas Trululu'
           ,'90 gramos'
           ,9
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('DUL003'
           ,'Chupetes Plop'
           ,'240 gramos'
           ,9
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('DUL004'
           ,'Galleta Nucita'
           ,'81 gramos'
           ,9
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('DUL005'
           ,'Golletas Amor'
           ,'100 gramos'
           ,9
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('GRA001'
           ,'Lentejas'
           ,'750 gramos'
           ,10
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('GRA002'
           ,'Fréjol'
           ,'700 gramos'
           ,10
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('GRA003'
           ,'Garbanzo'
           ,'650 gramos'
           ,10
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('GRA004'
           ,'Habas'
           ,'500 gramos'
           ,10
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('GRA005'
           ,'Arveja'
           ,'750 gramos'
           ,10
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAN001'
           ,'Pan blanco'
           ,'Pan fresco de trigo'
           ,11
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAN002'
           ,'Pan integral'
           ,'Pan de trigo integral fresco'
           ,11
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAN003'
           ,'Pound Cake'
           ,'Molde fresco sin decorar de vainilla'
           ,11
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAN004'
           ,'Moncaibas'
           ,'Moncaibas frescas de chocolate'
           ,11
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('PAN005'
           ,'Melvas'
           ,'Galletas melvas de chocolate'
           ,11
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CAR001'
           ,'Filete de res'
           ,'Corte de filetes de carne de res'
           ,12
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CAR002'
           ,'Pollo entero'
           ,'Pollo fresco entero'
           ,12
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CAR003'
           ,'Chuletas de cerdo'
           ,'Chuletas de cerdo marinadas'
           ,12
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CAR004'
           ,'Carne molida'
           ,'Carne de res molida'
           ,12
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('CAR005'
           ,'Pechuga de pollo'
           ,'Pechuga de pollo sin hueso'
           ,12
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('ACE001'
           ,'Aceite de oliva'
           ,'Botella de aceite de oliva 1 litro'
           ,13
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('ACE002'
           ,'Manteca de cerdo'
           ,'320 gramos'
           ,13
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('ACE003'
           ,'Aceite la favorita'
           ,'Botella de aceite la favorita 1 litro'
           ,13
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('ACE004'
           ,'Margarina'
           ,'500 gramos'
           ,13
           ,1)
GO
INSERT INTO [dbo].[Producto]
           ([Codigo]
           ,[Nombre]
           ,[Descripcion]
           ,[IdCategoria]
           ,[Estado])
     VALUES
           ('ACE005'
           ,'Aceite Girasol'
           ,'Botella de aceite de girasol refinado 1 litro'
           ,13
           ,1)
GO


/*
 * Insert para la tabla Clientes
 */

INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1719489658'
           ,'Kenya Luna'
           ,'klluna@uce.edu.ec'
           ,'0961083809'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1719489788'
           ,'Mateo Araya'
           ,'mtaara@hotmail.com'
           ,'0961078609'
           ,1)
GO

INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
       VALUES
           ('0267895432'
           ,'María Sánchez'
           ,'marias@gmail.com'
           ,'0987654021'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
VALUES
           ('0356721890'
           ,'Carlos Méndez'
           ,'cmendez@example.com'
           ,'0999765432'
           ,1) 
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0459821672'
           ,'Luisa González'
           ,'luisa.g@example.com'
           ,'0983128456'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0578012345'
           ,'Ana Martínez'
           ,'ana.m@example.com'
           ,'0985123490'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0678012341'
           ,'Pedro Gómez'
           ,'pedrog@example.com'
           ,'0976543210'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0789012356'
           ,'Laura Cajamarca'
           ,'laura@example.com'
           ,'0987654321'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0690123867'
           ,'Jacinto Lumbi'
           ,'jacinl@example.com'
           ,'0998365432'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0916645678'
           ,'Carolina Rosales'
           ,'carol@example.com'
           ,'0987654321'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0103456789'
           ,'Roberto Pérez'
           ,'rperez@example.com'
           ,'0987103456'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0112233445'
           ,'Gabriela Torres'
           ,'gabriela@example.com'
           ,'0987654311'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0233441266'
           ,'Andrés Ruiz'
           ,'andres@example.com'
           ,'0976543120'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0313445677'
           ,'Valeria Herrera'
           ,'valeria@example.com'
           ,'0987651321'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0414667788'
           ,'Javier Ramírez'
           ,'javier@example.com'
           ,'0998761432'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0561578899'
           ,'Carla Gutiérrez'
           ,'carla@example.com'
           ,'0987234156'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1677889920'
           ,'Diego Castro'
           ,'diego@example.com'
           ,'0987165321'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1778990011'
           ,'Mariana López'
           ,'mariana@example.com'
           ,'0998175432'
           ,1)
GO

INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0899001833'
           ,'Héctor Campos'
           ,'hectorcap@example.com'
           ,'0933185431'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0902192233'
           ,'Elena Navarro'
           ,'elena@example.com'
           ,'0987193456'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0511220344'
           ,'Fernando Soto'
           ,'fernando@example.com'
           ,'0987654320'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1321454367'
           ,'Gabriela Checa'
           ,'gabiche@example.com'
           ,'0976365211'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1322445566'
           ,'Andrea Chico'
           ,'andreach@example.com'
           ,'0973332256'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0344523672'
           ,'Valeria Cazco'
           ,'valeca@example.com'
           ,'0982374313'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0924564788'
           ,'Nicolás Caiza'
           ,'nicocz@example.com'
           ,'0998848641'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0562757889'
           ,'Carlos Aguinaga'
           ,'carlagui@example.com'
           ,'0987466251'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0674268900'
           ,'Daniel Montalvo'
           ,'danimon@example.com'
           ,'0983262252'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0827990714'
           ,'Adriana Mendoza'
           ,'adriana@example.com'
           ,'0992683725'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0351001128'
           ,'Hugo Molina'
           ,'hugo@example.com'
           ,'0937754328'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0401229340'
           ,'Eduardo Narváez'
           ,'eduardo@example.com'
           ,'0930954357'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('9900112233'
           ,'Isabella Rodríguez'
           ,'isabella@example.com'
           ,'0987123056'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1763145182'
           ,'Karen Pillajo'
           ,'karenpij@hotmail.com'
           ,'0953126512'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1704003227'
           ,'Liliana Andrade'
           ,'lilian@hotmail.com'
           ,'0997782539'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1137633293'
           ,'Margarita Pozo'
           ,'margpz@hotmail.com'
           ,'0976332672'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0273617634'
           ,'Leonel Tualombo'
           ,'leotb@hotmail.com'
           ,'0956352635'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0452628354'
           ,'Reyshel Enriquez'
           ,'reyz1@hotmail.com'
           ,'0965546278'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1724253627'
           ,'Jessica Batidas'
           ,'jessba@hotmail.com'
           ,'0988856672'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1237562468'
           ,'Steven Aguirre'
           ,'stvag@hotmail.com'
           ,'0900235783'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('0765382725'
           ,'Ian Lennon'
           ,'iannl@hotmail.com'
           ,'0944452623'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1562644391'
           ,'Drake Almeida'
           ,'drakeada@hotmail.com'
           ,'0988753426'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1333424048'
           ,'Norma Espinosa'
           ,'normaes@hotmail.com'
           ,'0931323456'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1741665241'
           ,'Elkin Meneses'
           ,'elkin1@hotmail.com'
           ,'0966642315'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('104211328'
           ,'Bryan Oña'
           ,'bryano@hotmail.com'
           ,'096323357'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1233438413'
           ,'David Jingo'
           ,'djingo@hotmail.com'
           ,'0978854322'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1776654438'
           ,'Francisco Salazar'
           ,'ciscoza@hotmail.com'
           ,'0992331278'
           ,1)
GO

INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1724507232'
           ,'Alexis Ponce'
           ,'alpon@hotmail.com'
           ,'0907071221'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1715132146'
           ,'Sebastian Villa'
           ,'sebasv@hotmail.com'
           ,'0921213462'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1231473112'
           ,'Ximena Panamá'
           ,'ximep@hotmail.com'
           ,'0969691232'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1748642218'
           ,'Lenin Guerrero'
           ,'leguerr@hotmail.com'
           ,'0922313423'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1765249351'
           ,'Angel Collaguazo'
           ,'angelco@hotmail.com'
           ,'0955423413'
           ,1)
GO
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[NombreCompleto]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1733506622'
           ,'María Jaramillo'
           ,'mabej@hotmail.com'
           ,'0999693422'
           ,1)
GO

/*
 * Insert para la tabla Proveedores
 */
 INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1768156470001'
           ,'Vita'
           ,'vitaleche@vita.com'
           ,'0995642839'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1742324326862'
           ,'Coca-Cola'
           ,'contactococacolaecuador@coca-cola.com'
           ,'0973342342'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1745162754724'
           ,'Gatorade'
           ,'CIC@GEPP.COM'
           ,'0934352627'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1562528267712'
           ,'AJE'
           ,'aje@ajegroup.co'
           ,' 0983363010'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1132323342162'
           ,'Frito-Lay'
           ,'frito@frito-lay.com'
           ,' 0944346772'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1552772681322'
           ,'Nutresa'
           ,'grupnutresa@nutresa.com'
           ,' 0996514271'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1005351836555'
           ,'Pepsico'
           ,'pepsi@pepsico.com'
           ,' 0942442456'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1663525228132'
           ,'Switchmasflow'
           ,'switch@switchmasflow.com'
           ,' 0969676823'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1718535173651'
           ,'Cervecería Nacional'
           ,'protecciondatosecuador@ab-inbev.com'
           ,' 0953544162'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1735433245523'
           ,'Corporacion Azende'
           ,'info@azende.com'
           ,'0932525521'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1735433245523'
           ,'Corporacion Azende'
           ,'info@azende.com'
           ,'0932525521'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1353345245552'
           ,'Nestlé'
           ,'servicioalconsumidor@ec.nestle'
           ,'0941876582'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1553477443537'
           ,'Portarroz'
           ,'ventas@portiarroz.com.ec'
           ,'0997905467'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1587544572833'
           ,'Sucesores S.A.'
           ,'ventas@sucesores.com.ec'
           ,'0986130084'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1587544572833'
           ,'Sucesores S.A.'
           ,'ventas@sucesores.com.ec'
           ,'0986130084'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1743517361278'
           ,'Toscana'
           ,'ventas@toscana.com.ec'
           ,'0988654422'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('2156535351900'
           ,'Verde Pamba'
           ,'ventas@verdepamba.com.ec'
           ,'0977563827'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1765543553599'
           ,'Paca'
           ,'ventas@paca.com.ec'
           ,'0966514271'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1488963597361'
           ,'Estrella de Oro'
           ,'oro@estrellaoro.com.ec'
           ,'0966634255'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1453997626241'
           ,'Deja'
           ,'info@deja.com.ec'
           ,'0978452842'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1007535672653'
           ,'Tu Hogar'
           ,'tuhogar@fabuloso.com.ec'
           ,'0965726351'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1017152547284'
           ,'Grupo Oriental'
           ,'astodomingo@gruporiental.com.ec'
           ,'0958982070'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1017152547284'
           ,'Grupo Oriental'
           ,'astodomingo@gruporiental.com.ec'
           ,'0958982070'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1725481976252'
           ,'Bolonia'
           ,'ventas@bolonia.com.ec'
           ,'0953479362'
           ,1)
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1535975894693'
           ,'Colgate'
           ,'ventas@colgateprofesional.com.ec'
           ,'0943658353'
           ,1)
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1337864528263'
           ,'Trululu'
           ,'ventas@trululu.com.ec'
           ,'0965305899'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1825477636551'
           ,'Betty Crocker'
           ,'ventas@bettycrocker.com.ec'
           ,'0998865526'
           ,1)
GO
INSERT INTO [dbo].[Proveedor]
           ([Documento]
           ,[RazonSocial]
           ,[Correo]
           ,[Telefono]
           ,[Estado])
     VALUES
           ('1773364366201'
           ,'Fríovesa'
           ,'ventas@friovesaui.com.ec'
           ,'0966532426'
           ,1)
GO



/* ---------PROCEDIMIENTO ALMACENADO PARA USUARIOS-------------*/
/*
 * Creacion de Procedimiento almacenado para insertar usuarios
 */

 CREATE PROC RegistrarUsuario(
 @Documento VARCHAR(30),
 @NombreCompleto VARCHAR(50),
 @Correo VARCHAR(50),
 @Clave VARCHAR(30),
 @IdRol INT,
 @Estado BIT,
 @IdUsuarioResultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @IdUsuarioResultado = 0
	set @Mensaje = ''

	if not exists (select * from Usuario where Documento = @Documento)
	begin
		insert into Usuario(Documento,NombreCompleto, Correo, Clave, IdRol, Estado) values
		(@Documento, @NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

		set @IdUsuarioResultado = SCOPE_IDENTITY()		
	end
	else
		set @Mensaje = 'No puede existir otro usuario con el mismo Nro de Cédula'
end
GO

/*
 * Creacion de Procedimiento almacenado para editar usuarios
 */

  CREATE PROC EditarUsuario(
 @IdUsuario INT,
 @Documento VARCHAR(30),
 @NombreCompleto VARCHAR(50),
 @Correo VARCHAR(50),
 @Clave VARCHAR(30),
 @IdRol INT,
 @Estado BIT,
 @Respuesta bit output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Respuesta = 0
	set @Mensaje = ''

	if not exists (select * from Usuario where Documento = @Documento and IdUsuario != @IdUsuario)
	begin
		UPDATE Usuario set
		Documento = @Documento,
		NombreCompleto=@NombreCompleto, 
		Correo=@Correo, 
		Clave=@Clave, 
		IdRol=@IdRol, 
		Estado=@Estado
		WHERE IdUsuario = @IdUsuario

		set @Respuesta = 1		
	end
	else
		set @Mensaje = 'No puede existir otro usuario con el mismo Nro de Cédula'
end

GO

/*
 * Creacion de Procedimiento almacenado para eliminar usuarios
 */

 CREATE PROC EliminarUsuario(
 @IdUsuario INT,
 @Respuesta bit output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit =1
	
	if EXISTS(SELECT * FROM Compra c
	INNER JOIN Usuario u on u.IdUsuario = c.IdUsuario
	WHERE u.IdUsuario = @IdUsuario
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una compra\n'

	END

		if EXISTS(SELECT * FROM Venta v
	INNER JOIN Usuario u on u.IdUsuario = v.IdUsuario
	WHERE u.IdUsuario = @IdUsuario
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una venta\n'

	END
	
	if(@pasoreglas = 1)
	BEGIN
		DELETE FROM Usuario where IdUsuario = @IdUsuario
		set @Respuesta = 1
	END
END

GO

/* ---------PROCEDIMIENTO ALMACENADO PARA CATEGORIA-------------*/
/*
 * Creacion de Procedimiento almacenado para guardar categoria
 */

 CREATE PROC RegistrarCategoria(
 @Descripcion VARCHAR(50),
 @Estado BIT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 0

	if not exists (select * from Categoria where Descripcion = @Descripcion)
	begin
		insert into Categoria(Descripcion,Estado) values
		(@Descripcion,@Estado)
		set @Resultado = SCOPE_IDENTITY()		
	end
	else
		set @Mensaje = 'No se puede repetir el nombre de una CATEGORIA'
end
GO

/*
 * Creacion de Procedimiento almacenado para editar categoria
 */

 CREATE PROC EditarCategoria(
 @IdCategoria INT,
 @Descripcion VARCHAR(50),
 @Estado BIT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 1

	if not exists (select * from Categoria where Descripcion = @Descripcion and IdCategoria != @IdCategoria)
		UPDATE Categoria SET 
		Descripcion = @Descripcion,
		Estado = @Estado
		WHERE IdCategoria = @IdCategoria		
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'No se puede repetir el nombre de una CATEGORIA'
	end
end
GO

/*
 * Creacion de Procedimiento almacenado para eliminar categoria
 */

 CREATE PROC EliminarCategoria(
 @IdCategoria INT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 1

	if not exists (select * from Categoria c
	INNER JOIN Producto p on p.IdCategoria = c.IdCategoria
	WHERE c.IdCategoria = @IdCategoria)
	begin
		DELETE top (1) FROM Categoria where IdCategoria = @IdCategoria
	end
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'La CATEGORIA se encuentra relacionada a un PRODUCTO'
	end
end
GO

/* ---------PROCEDIMIENTO ALMACENADO PARA PRODUCTOS-------------*/
/*
 * Creacion de Procedimiento almacenado para insertar productos
 */

 CREATE PROC RegistrarProducto(
 @Codigo VARCHAR(30),
 @Nombre VARCHAR(40),
 @Descripcion VARCHAR(50),
 @IdCategoria INT,
 @Estado BIT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 0

	if not exists (select * from Producto where Codigo = @Codigo)
	begin
		insert into Producto(Codigo,Nombre,Descripcion,IdCategoria,Estado) values
		(@Codigo,@Nombre,@Descripcion,@IdCategoria,@Estado)
		set @Resultado = SCOPE_IDENTITY()		
	end
	else
		set @Mensaje = 'Ya existe un producto con el mismo código'
end
GO

/*
 * Creacion de Procedimiento almacenado para editar productos
 */

 CREATE PROC EditarProducto(
 @IdProducto int,
 @Codigo VARCHAR(30),
 @Nombre VARCHAR(40),
 @Descripcion VARCHAR(50),
 @IdCategoria INT,
 @Estado BIT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 1

	if not exists (select * from Producto where Codigo = @Codigo and IdProducto != @IdProducto)
		UPDATE Producto SET 
		Codigo = @Codigo,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdCategoria = @IdCategoria,
		Estado = @Estado
		WHERE IdProducto = @IdProducto
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'Ya existe un producto con el mismo código'
	end
end
GO

/*
 * Creacion de Procedimiento almacenado para eliminar productos
 */

 CREATE PROC EliminarProducto(
 @IdProducto INT,
 @Respuesta int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit = 1

	if exists (select * from DetalleCompra dc
	INNER JOIN Producto p on p.IdProducto = dc.IdProducto
	WHERE p.IdProducto = @IdProducto)
	begin
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede ELIMINAR porque se encuentra relacionado a una compra\n'
	end
	if exists (select * from DetalleVenta dv
	INNER JOIN Producto p on p.IdProducto = dv.IdProducto
	WHERE p.IdProducto = @IdProducto)
	begin
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede ELIMINAR porque se encuentra relacionado a una venta\n'
	end
	if(@pasoreglas =1)
	begin
		delete from Producto where IdProducto = @IdProducto
		set @Respuesta = 1
	END
end
GO

/* ---------PROCEDIMIENTO ALMACENADO PARA CLIENTES-------------*/
/*
 * Creacion de Procedimiento almacenado para insertar clientes
 */

 CREATE PROC RegistrarCliente(
 @Documento VARCHAR(30),
 @NombreCompleto VARCHAR(50),
 @Correo VARCHAR(50),
 @Telefono VARCHAR(20),
 @Estado BIT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 0
	declare @IDPERSONA int

	if not exists (select * from Cliente where Documento = @Documento)
	begin
		insert into Cliente(Documento,NombreCompleto, Correo, Telefono, Estado) values
		(@Documento, @NombreCompleto,@Correo,@Telefono,@Estado)

		set @Resultado = SCOPE_IDENTITY()		
	end
	else
		set @Mensaje = 'No puede existir otro cliente con el mismo Nro de Cédula'
end
GO

/*
 * Creacion de Procedimiento almacenado para editar clientes
 */

  CREATE PROC EditarCliente(
 @IdCliente INT,
 @Documento VARCHAR(30),
 @NombreCompleto VARCHAR(50),
 @Correo VARCHAR(50),
 @Telefono VARCHAR(20),
 @Estado BIT,
 @Resultado bit output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 1
	declare @IDPERSONA int

	if not exists (select * from Cliente where Documento = @Documento and IdCliente != @IdCliente)
	begin
		UPDATE Cliente set
		Documento = @Documento,
		NombreCompleto=@NombreCompleto, 
		Correo=@Correo, 
		Telefono=@Telefono, 
		Estado=@Estado
		WHERE IdCliente = @IdCliente			
	end
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'No puede existir otro cliente con el mismo Nro de Cédula'
	end
end

GO

/* ---------PROCEDIMIENTO ALMACENADO PARA PROVEEDORES-------------*/
/*
 * Creacion de Procedimiento almacenado para insertar proveedores
 */

 CREATE PROC RegistrarProveedor(
 @Documento VARCHAR(30),
 @RazonSocial VARCHAR(50),
 @Correo VARCHAR(50),
 @Telefono VARCHAR(20),
 @Estado BIT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 0
	declare @IDPERSONA int

	if not exists (select * from Proveedor where Documento = @Documento)
	begin
		insert into Proveedor(Documento,RazonSocial, Correo, Telefono, Estado) values
		(@Documento, @RazonSocial,@Correo,@Telefono,@Estado)

		set @Resultado = SCOPE_IDENTITY()		
	end
	else
		set @Mensaje = 'No puede existir otro proveedor con el mismo Nro de Documento'
end
GO

/*
 * Creacion de Procedimiento almacenado para editar proveedores
 */

  CREATE PROC EditarProveedor(
 @IdProveedor INT,
 @Documento VARCHAR(30),
 @RazonSocial VARCHAR(50),
 @Correo VARCHAR(50),
 @Telefono VARCHAR(20),
 @Estado BIT,
 @Resultado int output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 1
	declare @IDPERSONA int

	if not exists (select * from Proveedor where Documento = @Documento and IdProveedor != @IdProveedor)
	begin
		UPDATE Proveedor set
		Documento = @Documento,
		RazonSocial=@RazonSocial, 
		Correo=@Correo, 
		Telefono=@Telefono, 
		Estado=@Estado
		WHERE IdProveedor = @IdProveedor			
	end
	else
	begin
		set @Resultado = 0	
		set @Mensaje = 'No puede existir otro proveedor con el mismo Nro de Documento'
	end
end

GO

/*
 * Creacion de Procedimiento almacenado para eliminar proveedores
 */

 CREATE PROC EliminarProveedor(
 @IdProveedor INT,
 @Resultado bit output,
 @Mensaje varchar(500) output
 )
 as
 begin
	set @Resultado = 1
	
	if NOT EXISTS(SELECT * FROM Proveedor p
	INNER JOIN Compra c on p.IdProveedor = c.IdProveedor
	WHERE p.IdProveedor = @IdProveedor
	)
	BEGIN
		delete top(1) from Proveedor where IdProveedor = @IdProveedor
	END
	ELSE
	BEGIN
		set @Resultado=0
		set @Mensaje = 'El proveedor ya se encuentra relacionado a una compra\n'

	END
END

GO