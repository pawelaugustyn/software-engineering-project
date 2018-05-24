﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrumIt.DataAccess;

namespace ScrumIt.Models
{
    internal class SprintModel
    {
        private DateTime _endDateTime;
        private DateTime _startDateTime;
        public int SprintId { get; set; } = 0;
        public int ParentProjectId { get; set; } = 0;

        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        public DateTime EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        public SprintModel()
        {

        }

        public SprintModel(int sprintid, int parentProjectId, string startDate, string endDate)
        {
            SprintId = sprintid;
            ParentProjectId = parentProjectId;
            DateTime.TryParse(startDate, out _startDateTime);
            DateTime.TryParse(endDate, out _endDateTime);
        }

        public static SprintModel GetSprintById(int sprint_id)
        {
            return SprintAccess.GetSprintById(sprint_id);
        }

        public static SprintModel GetCurrentSprintForProject(int project_id)
        {
            return SprintAccess.GetSprintByProjectIdAndDate(project_id, DateTime.Now);
        }

        public static List<SprintModel> GetAllSprintsInAProject(int project_id)
        {
            return SprintAccess.GetAllSprintsInAProject(project_id);
        }
    }
}
