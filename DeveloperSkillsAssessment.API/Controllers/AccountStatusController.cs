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
    public class AccountStatusController : ControllerBase
    {
        //Logs controller
        private readonly ILogger<AccountStatusController> _logger;

        //Initialise connection strings
        private readonly string connectionString;

        public AccountStatusController(IConfiguration configuration, ILogger<AccountStatusController> logger)
        {
            this.connectionString = configuration.GetValue<string>("AppSettings:Connection_string");
            _logger = logger;
        }

        [HttpGet]
        [Route("GetStats")]

        public async Task<IActionResult> Status()
        {
            try
            {
                DataTable dataTable = new DataTable();
                string storedProcName = "[dbo].[pr_AccGetStatus]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

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
    }
}
