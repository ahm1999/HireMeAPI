using HireMeAPI.BLL.Services;
using HireMeAPI.DTOs;

namespace HireMeAPI.BLL.interfaces
{
    public interface IWorkFieldService
    {
        public Task<WorkFieldServiceResponse> AddWorkField(WorkFieldDTO userData);
        public Task<WorkFieldServiceResponse> RemoveWrokField(Guid WorkFieldId);
        public Task<WorkFieldServiceResponse> GetAllWorkField();


    }
}
