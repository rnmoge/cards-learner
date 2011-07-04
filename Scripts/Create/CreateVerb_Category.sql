Begin Transaction;
Create  TABLE MAIN.[Temp_369895384](
[ID] int UNIQUE
,[ID_Verb] int
,[ID_Category] int
,[Closed] bit DEFAULT false
,[RightAnswers] int DEFAULT 0
, Primary Key(ID)   
);
Insert Into MAIN.[Temp_369895384] ([ID],[ID_Verb],[ID_Category],[Closed],[RightAnswers]) 
 Select [ID],[ID_Verb],[ID_Category],[Closed],[RightAnswers] From MAIN.[Verb_Category];
Drop Table MAIN.[Verb_Category];
Alter Table MAIN.[Temp_369895384] Rename To [Verb_Category];


Commit Transaction;