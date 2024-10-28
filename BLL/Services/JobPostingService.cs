using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;

namespace HireMeAPI.BLL.Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        public JobPostingService(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<JobPostingServiceResponse> createJobPosting(CreateJobPostingDTO jobPostingDTO)
        {

            try
            {

                JobPosting jobPosting = new()
                {
                    JobPostingId = Guid.NewGuid(),
                    JobTitle = jobPostingDTO.JobTitle,
                    CreatorId = _userService.GetUserId(),
                    JobDescription = jobPostingDTO.JobDescription,


                };

                await _context.jobPostings.AddAsync(jobPosting);
                await _context.SaveChangesAsync();
                var jobPostinglis = new List<JobPosting>(){
                    jobPosting
                };
                return new JobPostingServiceResponse(true, "Job Posting Added succesfully",jobPostinglis);


            }
            catch (Exception e) {

                return new JobPostingServiceResponse(false, $"unExpected Error {e.Message}");

            }


        }

        public Task<JobPostingServiceResponse> DeleteJobPosting()
        {
            throw new NotImplementedException();
        }

        public Task<JobPostingServiceResponse> GetJobPostings()
        {
            throw new NotImplementedException();
        }
    }


    public record JobPostingServiceResponse(bool succes, string Messege) {

        public List<JobPosting> JobPostings { get; set; }

        public JobPostingServiceResponse(bool succes,string Messege,List<JobPosting> jobPostings) :this (succes, Messege)
        {
            this.JobPostings = jobPostings;
        }

    }
}
