DROP TABLE IF EXISTS [dbo].[ProductCategory]
DROP TABLE IF EXISTS [dbo].[Product]
DROP TABLE IF EXISTS [dbo].[Category]
DROP TABLE IF EXISTS [dbo].[Unit]
DROP TABLE IF EXISTS [dbo].[Type]


CREATE TABLE [dbo].[Type](
	[TypeId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Code] [varchar](20) NOT NULL UNIQUE,
	[Description] [nvarchar](255) NULL
)

CREATE TABLE [dbo].[Unit](
	[UnitId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Code] [varchar](20) NOT NULL UNIQUE,
	[Description] [nvarchar](255) NULL
)

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Code] [varchar](20) NOT NULL UNIQUE,
	[Description] [nvarchar](255) NULL
)

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Code] [varchar](50) NOT NULL UNIQUE,
	[Description] [nvarchar](500) NULL,
	[Price] DECIMAL(19, 4) NOT NULL,
	[IsAvailable] [bit] NOT NULL DEFAULT 0,
	[DeliveryDate] [datetime] NULL,
	[TypeId] [int] NULL,
	[UnitId] [int] NULL
)
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([TypeId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Type]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Unit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([UnitId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Unit]
GO

CREATE TABLE [dbo].[ProductCategory](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL
	--CONSTRAINT PK_ProductCategory PRIMARY KEY ([ProductId], [CategoryId])
)
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO