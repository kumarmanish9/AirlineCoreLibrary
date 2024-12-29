-- drop database FlyingTogether;

-- step 1:
CREATE DATABASE FlyingTogether;

---- Pass: Changelife@26

-- Step 2: Use the Database
USE FlyingTogether;

CREATE TABLE Flight (
    Id INT NOT NULL AUTO_INCREMENT,         -- Auto-incrementing primary key
    FlightKey VARCHAR(50) NOT NULL,         -- FlightKey (assumed to be a string with a max length of 50)
    FlightNumber VARCHAR(10) NOT NULL,      -- Flight number (VARCHAR for alphanumeric string)
    Departure VARCHAR(3) NOT NULL,          -- Departure airport code (3-letter code)
    Arrival VARCHAR(3) NOT NULL,            -- Arrival airport code (3-letter code)
    ScheduledDate DATETIME NOT NULL,        -- Scheduled flight date and time (DATETIME for proper date-time storage)
    EventType VARCHAR(50),                  -- Event type (optional string with a max length of 50)
    EventReason VARCHAR(255),               -- Event reason (optional string with a max length of 255)
    IsOvernight BOOLEAN,                    -- Indicates if the flight is overnight (BOOLEAN)
    DelayInMinutes INT,                     -- Delay in minutes (optional INT)
    NumberOfPax INT NOT NULL,               -- Number of passengers (INT)
    PRIMARY KEY (Id)                        -- Primary key on Id
);

CREATE TABLE PassengerCompensation (
    Id INT NOT NULL AUTO_INCREMENT,          -- Auto-incrementing primary key
    PassengerKey VARCHAR(50) NOT NULL,       -- Unique identifier for the passenger
    FlightKey VARCHAR(50) NOT NULL,          -- Unique identifier for the flight
    Pnr VARCHAR(10) NOT NULL,                -- Passenger Name Record (PNR), alphanumeric, up to 10 characters
    FirstName VARCHAR(50) NOT NULL,          -- First name of the passenger
    LastName VARCHAR(50) NOT NULL,           -- Last name of the passenger
    Phone VARCHAR(15),                       -- Phone number, max 15 characters
    Email VARCHAR(100),                      -- Email address, max 100 characters
    EventReason VARCHAR(50),                 -- Reason for the event (e.g., Cancel, Delay, Unknown)
    CabinType VARCHAR(20),                   -- Cabin type (Economy, Premium, Business)
    PaxStatus VARCHAR(20),                   -- Passenger status (Gold, Silver, Platinum, General)
    IsEligible BOOLEAN,                      -- Indicates if the passenger is eligible for compensation (true/false)
    Compensation VARCHAR(50),                -- Compensation type (Hotel, Meal, Voucher, Miles, etc.)
    Status VARCHAR(20),                      -- Compensation status (Offered, Pending, Accepted, etc.)
    AgentRemarks TEXT,                       -- Remarks from the agent handling the compensation request
    Requester VARCHAR(20),                   -- Who requested the compensation: Auto, Agent
    PRIMARY KEY (Id)                        -- Primary key on Id
);

CREATE TABLE CompensationHistory (
    Id INT NOT NULL AUTO_INCREMENT,          -- Auto-incrementing unique identifier for each compensation record
    PassengerKey VARCHAR(50) NOT NULL,       -- Unique identifier for the passenger (up to 50 characters)
    CompType VARCHAR(100) NOT NULL,          -- Type of compensation (e.g., "Baggage Issue", "Flight Delay")
    CompValue VARCHAR(50) NOT NULL,          -- Value or amount of the compensation (up to 50 characters)
    CompStatus VARCHAR(50) NOT NULL,         -- Current status of the compensation (e.g., "Pending", "Approved", "Rejected")
    PRIMARY KEY (Id)                         -- Sets Id as the primary key
);

-- truncate table CompensationHistory
Select * from Flight;
Select * from PassengerCompensation;
Select * from CompensationHistory;









