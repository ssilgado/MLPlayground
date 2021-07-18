CREATE TABLE dbo.ImageRecord
    (
          ImageRecordKey INT IDENTITY(1,1) NOT NULL
        , ImageKey INT UNIQUE NOT NULL
        , ImageCategory VARCHAR(256) NOT NULL
        , RowCreateTs DATETIME NOT NULL
        , RowMaintenanceTs DATETIME NOT NULL
        , CONSTRAINT pkImageRecordOnImageRecordKey PRIMARY KEY (ImageRecordKey)
        , CONSTRAINT fkImageToImageRecordOnImageKey FOREIGN KEY (ImageKey) REFERENCES dbo.Image(ImageKey)
    )