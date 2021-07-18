CREATE TABLE dbo.Image
    (
          ImageKey          INT IDENTITY(1,1) NOT NULL
        , ImageData         VARBINARY(MAX)
        , RowCreateTs       DATETIME NOT NULL
        , RowMaintenanceTs  DATETIME NOT NULL
        , CONSTRAINT pkImageOnImageKey PRIMARY KEY (ImageKey)
    )