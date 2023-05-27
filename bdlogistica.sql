USE [master]
GO
/****** Object:  Database [logistica]    Script Date: 27/05/2023 12:42:56 a. m. ******/
CREATE DATABASE [logistica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'logisticaterrestre', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\logisticaterrestre.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'logisticaterrestre_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\logisticaterrestre_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [logistica] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [logistica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [logistica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [logistica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [logistica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [logistica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [logistica] SET ARITHABORT OFF 
GO
ALTER DATABASE [logistica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [logistica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [logistica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [logistica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [logistica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [logistica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [logistica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [logistica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [logistica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [logistica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [logistica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [logistica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [logistica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [logistica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [logistica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [logistica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [logistica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [logistica] SET RECOVERY FULL 
GO
ALTER DATABASE [logistica] SET  MULTI_USER 
GO
ALTER DATABASE [logistica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [logistica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [logistica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [logistica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [logistica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [logistica] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'logistica', N'ON'
GO
ALTER DATABASE [logistica] SET QUERY_STORE = ON
GO
ALTER DATABASE [logistica] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [logistica]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Nombres] [varchar](150) NOT NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](30) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[planes]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[planes](
	[IdPlanEntrega] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTipoProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaEntrega] [datetime] NULL,
	[PuertoEnvio] [varchar](10) NULL,
	[PrecioEnvio] [int] NOT NULL,
	[Descuento] [int] NULL,
	[NumeroFlota] [varchar](8) NULL,
	[NumeroGuia] [varchar](10) NOT NULL,
	[TipoLogistica] [varchar](10) NULL,
	[Placa] [varchar](6) NULL,
 CONSTRAINT [PK_planes] PRIMARY KEY CLUSTERED 
(
	[IdPlanEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoproducto]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoproducto](
	[IdTipoProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[TipoProducto] [varchar](50) NOT NULL,
	[TipoLogistica] [varchar](10) NULL,
 CONSTRAINT [PK_tipoproducto] PRIMARY KEY CLUSTERED 
(
	[IdTipoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertClientes]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		AMESCOBAR
-- Create date: 26-may-2023
-- Description:	procedimiento para insertar clientes
-- =============================================
create   PROCEDURE [dbo].[InsertClientes] 
	-- parameters

	@Identificacion varchar(20) = '',
	@Nombres varchar(150) = '',
	@Direccion varchar(100) = '',
	@Telefono varchar(30) = ''
	
AS
BEGIN


	--valida los estados de la cita 
	--IF (@Estado != 'pendiente' AND @Estado != 'cumplida' AND @Estado != 'cancelada')
--	BEGIN
	--   RAISERROR('No es valido el estado '  ,16,1);
	 --  RETURN;
--	END;

	--valida si la sala esta disponible
	----IF NOT EXISTS(SELECT * FROM Sala WHERE Id = @Id_sala AND CAST(@Fecha_inicio  AS DATE) >= CAST(Disponible_Desde AS DATE) AND CAST(@Fecha_inicio AS DATE) <= CAST(Disponible_HASTA AS DATE))
	--BEGIN
	 --  RAISERROR('la sala no se encuentra disponible',16,1);
	  --  RETURN;
	--END;

	

	

INSERT INTO dbo.clientes
           (
		   Identificacion
		   ,Nombres
		   ,Direccion
		   ,Telefono)
		   --retorna el id 
		   OUTPUT Inserted.IdCliente
     VALUES
           (
		    @Identificacion
		   ,@Nombres
		   ,@Direccion
		   ,@Telefono)
	
 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertPlanes]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		AMESCOBAR
-- Create date: 26-may-2023
-- Description:	procedimiento para insertar planes
-- =============================================
create   PROCEDURE [dbo].[InsertPlanes] 
	-- parameters

			@IdCliente int = 0
           ,@IdTipoProducto int = 0
           ,@Cantidad int = 0
           ,@FechaRegistro datetime = null
           ,@FechaEntrega  datetime = null
           ,@PuertoEnvio  varchar(10) = ''
           ,@PrecioEnvio int = 0
           ,@Descuento int = 0
           ,@NumeroFlota  varchar(8) = ''
           ,@NumeroGuia  varchar(10) = ''
           ,@TipoLogistica  varchar(10) = ''
           ,@Placa  varchar(6) = ''
	
AS
BEGIN


	--valida los estados de la cita 
	--IF (@Estado != 'pendiente' AND @Estado != 'cumplida' AND @Estado != 'cancelada')
--	BEGIN
	--   RAISERROR('No es valido el estado '  ,16,1);
	 --  RETURN;
--	END;

	--valida si la sala esta disponible
	----IF NOT EXISTS(SELECT * FROM Sala WHERE Id = @Id_sala AND CAST(@Fecha_inicio  AS DATE) >= CAST(Disponible_Desde AS DATE) AND CAST(@Fecha_inicio AS DATE) <= CAST(Disponible_HASTA AS DATE))
	--BEGIN
	 --  RAISERROR('la sala no se encuentra disponible',16,1);
	  --  RETURN;
	--END;

	



INSERT INTO [dbo].[planes]
           ([IdCliente]
           ,[IdTipoProducto]
           ,[Cantidad]
           ,[FechaRegistro]
           ,[FechaEntrega]
           ,[PuertoEnvio]
           ,[PrecioEnvio]
           ,[Descuento]
           ,[NumeroFlota]
           ,[NumeroGuia]
           ,[TipoLogistica]
           ,[Placa])
     VALUES
           (@IdCliente
           ,@IdTipoProducto
           ,@Cantidad
           ,@FechaRegistro
           ,@FechaEntrega
           ,@PuertoEnvio
           ,@PrecioEnvio
           ,@Descuento
           ,@NumeroFlota
           ,@NumeroGuia
           ,@TipoLogistica
           ,@Placa)



	
 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectClientes]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		AMESCOBAR
-- Create date: 05-MAYO-2023
-- Description:	procedimiento para seleccionar clientes
-- =============================================
CREATE   PROCEDURE [dbo].[SelectClientes] 
	-- parameters
	@Opcion int = 0,
	@IdCliente int = 0, 
	@Identificacion varchar(20) = '',
	@Nombres varchar(150) = '',
	@Direccion varchar(100) = '',
	@Telefono varchar(30) = ''
	
AS
BEGIN
	
	--filtra todos los datos
	IF @Opcion = 0
	SELECT IdCliente
		  ,Identificacion
		  ,Nombres
		  ,Direccion
		  ,Telefono
	  FROM dbo.clientes
--filtra por IdCliente
	IF @Opcion = 1
		SELECT IdCliente
		  ,Identificacion
		  ,Nombres
		  ,Direccion
		  ,Telefono
	  FROM dbo.clientes
		WHERE IdCliente = @IdCliente

	--filtra por @Identificacion
	IF @Opcion = 2
		SELECT IdCliente
		  ,Identificacion
		  ,Nombres
		  ,Direccion
		  ,Telefono
	  FROM dbo.clientes
		WHERE Identificacion = @Identificacion
END
GO
/****** Object:  StoredProcedure [dbo].[SelectPlanes]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		AMESCOBAR
-- Create date: 05-MAYO-2023
-- Description:	procedimiento para seleccionar planes
-- =============================================
create      PROCEDURE [dbo].[SelectPlanes] 
	-- parameters
	@Opcion int = 0,
	@IdPlanEntrega int = 0, 
	@IdCliente int = 0
	
	
AS
BEGIN

	
	--filtra todos los datos
	IF @Opcion = 0
		SELECT [IdPlanEntrega]
		  ,[IdCliente]
		  ,[IdTipoProducto]
		  ,[Cantidad]
		  ,[FechaRegistro]
		  ,[FechaEntrega]
		  ,[PuertoEnvio]
		  ,[PrecioEnvio]
		  ,[Descuento]
		  ,[NumeroFlota]
		  ,[NumeroGuia]
		  ,[TipoLogistica]
		  ,[Placa]
	  FROM [dbo].[planes]
--filtra por IdPlanEntrega
	IF @Opcion = 1
		SELECT [IdPlanEntrega]
			  ,[IdCliente]
			  ,[IdTipoProducto]
			  ,[Cantidad]
			  ,[FechaRegistro]
			  ,[FechaEntrega]
			  ,[PuertoEnvio]
			  ,[PrecioEnvio]
			  ,[Descuento]
			  ,[NumeroFlota]
			  ,[NumeroGuia]
			  ,[TipoLogistica]
			  ,[Placa]
		  FROM [dbo].[planes]
			WHERE IdPlanEntrega = @IdPlanEntrega

	--filtra por @IdCliente
	IF @Opcion = 2
		SELECT [IdPlanEntrega]
			  ,[IdCliente]
			  ,[IdTipoProducto]
			  ,[Cantidad]
			  ,[FechaRegistro]
			  ,[FechaEntrega]
			  ,[PuertoEnvio]
			  ,[PrecioEnvio]
			  ,[Descuento]
			  ,[NumeroFlota]
			  ,[NumeroGuia]
			  ,[TipoLogistica]
			  ,[Placa]
		  FROM [dbo].[planes]
			WHERE IdCliente = @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[SelectTipoProductos]    Script Date: 27/05/2023 12:42:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		AMESCOBAR
-- Create date: 05-MAYO-2023
-- Description:	procedimiento para seleccionar tipo de productos
-- =============================================
CREATE   PROCEDURE [dbo].[SelectTipoProductos] 
	-- parameters
	@Opcion int = 0,
	@IdTipoProducto int = 0, 
	@TipoProducto varchar(20) = '',
	@TipoLogistica varchar(20) = ''
	
AS
BEGIN
	
	--filtra todos los datos
	IF @Opcion = 0
	SELECT IdTipoProducto
		  ,TipoProducto
		  ,TipoLogistica
	  FROM dbo.tipoproducto

END
GO
USE [master]
GO
ALTER DATABASE [logistica] SET  READ_WRITE 
GO
