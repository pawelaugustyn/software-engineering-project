using ScrumIt.DataAccess;


namespace ScrumIt.Models
{
    class ProjectModel
    {
        public int ProjectId { get; set; } = 0;
        public string ProjectName { get; set; }
        public string ProjectColor { get; set; }
 
 
        public static ProjectModel GetProjectById(int projectid)
        {
            return ProjectAccess.GetProjectById(projectid);
        }
 
        public static ProjectModel GetProjectByName(string projectname)
        {
            return ProjectAccess.GetProjectByName(projectname);
        }

        public static bool CreateNewProject(ProjectModel addedProject)
        {
            return ProjectAccess.CreateNewProject(addedProject);
        }
    }
}
