IF EXISTS (SELECT * FROM dbo.refStatus)
    BEGIN
        DELETE FROM dbo.refStatus;
    END
GO

BEGIN
    INSERT INTO dbo.refStatus (StatusName, RowCreateTs, RowMaintenanceTs) VALUES
        ('In Progress', GETDATE(), GETDATE()),
        ('Completed', GETDATE(), GETDATE()),
        ('Cancelled', GETDATE(), GETDATE());
END
GO
