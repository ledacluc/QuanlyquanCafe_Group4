CREATE TABLE [dbo].[Food] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) DEFAULT (N'Chua dat ten') NOT NULL,
    [IdCategory] INT            NOT NULL,
    [Price]      FLOAT (53)     DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdCategory]) REFERENCES [dbo].[FoodCategory] ([Id])
);

