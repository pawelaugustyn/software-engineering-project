using System;
using System.Collections.Generic;
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
            SprintModel sprint = null;// = new SprintModel();
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
                    string datetime = time.ToString("yyyy-MM-dd hh:mm:ss");
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

        public static bool CreateNewSprintForProject(SprintModel addedSprint)
        {
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Brak uprawnien.");
            using (new Connection())
            {
                ValidateNewSprint(addedSprint);
                var cmd = new NpgsqlCommand("INSERT INTO sprints VALUES (DEFAULT, @projectid, @start::timestamp, @end::timestamp);")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", addedSprint.ParentProjectId);
                string startDate = addedSprint.StartDateTime.ToString("yyyy-MM-dd hh:mm:ss");
                string endDate = addedSprint.EndDateTime.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("start", startDate);
                cmd.Parameters.AddWithValue("end", endDate);
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
        // pobiera wszystkie sprinty, ktorych data zakonczenia jest wczesniejsza niz obecna data
        public static List<SprintModel> GetOldSprintsByProjectId(int projectid)
        {
            var sprints = new List<SprintModel>();
            var time = DateTime.Now;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from sprints where project_id = @projectid and sprint_end < @currentdate::timestamp;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectid);
                string datetime = time.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("currentdate", datetime);
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

        public static List<SprintModel> GetNotNotifiedEndingSprints(int days_till_end)
        {
            var sprints = new List<SprintModel>();
            var end_time = DateTime.Now.AddDays(days_till_end);
            var current_time = DateTime.Now;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from sprints where sprint_end < @enddate::timestamp and sprint_end > @currentdate::timestamp and emails_sent='false';")
                {
                    Connection = Connection.Conn
                };
                string end_datetime = end_time.ToString("yyyy-MM-dd hh:mm:ss");
                string current_datetime = current_time.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("currentdate", current_datetime);
                cmd.Parameters.AddWithValue("enddate", end_datetime);
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

        public static bool ChangeEmailSentStatus(int sprintid)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("update sprints set emails_sent='true' where sprint_id=@sprintid;")
                {
                    Connection = Connection.Conn
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
            // TODO
            // czy tu potrzebna jest inna walidacja?
            // ograniczenie na dlugosc sprintu (3-31 dni) jest zrobione na frontendzie
        }

        private static void ValidateSprintDuration(SprintModel sprint)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select sprint_id from sprints where ((sprint_start < @param_start::timestamp and sprint_end > @param_start2::timestamp) or (sprint_start < @param_end::timestamp and sprint_end > @param_end2::timestamp)) and project_id = @param_proj;")
                {
                    Connection = Connection.Conn
                };
                string datetimeStart = sprint.StartDateTime.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("param_start", datetimeStart);
                cmd.Parameters.AddWithValue("param_start2", datetimeStart);
                string datetimeEnd = sprint.EndDateTime.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("param_end", datetimeEnd);
                cmd.Parameters.AddWithValue("param_end2", datetimeEnd);
                cmd.Parameters.AddWithValue("param_proj", sprint.ParentProjectId);
                var res = cmd.ExecuteNonQuery();
                if (res > 0)
                    throw new ArgumentException("Czas trwania sprintu pokrywa sie z czasem innego istniejacego sprintu.");
            }
        }
    }
}
