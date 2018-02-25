using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCoreDemo.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularCoreDemo
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DbsContext _context;

        public ValuesController(DbsContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var str = new List<string>();

            var values = _context.Values.ToList();
            foreach (var value in values)
            {
                str.Add(value.Name);
            }

            return str;
        }
    }
}