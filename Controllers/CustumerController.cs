using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAspCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAspCore.Controllers
{
    [Route("api/custumer")]
    [ApiController]
    public class CustumerController : ControllerBase
    {
        private readonly MyApiContext _context;

        public CustumerController(MyApiContext _context)
        {
            this._context = _context;
        }

        // GET: api/<CustumerController>
        [HttpGet]
        public async Task<List<Custumer>> Get()
        {
            _context.Database.EnsureCreated();

            var custumer = new Custumer
            {
                FirstName = "Mbaye",
                LastName = "THIAM",
                Email = "mbaye123@live.fr"
            };
            _context.Custumers.Add(custumer);
            await _context.SaveChangesAsync();
            return await _context.Custumers.ToListAsync();
        }

        // GET api/<CustumerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustumerController>
        [HttpPost]
        public Custumer Post([FromBody] Custumer custumer)
        {
            _context.Custumers.Add(custumer);
            _context.SaveChanges();
            return custumer;

        }

        // PUT api/<CustumerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustumerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
