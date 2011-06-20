Begin Transaction;
Create  TABLE MAIN.[Temp_454925975](
[FirstForm] varchar(100)
,[FirstFormSound] binary
,[SecondForm] varchar(100)
,[SecondFormSound] binary
,[ThirdForm] varchar(100)
,[Translate] varchar(100)
,[ThirdFormSound] binary
,[Example1] text
,[ExampleSound1] binary
,[Example2] text
,[ExampleSound2] binary
,[Example3] text
,[ExampleSound3] binary
,[ID] int UNIQUE
, Primary Key(ID)   
);
Insert Into MAIN.[Temp_454925975] ([FirstForm],[FirstFormSound],[SecondForm],[SecondFormSound],[ThirdForm],[Translate],[ThirdFormSound],[Example1],[ExampleSound1],[Example2],[ExampleSound2],[Example3],[ExampleSound3],[ID]) 
 Select [FirstForm],[FirstFormSound],[SecondForm],[SecondFormSound],[ThirdForm],[Translate],[ThirdFormSound],[Example1],[ExampleSound1],[Example2],[ExampleSound2],[Example3],[ExampleSound3],[ID] From MAIN.[Verbs];
Drop Table MAIN.[Verbs];
Alter Table MAIN.[Temp_454925975] Rename To [Verbs];


Commit Transaction;