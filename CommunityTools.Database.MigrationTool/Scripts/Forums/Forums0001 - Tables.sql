SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create table ForumGroup (
	Id int not null primary key identity,
	Title nvarchar(255) not null,
	UrlName nvarchar(255) not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO

create table Forum (
	Id int not null primary key identity,
	Title nvarchar(255) not null,
	UrlName nvarchar(255) not null,
	ForumGroupId int not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO

create table ForumThread (
	Id int not null primary key identity,
	Title nvarchar(255) not null,
	UrlName nvarchar(255) not null,
	ForumId int not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO

create table ForumPost (
	Id int not null primary key identity,
	Title nvarchar(255) not null,
	Content nvarchar(max) not null,
	UrlName nvarchar(255) not null,
	ForumThreadId int not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO
