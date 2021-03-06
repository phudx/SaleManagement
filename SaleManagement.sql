USE [SaleManagement]
GO
/****** Object:  Table [dbo].[RevenueExpenditure]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevenueExpenditure](
	[ReID] [int] IDENTITY(1,1) NOT NULL,
	[ReContent] [nvarchar](1) NULL,
	[DateCreate] [date] NULL,
	[Money] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provider](
	[ProviderID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderName] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[Mobile] [varchar](20) NULL,
	[BankNumber] [varchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](500) NULL,
	[CategoryID] [int] NULL,
	[ProviderID] [int] NULL,
	[Unit] [nvarchar](500) NULL,
	[Producer] [nvarchar](500) NULL,
	[Expiry] [date] NULL,
	[Price] [bigint] NULL,
	[Number] [int] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NULL,
	[Pass] [varchar](50) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([UserID], [UserName], [Pass], [RoleId]) VALUES (1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1)
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[InvoiceImport]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InvoiceImport](
	[InvoiceImportCode] [varchar](10) NOT NULL,
	[ProviderCode] [varchar](10) NULL,
	[DateImport] [date] NULL,
	[TotalMoney] [int] NULL,
	[EmployeeCode] [varchar](10) NULL,
	[VAT] [int] NULL,
	[Note] [nvarchar](500) NULL,
	[StatusInvoice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceImportCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceExport]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InvoiceExport](
	[InvoiceExportCode] [varchar](10) NOT NULL,
	[CustomerCode] [varchar](10) NULL,
	[DateExport] [date] NULL,
	[TotalMoney] [int] NULL,
	[EmployeeCode] [varchar](10) NULL,
	[VAT] [int] NULL,
	[Note] [nvarchar](500) NULL,
	[StatusInvoice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceExportCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceCode] [varchar](10) NOT NULL,
	[ProductCode] [varchar](10) NOT NULL,
	[Number] [int] NULL,
	[Price] [int] NULL,
	[Note] [nvarchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Group] ON
INSERT [dbo].[Group] ([Id], [GroupName]) VALUES (1, N'Vùng Lục Ngạn')
INSERT [dbo].[Group] ([Id], [GroupName]) VALUES (2, N'Vùng Sơn Động')
INSERT [dbo].[Group] ([Id], [GroupName]) VALUES (3, N'Phía Bắc')
INSERT [dbo].[Group] ([Id], [GroupName]) VALUES (4, N'Phía Nam')
SET IDENTITY_INSERT [dbo].[Group] OFF
/****** Object:  Table [dbo].[Employee]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](500) NULL,
	[Position] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [varchar](20) NULL,
	[BirthDate] [datetime] NULL,
	[Sex] [bit] NULL,
	[UserID] [int] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[GroupID] [int] NULL,
	[Phone] [varchar](50) NULL,
	[Note] [nvarchar](500) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (1, N'Bánh mỳ')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (2, N'Nước ngọt')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[StatusInvoice]    Script Date: 03/06/2017 00:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusInvoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusInvoiceName] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Product_GetAllProduct]    Script Date: 03/06/2017 00:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Product_GetAllProduct]
(
		@ProductName NVARCHAR(500),
		@CategoryId  INT
)
AS
BEGIN
	SELECT p.ProductCode,
				 p.ProductName,
				 pd.ProviderName,
				 c.CategoryName,
				 p.Unit,
				 p.Producer,
				 p.Expiry,
				 p.Price,
         p.Number 
	FROM Product p INNER JOIN Provider pd ON p.ProviderCode=pd.ProviderCode
								 INNER JOIN Category c  ON c.Id=p.CategoryId
	WHERE p.Status=1
				AND (@ProductName='' OR p.ProductName LIKE N'%'+@ProductName+'%')
				AND (@CategoryId=0 OR p.CategoryId = @CategoryId)	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Product_Delete]    Script Date: 03/06/2017 00:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Product_Delete]
(
	@ProductCode  VARCHAR(10)
)
AS
BEGIN
  UPDATE Product
	SET Status=0
	WHERE ProductCode=@ProductCode
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Login_LoginUser]    Script Date: 03/06/2017 00:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Login_LoginUser]
(
@UserName VARCHAR(20),
@Pass 		VARCHAR(36)
)
AS
BEGIN
	SELECT l.UserName,l.RoleId,e.EmployeeName
	FROM Login l LEFT JOIN Employee e ON l.UserId=e.UserId
	WHERE l.UserName=@UserName AND
l.Pass=@Pass
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_InsertOrUpdate]    Script Date: 03/06/2017 00:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_InsertOrUpdate]
(
@CustomerCode VARCHAR(10),
@CustomerName VARCHAR(500),
@Address 			VARCHAR(500),
@Phone 				VARCHAR(15),
@GroupId 			INT,
@Note 				VARCHAR(500)
)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Customer WHERE CustomerCode=@CustomerCode)
--UPDATE
		BEGIN
			UPDATE Customer
			SET CustomerName=@CustomerName,
					Address=@Address,
					Phone=@Phone,
					GroupId=@GroupId,
					Note=@Note
			WHERE CustomerCode=@CustomerCode;
		END
		ELSE
--INSERT
		BEGIN
			INSERT INTO Customer(CustomerCode,CustomerName,Address,Phone,GroupId,Note,Status)
			VALUES(@CustomerCode,@CustomerName,@Address,@Phone,@GroupId,@Note,1);
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_GetCustomerCode]    Script Date: 03/06/2017 00:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_GetCustomerCode]
AS
BEGIN
SELECT  TOP 1 CONVERT(INT, SUBSTRING(CustomerCode, 3, 10))+1 AS STTNext
FROM Customer 
ORDER BY Customer.CustomerCode DESC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_GetAllCustomer]    Script Date: 03/06/2017 00:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_GetAllCustomer]
AS
BEGIN
SELECT  c.CustomerCode,
				c.CustomerName,
				c.Address,
				c.Phone,
				ISNULL(g.GroupName,'Khác') AS GroupName,
				c.Note
FROM Customer c LEFT JOIN [Group] g ON g.Id=c.GroupId
WHERE c.Status=1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_Delete]    Script Date: 03/06/2017 00:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_Delete]
(
	@CustomerCode  VARCHAR(10)
)
AS
BEGIN
UPDATE Customer
SET Status=0
WHERE CustomerCode=@CustomerCode
END
GO
/****** Object:  Default [DF__InvoiceEx__DateE__2F10007B]    Script Date: 03/06/2017 00:52:14 ******/
ALTER TABLE [dbo].[InvoiceExport] ADD  DEFAULT (getdate()) FOR [DateExport]
GO
/****** Object:  Default [DF__InvoiceIm__DateI__300424B4]    Script Date: 03/06/2017 00:52:14 ******/
ALTER TABLE [dbo].[InvoiceImport] ADD  DEFAULT (getdate()) FOR [DateImport]
GO
