CREATE DATABASE [Billing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Billing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Billing.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Billing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Billing_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Billing] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [Billing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Billing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Billing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Billing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Billing] SET ARITHABORT OFF 
GO
ALTER DATABASE [Billing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Billing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Billing] SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF)
GO
ALTER DATABASE [Billing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Billing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Billing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Billing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Billing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Billing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Billing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Billing] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Billing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Billing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Billing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Billing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Billing] SET  READ_WRITE 
GO
ALTER DATABASE [Billing] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Billing] SET  MULTI_USER 
GO
ALTER DATABASE [Billing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Billing] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Billing] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Billing]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = On;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = Primary;
GO
USE [Billing]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [Billing] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO

-- CREACION DE TABLAS 
CREATE	TABLE dbo.TypeCustomer
(
	Id			INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	Description	VARCHAR(60)						NOT NULL
)

CREATE	TABLE dbo.Mark
(
	Id			INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	Description	VARCHAR(60)						NOT NULL
)

CREATE	TABLE dbo.TransactionType
(
	Id			INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	Description	VARCHAR(60)						NOT NULL
)

CREATE	TABLE dbo.Customer
(
	Id					INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	IdTypeCustomer		INT								NOT NULL,
	BusinessName		VARCHAR(80)						NOT NULL,
	Nit					INT								NOT NULL,
	Address				VARCHAR(80)						NOT NULL,
	Phone				VARCHAR(18)						NOT NULL,
	State				BIT								NOT NULL,
	RegistrationDate	DATETIME						NOT NULL,
	FOREIGN KEY (IdTypeCustomer) REFERENCES TypeCustomer (Id)
)

CREATE	TABLE dbo.Payment
(
	Id				INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	IdCustomer		INT								NOT NULL,
	Date			DATETIME						NOT NULL,
	NumberPayment	INT								NOT NULL,
	Value			MONEY							NOT NULL,
	FOREIGN KEY (IdCustomer) REFERENCES Customer (Id)
)

CREATE	TABLE dbo.MovementBill
(
	Id					INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	IdCustomer			INT								NOT NULL,
	IdTransactionType	INT								NOT NULL,
	NumberBill			INT								NOT NULL,
	Date				DATETIME						NOT NULL,
	Total				MONEY							NOT NULL,
	SubTotal			MONEY							NOT NULL,
	Iva					MONEY							NOT NULL,
	FOREIGN KEY (IdCustomer) REFERENCES Customer (Id),
	FOREIGN KEY (IdTransactionType) REFERENCES TransactionType (Id)
) 

CREATE	TABLE dbo.Product
(
	Id			INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	IdMark		INT								NOT NULL,
	Description	VARCHAR(80)						NOT NULL,
	Price		MONEY							NOT NULL,
	FOREIGN KEY (IdMark) REFERENCES Mark (Id),
)

CREATE	TABLE dbo.Residue
(
	Id			INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	IdProduct	INT								NOT NULL,
	Stok		MONEY							NOT NULL,
	FOREIGN KEY (IdProduct) REFERENCES Product (Id)
)

CREATE	TABLE dbo.MovementProduct
(
	Id				INT PRIMARY KEY IDENTITY (1,1)	NOT NULL,
	IdMovementBill	INT								NOT NULL,
	IdProduct		INT								NOT NULL,
	Date			DATETIME						NOT NULL,
	Quantity		INT								NOT NULL,
	UnitValue		MONEY							NOT NULL,
	TotalValue		MONEY							NOT NULL,
	FOREIGN KEY (IdMovementBill) REFERENCES MovementBill (Id),
	FOREIGN KEY (IdProduct) REFERENCES Product (Id)
) 

