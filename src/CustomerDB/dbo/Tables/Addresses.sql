CREATE TABLE [dbo].[Addresses] (
    [AddressId]    INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId]   INT            NOT NULL,
    [Line]         NVARCHAR (100) NOT NULL,
    [Line2]        NVARCHAR (100) NULL,
    [AddressType]  NVARCHAR (8)   NOT NULL,
    [City]         NVARCHAR (50)  NOT NULL,
    [PostalCode]   NVARCHAR (6)   NOT NULL,
    [AddressState] NVARCHAR (20)  NOT NULL,
    [Country]      NVARCHAR (14)  NOT NULL,
    CONSTRAINT [PK_AddressId] PRIMARY KEY CLUSTERED ([AddressId] ASC),
    CONSTRAINT [CHK_AddressType] CHECK ([AddressType]='Billing' OR [AddressType]='Shipping'),
    CONSTRAINT [CHK_Country] CHECK ([Country]='Canada' OR [Country]='United States'),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);

