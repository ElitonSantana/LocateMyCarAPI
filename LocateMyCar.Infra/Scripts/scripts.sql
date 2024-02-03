BEGIN TRAN
--COMMIT
--ROLLBACK

CREATE TABLE Vehicles
(
    [VehicleId] INT IDENTITY(1,1) PRIMARY KEY,
    [Brand] VARCHAR(50) NOT NULL,
    [Model] VARCHAR(50) NOT NULL,
    [Type] INT NOT NULL,
    [ImageURL] VARCHAR(MAX),
    [CreationDate] DATETIME NOT NULL,
	[ModifiedDate] DATETIME
);

CREATE TABLE VehicleDetails
(
    [VehicleDetailId] INT IDENTITY(1,1) PRIMARY KEY,
    [Year] INT NOT NULL,
    [VehiclePower] DECIMAL(2, 1) NOT NULL,
    [Price] FLOAT NOT NULL,
    [VehicleDoors] INT NOT NULL,
    [ImageURL] VARCHAR(MAX),
    [CreationDate] DATETIME NOT NULL,
    [ModifiedDate] DATETIME,
    [VehicleId] INT FOREIGN KEY REFERENCES Vehicles(VehicleId)
);

GO

CREATE PROCEDURE usp_GetTopVehiclesOlders
AS
BEGIN
    SELECT TOP 3
        CONCAT(v.[Brand],' ',v.[Model]) AS 'FullName',
        vd.[Year] AS 'Year',
        vd.[ImageURL] AS 'ImageURL',
        vd.[Price] AS 'Price'
    FROM
        Vehicles v
    JOIN
        VehicleDetails vd ON v.VehicleId = vd.VehicleId
    ORDER BY
        vd.Year ASC;
END;