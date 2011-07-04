Begin Transaction;
Drop Trigger If Exists MAIN.[Verb_Category_Insert];
Create  Trigger MAIN.[Verb_Category_Insert] AFTER INSERT On [Verb_Category] FOR EACH ROW
begin
  UPDATE Verb_Category SET ID = (SELECT MAX(ID) + 1 as ID FROM Verb_Category) WHERE rowid = new.rowid;
end;
Commit Transaction;