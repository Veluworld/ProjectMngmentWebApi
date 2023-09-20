using ProjectData_API.Model;
using ProjectDataAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp_API.Repository
{
    public interface IProjectAppRepository
    {
    //    Task<Users> GetUser(string username, string password);
        
        Task<IEnumerable<ProjectData>> GetAllTeamMembers();
        Task<IEnumerable<TaskData>> GetTaskDetails(int memberId);

        //    Task<ProjectData> GetLoanApplication(int id);
        //    //Task<int> AddLoanApplication(LoanData loanData);
        //    Task<ProjectData> InsertLoanApplication(ProjectData _object);
        //    void UpdateLoanApplication(ProjectData loanData);
        //    void DeleteLoanApplication(int id);
        //    Task<ProjectData> GetLoanData(int id);
        Task<bool> InsertProjectData(ProjectData projectmdl);
        Task<bool> InsertTaskDetails(TaskData taskmdl);
        void UpdateAllocation(ProjectData prjData);
        //Task<ProjectData> InsertProjectData(ProjectData projectmdl);
    }
}
