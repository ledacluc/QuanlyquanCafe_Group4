CREATE TABLE [dbo].[FoodCategory] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) DEFAULT (N'Chua dat ten') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

