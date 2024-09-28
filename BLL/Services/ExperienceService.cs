using HireMeAPI.BLL.interfaces;
using HireMeAPI.DTOs;

namespace HireMeAPI.BLL.Services
{
    public class ExperienceService : IExperienceService
    {
        public Task<ExpericeServiceResponse> AddUserExperience(UserExperienceDTO userData)
        {
            throw new NotImplementedException();
        }

        public Task<ExpericeServiceResponse> GetUserExperience()
        {
            throw new NotImplementedException();
        }

        public Task<ExpericeServiceResponse> GetUserExperienceInWorkField(Guid WorkfieldId)
        {
            throw new NotImplementedException();
        }

        public Task<ExpericeServiceResponse> RemoveUserExperience(Guid ExperienceId)
        {
            throw new NotImplementedException();
        }
    }

    public record ExpericeServiceResponse(bool success);
}
