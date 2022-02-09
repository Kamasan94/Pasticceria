USE [master]
GO
/****** Object:  Database [Pasticceria]    Script Date: 09/02/2022 22:20:56 ******/
CREATE DATABASE [Pasticceria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pasticceria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pasticceria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pasticceria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pasticceria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Pasticceria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pasticceria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pasticceria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pasticceria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pasticceria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pasticceria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pasticceria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pasticceria] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Pasticceria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pasticceria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pasticceria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pasticceria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pasticceria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pasticceria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pasticceria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pasticceria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pasticceria] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Pasticceria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pasticceria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pasticceria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pasticceria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pasticceria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pasticceria] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Pasticceria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pasticceria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pasticceria] SET  MULTI_USER 
GO
ALTER DATABASE [Pasticceria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pasticceria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pasticceria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pasticceria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pasticceria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pasticceria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Pasticceria] SET QUERY_STORE = OFF
GO
USE [Pasticceria]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 09/02/2022 22:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dolci]    Script Date: 09/02/2022 22:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dolci](
	[DolceId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NULL,
 CONSTRAINT [PK_Dolci] PRIMARY KEY CLUSTERED 
(
	[DolceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredienti]    Script Date: 09/02/2022 22:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredienti](
	[IngredienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NULL,
 CONSTRAINT [PK_Ingredienti] PRIMARY KEY CLUSTERED 
(
	[IngredienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ricette]    Script Date: 09/02/2022 22:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ricette](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DolceId] [int] NOT NULL,
	[IngredienteId] [int] NOT NULL,
	[Quantita] [int] NOT NULL,
	[UM] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Ricette] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vetrina]    Script Date: 09/02/2022 22:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vetrina](
	[VetrinaId] [int] IDENTITY(1,1) NOT NULL,
	[DolceId] [int] NOT NULL,
	[Prezzo] [decimal](19, 4) NOT NULL,
	[Quantita] [int] NOT NULL,
	[MessaInVendita] [date] NOT NULL,
 CONSTRAINT [PK_Vetrina] PRIMARY KEY CLUSTERED 
(
	[VetrinaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220205143659_Init', N'6.0.1')
GO
SET IDENTITY_INSERT [dbo].[Dolci] ON 
GO
INSERT [dbo].[Dolci] ([DolceId], [Nome]) VALUES (2, N'Torta di mele')
GO
INSERT [dbo].[Dolci] ([DolceId], [Nome]) VALUES (3, N'Cannolo')
GO
INSERT [dbo].[Dolci] ([DolceId], [Nome]) VALUES (4, N'Zeppola')
GO
INSERT [dbo].[Dolci] ([DolceId], [Nome]) VALUES (11, N'Frittella')
GO
SET IDENTITY_INSERT [dbo].[Dolci] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredienti] ON 
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (1, N'Burro')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (2, N'Zucchero')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (3, N'Uovo')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (4, N'Sale')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (5, N'Vaniglia')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (6, N'Farina')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (7, N'Gocce di cioccolato')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (8, N'Lievito')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (9, N'Mele')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (10, N'Cannella')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (11, N'Latte')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (12, N'Strutto')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (13, N'Aceto')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (14, N'Marsala')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (15, N'Olio')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (16, N'Acqua')
GO
INSERT [dbo].[Ingredienti] ([IngredienteId], [Nome]) VALUES (17, N'Panna')
GO
SET IDENTITY_INSERT [dbo].[Ingredienti] OFF
GO
SET IDENTITY_INSERT [dbo].[Ricette] ON 
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (7, 2, 9, 930, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (8, 2, 6, 250, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (9, 2, 11, 150, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (10, 2, 10, 0, N'cucchiaini')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (11, 2, 2, 200, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (12, 2, 1, 100, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (13, 3, 6, 260, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (14, 3, 12, 30, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (15, 3, 4, 260, N'cucchiaini')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (16, 3, 13, 10, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (17, 3, 14, 60, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (18, 4, 3, 3, N'n')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (19, 4, 1, 55, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (20, 4, 6, 150, N'g')
GO
INSERT [dbo].[Ricette] ([Id], [DolceId], [IngredienteId], [Quantita], [UM]) VALUES (21, 4, 16, 250, N'ml')
GO
SET IDENTITY_INSERT [dbo].[Ricette] OFF
GO
SET IDENTITY_INSERT [dbo].[Vetrina] ON 
GO
INSERT [dbo].[Vetrina] ([VetrinaId], [DolceId], [Prezzo], [Quantita], [MessaInVendita]) VALUES (21, 3, CAST(2.2000 AS Decimal(19, 4)), 2, CAST(N'2022-02-09' AS Date))
GO
INSERT [dbo].[Vetrina] ([VetrinaId], [DolceId], [Prezzo], [Quantita], [MessaInVendita]) VALUES (22, 3, CAST(2.0000 AS Decimal(19, 4)), 2, CAST(N'2022-02-09' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Vetrina] OFF
GO
/****** Object:  Index [IX_Ricette_DolceId]    Script Date: 09/02/2022 22:20:57 ******/
CREATE NONCLUSTERED INDEX [IX_Ricette_DolceId] ON [dbo].[Ricette]
(
	[DolceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ricette_IngredienteId]    Script Date: 09/02/2022 22:20:57 ******/
CREATE NONCLUSTERED INDEX [IX_Ricette_IngredienteId] ON [dbo].[Ricette]
(
	[IngredienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vetrina_DolceId]    Script Date: 09/02/2022 22:20:57 ******/
CREATE NONCLUSTERED INDEX [IX_Vetrina_DolceId] ON [dbo].[Vetrina]
(
	[DolceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ricette]  WITH CHECK ADD  CONSTRAINT [FK_Ricette_Dolci_DolceId] FOREIGN KEY([DolceId])
REFERENCES [dbo].[Dolci] ([DolceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ricette] CHECK CONSTRAINT [FK_Ricette_Dolci_DolceId]
GO
ALTER TABLE [dbo].[Ricette]  WITH CHECK ADD  CONSTRAINT [FK_Ricette_Ingredienti_IngredienteId] FOREIGN KEY([IngredienteId])
REFERENCES [dbo].[Ingredienti] ([IngredienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ricette] CHECK CONSTRAINT [FK_Ricette_Ingredienti_IngredienteId]
GO
ALTER TABLE [dbo].[Vetrina]  WITH CHECK ADD  CONSTRAINT [FK_Vetrina_Dolci_DolceId] FOREIGN KEY([DolceId])
REFERENCES [dbo].[Dolci] ([DolceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vetrina] CHECK CONSTRAINT [FK_Vetrina_Dolci_DolceId]
GO
USE [master]
GO
ALTER DATABASE [Pasticceria] SET  READ_WRITE 
GO
