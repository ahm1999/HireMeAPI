using HireMeAPI.BLL.Services;
using HireMeAPI.DTOs;

namespace HireMeAPI.BLL.interfaces
{
    public interface IExperienceService
    {
        public Task<ExpericeServiceResponse> GetUserExperience();
        public Task<ExpericeServiceResponse> GetUserExperienceInWorkField(Guid WorkfieldId);

        public Task<ExpericeServiceResponse> AddUserExperience(UserExperienceDTO userData);

        public Task<ExpericeServiceResponse> RemoveUserExperience(Guid ExperienceId);
    }
}
