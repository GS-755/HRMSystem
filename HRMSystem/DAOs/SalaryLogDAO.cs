using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class SalaryLogDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.SalaryLogs.ToList().Count;
        }
        public static List<SalaryLog> Data { get => db.SalaryLogs.ToList(); }

        public static bool Add(SalaryLog salaryLog)
        {
            try
            {
                if (salaryLog != null)
                {
                    db.SalaryLogs.Add(salaryLog);
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
        public static SalaryLog Load(int id)
        {
            try
            {
                SalaryLog salaryLog = db.SalaryLogs.FirstOrDefault(k => k.Id == id);
                if (salaryLog != null)
                {
                    return salaryLog;
                }

                return new SalaryLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new SalaryLog();
            }
        }
        public static bool Edit(SalaryLog salaryLog)
        {
            try
            {
                if (salaryLog != null)
                {
                    db.Entry(salaryLog).State = EntityState.Modified;
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
