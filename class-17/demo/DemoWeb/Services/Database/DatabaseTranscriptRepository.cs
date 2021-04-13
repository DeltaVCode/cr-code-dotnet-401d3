using System;
using System.Threading.Tasks;
using DemoWeb.Data;
using DemoWeb.Models;
using Microsoft.EntityFrameworkCore;

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
            Grade grade = ParseGrade(createTranscript);

            var transcript = new Transcript
            {
                StudentId = studentId,
                CourseId = createTranscript.CourseId,
                Grade = grade,
                Passed = grade != Grade.F,
            };

            _context.Transcripts.Add(transcript);
            await _context.SaveChangesAsync();
        }

        private static Grade ParseGrade(CreateTranscript createTranscript)
        {
            // Turn string Grade into an enum Grade
            return Enum.Parse<Grade>(createTranscript.Grade);
        }

        public async Task<Transcript> GetTranscript(int studentId, int courseId)
        {
            return await _context.Transcripts.FindAsync(studentId, courseId);
        }

        public async Task<bool> UpdateTranscript(int studentId, CreateTranscript transcript)
        {
            var transcriptToUpdate = await _context.Transcripts.FindAsync(studentId, transcript.CourseId);
            if (transcriptToUpdate == null)
                return false;

            // TODO: Update all fields from transcript
            transcriptToUpdate.Grade = ParseGrade(transcript);

            _context.Entry(transcriptToUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
