USE [UsersAwards]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAwards]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAwards](
	[UserId] [int] NOT NULL,
	[AwardId] [int] NOT NULL,
 CONSTRAINT [PK_UsersAwards_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AwardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Users]
GO
ALTER TABLE [dbo].[UsersAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAwards_Awards1] FOREIGN KEY([AwardId])
REFERENCES [dbo].[Awards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAwards] CHECK CONSTRAINT [FK_UsersAwards_Awards1]
GO
ALTER TABLE [dbo].[UsersAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAwards_Users1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAwards] CHECK CONSTRAINT [FK_UsersAwards_Users1]
GO
/****** Object:  StoredProcedure [dbo].[sp_add_award]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_award] 
	@awardTitle nvarchar(100)
AS
BEGIN
	insert into Awards
	values		(@awardTitle);
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_add_award_to_user]    Script Date: 22.02.2020 18:02:53 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_add_user]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_user]
	@name nvarchar(50),
	@date_of_birth date
AS
BEGIN
	insert into Users
	values		(@name,
				@date_of_birth);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_award]    Script Date: 22.02.2020 18:02:53 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_delete_award_from_user]    Script Date: 22.02.2020 18:02:53 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_delete_user]    Script Date: 22.02.2020 18:02:53 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_get_awards_of_user]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_get_awards_of_user] 
	@userId int
AS
BEGIN
select distinct [Awards].[Title] as Award  from [dbo].[Users]
	join [dbo].[UsersAwards] on @userId = [dbo].[UsersAwards].[UserId]
	join [dbo].[Awards] on Awards.Id = [dbo].[UsersAwards].[AwardId]
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_getall_awards]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_getall_awards] AS
BEGIN
	select top(1000) [Id],[Title]
	from [dbo].[Awards]
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_getall_users]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_getall_users] AS
BEGIN
	select top(1000) [Id],[Name],[DateOfBirth]
	from [dbo].[Users]
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_update_award]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_award]
	@id int,
	@title nvarchar(100)
AS
BEGIN
	if(@title is not null)
	begin
		update Awards
		set Title = @title
		where id = @id
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_update_user]    Script Date: 22.02.2020 18:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_user]
	@id int,
	@name nvarchar(50),
	@date_of_birth date
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
END
GO
