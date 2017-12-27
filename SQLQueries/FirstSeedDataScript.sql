BEGIN TRAN

INSERT INTO [dbo].[Unit] ([Code], [Description]) VALUES ('Szt', 'Sztuki'), ('Kg', 'Kilogramy'), ('Meters', 'Metry')
INSERT INTO [dbo].[Type] ([Code], [Description]) VALUES ('RTV', 'Sprzęt radiowo-telewizyjny'), ('AGD', 'Artykuły gospodarstwa domowego'), ('Others', 'Inne')
INSERT INTO [dbo].[Category] ([Code], [Description]) VALUES ('Man', 'Dla mężczyzn'), ('Woman', 'Dla kobiet'), ('Kids', 'Dla dzieci')

INSERT INTO [dbo].[Product] ([Code], [Description], [Price], [IsAvailable], [DeliveryDate], [TypeId], [UnitId]) VALUES
           ('TV-SAM-46', 'Telewizor Samsung 46 cali', 2499.99, 1, '2018-01-01', 1, 1),
		   ('Zmyw-Bosch', 'Zmywarka Bosch', 1780.11, 0, null, 2, 1),
		   ('SOL-DO-ZMYW', 'Sól do zmywarki', 24, 1, '2017-12-31', 2, 2)

INSERT INTO [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES
		(1,1),
		(2,1),(2,2),(2,3),
		(3,1),(3,2)

COMMIT TRAN