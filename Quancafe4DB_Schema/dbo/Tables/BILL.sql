CREATE TABLE [dbo].[BILL] (
    [Id]           INT  IDENTITY (1, 1) NOT NULL,
    [DateCheckIn]  DATE DEFAULT (getdate()) NOT NULL,
    [DateCheckOut] DATE NULL,
    [IdTable]      INT  NOT NULL,
    [Status]       INT  DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdTable]) REFERENCES [dbo].[TableFood] ([Id])
);

