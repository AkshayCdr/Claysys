using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WatchWorld.Models;

namespace WatchWorld.Repository
{
    public class RegistrationRepository
    {
        SqlConnection connectionLink = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        SqlCommand command;

        SqlDataAdapter adapter;

        DataTable table;

        public List<Registration> GetUsers()
        {
            command = new SqlCommand("sp_SelectAllRegistration", connectionLink);
            command.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            List<Registration> list = new List<Registration>();
            foreach (DataRow table in table.Rows)
            {
                list.Add(new Registration
                {
                    Id = Convert.ToInt32(table["Id"]),
                    Name = table["Name"].ToString(),
                    Dob = DateTime.Parse(table["Dob"].ToString()),
                    Age = Convert.ToInt32(table["Age"]),
                    Gender = table["Gender"].ToString(),
                    Phone = table["Phone"].ToString(),
                    Email = table["Email"].ToString(),
                    State = table["State"].ToString(),
                    City = table["City"].ToString(),
                    Username = table["Username"].ToString(),
                    Password = table["Password"].ToString(),
                    

                });
            }
            return list;
        }

        public bool InsertUser(Registration registration)
        {
            try
            {
                command = new SqlCommand("sp_InsertRegistration", connectionLink);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", registration.Name);
                command.Parameters.AddWithValue("@dob", registration.Dob);
                command.Parameters.AddWithValue("@age", registration.Age);
                command.Parameters.AddWithValue("@gender", registration.Gender);
                command.Parameters.AddWithValue("@phone", registration.Phone);
                command.Parameters.AddWithValue("@email", registration.Email);
                command.Parameters.AddWithValue("@state", registration.State);
                command.Parameters.AddWithValue("@city", registration.City);
                command.Parameters.AddWithValue("@username", registration.Username);
                command.Parameters.AddWithValue("@password", registration.Password);

                connectionLink.Open();
                int r = command.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateUser(Registration registration)
        {
            try
            {
                command = new SqlCommand("sp_UpdateRegistration", connectionLink);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", registration.Name);
                command.Parameters.AddWithValue("@dob", registration.Dob);
                command.Parameters.AddWithValue("@age", registration.Age);
                command.Parameters.AddWithValue("@gender", registration.Gender);
                command.Parameters.AddWithValue("@phone", registration.Phone);
                command.Parameters.AddWithValue("@email", registration.Email);
                command.Parameters.AddWithValue("@state", registration.State);
                command.Parameters.AddWithValue("@city", registration.City);
                command.Parameters.AddWithValue("@username", registration.Username);
                command.Parameters.AddWithValue("@password", registration.Password);
                command.Parameters.AddWithValue("@id", registration.Id);

                connectionLink.Open();
                int r = command.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteUser(int id)
        {
            try
            {
                command = new SqlCommand("sp_DeleteRegistration", connectionLink);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                connectionLink.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}