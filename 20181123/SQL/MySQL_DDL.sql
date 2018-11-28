use test;

create table Member(
	mNo int not null AUTO_INCREMENT,
	mID varchar(30) not null,
	mPass varchar(16) not null,
	mName varchar(10) not null,
	delYn varchar(1) not null DEFAULT 'N',
	regDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	modDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`mNo`)
)
;

create table Rule (
	rNo int not null AUTO_INCREMENT,
	rName varchar(10) not null,
	rDesc varchar(200) null,
	delYn varchar(1) not null DEFAULT 'N',
	regDate TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP,
	modDate TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`rNo`)
)
;

create table Mapping (
	rNo int not null,
	mNo int not null
)
;

CREATE TABLE RuleView(
	rvNo int NOT NULL AUTO_INCREMENT,
	rNo int NOT NULL,
	vNo int NOT NULL,
	delYn varchar(1) not null DEFAULT 'N',
	regDate datetime not null DEFAULT CURRENT_TIMESTAMP,
	modDate datetime not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`rvNo`)
)
;

CREATE TABLE View(
	vNo int NOT NULL AUTO_INCREMENT,
	vName varchar(10) NOT NULL,
	vDesc varchar(200) NULL,
	vType varchar(1) NOT NULL,
	sizeX int NULL,
	sizeY int NULL,
	pointX int NULL,
	pointY int NULL,
	color int NULL,
	delYn varchar(1) not null DEFAULT 'N',
	regDate datetime not null DEFAULT CURRENT_TIMESTAMP,
	modDate datetime not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`vNo`)
);

CREATE TABLE ViewControl(
	vcNo int NOT NULL AUTO_INCREMENT,
	vNo int NOT NULL,
	uvcName varchar(20) NULL,
	vcType varchar(20) NOT NULL,
	vcName varchar(10) NOT NULL,
	vcText varchar(10) NULL,
	width int NULL,
	height int NULL,
	sizeX int NULL,
	sizeY int NULL,
	pointX int NULL,
	pointY int NULL,
	color int NULL,
	event int NULL,
	delYn varchar(1) not null DEFAULT 'N',
	regDate datetime not null DEFAULT CURRENT_TIMESTAMP,
	modDate datetime not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`vcNo`)
);