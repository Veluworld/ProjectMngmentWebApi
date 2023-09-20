using ProjectData_API;
using ProjectData_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDataAPI.Models
{
    public class ProjectDataContext : DbContext
    {
        public ProjectDataContext(DbContextOptions<ProjectDataContext> options)
           : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<ProjectData> projects { get; set; }
        public DbSet<TaskData> Tasks { get; set; }
       
    }

}
