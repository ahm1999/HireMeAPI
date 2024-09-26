using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HireMeAPI.BLL.Services
{
    public class ResumeService : IResumeServic
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        public ResumeService(AppDbContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<ResumeServiceRespoonse> AddResumeAsync(AddResumeDTO resumeDTO)
        {
            Resume resume = new()
            {
                Id = Guid.NewGuid(),
                Title = resumeDTO.Title,
                UserId = _userService.GetUserId(),
                Description = resumeDTO.Description,
                FileUrl = resumeDTO.FileUrl
                
            };
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();

            List<Resume> resList = new();
            resList.Add(resume);
            return new ResumeServiceRespoonse(true, "Resume added Succesfully",resList);
        }

        public async Task<ResumeServiceRespoonse> DeleteAsync(Guid ResumeId)
        {
            var _resume  =  await _context.Resumes.FirstOrDefaultAsync(r => r.Id == ResumeId && r.UserId == _userService.GetUserId());
            List<Resume> resList = new();


            if (_resume  is null) return new ResumeServiceRespoonse(false, "No resume with this id exists", resList);

            _context.Resumes.Remove(_resume);
            await _context.SaveChangesAsync();

            return new ResumeServiceRespoonse(true, "Resume removed succesfully", resList);

        }

        public async Task<ResumeServiceRespoonse> GetAllUserResumes()
        {
            Guid UserID = _userService.GetUserId();

            var resumes = await _context.Resumes.Where(r => r.UserId == UserID).ToListAsync();

            return new ResumeServiceRespoonse(true, "operation success", resumes);
        }
    }
}
