using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class EmployeeTypeDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.EmployeeTypes.ToList().Count;
        }
        public static List<EmployeeType> Data { get => db.EmployeeTypes.ToList(); }

        public static bool Add(EmployeeType employeeType)
        {
            try
            {
                if (employeeType != null)
                {
                    db.EmployeeTypes.Add(employeeType);
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
        public static EmployeeType Load(int id)
        {
            try
            {
                EmployeeType employeeType = db.EmployeeTypes.FirstOrDefault(k => k.IdType == id);
                if (employeeType != null)
                {
                    return employeeType;
                }

                return new EmployeeType();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new EmployeeType();
            }
        }
        public static bool Edit(EmployeeType employeeType)
        {
            try
            {
                if (employeeType != null)
                {
                    db.Entry(employeeType).State = EntityState.Modified;
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
                EmployeeType employeeType = db.EmployeeTypes.FirstOrDefault(k => k.IdType == id);
                if (employeeType != null)
                {
                    db.Entry(employeeType).State = EntityState.Deleted;
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
