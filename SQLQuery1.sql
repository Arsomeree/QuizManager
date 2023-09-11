
/****** Object: Table [dbo].[Quizinfo] Script Date: 19/09/2021 20:57:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Quizinfo] (
    [id]       INT          NOT NULL,
    [Title]    VARCHAR (50) NULL,
    [Question] VARCHAR (50) NULL,
    [Choice1]  VARCHAR (50) NULL,
    [Choice2]  VARCHAR (50) NULL,
    [Choice3]  VARCHAR (50) NULL,
    [Choice4]  VARCHAR (50) NULL,
    [Choice5]  VARCHAR (50) NULL,
    [Answer]   VARCHAR (50) NULL
);


