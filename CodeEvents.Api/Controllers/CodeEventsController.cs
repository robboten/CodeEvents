using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeEvents.Api.Core.Entities;
using CodeEvents.Api.Data;
using CodeEvents.Api.Data.Repositories;
using AutoMapper;
using CodeEvents.Api.Core.Dtos;

namespace CodeEvents.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeEventsController : ControllerBase
    {
        private readonly CodeEventsApiContext _context;
        private UnitOfWork _uow;
        private IMapper _mapper;

        public CodeEventsController(CodeEventsApiContext context, IMapper mapper)
        {
            _context = context;
            _uow = new UnitOfWork(context);
            _mapper = mapper;

   
        }

        // GET: api/CodeEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeEvent>>> GetCodeEvent()
        {
          //  var events = await _uow.CodeEventRepository.GetWithLocationAsync();


          //if (events == null)
          //{
          //    return NotFound();
          //}
            var mapped = _mapper.Map<IEnumerable<CodeEventDto>>(await _uow.CodeEventRepository.GetWithLocationAsync());
            return Ok(mapped);
        }

        // GET: api/CodeEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeEvent>> GetCodeEvent(int id)
        {
          if (_context.CodeEvent == null)
          {
              return NotFound();
          }
            var codeEvent = await _context.CodeEvent.FindAsync(id);

            if (codeEvent == null)
            {
                return NotFound();
            }

            return codeEvent;
        }

        // PUT: api/CodeEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeEvent(int id, CodeEvent codeEvent)
        {
            if (id != codeEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(codeEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeEventExists(id))
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

        // POST: api/CodeEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CodeEvent>> PostCodeEvent(CodeEvent codeEvent)
        {
          if (_context.CodeEvent == null)
          {
              return Problem("Entity set 'CodeEventsApiContext.CodeEvent'  is null.");
          }
            _context.CodeEvent.Add(codeEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeEvent", new { id = codeEvent.Id }, codeEvent);
        }

        // DELETE: api/CodeEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeEvent(int id)
        {
            if (_context.CodeEvent == null)
            {
                return NotFound();
            }
            var codeEvent = await _context.CodeEvent.FindAsync(id);
            if (codeEvent == null)
            {
                return NotFound();
            }

            _context.CodeEvent.Remove(codeEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CodeEventExists(int id)
        {
            return (_context.CodeEvent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
