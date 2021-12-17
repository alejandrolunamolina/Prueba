using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }


        //public IEnumerable<WeatherForecast> Get()
        //{


        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();


        //}
        [HttpGet]
        public JsonResult Get() {

            string query = @"select id, name, price, mrp, stock, isPublished from BDComisiones.dbo.Producto";
            System.Data.DataTable table = new System.Data.DataTable();
            String sqlRecurso = _configuration.GetConnectionString("ProductoConnecion");

            SqlDataReader MyReader;

            using (SqlConnection Mycon = new SqlConnection(sqlRecurso)) 
            {
                Mycon.Open();
                using (SqlCommand Mycommand = new SqlCommand(query, Mycon))
                {
                    MyReader = Mycommand.ExecuteReader();
                    table.Load(MyReader);
                    MyReader.Close();
                    Mycon.Close();
                }
            }

            return new JsonResult(table);

        }


    }
}
