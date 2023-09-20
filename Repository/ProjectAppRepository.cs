using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LoanApp_API.Repository;
using Microsoft.Extensions.Configuration;
using ProjectDataAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProjectData_API.Model;
using System.ComponentModel.DataAnnotations;

namespace LoanApp_API.Repository
{
    public class ProjectAppRepository : IProjectAppRepository
    {

        private IConfiguration Configuration;
        private readonly ProjectDataContext _context;


        public ProjectAppRepository(IConfiguration _configuration, ProjectDataContext context)
        {
            Configuration = _configuration;
            _context = context;
        }       
        /// <summary>
        /// Get All the team Members
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectData>> GetAllTeamMembers()
        {
            try
            {
                var teamMembers = await _context.projects.Select(x => new ProjectData()
                {
                    TeamMemberName = x.TeamMemberName,
                    Experience = x.Experience,
                    SkillSet = x.SkillSet,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    AllocationPercentage = x.AllocationPercentage

                }).OrderByDescending(x => x.Experience).ToListAsync();
                return teamMembers;
            }
            catch(Exception ex) 
            { 
                throw; 
            }
        }

        /// <summary>
        /// Create new member to the project.
        /// </summary>
        /// <param name="projectmdl"></param>
        /// <returns></returns>
        public async Task<bool> InsertProjectData(ProjectData projectmdl)
        {
            try
            {
                var obj = await _context.projects.AddAsync(projectmdl);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex) { throw; }

        }

        /// <summary>
        /// Create task for the project
        /// </summary>
        /// <param name="taskmdl"></param>
        /// <returns></returns>
        public async Task<bool> InsertTaskDetails(TaskData taskmdl)
        {
            try
            {
                var obj = await _context.Tasks.AddAsync(taskmdl);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex) { throw; }
        }

        /// <summary>
        /// get the taks details created to the project
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskData>> GetTaskDetails(int memberId)
        {
            try
            {
                var teamMembers = await _context.Tasks.Select(x => new TaskData()
                { 
                    TaskId = x.TaskId,
                    MemberName = x.MemberName,
                    TaskName = x.TaskName,
                    MemberId = x.MemberId,
                    Deliverables = x.Deliverables,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate}).Where(x=> x.MemberId == memberId).OrderByDescending(x => x.TaskId).ToListAsync();
                return teamMembers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateAllocation(ProjectData prjData)
        {
            try
            {
                _context.projects.Attach(prjData).Property(x => x.AllocationPercentage).IsModified = true;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }




        //public void UpdateLoanApplication(LoanData loanData)
        //{
        //    _context.LoanApplication.Update(loanData);
        //    _context.SaveChanges();
        //}

        //public void DeleteLoanApplication(int id)
        //{
        //    var Loan = _context.LoanApplication.Find(id);
        //    _context.LoanApplication.Remove(Loan);
        //    _context.SaveChanges();

        //}

        //public async Task<LoanData> GetLoanData(int id)
        //{
        //    var loanApplicationData = await _context.LoanApplication.Select(x => new LoanData()
        //    {
        //        ApplicationId = x.ApplicationId,
        //        FirstName = x.FirstName,
        //        LastName = x.LastName,
        //        LoanAmount = x.LoanAmount,
        //        PropertyAddress = x.PropertyAddress
        //    }).Where(x => x.ApplicationId == id).SingleOrDefaultAsync();

        //    return loanApplicationData;
        //}
    }
}
