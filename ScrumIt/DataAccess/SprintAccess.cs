﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SprintModel sprint = new SprintModel();
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
                        "select * from sprints where project_id = @projectid and sprint_start > @currentdate order by sprint_start top 1;")
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
                                SprintId = (int)reader[0],
                                ParentProjectId = (int)reader[1],
                                StartDateTime = (DateTime)reader[2],
                                EndDateTime = (DateTime)reader[3]
                            };
                            break; //ten oto break powinien byc chyba wyrzucony, i sprawdzanie czy faktycznie byla to jedna wartosc powinna byc robiona przez test
                        }
                        //ostatni ukonczony sprint
                        //jesli nie ma zaplanowanego kolejnego sprintu, pobierz z bazy wszystkie sprinty dla danego projektu, uszereguj malejaco pod wzgledem daty zakonczenia i wez pierwszy rekord, czyli ostatni ukonczony sprint
                        if (!checkIfAnyResults)
                        {
                            cmd = new NpgsqlCommand(
                                "select * from sprints where project_id = @projectid and sprint_end < @currentdate order by sprint_end desc top 1;")
                            {
                                Connection = Connection.Conn
                            };

                            cmd.Parameters.AddWithValue("projectid", projectid);
                            cmd.Parameters.AddWithValue("currentdate", datetime);
                            using (var reader2 = cmd.ExecuteReader())
                            {
                                while (reader2.Read())
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
                    }
                }
                return sprint;
            }
        }

        public static long GetEstimatesOfTasksCompletedInSprint(int sprintid)
        {
            long estimates_of_completed_tasks = 0;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select sum(task_estimated_time) from tasks where sprint_id=@sprint_id and task_stage=3;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", sprintid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            // Co zwracamy, gdy suma z bazy wynosi NULL ??
                            estimates_of_completed_tasks = (long) reader[0];
                        }

                        break;
                    }
                }
            }

            return estimates_of_completed_tasks;
        }

        public static long GetEstimatesOfAllTasksInSprint(int sprintid)
        {
            long estimates_of_all_tasks = 0;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select  sum(task_estimated_time) from tasks where sprint_id=@sprint_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", sprintid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            // Co zwracamy, gdy suma z bazy wynosi NULL ??
                            estimates_of_all_tasks = (long) reader[0];
                        }

                        break;
                    }
                }
            }

            return estimates_of_all_tasks;
        }
    }
}
