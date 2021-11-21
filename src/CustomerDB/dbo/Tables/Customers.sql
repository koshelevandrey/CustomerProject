CREATE TABLE [dbo].[Customers] (
    [CustomerId]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]            NVARCHAR (50)  NULL,
    [LastName]             NVARCHAR (50)  NOT NULL,
    [PhoneNumber]          NVARCHAR (16)  NULL,
    [Email]                NVARCHAR (100) NULL,
    [Notes]                NVARCHAR (MAX) NOT NULL,
    [TotalPurchasesAmount] MONEY          NULL,
    CONSTRAINT [PK_CustomerId] PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [CHK_Email] CHECK ([Email] like '%[a-zA-Z0-9][@][a-zA-Z0-9]%[.][a-zA-Z0-9]%'),
    CONSTRAINT [CHK_PhoneNumber_E164] CHECK ([PhoneNumber] like '+[1-9]'+replicate('[0-9]',(14)) OR [PhoneNumber] like '[1-9]'+replicate('[0-9]',(14)))
);

