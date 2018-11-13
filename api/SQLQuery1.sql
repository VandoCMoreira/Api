/*Select distinct  Q.* from Questions Q 
left join Choices C on (Q.QuestionId = C.QuestionId)
where upper(Q.QuestionName) in ('delphi') or upper(C.ChoiceName) in ('delphi')*/



Select  top 1 Q.* from Questions Q 
inner join Choices C on (Q.QuestionId = C.QuestionId)
where upper(Q.QuestionName) in ('elphi') or upper(C.ChoiceName) in ('delphi')
ORDER BY Q.QUESTIONAME ASC OFFSET 5 FETCH FIRST 10 ROWS ONLY


DBCC CHECKIDENT ('[Choices]', RESEED,0)
