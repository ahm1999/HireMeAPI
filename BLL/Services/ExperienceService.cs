using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace HireMeAPI.BLL.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService; 
        public ExperienceService(AppDbContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<ExpericeServiceResponse> AddUserExperience(UserExperienceDTO userData)
        {

            Guid ExperienceId = Guid.NewGuid();
            Experience _experience = new()
            {
                Id = ExperienceId,
                ComanyName = userData.ComanyName,
                JobDescription = userData.JobDescription,
                Title = userData.JobTitle,
                StartedFrom = userData.StartedFrom,
                WorkedUntill = userData.WorkedUntill,
                UserId = _userService.GetUserId()    
            };

            await _context.Experiences.AddAsync(_experience);

            List<ExperienceWorkFields> experienceWorkFields_List = await ExperienceWorkFieldsListAsync(userData.WorkFields, ExperienceId);

            await _context.ExperienceWorkFields.AddRangeAsync(experienceWorkFields_List);

            await _context.SaveChangesAsync();

            
            List <Experience> responseList = new();


            _experience.WorkFields = null;
            responseList.Add(_experience);
            return new ExpericeServiceResponse(true,"Experiece Added Succesfully",responseList);

        }

        public async Task<ExpericeServiceResponse> GetUserExperience(Guid UserId)
        {
            var _Experience  = await _context.Experiences.Where(e => e.UserId == UserId).ToListAsync();

            return new ExpericeServiceResponse(true, "User Experience Found", _Experience);

        }

        public Task<ExpericeServiceResponse> GetUserExperienceInWorkField(Guid WorkfieldId)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpericeServiceResponse> RemoveUserExperience(Guid ExperienceId)
        {
            Guid UserId = _userService.GetUserId();
            var _experience = await _context.Experiences.FirstOrDefaultAsync(e => e.Id == ExperienceId && e.UserId == UserId);
            if (_experience == null) {
                return new ExpericeServiceResponse(false, "Experience not found or Unauthorized");
            }

            _context.Experiences.Remove(_experience);
            await _context.SaveChangesAsync();

            return new ExpericeServiceResponse(true, "experience removed Succesfully");
            
        }

        private async Task<List<ExperienceWorkFields>> ExperienceWorkFieldsListAsync(List<Guid> WorkFieldGuids,Guid _ExperiencId) {
            var WorkFields = await _context.WorkFields.Where(wf =>  WorkFieldGuids.Contains(wf.Id)).ToListAsync();

           return WorkFields.Select(wf =>
            {
                return new ExperienceWorkFields()
                {
                    ExperienceId = _ExperiencId,
                    WorkFieldId = wf.Id
                };
            }
                ).ToList();

        }
    }


    public record ExpericeServiceResponse(bool success, string messege) {

        public List<Experience> Experiences { get; set; }
        public ExpericeServiceResponse(bool success, string messege,List<Experience> experiences):this(success,messege)
        {
            this.Experiences = experiences;
        }
    }
     ;
}
