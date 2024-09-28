using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;

namespace HireMeAPI.BLL.interfaces
{
    public interface IResumeService
    {
        public Task<ResumeServiceRespoonse> AddResumeAsync(AddResumeDTO resumeDTO);
        public Task<ResumeServiceRespoonse> DeleteAsync(Guid ResumeId);
        public Task<ResumeServiceRespoonse> GetAllUserResumes();

    }

    public record ResumeServiceRespoonse(bool Success,string messege, List<Resume> Resumes);
}
