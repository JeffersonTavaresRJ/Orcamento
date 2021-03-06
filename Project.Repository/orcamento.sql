USE [master]
GO
/****** Object:  Database [Orcamento]    Script Date: 08/04/2018 15:58:39 ******/
CREATE DATABASE [Orcamento]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Orcamento', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Orcamento.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Orcamento_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Orcamento_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Orcamento] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Orcamento].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Orcamento] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Orcamento] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Orcamento] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Orcamento] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Orcamento] SET ARITHABORT OFF 
GO
ALTER DATABASE [Orcamento] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Orcamento] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Orcamento] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Orcamento] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Orcamento] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Orcamento] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Orcamento] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Orcamento] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Orcamento] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Orcamento] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Orcamento] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Orcamento] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Orcamento] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Orcamento] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Orcamento] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Orcamento] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Orcamento] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Orcamento] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Orcamento] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Orcamento] SET  MULTI_USER 
GO
ALTER DATABASE [Orcamento] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Orcamento] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Orcamento] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Orcamento] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Orcamento]
GO
/****** Object:  Table [dbo].[Conta]    Script Date: 08/04/2018 15:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [PK_Conta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Forma_Pagamento]    Script Date: 08/04/2018 15:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Forma_Pagamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [PK_Forma_Pagamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 08/04/2018 15:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lancamento]    Script Date: 08/04/2018 15:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lancamento](
	[Id_Grupo] [int] NOT NULL,
	[Id_Conta] [int] NOT NULL,
	[Data_Referencia] [date] NOT NULL,
	[Id_Forma_Pagamento] [int] NOT NULL,
	[Descricao] [nvarchar](50) NULL,
	[Data_Lancamento] [date] NOT NULL,
	[Valor] [float] NOT NULL,
 CONSTRAINT [PK_Lancamento_1] PRIMARY KEY CLUSTERED 
(
	[Id_Grupo] ASC,
	[Id_Conta] ASC,
	[Data_Referencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 08/04/2018 15:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Previsao]    Script Date: 08/04/2018 15:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Previsao](
	[Id_Grupo] [int] NOT NULL,
	[Id_Conta] [int] NOT NULL,
	[Data_Referencia] [date] NOT NULL,
	[Data_Inicial] [date] NOT NULL,
	[Data_Final] [date] NOT NULL,
	[Valor] [float] NOT NULL,
 CONSTRAINT [PK_Previsao] PRIMARY KEY CLUSTERED 
(
	[Id_Grupo] ASC,
	[Id_Conta] ASC,
	[Data_Referencia] ASC,
	[Data_Inicial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/04/2018 15:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [nvarchar](4) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Senha] [nvarchar](50) NOT NULL,
	[Status] [char](1) NOT NULL CONSTRAINT [DF_Usuario_Status]  DEFAULT ('A'),
	[IdPerfil] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([Id], [Descricao]) VALUES (1, N'Administrador')
INSERT [dbo].[Perfil] ([Id], [Descricao]) VALUES (2, N'Moderador')
INSERT [dbo].[Perfil] ([Id], [Descricao]) VALUES (3, N'Comum')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
INSERT [dbo].[Usuario] ([IdUsuario], [Nome], [Senha], [Status], [IdPerfil]) VALUES (N'B9GY', N'Jefferson Silva Tavares', N'BBF2DEAD374654CBB32A917AFD236656', N'A', 1)
INSERT [dbo].[Usuario] ([IdUsuario], [Nome], [Senha], [Status], [IdPerfil]) VALUES (N'JST4', N'JEFFERSON TAVARES', N'BBF2DEAD374654CBB32A917AFD236656', N'A', 1)
INSERT [dbo].[Usuario] ([IdUsuario], [Nome], [Senha], [Status], [IdPerfil]) VALUES (N'T4TS', N'Tavares Jefferson', N'BBF2DEAD374654CBB32A917AFD236656', N'I', 1)
ALTER TABLE [dbo].[Grupo] ADD  CONSTRAINT [DF_Grupo_Status]  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Grupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([Id])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_Grupo]
GO
ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Lancamento_Conta] FOREIGN KEY([Id_Conta])
REFERENCES [dbo].[Conta] ([Id])
GO
ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Lancamento_Conta]
GO
ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Lancamento_Forma_Pagamento] FOREIGN KEY([Id_Forma_Pagamento])
REFERENCES [dbo].[Forma_Pagamento] ([Id])
GO
ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Lancamento_Forma_Pagamento]
GO
ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Lancamento_Grupo] FOREIGN KEY([Id_Grupo])
REFERENCES [dbo].[Grupo] ([Id])
GO
ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Lancamento_Grupo]
GO
ALTER TABLE [dbo].[Previsao]  WITH CHECK ADD  CONSTRAINT [FK_Previsao_Conta] FOREIGN KEY([Id_Conta])
REFERENCES [dbo].[Conta] ([Id])
GO
ALTER TABLE [dbo].[Previsao] CHECK CONSTRAINT [FK_Previsao_Conta]
GO
ALTER TABLE [dbo].[Previsao]  WITH CHECK ADD  CONSTRAINT [FK_Previsao_Grupo] FOREIGN KEY([Id_Grupo])
REFERENCES [dbo].[Grupo] ([Id])
GO
ALTER TABLE [dbo].[Previsao] CHECK CONSTRAINT [FK_Previsao_Grupo]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [chk_status_conta] CHECK  (([Status]='I' OR [Status]='A'))
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [chk_status_conta]
GO
ALTER TABLE [dbo].[Forma_Pagamento]  WITH CHECK ADD  CONSTRAINT [chk_status_forma_pagamento] CHECK  (([Status]='I' OR [Status]='A'))
GO
ALTER TABLE [dbo].[Forma_Pagamento] CHECK CONSTRAINT [chk_status_forma_pagamento]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [chk_status_grupo] CHECK  (([Status]='I' OR [Status]='A'))
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [chk_status_grupo]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [chk_status_usuario] CHECK  (([Status]='I' OR [Status]='A'))
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [chk_status_usuario]
GO
USE [master]
GO
ALTER DATABASE [Orcamento] SET  READ_WRITE 
GO
