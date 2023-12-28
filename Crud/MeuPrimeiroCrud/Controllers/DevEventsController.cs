using MeuPrimeiroCrud.Entities;
using MeuPrimeiroCrud.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuPrimeiroCrud.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;
        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEevents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEevents);

        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvents == null)
            {

                return NotFound();
            }
            return Ok(devEvents);

        }

        [HttpPost]
        public IActionResult Post(DevEvents devEvents)
        {
            _context.DevEvents.Add(devEvents);

            return CreatedAtAction(nameof(GetById), new { id = devEvents.Id}, devEvents);

        }

        // api/dev-events/12312421 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvents input)
        {

            var devEvents = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvents == null)
            {

                return NotFound();
            }
            devEvents.update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {


            var devEvents = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvents == null)
            {

                return NotFound();
            }

            return NoContent();
        }

    }
}
