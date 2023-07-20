using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperSkillsAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //Logs controller
        private readonly ILogger<UsersController> _logger;

        //Initialise connection strings
        private readonly string connectionString;

        public UsersController(IConfiguration configuration, ILogger<UsersController> logger)
        {
            this.connectionString = configuration.GetValue<string>("AppSettings:Connection_string");
            _logger = logger;
        }

        [HttpGet]
        [Route("SubmitLogs")]

        public async Task<IActionResult> Login(string Username, string Password)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string storedProcName = "[dbo].[pr_Login]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    await connection.OpenAsync();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }

                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAccounts")]

        public async Task<IActionResult> GetAccounts(int PersonCode)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string storedProcName = "[dbo].[pr_GetAccounts]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonCode", PersonCode);

                    await connection.OpenAsync();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }

                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteOrg(string IDNum)
        {
            try
            {
                int result;
                string storedProcName = "[dbo].[pr_DeletePerson]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDNum", IDNum);

                    await connection.OpenAsync();
                    var returnValueParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int); // Add a parameter for the return value
                    returnValueParameter.Direction = ParameterDirection.ReturnValue; // Set the direction of the return value parameter
                    await command.ExecuteNonQueryAsync();
                    result = (int)returnValueParameter.Value;
                }

                if (result == 0)
                {
                    // Successful registration
                    return Ok("Person successfully deleted!");
                }
                else
                {
                    return Ok("Failed to delete person!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("EditUser")]
        public async Task<IActionResult> EditUsr(string IDNum,string Name,string Surname)
        {
            try
            {
                int result;
                string storedProcName = "[dbo].[pr_EditPerson]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDNum", IDNum);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Surname", Surname);

                    await connection.OpenAsync();
                    var returnValueParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int); // Add a parameter for the return value
                    returnValueParameter.Direction = ParameterDirection.ReturnValue; // Set the direction of the return value parameter
                    await command.ExecuteNonQueryAsync();
                    result = (int)returnValueParameter.Value;
                }

                if (result == 0)
                {
                    // Successful registration
                    return Ok("Person successfully deleted!");
                }
                else
                {
                    return Ok("Failed to delete person!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult> CreateUsr(string IDNum, string Name, string Surname)
        {
            try
            {
                int result;
                string storedProcName = "[dbo].[pr_InsertUser]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDNum", IDNum);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Surname", Surname);

                    await connection.OpenAsync();
                    var returnValueParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int); // Add a parameter for the return value
                    returnValueParameter.Direction = ParameterDirection.ReturnValue; // Set the direction of the return value parameter
                    await command.ExecuteNonQueryAsync();
                    result = (int)returnValueParameter.Value;
                }

                if (result == 0)
                {
                    // Successful registration
                    return Ok("Person successfully inserted!");
                }
                else
                {
                    return Ok("Failed to insert person!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
