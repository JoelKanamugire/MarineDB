-- Customer Table
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Address VARCHAR(255),
    UnpaidBalance DECIMAL(10, 2)
);
-- Owner Table
CREATE TABLE Owner (
    OwnerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
);
-- Boat Table
CREATE TABLE Boat (
    BoatID INT PRIMARY KEY,
    BoatName VARCHAR(255),
    BoatSize INT,
    OwnerID INT,
    FOREIGN KEY (OwnerID) REFERENCES Owner(OwnerID)
);
-- Charter Table
CREATE TABLE Charter (
    CharterID INT PRIMARY KEY,
    BoatID INT,
    CustomerID INT,
    StartDate DATE,
    EndDate DATE,
    LateReturnDays INT,
    FOREIGN KEY (BoatID) REFERENCES Boat(BoatID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

-- Crew Table
CREATE TABLE Crew (
    CrewID INT PRIMARY KEY,
    LastName VARCHAR(255),
    FirstName VARCHAR(255),
    HourlyRate DECIMAL(10, 2),
    CharterID INT,
    FOREIGN KEY (CharterID) REFERENCES Charter(CharterID)
);

CREATE TABLE Equipment (
    EquipmentID INT PRIMARY KEY,
    BoatID INT,
    FOREIGN KEY (BoatID) REFERENCES Boat(BoatID)
);
-- Itinerary Table
CREATE TABLE Itinerary (
    ItineraryID INT PRIMARY KEY,
    Name VARCHAR(255), -- Assuming VARCHAR with a suitable length for the name
    -- Other itinerary attributes
);
-- Maintenance Table
CREATE TABLE Maintenance (
    MaintenanceID INT PRIMARY KEY,
    BoatID INT,
    MaintenanceDate DATE, 
    Cost DECIMAL(10, 2), 
    FOREIGN KEY (BoatID) REFERENCES Boat(BoatID)
);

-- Sample Owners
INSERT INTO Owner (OwnerID, FirstName, LastName)
VALUES
    (1, 'Joel', 'Kanamugire'),
    (2, 'Pazong', 'Thor'),
    (3, 'Hazem', 'Farra'),
    (4, 'Nghi', 'Nguyen'),
    (5, 'John', 'Doe'),
    (6, 'Jane', 'Smith');
-- Sample Customers
INSERT INTO Customer (CustomerID, FirstName, LastName, Address, UnpaidBalance)
VALUES
    (1, 'John', 'Doe', '123 Main St, Cityville', 150.00),
    (2, 'Jane', 'Smith', '456 Oak Ave, Townsville', 0.00),
    (3, 'Alice', 'Johnson', '789 Pine Blvd, Villagetown', 75.50),
    (4, 'Bob', 'Williams', '101 Elm St, Hamletville', 200.25),
    (5, 'Eva', 'Martinez', '222 Maple Dr, Suburbia', 0.00),
    (6, 'David', 'Lee', '333 Birch Ln, Countryside', 50.75);
-- Sample Boats
INSERT INTO Boat (BoatID, BoatName, BoatSize, OwnerID)
VALUES
    (1, 'SailAway 2000', 35, 1),  -- Owned by Joel Kanamugire
    (2, 'SeaExplorer X1', 45, 2),  -- Owned by Pazong Thor
    (3, 'SpeedyCat 300', 25, 3),    -- Owned by Hazem Farra
    (4, 'BlueWave Cruiser', 40, 4), -- Owned by Nghi Nguyen
    (5, 'SunsetSail Deluxe', 30, 5), 
    (6, 'OceanGlider', 50, 6);      -- Sample boat
-- Sample Itineraries
INSERT INTO Itinerary (ItineraryID, Name)
VALUES
    (1, 'Coastal Adventure'),
    (2, 'Island Hopping'),
    (3, 'Sunset Cruise'),
    (4, 'Fishing Expedition'),
    (5, 'Weekend Getaway'),
    (6, 'Dolphin Watching');
-- Sample Equipment
INSERT INTO Equipment (EquipmentID, BoatID)
VALUES
    (1, 1),  -- Equipment 1 associated with Boat 1
    (2, 2),  -- Equipment 2 associated with Boat 2
    (3, 3),  -- Equipment 3 associated with Boat 3
    (4, 4),  -- Equipment 4 associated with Boat 4
    (5, 5),  -- Equipment 5 associated with Boat 5
    (6, 6);  -- Equipment 6 associated with Boat 6
-- Sample Maintenance Records
INSERT INTO Maintenance (MaintenanceID, BoatID, MaintenanceDate, Cost)
VALUES
    (1, 1, '2023-01-15', 200.00),  -- Maintenance for Boat 1
    (2, 2, '2023-02-20', 150.50),  -- Maintenance for Boat 2
    (3, 3, '2023-03-10', 300.75),  -- Maintenance for Boat 3
    (4, 4, '2023-04-05', 100.25),  -- Maintenance for Boat 4
    (5, 5, '2023-05-12', 75.00),   -- Maintenance for Boat 5
    (6, 6, '2023-06-18', 250.50);  -- Maintenance for Boat 6
-- Sample Charter Records
INSERT INTO Charter (CharterID, BoatID, CustomerID, StartDate, EndDate, LateReturnDays)
VALUES
    (1, 1, 1, '2023-01-10', '2023-01-15', 0),  -- Charter for Boat 1 with Customer 1
    (2, 2, 2, '2023-02-15', '2023-02-20', 1),  -- Charter for Boat 2 with Customer 2
    (3, 3, 3, '2023-03-05', '2023-03-10', 0),  -- Charter for Boat 3 with Customer 3
    (4, 4, 4, '2023-04-01', '2023-04-05', 2),  -- Charter for Boat 4 with Customer 4
    (5, 5, 5, '2023-05-08', '2023-05-12', 0),  -- Charter for Boat 5 with Customer 5
    (6, 6, 6, '2023-06-13', '2023-06-18', 1);  -- Charter for Boat 6 with Customer 6

-- Sample Crew Members
INSERT INTO Crew (CrewID, LastName, FirstName, HourlyRate, CharterID)
VALUES
    (1, 'Smith', 'Alice', 20.00, 1),  -- Alice Smith on Charter 1
    (2, 'Johnson', 'Bob', 25.00, 1),   -- Bob Johnson on Charter 1
    (3, 'Martinez', 'Eva', 18.50, 2),  -- Eva Martinez on Charter 2
    (4, 'Lee', 'David', 22.00, 3),     -- David Lee on Charter 3
    (5, 'Doe', 'John', 23.75, 4),      -- John Doe on Charter 4
    (6, 'Nguyen', 'Linh', 21.25, 5);   -- Linh Nguyen on Charter 5



