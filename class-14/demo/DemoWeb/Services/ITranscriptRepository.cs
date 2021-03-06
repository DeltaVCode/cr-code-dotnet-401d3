using System.Threading.Tasks;
using DemoWeb.Models;

namespace DemoWeb.Services
{
    public interface ITranscriptRepository
    {
        Task AddToTranscript(int studentId, CreateTranscript transcript);
        Task<Transcript> GetTranscript(int studentId, int courseId);
    }
}
