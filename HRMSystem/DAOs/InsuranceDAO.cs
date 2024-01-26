using HRMSystem.Models;

namespace HRMSystem.Controllers
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;

    public class InsuranceDAO   
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.InsuranceTypes.ToList().Count;
        }
        public static List<InsuranceType> Data { get => db.InsuranceTypes.ToList(); }

        public bool Add(InsuranceType insurance)
        {
            try
            {
                if(insurance != null)
                {
                    db.InsuranceTypes.Add(insurance);
                    db.SaveChanges();

                    return true; 
                }

                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public InsuranceType Load(int id)
        {
            try
            {
                InsuranceType insurance = db.InsuranceTypes.
                    FirstOrDefault(k => k.IdInsType == id);
                if(insurance != null)
                {
                    return insurance;
                }

                return new InsuranceType();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new InsuranceType();
            }
        }
        public bool Edit(InsuranceType insurance)
        {
            try
            {
                if(insurance != null)
                {
                    db.Entry(insurance).State = EntityState.Modified; 
                    
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                InsuranceType insurance = db.InsuranceTypes.
                    FirstOrDefault(k => k.IdInsType == id);
                if (insurance != null)
                {
                    db.Entry(insurance).State = EntityState.Deleted;
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
