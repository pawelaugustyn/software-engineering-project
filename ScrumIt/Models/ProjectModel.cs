using System.Collections.Generic;
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

        public static bool DeleteProject(ProjectModel projectToDelete)
        {
            return ProjectAccess.DeleteProject(projectToDelete);
        }

        public static bool UpdateProject(ProjectModel projectToUpdate)
        {
            return ProjectAccess.UpdateProject(projectToUpdate);
        }

        public static void AssignUsersToProject(ProjectModel projectToAssignTo, List<UserModel> usersToAssign)
        {
            ProjectAccess.AssignUsersToProject(projectToAssignTo, usersToAssign);
        }

        public static void AddNewUserToProject(int userId, int projectId)
        {
            ProjectAccess.AddNewUserToProject(userId, projectId);
        }
    }
}
