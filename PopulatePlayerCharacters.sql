INSERT INTO dbo.Players (PlayerName)
SELECT name
FROM (
	VALUES
		('Katie'), 
		('Shawn'), 
		('Jim'), 
		('Matt'), 
		('Kristina'), 
		('Leighton'), 
		('Hillary')
	) AS T (name)
EXCEPT
SELECT PlayerName
FROM dbo.Players

INSERT INTO dbo.Races (RaceName)
SELECT name
FROM (
	VALUES
		 ('Aarakocra')
		,('Aasimar')
		,('Bugbear')
		,('Changeling')
		,('Dragonborn')
		,('Dwarf')
		,('Elf')
		,('Firbolg')
		,('Genasi')
		,('Gnome')
		,('Goblin')
		,('Goliath')
		,('Half-Elf')
		,('Half-Orc')
		,('Halfling')
		,('Hobgoblin')
		,('Human')
		,('Kenku')
		,('Kobold')
		,('Lizardfolk')
		,('Minotaur')
		,('Orc')
		,('Shifter')
		,('Tabaxi')
		,('Tiefling')
		,('Triton')
		,('Warforged')
		,('Yuan-ti')
	) AS T (name)
EXCEPT
SELECT RaceName
FROM dbo.Races

INSERT INTO dbo.Classes(ClassName)
SELECT name
FROM (
	VALUES
	 ('Artificer')
	,('Barbarian')
	,('Bard')
	,('Cleric')
	,('Druid')
	,('Fighter')
	,('Monk')
	,('Mystic')
	,('Paladin')
	,('Ranger')
	,('Rogue')
	,('Sorcerer')
	,('Warlock')
	,('Wizard')
	) AS T (name)
EXCEPT
SELECT ClassName
FROM dbo.Classes

DECLARE @Players TABLE (PlayerName VARCHAR(100), CharacterName  VARCHAR(100), RaceName  VARCHAR(100), ClassName  VARCHAR(100), CharacterLevel INT, CharacterExperience DECIMAL(9,2))
INSERT INTO @Players VALUES
	 ('Katie', 'Maerwyn Moonbeard', 'Dwarf', 'Druid', 5, 8000)
	,('Shawn', 'Vain Durine', 'Human', 'Paladin', 5, 8000)
	,('Jim', 'Kruug', 'Half-Orc', 'Fighter', 5, 8000)
	,('Matt', 'Mindartis Amakiir', 'Elf', 'Ranger', 5, 8000)
	,('Kristina', 'Anastrianna Holimion', 'Elf', 'Wizard', 5, 8000)
	,('Leighton', 'Alfin Shortstubble Coniferous Quickwit Wildheart Rockfeather', 'Gnome', 'Bard', 5, 8000)
	,('Hillary', 'Noralen Nightbreeze', 'Elf', 'Ranger', 5, 8000)

INSERT INTO dbo.Characters (PlayerId, RaceId, CharacterName, CharacterLevel, CharacterExperience)
SELECT
	 PlayerId
	,RaceId
	,CharacterName
	,CharacterLevel
	,CharacterExperience
FROM @Players A
JOIN dbo.Players P ON A.PlayerName= P.PlayerName
JOIN dbo.Races R ON A.RaceName = R.RaceName
EXCEPT
SELECT
	 PlayerId
	,RaceId
	,CharacterName
	,CharacterLevel
	,CharacterExperience
FROM dbo.Characters

INSERT INTO dbo.CharacterClasses (CharacterId, ClassId, ClassLevels)
SELECT
	 CharacterId
	,ClassId
	,ClassLevels = A.CharacterLevel
FROM @Players A
JOIN dbo.Classes C ON A.ClassName = C.ClassName
JOIN dbo.Characters Ch ON Ch.CharacterName = A.CharacterName
EXCEPT
SELECT
	 CharacterId
	,ClassId
	,ClassLevels
FROM dbo.CharacterClasses