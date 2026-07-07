IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Rooms] (
    [Id] int NOT NULL IDENTITY,
    [RoomNumber] nvarchar(max) NOT NULL,
    [Residence] nvarchar(max) NOT NULL,
    [RoomType] nvarchar(max) NOT NULL,
    [TotalBeds] int NOT NULL,
    [OccupiedBeds] int NOT NULL,
    [Floor] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Size] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Bookings] (
    [Id] int NOT NULL IDENTITY,
    [RoomId] int NOT NULL,
    [BedNumber] int NOT NULL,
    [StudentName] nvarchar(max) NOT NULL,
    [StudentEmail] nvarchar(max) NOT NULL,
    [StudentPhone] nvarchar(max) NOT NULL,
    [BookingDate] datetime2 NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Bookings_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Rooms] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Floor', N'OccupiedBeds', N'Price', N'Residence', N'RoomNumber', N'RoomType', N'Size', N'TotalBeds') AND [object_id] = OBJECT_ID(N'[Rooms]'))
    SET IDENTITY_INSERT [Rooms] ON;
INSERT INTO [Rooms] ([Id], [Floor], [OccupiedBeds], [Price], [Residence], [RoomNumber], [RoomType], [Size], [TotalBeds])
VALUES (1, 1, 0, 3500.0, N'single', N'101', N'Single', N'20m²', 1),
(2, 1, 0, 3500.0, N'single', N'102', N'Single', N'20m²', 1),
(3, 1, 0, 3500.0, N'single', N'103', N'Single', N'20m²', 1),
(4, 1, 0, 3500.0, N'single', N'104', N'Single', N'20m²', 1),
(5, 2, 0, 3500.0, N'single', N'201', N'Single', N'20m²', 1),
(6, 2, 0, 3500.0, N'single', N'202', N'Single', N'20m²', 1),
(7, 2, 0, 3500.0, N'single', N'203', N'Single', N'20m²', 1),
(8, 2, 0, 3500.0, N'single', N'204', N'Single', N'20m²', 1),
(9, 1, 0, 2800.0, N'double', N'101', N'Double', N'28m²', 2),
(10, 1, 0, 2800.0, N'double', N'102', N'Double', N'28m²', 2),
(11, 1, 0, 2800.0, N'double', N'103', N'Double', N'28m²', 2),
(12, 1, 0, 2800.0, N'double', N'104', N'Double', N'28m²', 2),
(13, 1, 0, 2200.0, N'triple', N'101', N'Triple', N'35m²', 3),
(14, 1, 0, 2200.0, N'triple', N'102', N'Triple', N'35m²', 3),
(15, 1, 0, 2200.0, N'triple', N'103', N'Triple', N'35m²', 3),
(16, 1, 0, 2200.0, N'triple', N'104', N'Triple', N'35m²', 3),
(17, 1, 0, 3500.0, N'mix', N'101', N'Single', N'20m²', 1),
(18, 1, 0, 2800.0, N'mix', N'102', N'Double', N'28m²', 2),
(19, 1, 0, 2200.0, N'mix', N'103', N'Triple', N'35m²', 3),
(20, 1, 0, 3500.0, N'mix', N'104', N'Single', N'20m²', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Floor', N'OccupiedBeds', N'Price', N'Residence', N'RoomNumber', N'RoomType', N'Size', N'TotalBeds') AND [object_id] = OBJECT_ID(N'[Rooms]'))
    SET IDENTITY_INSERT [Rooms] OFF;
GO

CREATE INDEX [IX_Bookings_RoomId] ON [Bookings] ([RoomId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260309025729_CleanStart', N'8.0.0');
GO

COMMIT;
GO

