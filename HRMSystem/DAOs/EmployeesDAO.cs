using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.Controllers
{
    public class EmployeesDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.Employees.ToList().Count;
        }
        public static List<Employee> Data { get => db.Employees.ToList(); }

        public static bool Add(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    db.Employees.Add(employee);
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
        public static Employee Load(int id)
        {
            try
            {
                Employee employee = db.Employees.FirstOrDefault(k => k.Id == id);
                if(employee != null)
                {
                    return employee;
                }

                return new Employee();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new Employee();
            }
        }
        public static bool Edit(Employee employee)
        {
            try
            {
                if(employee != null)
                {
                    db.Entry(employee).State = EntityState.Modified;
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
    }
}
