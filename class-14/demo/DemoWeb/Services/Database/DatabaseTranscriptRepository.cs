using DemoWeb.Data;

namespace DemoWeb.Services.Database
{
    public class DatabaseTranscriptRepository : ITranscriptRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseTranscriptRepository(SchoolDbContext context)
        {
            _context = context;
        }
    }
}
