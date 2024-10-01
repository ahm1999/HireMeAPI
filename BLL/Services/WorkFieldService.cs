using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HireMeAPI.BLL.Services
{
    public class WorkFieldService : IWorkFieldService
    {
        private readonly AppDbContext _context; 
        public WorkFieldService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<WorkFieldServiceResponse> AddWorkField(WorkFieldDTO userData)
        {

            WorkFields _workFields = new()
            {
                Id = Guid.NewGuid(),
                Name = userData.Name,
                Description = userData.Description

            };

            await _context.WorkFields.AddAsync(_workFields);
            await _context.SaveChangesAsync();
            List<WorkFields> res = new();
            res.Add(_workFields);
            return new WorkFieldServiceResponse(true, "WorkField added succesfully", res);

        }

        public async Task<WorkFieldServiceResponse> GetAllWorkField()
        {
            List<WorkFields> workFields = await _context.WorkFields.ToListAsync();

            return new WorkFieldServiceResponse(true, "WorkFields",workFields);

        }

        public async Task<WorkFieldServiceResponse> RemoveWrokField(Guid WorkFieldId)
        {
            var _workField = await _context.WorkFields.FirstOrDefaultAsync(wf => wf.Id == WorkFieldId);
            if(_workField == null) return new WorkFieldServiceResponse(false, "this workField doesn't exist");

            _context.WorkFields.Remove(_workField);
            await _context.SaveChangesAsync();
            return new WorkFieldServiceResponse(true, "WorkField deleted Succesfully");
        }
    }

    public record WorkFieldServiceResponse(bool Status, string messege) {
        public List<WorkFields> WorkFields { get; set;  }
        public WorkFieldServiceResponse(bool Status, string messege,List<WorkFields> workFields) :this(Status,messege)
        {
            this.WorkFields = workFields;
        }
    };
}
