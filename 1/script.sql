USE [KaoQin]
GO
/****** Object:  Table [dbo].[cardaddr]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cardaddr](
	[cardaddr_jin] [varchar](50) NULL,
	[cardaddr_chu] [varchar](50) NULL,
	[cardaddr_id] [varchar](50) NOT NULL,
 CONSTRAINT [PK_cardaddr] PRIMARY KEY CLUSTERED 
(
	[cardaddr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cardinf]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cardinf](
	[c_name] [nvarchar](50) NULL,
	[c_time] [varchar](50) NULL,
	[c_addr] [varchar](50) NULL,
	[c_id] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[c_status] [varchar](50) NULL,
 CONSTRAINT [PK_cardinf] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chuchai]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chuchai](
	[C_ID] [int] IDENTITY(1,1) NOT NULL,
	[c_number] [varchar](50) NULL,
	[c_name] [varchar](50) NULL,
	[c_startdate] [varchar](50) NOT NULL,
	[c_enddate] [varchar](50) NULL,
	[c_things] [varchar](100) NULL,
 CONSTRAINT [PK_chuchai] PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[gongzuori]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[gongzuori](
	[YearMon] [varchar](50) NOT NULL,
	[gongzuodate] [varchar](350) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_gongzuori] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[jiaban]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[jiaban](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[u_number] [varchar](50) NULL,
	[u_name] [varchar](50) NULL,
	[u_jiatime] [varchar](50) NULL,
	[u_jiadate] [varchar](50) NULL,
 CONSTRAINT [PK_jiaban] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[jinzhitab]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[jinzhitab](
	[jinzhiid] [varchar](50) NOT NULL,
	[status] [varchar](50) NULL,
	[nowtime] [varchar](50) NULL,
 CONSTRAINT [PK_jinzhitab] PRIMARY KEY CLUSTERED 
(
	[jinzhiid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kaohe]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kaohe](
	[k_id] [int] IDENTITY(1,1) NOT NULL,
	[k_number] [varchar](50) NULL,
	[k_name] [varchar](50) NULL,
	[k_jihua] [varchar](600) NULL,
	[k_wancheng] [varchar](800) NULL,
	[k_jieguo] [varchar](50) NULL,
	[k_pingyu] [varchar](400) NULL,
	[k_defen] [varchar](200) NULL,
	[k_statue] [varchar](10) NULL,
	[k_time] [varchar](50) NULL,
 CONSTRAINT [PK_kaohe] PRIMARY KEY CLUSTERED 
(
	[k_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KaoQinCanShu]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KaoQinCanShu](
	[banci] [varchar](50) NOT NULL,
	[time1] [varchar](50) NULL,
	[time2] [varchar](50) NULL,
	[time3] [varchar](50) NULL,
	[time4] [varchar](50) NULL,
	[time5] [varchar](50) NULL,
	[time6] [varchar](50) NULL,
	[xianshi1] [varchar](50) NULL,
	[xianshi2] [varchar](50) NULL,
	[canbu] [varchar](50) NULL,
	[chebu] [varchar](50) NULL,
	[chidao] [varchar](50) NULL,
	[zaotiu] [varchar](50) NULL,
	[queqin] [varchar](50) NULL,
	[ligang] [varchar](50) NULL,
	[nianxiu] [varchar](50) NULL,
	[shijia] [varchar](50) NULL,
	[linshijia] [varchar](50) NULL,
	[bingjia] [varchar](50) NULL,
	[kuanggong] [varchar](50) NULL,
 CONSTRAINT [PK_KaoQinCanShu] PRIMARY KEY CLUSTERED 
(
	[banci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KaoqinName]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KaoqinName](
	[id] [int] NOT NULL,
	[kaoqinName] [varchar](50) NULL,
 CONSTRAINT [PK_KaoqinName] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[Model] [varchar](50) NULL,
	[IP] [varchar](50) NULL,
	[Port] [varchar](50) NULL,
	[location] [varchar](50) NULL,
	[IP_2] [varchar](50) NULL,
	[Port_2] [varchar](50) NULL,
	[addre] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[addre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[permission]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[permission](
	[permname] [varchar](50) NOT NULL,
	[address] [varchar](50) NULL,
 CONSTRAINT [PK_permission_1] PRIMARY KEY CLUSTERED 
(
	[permname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[qingjia]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[qingjia](
	[Q_ID] [int] IDENTITY(1,1) NOT NULL,
	[q_number] [varchar](50) NULL,
	[q_name] [varchar](50) NULL,
	[q_startdate] [varchar](50) NULL,
	[q_enddate] [varchar](50) NULL,
	[q_things] [varchar](200) NULL,
	[q_shixiang] [varchar](50) NULL,
	[q_statue] [varchar](50) NULL,
	[q_all] [varchar](50) NULL,
 CONSTRAINT [PK_qingjia] PRIMARY KEY CLUSTERED 
(
	[Q_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RiJiHua]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RiJiHua](
	[r_id] [int] IDENTITY(1,1) NOT NULL,
	[r_number] [varchar](50) NULL,
	[r_name] [varchar](50) NULL,
	[r_time] [varchar](50) NULL,
	[r_jihua] [varchar](600) NULL,
	[r_mubiao] [varchar](600) NULL,
	[r_gongshi] [varchar](50) NULL,
	[r_neirong] [varchar](600) NULL,
	[r_jieguo] [varchar](600) NULL,
	[r_statue] [varchar](10) NULL,
	[r_pingyu] [varchar](400) NULL,
	[r_defen] [varchar](200) NULL,
 CONSTRAINT [PK_RiJiHua] PRIMARY KEY CLUSTERED 
(
	[r_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShenQingShenBao]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShenQingShenBao](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_number] [varchar](50) NULL,
	[s_name] [varchar](50) NULL,
	[s_time] [varchar](50) NULL,
	[s_leibie] [varchar](50) NULL,
	[s_statue] [varchar](10) NULL,
	[id] [varchar](50) NULL,
 CONSTRAINT [PK_ShenQingShenBao] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table_1](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_number] [varchar](50) NULL,
	[s_name] [varchar](50) NULL,
	[s_time] [varchar](50) NULL,
	[s_leibie] [varchar](50) NULL,
	[s_statue] [varchar](10) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table_2]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table_2](
	[r_id] [int] NOT NULL,
	[r_number] [varchar](50) NULL,
	[r_name] [varchar](50) NULL,
	[r_time] [varchar](50) NULL,
	[r_jihua] [varchar](600) NULL,
	[r_mubiao] [varchar](600) NULL,
	[r_gongshi] [varchar](50) NULL,
	[r_neirong] [varchar](600) NULL,
	[r_jieguo] [varchar](600) NULL,
	[r_statue] [varchar](10) NULL,
	[r_pingyu] [varchar](400) NULL,
	[r_defen] [varchar](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table_3]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table_3](
	[z_number] [varchar](50) NULL,
	[z_name] [varchar](50) NULL,
	[z_time] [varchar](50) NULL,
	[z_jihua] [varchar](600) NULL,
	[z_mubiao] [varchar](600) NULL,
	[z_zhanbi] [varchar](50) NULL,
	[z_shishiqingkuang] [varchar](600) NULL,
	[z_jieguo] [varchar](600) NULL,
	[z_statue] [varchar](10) NULL,
	[z_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Time]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Time](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time1] [varchar](50) NOT NULL,
	[time2] [varchar](50) NULL,
	[time3] [varchar](50) NOT NULL,
	[time4] [varchar](50) NULL,
	[banci] [varchar](50) NULL,
	[minute1] [varchar](50) NULL,
	[minute2] [varchar](50) NULL,
	[minute3] [varchar](50) NULL,
	[minute4] [varchar](50) NULL,
	[chidaozaotui] [varchar](50) NULL,
 CONSTRAINT [PK_Time] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[type] [varchar](50) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[userinfo]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userinfo](
	[cardid1] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[number] [varchar](50) NULL,
	[zaizhi] [varchar](50) NULL,
	[Banci] [varchar](50) NULL,
	[cardid2] [varchar](50) NULL,
	[cardid3] [varchar](50) NULL,
	[shangji] [varchar](50) NULL,
	[kaoqinadmin] [varchar](50) NULL,
	[jibie] [varchar](50) NULL,
	[canbu] [varchar](50) NULL,
	[chebu] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_userinfo_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ZhouJiHua]    Script Date: 2019/12/16 13:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ZhouJiHua](
	[z_id] [int] IDENTITY(1,1) NOT NULL,
	[z_number] [varchar](50) NULL,
	[z_name] [varchar](50) NULL,
	[z_time] [varchar](50) NULL,
	[z_jihua] [varchar](600) NULL,
	[z_mubiao] [varchar](600) NULL,
	[z_zhanbi] [varchar](50) NULL,
	[z_shishiqingkuang] [varchar](600) NULL,
	[z_jieguo] [varchar](600) NULL,
	[z_statue] [varchar](10) NULL,
 CONSTRAINT [PK_ZhouJiHua] PRIMARY KEY CLUSTERED 
(
	[z_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[cardaddr] ([cardaddr_jin], [cardaddr_chu], [cardaddr_id]) VALUES (N'1', N'2', N'1')
SET IDENTITY_INSERT [dbo].[gongzuori] ON 

INSERT [dbo].[gongzuori] ([YearMon], [gongzuodate], [id]) VALUES (N'2019-12', N'2019-12-02,
2019-12-03,
2019-12-04,
2019-12-05,
2019-12-06,
2019-12-09,
2019-12-10,
2019-12-11,
2019-12-12,
2019-12-13,
2019-12-16,
2019-12-17,
2019-12-18,
2019-12-19,
2019-12-20,
2019-12-23,
2019-12-24,
2019-12-25,
2019-12-26,
2019-12-27,
2019-12-30,
2019-12-31,
', 2)
INSERT [dbo].[gongzuori] ([YearMon], [gongzuodate], [id]) VALUES (N'2019-11', N'2019-11-01,
2019-11-04,
2019-11-05,
2019-11-06,
2019-11-07,
2019-11-08,
2019-11-11,
2019-11-12,
2019-11-13,
2019-11-14,
2019-11-15,
2019-11-18,
2019-11-19,
2019-11-20,
2019-11-21,
2019-11-22,
2019-11-25,
2019-11-26,
2019-11-27,
2019-11-28,
2019-11-29,
', 3)
SET IDENTITY_INSERT [dbo].[gongzuori] OFF
SET IDENTITY_INSERT [dbo].[kaohe] ON 

INSERT [dbo].[kaohe] ([k_id], [k_number], [k_name], [k_jihua], [k_wancheng], [k_jieguo], [k_pingyu], [k_defen], [k_statue], [k_time]) VALUES (1, N'123', N'张三', N'2wq3er1', N'wqedr1', NULL, N'', N'', N'0', N'2019-12-12')
SET IDENTITY_INSERT [dbo].[kaohe] OFF
INSERT [dbo].[KaoQinCanShu] ([banci], [time1], [time2], [time3], [time4], [time5], [time6], [xianshi1], [xianshi2], [canbu], [chebu], [chidao], [zaotiu], [queqin], [ligang], [nianxiu], [shijia], [linshijia], [bingjia], [kuanggong]) VALUES (N'班次1', N'09:00', N'12:00', N'01:00', N'18:00', N'18:30', N'21:30', N'3', N'8', N'18:30', N'18:30', N'15', N'15', N'120', N'1', N'0', N'0', N'0.5', N'0', N'2')
SET IDENTITY_INSERT [dbo].[qingjia] ON 

INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (1, N'124', N'李四', N'2019-12-11 09:00', N'2019-12-11 18:00', N'save', N'年假', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (2, N'124', N'李四', N'2019-12-11 09:00', N'2019-12-11 18:00', N'水电费GV', N'事假', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (3, N'124', N'李四', N'2019-12-11 09:00', N'2019-12-11 18:00', N'SD B', N'病假', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (4, N'123', N'张三', N'2019-12-11 09:00', N'2019-12-11 18:00', N'啊', N'加班', N'3', N'5')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (5, N'123', N'张三', N'2019-12-11 09:00', N'2019-12-11 18:00', N'啊', N'加班', N'3', N'5')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (6, N'123', N'张三', N'2019-12-11 09:00', N'2019-12-11 18:00', N'啊', N'加班', N'3', N'5')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (7, N'123', N'张三', N'2019-12-11 09:00', N'2019-12-11 18:00', N'按错', N'临时假', N'3', N'2')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (8, N'123', N'张三', N'2019-12-12 09:00', N'2019-12-12 18:00', N'收到', N'病假', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (9, N'123', N'张三', N'2019-12-12 09:00', N'2019-12-12 18:00', N'edrsf', N'事假', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (10, N'123', N'张三', N'2019-12-12 09:00', N'2019-12-12 18:00', N'谁打副本', N'因公外出', N'3', N'2')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (11, N'123', N'张三', N'2019-12-12 09:00', N'2019-12-12 18:00', N'鄂武商', N'年假', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (12, N'123', N'张三', N'2019-12-12 09:00', N'2019-12-12 18:00', N'按时', N'病假', N'3', N'2')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (13, N'123', N'张三', N'2019-12-12 09:00', N'2019-12-12 18:00', N'sdxb ', N'事假', N'3', N'2')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (14, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'asd', N'因公外出', N'3', N'2')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (15, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'asf', N'因公外出', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (16, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'a', N'因公外出', N'3', N'2')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (17, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'SFC ', N'因公外出', N'3', N'2')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (18, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'S', N'因公外出', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (19, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'A', N'因公外出', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (20, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'a', N'事假', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (21, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'A', N'因公外出', N'3', N'1')
INSERT [dbo].[qingjia] ([Q_ID], [q_number], [q_name], [q_startdate], [q_enddate], [q_things], [q_shixiang], [q_statue], [q_all]) VALUES (22, N'123', N'张三', N'2019-12-13 09:00', N'2019-12-13 18:00', N'a', N'因公外出', N'3', N'1')
SET IDENTITY_INSERT [dbo].[qingjia] OFF
SET IDENTITY_INSERT [dbo].[RiJiHua] ON 

INSERT [dbo].[RiJiHua] ([r_id], [r_number], [r_name], [r_time], [r_jihua], [r_mubiao], [r_gongshi], [r_neirong], [r_jieguo], [r_statue], [r_pingyu], [r_defen]) VALUES (1, N'123', N'张三', N'2019-12-12', N'wesef', N'dfsfd', N'dfs', N'd', N'ds', N'0', N'', N'')
INSERT [dbo].[RiJiHua] ([r_id], [r_number], [r_name], [r_time], [r_jihua], [r_mubiao], [r_gongshi], [r_neirong], [r_jieguo], [r_statue], [r_pingyu], [r_defen]) VALUES (2, N'123', N'张三', N'2019-12-03', N'谁DVD', N'的程序v', N'现代城', N' 程序', N'程序', N'0', N'', N'')
SET IDENTITY_INSERT [dbo].[RiJiHua] OFF
SET IDENTITY_INSERT [dbo].[ShenQingShenBao] ON 

INSERT [dbo].[ShenQingShenBao] ([s_id], [s_number], [s_name], [s_time], [s_leibie], [s_statue], [id]) VALUES (20, N'123', N'张三', N'2019-12-16', N'周计划', N'0', NULL)
SET IDENTITY_INSERT [dbo].[ShenQingShenBao] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([ID], [username], [password], [type]) VALUES (1, N'admin', N' 21232f297a57a5a743894a0e4a801fc3', N'网站')
INSERT [dbo].[user] ([ID], [username], [password], [type]) VALUES (2, N'hr', N' 21232f297a57a5a743894a0e4a801fc3', N'HR')
SET IDENTITY_INSERT [dbo].[user] OFF
SET IDENTITY_INSERT [dbo].[userinfo] ON 

INSERT [dbo].[userinfo] ([cardid1], [name], [number], [zaizhi], [Banci], [cardid2], [cardid3], [shangji], [kaoqinadmin], [jibie], [canbu], [chebu], [password], [id]) VALUES (N'123', N'张三', N'123', N'在职', N'班次1', N'', N'', N'', N'', N'3', N'20', N'20', N' 81dc9bdb52d04dc20036dbd8313ed055', 1)
INSERT [dbo].[userinfo] ([cardid1], [name], [number], [zaizhi], [Banci], [cardid2], [cardid3], [shangji], [kaoqinadmin], [jibie], [canbu], [chebu], [password], [id]) VALUES (N'124', N'李四', N'124', N'在职', N'班次1', N'', N'', N'123', N'123', N'4', N'10', N'10', N' 81dc9bdb52d04dc20036dbd8313ed055', 2)
SET IDENTITY_INSERT [dbo].[userinfo] OFF
SET IDENTITY_INSERT [dbo].[ZhouJiHua] ON 

INSERT [dbo].[ZhouJiHua] ([z_id], [z_number], [z_name], [z_time], [z_jihua], [z_mubiao], [z_zhanbi], [z_shishiqingkuang], [z_jieguo], [z_statue]) VALUES (7, N'123', N'张三', N'2019-12-16', N'a', N'a', N'a', N'a', N'a', N'0')
SET IDENTITY_INSERT [dbo].[ZhouJiHua] OFF
