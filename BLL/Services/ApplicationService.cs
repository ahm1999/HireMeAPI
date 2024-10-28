using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HireMeAPI.BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUserService _userService;
        private readonly AppDbContext _context;
        public ApplicationService(IUserService userService,AppDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<ApplicationServiceResponse> CreateApplication(CreateApplicationDTO createApplication)
        {
            try
            {
                Application ret_application = await _context.Applications.FirstOrDefaultAsync(ap => ap.UserId == createApplication.UserId && ap.JobPostingId == createApplication.JobPostingId);
                if (ret_application is not null)
                {
                    return new ApplicationServiceResponse(false, "Already Applied For this jobPosting");
                }

                Application application = new()
                {
                    JobPostingId = createApplication.JobPostingId,
                    UserId = _userService.GetUserId(),
                    ResumeId = createApplication.ResumeId
                };

                await _context.AddAsync(application);
                await _context.SaveChangesAsync();

                return new ApplicationServiceResponse(true, "Application Created Succesfully");
            }
            catch (DbUpdateException e)
            {
                return new ApplicationServiceResponse(false, $"Database Exception {e.Message}");
            }
            catch (Exception e) {
                return new ApplicationServiceResponse(false, $"Exception {e.Message}");
            }

        }
    }

    public record ApplicationServiceResponse (bool success,string Messege){

        public List<Application> Applications { get; set; }

        public ApplicationServiceResponse(bool success,string Messege,List<Application> applications):this(success,Messege)
        {
            this.Applications = Applications;
        }

    }

}
