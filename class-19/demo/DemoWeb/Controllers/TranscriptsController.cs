using System.Collections.Generic;
using System.Threading.Tasks;
using DemoWeb.Models;
using DemoWeb.Models.Api;
using DemoWeb.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWeb.Controllers
{
    [Route("api/Students/{studentId}/Transcript")]
    [ApiController]
    public class TranscriptsController : ControllerBase
    {
        private readonly ITranscriptRepository transcriptRepository;

        public TranscriptsController(ITranscriptRepository transcriptRepository)
        {
            this.transcriptRepository = transcriptRepository;
        }

        // GET: api/<TranscriptsController>
        [HttpGet]
        public async Task<List<TranscriptDto>> Get(int studentId)
        {
            return await transcriptRepository.GetAll(studentId);
        }

        // GET api/<TranscriptsController>/5
        [HttpGet("{courseId}")]
        public async Task<ActionResult<TranscriptDto>> Get(int studentId, int courseId)
        {
            var transcript = await transcriptRepository.GetTranscript(studentId, courseId);
            if (transcript == null)
                return NotFound();

            return transcript;
        }

        // POST api/<TranscriptsController>
        [HttpPost]
        public async Task Post(int studentId, [FromBody] CreateTranscript transcript)
        {
            await transcriptRepository.AddToTranscript(studentId, transcript);
            // TODO: return CreatedAtAction();
        }

        // PUT api/<TranscriptsController>/5
        [HttpPut("{courseId}")]
        public async Task<IActionResult> Put(int studentId, int courseId, [FromBody] CreateTranscript transcript)
        {
            if (courseId != transcript.CourseId)
                return BadRequest();

            if (!await transcriptRepository.UpdateTranscript(studentId, transcript))
                return NotFound();

            return NoContent();
        }

        // DELETE api/<TranscriptsController>/5
        [HttpDelete("{id}")]
        public void Delete(int studentId, int id)
        {
        }
    }
}
