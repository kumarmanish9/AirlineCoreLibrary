-- step 1:
CREATE DATABASE FlyingTogether;

---- Pass: Changelife@26

-- Step 2: Use the Database
USE FlyingTogether;

CREATE TABLE Flight (
    Id INT NOT NULL AUTO_INCREMENT,      -- Auto-incrementing primary key
    FlightKey VARCHAR(50) NOT NULL,      -- FlightKey (assumed to be a string with a max length of 50)
    FlightNumber VARCHAR(10) NOT NULL,   -- Flight number (VARCHAR for alphanumeric string)
    Departure VARCHAR(3) NOT NULL,      -- Departure airport code (3-letter code)
    Arrival VARCHAR(3) NOT NULL,        -- Arrival airport code (3-letter code)
    ScheduledDate DATETIME NOT NULL,    -- Scheduled flight date and time (DATETIME for proper date-time storage)
    NumberOfPax INT NOT NULL,           -- Number of passengers (INT)
    PRIMARY KEY (Id)                    -- Primary key on Id
);

CREATE TABLE Passenger (
    Id INT NOT NULL AUTO_INCREMENT,          -- Auto-incrementing primary key
    PassengerKey VARCHAR(50) NOT NULL,       -- PassengerKey (string, assumed to be 50 characters max)
    FlightKey VARCHAR(50) NOT NULL,          -- FlightKey (string, assumed to be 50 characters max)
    Pnr VARCHAR(10) NOT NULL,                -- PNR (string, assumed to be alphanumeric, up to 10 characters)
    FirstName VARCHAR(50) NOT NULL,          -- First name of the passenger (string, 50 characters max)
    LastName VARCHAR(50) NOT NULL,           -- Last name of the passenger (string, 50 characters max)
    Phone VARCHAR(15),                       -- Phone number (string, 15 characters max)
    Email VARCHAR(100),                      -- Email address (string, 100 characters max)
    Compensation VARCHAR(50),                -- Compensation (string, 50 characters max, could be a monetary value)
    Status VARCHAR(20),                      -- Status (string, 20 characters max)
    PRIMARY KEY (Id)                         -- Primary key on Id
);









