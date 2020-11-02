CREATE TABLE [HomeworkAssignments]
(
    [ID]			INT PRIMARY KEY IDENTITY (1,1),
    [Priority]		NVARCHAR(6)			NOT NULL,
    [DueDate]	    DATE				NOT NULL,
    [TimeDue]		DATETIME            NOT NULL,
	[Department]	NVARCHAR(4)			NOT NULL,
	[CourseNumber]	INT					NOT NULL,
	[Assignment]	NVARCHAR(64)		NOT NULL,
	[Notes]			NVARCHAR(MAX)
)
GO