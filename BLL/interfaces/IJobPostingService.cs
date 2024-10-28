using HireMeAPI.BLL.Services;
using HireMeAPI.DTOs;

namespace HireMeAPI.BLL.interfaces
{
    public interface IJobPostingService
    {

        Task<JobPostingServiceResponse> createJobPosting(CreateJobPostingDTO jobPostingDTO);
        Task<JobPostingServiceResponse> DeleteJobPosting();
        Task<JobPostingServiceResponse> GetJobPostings();


    }
}
