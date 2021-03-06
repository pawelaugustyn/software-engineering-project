﻿using System;
using System.Collections.Generic;
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

        public static SprintModel GetSprintById(int sprintid)
        {
            return SprintAccess.GetSprintById(sprintid);
        }

        public static SprintModel GetMostRecentSprintForProject(int projectid)
        {
            return SprintAccess.GetMostRecentSprintByProjectId(projectid, DateTime.Now);
        }

        public static List<SprintModel> GetNotActiveSprintModels(int projectId)
        {
            return SprintAccess.GetNotActiveSprintsByProjectId(projectId);
        }

        public static void CreateNewSprint(SprintModel sprint)
        {
            SprintAccess.CreateNewSprintForProject(sprint);
        }

        public static Dictionary<string, int> GetSprintCompletionData(int sprintId)
        {
            return SprintAccess.GetSprintCompletionData(sprintId);
        }
    }
}
