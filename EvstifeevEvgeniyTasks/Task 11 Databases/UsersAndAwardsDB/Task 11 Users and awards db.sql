USE [UsersAwards]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Image_link] [nvarchar](100) NULL,
 CONSTRAINT [PK_Awards_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Image_link] [nvarchar](100) NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAwards]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAwards](
	[UserId] [int] NOT NULL,
	[AwardId] [int] NOT NULL,
 CONSTRAINT [PK_UsersAwards] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AwardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UsersAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAwards_Awards] FOREIGN KEY([AwardId])
REFERENCES [dbo].[Awards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAwards] CHECK CONSTRAINT [FK_UsersAwards_Awards]
GO
ALTER TABLE [dbo].[UsersAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAwards_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAwards] CHECK CONSTRAINT [FK_UsersAwards_Users]
GO
/****** Object:  StoredProcedure [dbo].[sp_add_award]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_award] 
	@awardTitle nvarchar(100),
	@image_link nvarchar(100)
AS
BEGIN
	if(@awardTitle is not null)
	insert into Awards
	values		(@awardTitle, @image_link);
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_add_award_to_user]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_award_to_user] 
	@user_id int,
	@award_id int
AS
BEGIN
	if (exists(select id from Users where  id = @user_id) and exists(select id from Awards where  id = @award_id)
	and not exists(select Awardid, UserId from UsersAwards where Awardid = @award_id and UserId = @user_id))
		begin
			insert into dbo.UsersAwards
			values		(@user_id,@award_id);
		end
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_add_user]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_user]
	@name nvarchar(50),
	@date_of_birth date,
	@image_link nvarchar(100)
AS
BEGIN
	if (@name is not null and @date_of_birth is not null)
	insert into Users
	values		(@name,
				@date_of_birth,
				@image_link);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_award]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_award]
	@id int
AS
BEGIN
	delete from Awards
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_award_from_user]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_award_from_user]
	@user_id int,
	@award_id int
AS
BEGIN
	delete from UsersAwards
	where Userid = @user_id 
	and AwardId = @award_id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_user]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_user]
	@id int
AS
BEGIN
	delete from Users
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_awards_of_user]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_awards_of_user] 
	@userId int
AS
BEGIN
select distinct Awards.[Id], Awards.Title, Awards.Image_link from [dbo].[Users]
	join [dbo].[UsersAwards] on @userId = [dbo].[UsersAwards].[UserId]
	join [dbo].[Awards] on Awards.Id = [dbo].[UsersAwards].[AwardId]
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_get_by_id_award]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_by_id_award] 
	@id int
AS
BEGIN
select Awards.[Id],Title,[Image_Link]  as ImageLink
	from [dbo].Awards where Awards.Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_get_by_id_user]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_by_id_user] 
	@id int
AS
BEGIN
select [Users].[Id],[Users].[Name],[DateOfBirth],[Image_Link]  as ImageLink
	from [dbo].[Users] where Users.Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_getall_awards]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getall_awards] AS
BEGIN
	select [Id],[Title],[Image_link] as ImageLink
	from [dbo].[Awards]
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_getall_users]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getall_users] AS
BEGIN
	select [Users].[Id],[Users].[Name],[DateOfBirth], [Image_Link] as ImageLink
	from [dbo].[Users]
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_update_award]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_award]
	@id int,
	@title nvarchar(100),
	@image_link nvarchar(100)
AS
BEGIN
	if(@title is not null)
	begin
		update Awards
		set Title = @title
		where id = @id
	end
	if(@image_link is not null)
	begin
		update Awards
		set Image_link = @image_link
		where id = @id
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_update_user]    Script Date: 23.02.2020 18:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_user]
	@id int,
	@name nvarchar(50),
	@date_of_birth date,
	@image_link nvarchar(100)
AS
BEGIN
	if(@name is not null)
		begin
		update Users
		set Name = @name where id=@id
		end
	if(@date_of_birth is not null)
		begin
		update Users
		set DateOfBirth = @date_of_birth where id=@id
		end
	if(@image_link is not null)
		begin
		update Users
		set Image_link = @image_link where id=@id
		end
END
GO
