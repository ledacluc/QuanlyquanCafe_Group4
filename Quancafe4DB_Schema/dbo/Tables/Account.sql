CREATE TABLE [dbo].[Account] (
    [UserName]    NVARCHAR (100) NOT NULL,
    [DisplayName] NVARCHAR (100) DEFAULT (N'Nhap ten') NOT NULL,
    [Password]    NVARCHAR (200) DEFAULT ((0)) NOT NULL,
    [Type]        INT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserName] ASC)
);

