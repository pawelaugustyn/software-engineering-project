﻿using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class SprintAccess
    {
        public static SprintModel GetSprintById(int sprintid)
        {
            SprintModel sprint = new SprintModel();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from sprints where sprint_id = @sprintid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprintid", sprintid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sprint = new SprintModel
                        {
                            SprintId = (int)reader[0],
                            ParentProjectId = (int)reader[1],
                            StartDateTime = (DateTime)reader[2],
                            EndDateTime = (DateTime)reader[3]
                        };
                        break;
                    }
                }
            }

            return sprint;
        }

        public static SprintModel GetSprintByProjectIdAndDate(int projectid, DateTime time)
        {
            SprintModel sprint = null;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from sprints where project_id = @projectid and sprint_start < @datestart::timestamp and sprint_end > @dateend::timestamp;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectid);
                string datetime = time.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("datestart", datetime);
                cmd.Parameters.AddWithValue("dateend", datetime);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sprint = new SprintModel
                        {
                            SprintId = (int)reader[0],
                            ParentProjectId = (int)reader[1],
                            StartDateTime = (DateTime)reader[2],
                            EndDateTime = (DateTime)reader[3]
                        };
                        break;
                    }
                }
            }

            return sprint;

        }

        //pobierz najchetniej obecny sprint, jesli nie istnieje to najblizszy zaplanowany sprint, jesli nie ma zaplanowanych sprintow do przodu to ostatni ukonczony
        public static SprintModel GetMostRecentSprintByProjectId(int projectid, DateTime time)
        {
            //current sprint
            SprintModel sprint = GetSprintByProjectIdAndDate(projectid, time);
            if (sprint != null)
                return sprint;
            else
            {
                sprint = new SprintModel();
                using (new Connection())
                {
                    //najblizszy zaplanowany (na przyszlosc) sprint
                    //jesli nie ma current sprintu, pobierz z bazy wszystkie sprinty dla danego projektu, uszereguj rosnaco pod wzgledem daty startu i wez pierwszy rekord, czyli pierwszy zaplanowany sprint

                    var cmd = new NpgsqlCommand(
                        "select * from sprints where project_id = @projectid and sprint_start > @currentdate::timestamp order by sprint_start limit 1;")
                    {
                        Connection = Connection.Conn
                    };
                    cmd.Parameters.AddWithValue("projectid", projectid);
                    var datetime = time.ToString("yyyy-MM-dd hh:mm:ss");
                    cmd.Parameters.AddWithValue("currentdate", datetime);
                    using (var reader = cmd.ExecuteReader())
                    {
                        //flaga do sprawdzania czy udalo sie pobrac jakis zaplanowany sprint, jesli nie to bedziemy wczytywac ostatni ukonczony
                        var checkIfAnyResults = false;
                        while (reader.Read())
                        {
                            checkIfAnyResults = true;
                            sprint = new SprintModel
                            {
                                SprintId = (int) reader[0],
                                ParentProjectId = (int) reader[1],
                                StartDateTime = (DateTime) reader[2],
                                EndDateTime = (DateTime) reader[3]
                            };
                            break; //ten oto break powinien byc chyba wyrzucony, i sprawdzanie czy faktycznie byla to jedna wartosc powinna byc robiona przez test
                        }

                        //ostatni ukonczony sprint
                        //jesli nie ma zaplanowanego kolejnego sprintu, pobierz z bazy wszystkie sprinty dla danego projektu, uszereguj malejaco pod wzgledem daty zakonczenia i wez pierwszy rekord, czyli ostatni ukonczony sprint
                        if (checkIfAnyResults)
                            return sprint;
                    }

                    cmd = new NpgsqlCommand(
                            "select * from sprints where project_id = @projectid and sprint_end < @currentdate::timestamp order by sprint_end desc limit 1;")
                    {
                        Connection = Connection.Conn
                    };

                    cmd.Parameters.AddWithValue("projectid", projectid);
                    cmd.Parameters.AddWithValue("currentdate", datetime);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sprint = new SprintModel
                            {
                                SprintId = (int)reader[0],
                                ParentProjectId = (int)reader[1],
                                StartDateTime = (DateTime)reader[2],
                                EndDateTime = (DateTime)reader[3]
                            };
                            break;
                        }
                    }
                }
                return sprint;
            }
        }

        public static List<SprintModel> GetAllSprintsByProjectId(int projectId)
        {
            var sprintsList = new List<SprintModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from sprints where project_id = @projectid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sprintsList.Add(new SprintModel
                        {
                            SprintId = (int)reader[0],
                            ParentProjectId = (int)reader[1],
                            StartDateTime = (DateTime)reader[2],
                            EndDateTime = (DateTime)reader[3]
                        });
                    }
                }
            }
            return sprintsList.OrderByDescending(c => c.StartDateTime).ToList();
        }

        public static List<SprintModel> GetNotActiveSprintsByProjectId(int projectId)
        {
            //pobieramy wszystkie sprinty
            var sprints = new List<SprintModel>();
            sprints = GetAllSprintsByProjectId(projectId);
            //pobieramy obecnie wyswietlany sprint
            var currentSprint = GetMostRecentSprintByProjectId(projectId, DateTime.Now);
            //usuwamy z listy obecnie wyswietlany sprint
            foreach (var sprint in sprints)
            {
                if (sprint.SprintId == currentSprint.SprintId)
                {
                    sprints.Remove(sprint);
                    break;
                }
            }

            return sprints;
        }

        public static bool CreateNewSprintForProject(SprintModel addedSprint)
        {
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Brak uprawnien.");
            using (new Connection())
            {
                ValidateNewSprint(addedSprint);
                var cmd = new NpgsqlCommand("INSERT INTO sprints VALUES (DEFAULT, @projectid, @start, @end);")
                {
                    Connection = Connection.Conn
                };
                addedSprint.StartDateTime = new DateTime(addedSprint.StartDateTime.Year, addedSprint.StartDateTime.Month, addedSprint.StartDateTime.Day, 0, 0, 0);
                addedSprint.EndDateTime = new DateTime(addedSprint.EndDateTime.Year, addedSprint.EndDateTime.Month, addedSprint.EndDateTime.Day, 23, 59, 59);
                cmd.Parameters.AddWithValue("projectid", addedSprint.ParentProjectId);
                cmd.Parameters.AddWithValue("start", addedSprint.StartDateTime);
                cmd.Parameters.AddWithValue("end", addedSprint.EndDateTime);
                var result = cmd.ExecuteNonQuery();

                if (result != 1)
                    return false;

                cmd = new NpgsqlCommand("SELECT sprint_id FROM sprints ORDER BY sprint_id DESC LIMIT 1;")
                {
                    Connection = Connection.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addedSprint.SprintId = (int)reader[0];
                        break;
                    }
                }
            }

            return true;
        }

        public static DateTime? GetEndOfLastSprintByProjectId(int projectId)
        {
            DateTime? endDate = null;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select max(sprint_end) from sprints where project_id = @projectid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0] != DBNull.Value)
                            endDate = reader.GetDateTime(0);
                    }
                }
            }
            return endDate;
        }

        public static Dictionary<string, int> GetSprintCompletionData(int sprintId)
        {
            var dict = new Dictionary<string, int>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select todo, inprogress, done, total from sprint_completion_new where sprint_id = @sprint_id")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", sprintId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dict.Add("todo", Convert.ToInt32((long) reader[0]));
                        dict.Add("inprogress", Convert.ToInt32((long) reader[1]));
                        dict.Add("done", Convert.ToInt32((long) reader[2]));
                        dict.Add("total", Convert.ToInt32((long) reader[3]));
                        break;
                    }
                }
            }
            return dict;
        }
              
              
        public static List<SprintModel> GetNotNotifiedEndingSprints(int daysTillEnd, bool exclusive = false)
        {
            var sprints = new List<SprintModel>();
            var endTime = DateTime.Now.AddDays(daysTillEnd);
            var currentTime = DateTime.Now;
            using (var c = new Connection(exclusive))
            {
                var cmd = new NpgsqlCommand("select * from sprints where sprint_end < @enddate::timestamp and sprint_end > @currentdate::timestamp and emails_sent='false';")
                {
                    Connection = exclusive ? c.ConnExcl : Connection.Conn
                };
                string endDatetime = endTime.ToString("yyyy-MM-dd hh:mm:ss");
                string currentDatetime = currentTime.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("currentdate", currentDatetime);
                cmd.Parameters.AddWithValue("enddate", endDatetime);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sprints.Add(new SprintModel
                        {
                            SprintId = (int)reader[0],
                            ParentProjectId = (int)reader[1],
                            StartDateTime = (DateTime)reader[2],
                            EndDateTime = (DateTime)reader[3]
                        });
                    }
                }
            }

            return sprints;
        }

        public static bool ChangeEmailSentStatus(int sprintid, bool exclusive = false)
        {
            using (var c = new Connection(exclusive))
            {
                var cmd = new NpgsqlCommand("update sprints set emails_sent='true' where sprint_id=@sprintid;")
                {
                    Connection = exclusive ? c.ConnExcl : Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprintid", sprintid);
                var res = cmd.ExecuteNonQuery();

                return res == 1;
            }
        }

        private static void ValidateNewSprint(SprintModel addedSprint)
        {
            ValidateStartDate(addedSprint);
            ValidateEndDate(addedSprint.EndDateTime);
            ValidateSprintDuration(addedSprint);
        }

        private static void ValidateStartDate(SprintModel sprint)
        {
            if (sprint.StartDateTime == null)
                throw new ArgumentException("Brak daty rozpoczecia sprintu");

            if (sprint.StartDateTime >= sprint.EndDateTime)
                throw new ArgumentException("Rozpoczecie sprintu musi nastapic przed jego zakonczeniem");
        }

        private static void ValidateEndDate(DateTime endDate)
        {
            if (endDate == null)
                throw new ArgumentException("Brak daty zakonczenia sprintu");
        }

        private static void ValidateSprintDuration(SprintModel sprint)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand(@"SELECT
                    sprint_id
                        FROM sprints
                    WHERE(
                    sprint_start <= @param_start
                    AND
                    sprint_end >= @param_start
                    OR
                    sprint_start <= @param_end
                    AND
                    sprint_end >= @param_end
                    OR
                    sprint_start > @param_start
                    AND
                    sprint_start < @param_end
                    AND
                    sprint_end <= @param_end
                    OR
                    sprint_start < @param_start
                    AND
                    sprint_end > @param_start
                    AND
                    sprint_end < @param_end
                    )
                    AND
                        project_id = @param_proj;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("param_start", sprint.StartDateTime);
                cmd.Parameters.AddWithValue("param_end", sprint.EndDateTime);
                cmd.Parameters.AddWithValue("param_proj", sprint.ParentProjectId);
                var res = (int?)cmd.ExecuteScalar();
                if (res != null && res > 0)
                    throw new ArgumentException("Czas trwania sprintu pokrywa sie z czasem innego istniejacego sprintu.");
            }
        }
    }
}
