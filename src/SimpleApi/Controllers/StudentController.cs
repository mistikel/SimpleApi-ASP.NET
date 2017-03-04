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
    public class StudentController : Controller
    {
        private readonly ApiContext _context;

        public StudentController(ApiContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetStudent")]
        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(t => t.ID == id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _context.Add(value);
            _context.SaveChanges();
            return CreatedAtRoute("GetStudent", new { id = value.ID }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student value)
        {
            if (value.ID != id || value == null)
            {
                return BadRequest();
            }
            var student = _context.Students.FirstOrDefault(t => t.ID == id);
            if(student == null)
            {
                return NotFound();
            }

            student.Major = value.Major;
            student.Name = value.Name;
            student.Nim = value.Nim;
            _context.Students.Update(student);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(t => t.ID == id);
            if(student == null)
            {
                return NotFound();
            }
            var entity = _context.Students.First(t => t.ID == id);
            _context.Students.Remove(entity);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
