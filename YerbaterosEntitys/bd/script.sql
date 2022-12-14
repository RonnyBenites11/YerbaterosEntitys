USE [master]
GO
/****** Object:  Database [ProyectoDSW_202202_2]    Script Date: 28/10/2022 7:43:11 ******/
CREATE DATABASE [ProyectoDSW_202202_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoDSW_202202_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProyectoDSW_202202_2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoDSW_202202_2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProyectoDSW_202202_2_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoDSW_202202_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET RECOVERY FULL 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProyectoDSW_202202_2', N'ON'
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET QUERY_STORE = OFF
GO
USE [ProyectoDSW_202202_2]
GO
/****** Object:  Schema [Compras]    Script Date: 28/10/2022 7:43:11 ******/
CREATE SCHEMA [Compras]
GO
/****** Object:  Schema [RRHH]    Script Date: 28/10/2022 7:43:11 ******/
CREATE SCHEMA [RRHH]
GO
/****** Object:  Schema [Ventas]    Script Date: 28/10/2022 7:43:11 ******/
CREATE SCHEMA [Ventas]
GO
/****** Object:  Table [Compras].[categorias]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Compras].[categorias](
	[IdCategoria] [int] NOT NULL,
	[NombreCategoria] [varchar](15) NOT NULL,
	[Descripcion] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Compras].[productos]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Compras].[productos](
	[IdProducto] [int] NOT NULL,
	[NomProducto] [varchar](40) NOT NULL,
	[IdProveedor] [int] NULL,
	[IdCategoria] [int] NULL,
	[CantxUnidad] [varchar](20) NOT NULL,
	[PrecioUnidad] [decimal](10, 0) NOT NULL,
	[UnidadesEnExistencia] [smallint] NOT NULL,
	[UnidadesEnPedido] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Compras].[proveedores]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Compras].[proveedores](
	[IdProveedor] [int] NOT NULL,
	[NomProveedor] [varchar](40) NOT NULL,
	[DirProveedor] [varchar](60) NOT NULL,
	[NomContacto] [varchar](80) NOT NULL,
	[CargoContacto] [varchar](50) NOT NULL,
	[idpais] [char](3) NULL,
	[fonoProveedor] [varchar](15) NOT NULL,
	[FaxProveedor] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Asiento]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Asiento](
	[Cod_Asiento] [int] IDENTITY(1,1) NOT NULL,
	[Alias_Asiento] [varchar](20) NULL,
	[Cod_Bus] [int] NULL,
	[Cod_Tipo_Asiento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Asiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Bus]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Bus](
	[Cod_Bus] [int] IDENTITY(1,1) NOT NULL,
	[Registro] [varchar](100) NULL,
	[Cantidad_Asientos] [int] NULL,
	[Marca] [varchar](100) NULL,
	[Modelo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Bus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Cliente]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Cliente](
	[CodNro_Cliente] [int] NOT NULL,
	[Cod_TipoDoc] [int] NULL,
	[Nombres_Cliente] [varchar](30) NULL,
	[Apellidos_Cliente] [varchar](30) NULL,
	[Cod_Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodNro_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Departamento]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Departamento](
	[Cod_Departamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Departamento] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_DetalleVentaPasaje]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DetalleVentaPasaje](
	[Id_Venta] [int] IDENTITY(1,1) NOT NULL,
	[Cod_Viaje] [int] NULL,
	[CodNro_Cliente] [int] NULL,
	[Cod_Asiento] [int] NULL,
	[Voucher] [varchar](20) NULL,
	[Costo_Ticket] [float] NULL,
	[Descuento] [float] NULL,
	[Sub_total] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Ruta]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Ruta](
	[Cod_Ruta] [int] IDENTITY(1,1) NOT NULL,
	[Alias_Ruta] [varchar](100) NULL,
	[Tiempo_Promedio_Ruta] [bigint] NULL,
	[Cod_Terminal_Origen] [int] NULL,
	[Cod_Terminal_Destino] [int] NULL,
	[DistanciaKm] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Ruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TerminalTerrestre]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TerminalTerrestre](
	[Cod_Terminal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Terminal] [varchar](100) NULL,
	[Cod_Departamento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Terminal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TipoAsiento]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TipoAsiento](
	[Cod_Tipo_Asiento] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_ASiento] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Tipo_Asiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TipoDoc]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TipoDoc](
	[Cod_TipoDoc] [int] NOT NULL,
	[Descripcion_TipoDoc] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_TipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Usuario]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Usuario](
	[Cod_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Correo_Usuario] [varchar](30) NULL,
	[Contraseña_Usuario] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_VentaPasaje]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_VentaPasaje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cod_Usuario] [int] NULL,
	[Fecha_Venta] [date] NULL,
	[Monto_Total] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Viaje]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Viaje](
	[Cod_Viaje] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Hora_Partida] [date] NULL,
	[Fecha_Hora_Llegada] [date] NULL,
	[Cod_Ruta] [int] NULL,
	[Cod_Bus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod_Viaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[Cargos]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[Cargos](
	[idcargo] [int] NOT NULL,
	[desCargo] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idcargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[Distritos]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[Distritos](
	[idDistrito] [int] NOT NULL,
	[nomDistrito] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[empleados]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[empleados](
	[IdEmpleado] [int] NOT NULL,
	[ApeEmpleado] [varchar](50) NOT NULL,
	[NomEmpleado] [varchar](50) NOT NULL,
	[FecNac] [datetime] NOT NULL,
	[DirEmpleado] [varchar](60) NOT NULL,
	[idDistrito] [int] NULL,
	[fonoEmpleado] [varchar](15) NULL,
	[idCargo] [int] NULL,
	[FecContrata] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[clientes]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[clientes](
	[IdCliente] [varchar](5) NOT NULL,
	[NomCliente] [varchar](40) NOT NULL,
	[DirCliente] [varchar](60) NOT NULL,
	[idpais] [char](3) NULL,
	[fonoCliente] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[paises]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[paises](
	[Idpais] [char](3) NOT NULL,
	[NombrePais] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idpais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[pedidoscabe]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[pedidoscabe](
	[IdPedido] [int] NOT NULL,
	[IdCliente] [varchar](5) NULL,
	[IdEmpleado] [int] NULL,
	[FechaPedido] [datetime] NOT NULL,
	[FechaEntrega] [datetime] NULL,
	[FechaEnvio] [datetime] NULL,
	[EnvioPedido] [char](1) NULL,
	[CantidaPedido] [int] NULL,
	[Destinatario] [varchar](40) NULL,
	[DirDestinatario] [varchar](60) NULL,
	[CiuDestinatario] [varchar](60) NULL,
	[RefDestnatario] [varchar](60) NULL,
	[DepDestinatario] [varchar](60) NULL,
	[PaiDestinatario] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[pedidosdeta]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[pedidosdeta](
	[IdPedido] [int] NULL,
	[IdProducto] [int] NULL,
	[PrecioUnidad] [decimal](10, 0) NOT NULL,
	[Cantidad] [smallint] NOT NULL,
	[Descuento] [float] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [Ventas].[pedidoscabe] ADD  DEFAULT (getdate()) FOR [FechaPedido]
GO
ALTER TABLE [Ventas].[pedidoscabe] ADD  DEFAULT ('0') FOR [EnvioPedido]
GO
ALTER TABLE [Compras].[productos]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [Compras].[categorias] ([IdCategoria])
GO
ALTER TABLE [Compras].[productos]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [Compras].[proveedores] ([IdProveedor])
GO
ALTER TABLE [Compras].[proveedores]  WITH CHECK ADD FOREIGN KEY([idpais])
REFERENCES [Ventas].[paises] ([Idpais])
GO
ALTER TABLE [dbo].[tb_Asiento]  WITH CHECK ADD FOREIGN KEY([Cod_Bus])
REFERENCES [dbo].[tb_Bus] ([Cod_Bus])
GO
ALTER TABLE [dbo].[tb_Asiento]  WITH CHECK ADD FOREIGN KEY([Cod_Tipo_Asiento])
REFERENCES [dbo].[tb_TipoAsiento] ([Cod_Tipo_Asiento])
GO
ALTER TABLE [dbo].[tb_Cliente]  WITH CHECK ADD FOREIGN KEY([Cod_TipoDoc])
REFERENCES [dbo].[tb_TipoDoc] ([Cod_TipoDoc])
GO
ALTER TABLE [dbo].[tb_Cliente]  WITH CHECK ADD FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[tb_Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[tb_DetalleVentaPasaje]  WITH CHECK ADD FOREIGN KEY([Cod_Asiento])
REFERENCES [dbo].[tb_Asiento] ([Cod_Asiento])
GO
ALTER TABLE [dbo].[tb_DetalleVentaPasaje]  WITH CHECK ADD FOREIGN KEY([Cod_Viaje])
REFERENCES [dbo].[tb_Viaje] ([Cod_Viaje])
GO
ALTER TABLE [dbo].[tb_DetalleVentaPasaje]  WITH CHECK ADD FOREIGN KEY([CodNro_Cliente])
REFERENCES [dbo].[tb_Cliente] ([CodNro_Cliente])
GO
ALTER TABLE [dbo].[tb_DetalleVentaPasaje]  WITH CHECK ADD FOREIGN KEY([Id_Venta])
REFERENCES [dbo].[tb_VentaPasaje] ([Id])
GO
ALTER TABLE [dbo].[tb_Ruta]  WITH CHECK ADD FOREIGN KEY([Cod_Terminal_Origen])
REFERENCES [dbo].[tb_TerminalTerrestre] ([Cod_Terminal])
GO
ALTER TABLE [dbo].[tb_Ruta]  WITH CHECK ADD FOREIGN KEY([Cod_Terminal_Destino])
REFERENCES [dbo].[tb_TerminalTerrestre] ([Cod_Terminal])
GO
ALTER TABLE [dbo].[tb_TerminalTerrestre]  WITH CHECK ADD FOREIGN KEY([Cod_Departamento])
REFERENCES [dbo].[tb_Departamento] ([Cod_Departamento])
GO
ALTER TABLE [dbo].[tb_VentaPasaje]  WITH CHECK ADD FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[tb_Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[tb_Viaje]  WITH CHECK ADD FOREIGN KEY([Cod_Bus])
REFERENCES [dbo].[tb_Bus] ([Cod_Bus])
GO
ALTER TABLE [dbo].[tb_Viaje]  WITH CHECK ADD FOREIGN KEY([Cod_Ruta])
REFERENCES [dbo].[tb_Ruta] ([Cod_Ruta])
GO
ALTER TABLE [RRHH].[empleados]  WITH CHECK ADD FOREIGN KEY([idCargo])
REFERENCES [RRHH].[Cargos] ([idcargo])
GO
ALTER TABLE [RRHH].[empleados]  WITH CHECK ADD FOREIGN KEY([idDistrito])
REFERENCES [RRHH].[Distritos] ([idDistrito])
GO
ALTER TABLE [Ventas].[clientes]  WITH CHECK ADD FOREIGN KEY([idpais])
REFERENCES [Ventas].[paises] ([Idpais])
GO
ALTER TABLE [Ventas].[pedidoscabe]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [Ventas].[clientes] ([IdCliente])
GO
ALTER TABLE [Ventas].[pedidoscabe]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [Ventas].[clientes] ([IdCliente])
GO
ALTER TABLE [Ventas].[pedidoscabe]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [RRHH].[empleados] ([IdEmpleado])
GO
ALTER TABLE [Ventas].[pedidoscabe]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [RRHH].[empleados] ([IdEmpleado])
GO
ALTER TABLE [Ventas].[pedidosdeta]  WITH CHECK ADD FOREIGN KEY([IdPedido])
REFERENCES [Ventas].[pedidoscabe] ([IdPedido])
GO
ALTER TABLE [Ventas].[pedidosdeta]  WITH CHECK ADD FOREIGN KEY([IdPedido])
REFERENCES [Ventas].[pedidoscabe] ([IdPedido])
GO
ALTER TABLE [Ventas].[pedidosdeta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [Compras].[productos] ([IdProducto])
GO
ALTER TABLE [Ventas].[pedidosdeta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [Compras].[productos] ([IdProducto])
GO
/****** Object:  StoredProcedure [dbo].[usp_listarClientes]    Script Date: 28/10/2022 7:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_listarClientes]
as
begin
select c.CodNro_Cliente,d.Descripcion_TipoDoc,c.Nombres_Cliente,c.Apellidos_Cliente,u.Correo_Usuario from tb_Cliente c  inner join tb_TipoDoc d on c.Cod_TipoDoc= d.Cod_TipoDoc inner join tb_Usuario u on u.Cod_Usuario = c.Cod_Usuario
end
GO
USE [master]
GO
ALTER DATABASE [ProyectoDSW_202202_2] SET  READ_WRITE 
GO
