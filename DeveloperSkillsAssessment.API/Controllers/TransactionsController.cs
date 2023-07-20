using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeveloperSkillsAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        //Logs controller
        private readonly ILogger<TransactionsController> _logger;

        //Initialise connection strings
        private readonly string connectionString;

        public TransactionsController(IConfiguration configuration, ILogger<TransactionsController> logger)
        {
            this.connectionString = configuration.GetValue<string>("AppSettings:Connection_string");
            _logger = logger;
        }

        [HttpGet]
        [Route("GetTrans")]

        public async Task<IActionResult> Login(int AccCode)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string storedProcName = "[dbo].[pr_GetAllTransactions]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccCode", AccCode);

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

        [HttpPut]
        [Route("EditTrans")]
        public async Task<IActionResult> EditTrans(int AccCode, decimal amount, string des)
        {
            try
            {
                int result;
                string storedProcName = "[dbo].[pr_EditTrans]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccCode", AccCode);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@des", des);

                    await connection.OpenAsync();
                    var returnValueParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int); // Add a parameter for the return value
                    returnValueParameter.Direction = ParameterDirection.ReturnValue; // Set the direction of the return value parameter
                    await command.ExecuteNonQueryAsync();
                    result = (int)returnValueParameter.Value;
                }

                if (result == 0)
                {
                    // Successful registration
                    return Ok("Transaction successfully deleted!");
                }
                else
                {
                    return Ok("Failed to update Transaction!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("InsertTrans")]
        public async Task<IActionResult> CreateTrans(int AccCode, DateTime transd, decimal amount, string des)
        {
            try
            {
                int result;
                string storedProcName = "[dbo].[pr_InsertTrans]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccCode", AccCode);
                    command.Parameters.AddWithValue("@transd", transd);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@des", des);

                    await connection.OpenAsync();
                    var returnValueParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int); // Add a parameter for the return value
                    returnValueParameter.Direction = ParameterDirection.ReturnValue; // Set the direction of the return value parameter
                    await command.ExecuteNonQueryAsync();
                    result = (int)returnValueParameter.Value;
                }

                if (result == 0)
                {
                    // Successful registration
                    return Ok("Transaction successfully inserted!");
                }
                else
                {
                    return Ok("Failed to insert transaction!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
