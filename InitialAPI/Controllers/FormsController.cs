using InitialAPI.Context;
using InitialAPI.DTOs;
using InitialAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InitialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly FormsContext _context;

        public FormsController(FormsContext context)
        {
            _context = context;
        }

        // GET: api/Forms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form>>> GetForms()
        {
            return await _context.Forms.Include(x => x.Fields).ToListAsync();
        }

        // GET: api/Forms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> GetForm(long id)
        {
            var form = await _context.Forms.Include(x => x.Fields).FirstOrDefaultAsync(y => y.Id.Equals(id));

            if (form == null)
            {
                return NotFound();
            }

            return form;
        }


        // POST: api/Forms
        [HttpPost]
        public async Task<ActionResult<Form>> PostForm(Form form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForm", new { id = form.Id }, form);
        }

        // POST: api/Forms/Update
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<Form>> UpdateForm(Form form)
        {
            _context.Forms.Update(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForm", new { id = form.Id }, form);
        }

        // POST: api/Forms
        [HttpPost]
        [Route("Fields")]
        public async Task<ActionResult<Form?>> PostFields(List<FieldDTO> fields)
        {
            try
            {
                _context.Fields.AddRange(fields.Select(a => new Field
                {
                    Title = a.Title,
                    Content = a.Content,
                    Type = a.Type,
                    Form = null,
                    FormId = a.FormId,
                }));
                await _context.SaveChangesAsync();

                return Ok(await _context.Forms.FirstOrDefaultAsync(x => x.Id.Equals(fields.First().FormId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Forms/5
        [HttpDelete("Field/{id}")]
        public async Task<IActionResult> DeleteField(long id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field == null)
            {
                return NotFound();
            }

            _context.Fields.Remove(field);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(long id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormExists(long id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
