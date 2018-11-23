use [gdc]
go

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Member') 
    drop table [dbo].[Member] 
go 

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Rule') 
    drop table [dbo].[Rule] 
go 

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Mapping') 
    drop table [dbo].[Mapping] 
go 

create table [dbo].[Member](
	[mNo] int IDENTITY(1,1) not null,
	[mID] varchar(30) not null,
	[mPass] varchar(16) not null,
	[mName] varchar(10) not null,
	[delYn] varchar(1) not null DEFAULT ('N'),
	[regDate] datetime not null DEFAULT (getdate()),
	[modDate] datetime not null DEFAULT (getdate())
)
go

create table [dbo].[Rule] (
	[rNo] int IDENTITY(1,1) not null,
	[rName] varchar(10) not null,
	[rDesc] varchar(200) null,
	[delYn] varchar(1) not null DEFAULT ('N'),
	[regDate] datetime not null DEFAULT (getdate()),
	[modDate] datetime not null DEFAULT (getdate())
)
go

create table [dbo].[Mapping] (
	[rNo] int not null,
	[mNo] int not null
)
go

ALTER TABLE [Member] ADD CONSTRAINT pk_Member PRIMARY KEY CLUSTERED(mNo)
go

ALTER TABLE [Rule] ADD CONSTRAINT pk_Rule PRIMARY KEY CLUSTERED(rNo)
go