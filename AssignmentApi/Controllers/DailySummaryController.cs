using AssignmentApi.Models;
using AssignmentApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySummaryController : ControllerBase
    {
        private IDailySummaryService dailySummaryService;
        public DailySummaryController(IDailySummaryService dailySummaryService) { this.dailySummaryService = dailySummaryService; }

        // GET api/<DailySummaryController>/5
        [HttpGet("{employeeId}")]
        public ResponseModel Get(long employeeId)
        {
            var dailySummary = dailySummaryService.GetDailySummary(employeeId);
            return new ResponseModel(200, dailySummary);    
        }

        [HttpGet("GetPerDaySalary/{employeeId}")]
        public ResponseModel GetPerDaySalary(long employeeId)
        {
            var data = dailySummaryService.GetPerDaySalary(employeeId);
            return new ResponseModel(200, data);
        }

        // POST api/<DailySummaryController>
        [HttpPost]
        public long Post([FromBody] TblDailySummary dailySummary)
        {
            return dailySummaryService.AddDailySummary(dailySummary);
        }

        // DELETE api/<DailySummaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dailySummaryService.DeleteDailySummary(id);
        }
    }
}
