using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Services
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile profileImage);
    }

    public class KeithFileService : IFileService
    {
        public async Task<string> Upload(IFormFile profileImage)
        {
            return "https://avatars.githubusercontent.com/u/133987?v=4";
        }
    }
}
