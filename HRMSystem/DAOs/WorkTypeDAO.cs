using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class WorkTypeDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.WorkTypes.ToList().Count;
        }
        public static List<WorkType> Data { get => db.WorkTypes.ToList(); }

        public static bool Add(WorkType workType)
        {
            try
            {
                if (workType != null)
                {
                    db.WorkTypes.Add(workType);
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
        public static WorkType Load(int id)
        {
            try
            {
                WorkType workType = db.WorkTypes.FirstOrDefault(k => k.IdWorkType == id);
                if (workType != null)
                {
                    return workType;
                }

                return new WorkType();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new WorkType();
            }
        }
        public static bool Edit(WorkType workType)
        {
            try
            {
                if (workType != null)
                {
                    db.Entry(workType).State = EntityState.Modified;
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
        public static bool Delete(int id)
        {
            try
            {
                WorkType workType = db.WorkTypes.FirstOrDefault(k => k.IdWorkType == id);
                if (workType != null)
                {
                    db.Entry(workType).State = EntityState.Deleted;
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
