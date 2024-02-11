CREATE TABLE Notes (
    ID INT PRIMARY KEY IDENTITY,
    ObjectID INT,
    ObjectName VARCHAR(100),
    Note NVARCHAR(MAX),
    DateTime DATETIME
);
