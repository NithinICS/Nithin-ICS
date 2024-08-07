CREATE DATABASE TrainBookingDB;
USE TrainBookingDB;

-- Table to store train details
CREATE TABLE Trains (
    TrainID INT PRIMARY KEY IDENTITY,
    TrainName NVARCHAR(100),
    Destination NVARCHAR(100),
    StartingLocation NVARCHAR(100),
    SeatsAvailable INT,
    PricePerSeat DECIMAL(10, 2)
)

-- Table to store user details
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50),
    Password NVARCHAR(50),
    IsAdmin BIT
);

-- Table to store bookings
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY,
    UserID INT,
    TrainID INT,
    SeatsBooked INT,
    BookingDate DATETIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (TrainID) REFERENCES Trains(TrainID)
);

USE TrainBookingDB;

-- Table to store cancellation details
CREATE TABLE Cancellations (
    CancellationID INT PRIMARY KEY IDENTITY,
    BookingID INT,
    CancellationDate DATETIME,
    RefundAmount DECIMAL(10, 2),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);

-- Insert Users
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('admin1', 'password1A', 1);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user1', 'password1', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user2', 'password2', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user3', 'password3', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user4', 'password4', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user5', 'password5', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user6', 'password6', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user7', 'password7', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user8', 'password8', 0);
INSERT INTO Users (Username, Password, IsAdmin) VALUES ('user9', 'password9', 0);

Select * from Users

-- Insert Train Details
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Rajdhani Express', 'Delhi', 'Mumbai', 300, 2000.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Shatabdi Express', 'Bangalore', 'Chennai', 250, 1500.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Duronto Express', 'Kolkata', 'Delhi', 280, 1800.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Garib Rath', 'Mumbai', 'Delhi', 320, 1200.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Nandigram Express', 'Hyderabad', 'Bangalore', 260, 1400.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Jan Shatabdi', 'Chennai', 'Madurai', 240, 1000.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Express 12345', 'Delhi', 'Lucknow', 200, 1600.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Udyan Express', 'Pune', 'Nagpur', 220, 1300.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Swaraj Express', 'Delhi', 'Amritsar', 270, 1700.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Superfast Express', 'Kolkata', 'Chennai', 300, 1900.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Humsafar Express', 'Mumbai', 'Delhi', 250, 2200.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Mahatma Gandhi Express', 'Delhi', 'Patna', 230, 1400.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Kavi Guru Express', 'Kolkata', 'Bhubaneswar', 200, 1300.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Yuva Express', 'Chennai', 'Hyderabad', 250, 1500.00);
INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES ('Narmada Express', 'Bhopal', 'Mumbai', 240, 1600.00);


select * from Trains
Select * from Users
select * from Bookings
select * from Cancellations


SELECT BookingID FROM Bookings;






















Declare @BookingID INT;

SELECT BookingID 
FROM Bookings 
WHERE BookingID = @BookingID;



set @BookingID=ISNull;

