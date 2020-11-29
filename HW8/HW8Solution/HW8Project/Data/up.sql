CREATE TABLE [Courses] 
(
  [course_id]       NVARCHAR(6)     PRIMARY KEY,
  [title]           NVARCHAR(50)    ,
  [description]     NVARCHAR(max)
)

CREATE TABLE [Assignments] 
(
  [id]              INT             PRIMARY KEY IDENTITY (1,1),
  [priority]        NVARCHAR(10)    NOT NULL,
  [due_date]        DATE            NOT NULL,
  [course_id]       NVARCHAR(6)     NOT NULL,
  [title]           NVARCHAR(50)    NOT NULL,
  [keywords]        NVARCHAR(max)   ,
  [notes]           NVARCHAR(max)   
)

CREATE TABLE [Keywords] 
(
  [id]              INT             PRIMARY KEY IDENTITY (1,1),
  [title]           NVARCHAR(255)   NOT NULL
)

ALTER TABLE [Assignments] ADD FOREIGN KEY ([course_id]) REFERENCES [Courses] ([course_id])

GO
