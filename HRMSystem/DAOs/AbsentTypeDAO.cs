using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class AbsentTypeDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.AbsentTypes.ToList().Count;
        }
        public static List<AbsentType> Data { get => db.AbsentTypes.ToList(); }

        public static bool Add(AbsentType absentType)
        {
            try
            {
                if (absentType != null)
                {
                    db.AbsentTypes.Add(absentType);
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
        public static AbsentType Load(int id)
        {
            try
            {
                AbsentType absentType = db.AbsentTypes.FirstOrDefault(k => k.IdAbsentType == id);
                if (absentType != null)
                {
                    return absentType;
                }

                return new AbsentType();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new AbsentType();
            }
        }
        public static bool Edit(AbsentType absentType)
        {
            try
            {
                if (absentType != null)
                {
                    db.Entry(absentType).State = EntityState.Modified;
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
                AbsentType absentType = db.AbsentTypes.FirstOrDefault(k => k.IdAbsentType == id);
                if (absentType != null)
                {
                    db.Entry(absentType).State = EntityState.Deleted;
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
