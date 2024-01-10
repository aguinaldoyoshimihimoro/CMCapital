
CREATE TABLE [dbo].[Clientes](
	[Id_Cod_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Dt_Ultima_Compra] [datetime] NOT NULL,
	[Saldo] [float] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id_Cod_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Produtos](
	[Id_Cod_Produto] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](150) NOT NULL,
	[Dt_Vencimento] [datetime] NOT NULL,
	[Dt_Cadastro] [datetime] NOT NULL,
	[Vr_Unitario] [float] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Id_Cod_Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClientesProdutos](
	[Id_Cod_ClienteProduto] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cod_Cliente] [int] NOT NULL,
	[Id_Cod_Produto] [int] NOT NULL,
	[Dt_Compra] [datetime] NOT NULL,
	[Vr_Compra] [float] NOT NULL,
 CONSTRAINT [PK_ClientesProdutos] PRIMARY KEY CLUSTERED 
(
	[Id_Cod_ClienteProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Taxas](
	[Id_Cod_Taxa] [int] IDENTITY(1,1) NOT NULL,
	[Vr_Inicial] [float] NULL,
	[Vr_Final] [float] NULL,
	[Percentual] [decimal](5, 4) NOT NULL,
 CONSTRAINT [PK_Taxas] PRIMARY KEY CLUSTERED 
(
	[Id_Cod_Taxa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO







--insert into Clientes values('Cliente 1', '01/12/2023', 1.00)
--insert into Clientes values('Cliente 2', '01/12/2023', 10.00)
--insert into Clientes values('Cliente 3', '01/12/2023', 100.00)
--insert into Clientes values('Cliente 4', '01/12/2023', 1000.00)
--insert into Clientes values('Cliente 5', '01/12/2023', 10000.00)

select * from Produtos

--insert into Produtos values('Produto A', '31/05/2024', '02/01/2024', 10.00)
--insert into Produtos values('Produto B', '30/06/2024', '02/01/2024', 100.00)
--insert into Produtos values('Produto C', '31/07/2024', '02/01/2024', 200.00)
--insert into Produtos values('Produto D', '30/08/2024', '02/01/2024', 500.00)
--insert into Produtos values('Produto E', '30/09/2024', '02/01/2024', 1000.00)
--insert into Produtos values('Produto F', '31/10/2024', '02/01/2024', 3000.00)
--insert into Produtos values('Produto F', '30/11/2024', '02/01/2024', 11000.00)
--insert into Produtos values('Produto G', '31/12/2024', '02/01/2024', 22000.00)

--insert into Taxas values(500.00, 1000.00, 0.65)
--insert into Taxas values(1000.00, 10000.00, 0.85)
--insert into Taxas values(10001.00, 20000.00, 0.98)
--insert into Taxas values(20001.00, null, 1.018)

--insert into ClientesProdutos values(1,1,'02/01/2024', 10.00)
--insert into ClientesProdutos values(1,2,'02/01/2024', 100.00)
--insert into ClientesProdutos values(1,3,'02/01/2024', 200.00)

--insert into ClientesProdutos values(2,1,'02/01/2024', 20.00)
--insert into ClientesProdutos values(2,2,'02/01/2024', 200.00)
--insert into ClientesProdutos values(2,3,'02/01/2024', 400.00)

--insert into ClientesProdutos values(3,1,'02/01/2024', 50.00)
--insert into ClientesProdutos values(3,2,'02/01/2024', 1000.00)
--insert into ClientesProdutos values(3,3,'02/01/2024', 2000.00)

--insert into ClientesProdutos values(4,4,'02/01/2024', 500.00)
--insert into ClientesProdutos values(4,5,'02/01/2024', 1000.00)
--insert into ClientesProdutos values(4,6,'02/01/2024', 3000.00)

--insert into ClientesProdutos values(5,4,'02/01/2024', 2000.00)
--insert into ClientesProdutos values(5,5,'02/01/2024', 4000.00)
--insert into ClientesProdutos values(5,6,'02/01/2024', 12000.00)


