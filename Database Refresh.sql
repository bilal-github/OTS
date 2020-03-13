use OTS
DBCC CHECKIDENT ([disciplines], RESEED, 0);
DBCC CHECKIDENT (questions, RESEED, 0);
DBCC CHECKIDENT (answers, RESEED, 0);
DBCC CHECKIDENT (Test, RESEED, 0);
DBCC CHECKIDENT (Users, RESEED, 0);



GO
select * from disciplines
select * from questions
select * from answers
select * from Test
--delete from questions
--delete from Answers
delete from Disciplines
insert into disciplines values('Class 7 Diriving Test')
insert into questions values('When can you make a right turn at a red light?')
insert into Answers(DisciplineID,QuestionID,Answer1,Answer2,Answer3,Answer4,CorrectAnswer)
	values(1,1,


;

select * from Users
select * from DisciplineDetail
insert into DisciplineDetail(UserID,DisciplineID) Values(1,1);
insert into Test(DisciplineID,UserID) Values(1,1);

insert into Users(UserFirstName,UserLastName,UserEmail,UserPassword) Values('Bilal','Ahmad','bilal_ahmad_94@hotmail.com','12345678')