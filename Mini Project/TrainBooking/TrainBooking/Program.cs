using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

public static class DataAccess
{
    private static string connectionString;

    static DataAccess()
    {
        connectionString = ConfigurationManager.ConnectionStrings["TrainBookingDBConnectionString"].ConnectionString;
    }

    public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            if (parameters != null)
            {
                adapter.SelectCommand.Parameters.AddRange(parameters);
            }
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }

    public static void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static DataTable GetTrains()
    {
        string query = "SELECT * FROM Trains";
        return ExecuteQuery(query);
    }

    public static void AddBooking(int userId, int trainId, int seatsBooked)
    {
        string query = "INSERT INTO Bookings (UserID, TrainID, SeatsBooked, BookingDate) VALUES (@UserID, @TrainID, @SeatsBooked, @BookingDate)";
        SqlParameter[] parameters = {
            new SqlParameter("@UserID", userId),
            new SqlParameter("@TrainID", trainId),
            new SqlParameter("@SeatsBooked", seatsBooked),
            new SqlParameter("@BookingDate", DateTime.Now)
        };
        ExecuteNonQuery(query, parameters);
    }

    public static void CancelBooking(int bookingId, decimal refundAmount)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    string getBookingQuery = "SELECT TrainID, SeatsBooked FROM Bookings WHERE BookingID = @BookingID";
                    SqlCommand getBookingCmd = new SqlCommand(getBookingQuery, conn, transaction);
                    getBookingCmd.Parameters.AddWithValue("@BookingID", bookingId);

                    SqlDataReader reader = getBookingCmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        throw new Exception("Booking not found.");
                    }

                    int trainId = reader.GetInt32(reader.GetOrdinal("TrainID"));
                    int seatsBooked = reader.GetInt32(reader.GetOrdinal("SeatsBooked"));
                    reader.Close();

                    string deleteQuery = "DELETE FROM Bookings WHERE BookingID = @BookingID";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction))
                    {
                        deleteCmd.Parameters.AddWithValue("@BookingID", bookingId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    string insertQuery = "INSERT INTO Cancellations (BookingID, CancellationDate, RefundAmount) VALUES (@BookingID, @CancellationDate, @RefundAmount)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@BookingID", bookingId);
                        insertCmd.Parameters.AddWithValue("@CancellationDate", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@RefundAmount", refundAmount);
                        insertCmd.ExecuteNonQuery();
                    }

                    DataTable trainTable = GetTrains();
                    DataRow trainRow = trainTable.AsEnumerable().FirstOrDefault(row => (int)row["TrainID"] == trainId);

                    if (trainRow != null)
                    {
                        int availableSeats = (int)trainRow["SeatsAvailable"];
                        EditTrain(trainId, (string)trainRow["TrainName"], (string)trainRow["Destination"], (string)trainRow["StartingLocation"], availableSeats + seatsBooked, (decimal)trainRow["PricePerSeat"]);
                    }
                    else
                    {
                        throw new Exception("Train not found.");
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("An error occurred: " + ex.Message);
                    throw;
                }
            }
        }
    }

    public static DataTable GetUsers()
    {
        string query = "SELECT * FROM Users";
        return ExecuteQuery(query);
    }

    public static DataTable GetBookings()
    {
        string query = "SELECT * FROM Bookings";
        return ExecuteQuery(query);
    }

    public static DataTable GetCancellations()
    {
        string query = "SELECT * FROM Cancellations";
        return ExecuteQuery(query);
    }

    public static void EditTrain(int trainId, string trainName, string destination, string startingLocation, int seatsAvailable, decimal pricePerSeat)
    {
        string query = "UPDATE Trains SET TrainName = @TrainName, Destination = @Destination, StartingLocation = @StartingLocation, SeatsAvailable = @SeatsAvailable, PricePerSeat = @PricePerSeat WHERE TrainID = @TrainID";
        SqlParameter[] parameters = {
            new SqlParameter("@TrainID", trainId),
            new SqlParameter("@TrainName", trainName),
            new SqlParameter("@Destination", destination),
            new SqlParameter("@StartingLocation", startingLocation),
            new SqlParameter("@SeatsAvailable", seatsAvailable),
            new SqlParameter("@PricePerSeat", pricePerSeat)
        };
        ExecuteNonQuery(query, parameters);
    }

    public static void RegisterUser(string username, string password)
    {
        string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
        SqlParameter[] parameters = {
            new SqlParameter("@Username", username),
            new SqlParameter("@Password", password) // Passwords should be hashed in a real-world scenario
        };
        ExecuteNonQuery(query, parameters);
    }

    public static void AddTrain(string trainName, string destination, string startingLocation, int seatsAvailable, decimal pricePerSeat)
    {
        string query = "INSERT INTO Trains (TrainName, Destination, StartingLocation, SeatsAvailable, PricePerSeat) VALUES (@TrainName, @Destination, @StartingLocation, @SeatsAvailable, @PricePerSeat)";
        SqlParameter[] parameters = {
            new SqlParameter("@TrainName", trainName),
            new SqlParameter("@Destination", destination),
            new SqlParameter("@StartingLocation", startingLocation),
            new SqlParameter("@SeatsAvailable", seatsAvailable),
            new SqlParameter("@PricePerSeat", pricePerSeat)
        };
        ExecuteNonQuery(query, parameters);
    }

    public static void DeleteTrain(int trainId)
    {
        string query = "DELETE FROM Trains WHERE TrainID = @TrainID";
        SqlParameter[] parameters = {
            new SqlParameter("@TrainID", trainId)
        };
        ExecuteNonQuery(query, parameters);
    }

    public static void UpdateTrainPrice(int trainId, decimal newPricePerSeat)
    {
        string query = "UPDATE Trains SET PricePerSeat = @PricePerSeat WHERE TrainID = @TrainID";
        SqlParameter[] parameters = {
            new SqlParameter("@TrainID", trainId),
            new SqlParameter("@PricePerSeat", newPricePerSeat)
        };
        ExecuteNonQuery(query, parameters);
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear(); // Clear the console for better readability
            Console.WriteLine("Welcome to Railways");
            Console.WriteLine("Are you an Admin or a Normal User? (Enter 'Admin' or 'User')");
            string userType = Console.ReadLine();

            if (userType.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                AdminActions();
            }
            else if (userType.Equals("User", StringComparison.OrdinalIgnoreCase))
            {
                UserActions();
            }
            else
            {
                Console.WriteLine("Invalid option.");
                WaitForUserInput();
            }
        }
    }

    static void AdminActions()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for better readability
            Console.WriteLine("Admin Panel");
            Console.WriteLine("1. View Trains");
            Console.WriteLine("2. Edit Train Details");
            Console.WriteLine("3. Add New Train");
            Console.WriteLine("4. Delete Train");
            Console.WriteLine("5. Change Train Price");
            Console.WriteLine("6. View All Users");
            Console.WriteLine("7. View All Bookings");
            Console.WriteLine("8. View Cancellation History");
            Console.WriteLine("9. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewTrains();
                    break;
                case "2":
                    EditTrainDetails();
                    break;
                case "3":
                    AddNewTrain();
                    break;
                case "4":
                    DeleteTrain();
                    break;
                case "5":
                    ChangeTrainPrice();
                    break;
                case "6":
                    ViewAllUsers();
                    break;
                case "7":
                    ViewAllBookings();
                    break;
                case "8":
                    ViewCancellationHistory();
                    break;
                case "9":
                    return; // Exit AdminActions and go back to Main menu
                default:
                    Console.WriteLine("Invalid choice.");
                    WaitForUserInput();
                    break;
            }
        }
    }

    static void UserActions()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for better readability
            Console.WriteLine("User Panel");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    BookTickets();
                    break;
                case "3":
                    CancelBooking();
                    break;
                case "4":
                    return; // Exit UserActions and go back to Main menu
                default:
                    Console.WriteLine("Invalid choice.");
                    WaitForUserInput();
                    break;
            }
        }
    }

    static void ViewTrains()
    {
        DataTable trains = DataAccess.GetTrains();
        Console.Clear(); // Clear the console for better readability
        Console.WriteLine("Trains:");
        foreach (DataRow row in trains.Rows)
        {
            Console.WriteLine($"ID: {row["TrainID"]}, Name: {row["TrainName"]}, Destination: {row["Destination"]}, Starting Location: {row["StartingLocation"]}, Seats Available: {row["SeatsAvailable"]}, Price per Seat: {row["PricePerSeat"]}");
        }
        WaitForUserInput();
    }

    static void EditTrainDetails()
    {
        ViewTrains();
        Console.WriteLine("Enter Train ID to edit:");
        int trainId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter New Train Name:");
        string trainName = Console.ReadLine();

        Console.WriteLine("Enter New Destination:");
        string destination = Console.ReadLine();

        Console.WriteLine("Enter New Starting Location:");
        string startingLocation = Console.ReadLine();

        Console.WriteLine("Enter New Seats Available:");
        int seatsAvailable = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter New Price per Seat:");
        decimal pricePerSeat = decimal.Parse(Console.ReadLine());

        DataAccess.EditTrain(trainId, trainName, destination, startingLocation, seatsAvailable, pricePerSeat);
        Console.WriteLine("Train details updated successfully.");
        WaitForUserInput();
    }

    static void AddNewTrain()
    {
        Console.WriteLine("Enter Train Name:");
        string trainName = Console.ReadLine();

        Console.WriteLine("Enter Destination:");
        string destination = Console.ReadLine();

        Console.WriteLine("Enter Starting Location:");
        string startingLocation = Console.ReadLine();

        Console.WriteLine("Enter Seats Available:");
        int seatsAvailable = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Price per Seat:");
        decimal pricePerSeat = decimal.Parse(Console.ReadLine());

        DataAccess.AddTrain(trainName, destination, startingLocation, seatsAvailable, pricePerSeat);
        Console.WriteLine("Train added successfully.");
        WaitForUserInput();
    }

    static void DeleteTrain()
    {
        Console.WriteLine("Enter Train ID to delete:");
        int trainId = int.Parse(Console.ReadLine());

        DataAccess.DeleteTrain(trainId);
        Console.WriteLine("Train deleted successfully.");
        WaitForUserInput();
    }

    static void ChangeTrainPrice()
    {
        Console.WriteLine("Enter Train ID to update price:");
        int trainId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter new Price per Seat:");
        decimal newPricePerSeat = decimal.Parse(Console.ReadLine());

        DataAccess.UpdateTrainPrice(trainId, newPricePerSeat);
        Console.WriteLine("Train price updated successfully.");
        WaitForUserInput();
    }

    static void ViewAllUsers()
    {
        DataTable users = DataAccess.GetUsers();
        Console.Clear(); // Clear the console for better readability
        Console.WriteLine("Users:");
        foreach (DataRow row in users.Rows)
        {
            Console.WriteLine($"ID: {row["UserID"]}, Username: {row["Username"]}");
        }
        WaitForUserInput();
    }

    static void ViewAllBookings()
    {
        DataTable bookings = DataAccess.GetBookings();
        Console.Clear(); // Clear the console for better readability
        Console.WriteLine("Bookings:");
        foreach (DataRow row in bookings.Rows)
        {
            Console.WriteLine($"Booking ID: {row["BookingID"]}, UserID: {row["UserID"]}, TrainID: {row["TrainID"]}, Seats Booked: {row["SeatsBooked"]}, Booking Date: {row["BookingDate"]}");
        }
        WaitForUserInput();
    }

    static void ViewCancellationHistory()
    {
        DataTable cancellations = DataAccess.GetCancellations();
        Console.Clear(); // Clear the console for better readability
        Console.WriteLine("Cancellations:");
        foreach (DataRow row in cancellations.Rows)
        {
            Console.WriteLine($"Cancellation ID: {row["CancellationID"]}, BookingID: {row["BookingID"]}, Cancellation Date: {row["CancellationDate"]}, Refund Amount: {row["RefundAmount"]}");
        }
        WaitForUserInput();
    }

    static void RegisterUser()
    {
        Console.WriteLine("Enter Username:");
        string username = Console.ReadLine();

        Console.WriteLine("Enter Password:");
        string password = Console.ReadLine();

        DataAccess.RegisterUser(username, password);
        Console.WriteLine("User registered successfully.");
        WaitForUserInput();
    }

    static void BookTickets()
    {
        Console.WriteLine("Enter User ID:");
        int userId = int.Parse(Console.ReadLine());

        ViewTrains();
        Console.WriteLine("Enter Train ID to book:");
        int trainId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Number of Seats to Book:");
        int seatsBooked = int.Parse(Console.ReadLine());

        DataTable trainTable = DataAccess.GetTrains();
        DataRow trainRow = trainTable.AsEnumerable().FirstOrDefault(row => (int)row["TrainID"] == trainId);

        if (trainRow != null)
        {
            int availableSeats = (int)trainRow["SeatsAvailable"];
            if (seatsBooked <= availableSeats)
            {
                // Add booking
                DataAccess.AddBooking(userId, trainId, seatsBooked);

                // Update available seats
                DataAccess.EditTrain(trainId, (string)trainRow["TrainName"], (string)trainRow["Destination"], (string)trainRow["StartingLocation"], availableSeats - seatsBooked, (decimal)trainRow["PricePerSeat"]);

                // Get the latest booking details
                DataTable bookings = DataAccess.GetBookings();
                DataRow bookingRow = bookings.AsEnumerable().FirstOrDefault(row => (int)row["UserID"] == userId && (int)row["TrainID"] == trainId && (int)row["SeatsBooked"] == seatsBooked);

                if (bookingRow != null)
                {
                    int bookingId = (int)bookingRow["BookingID"];
                    DateTime bookingDate = (DateTime)bookingRow["BookingDate"];

                    // Print the ticket
                    PrintTicket(bookingId, userId, trainId, seatsBooked, bookingDate);
                }
                else
                {
                    Console.WriteLine("Booking details not found.");
                }
            }
            else
            {
                Console.WriteLine("Not enough seats available.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Train ID.");
        }
        WaitForUserInput();
    }
    static void PrintTicket(int bookingId, int userId, int trainId, int seatsBooked, DateTime bookingDate)
    {
        // Fetch train details
        DataTable trainTable = DataAccess.GetTrains();
        DataRow trainRow = trainTable.AsEnumerable().FirstOrDefault(row => (int)row["TrainID"] == trainId);

        if (trainRow != null)
        {
            string trainName = (string)trainRow["TrainName"];
            string destination = (string)trainRow["Destination"];
            string startingLocation = (string)trainRow["StartingLocation"];
            decimal pricePerSeat = (decimal)trainRow["PricePerSeat"];

            Console.Clear(); // Clear the console for better readability
            Console.WriteLine("Booking Successful!");
            Console.WriteLine("------- Ticket -------");
            Console.WriteLine($"Booking ID: {bookingId}");
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"Train: {trainName}");
            Console.WriteLine($"Destination: {destination}");
            Console.WriteLine($"Starting Location: {startingLocation}");
            Console.WriteLine($"Seats Booked: {seatsBooked}");
            Console.WriteLine($"Price per Seat: {pricePerSeat:C}");
            Console.WriteLine($"Total Price: {seatsBooked * pricePerSeat:C}");
            Console.WriteLine($"Booking Date: {bookingDate}");
            Console.WriteLine("-----------------------");
        }
        else
        {
            Console.WriteLine("Train not found.");
        }
    }
    static void CancelBooking()
    {
        Console.WriteLine("Enter User ID:");
        int userId = int.Parse(Console.ReadLine());

        DataTable bookings = DataAccess.GetBookings();
        var userBookings = bookings.AsEnumerable().Where(row => (int)row["UserID"] == userId).ToList();

        if (userBookings.Count > 0)
        {
            Console.Clear(); // Clear the console for better readability
            Console.WriteLine("Your Booked Tickets:");
            foreach (var row in userBookings)
            {
                Console.WriteLine($"Booking ID: {row["BookingID"]}, TrainID: {row["TrainID"]}, Seats Booked: {row["SeatsBooked"]}, Booking Date: {row["BookingDate"]}");
            }

            Console.WriteLine("Enter Booking ID to cancel:");
            int bookingId = int.Parse(Console.ReadLine());

            var bookingToCancel = userBookings.FirstOrDefault(row => (int)row["BookingID"] == bookingId);

            if (bookingToCancel != null)
            {
                int trainId = (int)bookingToCancel["TrainID"];
                int seatsBooked = (int)bookingToCancel["SeatsBooked"];

                DataTable trainTable = DataAccess.GetTrains();
                DataRow trainRow = trainTable.AsEnumerable().FirstOrDefault(row => (int)row["TrainID"] == trainId);

                if (trainRow != null)
                {
                    decimal refundAmount = seatsBooked * (decimal)trainRow["PricePerSeat"];

                    DataAccess.CancelBooking(bookingId, refundAmount);

                    Console.WriteLine("\nTicket Cancelled Successfully!");
                    Console.WriteLine($"Refund Amount: {refundAmount}");
                }
                else
                {
                    Console.WriteLine("Invalid Train ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Booking ID.");
            }
        }
        else
        {
            Console.WriteLine("No bookings found for this User ID.");
        }
        WaitForUserInput();
    }

    static void WaitForUserInput()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}