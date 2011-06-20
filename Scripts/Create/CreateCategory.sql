Begin Transaction;
Create  TABLE MAIN.[Temp_807483443](
[ID] int UNIQUE
,[Name] varchar
, Primary Key(ID)   
);
Insert Into MAIN.[Temp_807483443] ([ID],[Name]) 
 Select [ID],[Name] From MAIN.[Category];
Drop Table MAIN.[Category];
Alter Table MAIN.[Temp_807483443] Rename To [Category];


Commit Transaction;