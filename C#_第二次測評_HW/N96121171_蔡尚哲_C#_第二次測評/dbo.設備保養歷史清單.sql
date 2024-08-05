CREATE TABLE [dbo].[設備保養歷史清單] (
    [Id]  INT        NOT NULL,
    [時間]  TEXT NOT NULL,
    [編號]  CHAR (10)  NULL,
    [保養人] CHAR (10)  NULL,
    [料號]  CHAR (10)  NULL,
    [備註]  NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

