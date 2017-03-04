using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Data;
using SimpleApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    public class LecturerController : Controller
    {
        private readonly ApiContext _context;
        public LecturerController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Lecturer> Get()
        {
            return _context.Lecturer.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetLecturer")]
        public Lecturer Get(int id)
        {
            return _context.Lecturer.FirstOrDefault(t => t.ID == id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Lecturer value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _context.Add(value);
            _context.SaveChanges();
            return CreatedAtRoute("GetLecturer", new { id = value.ID }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Lecturer value)
        {
            if (value.ID != id || value == null)
            {
                return BadRequest();
            }
            var lecturer = _context.Lecturer.FirstOrDefault(t => t.ID == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            lecturer.Research = value.Research;
            lecturer.Name = value.Name;
            lecturer.Nip = value.Nip;
            _context.Lecturer.Update(lecturer);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lecturer = _context.Lecturer.FirstOrDefault(t => t.ID == id);
            if (lecturer == null)
            {
                return NotFound();
            }
            var entity = _context.Lecturer.First(t => t.ID == id);
            _context.Lecturer.Remove(entity);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
