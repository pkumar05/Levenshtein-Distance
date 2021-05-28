CREATE TABLE [LD].[GenericMetaData] (
    [Id]          VARCHAR (36)    NOT NULL,
    [MetaSource]  VARCHAR (100)   NOT NULL,
    [MetaType]    VARCHAR (36)    NULL,
    [MetaData]    NVARCHAR (MAX)  NULL,
    [Code]        VARCHAR (100)   NULL,
    [Description] NVARCHAR (2000) NULL,
    [Active]      BIT             DEFAULT ((1)) NOT NULL,
    [CreatedBy]   NVARCHAR (200)  NOT NULL,
    [CreatedDate] DATETIME        NOT NULL,
    [UpdatedBy]   NVARCHAR (200)  NULL,
    [UpdatedDate] DATETIME        NULL
);

