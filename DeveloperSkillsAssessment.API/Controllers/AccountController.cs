using System.Threading.Tasks;
//using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperSkillsAssessment.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //Logs controller
        private readonly ILogger<AccountController> _logger;

        //Initialise connection strings
        private readonly string connectionString;

        public AccountController(IConfiguration configuration, ILogger<AccountController> logger)
        {
            this.connectionString = configuration.GetValue<string>("AppSettings:Connection_string");
            _logger = logger;
        }

        [HttpPost]
        [Route("InsertAcc")]
        public async Task<IActionResult> CreateAcc(int PersonC,string AccNum ,decimal OutStanding ,string status)
        {
            try
            {
                int result;
                string storedProcName = "[dbo].[pr_CreateAcc]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonC", PersonC);
                    command.Parameters.AddWithValue("@AccNum", AccNum);
                    command.Parameters.AddWithValue("@OutStanding", OutStanding);
                    command.Parameters.AddWithValue("@status", status);

                    await connection.OpenAsync();
                    var returnValueParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int); // Add a parameter for the return value
                    returnValueParameter.Direction = ParameterDirection.ReturnValue; // Set the direction of the return value parameter
                    await command.ExecuteNonQueryAsync();
                    result = (int)returnValueParameter.Value;
                }

                if (result == 0)
                {
                    // Successful registration
                    return Ok("Account successfully inserted!");
                }
                else
                {
                    return Ok("Failed to insert account!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("EditAcc")]
        public async Task<IActionResult> EditAcc(string AccNum, decimal OutStan, Boolean Closed,string Status)
        {
            try
            {
                int result;
                string storedProcName = "[dbo].[pr_EditAcc]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccNum", AccNum);
                    command.Parameters.AddWithValue("@OutStan", OutStan);
                    command.Parameters.AddWithValue("@Closed", Closed);
                    command.Parameters.AddWithValue("@Status", Status);

                    await connection.OpenAsync();
                    var returnValueParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int); // Add a parameter for the return value
                    returnValueParameter.Direction = ParameterDirection.ReturnValue; // Set the direction of the return value parameter
                    await command.ExecuteNonQueryAsync();
                    result = (int)returnValueParameter.Value;
                }

                if (result == 0)
                {
                    // Successful registration
                    return Ok("Account successfully edited!");
                }
                else
                {
                    return Ok("Failed to edit account!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
