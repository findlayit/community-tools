SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create table [Users] (
	Id int not null primary key identity,
	Username nvarchar(255) not null,
	[Password] nvarchar(255) not null,
	Salt nvarchar(255) not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO
