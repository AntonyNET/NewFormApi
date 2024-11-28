using Microsoft.EntityFrameworkCore;
using WebForm.Contracts.Candidate;
using WebForm.Entity;

namespace WebForm.Services
{
    public class CandidateService
    {
        private readonly ApplicationDBContext _dbContext;

        public CandidateService(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Guid> CreateCandidate(CreateCandidateRequest request)
        {
            var candidate = new Candidate
            {
                FirstName  = request.FirstName,
                LastName   = request.LastName,
                MiddleName = request.MiddleName
            };

            await _dbContext.Candidates.AddAsync(candidate);
            await _dbContext.SaveChangesAsync();

            return candidate.Id;
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            var allCandidates = await _dbContext.Candidates.ToListAsync();
            return allCandidates;
        }
    }
}
