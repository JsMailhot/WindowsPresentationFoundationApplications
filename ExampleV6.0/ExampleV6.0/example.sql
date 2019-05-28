USE MASTER;
GO
IF EXISTS(Select name FROM sys.databases
	where name='Example_DB')
	DROP DATABASE Example_DB
GO

CREATE DATABASE Example_DB;
GO

USE Example_DB;
GO

-- drop table Journals
go

CREATE TABLE [Example_DB].[dbo].[Journals](
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DateSaved DateTime NOT NULL,
	JournalEntry varChar(250) NOT NULL
);

INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('19961113 23:00:00','Today I was Born');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('1999-04-20 09:42:06.000','I witnessed something horrible');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2000-08-07 12:43:15.000','I voted');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2001-09-11 09:37:16.000','I went home from school early');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2004-09-06 12:21:26.000','I voted');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2007-11-09 15:18:42.000','I skipped lunch and dinner today');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2011-05-22 16:01:50.000','I feel safer and stronger today');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2012-08-05 06:25:58.000','I Voted Today');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2014-11-11 15:39:10.000','I went to New Yor today');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2015-06-26 11:01:07.000','I held a celebration');
INSERT into Example_DB..Journals(DateSaved,JournalEntry)VALUES('2016-08-11 09:07:06.000','I Voted today');

SELECT * FROM Journals ORDER BY DateSaved DESC;