Begin Transaction;

DROP TABLE Verb_Category;

CREATE TABLE Verb_Category(
[ID] int UNIQUE
,[ID_Verb] int
,[ID_Category] int
,[Closed] bit DEFAULT false
,[RightAnswers] int DEFAULT 0
, Primary Key(ID)   
);

CREATE UNIQUE INDEX [Verb_Category_udx] On [Verb_Category] (
[ID_Verb] ,
[ID_Category] );


Commit Transaction;