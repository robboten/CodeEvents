namespace CodeEvents.Api.Data.Repositories
{
    public class UnitOfWork
    {
        private readonly CodeEventsApiContext _context;
        public CodeEventRepository CodeEventRepository { get; set; }
        public UnitOfWork(CodeEventsApiContext context)
        {
         _context= context;
            CodeEventRepository = new CodeEventRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
