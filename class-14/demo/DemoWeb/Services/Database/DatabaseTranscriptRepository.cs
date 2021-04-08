using System.Threading.Tasks;
using DemoWeb.Data;
using DemoWeb.Models;

namespace DemoWeb.Services.Database
{
    public class DatabaseTranscriptRepository : ITranscriptRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseTranscriptRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task AddToTranscript(int studentId, CreateTranscript createTranscript)
        {
            var transcript = new Transcript
            {
                StudentId = studentId,
                CourseId = createTranscript.CourseId,
                Grade = createTranscript.Grade,
                Passed = createTranscript.Grade != Grade.F,
            };

            _context.Transcripts.Add(transcript);
            await _context.SaveChangesAsync();
        }

        public async Task<Transcript> GetTranscript(int studentId, int courseId)
        {
            return await _context.Transcripts.FindAsync(studentId, courseId);
        }
    }
}
