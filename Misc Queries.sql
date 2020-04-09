Select a.QuestionID  from answers a 
left join Temp t on a.QuestionID = t.QuestionID 
where t.QuestionID is NULL and a.DisciplineID  =1
and t.UserID != 1;

Select a.QuestionID from Answers a Except(
select QuestionID from Temp where DisciplineID =1 and UserID =1)


delete from temp

insert into Temp(UserID,DisciplineID,QuestionID,Iscorrect) Values(1,1,4,'false')
Update Temp Set IsCorrect = 'true' where  UserID=1 and DisciplineID = 1 and QuestionID = 2
use OTS
Select * from temp

select count(*) from Temp where IsCorrect = 1 and UserID =1 and DisciplineID = 1
select count(QuestionID) from Temp where UserID =1 and DisciplineID =1

alter table temp 
drop column  IsCorrect 

alter table temp
add  IsCorrect bit