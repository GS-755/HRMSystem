using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class AbsentLogDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.AbsentLogs.ToList().Count;
        }
        public static List<AbsentLog> Data { get => db.AbsentLogs.ToList(); }

        public static bool Add(AbsentLog absentLog)
        {
            try
            {
                if (absentLog != null)
                {
                    db.AbsentLogs.Add(absentLog);
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
        public static AbsentLog Load(int id)
        {
            try
            {
                AbsentLog log = db.AbsentLogs.FirstOrDefault(k => k.Id == id);
                if (log != null)
                {
                    return log;
                }

                return new AbsentLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new AbsentLog();
            }
        }
        public static bool Edit(AbsentLog absentLog)
        {
            try
            {
                if (absentLog != null)
                {
                    db.Entry(absentLog).State = EntityState.Modified;
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
