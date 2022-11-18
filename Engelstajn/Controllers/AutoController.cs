using Engelstajn.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Engelstajn.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace Engelstajn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly DBWSAutoContext _context;
        public AutoController(DBWSAutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List <Auto> autos()
        {
            List <Auto> list = _context.Autos.ToList();
            return list;
        }

        [HttpGet("{modelo}")]
        public List <Auto>  Get(string modelo)
        {
            List <Auto> autos = (from a in _context.Autos where a.Modelo == modelo select a).ToList();
            return autos;
        }
        
        
        [HttpPost]
        public ActionResult Post ( Auto auto)
        {
            _context.Autos.Add(auto);
            _context.SaveChanges();
            return Ok();
        }

        //[HttpGet("{id}")]
        //public ActionResult <Auto> Getid(string id)
        //{
        //    var auto = (from a in _context.Autos where a.Id== id select a).FirstOrDefault();
        //    return auto;
        //}


        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Auto auto) 
        {
            if(id != auto.Id)
            {
                BadRequest();
            }
            _context.Entry(auto).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult <Auto> Delete(string id) 
        {
            var auto = _context.Autos.Find(id);
            if(auto == null) {
                return NotFound();
            }
            _context.Autos.Remove(auto);
            _context.SaveChanges();
            return auto;
        }

        [HttpGet("{marca}/{modelo}")]
        public dynamic Get (string marca, string modelo)
        {
            dynamic autos = (from a in _context.Autos where a.Marca== marca && a.Modelo == modelo select a);
            return autos;
        }

        [HttpGet("{color}")]
        public dynamic Getcolor (string color)
        {
            var autos = (from a in _context.Autos where a.Color== color select a).ToList();
            return autos;
        }
    }
}
