CREATE TABLE [dbo].[Billinfo] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [IdBILL] INT NOT NULL,
    [IdFood] INT NOT NULL,
    [count]  INT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdBILL]) REFERENCES [dbo].[BILL] ([Id]),
    FOREIGN KEY ([IdFood]) REFERENCES [dbo].[Food] ([Id])
);

