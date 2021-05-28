CREATE TABLE [LD].[GenericStringsComputations] (
    [Id]                  VARCHAR (36)    NOT NULL,
    [Source]              NVARCHAR (MAX)  NULL,
    [Target]              NVARCHAR (MAX)  NULL,
    [LevenshteinDistance] INT             DEFAULT ((-101)) NULL,
    [Code]                VARCHAR (100)   NULL,
    [Description]         NVARCHAR (2000) NULL,
    [Active]              BIT             DEFAULT ((1)) NOT NULL,
    [CreatedBy]           NVARCHAR (200)  NOT NULL,
    [CreatedDate]         DATETIME        NOT NULL,
    [UpdatedBy]           NVARCHAR (200)  NULL,
    [UpdatedDate]         DATETIME        NULL
);

