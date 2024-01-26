using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class EducationTypeDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.EducationTypes.ToList().Count;
        }
        public static List<EducationType> Data { get => db.EducationTypes.ToList(); }

        public static bool Add(EducationType educationType)
        {
            try
            {
                if (educationType != null)
                {
                    db.EducationTypes.Add(educationType);
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
        public static EducationType Load(int id)
        {
            try
            {
                EducationType education = db.EducationTypes.FirstOrDefault(k => k.IdEduType == id);
                if (education != null)
                {
                    return education;
                }

                return new EducationType();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new EducationType();
            }
        }
        public static bool Edit(EducationType educationType)
        {
            try
            {
                if (educationType != null)
                {
                    db.Entry(educationType).State = EntityState.Modified;
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
                EducationType educationType = db.EducationTypes.FirstOrDefault(k => k.IdEduType == id);
                if (educationType != null)
                {
                    db.Entry(educationType).State = EntityState.Deleted;
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
