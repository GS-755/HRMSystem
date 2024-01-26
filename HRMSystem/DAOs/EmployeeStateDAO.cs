using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class EmployeeStateDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.EmployeeStates.ToList().Count;
        }
        public static List<EmployeeState> Data { get => db.EmployeeStates.ToList(); }

        public static bool Add(EmployeeState employeeState)
        {
            try
            {
                if (employeeState != null)
                {
                    db.EmployeeStates.Add(employeeState);
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
        public static EmployeeState Load(int id)
        {
            try
            {
                EmployeeState employeeState = db.EmployeeStates.FirstOrDefault(k => k.IdState == id);
                if (employeeState != null)
                {
                    return employeeState;
                }

                return new EmployeeState();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new EmployeeState();
            }
        }
        public static bool Edit(EmployeeState employeeState)
        {
            try
            {
                if (employeeState != null)
                {
                    db.Entry(employeeState).State = EntityState.Modified;
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
                EmployeeState employeeState = db.EmployeeStates.FirstOrDefault(k => k.IdState == id);
                if (employeeState != null)
                {
                    db.Entry(employeeState).State = EntityState.Deleted;
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
