--Database Script for Online Testing System (OTS)

IF DB_ID('OTS') IS NOT NULL
	DROP DATABASE OTS
GO

CREATE DATABASE OTS
GO 

USE OTS
GO


CREATE TABLE Users(
	UserID int identity,
	constraint Users_UserID_PK PRIMARY KEY (UserID),
	UserPassword varchar(8) NOT NULL,
	UserFirstName varchar(30) NOT NULL,
	UserLastName varchar(30) NOT NULL,
	UserEmail varchar(50) NOT NULL
);
GO

CREATE TABLE Disciplines(
	DisciplineID int identity,
	constraint DisciplineID_PK PRIMARY KEY (DisciplineID),
	DisciplineName varchar(50) NOT NULL
);
GO

CREATE TABLE DisciplineDetail(
	DetailID int identity,
	constraint DetailID_PK PRIMARY KEY (DetailID),
	UserID int,
	constraint DisciplineDetail_UserID_FK FOREIGN KEY (UserID)
		References Users(UserID),
	DisciplineID int,
	constraint DisciplineDetail_DisciplineID_FK FOREIGN KEY (DisciplineID)
		References Disciplines(DisciplineID)
);
GO

CREATE TABLE Test(
	TestID int identity,
	constraint TestID_PK PRIMARY KEY (TestID), 
	DisciplineID int,
	UserID int, 
	constraint Test_DisciplineID_FK FOREIGN KEY (DisciplineID)
		References Disciplines(DisciplineID),
	constraint Test_UserID_FK FOREIGN KEY (UserID)
		References Users(UserID)
);
GO

CREATE TABLE Results(
	SerialNo int identity,
	constraint Results_SerialNo_PK PRIMARY KEY (SerialNo),
	UserID int,
	constraint Results_UserID_FK FOREIGN KEY (UserID)
		References Users(UserID),
	TestID int,
	constraint Results_TestID_FK FOREIGN KEY (TestID)
		References Test(TestID),
	Score numeric(10) NOT NULL
);
GO

CREATE TABLE Questions(
	QuestionID int identity,
	constraint QuestionID_PK PRIMARY KEY (QuestionID),
	QuestionDescription varchar(150) NOT NULL
);
GO

CREATE TABLE Answers(
	SerialNo int identity,
	constraint SerialNo_PK PRIMARY KEY (SerialNo),
	DisciplineID int,
	constraint Answers_DisciplineID_FK FOREIGN KEY (DisciplineID)
		References Disciplines(DisciplineID),
	Category varchar(3),
	QuestionID int,
	constraint Answers_QuestionID_FK FOREIGN KEY (QuestionID)
		References Questions(QuestionID),
	Answer1 varchar(100) NOT NULL,
	Answer2 varchar(100) NOT NULL,
	Answer3 varchar(100) NOT NULL,
	Answer4 varchar(100) NOT NULL,
	CorrectAnswer varchar(100) NOT NULL
);
GO

CREATE TABLE Admin
(AdminID int IDENTITY PRIMARY KEY,
AdminName varchar(30) NOT NULL,
AdminPassword varchar(30) NOT NULL);
GO

CREATE TABLE Temp
(UserEmail varchar(50) NOT NULL,
DisciplineID int NOT NULL,
QuestionID int NOT NULL);
GO








