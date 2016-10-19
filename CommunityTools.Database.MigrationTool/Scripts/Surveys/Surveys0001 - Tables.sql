SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create table [Survey] (
	Id int not null primary key identity,
	Title nvarchar(255),
	UrlName nvarchar(300),
	Description nvarchar(max),
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO

create table [QuestionAnswer] (
	Id int not null primary key identity,
	Description nvarchar(255),
	AnswerType int not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO

create table [QuestionAnswerOption] (
	Id int not null primary key identity,
	QuestionAnswerId int not null,
	Idx int not null,
	OptionText nvarchar(255) not null,
	OptionValue int not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO

alter table [QuestionAnswerOption] add constraint FK_QuestionAnswerOption_QuestionAnswerId foreign key (QuestionAnswerId) references QuestionAnswer(Id);
GO

create table [Question] (
	Id int not null primary key identity,
	SurveyId int not null,
	Idx int not null,
	QuestionText nvarchar(4000),
	QuestionAnswerId int not null,
	CreatedBy int not null,
	CreatedDateTime datetime2 not null,
	IsDeleted bit not null DEFAULT(0)
);
GO

alter table [Question] add constraint FK_Question_QuestionAnswerId foreign key (QuestionAnswerId) references QuestionAnswer(Id);
GO
alter table [Question] add constraint FK_Question_SurveyId foreign key (SurveyId) references Survey(Id);
GO
