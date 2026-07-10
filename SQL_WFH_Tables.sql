-- ============================================================
-- WFH GPS TRACKING SYSTEM - SQL TABLES
-- Run this script on LotusTechCRMLive database
-- ============================================================

-- Table 1: Main WFH Tracking Session (one per day per employee)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblWFHTracking' AND xtype='U')
CREATE TABLE tblWFHTracking (
    Id               INT IDENTITY(1,1) PRIMARY KEY,
    AttendanceId     INT NOT NULL,
    EmployeeId       INT NOT NULL,
    TrackingDate     DATE NOT NULL,
    AssignedLat      FLOAT NOT NULL,
    AssignedLong     FLOAT NOT NULL,
    AllowedRadius    FLOAT NOT NULL DEFAULT 100,
    TrackingStartTime DATETIME NOT NULL,
    TrackingEndTime  DATETIME NULL,
    CurrentStatus    NVARCHAR(20) NOT NULL DEFAULT 'Inside',
    CurrentLat       FLOAT NULL,
    CurrentLong      FLOAT NULL,
    CurrentDistance  FLOAT NULL,
    CurrentAddress   NVARCHAR(500) NULL,
    LastPingTime     DATETIME NULL,
    TotalAutoOutCount INT NOT NULL DEFAULT 0,
    TotalOutsideDurationMinutes INT NOT NULL DEFAULT 0,
    DeviceName       NVARCHAR(200) NULL,
    Browser          NVARCHAR(200) NULL,
    IpAddress        NVARCHAR(50) NULL,
    CreatedOn        DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedOn        DATETIME NULL
);

-- Table 2: GPS Pings (every 20 seconds)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblWFHGPSPing' AND xtype='U')
CREATE TABLE tblWFHGPSPing (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    TrackingId      INT NOT NULL,
    EmployeeId      INT NOT NULL,
    AttendanceId    INT NOT NULL,
    PingTime        DATETIME NOT NULL,
    Latitude        FLOAT NOT NULL,
    Longitude       FLOAT NOT NULL,
    Distance        FLOAT NOT NULL,
    IsInsideRadius  BIT NOT NULL DEFAULT 1,
    CreatedOn       DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table 3: Auto-Out / Auto-Return Events
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblWFHTrackingEvents' AND xtype='U')
CREATE TABLE tblWFHTrackingEvents (
    Id                    INT IDENTITY(1,1) PRIMARY KEY,
    TrackingId            INT NOT NULL,
    AttendanceId          INT NOT NULL,
    EmployeeId            INT NOT NULL,
    EventType             NVARCHAR(20) NOT NULL,
    EventTime             DATETIME NOT NULL,
    Latitude              FLOAT NOT NULL,
    Longitude             FLOAT NOT NULL,
    Distance              FLOAT NOT NULL,
    Address               NVARCHAR(500) NULL,
    DeviceName            NVARCHAR(200) NULL,
    Browser               NVARCHAR(200) NULL,
    IpAddress             NVARCHAR(50) NULL,
    Reason                NVARCHAR(500) NULL,
    ReturnTime            DATETIME NULL,
    OutsideDurationMinutes INT NULL,
    CreatedOn             DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table 4: Real-Time Current Status per Employee
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblWFHCurrentStatus' AND xtype='U')
CREATE TABLE tblWFHCurrentStatus (
    Id                         INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId                 INT NOT NULL,
    AttendanceId               INT NULL,
    TrackingId                 INT NULL,
    TrackingDate               DATE NULL,
    CurrentStatus              NVARCHAR(20) NULL DEFAULT 'NotTracking',
    CurrentLat                 FLOAT NULL,
    CurrentLong                FLOAT NULL,
    CurrentDistance            FLOAT NULL,
    CurrentAddress             NVARCHAR(500) NULL,
    OutsideSince               DATETIME NULL,
    ReturnedTime               DATETIME NULL,
    TotalOutsideDurationMinutes INT NOT NULL DEFAULT 0,
    TotalAutoOutCount          INT NOT NULL DEFAULT 0,
    LastPingTime               DATETIME NULL,
    DeviceName                 NVARCHAR(200) NULL,
    Browser                    NVARCHAR(200) NULL,
    IpAddress                  NVARCHAR(50) NULL,
    UpdatedOn                  DATETIME NULL
);

-- Table 5: Notification History
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblWFHNotificationHistory' AND xtype='U')
CREATE TABLE tblWFHNotificationHistory (
    Id                INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId        INT NOT NULL,
    AttendanceId      INT NULL,
    TrackingEventId   INT NULL,
    NotificationType  NVARCHAR(50) NULL,
    Title             NVARCHAR(200) NULL,
    Body              NVARCHAR(1000) NULL,
    SentTo            NVARCHAR(50) NULL,
    SentOn            DATETIME NOT NULL DEFAULT GETDATE(),
    IsDelivered       BIT NOT NULL DEFAULT 0
);

-- Indexes for performance
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_tblWFHGPSPing_EmpDate')
    CREATE INDEX IX_tblWFHGPSPing_EmpDate ON tblWFHGPSPing (EmployeeId, PingTime DESC);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_tblWFHCurrentStatus_EmpId')
    CREATE INDEX IX_tblWFHCurrentStatus_EmpId ON tblWFHCurrentStatus (EmployeeId);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_tblWFHTracking_EmpDate')
    CREATE INDEX IX_tblWFHTracking_EmpDate ON tblWFHTracking (EmployeeId, TrackingDate);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_tblWFHTrackingEvents_EmpDate')
    CREATE INDEX IX_tblWFHTrackingEvents_EmpDate ON tblWFHTrackingEvents (EmployeeId, EventTime DESC);

PRINT 'WFH GPS Tracking tables created successfully.';
