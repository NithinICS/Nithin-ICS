using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=ICS-LT-78XDR73\\SQLEXPRESS;Database=EmployeeManagementDB;User Id=sa;Password=123456789;";

            Console.WriteLine("Enter Employee Name:");
            string empName = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary:");
            decimal empSal = 0;
            while (!decimal.TryParse(Console.ReadLine(), out empSal) || empSal < 25000)
            {
                Console.WriteLine("Invalid input. Please enter a salary greater than or equal to 25000:");
            }

            Console.WriteLine("Enter Employee Type (F for Full-time, P for Part-time):");
            char empType = ' ';
            while (!char.TryParse(Console.ReadLine(), out empType) || (empType != 'F' && empType != 'P'))
            {
                Console.WriteLine("Invalid input. Please enter 'F' for Full-time or 'P' for Part-time:");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand insertCommand = new SqlCommand("InsertEmployee", connection))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;

                        insertCommand.Parameters.AddWithValue("@EmpName", empName);
                        insertCommand.Parameters.AddWithValue("@EmpSal", empSal);
                        insertCommand.Parameters.AddWithValue("@EmpType", empType);

                        int newEmpNo = (int)insertCommand.ExecuteScalar();
                        Console.WriteLine($"Successfully added employee with EmpNo: {newEmpNo}");
                    }

                    using (SqlCommand selectCommand = new SqlCommand("SELECT * FROM Employee_Details", connection))
                    {
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            Console.WriteLine("Employee_Details:");
                            Console.WriteLine("EmpNo\tEmpName\tEmpSal\tEmpType");
                            Console.WriteLine("----------------------------------------");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["EmpNo"]}\t{reader["EmpName"]}\t{reader["EmpSal"]}\t{reader["EmpType"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}