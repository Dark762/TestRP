USE [db_Test]
GO

/****** Object:  Table [dbo].[Producto]    Script Date: 30/07/2021 12:55:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Precio] [numeric](18, 2) NULL,
	[Stock] [int] NULL,
	[FechaRegistro] [datetime] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




Create PROC USP_INS_PRODUCTO
@Nombre VARCHAR(50)
,@Precio numeric(18,2)
,@Stock int
,@FechaRegistro datetime
AS
BEGIN
	Insert Into Producto (Nombre, Precio, Stock, FechaRegistro) Values(@Nombre, @Precio, @Stock, @FechaRegistro)
END;


Create PROC USP_UPD_PRODUCTO
@Id int
,@Nombre VARCHAR(50)
,@Precio numeric(18,2)
,@Stock int
,@FechaRegistro datetime
AS
BEGIN
						  UPDATE Producto set 
							  Nombre= @Nombre
							  ,Precio= @Precio
							  ,Stock= @Stock
							  ,FechaRegistro= @FechaRegistro
                          WHERE Id= @Id
END



create proc USP_DEL_PRODUCTO
@Id int
AS
BEGIN
	DELETE FROM Producto WHERE Id = @Id
END