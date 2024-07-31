using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Dapper;
namespace Carisusa_Dapper_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientApiController : ControllerBase
    {

        private SqliteConnection _connection = new SqliteConnection ("Data Source = carisusaData.db");

        [HttpGet("GetClients")]

        public async Task<IActionResult> GetClients(){

            const string query = "Select * from client";

            var result = await _connection.QueryAsync<Client>(query);
            if (result.Count() == 0)
                return BadRequest("No Data");

            return Ok(result);
        }

        [HttpPost("SaveClient")]

        public async Task<IActionResult> SaveClient(Client client) {

            const string query = "Insert into client (ClientName, Residency) Values ( @ClientName, @Residency ); Select * from client order by Id desc limit 1";
            var result = await _connection.QueryAsync<Client>(query, client);
            return Ok(result);
        }

        [HttpPut("UpdateClient")]

        public async Task<IActionResult> UpdateClient(int Id, Client client) {

            const string query = "Update client set ClientName = @ClientName, Residency = @Residency where Id = @Id; Select * from client where Id = @Id limit 1";  
            var result = await _connection.QueryAsync<Client>(query, new{
                Id = Id,
                ClientName = client.ClientName,
                Residency = client.Residency
            });

            return Ok(result);
        }

        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int Id){
            
            const string query = "Delete From client where Id = @Id; ";
            
            await _connection.QueryAsync<Client>(query, new { Id = Id,});

            return Ok();
        }
    }
}

public class Client{
    public int Id { get; set;}
    public string? ClientName { get; set;}
    public string? Residency { get; set;}

}