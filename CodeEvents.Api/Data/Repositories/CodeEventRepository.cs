using CodeEvents.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeEvents.Api.Data.Repositories
{
    public class CodeEventRepository
    {
        private readonly CodeEventsApiContext _context;
        public CodeEventRepository(CodeEventsApiContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<CodeEvent>> GetAsync()
        {
            return await _context.CodeEvent.ToListAsync();
        }

        public async Task<IEnumerable<CodeEvent>> GetWithLecturesAsync()
        {
            return await _context.CodeEvent.Include(e=>e.Lectures).ToListAsync();
        }
        public async Task<IEnumerable<CodeEvent>> GetWithLocationAsync()
        {
            return await _context.CodeEvent.Include(e => e.Location).ToListAsync();
        }
    }
}
