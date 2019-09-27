CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (MAX)  NOT NULL,
    [LastName]     NVARCHAR (MAX)  NOT NULL,
    [DateOfBirth]  DATETIME2 (7)   NOT NULL,
    [AnnualIncome] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

