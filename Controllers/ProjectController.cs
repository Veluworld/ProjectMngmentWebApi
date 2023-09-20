
using LoanApp_API.Repository;
using ProjectDataAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectData_API.Model;
using System;
using System.Threading.Tasks;

namespace LoanApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {


        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectAppRepository _projectRepository;

        public ProjectController(IProjectAppRepository loanRepository)
        {
            _projectRepository = loanRepository;
        }

        [HttpGet]
        [Route("/projectmgmt/api/v1/manager/list/memberDetails")]
        public async Task<IActionResult> GetAllTeamMembers()
        {
            try
            {
                var TeamMembers = await _projectRepository.GetAllTeamMembers();
                return Ok(TeamMembers);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.InnerException, "Not able to fetch records !!!");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("/projectmgmt/api/v1/member/list/{memberId}")]
        public async Task<IActionResult> GetTasks(int memberId)
        {
            try
            {
                var taskDetails = await _projectRepository.GetTaskDetails(memberId);
                return Ok(taskDetails);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.InnerException, "Not able to get task list !!!");
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("/projectmgmt/api/v1/manager/add-member")]
        public async Task<IActionResult> InsertProjectData(ProjectData projectmdl)
        {
            try
            { 
                var createdoan = await _projectRepository.InsertProjectData(projectmdl);
                return Ok(createdoan);

            }
            catch (Exception Ex)
            {
                _logger.Log(LogLevel.Error, Ex.InnerException, "Not able insert project data !!!");
                return Ok("Error creating new Loan Application !!! : " + Ex.InnerException);
            }
        }

        [HttpPost]
        [Route("/projectmgmt/api/v1/manager/assign-task")]
        public async Task<IActionResult> InsertTaskDetails(TaskData taskmdl)
        {
            try
            {
                var createdoan = await _projectRepository.InsertTaskDetails(taskmdl);
                return Ok(createdoan);

            }
            catch (Exception Ex)
            {
                _logger.Log(LogLevel.Error, Ex.InnerException, "Not able to assign task !!!");
                return Ok("Error creating new Loan Application !!! : " + Ex.InnerException);
            }
        }


        [HttpPut]
        [Route("/projectmgmt/api/v1/manager/update/{allocationPercentage}")]
        public string UpdateAllocation(int memberId, int allocationPercentage)
        {
            try
            {
                ProjectData prjData = new ProjectData();
                prjData.Id = memberId; prjData.AllocationPercentage = allocationPercentage;
                _projectRepository.UpdateAllocation(prjData);                
                return "true";
            }
            catch (Exception Ex)
            {
                _logger.Log(LogLevel.Error, Ex.InnerException, "Not able to update allocation !!!");
                return "Error Updating new Loan Application !!! : " + Ex.InnerException;
            }
        }        
    }
}
