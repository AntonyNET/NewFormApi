using Microsoft.AspNetCore.Mvc;
using WebForm.Contracts.Candidate;
using WebForm.Entity;
using WebForm.Services;

namespace WebForm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidateController
    {
        private readonly CandidateService _candidatesService;

        public CandidateController(CandidateService candidateService)
        {
            _candidatesService = candidateService;
        }

        [HttpGet]
        public async Task<List<Candidate>> GetAllCandidates()
        {
            var allCandidates = await _candidatesService.GetAllCandidates();

            return allCandidates;
        }

        [HttpPost]
        public async Task<Guid> CreateCandidate([FromBody] CreateCandidateRequest request)
        {
            //TODO собственное
            //плохо? то что связываем сервис с входящей DTO
            var candidateId = await _candidatesService.CreateCandidate(request);

            return candidateId;
        }
    }
}
