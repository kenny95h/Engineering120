--CREATE DATABASE Spartans;

--CREATE TABLE Trainers (
--	trainerID INT PRIMARY KEY IDENTITY(1, 1),
--	first_name VARCHAR (20),
--	last_name VARCHAR (20)
--)

--CREATE TABLE Courses (
--	course_name VARCHAR (30) PRIMARY KEY,
--	course_weeks INT,
--	trainerID INT FOREIGN KEY REFERENCES Trainers (trainerID)
--)

--CREATE TABLE Trainees (
--	traineeID INT PRIMARY KEY IDENTITY(1, 1),
--	title VARCHAR (6),
--	first_name VARCHAR (20),
--	last_name VARCHAR (20),
--	course_name VARCHAR (30) FOREIGN KEY REFERENCES Courses (course_name)
--)

--INSERT INTO Trainers (
--	first_name, last_name
--) VALUES (
--	'Nishant', 
--	'Mandal'
--)

--INSERT INTO Courses (
--	course_name, course_weeks, trainerID
--) VALUES (
--	'Engineering 120',
--	8,
--	1
--)

--INSERT INTO Trainees (
--	title, first_name, last_name, course_name
--) VALUES (
--	'Mr', 'Kenny', 'Harvey', 'Engineering 120'
--), 
--('Mr', 'Charlie', 'Batten', 'Engineering 120'),
--('Mr', 'Pun Kai', 'Chan', 'Engineering 120'),
--('Mr', 'Ellis', 'Witten', 'Engineering 120'),
--('Mr', 'Daniel', 'Summerside', 'Engineering 120'),
--('Mr', 'David', 'Joyce', 'Engineering 120'),
--('Mr', 'Dylan', 'Cole', 'Engineering 120'),
--('Mr', 'Maks', 'Haydes', 'Engineering 120'),
--('Mr', 'Labahang', 'Limbu', 'Engineering 120'),
--('Mr', 'Thomas', 'Wolstencroft', 'Engineering 120'),
--('Mr', 'Jonathan', 'Crofts', 'Engineering 120')

SELECT title + ' ' + t.first_name + ' ' + t.last_name AS "Full Name", 
	t.course_name AS "Course", 
	tner.first_name + ' ' + tner.last_name AS "Trainer"
FROM Trainees t
INNER JOIN Courses c
	ON t.course_name = c.course_name
INNER JOIN Trainers tner
	ON c.trainerID = tner.trainerID
ORDER BY t.first_name ASC;