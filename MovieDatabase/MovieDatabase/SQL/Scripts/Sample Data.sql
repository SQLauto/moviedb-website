USE [MovieDB]
GO
SET IDENTITY_INSERT [dbo].[Actor] ON 

GO
INSERT [dbo].[Actor] ([ID], [FirstName], [LastName], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (1, N'Paul', N'Rudd', N'chrisbo', CAST(N'2016-04-07 18:10:57.797' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Actor] ([ID], [FirstName], [LastName], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (2, N'Jason', N'Siegel', N'chrisbo', CAST(N'2016-04-07 18:39:52.507' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Actor] ([ID], [FirstName], [LastName], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (3, N'Radha', N'Mitchell', N'chrisbo', CAST(N'2016-04-07 18:46:06.977' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Actor] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

GO
INSERT [dbo].[Movie] ([ID], [Title], [Year], [GenreID], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (2, N'I Love You Man', 2003, 3, N'chrisbo', CAST(N'2016-04-07 18:13:48.150' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Movie] ([ID], [Title], [Year], [GenreID], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (3, N'Silent Hill', 2006, 4, N'chrisbo', CAST(N'2016-04-07 18:43:29.800' AS DateTime), N'chrisbo', CAST(N'2016-04-07 18:44:17.760' AS DateTime), NULL, NULL, 0)
GO
INSERT [dbo].[Movie] ([ID], [Title], [Year], [GenreID], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (4, N'40 Year-Old Virgin', 2005, 3, N'chrisbo', CAST(N'2016-04-07 18:48:50.367' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie_Actor] ON 

GO
INSERT [dbo].[Movie_Actor] ([Id], [ActorID], [MovieID], [AddBy], [AddDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (1, 1, 2, N'chrisbo', CAST(N'2016-04-07 18:17:22.960' AS DateTime), NULL, NULL, 0)
GO
INSERT [dbo].[Movie_Actor] ([Id], [ActorID], [MovieID], [AddBy], [AddDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (2, 2, 2, N'chrisbo', CAST(N'2016-04-07 18:40:29.713' AS DateTime), NULL, NULL, 0)
GO
INSERT [dbo].[Movie_Actor] ([Id], [ActorID], [MovieID], [AddBy], [AddDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (3, 3, 3, N'chrisbo', CAST(N'2016-04-07 18:46:29.750' AS DateTime), NULL, NULL, 0)
GO
INSERT [dbo].[Movie_Actor] ([Id], [ActorID], [MovieID], [AddBy], [AddDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (4, 1, 4, N'chrisbo', CAST(N'2016-04-07 18:49:33.247' AS DateTime), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Movie_Actor] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

GO
INSERT [dbo].[Genre] ([ID], [Name], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (2, N'Adventure', N'chrisbo', CAST(N'2016-04-07 02:11:45.000' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Genre] ([ID], [Name], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (3, N'Comedy', N'chrisbo', CAST(N'2016-04-07 18:13:17.493' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Genre] ([ID], [Name], [AddBy], [AddDate], [UpdateBy], [UpdateDate], [ExpireBy], [ExpireDate], [IsExpired]) VALUES (4, N'Horror', N'chrisbo', CAST(N'2016-04-07 18:42:50.213' AS DateTime), NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
