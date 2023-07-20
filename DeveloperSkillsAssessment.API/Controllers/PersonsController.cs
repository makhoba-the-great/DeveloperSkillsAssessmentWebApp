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
    public class PersonsController : ControllerBase
    {
        //Logs controller
        private readonly ILogger<PersonsController> _logger;

        //Initialise connection strings
        private readonly string connectionString;

        public PersonsController(IConfiguration configuration, ILogger<PersonsController> logger)
        {
            this.connectionString = configuration.GetValue<string>("AppSettings:Connection_string");
            _logger = logger;
        }

        [HttpGet]
        [Route("GetPersons")]

        public async Task<IActionResult> GetPersons()
        {
            try
            {
                DataTable dataTable = new DataTable();
                string storedProcName = "[dbo].[pr_GetAllPersons]";
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
