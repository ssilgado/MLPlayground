CREATE TABLE dbo.ProcessStatus
    (
          ProcessStatusKey          INT IDENTITY(1,1) NOT NULL
        , ProcessGUID               UNIQUEIDENTIFIER NOT NULL
        , StatusKey                 INT NOT NULL
        , RowCreateTs             DATETIME NOT NULL
        , RowMaintenanceTs          DATETIME NOT NULL
        , CONSTRAINT pkProcessStatusOnProcessStatusKey PRIMARY KEY (ProcessStatusKey)
        , CONSTRAINT fkProcessStatusOnStatusStatusKey FOREIGN KEY (StatusKey) REFERENCES dbo.refStatus (StatusKey)
    )