using HireMeAPI.BLL.Services;
using HireMeAPI.DTOs;

namespace HireMeAPI.BLL.interfaces
{
    public interface IApplicationService
    {

        Task<ApplicationServiceResponse> CreateApplication(CreateApplicationDTO createApplication);

    }
}
