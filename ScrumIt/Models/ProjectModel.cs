﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrumIt.DataAccess;


namespace ScrumIt.Models
{
    class ProjectModel
    {
        public int ProjectId { get; set; } = 0;
        public string ProjectName { get; set; }
        public string ProjectColor { get; set; }
        public int TeamId { get; set; }
 
 
        public static ProjectModel GetProjectById(int projectid)
        {
            return new ProjectModel();
        }
 
        public static ProjectModel GetProjectByName(string projectname)
        {
            return new ProjectModel();
        }
 
        public static ProjectModel GetProjectByTeamId(int teamid)
        {
            return new ProjectModel();
        }
    }
}
