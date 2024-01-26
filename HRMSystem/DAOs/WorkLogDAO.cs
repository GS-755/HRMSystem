using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.Controllers
{
    public class WorklogsDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.WorkLogs.ToList().Count;
        }
        public static List<WorkLog> Data { get => db.WorkLogs.ToList(); }

        public static bool Add(WorkLog workLog)
        {
            try
            {
                if(workLog != null)
                {
                    db.WorkLogs.Add(workLog);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public static WorkLog Load(int id)
        {
            try
            {
                WorkLog workLog = db.WorkLogs.FirstOrDefault(k => k.Id == id);
                if (workLog != null)
                {
                    return workLog;
                }

                return new WorkLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new WorkLog();
            }
        }
        public static bool Edit(WorkLog workLog)
        {
            try
            {
                if (workLog != null)
                {
                    db.Entry(workLog).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
