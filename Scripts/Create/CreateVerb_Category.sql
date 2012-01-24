Begin Transaction;
Create  TABLE MAIN.[Temp_789145807](
[ID] int UNIQUE
,[ID_Verb] int
,[ID_Category] int
,[Closed] bit DEFAULT false
,[RightAnswers] int DEFAULT 0
,[StudyLevel] int DEFAULT 0
   
);
Insert Into MAIN.[Temp_789145807] ([ID],[ID_Verb],[ID_Category],[Closed],[RightAnswers],[StudyLevel]) 
 Select [ID],[ID_Verb],[ID_Category],[Closed],[RightAnswers],[StudyLevel] From MAIN.[Verb_Category];
Drop Table MAIN.[Verb_Category];
Alter Table MAIN.[Temp_789145807] Rename To [Verb_Category];

CREATE TRIGGER [Verb_Category_Insert] AFTER INSERT On [Verb_Category] FOR EACH ROW
begin
  UPDATE Verb_Category SET ID = (SELECT MAX(ID) + 1 as ID FROM Verb_Category) WHERE rowid = new.rowid;
end;

Commit Transaction;
