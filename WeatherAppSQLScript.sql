USE [WeatherAppTask]
GO
/****** Object:  Table [dbo].[Sehirler]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sehirler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sehir_adi] [varchar](50) NULL,
 CONSTRAINT [PK_Sehirler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SehirGetir]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[SehirGetir]
as
Select * from Sehirler
GO
/****** Object:  UserDefinedFunction [dbo].[SehirIdGore]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[SehirIdGore]
(@sehirId int)
returns Table
as RETURN 
(select * from Sehirler where id = @sehirId)
GO
/****** Object:  Table [dbo].[SehirlerHavaDurumlari]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SehirlerHavaDurumlari](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sehir_id] [int] NULL,
	[tarih] [datetime] NULL,
	[durum] [varchar](250) NULL,
	[mak] [int] NULL,
	[kayit_tarihi] [datetime] NULL,
 CONSTRAINT [PK_SehirlerHavaDurumlari] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[SehirHavaDurumuIdGore]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[SehirHavaDurumuIdGore]
(@sehirId int)
returns Table
as RETURN 
(select * from SehirlerHavaDurumlari where sehir_id = @sehirId)
GO
/****** Object:  StoredProcedure [dbo].[spHavaDurumuSifirlama]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[spHavaDurumuSifirlama]
--(
--@SehirAdi varchar(50)
--)
As 
Begin 
     delete from SehirlerHavaDurumlari
End


GO
/****** Object:  StoredProcedure [dbo].[spYeniKayitEkle]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[spYeniKayitEkle]
(
@Sehir_id int,
@Tarih datetime,
@Durum varchar(250),
@Mak int,
@KayitTarihi datetime
)
As 
Begin 
     insert into SehirlerHavaDurumlari (sehir_id, tarih, durum, mak, kayit_tarihi) values (@Sehir_id, @Tarih, @Durum, @Mak, @KayitTarihi)
End


GO
/****** Object:  StoredProcedure [dbo].[spYeniKayitEkleSehir]    Script Date: 02.10.2021 18:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[spYeniKayitEkleSehir]
(
@SehirAdi varchar(50)
)
As 
Begin 
     insert into Sehirler (sehir_adi) values (@SehirAdi)
End


GO
