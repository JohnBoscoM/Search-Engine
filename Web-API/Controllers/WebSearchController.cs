using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_API.Interfaces;
using Web_API.Models;
using Web_API.WebSearch_Helper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSearchController : ControllerBase
    {
        private readonly IWebSearch webSearch;

        public WebSearchController()
        {
            webSearch = new WebSearch();
        }
        // GET: api/<WebSearchController>
        [HttpGet("{searchQuery}")]
        public ActionResult GetWebSearchResult(string searchQuery)
        {
            try
            {
                var searchResult = webSearch.Search(searchQuery);
                return Ok(searchResult);

            }
            catch (Exception e)
            {
                return StatusCode(400, new { ErrorMessage = e.Message });
            }
        }
       

        // POST api/<WebSearchController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WebSearchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WebSearchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
