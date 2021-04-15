using System.Collections.Generic;
using System.Threading.Tasks;
using DemoWeb.Models;
using DemoWeb.Models.Api;

namespace DemoWeb.Services
{
    public interface ITranscriptRepository
    {
        Task AddToTranscript(int studentId, CreateTranscript transcript);
        Task<TranscriptDto> GetTranscript(int studentId, int courseId);
        Task<bool> UpdateTranscript(int studentId, CreateTranscript transcript);
        Task<List<TranscriptDto>> GetAll(int studentId);
    }
}
