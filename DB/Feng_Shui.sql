USE [IchiPaint]
GO
/****** Object:  Table [dbo].[Feng_Shui]    Script Date: 29/05/2018 12:13:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feng_Shui](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[YearOfBirthDay] [numeric](4, 0) NULL,
	[Ten] [nvarchar](200) NULL,
	[MauTuongSinh] [nvarchar](max) NULL,
	[MauTuongKhac] [nvarchar](max) NULL,
 CONSTRAINT [PK_Feng_Shui] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Feng_Shui] ON 

INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1948 AS Numeric(4, 0)), N'Tích Lịch Hỏa (Lửa sấm sét)
', N'NULNên sử dụng tông màu đỏ, hồng, tím, ngoài ra kết hợp với các màu xanh (Thanh mộc sinh Hỏa). 
L', N'Tránh dùng những tông màu đen, màu xanh biển sẫm (nước đen khắc Hỏa).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(1950 AS Numeric(4, 0)), N'Tùng bách mộc (Cây tùng bách)
', N'Nên sử dụng tông màu xanh, ngoài ra kết hợp với tông màu đen, xanh biển sẫm (nước đen sinh Mộc).
', N' Nên tránh dùng những tông màu trắng và sắc ánh kim (Trắng bạch kim khắc Mộc).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(1952 AS Numeric(4, 0)), N'Trường lưu thủy (Giòng nước lớn)
', N'Nên sử dụng tông màu đen, màu xanh biển sẫm, ngoài ra kết hợp với các tông màu trắng và những sắc ánh kim (Trắng bạch kim sinh Thủy).
', N' Nên tránh dùng những màu sắc kiêng kỵ như màu vàng đất, màu nâu (Hoàng thổ khắc Thủy)
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(1954 AS Numeric(4, 0)), N'Sa trung kim (Vàng trong cát)
', N'Nên sử dụng tông màu sáng và những sắc ánh kim vì màu trắng là màu sở hữu của bản mệnh, ngoài ra kết hợp với các tông màu nâu, màu vàng vì đây là những màu sắc sinh vượng (Hoàng Thổ sinh Kim). Những màu này luôn đem lại niềm vui, sự may mắn cho gia chủ. 
', N'Tuy nhiên gia chủ phải tránh những màu sắc kiêng kỵ như màu hồng, màu đỏ, màu tím (Hồng Hỏa khắc Kim).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(1956 AS Numeric(4, 0)), N'Sơn hạ hỏa (Lửa dưới chân núi)
', N'Nên sử dụng tông màu đỏ, hồng, tím, ngoài ra kết hợp với các màu xanh (Thanh mộc sinh Hỏa). 
', N'Tránh dùng những tông màu đen, màu xanh biển sẫm (nước đen khắc Hỏa).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(1958 AS Numeric(4, 0)), N'Bình địa mộc (Cây ở đồng bằng)
', N'Nên sử dụng tông màu xanh, ngoài ra kết hợp với tông màu đen, xanh biển sẫm (nước đen sinh Mộc).
', N' Nên tránh dùng những tông màu trắng và sắc ánh kim (Trắng bạch kim khắc Mộc).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(1960 AS Numeric(4, 0)), N'Bích thượng thổ (Đất trên vách)
', N'Gia chủ mệnh Thổ nên sử dụng tông màu vàng đất, màu nâu, ngoài ra có thể kết hợp với màu hồng, màu đỏ, màu tím (Hồng hỏa sinh Thổ). 
', N'Màu xanh là màu sắc kiêng kỵ mà gia chủ nên tránh dùng (Thanh mộc khắc Thổ).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(1962 AS Numeric(4, 0)), N'Kim bạch kim (Vàng pha bạch kim)
', N'Nên sử dụng tông màu sáng và những sắc ánh kim vì màu trắng là màu sở hữu của bản mệnh, ngoài ra kết hợp với các tông màu nâu, màu vàng vì đây là những màu sắc sinh vượng (Hoàng Thổ sinh Kim). Những màu này luôn đem lại niềm vui, sự may mắn cho gia chủ. 
', N'Tuy nhiên gia chủ phải tránh những màu sắc kiêng kỵ như màu hồng, màu đỏ, màu tím (Hồng Hỏa khắc Kim).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(1964 AS Numeric(4, 0)), N'Hú đăng hỏa (Lửa ngọn đèn)
', N'Nên sử dụng tông màu đỏ, hồng, tím, ngoài ra kết hợp với các màu xanh (Thanh mộc sinh Hỏa). 
', N'Tránh dùng những tông màu đen, màu xanh biển sẫm (nước đen khắc Hỏa).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(1966 AS Numeric(4, 0)), N'Thiên hà thủy (Nước trên trời)
', N'Nên sử dụng tông màu đen, màu xanh biển sẫm, ngoài ra kết hợp với các tông màu trắng và những sắc ánh kim (Trắng bạch kim sinh Thủy).
', N' Nên tránh dùng những màu sắc kiêng kỵ như màu vàng đất, màu nâu (Hoàng thổ khắc Thủy)
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(1968 AS Numeric(4, 0)), N'Đại dịch thổ (Đất thuộc 1 khu lớn)
', N'Gia chủ mệnh Thổ nên sử dụng tông màu vàng đất, màu nâu, ngoài ra có thể kết hợp với màu hồng, màu đỏ, màu tím (Hồng hỏa sinh Thổ). 
', N'Màu xanh là màu sắc kiêng kỵ mà gia chủ nên tránh dùng (Thanh mộc khắc Thổ).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(1970 AS Numeric(4, 0)), N'Thoa xuyến kim (Vàng trang sức)
', N'Nên sử dụng tông màu sáng và những sắc ánh kim vì màu trắng là màu sở hữu của bản mệnh, ngoài ra kết hợp với các tông màu nâu, màu vàng vì đây là những màu sắc sinh vượng (Hoàng Thổ sinh Kim). Những màu này luôn đem lại niềm vui, sự may mắn cho gia chủ. 
', N'Tuy nhiên gia chủ phải tránh những màu sắc kiêng kỵ như màu hồng, màu đỏ, màu tím (Hồng Hỏa khắc Kim).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(1972 AS Numeric(4, 0)), N'Tang đố mộc (Gỗ cây dâu)
', N'Nên sử dụng tông màu xanh, ngoài ra kết hợp với tông màu đen, xanh biển sẫm (nước đen sinh Mộc).
', N' Nên tránh dùng những tông màu trắng và sắc ánh kim (Trắng bạch kim khắc Mộc).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(1974 AS Numeric(4, 0)), N' Đại khê thủy (Nước dưới khe lớn)
', N'Nên sử dụng tông màu đen, màu xanh biển sẫm, ngoài ra kết hợp với các tông màu trắng và những sắc ánh kim (Trắng bạch kim sinh Thủy).
', N' Nên tránh dùng những màu sắc kiêng kỵ như màu vàng đất, màu nâu (Hoàng thổ khắc Thủy)
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(15 AS Numeric(18, 0)), CAST(1976 AS Numeric(4, 0)), N'Sa trung thổ (Đất lẫn trong cát)
', N'Gia chủ mệnh Thổ nên sử dụng tông màu vàng đất, màu nâu, ngoài ra có thể kết hợp với màu hồng, màu đỏ, màu tím (Hồng hỏa sinh Thổ). 
', N'Màu xanh là màu sắc kiêng kỵ mà gia chủ nên tránh dùng (Thanh mộc khắc Thổ).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(16 AS Numeric(18, 0)), CAST(1978 AS Numeric(4, 0)), N'Thiên thượng hỏa (Lửa trên trời)
', N'Nên sử dụng tông màu đỏ, hồng, tím, ngoài ra kết hợp với các màu xanh (Thanh mộc sinh Hỏa). 
', N'Tránh dùng những tông màu đen, màu xanh biển sẫm (nước đen khắc Hỏa).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(17 AS Numeric(18, 0)), CAST(1980 AS Numeric(4, 0)), N'Thạch lựu mộc (Cây thạch lựu)
', N'Nên sử dụng tông màu xanh, ngoài ra kết hợp với tông màu đen, xanh biển sẫm (nước đen sinh Mộc).
', N' Nên tránh dùng những tông màu trắng và sắc ánh kim (Trắng bạch kim khắc Mộc).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(18 AS Numeric(18, 0)), CAST(1982 AS Numeric(4, 0)), N'Đại hải thủy (Nước đại dương)
', N'Nên sử dụng tông màu đen, màu xanh biển sẫm, ngoài ra kết hợp với các tông màu trắng và những sắc ánh kim (Trắng bạch kim sinh Thủy).
', N' Nên tránh dùng những màu sắc kiêng kỵ như màu vàng đất, màu nâu (Hoàng thổ khắc Thủy)
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(19 AS Numeric(18, 0)), CAST(1984 AS Numeric(4, 0)), N'Hải trung kim (Vàng dưới biển)
', N'Nên sử dụng tông màu sáng và những sắc ánh kim vì màu trắng là màu sở hữu của bản mệnh, ngoài ra kết hợp với các tông màu nâu, màu vàng vì đây là những màu sắc sinh vượng (Hoàng Thổ sinh Kim). Những màu này luôn đem lại niềm vui, sự may mắn cho gia chủ. 
', N'Tuy nhiên gia chủ phải tránh những màu sắc kiêng kỵ như màu hồng, màu đỏ, màu tím (Hồng Hỏa khắc Kim).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(20 AS Numeric(18, 0)), CAST(1986 AS Numeric(4, 0)), N'Lộ trung hỏa (Lửa trong lò)
', N'Nên sử dụng tông màu đỏ, hồng, tím, ngoài ra kết hợp với các màu xanh (Thanh mộc sinh Hỏa). 
', N'Tránh dùng những tông màu đen, màu xanh biển sẫm (nước đen khắc Hỏa).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(21 AS Numeric(18, 0)), CAST(1988 AS Numeric(4, 0)), N'Đại lâm mộc (Cây trong rừng lớn)
', N'Nên sử dụng tông màu xanh, ngoài ra kết hợp với tông màu đen, xanh biển sẫm (nước đen sinh Mộc).
', N'Nên tránh dùng những tông màu trắng và sắc ánh kim (Trắng bạch kim khắc Mộc).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(22 AS Numeric(18, 0)), CAST(1990 AS Numeric(4, 0)), N'Lộ bàng thổ (Đất giữa đường)
', N'Gia chủ mệnh Thổ nên sử dụng tông màu vàng đất, màu nâu, ngoài ra có thể kết hợp với màu hồng, màu đỏ, màu tím (Hồng hỏa sinh Thổ). 
', N'Màu xanh là màu sắc kiêng kỵ mà gia chủ nên tránh dùng (Thanh mộc khắc Thổ).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(1992 AS Numeric(4, 0)), N'Kiếm phong kim (Vàng đầu mũi kiếm)
', N'Nên sử dụng tông màu sáng và những sắc ánh kim vì màu trắng là màu sở hữu của bản mệnh, ngoài ra kết hợp với các tông màu nâu, màu vàng vì đây là những màu sắc sinh vượng (Hoàng Thổ sinh Kim). Những màu này luôn đem lại niềm vui, sự may mắn cho gia chủ. 
', N'Tuy nhiên gia chủ phải tránh những màu sắc kiêng kỵ như màu hồng, màu đỏ, màu tím (Hồng Hỏa khắc Kim).')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(24 AS Numeric(18, 0)), CAST(1994 AS Numeric(4, 0)), N'Sơn đầu hỏa (Lửa trên núi)
', N'Nên sử dụng tông màu đỏ, hồng, tím, ngoài ra kết hợp với các màu xanh (Thanh mộc sinh Hỏa). 
', N'Tránh dùng những tông màu đen, màu xanh biển sẫm (nước đen khắc Hỏa).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(25 AS Numeric(18, 0)), CAST(1996 AS Numeric(4, 0)), N'Giản hạ thủy (Nước dưới khe)
', N'Nên sử dụng tông màu đen, màu xanh biển sẫm, ngoài ra kết hợp với các tông màu trắng và những sắc ánh kim (Trắng bạch kim sinh Thủy).
', N' Nên tránh dùng những màu sắc kiêng kỵ như màu vàng đất, màu nâu (Hoàng thổ khắc Thủy)
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(26 AS Numeric(18, 0)), CAST(1998 AS Numeric(4, 0)), N'Thành đầu thổ (Đất trên thành)
', N'Gia chủ mệnh Thổ nên sử dụng tông màu vàng đất, màu nâu, ngoài ra có thể kết hợp với màu hồng, màu đỏ, màu tím (Hồng hỏa sinh Thổ). 
', N'Màu xanh là màu sắc kiêng kỵ mà gia chủ nên tránh dùng (Thanh mộc khắc Thổ).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(27 AS Numeric(18, 0)), CAST(2000 AS Numeric(4, 0)), N'Bạch lạp kim (Vàng trong nến rắn)
', N'Nên sử dụng tông màu sáng và những sắc ánh kim vì màu trắng là màu sở hữu của bản mệnh, ngoài ra kết hợp với các tông màu nâu, màu vàng vì đây là những màu sắc sinh vượng (Hoàng Thổ sinh Kim). Những màu này luôn đem lại niềm vui, sự may mắn cho gia chủ. 
', N'Tuy nhiên gia chủ phải tránh những màu sắc kiêng kỵ như màu hồng, màu đỏ, màu tím (Hồng Hỏa khắc Kim).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(28 AS Numeric(18, 0)), CAST(2002 AS Numeric(4, 0)), N'Dương liễu mộc (Cây dương liễu)
', N'Nên sử dụng tông màu xanh, ngoài ra kết hợp với tông màu đen, xanh biển sẫm (nước đen sinh Mộc).
', N' Nên tránh dùng những tông màu trắng và sắc ánh kim (Trắng bạch kim khắc Mộc).
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(29 AS Numeric(18, 0)), CAST(2004 AS Numeric(4, 0)), N'Tuyền trung thủy (Dưới giữa dòng suối)
', N'Nên sử dụng tông màu đen, màu xanh biển sẫm, ngoài ra kết hợp với các tông màu trắng và những sắc ánh kim (Trắng bạch kim sinh Thủy).
', N'Nên tránh dùng những màu sắc kiêng kỵ như màu vàng đất, màu nâu (Hoàng thổ khắc Thủy)
')
INSERT [dbo].[Feng_Shui] ([Id], [YearOfBirthDay], [Ten], [MauTuongSinh], [MauTuongKhac]) VALUES (CAST(30 AS Numeric(18, 0)), CAST(2006 AS Numeric(4, 0)), N'Ốc thượng thổ (Đất trên nóc nhà)
', N'Gia chủ mệnh Thổ nên sử dụng tông màu vàng đất, màu nâu, ngoài ra có thể kết hợp với màu hồng, màu đỏ, màu tím (Hồng hỏa sinh Thổ). 
', N'Màu xanh là màu sắc kiêng kỵ mà gia chủ nên tránh dùng (Thanh mộc khắc Thổ).
')
SET IDENTITY_INSERT [dbo].[Feng_Shui] OFF
