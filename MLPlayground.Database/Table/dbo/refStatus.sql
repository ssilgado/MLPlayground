CREATE TABLE dbo.refStatus
    (
          StatusKey             INT NOT NULL IDENTITY(1,1)
        , StatusName            VARCHAR(100) NOT NULL
        , RowCreateTs           DATETIME NOT NULL
        , RowMaintenanceTs      DATETIME NOT NULL
        , CONSTRAINT pkRefStatusOnStatusKey PRIMARY KEY (StatusKey)
    )