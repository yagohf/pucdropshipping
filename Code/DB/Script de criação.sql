USE [master]
GO
/****** Object:  Database [Dropshipping]    Script Date: 18/08/2018 22:39:51 ******/
CREATE DATABASE [Dropshipping]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dropshipping', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dropshipping.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dropshipping_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dropshipping_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dropshipping] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dropshipping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dropshipping] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dropshipping] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dropshipping] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dropshipping] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dropshipping] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dropshipping] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dropshipping] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dropshipping] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dropshipping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dropshipping] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dropshipping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dropshipping] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dropshipping] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dropshipping] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dropshipping] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dropshipping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dropshipping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dropshipping] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dropshipping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dropshipping] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dropshipping] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dropshipping] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dropshipping] SET RECOVERY FULL 
GO
ALTER DATABASE [Dropshipping] SET  MULTI_USER 
GO
ALTER DATABASE [Dropshipping] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dropshipping] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dropshipping] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dropshipping] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dropshipping] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dropshipping', N'ON'
GO
USE [Dropshipping]
GO
/****** Object:  Table [dbo].[Atendimento]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Atendimento](
	[Id] [int] NOT NULL,
	[IdAtendimentoTipo] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdAtendente] [int] NULL,
	[IdPedido] [int] NULL,
	[IdPedidoItem] [int] NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Descricao] [varchar](8000) NOT NULL,
	[Finalizado] [bit] NOT NULL,
 CONSTRAINT [PK_Solicitacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AtendimentoChat]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AtendimentoChat](
	[Id] [int] NOT NULL,
	[IdAtendimento] [int] NOT NULL,
	[IdAutor] [int] NOT NULL,
	[Texto] [varchar](4000) NOT NULL,
	[DataEnvio] [datetime] NOT NULL,
 CONSTRAINT [PK_AtendimentoChat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AtendimentoTipo]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AtendimentoTipo](
	[Id] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](400) NOT NULL,
 CONSTRAINT [PK_AtendimentoTipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_AtendimentoTipo_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entrega]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrega](
	[IdPedidoItem] [int] NOT NULL,
	[IdEntregaStatus] [int] NOT NULL,
	[DataPrevisaoEntrega] [date] NULL,
 CONSTRAINT [PK_Entrega] PRIMARY KEY CLUSTERED 
(
	[IdPedidoItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EntregaEvento]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntregaEvento](
	[Id] [int] NOT NULL,
	[IdPedidoItem] [int] NOT NULL,
	[IdEntregaStatus] [int] NOT NULL,
	[DataOcorrencia] [datetime] NOT NULL,
 CONSTRAINT [PK_PedidoEvento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EntregaStatus]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntregaStatus](
	[Id] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](400) NOT NULL,
 CONSTRAINT [PK_EntregaStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_EntregaStatus_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[Id] [int] NOT NULL,
	[EnderecoWebsite] [varchar](100) NULL,
	[AtualizaEstoqueAutomaticamente] [bit] NOT NULL,
 CONSTRAINT [PK_Fornecedor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pagamento]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pagamento](
	[IdPedido] [int] NOT NULL,
	[IdPagamentoStatus] [int] NOT NULL,
	[ChaveTransacao] [varchar](32) NOT NULL,
	[DescricaoPagamento] [varchar](300) NOT NULL,
	[XMLTransacao] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Pagamento] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagamentoEvento]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PagamentoEvento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdPagamentoStatus] [int] NOT NULL,
	[DataRecebimento] [datetime] NOT NULL,
	[XMLTransacao] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PagamentoEvento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagamentoStatus]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PagamentoStatus](
	[Id] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](400) NOT NULL,
 CONSTRAINT [PK_PagamentoStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_PagamentoStatus_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdVendedor] [int] NULL,
	[Data] [datetime] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[ValorProdutos] [decimal](20, 2) NOT NULL,
	[Desconto] [decimal](20, 2) NOT NULL,
	[ValorPago] [decimal](20, 2) NOT NULL,
	[IdEnderecoEntrega] [int] NOT NULL,
 CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoItem]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdVenda] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[PrecoUnitario] [decimal](20, 2) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[Desconto] [decimal](20, 2) NOT NULL,
	[PrecoFinal] [decimal](20, 2) NOT NULL,
 CONSTRAINT [PK_PedidoItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoStatus]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PedidoStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](400) NOT NULL,
 CONSTRAINT [PK_PedidoStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_PedidoStatus_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Perfil_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Telefone] [varchar](20) NULL,
	[Documento] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PessoaEndereco]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PessoaEndereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPessoa] [int] NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Numero] [varchar](10) NOT NULL,
	[Observacao] [varchar](200) NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cidade] [varchar](150) NOT NULL,
	[Estado] [varchar](100) NOT NULL,
	[CEP] [varchar](10) NOT NULL,
 CONSTRAINT [PK_PessoaEndereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFornecedor] [int] NOT NULL,
	[ChaveFornecedor] [varchar](100) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[Disponivel] [bit] NOT NULL,
	[PrecoCusto] [decimal](20, 2) NOT NULL,
	[PrecoVenda] [decimal](20, 2) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[IdProdutoCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_IdFornecedorChaveFornecedor] UNIQUE NONCLUSTERED 
(
	[IdFornecedor] ASC,
	[ChaveFornecedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProdutoCategoria]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProdutoCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](400) NOT NULL,
 CONSTRAINT [PK_ProdutoCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProdutoPromocao]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoPromocao](
	[IdPromocao] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[PrecoVenda] [decimal](20, 2) NOT NULL,
 CONSTRAINT [PK_ProdutoPromocao] PRIMARY KEY CLUSTERED 
(
	[IdPromocao] ASC,
	[IdProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promocao]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promocao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFimPrevisto] [datetime] NULL,
	[DataFim] [datetime] NULL,
	[Ativa] [bit] NOT NULL,
 CONSTRAINT [PK_Promocao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Promocao_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 18/08/2018 22:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Senha] [varchar](32) NOT NULL,
	[IdPerfil] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Usuario] UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_AtendimentoTipo] FOREIGN KEY([IdAtendimentoTipo])
REFERENCES [dbo].[AtendimentoTipo] ([Id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Atendimento_AtendimentoTipo]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_Pessoa] FOREIGN KEY([IdAtendente])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Atendimento_Pessoa]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Solicitacao_Pedido]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_PedidoItem] FOREIGN KEY([IdPedidoItem])
REFERENCES [dbo].[PedidoItem] ([Id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Solicitacao_PedidoItem]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_Pessoa] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Solicitacao_Pessoa]
GO
ALTER TABLE [dbo].[AtendimentoChat]  WITH CHECK ADD  CONSTRAINT [FK_AtendimentoChat_Atendimento] FOREIGN KEY([IdAtendimento])
REFERENCES [dbo].[Atendimento] ([Id])
GO
ALTER TABLE [dbo].[AtendimentoChat] CHECK CONSTRAINT [FK_AtendimentoChat_Atendimento]
GO
ALTER TABLE [dbo].[AtendimentoChat]  WITH CHECK ADD  CONSTRAINT [FK_AtendimentoChat_Pessoa] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[AtendimentoChat] CHECK CONSTRAINT [FK_AtendimentoChat_Pessoa]
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD  CONSTRAINT [FK_Entrega_EntregaStatus] FOREIGN KEY([IdEntregaStatus])
REFERENCES [dbo].[EntregaStatus] ([Id])
GO
ALTER TABLE [dbo].[Entrega] CHECK CONSTRAINT [FK_Entrega_EntregaStatus]
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD  CONSTRAINT [FK_Entrega_PedidoItem] FOREIGN KEY([IdPedidoItem])
REFERENCES [dbo].[PedidoItem] ([Id])
GO
ALTER TABLE [dbo].[Entrega] CHECK CONSTRAINT [FK_Entrega_PedidoItem]
GO
ALTER TABLE [dbo].[EntregaEvento]  WITH CHECK ADD  CONSTRAINT [FK_EntregaEvento_EntregaStatus] FOREIGN KEY([IdEntregaStatus])
REFERENCES [dbo].[EntregaStatus] ([Id])
GO
ALTER TABLE [dbo].[EntregaEvento] CHECK CONSTRAINT [FK_EntregaEvento_EntregaStatus]
GO
ALTER TABLE [dbo].[EntregaEvento]  WITH CHECK ADD  CONSTRAINT [FK_PedidoEvento_Entrega] FOREIGN KEY([IdPedidoItem])
REFERENCES [dbo].[Entrega] ([IdPedidoItem])
GO
ALTER TABLE [dbo].[EntregaEvento] CHECK CONSTRAINT [FK_PedidoEvento_Entrega]
GO
ALTER TABLE [dbo].[Fornecedor]  WITH CHECK ADD  CONSTRAINT [FK_Fornecedor_Pessoa] FOREIGN KEY([Id])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Fornecedor] CHECK CONSTRAINT [FK_Fornecedor_Pessoa]
GO
ALTER TABLE [dbo].[Pagamento]  WITH CHECK ADD  CONSTRAINT [FK_Pagamento_PagamentoStatus] FOREIGN KEY([IdPagamentoStatus])
REFERENCES [dbo].[PagamentoStatus] ([Id])
GO
ALTER TABLE [dbo].[Pagamento] CHECK CONSTRAINT [FK_Pagamento_PagamentoStatus]
GO
ALTER TABLE [dbo].[Pagamento]  WITH CHECK ADD  CONSTRAINT [FK_Pagamento_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Pagamento] CHECK CONSTRAINT [FK_Pagamento_Pedido]
GO
ALTER TABLE [dbo].[PagamentoEvento]  WITH CHECK ADD  CONSTRAINT [FK_PagamentoEvento_Pagamento] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pagamento] ([IdPedido])
GO
ALTER TABLE [dbo].[PagamentoEvento] CHECK CONSTRAINT [FK_PagamentoEvento_Pagamento]
GO
ALTER TABLE [dbo].[PagamentoEvento]  WITH CHECK ADD  CONSTRAINT [FK_PagamentoEvento_PagamentoStatus] FOREIGN KEY([IdPagamentoStatus])
REFERENCES [dbo].[PagamentoStatus] ([Id])
GO
ALTER TABLE [dbo].[PagamentoEvento] CHECK CONSTRAINT [FK_PagamentoEvento_PagamentoStatus]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_PedidoStatus] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[PedidoStatus] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_PedidoStatus]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_PessoaEndereco] FOREIGN KEY([IdEnderecoEntrega])
REFERENCES [dbo].[PessoaEndereco] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_PessoaEndereco]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Vendedor] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Vendedor]
GO
ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Pedido] FOREIGN KEY([IdVenda])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Pedido]
GO
ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Produto]
GO
ALTER TABLE [dbo].[Pessoa]  WITH CHECK ADD  CONSTRAINT [FK_Pessoa_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Pessoa] CHECK CONSTRAINT [FK_Pessoa_Usuario]
GO
ALTER TABLE [dbo].[PessoaEndereco]  WITH CHECK ADD  CONSTRAINT [FK_PessoaEndereco_Pessoa] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[PessoaEndereco] CHECK CONSTRAINT [FK_PessoaEndereco_Pessoa]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([Id])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_Fornecedor]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_ProdutoCategoria] FOREIGN KEY([IdProdutoCategoria])
REFERENCES [dbo].[ProdutoCategoria] ([Id])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_ProdutoCategoria]
GO
ALTER TABLE [dbo].[ProdutoPromocao]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoPromocao_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[ProdutoPromocao] CHECK CONSTRAINT [FK_ProdutoPromocao_Produto]
GO
ALTER TABLE [dbo].[ProdutoPromocao]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoPromocao_Promocao] FOREIGN KEY([IdPromocao])
REFERENCES [dbo].[Promocao] ([Id])
GO
ALTER TABLE [dbo].[ProdutoPromocao] CHECK CONSTRAINT [FK_ProdutoPromocao_Promocao]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
USE [master]
GO
ALTER DATABASE [Dropshipping] SET  READ_WRITE 
GO
