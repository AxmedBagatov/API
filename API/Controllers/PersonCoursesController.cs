using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonCoursesController : ControllerBase
    {
        private readonly webportalContext _context;

        public PersonCoursesController(webportalContext context)
        {
            _context = context;
        }

        // GET: api/PersonCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonCourse>>> GetPersonCourses()
        {
          if (_context.PersonCourses == null)
          {
              return NotFound();
          }
            return await _context.PersonCourses.ToListAsync();
        }

        // GET: api/PersonCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonCourse>> GetPersonCourse(int id)
        {
          if (_context.PersonCourses == null)
          {
              return NotFound();
          }
            var personCourse = await _context.PersonCourses.FindAsync(id);

            if (personCourse == null)
            {
                return NotFound();
            }

            return personCourse;
        }

        // PUT: api/PersonCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonCourse(int id, PersonCourse personCourse)
        {
            if (id != personCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(personCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonCourse>> PostPersonCourse(PersonCourse personCourse)
        {
          if (_context.PersonCourses == null)
          {
              return Problem("Entity set 'webportalContext.PersonCourses'  is null.");
          }
            _context.PersonCourses.Add(personCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonCourse", new { id = personCourse.Id }, personCourse);
        }

        // DELETE: api/PersonCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonCourse(int id)
        {
            if (_context.PersonCourses == null)
            {
                return NotFound();
            }
            var personCourse = await _context.PersonCourses.FindAsync(id);
            if (personCourse == null)
            {
                return NotFound();
            }

            _context.PersonCourses.Remove(personCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonCourseExists(int id)
        {
            return (_context.PersonCourses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
